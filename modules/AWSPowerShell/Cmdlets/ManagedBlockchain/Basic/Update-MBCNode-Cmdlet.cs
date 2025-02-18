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
using Amazon.ManagedBlockchain;
using Amazon.ManagedBlockchain.Model;

namespace Amazon.PowerShell.Cmdlets.MBC
{
    /// <summary>
    /// Updates a node configuration with new parameters.
    /// 
    ///  
    /// <para>
    /// Applies only to Hyperledger Fabric.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MBCNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain UpdateNode API operation.", Operation = new[] {"UpdateNode"}, SelectReturnType = typeof(Amazon.ManagedBlockchain.Model.UpdateNodeResponse))]
    [AWSCmdletOutput("None or Amazon.ManagedBlockchain.Model.UpdateNodeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ManagedBlockchain.Model.UpdateNodeResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateMBCNodeCmdlet : AmazonManagedBlockchainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogPublishingConfiguration_Fabric
        /// <summary>
        /// <para>
        /// <para>Configuration properties for logging events associated with a node that is owned by
        /// a member of a Managed Blockchain network using the Hyperledger Fabric framework.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ManagedBlockchain.Model.NodeFabricLogPublishingConfiguration LogPublishingConfiguration_Fabric { get; set; }
        #endregion
        
        #region Parameter MemberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the member that owns the node.</para><para>Applies only to Hyperledger Fabric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemberId { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network that the node is on.</para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter NodeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the node.</para>
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
        public System.String NodeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchain.Model.UpdateNodeResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NodeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MBCNode (UpdateNode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchain.Model.UpdateNodeResponse, UpdateMBCNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogPublishingConfiguration_Fabric = this.LogPublishingConfiguration_Fabric;
            context.MemberId = this.MemberId;
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeId = this.NodeId;
            #if MODULAR
            if (this.NodeId == null && ParameterWasBound(nameof(this.NodeId)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ManagedBlockchain.Model.UpdateNodeRequest();
            
            
             // populate LogPublishingConfiguration
            var requestLogPublishingConfigurationIsNull = true;
            request.LogPublishingConfiguration = new Amazon.ManagedBlockchain.Model.NodeLogPublishingConfiguration();
            Amazon.ManagedBlockchain.Model.NodeFabricLogPublishingConfiguration requestLogPublishingConfiguration_logPublishingConfiguration_Fabric = null;
            if (cmdletContext.LogPublishingConfiguration_Fabric != null)
            {
                requestLogPublishingConfiguration_logPublishingConfiguration_Fabric = cmdletContext.LogPublishingConfiguration_Fabric;
            }
            if (requestLogPublishingConfiguration_logPublishingConfiguration_Fabric != null)
            {
                request.LogPublishingConfiguration.Fabric = requestLogPublishingConfiguration_logPublishingConfiguration_Fabric;
                requestLogPublishingConfigurationIsNull = false;
            }
             // determine if request.LogPublishingConfiguration should be set to null
            if (requestLogPublishingConfigurationIsNull)
            {
                request.LogPublishingConfiguration = null;
            }
            if (cmdletContext.MemberId != null)
            {
                request.MemberId = cmdletContext.MemberId;
            }
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            if (cmdletContext.NodeId != null)
            {
                request.NodeId = cmdletContext.NodeId;
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
        
        private Amazon.ManagedBlockchain.Model.UpdateNodeResponse CallAWSServiceOperation(IAmazonManagedBlockchain client, Amazon.ManagedBlockchain.Model.UpdateNodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain", "UpdateNode");
            try
            {
                return client.UpdateNodeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ManagedBlockchain.Model.NodeFabricLogPublishingConfiguration LogPublishingConfiguration_Fabric { get; set; }
            public System.String MemberId { get; set; }
            public System.String NetworkId { get; set; }
            public System.String NodeId { get; set; }
            public System.Func<Amazon.ManagedBlockchain.Model.UpdateNodeResponse, UpdateMBCNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
