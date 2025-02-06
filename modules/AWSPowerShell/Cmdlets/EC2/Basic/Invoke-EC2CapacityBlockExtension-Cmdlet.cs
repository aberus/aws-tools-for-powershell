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
    /// Purchase the Capacity Block extension for use with your account. You must specify
    /// the ID of the Capacity Block extension offering you are purchasing.
    /// </summary>
    [Cmdlet("Invoke", "EC2CapacityBlockExtension", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CapacityBlockExtension")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) PurchaseCapacityBlockExtension API operation.", Operation = new[] {"PurchaseCapacityBlockExtension"}, SelectReturnType = typeof(Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CapacityBlockExtension or Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.CapacityBlockExtension objects.",
        "The service call response (type Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeEC2CapacityBlockExtensionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityBlockExtensionOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Block extension offering to purchase.</para>
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
        public System.String CapacityBlockExtensionOfferingId { get; set; }
        #endregion
        
        #region Parameter CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity reservation to be extended.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityBlockExtensions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityBlockExtensions";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-EC2CapacityBlockExtension (PurchaseCapacityBlockExtension)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse, InvokeEC2CapacityBlockExtensionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityBlockExtensionOfferingId = this.CapacityBlockExtensionOfferingId;
            #if MODULAR
            if (this.CapacityBlockExtensionOfferingId == null && ParameterWasBound(nameof(this.CapacityBlockExtensionOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityBlockExtensionOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapacityReservationId = this.CapacityReservationId;
            #if MODULAR
            if (this.CapacityReservationId == null && ParameterWasBound(nameof(this.CapacityReservationId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityReservationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.PurchaseCapacityBlockExtensionRequest();
            
            if (cmdletContext.CapacityBlockExtensionOfferingId != null)
            {
                request.CapacityBlockExtensionOfferingId = cmdletContext.CapacityBlockExtensionOfferingId;
            }
            if (cmdletContext.CapacityReservationId != null)
            {
                request.CapacityReservationId = cmdletContext.CapacityReservationId;
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
        
        private Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.PurchaseCapacityBlockExtensionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "PurchaseCapacityBlockExtension");
            try
            {
                #if DESKTOP
                return client.PurchaseCapacityBlockExtension(request);
                #elif CORECLR
                return client.PurchaseCapacityBlockExtensionAsync(request).GetAwaiter().GetResult();
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
            public System.String CapacityBlockExtensionOfferingId { get; set; }
            public System.String CapacityReservationId { get; set; }
            public System.Func<Amazon.EC2.Model.PurchaseCapacityBlockExtensionResponse, InvokeEC2CapacityBlockExtensionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityBlockExtensions;
        }
        
    }
}
