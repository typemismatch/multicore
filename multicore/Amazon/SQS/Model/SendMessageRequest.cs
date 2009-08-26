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
    public class SendMessageRequest
    {
    
        private String queueUrlField;

        private String messageBodyField;

        private  List<Attribute> attributeField;


        /// <summary>
        /// Gets and sets the QueueUrl property.
        /// </summary>
        [XmlElementAttribute(ElementName = "QueueUrl")]
        public String QueueUrl
        {
            get { return this.queueUrlField ; }
            set { this.queueUrlField= value; }
        }



        /// <summary>
        /// Sets the QueueUrl property
        /// </summary>
        /// <param name="queueUrl">QueueUrl property</param>
        /// <returns>this instance</returns>
        public SendMessageRequest WithQueueUrl(String queueUrl)
        {
            this.queueUrlField = queueUrl;
            return this;
        }



        /// <summary>
        /// Checks if QueueUrl property is set
        /// </summary>
        /// <returns>true if QueueUrl property is set</returns>
        public Boolean IsSetQueueUrl()
        {
            return  this.queueUrlField != null;

        }


        /// <summary>
        /// Gets and sets the MessageBody property.
        /// </summary>
        [XmlElementAttribute(ElementName = "MessageBody")]
        public String MessageBody
        {
            get { return this.messageBodyField ; }
            set { this.messageBodyField= value; }
        }



        /// <summary>
        /// Sets the MessageBody property
        /// </summary>
        /// <param name="messageBody">MessageBody property</param>
        /// <returns>this instance</returns>
        public SendMessageRequest WithMessageBody(String messageBody)
        {
            this.messageBodyField = messageBody;
            return this;
        }



        /// <summary>
        /// Checks if MessageBody property is set
        /// </summary>
        /// <returns>true if MessageBody property is set</returns>
        public Boolean IsSetMessageBody()
        {
            return  this.messageBodyField != null;

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
        public SendMessageRequest WithAttribute(params Attribute[] list)
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





    }

}