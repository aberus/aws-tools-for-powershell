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
using Amazon.CodeGuruProfiler;
using Amazon.CodeGuruProfiler.Model;

namespace Amazon.PowerShell.Cmdlets.CGP
{
    /// <summary>
    /// Returns a list of <a href="https://docs.aws.amazon.com/codeguru/latest/profiler-api/API_Recommendation.html"><c>Recommendation</c></a> objects that contain recommendations for a profiling group
    /// for a given time period. A list of <a href="https://docs.aws.amazon.com/codeguru/latest/profiler-api/API_Anomaly.html"><c>Anomaly</c></a> objects that contains details about anomalies detected in the
    /// profiling group for the same time period is also returned.
    /// </summary>
    [Cmdlet("Get", "CGPRecommendation")]
    [OutputType("Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse")]
    [AWSCmdlet("Calls the Amazon CodeGuru Profiler GetRecommendations API operation.", Operation = new[] {"GetRecommendations"}, SelectReturnType = typeof(Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse",
        "This cmdlet returns an Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCGPRecommendationCmdlet : AmazonCodeGuruProfilerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para> The start time of the profile to get analysis data about. You must specify <c>startTime</c>
        /// and <c>endTime</c>. This is specified using the ISO 8601 format. For example, 2020-06-01T13:15:02.001Z
        /// represents 1 millisecond past June 1, 2020 1:15:02 PM UTC. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para> The language used to provide analysis. Specify using a string that is one of the
        /// following <c>BCP 47</c> language codes. </para><ul><li><para><c>de-DE</c> - German, Germany </para></li><li><para><c>en-GB</c> - English, United Kingdom </para></li><li><para><c>en-US</c> - English, United States </para></li><li><para><c>es-ES</c> - Spanish, Spain </para></li><li><para><c>fr-FR</c> - French, France </para></li><li><para><c>it-IT</c> - Italian, Italy </para></li><li><para><c>ja-JP</c> - Japanese, Japan </para></li><li><para><c>ko-KR</c> - Korean, Republic of Korea </para></li><li><para><c>pt-BR</c> - Portugese, Brazil </para></li><li><para><c>zh-CN</c> - Chinese, China </para></li><li><para><c>zh-TW</c> - Chinese, Taiwan </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter ProfilingGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the profiling group to get analysis data about. </para>
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
        public System.String ProfilingGroupName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para> The end time of the profile to get analysis data about. You must specify <c>startTime</c>
        /// and <c>endTime</c>. This is specified using the ISO 8601 format. For example, 2020-06-01T13:15:02.001Z
        /// represents 1 millisecond past June 1, 2020 1:15:02 PM UTC. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse, GetCGPRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            context.ProfilingGroupName = this.ProfilingGroupName;
            #if MODULAR
            if (this.ProfilingGroupName == null && ParameterWasBound(nameof(this.ProfilingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfilingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeGuruProfiler.Model.GetRecommendationsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.ProfilingGroupName != null)
            {
                request.ProfilingGroupName = cmdletContext.ProfilingGroupName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse CallAWSServiceOperation(IAmazonCodeGuruProfiler client, Amazon.CodeGuruProfiler.Model.GetRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Profiler", "GetRecommendations");
            try
            {
                #if DESKTOP
                return client.GetRecommendations(request);
                #elif CORECLR
                return client.GetRecommendationsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String Locale { get; set; }
            public System.String ProfilingGroupName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CodeGuruProfiler.Model.GetRecommendationsResponse, GetCGPRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
