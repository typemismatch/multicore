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
    public sealed class SDBProfileProvider : ProfileProvider
    {

    }
}
