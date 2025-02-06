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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Provides information about the specified Call Analytics job.
    /// 
    ///  
    /// <para>
    /// To view the job's status, refer to <c>CallAnalyticsJobStatus</c>. If the status is
    /// <c>COMPLETED</c>, the job is finished. You can find your completed transcript at the
    /// URI specified in <c>TranscriptFileUri</c>. If the status is <c>FAILED</c>, <c>FailureReason</c>
    /// provides details on why your transcription job failed.
    /// </para><para>
    /// If you enabled personally identifiable information (PII) redaction, the redacted transcript
    /// appears at the location specified in <c>RedactedTranscriptFileUri</c>.
    /// </para><para>
    /// If you chose to redact the audio in your media file, you can find your redacted media
    /// file at the location specified in <c>RedactedMediaFileUri</c>.
    /// </para><para>
    /// To get a list of your Call Analytics jobs, use the operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TRSCallAnalyticsJob")]
    [OutputType("Amazon.TranscribeService.Model.CallAnalyticsJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service GetCallAnalyticsJob API operation.", Operation = new[] {"GetCallAnalyticsJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CallAnalyticsJob or Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CallAnalyticsJob object.",
        "The service call response (type Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTRSCallAnalyticsJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CallAnalyticsJobName
        /// <summary>
        /// <para>
        /// <para>The name of the Call Analytics job you want information about. Job names are case
        /// sensitive.</para>
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
        public System.String CallAnalyticsJobName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CallAnalyticsJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CallAnalyticsJob";
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
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse, GetTRSCallAnalyticsJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallAnalyticsJobName = this.CallAnalyticsJobName;
            #if MODULAR
            if (this.CallAnalyticsJobName == null && ParameterWasBound(nameof(this.CallAnalyticsJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter CallAnalyticsJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TranscribeService.Model.GetCallAnalyticsJobRequest();
            
            if (cmdletContext.CallAnalyticsJobName != null)
            {
                request.CallAnalyticsJobName = cmdletContext.CallAnalyticsJobName;
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
        
        private Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.GetCallAnalyticsJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "GetCallAnalyticsJob");
            try
            {
                #if DESKTOP
                return client.GetCallAnalyticsJob(request);
                #elif CORECLR
                return client.GetCallAnalyticsJobAsync(request).GetAwaiter().GetResult();
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
            public System.String CallAnalyticsJobName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.GetCallAnalyticsJobResponse, GetTRSCallAnalyticsJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CallAnalyticsJob;
        }
        
    }
}
