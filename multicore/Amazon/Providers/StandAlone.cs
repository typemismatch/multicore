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
using System.Collections;
using System.Linq;
using System.Text;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Attribute = Amazon.SimpleDB.Model.Attribute;

namespace MultiCore.Amazon.Providers
{
    /// <summary>
    /// Self contained SDB Provider
    /// </summary>
    public class StandAlone
    {
        string accessKey = "";
        string secretKey = "";
        string domainPrefix = "";
        string[] domains;
        AmazonSimpleDB client;

        public StandAlone(string AccessKey, string SecretKey, string[] Domains)
        {
            accessKey = AccessKey;
            secretKey = SecretKey;
            domains = Domains;
            Init();
        }
        
        public StandAlone(string AccessKey, string SecretKey)
        {
            accessKey = AccessKey;
            secretKey = SecretKey;
            domains = new string[] { };
            Init();
        }

        public StandAlone(string AccessKey, string SecretKey, string DomainPrefix)
        {
            domainPrefix = DomainPrefix;
            accessKey = AccessKey;
            secretKey = SecretKey;
            domains = new string[] { };
            Init();
        }

        void Init()
        {
            client = new AmazonSimpleDBClient(accessKey, secretKey);
            foreach (string domain in domains)
            {
                string _domain = SetDomain(domain);
                CreateDomainRequest request = new CreateDomainRequest().WithDomainName(_domain);
                client.CreateDomain(request);
            }
        }

        public MCItem GetItem(string ItemName, string Domain)
        {
            Domain = SetDomain(Domain);
            GetAttributesRequest request = new GetAttributesRequest().WithDomainName(Domain).WithItemName(ItemName);
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

        public void SaveItem(MCItem item)
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
        public List<MCItem> GetItems(string Domain)
        {
            Domain = SetDomain(Domain);
            SelectRequest request = new SelectRequest().WithSelectExpression("Select * from " + Domain);
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

        public void SaveItem(MCItem item, string Domain)
        {
            item.Domain = Domain;
            SaveItem(item);
        }

        public List<MCItem> Select(string Query, string Domain)
        {
            Domain = SetDomain(Domain);
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

        public void DeleteItem(string ItemName, string Domain)
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

        public void CreateDomain(string Domain)
        {
            Domain = SetDomain(Domain);
            CreateDomainRequest request = new CreateDomainRequest().WithDomainName(Domain);
            client.CreateDomain(request);
        }
    }
}
