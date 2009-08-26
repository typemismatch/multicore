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
    public class AddPermissionRequest
    {
    
        private String queueUrlField;

        private String labelField;

        private List<String> AWSAccountIdField;

        private List<String> actionNameField;


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
        public AddPermissionRequest WithQueueUrl(String queueUrl)
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
        /// Gets and sets the Label property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Label")]
        public String Label
        {
            get { return this.labelField ; }
            set { this.labelField= value; }
        }



        /// <summary>
        /// Sets the Label property
        /// </summary>
        /// <param name="label">Label property</param>
        /// <returns>this instance</returns>
        public AddPermissionRequest WithLabel(String label)
        {
            this.labelField = label;
            return this;
        }



        /// <summary>
        /// Checks if Label property is set
        /// </summary>
        /// <returns>true if Label property is set</returns>
        public Boolean IsSetLabel()
        {
            return  this.labelField != null;

        }


        /// <summary>
        /// Gets and sets the AWSAccountId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AWSAccountId")]
        public List<String> AWSAccountId
        {
            get
            {
                if (this.AWSAccountIdField == null)
                {
                    this.AWSAccountIdField = new List<String>();
                }
                return this.AWSAccountIdField;
            }
            set { this.AWSAccountIdField =  value; }
        }



        /// <summary>
        /// Sets the AWSAccountId property
        /// </summary>
        /// <param name="list">AWSAccountId property</param>
        /// <returns>this instance</returns>
        public AddPermissionRequest WithAWSAccountId(params String[] list)
        {
            foreach (String item in list)
            {
                AWSAccountId.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of AWSAccountId property is set
        /// </summary>
        /// <returns>true if AWSAccountId property is set</returns>
        public Boolean IsSetAWSAccountId()
        {
            return (AWSAccountId.Count > 0);
        }




        /// <summary>
        /// Gets and sets the ActionName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ActionName")]
        public List<String> ActionName
        {
            get
            {
                if (this.actionNameField == null)
                {
                    this.actionNameField = new List<String>();
                }
                return this.actionNameField;
            }
            set { this.actionNameField =  value; }
        }



        /// <summary>
        /// Sets the ActionName property
        /// </summary>
        /// <param name="list">ActionName property</param>
        /// <returns>this instance</returns>
        public AddPermissionRequest WithActionName(params String[] list)
        {
            foreach (String item in list)
            {
                ActionName.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of ActionName property is set
        /// </summary>
        /// <returns>true if ActionName property is set</returns>
        public Boolean IsSetActionName()
        {
            return (ActionName.Count > 0);
        }







    }

}