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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// Deletes a what-if forecast export created using the <a>CreateWhatIfForecastExport</a>
    /// operation. You can delete only what-if forecast exports that have a status of <c>ACTIVE</c>
    /// or <c>CREATE_FAILED</c>. To get the status, use the <a>DescribeWhatIfForecastExport</a>
    /// operation.
    /// </summary>
    [Cmdlet("Remove", "FRCWhatIfForecastExport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Forecast Service DeleteWhatIfForecastExport API operation.", Operation = new[] {"DeleteWhatIfForecastExport"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DeleteWhatIfForecastExportResponse))]
    [AWSCmdletOutput("None or Amazon.ForecastService.Model.DeleteWhatIfForecastExportResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ForecastService.Model.DeleteWhatIfForecastExportResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveFRCWhatIfForecastExportCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WhatIfForecastExportArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the what-if forecast export that you want to delete.</para>
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
        public System.String WhatIfForecastExportArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DeleteWhatIfForecastExportResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WhatIfForecastExportArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FRCWhatIfForecastExport (DeleteWhatIfForecastExport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DeleteWhatIfForecastExportResponse, RemoveFRCWhatIfForecastExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.WhatIfForecastExportArn = this.WhatIfForecastExportArn;
            #if MODULAR
            if (this.WhatIfForecastExportArn == null && ParameterWasBound(nameof(this.WhatIfForecastExportArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfForecastExportArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.DeleteWhatIfForecastExportRequest();
            
            if (cmdletContext.WhatIfForecastExportArn != null)
            {
                request.WhatIfForecastExportArn = cmdletContext.WhatIfForecastExportArn;
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
        
        private Amazon.ForecastService.Model.DeleteWhatIfForecastExportResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DeleteWhatIfForecastExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DeleteWhatIfForecastExport");
            try
            {
                return client.DeleteWhatIfForecastExportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String WhatIfForecastExportArn { get; set; }
            public System.Func<Amazon.ForecastService.Model.DeleteWhatIfForecastExportResponse, RemoveFRCWhatIfForecastExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
