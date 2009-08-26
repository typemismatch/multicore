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
    public class Message
    {
    
        private String messageIdField;

        private String receiptHandleField;

        private String MD5OfBodyField;

        private String bodyField;

        private  List<Attribute> attributeField;


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
        public Message WithMessageId(String messageId)
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
        /// Gets and sets the ReceiptHandle property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ReceiptHandle")]
        public String ReceiptHandle
        {
            get { return this.receiptHandleField ; }
            set { this.receiptHandleField= value; }
        }



        /// <summary>
        /// Sets the ReceiptHandle property
        /// </summary>
        /// <param name="receiptHandle">ReceiptHandle property</param>
        /// <returns>this instance</returns>
        public Message WithReceiptHandle(String receiptHandle)
        {
            this.receiptHandleField = receiptHandle;
            return this;
        }



        /// <summary>
        /// Checks if ReceiptHandle property is set
        /// </summary>
        /// <returns>true if ReceiptHandle property is set</returns>
        public Boolean IsSetReceiptHandle()
        {
            return  this.receiptHandleField != null;

        }


        /// <summary>
        /// Gets and sets the MD5OfBody property.
        /// </summary>
        [XmlElementAttribute(ElementName = "MD5OfBody")]
        public String MD5OfBody
        {
            get { return this.MD5OfBodyField ; }
            set { this.MD5OfBodyField= value; }
        }



        /// <summary>
        /// Sets the MD5OfBody property
        /// </summary>
        /// <param name="MD5OfBody">MD5OfBody property</param>
        /// <returns>this instance</returns>
        public Message WithMD5OfBody(String MD5OfBody)
        {
            this.MD5OfBodyField = MD5OfBody;
            return this;
        }



        /// <summary>
        /// Checks if MD5OfBody property is set
        /// </summary>
        /// <returns>true if MD5OfBody property is set</returns>
        public Boolean IsSetMD5OfBody()
        {
            return  this.MD5OfBodyField != null;

        }


        /// <summary>
        /// Gets and sets the Body property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Body")]
        public String Body
        {
            get { return this.bodyField ; }
            set { this.bodyField= value; }
        }



        /// <summary>
        /// Sets the Body property
        /// </summary>
        /// <param name="body">Body property</param>
        /// <returns>this instance</returns>
        public Message WithBody(String body)
        {
            this.bodyField = body;
            return this;
        }



        /// <summary>
        /// Checks if Body property is set
        /// </summary>
        /// <returns>true if Body property is set</returns>
        public Boolean IsSetBody()
        {
            return  this.bodyField != null;

        }


        /// <summary>
        /// Gets and sets the Attribute property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Attribute")]
        public List<Attribute> Attribute
        {
            get
            {
                if (this.attributeField == null)
                {
                    this.attributeField = new List<Attribute>();
                }
                return this.attributeField;
            }
            set { this.attributeField =  value; }
        }



        /// <summary>
        /// Sets the Attribute property
        /// </summary>
        /// <param name="list">Attribute property</param>
        /// <returns>this instance</returns>
        public Message WithAttribute(params Attribute[] list)
        {
            foreach (Attribute item in list)
            {
                Attribute.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if Attribute property is set
        /// </summary>
        /// <returns>true if Attribute property is set</returns>
        public Boolean IsSetAttribute()
        {
            return (Attribute.Count > 0);
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
            if (IsSetReceiptHandle()) {
                xml.Append("<ReceiptHandle>");
                xml.Append(EscapeXML(this.ReceiptHandle));
                xml.Append("</ReceiptHandle>");
            }
            if (IsSetMD5OfBody()) {
                xml.Append("<MD5OfBody>");
                xml.Append(EscapeXML(this.MD5OfBody));
                xml.Append("</MD5OfBody>");
            }
            if (IsSetBody()) {
                xml.Append("<Body>");
                xml.Append(EscapeXML(this.Body));
                xml.Append("</Body>");
            }
            List<Attribute> attributeList = this.Attribute;
            foreach (Attribute attribute in attributeList) {
                xml.Append("<Attribute>");
                xml.Append(attribute.ToXMLFragment());
                xml.Append("</Attribute>");
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