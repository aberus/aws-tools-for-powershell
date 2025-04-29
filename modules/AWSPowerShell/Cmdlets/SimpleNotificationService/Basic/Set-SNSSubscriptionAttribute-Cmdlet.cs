/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Allows a subscription owner to set an attribute of the subscription to a new value.
    /// </summary>
    [Cmdlet("Set", "SNSSubscriptionAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) SetSubscriptionAttributes API operation.", Operation = new[] {"SetSubscriptionAttributes"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetSNSSubscriptionAttributeCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A map of attributes with their corresponding values.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that this action uses:</para><ul><li><para><c>DeliveryPolicy</c> – The policy that defines how Amazon SNS retries failed deliveries
        /// to HTTP/S endpoints.</para></li><li><para><c>FilterPolicy</c> – The simple JSON object that lets your subscriber receive only
        /// a subset of messages, rather than receiving every message published to the topic.</para></li><li><para><c>FilterPolicyScope</c> – This attribute lets you choose the filtering scope by
        /// using one of the following string value types:</para><ul><li><para><c>MessageAttributes</c> (default) – The filter is applied on the message attributes.</para></li><li><para><c>MessageBody</c> – The filter is applied on the message body.</para></li></ul></li><li><para><c>RawMessageDelivery</c> – When set to <c>true</c>, enables raw message delivery
        /// to Amazon SQS or HTTP/S endpoints. This eliminates the need for the endpoints to process
        /// JSON formatting, which is otherwise created for Amazon SNS metadata.</para></li><li><para><c>RedrivePolicy</c> – When specified, sends undeliverable messages to the specified
        /// Amazon SQS dead-letter queue. Messages that can't be delivered due to client errors
        /// (for example, when the subscribed endpoint is unreachable) or server errors (for example,
        /// when the service that powers the subscribed endpoint becomes unavailable) are held
        /// in the dead-letter queue for further analysis or reprocessing.</para></li></ul><para>The following attribute applies only to Amazon Data Firehose delivery stream subscriptions:</para><ul><li><para><c>SubscriptionRoleArn</c> – The ARN of the IAM role that has the following:</para><ul><li><para>Permission to write to the Firehose delivery stream</para></li><li><para>Amazon SNS listed as a trusted entity</para></li></ul><para>Specifying a valid ARN for this attribute is required for Firehose delivery stream
        /// subscriptions. For more information, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-firehose-as-subscriber.html">Fanout
        /// to Firehose delivery streams</a> in the <i>Amazon SNS Developer Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter AttributeValue
        /// <summary>
        /// <para>
        /// <para>The new value for the attribute in JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AttributeValue { get; set; }
        #endregion
        
        #region Parameter SubscriptionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the subscription to modify.</para>
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
        public System.String SubscriptionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SNSSubscriptionAttribute (SetSubscriptionAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesResponse, SetSNSSubscriptionAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttributeName = this.AttributeName;
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttributeValue = this.AttributeValue;
            context.SubscriptionArn = this.SubscriptionArn;
            #if MODULAR
            if (this.SubscriptionArn == null && ParameterWasBound(nameof(this.SubscriptionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.AttributeValue != null)
            {
                request.AttributeValue = cmdletContext.AttributeValue;
            }
            if (cmdletContext.SubscriptionArn != null)
            {
                request.SubscriptionArn = cmdletContext.SubscriptionArn;
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
        
        private Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "SetSubscriptionAttributes");
            try
            {
                return client.SetSubscriptionAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttributeName { get; set; }
            public System.String AttributeValue { get; set; }
            public System.String SubscriptionArn { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.SetSubscriptionAttributesResponse, SetSNSSubscriptionAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
