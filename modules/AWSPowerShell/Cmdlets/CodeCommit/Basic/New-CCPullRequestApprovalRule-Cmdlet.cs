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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Creates an approval rule for a pull request.
    /// </summary>
    [Cmdlet("New", "CCPullRequestApprovalRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.ApprovalRule")]
    [AWSCmdlet("Calls the AWS CodeCommit CreatePullRequestApprovalRule API operation.", Operation = new[] {"CreatePullRequestApprovalRule"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.ApprovalRule or Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.ApprovalRule object.",
        "The service call response (type Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCCPullRequestApprovalRuleCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApprovalRuleContent
        /// <summary>
        /// <para>
        /// <para>The content of the approval rule, including the number of approvals needed and the
        /// structure of an approval pool defined for approvals, if any. For more information
        /// about approval pools, see the CodeCommit User Guide.</para><note><para>When you create the content of the approval rule, you can specify approvers in an
        /// approval pool in one of two ways:</para><ul><li><para><b>CodeCommitApprovers</b>: This option only requires an Amazon Web Services account
        /// and a resource. It can be used for both IAM users and federated access users whose
        /// name matches the provided resource name. This is a very powerful option that offers
        /// a great deal of flexibility. For example, if you specify the Amazon Web Services account
        /// <i>123456789012</i> and <i>Mary_Major</i>, all of the following would be counted as
        /// approvals coming from that user:</para><ul><li><para>An IAM user in the account (arn:aws:iam::<i>123456789012</i>:user/<i>Mary_Major</i>)</para></li><li><para>A federated user identified in IAM as Mary_Major (arn:aws:sts::<i>123456789012</i>:federated-user/<i>Mary_Major</i>)</para></li></ul><para>This option does not recognize an active session of someone assuming the role of CodeCommitReview
        /// with a role session name of <i>Mary_Major</i> (arn:aws:sts::<i>123456789012</i>:assumed-role/CodeCommitReview/<i>Mary_Major</i>)
        /// unless you include a wildcard (*Mary_Major).</para></li><li><para><b>Fully qualified ARN</b>: This option allows you to specify the fully qualified
        /// Amazon Resource Name (ARN) of the IAM user or role. </para></li></ul><para>For more information about IAM ARNs, wildcards, and formats, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html">IAM
        /// Identifiers</a> in the <i>IAM User Guide</i>.</para></note>
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
        public System.String ApprovalRuleContent { get; set; }
        #endregion
        
        #region Parameter ApprovalRuleName
        /// <summary>
        /// <para>
        /// <para>The name for the approval rule.</para>
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
        public System.String ApprovalRuleName { get; set; }
        #endregion
        
        #region Parameter PullRequestId
        /// <summary>
        /// <para>
        /// <para>The system-generated ID of the pull request for which you want to create the approval
        /// rule.</para>
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
        public System.String PullRequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApprovalRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApprovalRule";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApprovalRuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCPullRequestApprovalRule (CreatePullRequestApprovalRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse, NewCCPullRequestApprovalRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApprovalRuleContent = this.ApprovalRuleContent;
            #if MODULAR
            if (this.ApprovalRuleContent == null && ParameterWasBound(nameof(this.ApprovalRuleContent)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalRuleContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApprovalRuleName = this.ApprovalRuleName;
            #if MODULAR
            if (this.ApprovalRuleName == null && ParameterWasBound(nameof(this.ApprovalRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PullRequestId = this.PullRequestId;
            #if MODULAR
            if (this.PullRequestId == null && ParameterWasBound(nameof(this.PullRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter PullRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleRequest();
            
            if (cmdletContext.ApprovalRuleContent != null)
            {
                request.ApprovalRuleContent = cmdletContext.ApprovalRuleContent;
            }
            if (cmdletContext.ApprovalRuleName != null)
            {
                request.ApprovalRuleName = cmdletContext.ApprovalRuleName;
            }
            if (cmdletContext.PullRequestId != null)
            {
                request.PullRequestId = cmdletContext.PullRequestId;
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
        
        private Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "CreatePullRequestApprovalRule");
            try
            {
                return client.CreatePullRequestApprovalRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApprovalRuleContent { get; set; }
            public System.String ApprovalRuleName { get; set; }
            public System.String PullRequestId { get; set; }
            public System.Func<Amazon.CodeCommit.Model.CreatePullRequestApprovalRuleResponse, NewCCPullRequestApprovalRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApprovalRule;
        }
        
    }
}
