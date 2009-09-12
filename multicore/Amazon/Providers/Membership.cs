/******************************************************************************* 
 *  Copyright 2009 GoVelvet LLC.
 *  Created by typemismatch - http://www.typemismatch.com/
 *  Primary site - http://www.dotnetmulticore.com/ 
 *  Get your source at - http://github.com/typemismatch/multicore/tree/master
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://www.opensource.org/licenses/apache2.0.php
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************  
 * 
 */

using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using Amazon.SimpleDB.Model;
using Amazon.SimpleDB;
using Attribute = Amazon.SimpleDB.Model.Attribute;

/*

Here are the attributes tracked inside SDB.

  Username Text (255) NOT NULL, (Simple DB Item Name)
  Email Text (128) NOT NULL,
  Password Text (128) NOT NULL,
  PasswordQuestion Text (255),
  PasswordAnswer Text (255),
  IsApproved YesNo, 

*/

namespace MultiCore.Amazon.Providers
{
    public sealed class SDBMembershipProvider : MembershipProvider
    {

        private string eventSource = "SDBProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string accessKey = "";
        private string secretKey = "";
        private string domain = "";
        private AmazonSimpleDB client;


        //
        // Used when determining encryption key values.
        //

        private MachineKeySection machineKey;

        //
        // If false, exceptions are thrown to the caller. If true,
        // exceptions are written to the event log.
        //

        private bool pWriteExceptionsToEventLog;

        public bool WriteExceptionsToEventLog
        {
            get { return pWriteExceptionsToEventLog; }
            set { pWriteExceptionsToEventLog = value; }
        }

        private string pApplicationName;
        private bool pEnablePasswordReset;
        private bool pEnablePasswordRetrieval;
        private bool pRequiresQuestionAndAnswer;
        private bool pRequiresUniqueEmail;
        private int pMaxInvalidPasswordAttempts;
        private int pPasswordAttemptWindow;
        private MembershipPasswordFormat pPasswordFormat;

        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }

        public override bool EnablePasswordReset
        {
            get { return pEnablePasswordReset; }
        }


        public override bool EnablePasswordRetrieval
        {
            get { return pEnablePasswordRetrieval; }
        }


        public override bool RequiresQuestionAndAnswer
        {
            get { return pRequiresQuestionAndAnswer; }
        }


        public override bool RequiresUniqueEmail
        {
            get { return pRequiresUniqueEmail; }
        }


        public override int MaxInvalidPasswordAttempts
        {
            get { return pMaxInvalidPasswordAttempts; }
        }


        public override int PasswordAttemptWindow
        {
            get { return pPasswordAttemptWindow; }
        }

        private int pMinRequiredNonAlphanumericCharacters;

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return pMinRequiredNonAlphanumericCharacters; }
        }

        private int pMinRequiredPasswordLength;

        public override int MinRequiredPasswordLength
        {
            get { return pMinRequiredPasswordLength; }
        }

        private string pPasswordStrengthRegularExpression;

        public override string PasswordStrengthRegularExpression
        {
            get { return pPasswordStrengthRegularExpression; }
        }

        //
        // System.Configuration.Provider.ProviderBase.Initialize Method
        //

        public override void Initialize(string name, NameValueCollection config)
        {
            //
            // Initialize values from web.config.
            //

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "SDBMembershipProvider";

            // Initialize the abstract base class.
            base.Initialize(name, config);

            accessKey = GetConfigValue(config["accessKey"], "");
            secretKey = GetConfigValue(config["secretKey"], "");
            domain = GetConfigValue(config["domain"], "Users");
            pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            string temp_format = config["passwordFormat"];
            if (temp_format == null)
            {
                temp_format = "Hashed";
            }

            switch (temp_format)
            {
                case "Hashed":
                    pPasswordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    pPasswordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    pPasswordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");
            }

            //
            // Initialize the SimpleDB Client.
            //

            client = new AmazonSimpleDBClient(accessKey, secretKey);

            // Make sure the domain for users exists
            CreateDomainRequest cdRequest = new CreateDomainRequest();
            cdRequest.DomainName = domain;
            client.CreateDomain(cdRequest);

            // Get encryption and decryption key information from the configuration.
            Configuration cfg =
              WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");

            if (machineKey.ValidationKey.Contains("AutoGenerate"))
                if (PasswordFormat != MembershipPasswordFormat.Clear)
                    throw new ProviderException("Hashed or Encrypted passwords " +
                                                "are not supported with auto-generated keys.");
        }


        //
        // A helper function to retrieve config values from the configuration file.
        //

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return pPasswordFormat; }
        }


        public override bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            if (!ValidateUser(username, oldPwd))
                return false;

            try
            {
                ReplaceableAttribute replaceAttribute = new ReplaceableAttribute().WithName("Password").WithValue(newPwd).WithReplace(true);
                PutAttributesRequest request = new PutAttributesRequest().WithDomainName(domain).WithItemName(username).WithAttribute(replaceAttribute);
                client.PutAttributes(request);
                return true;
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ChangePassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }

            return false; 
        }



        //
        // MembershipProvider.ChangePasswordQuestionAndAnswer
        //

        public override bool ChangePasswordQuestionAndAnswer(string username,
                      string password,
                      string newPwdQuestion,
                      string newPwdAnswer)
        {
            if (!ValidateUser(username, password))
                return false;

            try
            {
                return true;
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ChangePasswordQuestionAndAnswer");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            return false;
        }



        //
        // MembershipProvider.CreateUser
        //

        public override MembershipUser CreateUser(string username,
                 string password,
                 string email,
                 string passwordQuestion,
                 string passwordAnswer,
                 bool isApproved,
                 object providerUserKey,
                 out MembershipCreateStatus status)
        {
            MembershipUser u = GetUser(username, false);

            if (u == null)
            {
                try
                {
                    // Create an item in SDB with the Itemname = username
                    List<ReplaceableAttribute> data = new List<ReplaceableAttribute>();
                    data.Add(new ReplaceableAttribute().WithName("Email").WithValue(email));
                    data.Add(new ReplaceableAttribute().WithName("Password").WithValue(password));
                    if (passwordQuestion != null)
                        data.Add(new ReplaceableAttribute().WithName("PasswordQuestion").WithValue(passwordQuestion));
                    if (passwordAnswer != null)
                        data.Add(new ReplaceableAttribute().WithName("PasswordAnswer").WithValue(passwordAnswer));
                    data.Add(new ReplaceableAttribute().WithName("IsApproved").WithValue(isApproved.ToString()));
                    PutAttributesRequest request = new PutAttributesRequest().WithDomainName(domain).WithItemName(username);
                    request.Attribute = data;
                    client.PutAttributes(request);
                    status = MembershipCreateStatus.Success;
                }
                catch (Exception e)
                {
                    if (WriteExceptionsToEventLog)
                    {
                        WriteToEventLog(e, "CreateUser");
                    }

                    status = MembershipCreateStatus.ProviderError;
                }

                return GetUser(username, false);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }



        //
        // MembershipProvider.DeleteUser
        //

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            try
            {
                DeleteAttributesRequest request = new DeleteAttributesRequest().WithDomainName(domain).WithItemName(username);
                client.DeleteAttributes(request);
                return true;
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "DeleteUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }

            return false;
        }



        //
        // MembershipProvider.GetAllUsers
        //

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            try
            {
                SelectRequest request = new SelectRequest().WithSelectExpression("Select * from " + domain);
                SelectResponse response = client.Select(request);
                totalRecords = response.SelectResult.Item.Count;
                string username = "";
                string email = "";
                string passwordQuestion = "";
                bool isApproved = false;
                foreach (Item item in response.SelectResult.Item)
                {
                    List<Attribute> attributes = item.Attribute;
                    foreach (Attribute att in attributes)
                    {
                        switch (att.Name)
                        {
                            case "Email": email = att.Value; break;
                            case "PasswordQuestion": passwordQuestion = att.Value; break;
                            case "IsApproved": isApproved = bool.Parse(att.Value); break;
                            default : break;
                        }
                    }
                    username = item.Name;

                    MembershipUser user = new MembershipUser(this.Name, username,
                        "", email, passwordQuestion, "", isApproved, false, 
                        DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
                    users.Add(user);  
                }
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetAllUsers ");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }

            return users;
        }


        //
        // MembershipProvider.GetNumberOfUsersOnline
        //
        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <returns></returns>
        public override int GetNumberOfUsersOnline()
        {

            int numOnline = 0;

            return numOnline;
        }



        //
        // MembershipProvider.GetPassword
        //

        public override string GetPassword(string username, string answer)
        {
            if (!EnablePasswordRetrieval)
            {
                throw new ProviderException("Password Retrieval Not Enabled.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Hashed)
            {
                throw new ProviderException("Cannot retrieve Hashed passwords.");
            }

            string password = "";
            string passwordAnswer = "";

            try
            {
                GetAttributesRequest request = new GetAttributesRequest().WithDomainName(domain).WithItemName(username).WithAttributeName(new string[] { "Password", "PasswordAnswer" });
                GetAttributesResponse response = client.GetAttributes(request);
                if (response.IsSetGetAttributesResult())
                {
                    GetAttributesResult result = response.GetAttributesResult;
                    foreach (Attribute att in result.Attribute)
                    {
                        switch (att.Name)
                        {
                            case "Password": password = att.Value; break;
                            case "PasswordAnswer": passwordAnswer = att.Value; break;
                            default: break;
                        }
                    }
                }
                else throw new MembershipPasswordException("User not found");
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetPassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }

            if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
            {
                throw new MembershipPasswordException("Incorrect password answer.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Encrypted)
            {
                password = UnEncodePassword(password);
            }

            return password;
        }



        //
        // MembershipProvider.GetUser(string, bool)
        //

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            try
            {
                GetAttributesRequest request = new GetAttributesRequest().WithDomainName(domain).WithItemName(username);
                GetAttributesResponse response = client.GetAttributes(request);
                GetAttributesResult result = response.GetAttributesResult;
                // if we have no attributes we have no user
                if (result.Attribute.Count == 0) return null;
                string email = "";
                string passwordQuestion = "";
                bool isApproved = false;
                List<Attribute> attributes = result.Attribute;
                foreach (Attribute att in attributes)
                {
                    switch (att.Name)
                    {
                        case "Email": email = att.Value; break;
                        case "PasswordQuestion": passwordQuestion = att.Value; break;
                        case "IsApproved": isApproved = bool.Parse(att.Value); break;
                        default: break;
                    }
                }

                MembershipUser user = new MembershipUser(this.Name, username,
                    "", email, passwordQuestion, "", isApproved, false,
                    DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
                return user;
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUser(String, Boolean)");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
        }


        //
        // MembershipProvider.GetUser(object, bool)
        //

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return GetUser(providerUserKey.ToString(), userIsOnline);
        }


        //
        // MembershipProvider.UnlockUser
        //
        /// <summary>
        /// Not implemented yet.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override bool UnlockUser(string username)
        {
            return true;
        }


        //
        // MembershipProvider.GetUserNameByEmail
        //
        /// <summary>
        /// Not implemented yet.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override string GetUserNameByEmail(string email)
        {
            return "";
        }


        public override string ResetPassword(string username, string answer)
        {
            if (!EnablePasswordReset)
            {
                throw new NotSupportedException("Password reset is not enabled.");
            }

            if (answer == null && RequiresQuestionAndAnswer)
            {
                throw new ProviderException("Password answer required for password reset.");
            }

            string newPassword =
              System.Web.Security.Membership.GeneratePassword(6, 0);

            string passwordAnswer = "";

            try
            {
                GetAttributesRequest request = new GetAttributesRequest().WithDomainName(domain).WithItemName(username).WithAttributeName(new string[] { "Password", "PasswordAnswer" });
                GetAttributesResponse response = client.GetAttributes(request);
                if (response.IsSetGetAttributesResult())
                {
                    GetAttributesResult result = response.GetAttributesResult;
                    foreach (Attribute att in result.Attribute)
                    {
                        switch (att.Name)
                        {
                            case "PasswordAnswer": passwordAnswer = att.Value; break;
                            default: break;
                        }
                    }
                }
                else throw new MembershipPasswordException("User not found");

                if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
                {
                    throw new MembershipPasswordException("Incorrect password answer.");
                }

                // Update the new password here
                ReplaceableAttribute replace = new ReplaceableAttribute().WithName("Password").WithValue(newPassword).WithReplace(true);
                PutAttributesRequest prequest = new PutAttributesRequest().WithDomainName(domain).WithItemName(username).WithAttribute(replace);
                client.PutAttributes(prequest);
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ResetPassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }

            return newPassword;
        }


        //
        // MembershipProvider.UpdateUser
        //

        public override void UpdateUser(MembershipUser user)
        {
            try
            {
                List<ReplaceableAttribute> attributes = new List<ReplaceableAttribute>();
                attributes.Add(new ReplaceableAttribute().WithName("Email").WithValue(user.Email).WithReplace(true));

                PutAttributesRequest request = new PutAttributesRequest().WithDomainName(domain).WithItemName(user.UserName);
                request.Attribute = attributes;
                client.PutAttributes(request);
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UpdateUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
        }


        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            string dbpassword = "";
            try
            {
                GetAttributesRequest request = new GetAttributesRequest().WithDomainName(domain).WithItemName(username).WithAttributeName(new string[] { "Password", "PasswordAnswer" });
                GetAttributesResponse response = client.GetAttributes(request);
                if (response.IsSetGetAttributesResult())
                {
                    GetAttributesResult result = response.GetAttributesResult;
                    foreach (Attribute att in result.Attribute)
                    {
                        switch (att.Name)
                        {
                            case "Password": dbpassword = att.Value; break;
                            default: break;
                        }
                    }
                }
                else throw new MembershipPasswordException("User not found");
                if (dbpassword == password) return true;
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ValidateUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }

            return isValid;
        }


        //
        // CheckPassword
        //   Compares password values based on the MembershipPasswordFormat.
        //

        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            if (pass1 == pass2)
            {
                return true;
            }

            return false;
        }


        //
        // EncodePassword
        //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        //

        private string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(machineKey.ValidationKey);
                    encodedPassword =
                      Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return encodedPassword;
        }


        //
        // UnEncodePassword
        //   Decrypts or leaves the password clear based on the PasswordFormat.
        //

        private string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password =
                      Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        //
        // HexToByte
        //   Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        //

        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        //
        // MembershipProvider.FindUsersByName
        //
        /// <summary>
        /// Not yet implemented.
        /// </summary>
        /// <param name="usernameToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();
            try
            {
                totalRecords = 0;
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "FindUsersByName");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            return users;
        }

        //
        // MembershipProvider.FindUsersByEmail
        //
        /// <summary>
        /// Not yet implemented.
        /// </summary>
        /// <param name="emailToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            try
            {
                totalRecords = 0;
            }
            catch (Exception e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "FindUsersByEmail");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }

            return users;
        }


        private void WriteToEventLog(Exception e, string action)
        {
            EventLog log = new EventLog();
            log.Source = eventSource;
            log.Log = eventLog;

            string message = "An exception occurred communicating with simple db.\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            log.WriteEntry(message);
        }

    }
}
