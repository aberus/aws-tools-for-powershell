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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// Deletes a channel message. Only admins can perform this action. Deletion makes messages
    /// inaccessible immediately. A background process deletes any revisions created by <c>UpdateChannelMessage</c>.
    /// 
    ///  <note><para>
    /// The <c>x-amz-chime-bearer</c> request header is mandatory. Use the ARN of the <c>AppInstanceUser</c>
    /// or <c>AppInstanceBot</c> that makes the API call as the value in the header.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "CHMMGChannelMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging DeleteChannelMessage API operation.", Operation = new[] {"DeleteChannelMessage"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageResponse))]
    [AWSCmdletOutput("None or Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCHMMGChannelMessageCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the channel.</para>
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
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter ChimeBearer
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceUser</c> or <c>AppInstanceBot</c> that makes the API
        /// call.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChimeBearer { get; set; }
        #endregion
        
        #region Parameter MessageId
        /// <summary>
        /// <para>
        /// <para>The ID of the message being deleted.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MessageId { get; set; }
        #endregion
        
        #region Parameter SubChannelId
        /// <summary>
        /// <para>
        /// <para>The ID of the SubChannel in the request.</para><note><para>Only required when deleting messages in a SubChannel that the user belongs to.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubChannelId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MessageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CHMMGChannelMessage (DeleteChannelMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageResponse, RemoveCHMMGChannelMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChimeBearer = this.ChimeBearer;
            #if MODULAR
            if (this.ChimeBearer == null && ParameterWasBound(nameof(this.ChimeBearer)))
            {
                WriteWarning("You are passing $null as a value for parameter ChimeBearer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageId = this.MessageId;
            #if MODULAR
            if (this.MessageId == null && ParameterWasBound(nameof(this.MessageId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubChannelId = this.SubChannelId;
            
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
            var request = new Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.ChimeBearer != null)
            {
                request.ChimeBearer = cmdletContext.ChimeBearer;
            }
            if (cmdletContext.MessageId != null)
            {
                request.MessageId = cmdletContext.MessageId;
            }
            if (cmdletContext.SubChannelId != null)
            {
                request.SubChannelId = cmdletContext.SubChannelId;
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
        
        private Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "DeleteChannelMessage");
            try
            {
                return client.DeleteChannelMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.String ChimeBearer { get; set; }
            public System.String MessageId { get; set; }
            public System.String SubChannelId { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.DeleteChannelMessageResponse, RemoveCHMMGChannelMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
