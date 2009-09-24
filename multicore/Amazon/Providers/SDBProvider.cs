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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Attribute = Amazon.SimpleDB.Model.Attribute;

namespace MultiCore.Amazon.Providers
{
    public class SDBProvider : MCProvider
    {
        string accessKey = "";
        string secretKey = "";
        string domainPrefix = "";
        AmazonSimpleDB client;

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            accessKey = config["accessKey"];
            secretKey = config["secretKey"];
            if (string.IsNullOrEmpty(accessKey)) throw new ConfigurationErrorsException("AWS Access Key is required.");
            if (string.IsNullOrEmpty(secretKey)) throw new ConfigurationErrorsException("AWS Secret Key is required.");

            // Set any domain prefix
            if (!string.IsNullOrEmpty(config["domainPrefix"])) domainPrefix = config["domainPrefix"];

            client = new AmazonSimpleDBClient(accessKey, secretKey);

            if (config["domains"] != null)
            {
                // Make sure domains exist
                string[] domains = config["domains"].ToString().Split(new char[] { ',' });
                foreach (string domain in domains)
                {
                    string _domain = SetDomain(domain);
                    CreateDomainRequest request = new CreateDomainRequest().WithDomainName(_domain);
                    client.CreateDomain(request);
                }
            }
        }

        /// <summary>
        /// Returns a SIMPLEDB object with ALL attributes.
        /// </summary>
        /// <param name="ItemName">Same as the item ID.</param>
        /// <param name="Domain"></param>
        /// <returns></returns>
        public override MCItem GetItem(string ItemName, string Domain)
        {
            string sdbDomain = SetDomain(Domain);
            GetAttributesRequest request = new GetAttributesRequest().WithDomainName(sdbDomain).WithItemName(ItemName);
            GetAttributesResponse response = client.GetAttributes(request);
            MCItem item = new MCItem();
            item.Domain = Domain;
            item.ItemName = ItemName;
            item.Attributes = new Hashtable();
            foreach (Attribute attribute in response.GetAttributesResult.Attribute)
            {
                item.Attributes.Add(attribute.Name, attribute.Value);
            }
            return item;
        }

        public override void SaveItem(MCItem item)
        {
            item.Domain = SetDomain(item.Domain);
            PutAttributesRequest request = new PutAttributesRequest().WithDomainName(item.Domain).WithItemName(item.ItemName);
            List<ReplaceableAttribute> attributes = new List<ReplaceableAttribute>();
            foreach (string key in item.Attributes.Keys)
            {
                attributes.Add(new ReplaceableAttribute().WithName(key).WithValue(item.Attributes[key].ToString()).WithReplace(true));
            }
            request.Attribute = attributes;
            client.PutAttributes(request);
        }

        /// <summary>
        /// This was kept in place but refactored to support Select.
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        public override List<MCItem> GetItems(string Domain)
        {
            string sdbDomain = SetDomain(Domain);
            SelectRequest request = new SelectRequest().WithSelectExpression("Select * from " + sdbDomain);
            SelectResponse response = client.Select(request);
            List<MCItem> items = new List<MCItem>();
            foreach (Item sdb in response.SelectResult.Item)
            {
                MCItem newItem = new MCItem(sdb.Name, Domain);
                foreach (Attribute attribute in sdb.Attribute) newItem.Attributes.Add(attribute.Name, attribute.Value);
                items.Add(newItem);
            }
            return items;
        }

        public override void SaveItem(MCItem item, string Domain)
        {
            item.Domain = Domain;
            SaveItem(item);
        }

        public override List<MCItem> Select(string Query, string Domain)
        {
            string sdbDomain = SetDomain(Domain);
            SelectRequest request = new SelectRequest().WithSelectExpression(Query);
            SelectResponse response = client.Select(request);
            List<MCItem> items = new List<MCItem>();
            foreach (Item sdb in response.SelectResult.Item)
            {
                MCItem newItem = new MCItem(sdb.Name, Domain);
                foreach (Attribute attribute in sdb.Attribute) newItem.Attributes.Add(attribute.Name, attribute.Value);
                items.Add(newItem);
            }
            return items;
        }

        public override void DeleteItem(string ItemName,string Domain)
        {
            Domain = SetDomain(Domain);
            DeleteAttributesRequest request = new DeleteAttributesRequest().WithDomainName(Domain).WithItemName(ItemName);
            client.DeleteAttributes(request);
        }

        private string SetDomain(string Domain)
        {
            if (!string.IsNullOrEmpty(domainPrefix)) return domainPrefix + Domain;
            else return Domain;
        }

        public override void CreateDomain(string Domain)
        {
            Domain = SetDomain(Domain);
            CreateDomainRequest request = new CreateDomainRequest().WithDomainName(Domain);
            client.CreateDomain(request);
        }
    }
}
