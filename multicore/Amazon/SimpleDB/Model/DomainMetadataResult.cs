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
 *  Amazon Simple DB CSharp Library
 *  API Version: 2009-04-15
 *  Generated: Mon May 11 14:22:34 PDT 2009 
 * 
 */

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;


namespace Amazon.SimpleDB.Model
{
    [XmlTypeAttribute(Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/")]
    [XmlRootAttribute(Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/", IsNullable = false)]
    public class DomainMetadataResult
    {
    
        private String itemCountField;

        private String itemNamesSizeBytesField;

        private String attributeNameCountField;

        private String attributeNamesSizeBytesField;

        private String attributeValueCountField;

        private String attributeValuesSizeBytesField;

        private String timestampField;


        /// <summary>
        /// Gets and sets the ItemCount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ItemCount")]
        public String ItemCount
        {
            get { return this.itemCountField ; }
            set { this.itemCountField= value; }
        }



        /// <summary>
        /// Sets the ItemCount property
        /// </summary>
        /// <param name="itemCount">ItemCount property</param>
        /// <returns>this instance</returns>
        public DomainMetadataResult WithItemCount(String itemCount)
        {
            this.itemCountField = itemCount;
            return this;
        }



        /// <summary>
        /// Checks if ItemCount property is set
        /// </summary>
        /// <returns>true if ItemCount property is set</returns>
        public Boolean IsSetItemCount()
        {
            return  this.itemCountField != null;

        }


        /// <summary>
        /// Gets and sets the ItemNamesSizeBytes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ItemNamesSizeBytes")]
        public String ItemNamesSizeBytes
        {
            get { return this.itemNamesSizeBytesField ; }
            set { this.itemNamesSizeBytesField= value; }
        }



        /// <summary>
        /// Sets the ItemNamesSizeBytes property
        /// </summary>
        /// <param name="itemNamesSizeBytes">ItemNamesSizeBytes property</param>
        /// <returns>this instance</returns>
        public DomainMetadataResult WithItemNamesSizeBytes(String itemNamesSizeBytes)
        {
            this.itemNamesSizeBytesField = itemNamesSizeBytes;
            return this;
        }



        /// <summary>
        /// Checks if ItemNamesSizeBytes property is set
        /// </summary>
        /// <returns>true if ItemNamesSizeBytes property is set</returns>
        public Boolean IsSetItemNamesSizeBytes()
        {
            return  this.itemNamesSizeBytesField != null;

        }


        /// <summary>
        /// Gets and sets the AttributeNameCount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AttributeNameCount")]
        public String AttributeNameCount
        {
            get { return this.attributeNameCountField ; }
            set { this.attributeNameCountField= value; }
        }



        /// <summary>
        /// Sets the AttributeNameCount property
        /// </summary>
        /// <param name="attributeNameCount">AttributeNameCount property</param>
        /// <returns>this instance</returns>
        public DomainMetadataResult WithAttributeNameCount(String attributeNameCount)
        {
            this.attributeNameCountField = attributeNameCount;
            return this;
        }



        /// <summary>
        /// Checks if AttributeNameCount property is set
        /// </summary>
        /// <returns>true if AttributeNameCount property is set</returns>
        public Boolean IsSetAttributeNameCount()
        {
            return  this.attributeNameCountField != null;

        }


        /// <summary>
        /// Gets and sets the AttributeNamesSizeBytes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AttributeNamesSizeBytes")]
        public String AttributeNamesSizeBytes
        {
            get { return this.attributeNamesSizeBytesField ; }
            set { this.attributeNamesSizeBytesField= value; }
        }



        /// <summary>
        /// Sets the AttributeNamesSizeBytes property
        /// </summary>
        /// <param name="attributeNamesSizeBytes">AttributeNamesSizeBytes property</param>
        /// <returns>this instance</returns>
        public DomainMetadataResult WithAttributeNamesSizeBytes(String attributeNamesSizeBytes)
        {
            this.attributeNamesSizeBytesField = attributeNamesSizeBytes;
            return this;
        }



        /// <summary>
        /// Checks if AttributeNamesSizeBytes property is set
        /// </summary>
        /// <returns>true if AttributeNamesSizeBytes property is set</returns>
        public Boolean IsSetAttributeNamesSizeBytes()
        {
            return  this.attributeNamesSizeBytesField != null;

        }


        /// <summary>
        /// Gets and sets the AttributeValueCount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AttributeValueCount")]
        public String AttributeValueCount
        {
            get { return this.attributeValueCountField ; }
            set { this.attributeValueCountField= value; }
        }



        /// <summary>
        /// Sets the AttributeValueCount property
        /// </summary>
        /// <param name="attributeValueCount">AttributeValueCount property</param>
        /// <returns>this instance</returns>
        public DomainMetadataResult WithAttributeValueCount(String attributeValueCount)
        {
            this.attributeValueCountField = attributeValueCount;
            return this;
        }



        /// <summary>
        /// Checks if AttributeValueCount property is set
        /// </summary>
        /// <returns>true if AttributeValueCount property is set</returns>
        public Boolean IsSetAttributeValueCount()
        {
            return  this.attributeValueCountField != null;

        }


        /// <summary>
        /// Gets and sets the AttributeValuesSizeBytes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AttributeValuesSizeBytes")]
        public String AttributeValuesSizeBytes
        {
            get { return this.attributeValuesSizeBytesField ; }
            set { this.attributeValuesSizeBytesField= value; }
        }



        /// <summary>
        /// Sets the AttributeValuesSizeBytes property
        /// </summary>
        /// <param name="attributeValuesSizeBytes">AttributeValuesSizeBytes property</param>
        /// <returns>this instance</returns>
        public DomainMetadataResult WithAttributeValuesSizeBytes(String attributeValuesSizeBytes)
        {
            this.attributeValuesSizeBytesField = attributeValuesSizeBytes;
            return this;
        }



        /// <summary>
        /// Checks if AttributeValuesSizeBytes property is set
        /// </summary>
        /// <returns>true if AttributeValuesSizeBytes property is set</returns>
        public Boolean IsSetAttributeValuesSizeBytes()
        {
            return  this.attributeValuesSizeBytesField != null;

        }


        /// <summary>
        /// Gets and sets the Timestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Timestamp")]
        public String Timestamp
        {
            get { return this.timestampField ; }
            set { this.timestampField= value; }
        }



        /// <summary>
        /// Sets the Timestamp property
        /// </summary>
        /// <param name="timestamp">Timestamp property</param>
        /// <returns>this instance</returns>
        public DomainMetadataResult WithTimestamp(String timestamp)
        {
            this.timestampField = timestamp;
            return this;
        }



        /// <summary>
        /// Checks if Timestamp property is set
        /// </summary>
        /// <returns>true if Timestamp property is set</returns>
        public Boolean IsSetTimestamp()
        {
            return  this.timestampField != null;

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
            if (IsSetItemCount()) {
                xml.Append("<ItemCount>");
                xml.Append(EscapeXML(this.ItemCount));
                xml.Append("</ItemCount>");
            }
            if (IsSetItemNamesSizeBytes()) {
                xml.Append("<ItemNamesSizeBytes>");
                xml.Append(EscapeXML(this.ItemNamesSizeBytes));
                xml.Append("</ItemNamesSizeBytes>");
            }
            if (IsSetAttributeNameCount()) {
                xml.Append("<AttributeNameCount>");
                xml.Append(EscapeXML(this.AttributeNameCount));
                xml.Append("</AttributeNameCount>");
            }
            if (IsSetAttributeNamesSizeBytes()) {
                xml.Append("<AttributeNamesSizeBytes>");
                xml.Append(EscapeXML(this.AttributeNamesSizeBytes));
                xml.Append("</AttributeNamesSizeBytes>");
            }
            if (IsSetAttributeValueCount()) {
                xml.Append("<AttributeValueCount>");
                xml.Append(EscapeXML(this.AttributeValueCount));
                xml.Append("</AttributeValueCount>");
            }
            if (IsSetAttributeValuesSizeBytes()) {
                xml.Append("<AttributeValuesSizeBytes>");
                xml.Append(EscapeXML(this.AttributeValuesSizeBytes));
                xml.Append("</AttributeValuesSizeBytes>");
            }
            if (IsSetTimestamp()) {
                xml.Append("<Timestamp>");
                xml.Append(EscapeXML(this.Timestamp));
                xml.Append("</Timestamp>");
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