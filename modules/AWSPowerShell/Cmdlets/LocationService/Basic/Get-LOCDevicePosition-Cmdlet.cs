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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Retrieves a device's most recent position according to its sample time.
    /// 
    ///  <note><para>
    /// Device positions are deleted after 30 days.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "LOCDevicePosition")]
    [OutputType("Amazon.LocationService.Model.GetDevicePositionResponse")]
    [AWSCmdlet("Calls the Amazon Location Service GetDevicePosition API operation.", Operation = new[] {"GetDevicePosition"}, SelectReturnType = typeof(Amazon.LocationService.Model.GetDevicePositionResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.GetDevicePositionResponse",
        "This cmdlet returns an Amazon.LocationService.Model.GetDevicePositionResponse object containing multiple properties."
    )]
    public partial class GetLOCDevicePositionCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceId
        /// <summary>
        /// <para>
        /// <para>The device whose position you want to retrieve.</para>
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
        public System.String DeviceId { get; set; }
        #endregion
        
        #region Parameter TrackerName
        /// <summary>
        /// <para>
        /// <para>The tracker resource receiving the position update.</para>
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
        public System.String TrackerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.GetDevicePositionResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.GetDevicePositionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.GetDevicePositionResponse, GetLOCDevicePositionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeviceId = this.DeviceId;
            #if MODULAR
            if (this.DeviceId == null && ParameterWasBound(nameof(this.DeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrackerName = this.TrackerName;
            #if MODULAR
            if (this.TrackerName == null && ParameterWasBound(nameof(this.TrackerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.GetDevicePositionRequest();
            
            if (cmdletContext.DeviceId != null)
            {
                request.DeviceId = cmdletContext.DeviceId;
            }
            if (cmdletContext.TrackerName != null)
            {
                request.TrackerName = cmdletContext.TrackerName;
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
        
        private Amazon.LocationService.Model.GetDevicePositionResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.GetDevicePositionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "GetDevicePosition");
            try
            {
                #if DESKTOP
                return client.GetDevicePosition(request);
                #elif CORECLR
                return client.GetDevicePositionAsync(request).GetAwaiter().GetResult();
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
            public System.String DeviceId { get; set; }
            public System.String TrackerName { get; set; }
            public System.Func<Amazon.LocationService.Model.GetDevicePositionResponse, GetLOCDevicePositionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
