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
using Amazon.MigrationHubOrchestrator;
using Amazon.MigrationHubOrchestrator.Model;

namespace Amazon.PowerShell.Cmdlets.MHO
{
    /// <summary>
    /// List the steps in a workflow.
    /// </summary>
    [Cmdlet("Get", "MHOWorkflowStepList")]
    [OutputType("Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse")]
    [AWSCmdlet("Calls the AWS Migration Hub Orchestrator ListWorkflowSteps API operation.", Operation = new[] {"ListWorkflowSteps"}, SelectReturnType = typeof(Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse",
        "This cmdlet returns an Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse object containing multiple properties."
    )]
    public partial class GetMHOWorkflowStepListCmdlet : AmazonMigrationHubOrchestratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StepGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the step group.</para>
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
        public System.String StepGroupId { get; set; }
        #endregion
        
        #region Parameter WorkflowId
        /// <summary>
        /// <para>
        /// <para>The ID of the migration workflow.</para>
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
        public System.String WorkflowId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that can be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse, GetMHOWorkflowStepListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StepGroupId = this.StepGroupId;
            #if MODULAR
            if (this.StepGroupId == null && ParameterWasBound(nameof(this.StepGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter StepGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowId = this.WorkflowId;
            #if MODULAR
            if (this.WorkflowId == null && ParameterWasBound(nameof(this.WorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StepGroupId != null)
            {
                request.StepGroupId = cmdletContext.StepGroupId;
            }
            if (cmdletContext.WorkflowId != null)
            {
                request.WorkflowId = cmdletContext.WorkflowId;
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
        
        private Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse CallAWSServiceOperation(IAmazonMigrationHubOrchestrator client, Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Orchestrator", "ListWorkflowSteps");
            try
            {
                #if DESKTOP
                return client.ListWorkflowSteps(request);
                #elif CORECLR
                return client.ListWorkflowStepsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String StepGroupId { get; set; }
            public System.String WorkflowId { get; set; }
            public System.Func<Amazon.MigrationHubOrchestrator.Model.ListWorkflowStepsResponse, GetMHOWorkflowStepListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
