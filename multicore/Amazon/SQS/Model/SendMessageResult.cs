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
    public class SendMessageResult
    {
    
        private String messageIdField;

        private String MD5OfMessageBodyField;


        /// <summary>
        /// Gets and sets the MessageId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "MessageId")]
        public String MessageId
        {
            get { return this.messageIdField ; }
            set { this.messageIdField= value; }
        }



        /// <summary>
        /// Sets the MessageId property
        /// </summary>
        /// <param name="messageId">MessageId property</param>
        /// <returns>this instance</returns>
        public SendMessageResult WithMessageId(String messageId)
        {
            this.messageIdField = messageId;
            return this;
        }



        /// <summary>
        /// Checks if MessageId property is set
        /// </summary>
        /// <returns>true if MessageId property is set</returns>
        public Boolean IsSetMessageId()
        {
            return  this.messageIdField != null;

        }


        /// <summary>
        /// Gets and sets the MD5OfMessageBody property.
        /// </summary>
        [XmlElementAttribute(ElementName = "MD5OfMessageBody")]
        public String MD5OfMessageBody
        {
            get { return this.MD5OfMessageBodyField ; }
            set { this.MD5OfMessageBodyField= value; }
        }



        /// <summary>
        /// Sets the MD5OfMessageBody property
        /// </summary>
        /// <param name="MD5OfMessageBody">MD5OfMessageBody property</param>
        /// <returns>this instance</returns>
        public SendMessageResult WithMD5OfMessageBody(String MD5OfMessageBody)
        {
            this.MD5OfMessageBodyField = MD5OfMessageBody;
            return this;
        }



        /// <summary>
        /// Checks if MD5OfMessageBody property is set
        /// </summary>
        /// <returns>true if MD5OfMessageBody property is set</returns>
        public Boolean IsSetMD5OfMessageBody()
        {
            return  this.MD5OfMessageBodyField != null;

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
            if (IsSetMessageId()) {
                xml.Append("<MessageId>");
                xml.Append(EscapeXML(this.MessageId));
                xml.Append("</MessageId>");
            }
            if (IsSetMD5OfMessageBody()) {
                xml.Append("<MD5OfMessageBody>");
                xml.Append(EscapeXML(this.MD5OfMessageBody));
                xml.Append("</MD5OfMessageBody>");
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