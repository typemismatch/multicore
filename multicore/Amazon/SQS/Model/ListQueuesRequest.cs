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
    public class ListQueuesRequest
    {
    
        private String queueNamePrefixField;

        private  List<Attribute> attributeField;


        /// <summary>
        /// Gets and sets the QueueNamePrefix property.
        /// </summary>
        [XmlElementAttribute(ElementName = "QueueNamePrefix")]
        public String QueueNamePrefix
        {
            get { return this.queueNamePrefixField ; }
            set { this.queueNamePrefixField= value; }
        }



        /// <summary>
        /// Sets the QueueNamePrefix property
        /// </summary>
        /// <param name="queueNamePrefix">QueueNamePrefix property</param>
        /// <returns>this instance</returns>
        public ListQueuesRequest WithQueueNamePrefix(String queueNamePrefix)
        {
            this.queueNamePrefixField = queueNamePrefix;
            return this;
        }



        /// <summary>
        /// Checks if QueueNamePrefix property is set
        /// </summary>
        /// <returns>true if QueueNamePrefix property is set</returns>
        public Boolean IsSetQueueNamePrefix()
        {
            return  this.queueNamePrefixField != null;

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
        public ListQueuesRequest WithAttribute(params Attribute[] list)
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