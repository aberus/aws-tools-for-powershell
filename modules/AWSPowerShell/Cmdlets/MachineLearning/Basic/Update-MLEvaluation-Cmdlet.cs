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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Updates the <c>EvaluationName</c> of an <c>Evaluation</c>.
    /// 
    ///  
    /// <para>
    /// You can use the <c>GetEvaluation</c> operation to view the contents of the updated
    /// data element.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MLEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Machine Learning UpdateEvaluation API operation.", Operation = new[] {"UpdateEvaluation"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.UpdateEvaluationResponse))]
    [AWSCmdletOutput("System.String or Amazon.MachineLearning.Model.UpdateEvaluationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MachineLearning.Model.UpdateEvaluationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMLEvaluationCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EvaluationId
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <c>Evaluation</c> during creation.</para>
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
        public System.String EvaluationId { get; set; }
        #endregion
        
        #region Parameter EvaluationName
        /// <summary>
        /// <para>
        /// <para>A new user-supplied name or description of the <c>Evaluation</c> that will replace
        /// the current content. </para>
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
        [Alias("Name")]
        public System.String EvaluationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EvaluationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.UpdateEvaluationResponse).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.UpdateEvaluationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EvaluationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EvaluationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MLEvaluation (UpdateEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.UpdateEvaluationResponse, UpdateMLEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EvaluationId = this.EvaluationId;
            #if MODULAR
            if (this.EvaluationId == null && ParameterWasBound(nameof(this.EvaluationId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationName = this.EvaluationName;
            #if MODULAR
            if (this.EvaluationName == null && ParameterWasBound(nameof(this.EvaluationName)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MachineLearning.Model.UpdateEvaluationRequest();
            
            if (cmdletContext.EvaluationId != null)
            {
                request.EvaluationId = cmdletContext.EvaluationId;
            }
            if (cmdletContext.EvaluationName != null)
            {
                request.EvaluationName = cmdletContext.EvaluationName;
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
        
        private Amazon.MachineLearning.Model.UpdateEvaluationResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.UpdateEvaluationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "UpdateEvaluation");
            try
            {
                return client.UpdateEvaluationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EvaluationId { get; set; }
            public System.String EvaluationName { get; set; }
            public System.Func<Amazon.MachineLearning.Model.UpdateEvaluationResponse, UpdateMLEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EvaluationId;
        }
        
    }
}
