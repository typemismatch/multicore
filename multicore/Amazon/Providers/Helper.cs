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

namespace MultiCore.Amazon.Providers
{
    public class Helper
    {
        /// <summary>
        /// Initial helper method to protect against SDB Injection Attacks
        /// Currently just deals with ' issues.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static string SQLSafe(string SQL)
        {
            return SQL.Replace("'", "''");
        }
    }
}
