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
