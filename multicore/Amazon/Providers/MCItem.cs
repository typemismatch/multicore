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

namespace MultiCore.Amazon.Providers
{
    public class MCItem
    {
        string itemName = "";

        public MCItem() { }

        public MCItem(string ItemName, string Domain)
        {
            this.itemName = ItemName;
            this.Domain = Domain;
        }

        public string ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }

        public string Id
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }
        
        public string Domain = "";
        public Hashtable Attributes = new Hashtable();
        bool hasData = false;
        public bool HasData
        {
            get
            {
                if (Attributes.Count > 0) return true;
                else return false;
            }
        }

        public string Get(string AttributeName)
        {
            if (Attributes[AttributeName] != null)
                return Attributes[AttributeName].ToString();
            else
                return "";
        }
    }
}
