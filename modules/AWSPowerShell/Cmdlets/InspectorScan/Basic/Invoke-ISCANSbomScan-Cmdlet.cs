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
using Amazon.InspectorScan;
using Amazon.InspectorScan.Model;

namespace Amazon.PowerShell.Cmdlets.ISCAN
{
    /// <summary>
    /// Scans a provided CycloneDX 1.5 SBOM and reports on any vulnerabilities discovered
    /// in that SBOM. You can generate compatible SBOMs for your resources using the <a href="">Amazon
    /// Inspector SBOM generator</a>.
    /// </summary>
    [Cmdlet("Invoke", "ISCANSbomScan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Runtime.Documents.Document")]
    [AWSCmdlet("Calls the Inspector Scan ScanSbom API operation.", Operation = new[] {"ScanSbom"}, SelectReturnType = typeof(Amazon.InspectorScan.Model.ScanSbomResponse))]
    [AWSCmdletOutput("Amazon.Runtime.Documents.Document or Amazon.InspectorScan.Model.ScanSbomResponse",
        "This cmdlet returns an Amazon.Runtime.Documents.Document object.",
        "The service call response (type Amazon.InspectorScan.Model.ScanSbomResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeISCANSbomScanCmdlet : AmazonInspectorScanClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>The output format for the vulnerability report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.InspectorScan.OutputFormat")]
        public Amazon.InspectorScan.OutputFormat OutputFormat { get; set; }
        #endregion
        
        #region Parameter Sbom
        /// <summary>
        /// <para>
        /// <para>The JSON file for the SBOM you want to scan. The SBOM must be in CycloneDX 1.5 format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Management.Automation.PSObject Sbom { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Sbom'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.InspectorScan.Model.ScanSbomResponse).
        /// Specifying the name of a property of type Amazon.InspectorScan.Model.ScanSbomResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Sbom";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutputFormat), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-ISCANSbomScan (ScanSbom)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.InspectorScan.Model.ScanSbomResponse, InvokeISCANSbomScanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OutputFormat = this.OutputFormat;
            context.Sbom = this.Sbom;
            #if MODULAR
            if (this.Sbom == null && ParameterWasBound(nameof(this.Sbom)))
            {
                WriteWarning("You are passing $null as a value for parameter Sbom which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.InspectorScan.Model.ScanSbomRequest();
            
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
            }
            if (cmdletContext.Sbom != null)
            {
                request.Sbom = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Sbom);
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
        
        private Amazon.InspectorScan.Model.ScanSbomResponse CallAWSServiceOperation(IAmazonInspectorScan client, Amazon.InspectorScan.Model.ScanSbomRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector Scan", "ScanSbom");
            try
            {
                return client.ScanSbomAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.InspectorScan.OutputFormat OutputFormat { get; set; }
            public System.Management.Automation.PSObject Sbom { get; set; }
            public System.Func<Amazon.InspectorScan.Model.ScanSbomResponse, InvokeISCANSbomScanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Sbom;
        }
        
    }
}
