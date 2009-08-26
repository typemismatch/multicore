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
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml.Serialization;
using System.Collections.Generic;
using Amazon.SimpleDB.Model;
using Amazon.SimpleDB;
using Attribute = Amazon.SimpleDB.Model.Attribute;

namespace Amazon.SimpleDB
{


   /**

    *
    * AmazonSimpleDBClient is an implementation of AmazonSimpleDB
    *
    */
    public class AmazonSimpleDBClient : AmazonSimpleDB
    {

        private String awsAccessKeyId = null;
        private String awsSecretAccessKey = null;
        private AmazonSimpleDBConfig config = null;

        /// <summary>
        /// Constructs AmazonSimpleDBClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        public AmazonSimpleDBClient(String awsAccessKeyId, String awsSecretAccessKey)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonSimpleDBConfig())
        {
        }


        /// <summary>
        /// Constructs AmazonSimpleDBClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="config">configuration</param>
        public AmazonSimpleDBClient(String awsAccessKeyId, String awsSecretAccessKey, AmazonSimpleDBConfig config)
        {
            this.awsAccessKeyId = awsAccessKeyId;
            this.awsSecretAccessKey = awsSecretAccessKey;
            this.config = config;
        }


        // Public API ------------------------------------------------------------//

        
        /// <summary>
        /// Create Domain 
        /// </summary>
        /// <param name="request">Create Domain  request</param>
        /// <returns>Create Domain  Response from the service</returns>
        /// <remarks>
        /// The CreateDomain operation creates a new domain. The domain name must be unique
        /// among the domains associated with the Access Key ID provided in the request. The CreateDomain
        /// operation may take 10 or more seconds to complete.
        /// 
        /// </remarks>
        public CreateDomainResponse CreateDomain(CreateDomainRequest request)
        {
            return Invoke<CreateDomainResponse>(ConvertCreateDomain(request));
        }

        
        /// <summary>
        /// List Domains 
        /// </summary>
        /// <param name="request">List Domains  request</param>
        /// <returns>List Domains  Response from the service</returns>
        /// <remarks>
        /// The ListDomains operation lists all domains associated with the Access Key ID. It returns
        /// domain names up to the limit set by MaxNumberOfDomains. A NextToken is returned if there are more
        /// than MaxNumberOfDomains domains. Calling ListDomains successive times with the
        /// NextToken returns up to MaxNumberOfDomains more domain names each time.
        /// 
        /// </remarks>
        public ListDomainsResponse ListDomains(ListDomainsRequest request)
        {
            return Invoke<ListDomainsResponse>(ConvertListDomains(request));
        }

        
        /// <summary>
        /// Domain Metadata 
        /// </summary>
        /// <param name="request">Domain Metadata  request</param>
        /// <returns>Domain Metadata  Response from the service</returns>
        /// <remarks>
        /// The DomainMetadata operation returns some domain metadata values, such as the
        /// number of items, attribute names and attribute values along with their sizes.
        /// 
        /// </remarks>
        public DomainMetadataResponse DomainMetadata(DomainMetadataRequest request)
        {
            return Invoke<DomainMetadataResponse>(ConvertDomainMetadata(request));
        }

        
        /// <summary>
        /// Delete Domain 
        /// </summary>
        /// <param name="request">Delete Domain  request</param>
        /// <returns>Delete Domain  Response from the service</returns>
        /// <remarks>
        /// The DeleteDomain operation deletes a domain. Any items (and their attributes) in the domain
        /// are deleted as well. The DeleteDomain operation may take 10 or more seconds to complete.
        /// 
        /// </remarks>
        public DeleteDomainResponse DeleteDomain(DeleteDomainRequest request)
        {
            return Invoke<DeleteDomainResponse>(ConvertDeleteDomain(request));
        }

        
        /// <summary>
        /// Put Attributes 
        /// </summary>
        /// <param name="request">Put Attributes  request</param>
        /// <returns>Put Attributes  Response from the service</returns>
        /// <remarks>
        /// The PutAttributes operation creates or replaces attributes within an item. You specify new attributes
        /// using a combination of the Attribute.X.Name and Attribute.X.Value parameters. You specify
        /// the first attribute by the parameters Attribute.0.Name and Attribute.0.Value, the second
        /// attribute by the parameters Attribute.1.Name and Attribute.1.Value, and so on.
        /// Attributes are uniquely identified within an item by their name/value combination. For example, a single
        /// item can have the attributes { "first_name", "first_value" } and { "first_name",
        /// second_value" }. However, it cannot have two attribute instances where both the Attribute.X.Name and
        /// Attribute.X.Value are the same.
        /// Optionally, the requestor can supply the Replace parameter for each individual value. Setting this value
        /// to true will cause the new attribute value to replace the existing attribute value(s). For example, if an
        /// item has the attributes { 'a', '1' }, { 'b', '2'} and { 'b', '3' } and the requestor does a
        /// PutAttributes of { 'b', '4' } with the Replace parameter set to true, the final attributes of the
        /// item will be { 'a', '1' } and { 'b', '4' }, replacing the previous values of the 'b' attribute
        /// with the new value.
        /// 
        /// </remarks>
        public PutAttributesResponse PutAttributes(PutAttributesRequest request)
        {
            return Invoke<PutAttributesResponse>(ConvertPutAttributes(request));
        }

        
        /// <summary>
        /// Batch Put Attributes 
        /// </summary>
        /// <param name="request">Batch Put Attributes  request</param>
        /// <returns>Batch Put Attributes  Response from the service</returns>
        /// <remarks>
        /// The BatchPutAttributes operation creates or replaces attributes within one or more items.
        /// You specify the item name with the Item.X.ItemName parameter.
        /// You specify new attributes using a combination of the Item.X.Attribute.Y.Name and Item.X.Attribute.Y.Value parameters.
        /// You specify the first attribute for the first item by the parameters Item.0.Attribute.0.Name and Item.0.Attribute.0.Value,
        /// the second attribute for the first item by the parameters Item.0.Attribute.1.Name and Item.0.Attribute.1.Value, and so on.
        /// Attributes are uniquely identified within an item by their name/value combination. For example, a single
        /// item can have the attributes { "first_name", "first_value" } and { "first_name",
        /// second_value" }. However, it cannot have two attribute instances where both the Item.X.Attribute.Y.Name and
        /// Item.X.Attribute.Y.Value are the same.
        /// Optionally, the requestor can supply the Replace parameter for each individual value. Setting this value
        /// to true will cause the new attribute value to replace the existing attribute value(s). For example, if an
        /// item 'I' has the attributes { 'a', '1' }, { 'b', '2'} and { 'b', '3' } and the requestor does a
        /// BacthPutAttributes of {'I', 'b', '4' } with the Replace parameter set to true, the final attributes of the
        /// item will be { 'a', '1' } and { 'b', '4' }, replacing the previous values of the 'b' attribute
        /// with the new value.
        /// 
        /// </remarks>
        public BatchPutAttributesResponse BatchPutAttributes(BatchPutAttributesRequest request)
        {
            return Invoke<BatchPutAttributesResponse>(ConvertBatchPutAttributes(request));
        }

        
        /// <summary>
        /// Get Attributes 
        /// </summary>
        /// <param name="request">Get Attributes  request</param>
        /// <returns>Get Attributes  Response from the service</returns>
        /// <remarks>
        /// Returns all of the attributes associated with the item. Optionally, the attributes returned can be limited to
        /// the specified AttributeName parameter.
        /// If the item does not exist on the replica that was accessed for this operation, an empty attribute is
        /// returned. The system does not return an error as it cannot guarantee the item does not exist on other
        /// replicas.
        /// 
        /// </remarks>
        public GetAttributesResponse GetAttributes(GetAttributesRequest request)
        {
            return Invoke<GetAttributesResponse>(ConvertGetAttributes(request));
        }

        
        /// <summary>
        /// Delete Attributes 
        /// </summary>
        /// <param name="request">Delete Attributes  request</param>
        /// <returns>Delete Attributes  Response from the service</returns>
        /// <remarks>
        /// Deletes one or more attributes associated with the item. If all attributes of an item are deleted, the item is
        /// deleted.
        /// 
        /// </remarks>
        public DeleteAttributesResponse DeleteAttributes(DeleteAttributesRequest request)
        {
            return Invoke<DeleteAttributesResponse>(ConvertDeleteAttributes(request));
        }

        
        /// <summary>
        /// Select 
        /// </summary>
        /// <param name="request">Select  request</param>
        /// <returns>Select  Response from the service</returns>
        /// <remarks>
        /// The Select operation returns a set of item names and associate attributes that match the
        /// query expression. Select operations that run longer than 5 seconds will likely time-out
        /// and return a time-out error response.
        /// 
        /// </remarks>
        public SelectResponse Select(SelectRequest request)
        {
            return Invoke<SelectResponse>(ConvertSelect(request));
        }

        // Private API ------------------------------------------------------------//

        /**
         * Configure HttpClient with set of defaults as well as configuration
         * from AmazonSimpleDBConfig instance
         */
        private HttpWebRequest ConfigureWebRequest(int contentLength)
        {
            HttpWebRequest request = WebRequest.Create(config.ServiceURL) as HttpWebRequest;

            if (config.IsSetProxyHost())
            {
                request.Proxy = new WebProxy(config.ProxyHost, config.ProxyPort);
            }
            request.UserAgent = config.UserAgent;
            request.Method = "POST";
            request.Timeout = 50000;
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = contentLength;

            return request;
        }

        /**
         * Invoke request and return response
         */
        private T Invoke<T>(IDictionary<String, String> parameters)
        {
            String actionName = parameters["Action"];
            T response = default(T);
            String responseBody = null;
            HttpStatusCode statusCode = default(HttpStatusCode);

            /* Add required request parameters */
            AddRequiredParameters(parameters);

            String queryString = GetParametersAsString(parameters);

            byte[] requestData = new UTF8Encoding().GetBytes(queryString);
            bool shouldRetry = true;
            int retries = 0;
            do
            {
                HttpWebRequest request = ConfigureWebRequest(requestData.Length);
                /* Submit the request and read response body */
                try
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(requestData, 0, requestData.Length);
                    }
                    using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                    {
                        statusCode = httpResponse.StatusCode;
                        StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
                        responseBody = reader.ReadToEnd();
                    }

                    /* Attempt to deserialize response into <Action> Response type */
                    XmlSerializer serlizer = new XmlSerializer(typeof(T));
                    response = (T)serlizer.Deserialize(new StringReader(responseBody));
                    shouldRetry = false;
                }
                /* Web exception is thrown on unsucessful responses */
                catch (WebException we)
                {
                    shouldRetry = false;
                    using (HttpWebResponse httpErrorResponse = (HttpWebResponse)we.Response as HttpWebResponse)
                    {
                        if (httpErrorResponse == null)
                        {
                            throw new AmazonSimpleDBException(we);
                        }
                        statusCode = httpErrorResponse.StatusCode;
                        StreamReader reader = new StreamReader(httpErrorResponse.GetResponseStream(), Encoding.UTF8);
                        responseBody = reader.ReadToEnd();
                    }

                    if (statusCode == HttpStatusCode.InternalServerError || statusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        shouldRetry = true;
                        PauseOnRetry(++retries, statusCode);
                    }
                    else
                    {

                        /* Attempt to deserialize response into ErrorResponse type */
                        try
                        {
                            XmlSerializer serlizer = new XmlSerializer(typeof(ErrorResponse));
                            ErrorResponse errorResponse = (ErrorResponse)serlizer.Deserialize(new StringReader(responseBody));
                            Error error = errorResponse.Error[0];

                            /* Throw formatted exception with information available from the error response */
                            throw new AmazonSimpleDBException(
                                error.Message,
                                statusCode,
                                error.Code,
                                error.Type,
                                null,
                                errorResponse.RequestId,
                                errorResponse.ToXML());
                        }
                        /* Rethrow on deserializer error */
                        catch (Exception e)
                        {
                            if (e is AmazonSimpleDBException)
                            {
                                throw e;
                            }
                            else
                            {
                                AmazonSimpleDBException se = ReportAnyErrors(responseBody, statusCode, e);
                                throw se;
                            }
                        }
                    }
                }

                /* Catch other exceptions, attempt to convert to formatted exception,
                 * else rethrow wrapped exception */
                catch (Exception e)
                {
                    throw new AmazonSimpleDBException(e);
                }
            } while (shouldRetry);

            return response;
        }


        /**
         * Look for additional error strings in the response and return formatted exception
         */
        private AmazonSimpleDBException ReportAnyErrors(String responseBody, HttpStatusCode status, Exception e)
        {

            AmazonSimpleDBException ex = null;

            if (responseBody != null && responseBody.StartsWith("<"))
            {
                Match errorMatcherOne = Regex.Match(responseBody, "<RequestId>(.*)</RequestId>.*<Error>" +
                        "<Code>(.*)</Code><Message>(.*)</Message></Error>.*(<Error>)?", RegexOptions.Multiline);
                Match errorMatcherTwo = Regex.Match(responseBody, "<Error><Code>(.*)</Code><Message>(.*)" +
                        "</Message></Error>.*(<Error>)?.*<RequestID>(.*)</RequestID>", RegexOptions.Multiline);
                Match errorMatcherThree = Regex.Match(responseBody, "<Error><Code>(.*)</Code><Message>(.*)" +
                        "</Message><BoxUsage>(.*)</BoxUsage></Error>.*(<Error>)?.*<RequestID>(.*)</RequestID>", RegexOptions.Multiline);

                if (errorMatcherOne.Success)
                {
                    String requestId = errorMatcherOne.Groups[1].Value;
                    String code = errorMatcherOne.Groups[2].Value;
                    String message = errorMatcherOne.Groups[3].Value;

                    ex = new AmazonSimpleDBException(message, status, code, "Unknown", null, requestId, responseBody);

                }
                else if (errorMatcherTwo.Success)
                {
                    String code = errorMatcherTwo.Groups[1].Value;
                    String message = errorMatcherTwo.Groups[2].Value;
                    String requestId = errorMatcherTwo.Groups[4].Value;

                    ex = new AmazonSimpleDBException(message, status, code, "Unknown", null, requestId, responseBody);
                }
                else if (errorMatcherThree.Success)
                {
                    String code = errorMatcherThree.Groups[1].Value;
                    String message = errorMatcherThree.Groups[2].Value;
                    String boxUsage = errorMatcherThree.Groups[3].Value;
                    String requestId = errorMatcherThree.Groups[5].Value;

                    ex = new AmazonSimpleDBException(message, status, code, "Unknown", boxUsage, requestId, responseBody);
                }
                else
                {
                    ex = new AmazonSimpleDBException("Internal Error", status);
                }
            }
            else
            {
                ex = new AmazonSimpleDBException("Internal Error", status);
            }
            return ex;
        }

        /**
         * Exponential sleep on failed request
         */
        private void PauseOnRetry(int retries, HttpStatusCode status)
        {
            if (retries <= config.MaxErrorRetry)
            {
                int delay = (int)Math.Pow(4, retries) * 100;
                System.Threading.Thread.Sleep(delay);
            }
            else
            {
                throw new AmazonSimpleDBException("Maximum number of retry attempts reached : " + (retries - 1), status);
            }
        }

        /**
         * Add authentication related and version parameters
         */
        private void AddRequiredParameters(IDictionary<String, String> parameters)
        {
            parameters.Add("AWSAccessKeyId", this.awsAccessKeyId);
            parameters.Add("Timestamp", GetFormattedTimestamp());
            parameters.Add("Version", config.ServiceVersion);
            parameters.Add("SignatureVersion", config.SignatureVersion);
            parameters.Add("Signature", SignParameters(parameters, this.awsSecretAccessKey));
        }

        /**
         * Convert Dictionary of paremeters to Url encoded query string
         */
        private string GetParametersAsString(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            foreach (String key in (IEnumerable<String>)parameters.Keys)
            {
                String value = parameters[key];
                if (value != null)
                {
                    data.Append(key);
                    data.Append('=');
                    data.Append(UrlEncode(value, false));
                    data.Append('&');
                }
            }
            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        /**
         * Computes RFC 2104-compliant HMAC signature for request parameters
         * Implements AWS Signature, as per following spec:
         *
         * If Signature Version is 0, it signs concatenated Action and Timestamp
         *
         * If Signature Version is 1, it performs the following:
         *
         * Sorts all  parameters (including SignatureVersion and excluding Signature,
         * the value of which is being created), ignoring case.
         *
         * Iterate over the sorted list and append the parameter name (in original case)
         * and then its value. It will not URL-encode the parameter values before
         * constructing this string. There are no separators.
         *
         * If Signature Version is 2, string to sign is based on following:
         *
         *    1. The HTTP Request Method followed by an ASCII newline (%0A)
         *    2. The HTTP Host header in the form of lowercase host, followed by an ASCII newline.
         *    3. The URL encoded HTTP absolute path component of the URI
         *       (up to but not including the query string parameters);
         *       if this is empty use a forward '/'. This parameter is followed by an ASCII newline.
         *    4. The concatenation of all query string components (names and values)
         *       as UTF-8 characters which are URL encoded as per RFC 3986
         *       (hex characters MUST be uppercase), sorted using lexicographic byte ordering.
         *       Parameter names are separated from their values by the '=' character
         *       (ASCII character 61), even if the value is empty.
         *       Pairs of parameter and values are separated by the '&' character (ASCII code 38).
         *
         */
        private String SignParameters(IDictionary<String, String> parameters, String key)
        {
            String signatureVersion = parameters["SignatureVersion"];

            KeyedHashAlgorithm algorithm = new HMACSHA1();

            String stringToSign = null;
            if ("0".Equals(signatureVersion))
            {
                stringToSign = CalculateStringToSignV0(parameters);
            }
            else if ("1".Equals(signatureVersion))
            {
                stringToSign = CalculateStringToSignV1(parameters);
            }
            else if ("2".Equals(signatureVersion))
            {
                String signatureMethod = config.SignatureMethod;
                algorithm = KeyedHashAlgorithm.Create(signatureMethod.ToUpper());
                parameters.Add("SignatureMethod", signatureMethod);
                stringToSign = CalculateStringToSignV2(parameters);
            }
            else
            {
                throw new Exception("Invalid Signature Version specified");
            }

            return Sign(stringToSign, key, algorithm);
        }

        private String CalculateStringToSignV0(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            return data.Append(parameters["Action"]).Append(parameters["Timestamp"]).ToString();

        }

        private String CalculateStringToSignV1(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
                IDictionary<String, String> sorted =
                  new SortedDictionary<String, String>(parameters, StringComparer.OrdinalIgnoreCase);
                foreach (KeyValuePair<String, String> pair in sorted)
                {
                    if (pair.Value != null)
                    {
                        data.Append(pair.Key);
                        data.Append(pair.Value);
                    }
                }
            return data.ToString();
        }

        private String CalculateStringToSignV2(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            IDictionary<String, String> sorted =
                  new SortedDictionary<String, String>(parameters, StringComparer.Ordinal);
            data.Append("POST");
            data.Append("\n");
            Uri endpoint = new Uri(config.ServiceURL.ToLower());

            data.Append(endpoint.Host);
            data.Append("\n");
            String uri = endpoint.AbsolutePath;
            if (uri == null || uri.Length == 0)
            {
                uri = "/";
            }
            data.Append(UrlEncode(uri, true));
            data.Append("\n");
            foreach (KeyValuePair<String, String> pair in sorted)
            {
                if (pair.Value != null)
                {
                    data.Append(UrlEncode(pair.Key, false));
                    data.Append("=");
                    data.Append(UrlEncode(pair.Value, false));
                    data.Append("&");
                }
                
            }

            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        private String UrlEncode(String data, bool path)
        {
            StringBuilder encoded = new StringBuilder();
            String unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~" + (path ? "/" : "");

            foreach (char symbol in System.Text.Encoding.UTF8.GetBytes(data))
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    encoded.Append(symbol);
                }
                else
                {
                    encoded.Append("%" + String.Format("{0:X2}", (int)symbol));
                }
            }

            return encoded.ToString();

        }

        /**
         * Computes RFC 2104-compliant HMAC signature.
         */
        private String Sign(String data, String key, KeyedHashAlgorithm algorithm)
        {
            Encoding encoding = new UTF8Encoding();
            algorithm.Key = encoding.GetBytes(key);
            return Convert.ToBase64String(algorithm.ComputeHash(
                encoding.GetBytes(data.ToCharArray())));
        }


        /**
         * Formats date as ISO 8601 timestamp
         */
        private String GetFormattedTimestamp()
        {
            DateTime dateTime = DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                 dateTime.Hour, dateTime.Minute, dateTime.Second,
                                 dateTime.Millisecond
                                 , DateTimeKind.Local
                               ).ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z",
                                CultureInfo.InvariantCulture);
        }

                                                                                
        /**
         * Convert CreateDomainRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCreateDomain(CreateDomainRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CreateDomain");
            if (request.IsSetDomainName())
            {
                parameters.Add("DomainName", request.DomainName);
            }

            return parameters;
        }
        
                                        
        /**
         * Convert ListDomainsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertListDomains(ListDomainsRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ListDomains");
            if (request.IsSetMaxNumberOfDomains())
            {
                parameters.Add("MaxNumberOfDomains", request.MaxNumberOfDomains + "");
            }
            if (request.IsSetNextToken())
            {
                parameters.Add("NextToken", request.NextToken);
            }

            return parameters;
        }
        
                                                
        /**
         * Convert DomainMetadataRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDomainMetadata(DomainMetadataRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DomainMetadata");
            if (request.IsSetDomainName())
            {
                parameters.Add("DomainName", request.DomainName);
            }

            return parameters;
        }
        
                                                
        /**
         * Convert DeleteDomainRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDeleteDomain(DeleteDomainRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DeleteDomain");
            if (request.IsSetDomainName())
            {
                parameters.Add("DomainName", request.DomainName);
            }

            return parameters;
        }
        
                                        
        /**
         * Convert PutAttributesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertPutAttributes(PutAttributesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "PutAttributes");
            if (request.IsSetDomainName())
            {
                parameters.Add("DomainName", request.DomainName);
            }
            if (request.IsSetItemName())
            {
                parameters.Add("ItemName", request.ItemName);
            }
            List<ReplaceableAttribute> putAttributesRequestAttributeList = request.Attribute;
            int putAttributesRequestAttributeListIndex = 1;
            foreach (ReplaceableAttribute putAttributesRequestAttribute in putAttributesRequestAttributeList)
            {
                if (putAttributesRequestAttribute.IsSetName())
                {
                    parameters.Add("Attribute" + "."  + putAttributesRequestAttributeListIndex + "." + "Name", putAttributesRequestAttribute.Name);
                }
                if (putAttributesRequestAttribute.IsSetValue())
                {
                    parameters.Add("Attribute" + "."  + putAttributesRequestAttributeListIndex + "." + "Value", putAttributesRequestAttribute.Value);
                }
                if (putAttributesRequestAttribute.IsSetReplace())
                {
                    parameters.Add("Attribute" + "."  + putAttributesRequestAttributeListIndex + "." + "Replace", putAttributesRequestAttribute.Replace + "");
                }

                putAttributesRequestAttributeListIndex++;
            }

            return parameters;
        }
        
                                        
        /**
         * Convert BatchPutAttributesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertBatchPutAttributes(BatchPutAttributesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "BatchPutAttributes");
            if (request.IsSetDomainName())
            {
                parameters.Add("DomainName", request.DomainName);
            }
            List<ReplaceableItem> batchPutAttributesRequestItemList = request.Item;
            int batchPutAttributesRequestItemListIndex = 1;
            foreach (ReplaceableItem batchPutAttributesRequestItem in batchPutAttributesRequestItemList)
            {
                if (batchPutAttributesRequestItem.IsSetItemName())
                {
                    parameters.Add("Item" + "."  + batchPutAttributesRequestItemListIndex + "." + "ItemName", batchPutAttributesRequestItem.ItemName);
                }
                List<ReplaceableAttribute> itemAttributeList = batchPutAttributesRequestItem.Attribute;
                int itemAttributeListIndex = 1;
                foreach (ReplaceableAttribute itemAttribute in itemAttributeList)
                {
                    if (itemAttribute.IsSetName())
                    {
                        parameters.Add("Item" + "."  + batchPutAttributesRequestItemListIndex + "." + "Attribute" + "."  + itemAttributeListIndex + "." + "Name", itemAttribute.Name);
                    }
                    if (itemAttribute.IsSetValue())
                    {
                        parameters.Add("Item" + "."  + batchPutAttributesRequestItemListIndex + "." + "Attribute" + "."  + itemAttributeListIndex + "." + "Value", itemAttribute.Value);
                    }
                    if (itemAttribute.IsSetReplace())
                    {
                        parameters.Add("Item" + "."  + batchPutAttributesRequestItemListIndex + "." + "Attribute" + "."  + itemAttributeListIndex + "." + "Replace", itemAttribute.Replace + "");
                    }

                    itemAttributeListIndex++;
                }

                batchPutAttributesRequestItemListIndex++;
            }

            return parameters;
        }
        
                                        
        /**
         * Convert GetAttributesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetAttributes(GetAttributesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetAttributes");
            if (request.IsSetDomainName())
            {
                parameters.Add("DomainName", request.DomainName);
            }
            if (request.IsSetItemName())
            {
                parameters.Add("ItemName", request.ItemName);
            }
            List<String> getAttributesRequestAttributeNameList  =  request.AttributeName;
            int getAttributesRequestAttributeNameListIndex = 1;
            foreach  (String getAttributesRequestAttributeName in getAttributesRequestAttributeNameList)
            {
                parameters.Add("AttributeName" + "."  + getAttributesRequestAttributeNameListIndex, getAttributesRequestAttributeName);
                getAttributesRequestAttributeNameListIndex++;
            }

            return parameters;
        }
        
                                                
        /**
         * Convert DeleteAttributesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDeleteAttributes(DeleteAttributesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DeleteAttributes");
            if (request.IsSetDomainName())
            {
                parameters.Add("DomainName", request.DomainName);
            }
            if (request.IsSetItemName())
            {
                parameters.Add("ItemName", request.ItemName);
            }
            List<Attribute> deleteAttributesRequestAttributeList = request.Attribute;
            int deleteAttributesRequestAttributeListIndex = 1;
            foreach (Attribute deleteAttributesRequestAttribute in deleteAttributesRequestAttributeList)
            {
                if (deleteAttributesRequestAttribute.IsSetName())
                {
                    parameters.Add("Attribute" + "."  + deleteAttributesRequestAttributeListIndex + "." + "Name", deleteAttributesRequestAttribute.Name);
                }
                if (deleteAttributesRequestAttribute.IsSetValue())
                {
                    parameters.Add("Attribute" + "."  + deleteAttributesRequestAttributeListIndex + "." + "Value", deleteAttributesRequestAttribute.Value);
                }

                deleteAttributesRequestAttributeListIndex++;
            }

            return parameters;
        }
        
                                        
        /**
         * Convert SelectRequest to name value pairs
         */
        private IDictionary<String, String> ConvertSelect(SelectRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "Select");
            if (request.IsSetSelectExpression())
            {
                parameters.Add("SelectExpression", request.SelectExpression);
            }
            if (request.IsSetNextToken())
            {
                parameters.Add("NextToken", request.NextToken);
            }

            return parameters;
        }
        
                        
    }
}