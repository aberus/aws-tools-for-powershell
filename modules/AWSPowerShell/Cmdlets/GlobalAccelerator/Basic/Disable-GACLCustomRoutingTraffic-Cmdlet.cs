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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Specify the Amazon EC2 instance (destination) IP addresses and ports for a VPC subnet
    /// endpoint that cannot receive traffic for a custom routing accelerator. You can deny
    /// traffic to all destinations in the VPC endpoint, or deny traffic to a specified list
    /// of destination IP addresses and ports. Note that you cannot specify IP addresses or
    /// ports outside of the range that you configured for the endpoint group.
    /// 
    ///  
    /// <para>
    /// After you make changes, you can verify that the updates are complete by checking the
    /// status of your accelerator: the status changes from IN_PROGRESS to DEPLOYED.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "GACLCustomRoutingTraffic", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Global Accelerator DenyCustomRoutingTraffic API operation.", Operation = new[] {"DenyCustomRoutingTraffic"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficResponse))]
    [AWSCmdletOutput("None or Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficResponse) be returned by specifying '-Select *'."
    )]
    public partial class DisableGACLCustomRoutingTrafficCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DenyAllTrafficToEndpoint
        /// <summary>
        /// <para>
        /// <para>Indicates whether all destination IP addresses and ports for a specified VPC subnet
        /// endpoint <i>cannot</i> receive traffic from a custom routing accelerator. The value
        /// is TRUE or FALSE. </para><para>When set to TRUE, <i>no</i> destinations in the custom routing VPC subnet can receive
        /// traffic. Note that you cannot specify destination IP addresses and ports when the
        /// value is set to TRUE.</para><para>When set to FALSE (or not specified), you <i>must</i> specify a list of destination
        /// IP addresses that cannot receive traffic. A list of ports is optional. If you don't
        /// specify a list of ports, the ports that can accept traffic is the same as the ports
        /// configured for the endpoint group.</para><para>The default value is FALSE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DenyAllTrafficToEndpoint { get; set; }
        #endregion
        
        #region Parameter DestinationAddress
        /// <summary>
        /// <para>
        /// <para>A list of specific Amazon EC2 instance IP addresses (destination addresses) in a subnet
        /// that you want to prevent from receiving traffic. The IP addresses must be a subset
        /// of the IP addresses allowed for the VPC subnet associated with the endpoint group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationAddresses")]
        public System.String[] DestinationAddress { get; set; }
        #endregion
        
        #region Parameter DestinationPort
        /// <summary>
        /// <para>
        /// <para>A list of specific Amazon EC2 instance ports (destination ports) in a subnet endpoint
        /// that you want to prevent from receiving traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationPorts")]
        public System.Int32[] DestinationPort { get; set; }
        #endregion
        
        #region Parameter EndpointGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the endpoint group.</para>
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
        public System.String EndpointGroupArn { get; set; }
        #endregion
        
        #region Parameter EndpointId
        /// <summary>
        /// <para>
        /// <para>An ID for the endpoint. For custom routing accelerators, this is the virtual private
        /// cloud (VPC) subnet ID.</para>
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
        public System.String EndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-GACLCustomRoutingTraffic (DenyCustomRoutingTraffic)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficResponse, DisableGACLCustomRoutingTrafficCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DenyAllTrafficToEndpoint = this.DenyAllTrafficToEndpoint;
            if (this.DestinationAddress != null)
            {
                context.DestinationAddress = new List<System.String>(this.DestinationAddress);
            }
            if (this.DestinationPort != null)
            {
                context.DestinationPort = new List<System.Int32>(this.DestinationPort);
            }
            context.EndpointGroupArn = this.EndpointGroupArn;
            #if MODULAR
            if (this.EndpointGroupArn == null && ParameterWasBound(nameof(this.EndpointGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointId = this.EndpointId;
            #if MODULAR
            if (this.EndpointId == null && ParameterWasBound(nameof(this.EndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficRequest();
            
            if (cmdletContext.DenyAllTrafficToEndpoint != null)
            {
                request.DenyAllTrafficToEndpoint = cmdletContext.DenyAllTrafficToEndpoint.Value;
            }
            if (cmdletContext.DestinationAddress != null)
            {
                request.DestinationAddresses = cmdletContext.DestinationAddress;
            }
            if (cmdletContext.DestinationPort != null)
            {
                request.DestinationPorts = cmdletContext.DestinationPort;
            }
            if (cmdletContext.EndpointGroupArn != null)
            {
                request.EndpointGroupArn = cmdletContext.EndpointGroupArn;
            }
            if (cmdletContext.EndpointId != null)
            {
                request.EndpointId = cmdletContext.EndpointId;
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
        
        private Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "DenyCustomRoutingTraffic");
            try
            {
                #if DESKTOP
                return client.DenyCustomRoutingTraffic(request);
                #elif CORECLR
                return client.DenyCustomRoutingTrafficAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DenyAllTrafficToEndpoint { get; set; }
            public List<System.String> DestinationAddress { get; set; }
            public List<System.Int32> DestinationPort { get; set; }
            public System.String EndpointGroupArn { get; set; }
            public System.String EndpointId { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.DenyCustomRoutingTrafficResponse, DisableGACLCustomRoutingTrafficCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
