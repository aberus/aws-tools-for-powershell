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
using Amazon.Amplify;
using Amazon.Amplify.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMP
{
    /// <summary>
    /// Starts a new job for a branch of an Amplify app.
    /// </summary>
    [Cmdlet("Start", "AMPJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.JobSummary")]
    [AWSCmdlet("Calls the AWS Amplify StartJob API operation.", Operation = new[] {"StartJob"}, SelectReturnType = typeof(Amazon.Amplify.Model.StartJobResponse))]
    [AWSCmdletOutput("Amazon.Amplify.Model.JobSummary or Amazon.Amplify.Model.StartJobResponse",
        "This cmdlet returns an Amazon.Amplify.Model.JobSummary object.",
        "The service call response (type Amazon.Amplify.Model.StartJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartAMPJobCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID for an Amplify app. </para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch to use for the job. </para>
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
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter CommitId
        /// <summary>
        /// <para>
        /// <para> The commit ID from a third-party repository provider for the job. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitId { get; set; }
        #endregion
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para> The commit message from a third-party repository provider for the job. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter CommitTime
        /// <summary>
        /// <para>
        /// <para> The commit date and time for the job. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CommitTime { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique ID for an existing job. This is required if the value of <c>jobType</c>
        /// is <c>RETRY</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter JobReason
        /// <summary>
        /// <para>
        /// <para>A descriptive reason for starting the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobReason { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>Describes the type for the job. The job type <c>RELEASE</c> starts a new job with
        /// the latest change from the specified branch. This value is available only for apps
        /// that are connected to a repository. </para><para>The job type <c>RETRY</c> retries an existing job. If the job type value is <c>RETRY</c>,
        /// the <c>jobId</c> is also required. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Amplify.JobType")]
        public Amazon.Amplify.JobType JobType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Amplify.Model.StartJobResponse).
        /// Specifying the name of a property of type Amazon.Amplify.Model.StartJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobSummary";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BranchName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AMPJob (StartJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Amplify.Model.StartJobResponse, StartAMPJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BranchName = this.BranchName;
            #if MODULAR
            if (this.BranchName == null && ParameterWasBound(nameof(this.BranchName)))
            {
                WriteWarning("You are passing $null as a value for parameter BranchName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CommitId = this.CommitId;
            context.CommitMessage = this.CommitMessage;
            context.CommitTime = this.CommitTime;
            context.JobId = this.JobId;
            context.JobReason = this.JobReason;
            context.JobType = this.JobType;
            #if MODULAR
            if (this.JobType == null && ParameterWasBound(nameof(this.JobType)))
            {
                WriteWarning("You are passing $null as a value for parameter JobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Amplify.Model.StartJobRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.BranchName != null)
            {
                request.BranchName = cmdletContext.BranchName;
            }
            if (cmdletContext.CommitId != null)
            {
                request.CommitId = cmdletContext.CommitId;
            }
            if (cmdletContext.CommitMessage != null)
            {
                request.CommitMessage = cmdletContext.CommitMessage;
            }
            if (cmdletContext.CommitTime != null)
            {
                request.CommitTime = cmdletContext.CommitTime.Value;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.JobReason != null)
            {
                request.JobReason = cmdletContext.JobReason;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
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
        
        private Amazon.Amplify.Model.StartJobResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.StartJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "StartJob");
            try
            {
                return client.StartJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String BranchName { get; set; }
            public System.String CommitId { get; set; }
            public System.String CommitMessage { get; set; }
            public System.DateTime? CommitTime { get; set; }
            public System.String JobId { get; set; }
            public System.String JobReason { get; set; }
            public Amazon.Amplify.JobType JobType { get; set; }
            public System.Func<Amazon.Amplify.Model.StartJobResponse, StartAMPJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobSummary;
        }
        
    }
}
