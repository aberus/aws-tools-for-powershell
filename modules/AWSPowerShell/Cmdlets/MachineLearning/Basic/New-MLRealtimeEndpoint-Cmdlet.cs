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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Creates a real-time endpoint for the <c>MLModel</c>. The endpoint contains the URI
    /// of the <c>MLModel</c>; that is, the location to send real-time prediction requests
    /// for the specified <c>MLModel</c>.
    /// </summary>
    [Cmdlet("New", "MLRealtimeEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Machine Learning CreateRealtimeEndpoint API operation.", Operation = new[] {"CreateRealtimeEndpoint"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse))]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse",
        "This cmdlet returns an Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse object containing multiple properties."
    )]
    public partial class NewMLRealtimeEndpointCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MLModelId
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <c>MLModel</c> during creation.</para>
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
        [Alias("ModelId")]
        public System.String MLModelId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MLModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLRealtimeEndpoint (CreateRealtimeEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse, NewMLRealtimeEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MLModelId = this.MLModelId;
            #if MODULAR
            if (this.MLModelId == null && ParameterWasBound(nameof(this.MLModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter MLModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MachineLearning.Model.CreateRealtimeEndpointRequest();
            
            if (cmdletContext.MLModelId != null)
            {
                request.MLModelId = cmdletContext.MLModelId;
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
        
        private Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateRealtimeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateRealtimeEndpoint");
            try
            {
                return client.CreateRealtimeEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MLModelId { get; set; }
            public System.Func<Amazon.MachineLearning.Model.CreateRealtimeEndpointResponse, NewMLRealtimeEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
