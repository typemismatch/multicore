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
    public class ChangeMessageVisibilityRequest
    {
    
        private String queueUrlField;

        private String receiptHandleField;

        private Decimal? visibilityTimeoutField;

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
        public ChangeMessageVisibilityRequest WithQueueUrl(String queueUrl)
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
        public ChangeMessageVisibilityRequest WithReceiptHandle(String receiptHandle)
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
        /// Gets and sets the VisibilityTimeout property.
        /// </summary>
        [XmlElementAttribute(ElementName = "VisibilityTimeout")]
        public Decimal VisibilityTimeout
        {
            get { return this.visibilityTimeoutField.GetValueOrDefault() ; }
            set { this.visibilityTimeoutField= value; }
        }



        /// <summary>
        /// Sets the VisibilityTimeout property
        /// </summary>
        /// <param name="visibilityTimeout">VisibilityTimeout property</param>
        /// <returns>this instance</returns>
        public ChangeMessageVisibilityRequest WithVisibilityTimeout(Decimal visibilityTimeout)
        {
            this.visibilityTimeoutField = visibilityTimeout;
            return this;
        }



        /// <summary>
        /// Checks if VisibilityTimeout property is set
        /// </summary>
        /// <returns>true if VisibilityTimeout property is set</returns>
        public Boolean IsSetVisibilityTimeout()
        {
            return  this.visibilityTimeoutField.HasValue;

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
        public ChangeMessageVisibilityRequest WithAttribute(params Attribute[] list)
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