/******************************************************************************* 
 *  Copyright 2008 Amazon Technologies, Inc.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 *    __  _    _  ___ 
 *   (  )( \/\/ )/ __)
 *   /__\ \    / \__ \
 *  (_)(_) \/\/  (___/
 * 
 *  Amazon SQS CSharp Library
 *  API Version: 2009-02-01
 *  Generated: Wed Apr 08 19:02:38 PDT 2009 
 * 
 */

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;


namespace Amazon.SQS.Model
{
    [XmlTypeAttribute(Namespace = "http://queue.amazonaws.com/doc/2009-02-01/")]
    [XmlRootAttribute(Namespace = "http://queue.amazonaws.com/doc/2009-02-01/", IsNullable = false)]
    public class ListQueuesResult
    {
    
        private List<String> queueUrlField;


        /// <summary>
        /// Gets and sets the QueueUrl property.
        /// </summary>
        [XmlElementAttribute(ElementName = "QueueUrl")]
        public List<String> QueueUrl
        {
            get
            {
                if (this.queueUrlField == null)
                {
                    this.queueUrlField = new List<String>();
                }
                return this.queueUrlField;
            }
            set { this.queueUrlField =  value; }
        }



        /// <summary>
        /// Sets the QueueUrl property
        /// </summary>
        /// <param name="list">QueueUrl property</param>
        /// <returns>this instance</returns>
        public ListQueuesResult WithQueueUrl(params String[] list)
        {
            foreach (String item in list)
            {
                QueueUrl.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of QueueUrl property is set
        /// </summary>
        /// <returns>true if QueueUrl property is set</returns>
        public Boolean IsSetQueueUrl()
        {
            return (QueueUrl.Count > 0);
        }






        /// <summary>
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            List<String> queueUrlList  =  this.QueueUrl;
            foreach (String queueUrl in queueUrlList) { 
                xml.Append("<QueueUrl>");
                xml.Append(EscapeXML(queueUrl));
                xml.Append("</QueueUrl>");
            }	
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str) {
            StringBuilder sb = new StringBuilder();
            foreach (Char c in str)
            {
                switch (c) {
                case '&':
                    sb.Append("&amp;");
                    break;
                case '<':
                    sb.Append("&lt;");
                    break;
                case '>':
                    sb.Append("&gt;");
                    break;
                case '\'':
                    sb.Append("&#039;");
                    break;
                case '"':
                    sb.Append("&quot;");
                    break;
                default:
                    sb.Append(c);
                    break;
                }
            }
            return sb.ToString();
        }



    }

}