/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Cancels one or more Capacity Reservation Fleets. When you cancel a Capacity Reservation
    /// Fleet, the following happens:
    /// 
    ///  <ul><li><para>
    /// The Capacity Reservation Fleet's status changes to <c>cancelled</c>.
    /// </para></li><li><para>
    /// The individual Capacity Reservations in the Fleet are cancelled. Instances running
    /// in the Capacity Reservations at the time of cancelling the Fleet continue to run in
    /// shared capacity.
    /// </para></li><li><para>
    /// The Fleet stops creating new Capacity Reservations.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Stop", "EC2CapacityReservationFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CancelCapacityReservationFleetsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CancelCapacityReservationFleets API operation.", Operation = new[] {"CancelCapacityReservationFleets"}, SelectReturnType = typeof(Amazon.EC2.Model.CancelCapacityReservationFleetsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CancelCapacityReservationFleetsResponse",
        "This cmdlet returns an Amazon.EC2.Model.CancelCapacityReservationFleetsResponse object containing multiple properties."
    )]
    public partial class StopEC2CapacityReservationFleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityReservationFleetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Capacity Reservation Fleets to cancel.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CapacityReservationFleetIds")]
        public System.String[] CapacityReservationFleetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CancelCapacityReservationFleetsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CancelCapacityReservationFleetsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityReservationFleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-EC2CapacityReservationFleet (CancelCapacityReservationFleets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CancelCapacityReservationFleetsResponse, StopEC2CapacityReservationFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CapacityReservationFleetId != null)
            {
                context.CapacityReservationFleetId = new List<System.String>(this.CapacityReservationFleetId);
            }
            #if MODULAR
            if (this.CapacityReservationFleetId == null && ParameterWasBound(nameof(this.CapacityReservationFleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityReservationFleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CancelCapacityReservationFleetsRequest();
            
            if (cmdletContext.CapacityReservationFleetId != null)
            {
                request.CapacityReservationFleetIds = cmdletContext.CapacityReservationFleetId;
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
        
        private Amazon.EC2.Model.CancelCapacityReservationFleetsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CancelCapacityReservationFleetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CancelCapacityReservationFleets");
            try
            {
                #if DESKTOP
                return client.CancelCapacityReservationFleets(request);
                #elif CORECLR
                return client.CancelCapacityReservationFleetsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CapacityReservationFleetId { get; set; }
            public System.Func<Amazon.EC2.Model.CancelCapacityReservationFleetsResponse, StopEC2CapacityReservationFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
