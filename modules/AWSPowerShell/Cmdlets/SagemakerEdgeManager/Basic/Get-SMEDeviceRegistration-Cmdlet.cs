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
using Amazon.SagemakerEdgeManager;
using Amazon.SagemakerEdgeManager.Model;

namespace Amazon.PowerShell.Cmdlets.SME
{
    /// <summary>
    /// Use to check if a device is registered with SageMaker Edge Manager.
    /// </summary>
    [Cmdlet("Get", "SMEDeviceRegistration")]
    [OutputType("Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse")]
    [AWSCmdlet("Calls the Amazon Sagemaker Edge Manager GetDeviceRegistration API operation.", Operation = new[] {"GetDeviceRegistration"}, SelectReturnType = typeof(Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse))]
    [AWSCmdletOutput("Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse",
        "This cmdlet returns an Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse object containing multiple properties."
    )]
    public partial class GetSMEDeviceRegistrationCmdlet : AmazonSagemakerEdgeManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceFleetName
        /// <summary>
        /// <para>
        /// <para>The name of the fleet that the device belongs to.</para>
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
        public System.String DeviceFleetName { get; set; }
        #endregion
        
        #region Parameter DeviceName
        /// <summary>
        /// <para>
        /// <para>The unique name of the device you want to get the registration status from.</para>
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
        public System.String DeviceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse).
        /// Specifying the name of a property of type Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse, GetSMEDeviceRegistrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeviceFleetName = this.DeviceFleetName;
            #if MODULAR
            if (this.DeviceFleetName == null && ParameterWasBound(nameof(this.DeviceFleetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceFleetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceName = this.DeviceName;
            #if MODULAR
            if (this.DeviceName == null && ParameterWasBound(nameof(this.DeviceName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationRequest();
            
            if (cmdletContext.DeviceFleetName != null)
            {
                request.DeviceFleetName = cmdletContext.DeviceFleetName;
            }
            if (cmdletContext.DeviceName != null)
            {
                request.DeviceName = cmdletContext.DeviceName;
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
        
        private Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse CallAWSServiceOperation(IAmazonSagemakerEdgeManager client, Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Sagemaker Edge Manager", "GetDeviceRegistration");
            try
            {
                #if DESKTOP
                return client.GetDeviceRegistration(request);
                #elif CORECLR
                return client.GetDeviceRegistrationAsync(request).GetAwaiter().GetResult();
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
            public System.String DeviceFleetName { get; set; }
            public System.String DeviceName { get; set; }
            public System.Func<Amazon.SagemakerEdgeManager.Model.GetDeviceRegistrationResponse, GetSMEDeviceRegistrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
