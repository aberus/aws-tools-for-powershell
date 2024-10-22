/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Returns the URL of an existing Amazon SQS queue.
    /// 
    ///  
    /// <para>
    /// To access a queue that belongs to another AWS account, use the <c>QueueOwnerAWSAccountId</c>
    /// parameter to specify the account ID of the queue's owner. The queue's owner must grant
    /// you permission to access the queue. For more information about shared queue access,
    /// see <c><a>AddPermission</a></c> or see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-writing-an-sqs-policy.html#write-messages-to-shared-queue">Allow
    /// Developers to Write Messages to a Shared Queue</a> in the <i>Amazon SQS Developer
    /// Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SQSQueueUrl")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) GetQueueUrl API operation.", Operation = new[] {"GetQueueUrl"}, SelectReturnType = typeof(Amazon.SQS.Model.GetQueueUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.SQS.Model.GetQueueUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SQS.Model.GetQueueUrlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSQSQueueUrlCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueueName
        /// <summary>
        /// <para>
        /// <para>The name of the queue whose URL must be fetched. Maximum 80 characters. Valid values:
        /// alphanumeric characters, hyphens (<c>-</c>), and underscores (<c>_</c>).</para><para>Queue URLs and names are case-sensitive.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String QueueName { get; set; }
        #endregion
        
        #region Parameter QueueOwnerAWSAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the account that created the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String QueueOwnerAWSAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueueUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.GetQueueUrlResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.GetQueueUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueueUrl";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.GetQueueUrlResponse, GetSQSQueueUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.QueueName = this.QueueName;
            #if MODULAR
            if (this.QueueName == null && ParameterWasBound(nameof(this.QueueName)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueueOwnerAWSAccountId = this.QueueOwnerAWSAccountId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SQS.Model.GetQueueUrlRequest();
            
            if (cmdletContext.QueueName != null)
            {
                request.QueueName = cmdletContext.QueueName;
            }
            if (cmdletContext.QueueOwnerAWSAccountId != null)
            {
                request.QueueOwnerAWSAccountId = cmdletContext.QueueOwnerAWSAccountId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SQS.Model.GetQueueUrlResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.GetQueueUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "GetQueueUrl");
            try
            {
                #if DESKTOP
                return client.GetQueueUrl(request);
                #elif CORECLR
                return client.GetQueueUrlAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String QueueName { get; set; }
            public System.String QueueOwnerAWSAccountId { get; set; }
            public System.Func<Amazon.SQS.Model.GetQueueUrlResponse, GetSQSQueueUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueUrl;
        }
        
    }
}
