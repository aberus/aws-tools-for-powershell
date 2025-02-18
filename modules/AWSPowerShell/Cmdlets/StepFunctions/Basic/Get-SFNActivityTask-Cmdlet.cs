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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Used by workers to retrieve a task (with the specified activity ARN) which has been
    /// scheduled for execution by a running state machine. This initiates a long poll, where
    /// the service holds the HTTP connection open and responds as soon as a task becomes
    /// available (i.e. an execution of a task of this type is needed.) The maximum time the
    /// service holds on to the request before responding is 60 seconds. If no task is available
    /// within 60 seconds, the poll returns a <c>taskToken</c> with a null string.
    /// 
    ///  <note><para>
    /// This API action isn't logged in CloudTrail.
    /// </para></note><important><para>
    /// Workers should set their client side socket timeout to at least 65 seconds (5 seconds
    /// higher than the maximum time the service may hold the poll request).
    /// </para><para>
    /// Polling with <c>GetActivityTask</c> can cause latency in some implementations. See
    /// <a href="https://docs.aws.amazon.com/step-functions/latest/dg/bp-activity-pollers.html">Avoid
    /// Latency When Polling for Activity Tasks</a> in the Step Functions Developer Guide.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "SFNActivityTask")]
    [OutputType("Amazon.StepFunctions.Model.GetActivityTaskResponse")]
    [AWSCmdlet("Calls the AWS Step Functions GetActivityTask API operation.", Operation = new[] {"GetActivityTask"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.GetActivityTaskResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.GetActivityTaskResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.GetActivityTaskResponse object containing multiple properties."
    )]
    public partial class GetSFNActivityTaskCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActivityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the activity to retrieve tasks from (assigned when
        /// you create the task using <a>CreateActivity</a>.)</para>
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
        public System.String ActivityArn { get; set; }
        #endregion
        
        #region Parameter WorkerName
        /// <summary>
        /// <para>
        /// <para>You can provide an arbitrary name in order to identify the worker that the task is
        /// assigned to. This name is used when it is logged in the execution history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.GetActivityTaskResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.GetActivityTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.GetActivityTaskResponse, GetSFNActivityTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActivityArn = this.ActivityArn;
            #if MODULAR
            if (this.ActivityArn == null && ParameterWasBound(nameof(this.ActivityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ActivityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkerName = this.WorkerName;
            
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
            var request = new Amazon.StepFunctions.Model.GetActivityTaskRequest();
            
            if (cmdletContext.ActivityArn != null)
            {
                request.ActivityArn = cmdletContext.ActivityArn;
            }
            if (cmdletContext.WorkerName != null)
            {
                request.WorkerName = cmdletContext.WorkerName;
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
        
        private Amazon.StepFunctions.Model.GetActivityTaskResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.GetActivityTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "GetActivityTask");
            try
            {
                return client.GetActivityTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActivityArn { get; set; }
            public System.String WorkerName { get; set; }
            public System.Func<Amazon.StepFunctions.Model.GetActivityTaskResponse, GetSFNActivityTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
