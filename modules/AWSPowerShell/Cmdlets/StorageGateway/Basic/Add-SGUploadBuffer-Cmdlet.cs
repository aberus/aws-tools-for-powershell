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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Configures one or more gateway local disks as upload buffer for a specified gateway.
    /// This operation is supported for the stored volume, cached volume, and tape gateway
    /// types.
    /// 
    ///  
    /// <para>
    /// In the request, you specify the gateway Amazon Resource Name (ARN) to which you want
    /// to add upload buffer, and one or more disk IDs that you want to configure as upload
    /// buffer.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "SGUploadBuffer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway AddUploadBuffer API operation.", Operation = new[] {"AddUploadBuffer"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.AddUploadBufferResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.AddUploadBufferResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.AddUploadBufferResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddSGUploadBufferCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DiskId
        /// <summary>
        /// <para>
        /// <para>An array of strings that identify disks that are to be configured as working storage.
        /// Each string has a minimum length of 1 and maximum length of 300. You can get the disk
        /// IDs from the <a>ListLocalDisks</a> API.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DiskIds")]
        public System.String[] DiskId { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.AddUploadBufferResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.AddUploadBufferResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayARN";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DiskId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SGUploadBuffer (AddUploadBuffer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.AddUploadBufferResponse, AddSGUploadBufferCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DiskId != null)
            {
                context.DiskId = new List<System.String>(this.DiskId);
            }
            #if MODULAR
            if (this.DiskId == null && ParameterWasBound(nameof(this.DiskId)))
            {
                WriteWarning("You are passing $null as a value for parameter DiskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.AddUploadBufferRequest();
            
            if (cmdletContext.DiskId != null)
            {
                request.DiskIds = cmdletContext.DiskId;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
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
        
        private Amazon.StorageGateway.Model.AddUploadBufferResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.AddUploadBufferRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "AddUploadBuffer");
            try
            {
                return client.AddUploadBufferAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> DiskId { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.AddUploadBufferResponse, AddSGUploadBufferCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayARN;
        }
        
    }
}
