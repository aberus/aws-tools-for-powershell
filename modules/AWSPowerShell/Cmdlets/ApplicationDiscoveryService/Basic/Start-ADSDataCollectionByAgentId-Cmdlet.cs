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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Instructs the specified agents to start collecting data.
    /// </summary>
    [Cmdlet("Start", "ADSDataCollectionByAgentId", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationDiscoveryService.Model.AgentConfigurationStatus")]
    [AWSCmdlet("Calls the AWS Application Discovery Service StartDataCollectionByAgentIds API operation.", Operation = new[] {"StartDataCollectionByAgentIds"}, SelectReturnType = typeof(Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse))]
    [AWSCmdletOutput("Amazon.ApplicationDiscoveryService.Model.AgentConfigurationStatus or Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse",
        "This cmdlet returns a collection of Amazon.ApplicationDiscoveryService.Model.AgentConfigurationStatus objects.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartADSDataCollectionByAgentIdCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>The IDs of the agents from which to start collecting data. If you send a request to
        /// an agent ID that you do not have permission to contact, according to your Amazon Web
        /// Services account, the service does not throw an exception. Instead, it returns the
        /// error in the <i>Description</i> field. If you send a request to multiple agents and
        /// you do not have permission to contact some of those agents, the system does not throw
        /// an exception. Instead, the system shows <c>Failed</c> in the <i>Description</i> field.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AgentIds")]
        public System.String[] AgentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgentsConfigurationStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgentsConfigurationStatus";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ADSDataCollectionByAgentId (StartDataCollectionByAgentIds)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse, StartADSDataCollectionByAgentIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AgentId != null)
            {
                context.AgentId = new List<System.String>(this.AgentId);
            }
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsRequest();
            
            if (cmdletContext.AgentId != null)
            {
                request.AgentIds = cmdletContext.AgentId;
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
        
        private Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Application Discovery Service", "StartDataCollectionByAgentIds");
            try
            {
                return client.StartDataCollectionByAgentIdsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AgentId { get; set; }
            public System.Func<Amazon.ApplicationDiscoveryService.Model.StartDataCollectionByAgentIdsResponse, StartADSDataCollectionByAgentIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgentsConfigurationStatus;
        }
        
    }
}
