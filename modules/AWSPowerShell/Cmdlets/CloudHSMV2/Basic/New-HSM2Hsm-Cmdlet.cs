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
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;

namespace Amazon.PowerShell.Cmdlets.HSM2
{
    /// <summary>
    /// Creates a new hardware security module (HSM) in the specified CloudHSM cluster.
    /// 
    ///  
    /// <para><b>Cross-account use:</b> No. You cannot perform this operation on an CloudHSM cluster
    /// in a different Amazon Web Service account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "HSM2Hsm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudHSMV2.Model.Hsm")]
    [AWSCmdlet("Calls the AWS CloudHSM V2 CreateHsm API operation.", Operation = new[] {"CreateHsm"}, SelectReturnType = typeof(Amazon.CloudHSMV2.Model.CreateHsmResponse))]
    [AWSCmdletOutput("Amazon.CloudHSMV2.Model.Hsm or Amazon.CloudHSMV2.Model.CreateHsmResponse",
        "This cmdlet returns an Amazon.CloudHSMV2.Model.Hsm object.",
        "The service call response (type Amazon.CloudHSMV2.Model.CreateHsmResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewHSM2HsmCmdlet : AmazonCloudHSMV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where you are creating the HSM. To find the cluster's Availability
        /// Zones, use <a>DescribeClusters</a>.</para>
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
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier (ID) of the HSM's cluster. To find the cluster ID, use <a>DescribeClusters</a>.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>The HSM's IP address. If you specify an IP address, use an available address from
        /// the subnet that maps to the Availability Zone where you are creating the HSM. If you
        /// don't specify an IP address, one is chosen for you from that subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IpAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Hsm'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSMV2.Model.CreateHsmResponse).
        /// Specifying the name of a property of type Amazon.CloudHSMV2.Model.CreateHsmResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Hsm";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-HSM2Hsm (CreateHsm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudHSMV2.Model.CreateHsmResponse, NewHSM2HsmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            #if MODULAR
            if (this.AvailabilityZone == null && ParameterWasBound(nameof(this.AvailabilityZone)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpAddress = this.IpAddress;
            
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
            var request = new Amazon.CloudHSMV2.Model.CreateHsmRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddress = cmdletContext.IpAddress;
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
        
        private Amazon.CloudHSMV2.Model.CreateHsmResponse CallAWSServiceOperation(IAmazonCloudHSMV2 client, Amazon.CloudHSMV2.Model.CreateHsmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM V2", "CreateHsm");
            try
            {
                return client.CreateHsmAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String ClusterId { get; set; }
            public System.String IpAddress { get; set; }
            public System.Func<Amazon.CloudHSMV2.Model.CreateHsmResponse, NewHSM2HsmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Hsm;
        }
        
    }
}
