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
using Amazon.GameLift;
using Amazon.GameLift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves the location of stored game session logs for a specified game session on
    /// Amazon GameLift managed fleets. When a game session is terminated, Amazon GameLift
    /// automatically stores the logs in Amazon S3 and retains them for 14 days. Use this
    /// URL to download the logs.
    /// 
    ///  <note><para>
    /// See the <a href="https://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html#limits_gamelift">Amazon
    /// Web Services Service Limits</a> page for maximum log file sizes. Log files that exceed
    /// this limit are not saved.
    /// </para></note><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("Get", "GMLGameSessionLogUrl")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service GetGameSessionLogUrl API operation.", Operation = new[] {"GetGameSessionLogUrl"}, SelectReturnType = typeof(Amazon.GameLift.Model.GetGameSessionLogUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.GameLift.Model.GetGameSessionLogUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GameLift.Model.GetGameSessionLogUrlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGMLGameSessionLogUrlCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game session to get logs for. </para>
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
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PreSignedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.GetGameSessionLogUrlResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.GetGameSessionLogUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PreSignedUrl";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.GetGameSessionLogUrlResponse, GetGMLGameSessionLogUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GameSessionId = this.GameSessionId;
            #if MODULAR
            if (this.GameSessionId == null && ParameterWasBound(nameof(this.GameSessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter GameSessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLift.Model.GetGameSessionLogUrlRequest();
            
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
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
        
        private Amazon.GameLift.Model.GetGameSessionLogUrlResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.GetGameSessionLogUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "GetGameSessionLogUrl");
            try
            {
                return client.GetGameSessionLogUrlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GameSessionId { get; set; }
            public System.Func<Amazon.GameLift.Model.GetGameSessionLogUrlResponse, GetGMLGameSessionLogUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PreSignedUrl;
        }
        
    }
}
