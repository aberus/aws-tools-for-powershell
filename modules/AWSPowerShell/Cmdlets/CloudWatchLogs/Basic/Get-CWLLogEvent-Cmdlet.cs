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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Lists log events from the specified log stream. You can list all of the log events
    /// or filter using a time range.
    /// 
    ///  
    /// <para>
    /// By default, this operation returns as many log events as can fit in a response size
    /// of 1MB (up to 10,000 log events). You can get additional log events by specifying
    /// one of the tokens in a subsequent call. This operation can return empty results while
    /// there are more log events available through the token.
    /// </para><para>
    /// If you are using CloudWatch cross-account observability, you can use this operation
    /// in a monitoring account and view data from the linked source accounts. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">CloudWatch
    /// cross-account observability</a>.
    /// </para><para>
    /// You can specify the log group to search by using either <c>logGroupIdentifier</c>
    /// or <c>logGroupName</c>. You must include one of these two parameters, but you can't
    /// include both. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLLogEvent")]
    [OutputType("Amazon.CloudWatchLogs.Model.GetLogEventsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs GetLogEvents API operation.", Operation = new[] {"GetLogEvents"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.GetLogEventsResponse), LegacyAlias="Get-CWLLogEvents")]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.GetLogEventsResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.GetLogEventsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWLLogEventCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range, expressed as the number of milliseconds after <c>Jan 1,
        /// 1970 00:00:00 UTC</c>. Events with a timestamp equal to or later than this time are
        /// not included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>Specify either the name or ARN of the log group to view events from. If the log group
        /// is in a source account and you are using a monitoring account, you must use the log
        /// group ARN.</para><note><para> You must include either <c>logGroupIdentifier</c> or <c>logGroupName</c>, but not
        /// both. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para><note><para> You must include either <c>logGroupIdentifier</c> or <c>logGroupName</c>, but not
        /// both. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the log stream.</para>
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
        public System.String LogStreamName { get; set; }
        #endregion
        
        #region Parameter StartFromHead
        /// <summary>
        /// <para>
        /// <para>If the value is true, the earliest log events are returned first. If the value is
        /// false, the latest log events are returned first. The default value is false.</para><para>If you are using a previous <c>nextForwardToken</c> value as the <c>nextToken</c>
        /// in this operation, you must specify <c>true</c> for <c>startFromHead</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StartFromHead { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time range, expressed as the number of milliseconds after <c>Jan
        /// 1, 1970 00:00:00 UTC</c>. Events with a timestamp equal to this time or later than
        /// this time are included. Events with a timestamp earlier than this time are not included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Unmask
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to display the log event fields with all sensitive data unmasked
        /// and visible. The default is <c>false</c>.</para><para>To use this operation with this parameter, you must be signed into an account with
        /// the <c>logs:Unmask</c> permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Unmask { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of log events returned. If you don't specify a limit, the default
        /// is as many log events as can fit in a response size of 1 MB (up to 10,000 log events).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of items to return. (You received this token from a previous
        /// call.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.GetLogEventsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.GetLogEventsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.GetLogEventsResponse, GetCWLLogEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            context.Limit = this.Limit;
            context.LogGroupIdentifier = this.LogGroupIdentifier;
            context.LogGroupName = this.LogGroupName;
            context.LogStreamName = this.LogStreamName;
            #if MODULAR
            if (this.LogStreamName == null && ParameterWasBound(nameof(this.LogStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.StartFromHead = this.StartFromHead;
            context.StartTime = this.StartTime;
            context.Unmask = this.Unmask;
            
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
            var request = new Amazon.CloudWatchLogs.Model.GetLogEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifier = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamName = cmdletContext.LogStreamName;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartFromHead != null)
            {
                request.StartFromHead = cmdletContext.StartFromHead.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Unmask != null)
            {
                request.Unmask = cmdletContext.Unmask.Value;
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
        
        private Amazon.CloudWatchLogs.Model.GetLogEventsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.GetLogEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "GetLogEvents");
            try
            {
                #if DESKTOP
                return client.GetLogEvents(request);
                #elif CORECLR
                return client.GetLogEventsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Limit { get; set; }
            public System.String LogGroupIdentifier { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamName { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? StartFromHead { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Boolean? Unmask { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.GetLogEventsResponse, GetCWLLogEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
