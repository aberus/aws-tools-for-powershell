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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Cancels a pending request to assign billing of the unused capacity of a Capacity Reservation
    /// to a consumer account, or revokes a request that has already been accepted. For more
    /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/assign-billing.html">Billing
    /// assignment for shared Amazon EC2 Capacity Reservations</a>.
    /// </summary>
    [Cmdlet("Unregister", "EC2CapacityReservationBillingOwner", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DisassociateCapacityReservationBillingOwner API operation.", Operation = new[] {"DisassociateCapacityReservationBillingOwner"}, SelectReturnType = typeof(Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UnregisterEC2CapacityReservationBillingOwnerCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation.</para>
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
        public System.String CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter UnusedReservationBillingOwnerId
        /// <summary>
        /// <para>
        /// <para>The ID of the consumer account to which the request was sent.</para>
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
        public System.String UnusedReservationBillingOwnerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2CapacityReservationBillingOwner (DisassociateCapacityReservationBillingOwner)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse, UnregisterEC2CapacityReservationBillingOwnerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityReservationId = this.CapacityReservationId;
            #if MODULAR
            if (this.CapacityReservationId == null && ParameterWasBound(nameof(this.CapacityReservationId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityReservationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UnusedReservationBillingOwnerId = this.UnusedReservationBillingOwnerId;
            #if MODULAR
            if (this.UnusedReservationBillingOwnerId == null && ParameterWasBound(nameof(this.UnusedReservationBillingOwnerId)))
            {
                WriteWarning("You are passing $null as a value for parameter UnusedReservationBillingOwnerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerRequest();
            
            if (cmdletContext.CapacityReservationId != null)
            {
                request.CapacityReservationId = cmdletContext.CapacityReservationId;
            }
            if (cmdletContext.UnusedReservationBillingOwnerId != null)
            {
                request.UnusedReservationBillingOwnerId = cmdletContext.UnusedReservationBillingOwnerId;
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
        
        private Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DisassociateCapacityReservationBillingOwner");
            try
            {
                #if DESKTOP
                return client.DisassociateCapacityReservationBillingOwner(request);
                #elif CORECLR
                return client.DisassociateCapacityReservationBillingOwnerAsync(request).GetAwaiter().GetResult();
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
            public System.String CapacityReservationId { get; set; }
            public System.String UnusedReservationBillingOwnerId { get; set; }
            public System.Func<Amazon.EC2.Model.DisassociateCapacityReservationBillingOwnerResponse, UnregisterEC2CapacityReservationBillingOwnerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
