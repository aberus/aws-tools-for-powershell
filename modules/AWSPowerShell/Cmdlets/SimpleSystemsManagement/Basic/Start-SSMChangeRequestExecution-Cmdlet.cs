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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Creates a change request for Change Manager. The Automation runbooks specified in
    /// the change request run only after all required approvals for the change request have
    /// been received.
    /// </summary>
    [Cmdlet("Start", "SSMChangeRequestExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager StartChangeRequestExecution API operation.", Operation = new[] {"StartChangeRequestExecution"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartSSMChangeRequestExecutionCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoApprove
        /// <summary>
        /// <para>
        /// <para>Indicates whether the change request can be approved automatically without the need
        /// for manual approvals.</para><para>If <c>AutoApprovable</c> is enabled in a change template, then setting <c>AutoApprove</c>
        /// to <c>true</c> in <c>StartChangeRequestExecution</c> creates a change request that
        /// bypasses approver review.</para><note><para>Change Calendar restrictions are not bypassed in this scenario. If the state of an
        /// associated calendar is <c>CLOSED</c>, change freeze approvers must still grant permission
        /// for this change request to run. If they don't, the change won't be processed until
        /// the calendar state is again <c>OPEN</c>. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoApprove { get; set; }
        #endregion
        
        #region Parameter ChangeDetail
        /// <summary>
        /// <para>
        /// <para>User-provided details about the change. If no details are provided, content specified
        /// in the <b>Template information</b> section of the associated change template is added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChangeDetails")]
        public System.String ChangeDetail { get; set; }
        #endregion
        
        #region Parameter ChangeRequestName
        /// <summary>
        /// <para>
        /// <para>The name of the change request associated with the runbook workflow to be run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChangeRequestName { get; set; }
        #endregion
        
        #region Parameter DocumentName
        /// <summary>
        /// <para>
        /// <para>The name of the change template document to run during the runbook workflow.</para>
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
        public System.String DocumentName { get; set; }
        #endregion
        
        #region Parameter DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the change template document to run during the runbook workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A key-value map of parameters that match the declared parameters in the change template
        /// document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter Runbook
        /// <summary>
        /// <para>
        /// <para>Information about the Automation runbooks that are run during the runbook workflow.</para><note><para>The Automation runbooks specified for the runbook workflow can't run until all required
        /// approvals for the change request have been received.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Runbooks")]
        public Amazon.SimpleSystemsManagement.Model.Runbook[] Runbook { get; set; }
        #endregion
        
        #region Parameter ScheduledEndTime
        /// <summary>
        /// <para>
        /// <para>The time that the requester expects the runbook workflow related to the change request
        /// to complete. The time is an estimate only that the requester provides for reviewers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledEndTime { get; set; }
        #endregion
        
        #region Parameter ScheduledTime
        /// <summary>
        /// <para>
        /// <para>The date and time specified in the change request to run the Automation runbooks.</para><note><para>The Automation runbooks specified for the runbook workflow can't run until all required
        /// approvals for the change request have been received.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you assign to a resource. You can specify a maximum of five
        /// tags for a change request. Tags enable you to categorize a resource in different ways,
        /// such as by purpose, owner, or environment. For example, you might want to tag a change
        /// request to identify an environment or target Amazon Web Services Region. In this case,
        /// you could specify the following key-value pairs:</para><ul><li><para><c>Key=Environment,Value=Production</c></para></li><li><para><c>Key=Region,Value=us-east-2</c></para></li></ul><note><para>The <c>Array Members</c> maximum value is reported as 1000. This number includes capacity
        /// reserved for internal operations. When calling the <c>StartChangeRequestExecution</c>
        /// action, you can specify a maximum of 5 tags. You can, however, use the <a>AddTagsToResource</a>
        /// action to add up to a total of 50 tags to an existing change request configuration.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The user-provided idempotency token. The token must be unique, is case insensitive,
        /// enforces the UUID format, and can't be reused.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutomationExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutomationExecutionId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DocumentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SSMChangeRequestExecution (StartChangeRequestExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse, StartSSMChangeRequestExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoApprove = this.AutoApprove;
            context.ChangeDetail = this.ChangeDetail;
            context.ChangeRequestName = this.ChangeRequestName;
            context.ClientToken = this.ClientToken;
            context.DocumentName = this.DocumentName;
            #if MODULAR
            if (this.DocumentName == null && ParameterWasBound(nameof(this.DocumentName)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocumentVersion = this.DocumentVersion;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Parameter.Add((String)hashKey, valueSet);
                }
            }
            if (this.Runbook != null)
            {
                context.Runbook = new List<Amazon.SimpleSystemsManagement.Model.Runbook>(this.Runbook);
            }
            #if MODULAR
            if (this.Runbook == null && ParameterWasBound(nameof(this.Runbook)))
            {
                WriteWarning("You are passing $null as a value for parameter Runbook which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledEndTime = this.ScheduledEndTime;
            context.ScheduledTime = this.ScheduledTime;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
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
            var request = new Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionRequest();
            
            if (cmdletContext.AutoApprove != null)
            {
                request.AutoApprove = cmdletContext.AutoApprove.Value;
            }
            if (cmdletContext.ChangeDetail != null)
            {
                request.ChangeDetails = cmdletContext.ChangeDetail;
            }
            if (cmdletContext.ChangeRequestName != null)
            {
                request.ChangeRequestName = cmdletContext.ChangeRequestName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DocumentName != null)
            {
                request.DocumentName = cmdletContext.DocumentName;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.Runbook != null)
            {
                request.Runbooks = cmdletContext.Runbook;
            }
            if (cmdletContext.ScheduledEndTime != null)
            {
                request.ScheduledEndTime = cmdletContext.ScheduledEndTime.Value;
            }
            if (cmdletContext.ScheduledTime != null)
            {
                request.ScheduledTime = cmdletContext.ScheduledTime.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "StartChangeRequestExecution");
            try
            {
                return client.StartChangeRequestExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutoApprove { get; set; }
            public System.String ChangeDetail { get; set; }
            public System.String ChangeRequestName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DocumentName { get; set; }
            public System.String DocumentVersion { get; set; }
            public Dictionary<System.String, List<System.String>> Parameter { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Runbook> Runbook { get; set; }
            public System.DateTime? ScheduledEndTime { get; set; }
            public System.DateTime? ScheduledTime { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.StartChangeRequestExecutionResponse, StartSSMChangeRequestExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutomationExecutionId;
        }
        
    }
}
