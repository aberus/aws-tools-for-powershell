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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Disassociates a target network from the specified Client VPN endpoint. When you disassociate
    /// the last target network from a Client VPN, the following happens:
    /// 
    ///  <ul><li><para>
    /// The route that was automatically added for the VPC is deleted
    /// </para></li><li><para>
    /// All active client connections are terminated
    /// </para></li><li><para>
    /// New client connections are disallowed
    /// </para></li><li><para>
    /// The Client VPN endpoint's status changes to <c>pending-associate</c></para></li></ul>
    /// </summary>
    [Cmdlet("Unregister", "EC2ClientVpnTargetNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DisassociateClientVpnTargetNetwork API operation.", Operation = new[] {"DisassociateClientVpnTargetNetwork"}, SelectReturnType = typeof(Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse",
        "This cmdlet returns an Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse object containing multiple properties."
    )]
    public partial class UnregisterEC2ClientVpnTargetNetworkCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the target network association.</para>
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
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint from which to disassociate the target network.</para>
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
        public System.String ClientVpnEndpointId { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2ClientVpnTargetNetwork (DisassociateClientVpnTargetNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse, UnregisterEC2ClientVpnTargetNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociationId = this.AssociationId;
            #if MODULAR
            if (this.AssociationId == null && ParameterWasBound(nameof(this.AssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            #if MODULAR
            if (this.ClientVpnEndpointId == null && ParameterWasBound(nameof(this.ClientVpnEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientVpnEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            
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
            var request = new Amazon.EC2.Model.DisassociateClientVpnTargetNetworkRequest();
            
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
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
        
        private Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DisassociateClientVpnTargetNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DisassociateClientVpnTargetNetwork");
            try
            {
                return client.DisassociateClientVpnTargetNetworkAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssociationId { get; set; }
            public System.String ClientVpnEndpointId { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Func<Amazon.EC2.Model.DisassociateClientVpnTargetNetworkResponse, UnregisterEC2ClientVpnTargetNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
