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
using Amazon.IoTFleetWise;
using Amazon.IoTFleetWise.Model;

namespace Amazon.PowerShell.Cmdlets.IFW
{
    /// <summary>
    /// Updates a group, or batch, of vehicles.
    /// 
    ///  <note><para>
    ///  You must specify a decoder manifest and a vehicle model (model manifest) for each
    /// vehicle. 
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/update-vehicles-cli.html">Update
    /// multiple vehicles (AWS CLI)</a> in the <i>Amazon Web Services IoT FleetWise Developer
    /// Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "IFWUpdateVehicle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse")]
    [AWSCmdlet("Calls the AWS IoT FleetWise BatchUpdateVehicle API operation.", Operation = new[] {"BatchUpdateVehicle"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse))]
    [AWSCmdletOutput("Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse",
        "This cmdlet returns an Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse object containing multiple properties."
    )]
    public partial class NewIFWUpdateVehicleCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Vehicle
        /// <summary>
        /// <para>
        /// <para> A list of information about the vehicles to update. For more information, see the
        /// API data type.</para>
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
        [Alias("Vehicles")]
        public Amazon.IoTFleetWise.Model.UpdateVehicleRequestItem[] Vehicle { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse).
        /// Specifying the name of a property of type Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Vehicle), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IFWUpdateVehicle (BatchUpdateVehicle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse, NewIFWUpdateVehicleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Vehicle != null)
            {
                context.Vehicle = new List<Amazon.IoTFleetWise.Model.UpdateVehicleRequestItem>(this.Vehicle);
            }
            #if MODULAR
            if (this.Vehicle == null && ParameterWasBound(nameof(this.Vehicle)))
            {
                WriteWarning("You are passing $null as a value for parameter Vehicle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTFleetWise.Model.BatchUpdateVehicleRequest();
            
            if (cmdletContext.Vehicle != null)
            {
                request.Vehicles = cmdletContext.Vehicle;
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
        
        private Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.BatchUpdateVehicleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "BatchUpdateVehicle");
            try
            {
                #if DESKTOP
                return client.BatchUpdateVehicle(request);
                #elif CORECLR
                return client.BatchUpdateVehicleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoTFleetWise.Model.UpdateVehicleRequestItem> Vehicle { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.BatchUpdateVehicleResponse, NewIFWUpdateVehicleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
