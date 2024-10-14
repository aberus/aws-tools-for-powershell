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
using Amazon.Chatbot;
using Amazon.Chatbot.Model;

namespace Amazon.PowerShell.Cmdlets.CHAT
{
    /// <summary>
    /// Updates a Slack channel configuration.
    /// </summary>
    [Cmdlet("Update", "CHATSlackChannelConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chatbot.Model.SlackChannelConfiguration")]
    [AWSCmdlet("Calls the AWS Chatbot UpdateSlackChannelConfiguration API operation.", Operation = new[] {"UpdateSlackChannelConfiguration"}, SelectReturnType = typeof(Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chatbot.Model.SlackChannelConfiguration or Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse",
        "This cmdlet returns an Amazon.Chatbot.Model.SlackChannelConfiguration object.",
        "The service call response (type Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCHATSlackChannelConfigurationCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChatConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the SlackChannelConfiguration to update.</para>
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
        public System.String ChatConfigurationArn { get; set; }
        #endregion
        
        #region Parameter GuardrailPolicyArn
        /// <summary>
        /// <para>
        /// <para>The list of IAM policy ARNs that are applied as channel guardrails. The AWS managed
        /// <c>AdministratorAccess</c> policy is applied by default if this is not set. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GuardrailPolicyArns")]
        public System.String[] GuardrailPolicyArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>A user-defined role that AWS Chatbot assumes. This is not the service-linked role.</para><para>For more information, see <a href="https://docs.aws.amazon.com/chatbot/latest/adminguide/chatbot-iam-policies.html">IAM
        /// policies for AWS Chatbot</a> in the <i> AWS Chatbot Administrator Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter LoggingLevel
        /// <summary>
        /// <para>
        /// <para>Logging levels include <c>ERROR</c>, <c>INFO</c>, or <c>NONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingLevel { get; set; }
        #endregion
        
        #region Parameter SlackChannelId
        /// <summary>
        /// <para>
        /// <para>The ID of the Slack channel.</para><para>To get this ID, open Slack, right click on the channel name in the left pane, then
        /// choose Copy Link. The channel ID is the 9-character string at the end of the URL.
        /// For example, ABCBBLZZZ. </para>
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
        public System.String SlackChannelId { get; set; }
        #endregion
        
        #region Parameter SlackChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the Slack channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SlackChannelName { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the SNS topics that deliver notifications to AWS
        /// Chatbot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnsTopicArns")]
        public System.String[] SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter UserAuthorizationRequired
        /// <summary>
        /// <para>
        /// <para>Enables use of a user role requirement in your chat configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UserAuthorizationRequired { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChatConfigurationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChatConfigurationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChatConfigurationArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChatConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHATSlackChannelConfiguration (UpdateSlackChannelConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse, UpdateCHATSlackChannelConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChatConfigurationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChatConfigurationArn = this.ChatConfigurationArn;
            #if MODULAR
            if (this.ChatConfigurationArn == null && ParameterWasBound(nameof(this.ChatConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChatConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GuardrailPolicyArn != null)
            {
                context.GuardrailPolicyArn = new List<System.String>(this.GuardrailPolicyArn);
            }
            context.IamRoleArn = this.IamRoleArn;
            context.LoggingLevel = this.LoggingLevel;
            context.SlackChannelId = this.SlackChannelId;
            #if MODULAR
            if (this.SlackChannelId == null && ParameterWasBound(nameof(this.SlackChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter SlackChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlackChannelName = this.SlackChannelName;
            if (this.SnsTopicArn != null)
            {
                context.SnsTopicArn = new List<System.String>(this.SnsTopicArn);
            }
            context.UserAuthorizationRequired = this.UserAuthorizationRequired;
            
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
            var request = new Amazon.Chatbot.Model.UpdateSlackChannelConfigurationRequest();
            
            if (cmdletContext.ChatConfigurationArn != null)
            {
                request.ChatConfigurationArn = cmdletContext.ChatConfigurationArn;
            }
            if (cmdletContext.GuardrailPolicyArn != null)
            {
                request.GuardrailPolicyArns = cmdletContext.GuardrailPolicyArn;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.LoggingLevel != null)
            {
                request.LoggingLevel = cmdletContext.LoggingLevel;
            }
            if (cmdletContext.SlackChannelId != null)
            {
                request.SlackChannelId = cmdletContext.SlackChannelId;
            }
            if (cmdletContext.SlackChannelName != null)
            {
                request.SlackChannelName = cmdletContext.SlackChannelName;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArns = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.UserAuthorizationRequired != null)
            {
                request.UserAuthorizationRequired = cmdletContext.UserAuthorizationRequired.Value;
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
        
        private Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.UpdateSlackChannelConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "UpdateSlackChannelConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateSlackChannelConfiguration(request);
                #elif CORECLR
                return client.UpdateSlackChannelConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ChatConfigurationArn { get; set; }
            public List<System.String> GuardrailPolicyArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String LoggingLevel { get; set; }
            public System.String SlackChannelId { get; set; }
            public System.String SlackChannelName { get; set; }
            public List<System.String> SnsTopicArn { get; set; }
            public System.Boolean? UserAuthorizationRequired { get; set; }
            public System.Func<Amazon.Chatbot.Model.UpdateSlackChannelConfigurationResponse, UpdateCHATSlackChannelConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelConfiguration;
        }
        
    }
}
