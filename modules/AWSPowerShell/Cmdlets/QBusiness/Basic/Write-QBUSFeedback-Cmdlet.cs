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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Enables your end user to provide feedback on their Amazon Q Business generated chat
    /// responses.
    /// </summary>
    [Cmdlet("Write", "QBUSFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness PutFeedback API operation.", Operation = new[] {"PutFeedback"}, SelectReturnType = typeof(Amazon.QBusiness.Model.PutFeedbackResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.PutFeedbackResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.PutFeedbackResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteQBUSFeedbackCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the application associated with the feedback.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter MessageUsefulness_Comment
        /// <summary>
        /// <para>
        /// <para>A comment given by an end user on the usefulness of an AI-generated chat message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageUsefulness_Comment { get; set; }
        #endregion
        
        #region Parameter ConversationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the conversation the feedback is attached to.</para>
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
        public System.String ConversationId { get; set; }
        #endregion
        
        #region Parameter MessageCopiedAt
        /// <summary>
        /// <para>
        /// <para>The timestamp for when the feedback was recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? MessageCopiedAt { get; set; }
        #endregion
        
        #region Parameter MessageId
        /// <summary>
        /// <para>
        /// <para>The identifier of the chat message that the feedback was given for.</para>
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
        public System.String MessageId { get; set; }
        #endregion
        
        #region Parameter MessageUsefulness_Reason
        /// <summary>
        /// <para>
        /// <para>The reason for a usefulness rating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.MessageUsefulnessReason")]
        public Amazon.QBusiness.MessageUsefulnessReason MessageUsefulness_Reason { get; set; }
        #endregion
        
        #region Parameter MessageUsefulness_SubmittedAt
        /// <summary>
        /// <para>
        /// <para>The timestamp for when the feedback was submitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? MessageUsefulness_SubmittedAt { get; set; }
        #endregion
        
        #region Parameter MessageUsefulness_Usefulness
        /// <summary>
        /// <para>
        /// <para>The usefulness value assigned by an end user to a message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.MessageUsefulness")]
        public Amazon.QBusiness.MessageUsefulness MessageUsefulness_Usefulness { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user giving the feedback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.PutFeedbackResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-QBUSFeedback (PutFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.PutFeedbackResponse, WriteQBUSFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConversationId = this.ConversationId;
            #if MODULAR
            if (this.ConversationId == null && ParameterWasBound(nameof(this.ConversationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConversationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageCopiedAt = this.MessageCopiedAt;
            context.MessageId = this.MessageId;
            #if MODULAR
            if (this.MessageId == null && ParameterWasBound(nameof(this.MessageId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageUsefulness_Comment = this.MessageUsefulness_Comment;
            context.MessageUsefulness_Reason = this.MessageUsefulness_Reason;
            context.MessageUsefulness_SubmittedAt = this.MessageUsefulness_SubmittedAt;
            context.MessageUsefulness_Usefulness = this.MessageUsefulness_Usefulness;
            context.UserId = this.UserId;
            
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
            var request = new Amazon.QBusiness.Model.PutFeedbackRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ConversationId != null)
            {
                request.ConversationId = cmdletContext.ConversationId;
            }
            if (cmdletContext.MessageCopiedAt != null)
            {
                request.MessageCopiedAt = cmdletContext.MessageCopiedAt.Value;
            }
            if (cmdletContext.MessageId != null)
            {
                request.MessageId = cmdletContext.MessageId;
            }
            
             // populate MessageUsefulness
            var requestMessageUsefulnessIsNull = true;
            request.MessageUsefulness = new Amazon.QBusiness.Model.MessageUsefulnessFeedback();
            System.String requestMessageUsefulness_messageUsefulness_Comment = null;
            if (cmdletContext.MessageUsefulness_Comment != null)
            {
                requestMessageUsefulness_messageUsefulness_Comment = cmdletContext.MessageUsefulness_Comment;
            }
            if (requestMessageUsefulness_messageUsefulness_Comment != null)
            {
                request.MessageUsefulness.Comment = requestMessageUsefulness_messageUsefulness_Comment;
                requestMessageUsefulnessIsNull = false;
            }
            Amazon.QBusiness.MessageUsefulnessReason requestMessageUsefulness_messageUsefulness_Reason = null;
            if (cmdletContext.MessageUsefulness_Reason != null)
            {
                requestMessageUsefulness_messageUsefulness_Reason = cmdletContext.MessageUsefulness_Reason;
            }
            if (requestMessageUsefulness_messageUsefulness_Reason != null)
            {
                request.MessageUsefulness.Reason = requestMessageUsefulness_messageUsefulness_Reason;
                requestMessageUsefulnessIsNull = false;
            }
            System.DateTime? requestMessageUsefulness_messageUsefulness_SubmittedAt = null;
            if (cmdletContext.MessageUsefulness_SubmittedAt != null)
            {
                requestMessageUsefulness_messageUsefulness_SubmittedAt = cmdletContext.MessageUsefulness_SubmittedAt.Value;
            }
            if (requestMessageUsefulness_messageUsefulness_SubmittedAt != null)
            {
                request.MessageUsefulness.SubmittedAt = requestMessageUsefulness_messageUsefulness_SubmittedAt.Value;
                requestMessageUsefulnessIsNull = false;
            }
            Amazon.QBusiness.MessageUsefulness requestMessageUsefulness_messageUsefulness_Usefulness = null;
            if (cmdletContext.MessageUsefulness_Usefulness != null)
            {
                requestMessageUsefulness_messageUsefulness_Usefulness = cmdletContext.MessageUsefulness_Usefulness;
            }
            if (requestMessageUsefulness_messageUsefulness_Usefulness != null)
            {
                request.MessageUsefulness.Usefulness = requestMessageUsefulness_messageUsefulness_Usefulness;
                requestMessageUsefulnessIsNull = false;
            }
             // determine if request.MessageUsefulness should be set to null
            if (requestMessageUsefulnessIsNull)
            {
                request.MessageUsefulness = null;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.QBusiness.Model.PutFeedbackResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.PutFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "PutFeedback");
            try
            {
                return client.PutFeedbackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ConversationId { get; set; }
            public System.DateTime? MessageCopiedAt { get; set; }
            public System.String MessageId { get; set; }
            public System.String MessageUsefulness_Comment { get; set; }
            public Amazon.QBusiness.MessageUsefulnessReason MessageUsefulness_Reason { get; set; }
            public System.DateTime? MessageUsefulness_SubmittedAt { get; set; }
            public Amazon.QBusiness.MessageUsefulness MessageUsefulness_Usefulness { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.QBusiness.Model.PutFeedbackResponse, WriteQBUSFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
