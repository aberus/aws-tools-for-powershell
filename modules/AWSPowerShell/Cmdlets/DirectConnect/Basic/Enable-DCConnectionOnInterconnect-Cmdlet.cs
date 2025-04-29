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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// <note><para>
    /// Deprecated. Use <a>AllocateHostedConnection</a> instead.
    /// </para></note><para>
    /// Creates a hosted connection on an interconnect.
    /// </para><para>
    /// Allocates a VLAN number and a specified amount of bandwidth for use by a hosted connection
    /// on the specified interconnect.
    /// </para><note><para>
    /// Intended for use by Direct Connect Partners only.
    /// </para></note><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Enable", "DCConnectionOnInterconnect", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect AllocateConnectionOnInterconnect API operation.", Operation = new[] {"AllocateConnectionOnInterconnect"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse object containing multiple properties."
    )]
    [System.ObsoleteAttribute("Deprecated in favor of AllocateHostedConnection.")]
    public partial class EnableDCConnectionOnInterconnectCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Bandwidth
        /// <summary>
        /// <para>
        /// <para>The bandwidth of the connection. The possible values are 50Mbps, 100Mbps, 200Mbps,
        /// 300Mbps, 400Mbps, 500Mbps, 1Gbps, 2Gbps, 5Gbps, and 10Gbps. Note that only those Direct
        /// Connect Partners who have met specific requirements are allowed to create a 1Gbps,
        /// 2Gbps, 5Gbps or 10Gbps hosted connection.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Bandwidth { get; set; }
        #endregion
        
        #region Parameter ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the provisioned connection.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConnectionName { get; set; }
        #endregion
        
        #region Parameter InterconnectId
        /// <summary>
        /// <para>
        /// <para>The ID of the interconnect on which the connection will be provisioned.</para>
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
        public System.String InterconnectId { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account of the customer for whom the connection
        /// will be provisioned.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter Vlan
        /// <summary>
        /// <para>
        /// <para>The dedicated VLAN provisioned to the connection.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InterconnectId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCConnectionOnInterconnect (AllocateConnectionOnInterconnect)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse, EnableDCConnectionOnInterconnectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Bandwidth = this.Bandwidth;
            #if MODULAR
            if (this.Bandwidth == null && ParameterWasBound(nameof(this.Bandwidth)))
            {
                WriteWarning("You are passing $null as a value for parameter Bandwidth which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionName = this.ConnectionName;
            #if MODULAR
            if (this.ConnectionName == null && ParameterWasBound(nameof(this.ConnectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InterconnectId = this.InterconnectId;
            #if MODULAR
            if (this.InterconnectId == null && ParameterWasBound(nameof(this.InterconnectId)))
            {
                WriteWarning("You are passing $null as a value for parameter InterconnectId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwnerAccount = this.OwnerAccount;
            #if MODULAR
            if (this.OwnerAccount == null && ParameterWasBound(nameof(this.OwnerAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter OwnerAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Vlan = this.Vlan;
            #if MODULAR
            if (this.Vlan == null && ParameterWasBound(nameof(this.Vlan)))
            {
                WriteWarning("You are passing $null as a value for parameter Vlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectRequest();
            
            if (cmdletContext.Bandwidth != null)
            {
                request.Bandwidth = cmdletContext.Bandwidth;
            }
            if (cmdletContext.ConnectionName != null)
            {
                request.ConnectionName = cmdletContext.ConnectionName;
            }
            if (cmdletContext.InterconnectId != null)
            {
                request.InterconnectId = cmdletContext.InterconnectId;
            }
            if (cmdletContext.OwnerAccount != null)
            {
                request.OwnerAccount = cmdletContext.OwnerAccount;
            }
            if (cmdletContext.Vlan != null)
            {
                request.Vlan = cmdletContext.Vlan.Value;
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
        
        private Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AllocateConnectionOnInterconnect");
            try
            {
                return client.AllocateConnectionOnInterconnectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Bandwidth { get; set; }
            public System.String ConnectionName { get; set; }
            public System.String InterconnectId { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.Int32? Vlan { get; set; }
            public System.Func<Amazon.DirectConnect.Model.AllocateConnectionOnInterconnectResponse, EnableDCConnectionOnInterconnectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
