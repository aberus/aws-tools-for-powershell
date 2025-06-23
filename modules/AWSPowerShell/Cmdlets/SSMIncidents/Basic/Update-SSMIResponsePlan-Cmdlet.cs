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
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Updates the specified response plan.
    /// </summary>
    [Cmdlet("Update", "SSMIResponsePlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager UpdateResponsePlan API operation.", Operation = new[] {"UpdateResponsePlan"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.UpdateResponsePlanResponse))]
    [AWSCmdletOutput("None or Amazon.SSMIncidents.Model.UpdateResponsePlanResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSMIncidents.Model.UpdateResponsePlanResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSMIResponsePlanCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions that this response plan takes at the beginning of an incident.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public Amazon.SSMIncidents.Model.Action[] Action { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the response plan.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ChatChannel_ChatbotSn
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS targets that Chatbot uses to notify the chat channel of updates to
        /// an incident. You can also make updates to the incident through the chat channel by
        /// using the Amazon SNS topics. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChatChannel_ChatbotSns")]
        public System.String[] ChatChannel_ChatbotSn { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The long format name of the response plan. The display name can't contain spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ChatChannel_Empty
        /// <summary>
        /// <para>
        /// <para>Used to remove the chat channel from an incident record or response plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SSMIncidents.Model.EmptyChatChannel ChatChannel_Empty { get; set; }
        #endregion
        
        #region Parameter Engagement
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the contacts and escalation plans that the response
        /// plan engages during an incident.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Engagements")]
        public System.String[] Engagement { get; set; }
        #endregion
        
        #region Parameter IncidentTemplateDedupeString
        /// <summary>
        /// <para>
        /// <para>The string Incident Manager uses to prevent duplicate incidents from being created
        /// by the same incident in the same account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncidentTemplateDedupeString { get; set; }
        #endregion
        
        #region Parameter IncidentTemplateImpact
        /// <summary>
        /// <para>
        /// <para>Defines the impact to the customers. Providing an impact overwrites the impact provided
        /// by a response plan.</para><para><b>Supported impact codes</b></para><ul><li><para><c>1</c> - Critical</para></li><li><para><c>2</c> - High</para></li><li><para><c>3</c> - Medium</para></li><li><para><c>4</c> - Low</para></li><li><para><c>5</c> - No Impact</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IncidentTemplateImpact { get; set; }
        #endregion
        
        #region Parameter IncidentTemplateNotificationTarget
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS targets that are notified when updates are made to an incident.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncidentTemplateNotificationTargets")]
        public Amazon.SSMIncidents.Model.NotificationTargetItem[] IncidentTemplateNotificationTarget { get; set; }
        #endregion
        
        #region Parameter IncidentTemplateSummary
        /// <summary>
        /// <para>
        /// <para>A brief summary of the incident. This typically contains what has happened, what's
        /// currently happening, and next steps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncidentTemplateSummary { get; set; }
        #endregion
        
        #region Parameter IncidentTemplateTag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the template. When the <c>StartIncident</c> API action is called,
        /// Incident Manager assigns the tags specified in the template to the incident. To call
        /// this action, you must also have permission to call the <c>TagResource</c> API action
        /// for the incident record resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncidentTemplateTags")]
        public System.Collections.Hashtable IncidentTemplateTag { get; set; }
        #endregion
        
        #region Parameter IncidentTemplateTitle
        /// <summary>
        /// <para>
        /// <para>The short format name of the incident. The title can't contain spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncidentTemplateTitle { get; set; }
        #endregion
        
        #region Parameter Integration
        /// <summary>
        /// <para>
        /// <para>Information about third-party services integrated into the response plan.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Integrations")]
        public Amazon.SSMIncidents.Model.Integration[] Integration { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token ensuring that the operation is called only once with the specified details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.UpdateResponsePlanResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMIResponsePlan (UpdateResponsePlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.UpdateResponsePlanResponse, UpdateSSMIResponsePlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<Amazon.SSMIncidents.Model.Action>(this.Action);
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ChatChannel_ChatbotSn != null)
            {
                context.ChatChannel_ChatbotSn = new List<System.String>(this.ChatChannel_ChatbotSn);
            }
            context.ChatChannel_Empty = this.ChatChannel_Empty;
            context.ClientToken = this.ClientToken;
            context.DisplayName = this.DisplayName;
            if (this.Engagement != null)
            {
                context.Engagement = new List<System.String>(this.Engagement);
            }
            context.IncidentTemplateDedupeString = this.IncidentTemplateDedupeString;
            context.IncidentTemplateImpact = this.IncidentTemplateImpact;
            if (this.IncidentTemplateNotificationTarget != null)
            {
                context.IncidentTemplateNotificationTarget = new List<Amazon.SSMIncidents.Model.NotificationTargetItem>(this.IncidentTemplateNotificationTarget);
            }
            context.IncidentTemplateSummary = this.IncidentTemplateSummary;
            if (this.IncidentTemplateTag != null)
            {
                context.IncidentTemplateTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IncidentTemplateTag.Keys)
                {
                    context.IncidentTemplateTag.Add((String)hashKey, (System.String)(this.IncidentTemplateTag[hashKey]));
                }
            }
            context.IncidentTemplateTitle = this.IncidentTemplateTitle;
            if (this.Integration != null)
            {
                context.Integration = new List<Amazon.SSMIncidents.Model.Integration>(this.Integration);
            }
            
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
            var request = new Amazon.SSMIncidents.Model.UpdateResponsePlanRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate ChatChannel
            var requestChatChannelIsNull = true;
            request.ChatChannel = new Amazon.SSMIncidents.Model.ChatChannel();
            List<System.String> requestChatChannel_chatChannel_ChatbotSn = null;
            if (cmdletContext.ChatChannel_ChatbotSn != null)
            {
                requestChatChannel_chatChannel_ChatbotSn = cmdletContext.ChatChannel_ChatbotSn;
            }
            if (requestChatChannel_chatChannel_ChatbotSn != null)
            {
                request.ChatChannel.ChatbotSns = requestChatChannel_chatChannel_ChatbotSn;
                requestChatChannelIsNull = false;
            }
            Amazon.SSMIncidents.Model.EmptyChatChannel requestChatChannel_chatChannel_Empty = null;
            if (cmdletContext.ChatChannel_Empty != null)
            {
                requestChatChannel_chatChannel_Empty = cmdletContext.ChatChannel_Empty;
            }
            if (requestChatChannel_chatChannel_Empty != null)
            {
                request.ChatChannel.Empty = requestChatChannel_chatChannel_Empty;
                requestChatChannelIsNull = false;
            }
             // determine if request.ChatChannel should be set to null
            if (requestChatChannelIsNull)
            {
                request.ChatChannel = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Engagement != null)
            {
                request.Engagements = cmdletContext.Engagement;
            }
            if (cmdletContext.IncidentTemplateDedupeString != null)
            {
                request.IncidentTemplateDedupeString = cmdletContext.IncidentTemplateDedupeString;
            }
            if (cmdletContext.IncidentTemplateImpact != null)
            {
                request.IncidentTemplateImpact = cmdletContext.IncidentTemplateImpact.Value;
            }
            if (cmdletContext.IncidentTemplateNotificationTarget != null)
            {
                request.IncidentTemplateNotificationTargets = cmdletContext.IncidentTemplateNotificationTarget;
            }
            if (cmdletContext.IncidentTemplateSummary != null)
            {
                request.IncidentTemplateSummary = cmdletContext.IncidentTemplateSummary;
            }
            if (cmdletContext.IncidentTemplateTag != null)
            {
                request.IncidentTemplateTags = cmdletContext.IncidentTemplateTag;
            }
            if (cmdletContext.IncidentTemplateTitle != null)
            {
                request.IncidentTemplateTitle = cmdletContext.IncidentTemplateTitle;
            }
            if (cmdletContext.Integration != null)
            {
                request.Integrations = cmdletContext.Integration;
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
        
        private Amazon.SSMIncidents.Model.UpdateResponsePlanResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.UpdateResponsePlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "UpdateResponsePlan");
            try
            {
                return client.UpdateResponsePlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SSMIncidents.Model.Action> Action { get; set; }
            public System.String Arn { get; set; }
            public List<System.String> ChatChannel_ChatbotSn { get; set; }
            public Amazon.SSMIncidents.Model.EmptyChatChannel ChatChannel_Empty { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DisplayName { get; set; }
            public List<System.String> Engagement { get; set; }
            public System.String IncidentTemplateDedupeString { get; set; }
            public System.Int32? IncidentTemplateImpact { get; set; }
            public List<Amazon.SSMIncidents.Model.NotificationTargetItem> IncidentTemplateNotificationTarget { get; set; }
            public System.String IncidentTemplateSummary { get; set; }
            public Dictionary<System.String, System.String> IncidentTemplateTag { get; set; }
            public System.String IncidentTemplateTitle { get; set; }
            public List<Amazon.SSMIncidents.Model.Integration> Integration { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.UpdateResponsePlanResponse, UpdateSSMIResponsePlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
