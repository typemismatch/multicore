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
using Attribute = Amazon.SimpleDB.Model.Attribute;

namespace Amazon.SimpleDB.Model
{
    [XmlTypeAttribute(Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/")]
    [XmlRootAttribute(Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/", IsNullable = false)]
    public class SelectRequest
    {
    
        private String selectExpressionField;

        private String nextTokenField;


        /// <summary>
        /// Gets and sets the SelectExpression property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SelectExpression")]
        public String SelectExpression
        {
            get { return this.selectExpressionField ; }
            set { this.selectExpressionField= value; }
        }



        /// <summary>
        /// Sets the SelectExpression property
        /// </summary>
        /// <param name="selectExpression">SelectExpression property</param>
        /// <returns>this instance</returns>
        public SelectRequest WithSelectExpression(String selectExpression)
        {
            this.selectExpressionField = selectExpression;
            return this;
        }



        /// <summary>
        /// Checks if SelectExpression property is set
        /// </summary>
        /// <returns>true if SelectExpression property is set</returns>
        public Boolean IsSetSelectExpression()
        {
            return  this.selectExpressionField != null;

        }


        /// <summary>
        /// Gets and sets the NextToken property.
        /// </summary>
        [XmlElementAttribute(ElementName = "NextToken")]
        public String NextToken
        {
            get { return this.nextTokenField ; }
            set { this.nextTokenField= value; }
        }



        /// <summary>
        /// Sets the NextToken property
        /// </summary>
        /// <param name="nextToken">NextToken property</param>
        /// <returns>this instance</returns>
        public SelectRequest WithNextToken(String nextToken)
        {
            this.nextTokenField = nextToken;
            return this;
        }



        /// <summary>
        /// Checks if NextToken property is set
        /// </summary>
        /// <returns>true if NextToken property is set</returns>
        public Boolean IsSetNextToken()
        {
            return  this.nextTokenField != null;

        }





    }

}