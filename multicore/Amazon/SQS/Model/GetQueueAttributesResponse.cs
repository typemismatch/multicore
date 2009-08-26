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
    public class GetQueueAttributesResponse
    {
    
        private  GetQueueAttributesResult getQueueAttributesResultField;
        private  ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the GetQueueAttributesResult property.
        /// </summary>
        [XmlElementAttribute(ElementName = "GetQueueAttributesResult")]
        public GetQueueAttributesResult GetQueueAttributesResult
        {
            get { return this.getQueueAttributesResultField ; }
            set { this.getQueueAttributesResultField = value; }
        }



        /// <summary>
        /// Sets the GetQueueAttributesResult property
        /// </summary>
        /// <param name="getQueueAttributesResult">GetQueueAttributesResult property</param>
        /// <returns>this instance</returns>
        public GetQueueAttributesResponse WithGetQueueAttributesResult(GetQueueAttributesResult getQueueAttributesResult)
        {
            this.getQueueAttributesResultField = getQueueAttributesResult;
            return this;
        }



        /// <summary>
        /// Checks if GetQueueAttributesResult property is set
        /// </summary>
        /// <returns>true if GetQueueAttributesResult property is set</returns>
        public Boolean IsSetGetQueueAttributesResult()
        {
            return this.getQueueAttributesResultField != null;
        }




        /// <summary>
        /// Gets and sets the ResponseMetadata property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ResponseMetadata")]
        public ResponseMetadata ResponseMetadata
        {
            get { return this.responseMetadataField ; }
            set { this.responseMetadataField = value; }
        }



        /// <summary>
        /// Sets the ResponseMetadata property
        /// </summary>
        /// <param name="responseMetadata">ResponseMetadata property</param>
        /// <returns>this instance</returns>
        public GetQueueAttributesResponse WithResponseMetadata(ResponseMetadata responseMetadata)
        {
            this.responseMetadataField = responseMetadata;
            return this;
        }



        /// <summary>
        /// Checks if ResponseMetadata property is set
        /// </summary>
        /// <returns>true if ResponseMetadata property is set</returns>
        public Boolean IsSetResponseMetadata()
        {
            return this.responseMetadataField != null;
        }






        /// <summary>
        /// XML Representation for this object
        /// </summary>
        /// <returns>XML String</returns>

        public String ToXML() {
            StringBuilder xml = new StringBuilder();
            xml.Append("<GetQueueAttributesResponse xmlns=\"http://queue.amazonaws.com/doc/2009-02-01/\">");
            if (IsSetGetQueueAttributesResult()) {
                GetQueueAttributesResult  getQueueAttributesResult = this.GetQueueAttributesResult;
                xml.Append("<GetQueueAttributesResult>");
                xml.Append(getQueueAttributesResult.ToXMLFragment());
                xml.Append("</GetQueueAttributesResult>");
            } 
            if (IsSetResponseMetadata()) {
                ResponseMetadata  responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            } 
            xml.Append("</GetQueueAttributesResponse>");
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