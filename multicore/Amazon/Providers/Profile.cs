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
using System.Web.Profile;
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

namespace MultiCore.Amazon.Providers
{
    /// <summary>
    /// SimpleDB Profile Provider
    /// The Username is the DomainItem (PK)
    /// Each profile property is a domain attribute. Should extend easily.
    /// There is a hidden user called MCSDBPROFILE, this user has the "latest" attributes so
    /// we can return a valid number of profile properties. If you extend your profile settings existing
    /// users do not have those columns unless saved again. Not a problem but nice to keep this data.
    /// Required attributes - ItemName, Anon, LastActivity, LastUpdated
    /// </summary>
    public sealed class SDBProfileProvider : ProfileProvider
    {
        private string eventSource = "SDBProfileProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string accessKey = "";
        private string secretKey = "";
        private string domain = "";
        private string hiddenUser = "MCSDBPROFILE";
        private AmazonSimpleDB client;

        // Some internal variables
        private string appName = "";

        public override string ApplicationName
        {
            get
            {
                return appName;
            }
            set
            {
                appName = value;
            }
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "SDBProfileProvider";

            // Initialize the abstract base class.
            base.Initialize(name, config);

            accessKey = GetConfigValue(config["accessKey"], "");
            secretKey = GetConfigValue(config["secretKey"], "");
            domain = GetConfigValue(config["domain"], "Profiles");

            client = new AmazonSimpleDBClient(accessKey, secretKey);

            // Make sure the domain for user profiles exists
            CreateDomainRequest cdRequest = new CreateDomainRequest();
            cdRequest.DomainName = domain;
            client.CreateDomain(cdRequest);
        }

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
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

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            List<string> usernames = new List<string>();
            foreach (ProfileInfo profile in profiles)
            {
                usernames.Add(profile.UserName);
            }
            return DeleteProfiles(usernames.ToArray());
        }

        public override int DeleteProfiles(string[] usernames)
        {
            // I think we can make sure of a new sdb feature, grouped requests. 
            // It will be in the next update.
            int deleted = 0;

            foreach (string username in usernames)
            {
                try
                {
                    DeleteAttributesRequest deleteRequest = new DeleteAttributesRequest().WithDomainName(domain).WithItemName(username);
                    client.DeleteAttributes(deleteRequest);
                    deleted++;
                }
                catch (Exception err)
                {
                    WriteToEventLog(err, "DeleteProfiles");
                }
            }

            return deleted;
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a user's profile
        /// Currently assumes a single user will match the token.
        /// </summary>
        /// <param name="authenticationOption"></param>
        /// <param name="usernameToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            // TODO: Take paging into account
            // TODO: Take auth option into account
            totalRecords = 0;

            ProfileInfoCollection profiles = new ProfileInfoCollection();

            GetAttributesRequest request = new GetAttributesRequest().WithDomainName(domain).WithItemName(usernameToMatch);
            GetAttributesResponse response = client.GetAttributes(request);

            if (response.GetAttributesResult.Attribute.Count > 0)
            {
                ProfileInfo profile = null;
                List<Attribute> attributes = response.GetAttributesResult.Attribute;
                MCItem item = new MCItem();
                item.Domain = domain;
                item.ItemName = usernameToMatch;
                item.Attributes = new Hashtable();
                foreach (Attribute attribute in attributes)
                {
                    item.Attributes.Add(attribute.Name, attribute.Value);
                }
                bool Anon = bool.Parse(item.Get("Anon").Replace("", "false"));
                DateTime LastActivity = DateTime.Parse(item.Get("LastActivity"));
                DateTime LastUpdated = DateTime.Parse(item.Get("LastUpdated"));
                profile = new ProfileInfo(item.Id, Anon, LastActivity, LastUpdated, 0);
                profiles.Add(profile);
            }

            totalRecords = profiles.Count;
            return profiles;
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            // TODO: Take paging into account
            // TODO: Take auth option into account
            totalRecords = 0;

            ProfileInfoCollection profiles = new ProfileInfoCollection();

            SelectRequest request = new SelectRequest().WithSelectExpression("select * from " + domain);
            SelectResponse response = client.Select(request);

            if (response.SelectResult.Item.Count > 0)
            {
                foreach (Item _item in response.SelectResult.Item)
                {
                    ProfileInfo profile = null;
                    List<Attribute> attributes = _item.Attribute;
                    MCItem item = new MCItem();
                    item.Domain = domain;
                    item.ItemName = _item.Name;
                    item.Attributes = new Hashtable();
                    foreach (Attribute attribute in attributes)
                    {
                        item.Attributes.Add(attribute.Name, attribute.Value);
                    }
                    bool Anon = bool.Parse(item.Get("Anon").Replace("", "false"));
                    DateTime LastActivity = DateTime.Parse(item.Get("LastActivity"));
                    DateTime LastUpdated = DateTime.Parse(item.Get("LastUpdated"));
                    profile = new ProfileInfo(item.Id, Anon, LastActivity, LastUpdated, 0);
                    profiles.Add(profile);
                }
            }

            totalRecords = profiles.Count;
            return profiles;
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext sc, SettingsPropertyCollection collection)
        {
            string username = (string)sc["UserName"];
            SettingsPropertyValueCollection properties = new SettingsPropertyValueCollection();

            GetAttributesRequest request = new GetAttributesRequest().WithDomainName(domain).WithItemName(username);
            GetAttributesResponse response = client.GetAttributes(request);

            // Setup defaults ...

            foreach (SettingsProperty prop in collection)
            {
                SettingsPropertyValue value = new SettingsPropertyValue(prop);
                value.PropertyValue = prop.DefaultValue;
                properties.Add(value);
            }

            if (response.GetAttributesResult.Attribute.Count > 0)
            {
                List<Attribute> attributes = response.GetAttributesResult.Attribute;
                MCItem item = new MCItem();
                item.Domain = domain;
                item.ItemName = username;
                item.Attributes = new Hashtable();
                foreach (Attribute attribute in attributes)
                {
                    item.Attributes.Add(attribute.Name, attribute.Value);
                }
                foreach (SettingsProperty prop in collection)
                {
                    SettingsPropertyValue value = properties[prop.Name];
                    value.PropertyValue = item.Attributes[prop.Name];
                    //value.Deserialized = true;
                }
            }

            return properties;
        }

        public override void SetPropertyValues(SettingsContext sc, SettingsPropertyValueCollection properties)
        {
            string username = (string)sc["UserName"];
            bool userIsAuthenticated = (bool)sc["IsAuthenticated"];

            MCItem item = new MCItem(username, domain);
            item.Attributes.Add("Anon", "");
            item.Attributes.Add("LastUpdated", DateTime.Now.ToShortDateString());

            foreach (SettingsPropertyValue property in properties)
            {
                if (property.PropertyValue != null)
                {
                    item.Attributes.Add(property.Name, property.PropertyValue.ToString());
                }
            }

            PutAttributesRequest request = new PutAttributesRequest().WithDomainName(item.Domain).WithItemName(item.ItemName);
            List<ReplaceableAttribute> attributes = new List<ReplaceableAttribute>();
            foreach (string key in item.Attributes.Keys)
            {
                attributes.Add(new ReplaceableAttribute().WithName(key).WithValue(item.Attributes[key].ToString()).WithReplace(true));
            }
            request.Attribute = attributes;
            client.PutAttributes(request);
        }
    }
}
