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
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Amazon.SQS.Model;

namespace Amazon.SQS.Mock
{

    /// <summary>
    /// AmazonSQSMock is the implementation of AmazonSQS based
    /// on the pre-populated set of XML files that serve local data. It simulates 
    /// responses from Amazon SQS service.
    /// </summary>
    /// <remarks>
    /// Use this to test your application without making a call to 
    /// Amazon SQS 
    /// 
    /// Note, current Mock Service implementation does not valiadate requests
    /// </remarks>
    public  class AmazonSQSMock : AmazonSQS {
    

        // Public API ------------------------------------------------------------//
    
        
        /// <summary>
        /// Create Queue 
        /// </summary>
        /// <param name="request">Create Queue  request</param>
        /// <returns>Create Queue  Response from the service</returns>
        /// <remarks>
        /// The CreateQueue action creates a new queue, or returns the URL of an existing one.  When you request CreateQueue, you provide a name for the queue. To successfully create a new queue, you must provide a name that is unique within the scope of your own queues. If you provide the name of an existing queue, a new queue isn't created and an error isn't returned. Instead, the request succeeds and the queue URL for the existing queue is returned. Exception: if you provide a value for DefaultVisibilityTimeout that is different from the value for the existing queue, you receive an error.  
        /// </remarks>
        public CreateQueueResponse CreateQueue(CreateQueueRequest request)
        {
            return Invoke<CreateQueueResponse>("CreateQueueResponse.xml");
        }
        
        /// <summary>
        /// List Queues 
        /// </summary>
        /// <param name="request">List Queues  request</param>
        /// <returns>List Queues  Response from the service</returns>
        /// <remarks>
        /// The ListQueues action returns a list of your queues.
        ///   
        /// </remarks>
        public ListQueuesResponse ListQueues(ListQueuesRequest request)
        {
            return Invoke<ListQueuesResponse>("ListQueuesResponse.xml");
        }
        
        /// <summary>
        /// Add Permission 
        /// </summary>
        /// <param name="request">Add Permission  request</param>
        /// <returns>Add Permission  Response from the service</returns>
        /// <remarks>
        /// Adds the specified permission(s) to a queue for the specified principal(s). This allows for sharing access to the queue.
        ///   
        /// </remarks>
        public AddPermissionResponse AddPermission(AddPermissionRequest request)
        {
            return Invoke<AddPermissionResponse>("AddPermissionResponse.xml");
        }
        
        /// <summary>
        /// Change Message Visibility 
        /// </summary>
        /// <param name="request">Change Message Visibility  request</param>
        /// <returns>Change Message Visibility  Response from the service</returns>
        /// <remarks>
        /// The ChangeMessageVisibility action extends the read lock timeout of the specified message from the specified queue to the specified value.
        ///   
        /// </remarks>
        public ChangeMessageVisibilityResponse ChangeMessageVisibility(ChangeMessageVisibilityRequest request)
        {
            return Invoke<ChangeMessageVisibilityResponse>("ChangeMessageVisibilityResponse.xml");
        }
        
        /// <summary>
        /// Delete Message 
        /// </summary>
        /// <param name="request">Delete Message  request</param>
        /// <returns>Delete Message  Response from the service</returns>
        /// <remarks>
        /// The DeleteMessage action unconditionally removes the specified message from the specified queue. Even if the message is locked by another reader due to the visibility timeout setting, it is still deleted from the queue.
        ///   
        /// </remarks>
        public DeleteMessageResponse DeleteMessage(DeleteMessageRequest request)
        {
            return Invoke<DeleteMessageResponse>("DeleteMessageResponse.xml");
        }
        
        /// <summary>
        /// Delete Queue 
        /// </summary>
        /// <param name="request">Delete Queue  request</param>
        /// <returns>Delete Queue  Response from the service</returns>
        /// <remarks>
        /// This action unconditionally deletes the queue specified by the queue URL. Use this operation WITH CARE!  The queue is deleted even if it is NOT empty.
        ///   
        /// </remarks>
        public DeleteQueueResponse DeleteQueue(DeleteQueueRequest request)
        {
            return Invoke<DeleteQueueResponse>("DeleteQueueResponse.xml");
        }
        
        /// <summary>
        /// Get Queue Attributes 
        /// </summary>
        /// <param name="request">Get Queue Attributes  request</param>
        /// <returns>Get Queue Attributes  Response from the service</returns>
        /// <remarks>
        /// Gets one or all attributes of a queue. Queues currently have two attributes you can get: ApproximateNumberOfMessages and VisibilityTimeout.
        ///   
        /// </remarks>
        public GetQueueAttributesResponse GetQueueAttributes(GetQueueAttributesRequest request)
        {
            return Invoke<GetQueueAttributesResponse>("GetQueueAttributesResponse.xml");
        }
        
        /// <summary>
        /// Remove Permission 
        /// </summary>
        /// <param name="request">Remove Permission  request</param>
        /// <returns>Remove Permission  Response from the service</returns>
        /// <remarks>
        /// Removes the permission with the specified statement id from the queue.
        ///   
        /// </remarks>
        public RemovePermissionResponse RemovePermission(RemovePermissionRequest request)
        {
            return Invoke<RemovePermissionResponse>("RemovePermissionResponse.xml");
        }
        
        /// <summary>
        /// Receive Message 
        /// </summary>
        /// <param name="request">Receive Message  request</param>
        /// <returns>Receive Message  Response from the service</returns>
        /// <remarks>
        /// Retrieves one or more messages from the specified queue.  For each message returned, the response includes the message body; MD5 digest of the message body; receipt handle, which is the identifier you must provide when deleting the message; and message ID of each message. Messages returned by this action stay in the queue until you delete them. However, once a message is returned to a ReceiveMessage request, it is not returned on subsequent ReceiveMessage requests for the duration of the VisibilityTimeout. If you do not specify a VisibilityTimeout in the request, the overall visibility timeout for the queue is used for the returned messages.
        ///   
        /// </remarks>
        public ReceiveMessageResponse ReceiveMessage(ReceiveMessageRequest request)
        {
            return Invoke<ReceiveMessageResponse>("ReceiveMessageResponse.xml");
        }
        
        /// <summary>
        /// Send Message 
        /// </summary>
        /// <param name="request">Send Message  request</param>
        /// <returns>Send Message  Response from the service</returns>
        /// <remarks>
        /// The SendMessage action delivers a message to the specified queue.
        ///   
        /// </remarks>
        public SendMessageResponse SendMessage(SendMessageRequest request)
        {
            return Invoke<SendMessageResponse>("SendMessageResponse.xml");
        }
        
        /// <summary>
        /// Set Queue Attributes 
        /// </summary>
        /// <param name="request">Set Queue Attributes  request</param>
        /// <returns>Set Queue Attributes  Response from the service</returns>
        /// <remarks>
        /// Sets an attribute of a queue. Currently, you can set only the VisibilityTimeout attribute for a queue.
        ///   
        /// </remarks>
        public SetQueueAttributesResponse SetQueueAttributes(SetQueueAttributesRequest request)
        {
            return Invoke<SetQueueAttributesResponse>("SetQueueAttributesResponse.xml");
        }

        // Private API ------------------------------------------------------------//

        private T Invoke<T>(String xmlResource)
        {
            XmlSerializer serlizer = new XmlSerializer(typeof(T));
            Stream xmlStream = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream(xmlResource);
            return (T)serlizer.Deserialize(xmlStream);
        }
    }
}