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
using Amazon.CodeGuruSecurity;
using Amazon.CodeGuruSecurity.Model;

namespace Amazon.PowerShell.Cmdlets.CGS
{
    /// <summary>
    /// Generates a pre-signed URL, request headers used to upload a code resource, and code
    /// artifact identifier for the uploaded resource.
    /// 
    ///  
    /// <para>
    /// You can upload your code resource to the URL with the request headers using any HTTP
    /// client.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CGSUploadUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse")]
    [AWSCmdlet("Calls the Amazon CodeGuru Security CreateUploadUrl API operation.", Operation = new[] {"CreateUploadUrl"}, SelectReturnType = typeof(Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse",
        "This cmdlet returns an Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse object containing multiple properties."
    )]
    public partial class NewCGSUploadUrlCmdlet : AmazonCodeGuruSecurityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ScanName
        /// <summary>
        /// <para>
        /// <para>The name of the scan that will use the uploaded resource. CodeGuru Security uses the
        /// unique scan name to track revisions across multiple scans of the same resource. Use
        /// this <c>scanName</c> when you call <c>CreateScan</c> on the code resource you upload
        /// to this URL.</para>
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
        public System.String ScanName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGSUploadUrl (CreateUploadUrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse, NewCGSUploadUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ScanName = this.ScanName;
            #if MODULAR
            if (this.ScanName == null && ParameterWasBound(nameof(this.ScanName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeGuruSecurity.Model.CreateUploadUrlRequest();
            
            if (cmdletContext.ScanName != null)
            {
                request.ScanName = cmdletContext.ScanName;
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
        
        private Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse CallAWSServiceOperation(IAmazonCodeGuruSecurity client, Amazon.CodeGuruSecurity.Model.CreateUploadUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Security", "CreateUploadUrl");
            try
            {
                #if DESKTOP
                return client.CreateUploadUrl(request);
                #elif CORECLR
                return client.CreateUploadUrlAsync(request).GetAwaiter().GetResult();
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
            public System.String ScanName { get; set; }
            public System.Func<Amazon.CodeGuruSecurity.Model.CreateUploadUrlResponse, NewCGSUploadUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
