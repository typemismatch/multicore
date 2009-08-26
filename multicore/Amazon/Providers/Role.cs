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
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using System.Collections.Generic;
using Attribute = Amazon.SimpleDB.Model.Attribute;

/*

This provider works with the following schema for the tables of role data.
This is very denormalized due to SDB design - keep it that way for speed!
This provider doesn't care if a role exists or not - just adds as needed.
 
SDB Domain Name - Roles
 * Username-Rolename
 * Username
 * Rolename

*/

namespace MultiCore.Amazon.Providers
{

    public sealed class SDBRoleProvider : RoleProvider
    {

        //
        // Global connection string, generic exception message, event log info.
        //

        private string eventSource = "SDBRoleProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";

        private string accessKey = "";
        private string secretKey = "";
        private string domain = "";
        private AmazonSimpleDB client;


        //
        // If false, exceptions are thrown to the caller. If true,
        // exceptions are written to the event log.
        //

        private bool pWriteExceptionsToEventLog = false;

        public bool WriteExceptionsToEventLog
        {
            get { return pWriteExceptionsToEventLog; }
            set { pWriteExceptionsToEventLog = value; }
        }

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }        

        public override void Initialize(string name, NameValueCollection config)
        {

            //
            // Initialize values from web.config.
            //

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "SDBRoleProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Amazon Simple DB Role provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            accessKey = GetConfigValue(config["accessKey"], "");
            secretKey = GetConfigValue(config["secretKey"], "");
            domain = GetConfigValue(config["domain"], "Roles");

            if (config["writeExceptionsToEventLog"] != null)
            {
                if (config["writeExceptionsToEventLog"].ToUpper() == "TRUE")
                {
                    pWriteExceptionsToEventLog = true;
                }
            }

            //
            // Initialize the SimpleDB Client.
            //

            client = new AmazonSimpleDBClient(accessKey, secretKey);

            // Make sure the domain for users exists
            CreateDomainRequest cdRequest = new CreateDomainRequest();
            cdRequest.DomainName = domain;
            client.CreateDomain(cdRequest);
        }



        //
        // System.Web.Security.RoleProvider properties.
        //


        private string pApplicationName;


        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }

        //
        // System.Web.Security.RoleProvider methods.
        //

        //
        // RoleProvider.AddUsersToRoles
        //

        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            foreach (string username in usernames)
            {
                if (username.Contains(","))
                {
                    throw new ArgumentException("User names cannot contain commas.");
                }

                foreach (string rolename in rolenames)
                {
                    string id = username + "-" + rolename;
                    PutAttributesRequest request = new PutAttributesRequest().WithDomainName(domain).WithItemName(id);
                    List<ReplaceableAttribute> attributes = new List<ReplaceableAttribute>();
                    attributes.Add(new ReplaceableAttribute().WithName("Username").WithValue(username).WithReplace(true));
                    attributes.Add(new ReplaceableAttribute().WithName("Rolename").WithValue(rolename).WithReplace(true));
                    request.Attribute = attributes;
                    client.PutAttributes(request);
                }
            }
        }

        //
        // RoleProvider.CreateRole
        //

        public override void CreateRole(string rolename)
        {
        }


        //
        // RoleProvider.DeleteRole
        //

        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            return true;
        }


        //
        // RoleProvider.GetAllRoles
        //

        public override string[] GetAllRoles()
        {
            return new string[] { "admin", "user" };
        }


        //
        // RoleProvider.GetRolesForUser
        //

        public override string[] GetRolesForUser(string username)
        {
            SelectRequest request = new SelectRequest().WithSelectExpression("Select * from " + domain + " where Username='" + username + "'");
            //QueryRequest request = new QueryRequest().WithDomainName(domain).WithQueryExpression("['Username' = '" + username + "']");
            SelectResponse response = client.Select(request);
            List<string> roles = new List<string> ();
            foreach (Item key in response.SelectResult.Item)
            {
                roles.Add(key.Name.Replace(username + "-",""));
            }
            return roles.ToArray();
        }


        //
        // RoleProvider.GetUsersInRole
        //

        public override string[] GetUsersInRole(string rolename)
        {
            return new string[0];
        }


        //
        // RoleProvider.IsUserInRole
        //

        public override bool IsUserInRole(string username, string rolename)
        {
            GetAttributesRequest request = new GetAttributesRequest().WithDomainName(domain).WithItemName(username + "-" + rolename);
            GetAttributesResponse response = client.GetAttributes(request);
            if (response.GetAttributesResult.Attribute.Count > 0) return true;
            else return false;
        }


        //
        // RoleProvider.RemoveUsersFromRoles
        //

        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            foreach (string username in usernames)
            {
                foreach (string rolename in rolenames)
                {
                    DeleteAttributesRequest request = new DeleteAttributesRequest().WithDomainName(domain).WithItemName(username + "-" + rolename);
                    client.DeleteAttributes(request);
                }
            }
        }


        //
        // RoleProvider.RoleExists
        //

        public override bool RoleExists(string rolename)
        {
            return true;
        }

        //
        // RoleProvider.FindUsersInRole
        //

        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            return new string[0];
        }

        private void WriteToEventLog(OdbcException e, string action)
        {
            EventLog log = new EventLog();
            log.Source = eventSource;
            log.Log = eventLog;

            string message = exceptionMessage + "\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            log.WriteEntry(message);
        }

    }
}

