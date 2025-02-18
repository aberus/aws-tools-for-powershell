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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Starts a query of one or more log groups using CloudWatch Logs Insights. You specify
    /// the log groups and time range to query and the query string to use.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CWL_QuerySyntax.html">CloudWatch
    /// Logs Insights Query Syntax</a>.
    /// </para><para>
    /// After you run a query using <c>StartQuery</c>, the query results are stored by CloudWatch
    /// Logs. You can use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_GetQueryResults.html">GetQueryResults</a>
    /// to retrieve the results of a query, using the <c>queryId</c> that <c>StartQuery</c>
    /// returns. 
    /// </para><note><para>
    /// To specify the log groups to query, a <c>StartQuery</c> operation must include one
    /// of the following:
    /// </para><ul><li><para>
    /// Either exactly one of the following parameters: <c>logGroupName</c>, <c>logGroupNames</c>,
    /// or <c>logGroupIdentifiers</c></para></li><li><para>
    /// Or the <c>queryString</c> must include a <c>SOURCE</c> command to select log groups
    /// for the query. The <c>SOURCE</c> command can select log groups based on log group
    /// name prefix, account ID, and log class. 
    /// </para><para>
    /// For more information about the <c>SOURCE</c> command, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CWL_QuerySyntax-Source.html">SOURCE</a>.
    /// </para></li></ul></note><para>
    /// If you have associated a KMS key with the query results in this account, then <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_StartQuery.html">StartQuery</a>
    /// uses that key to encrypt the results when it stores them. If no key is associated
    /// with query results, the query results are encrypted with the default CloudWatch Logs
    /// encryption method.
    /// </para><para>
    /// Queries time out after 60 minutes of runtime. If your queries are timing out, reduce
    /// the time range being searched or partition your query into a number of queries.
    /// </para><para>
    /// If you are using CloudWatch cross-account observability, you can use this operation
    /// in a monitoring account to start a query in a linked source account. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">CloudWatch
    /// cross-account observability</a>. For a cross-account <c>StartQuery</c> operation,
    /// the query definition must be defined in the monitoring account.
    /// </para><para>
    /// You can have up to 30 concurrent CloudWatch Logs insights queries, including queries
    /// that have been added to dashboards. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CWLQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs StartQuery API operation.", Operation = new[] {"StartQuery"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.StartQueryResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchLogs.Model.StartQueryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.StartQueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCWLQueryCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range to query. The range is inclusive, so the specified end time
        /// is included in the query. Specified as epoch time, the number of seconds since <c>January
        /// 1, 1970, 00:00:00 UTC</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? EndTime { get; set; }
        #endregion
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The list of log groups to query. You can include up to 50 log groups.</para><para>You can specify them by the log group name or ARN. If a log group that you're querying
        /// is in a source account and you're using a monitoring account, you must specify the
        /// ARN of the log group here. The query definition must also be defined in the monitoring
        /// account.</para><para>If you specify an ARN, use the format arn:aws:logs:<i>region</i>:<i>account-id</i>:log-group:<i>log_group_name</i>
        /// Don't include an * at the end.</para><para>A <c>StartQuery</c> operation must include exactly one of the following parameters:
        /// <c>logGroupName</c>, <c>logGroupNames</c>, or <c>logGroupIdentifiers</c>. The exception
        /// is queries using the OpenSearch Service SQL query language, where you specify the
        /// log group names inside the <c>querystring</c> instead of here. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogGroupIdentifiers")]
        public System.String[] LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The log group on which to perform the query.</para><note><para>A <c>StartQuery</c> operation must include exactly one of the following parameters:
        /// <c>logGroupName</c>, <c>logGroupNames</c>, or <c>logGroupIdentifiers</c>. The exception
        /// is queries using the OpenSearch Service SQL query language, where you specify the
        /// log group names inside the <c>querystring</c> instead of here.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogGroupNameList
        /// <summary>
        /// <para>
        /// <para>The list of log groups to be queried. You can include up to 50 log groups.</para><note><para>A <c>StartQuery</c> operation must include exactly one of the following parameters:
        /// <c>logGroupName</c>, <c>logGroupNames</c>, or <c>logGroupIdentifiers</c>. The exception
        /// is queries using the OpenSearch Service SQL query language, where you specify the
        /// log group names inside the <c>querystring</c> instead of here.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] LogGroupNameList { get; set; }
        #endregion
        
        #region Parameter QueryLanguage
        /// <summary>
        /// <para>
        /// <para>Specify the query language to use for this query. The options are Logs Insights QL,
        /// OpenSearch PPL, and OpenSearch SQL. For more information about the query languages
        /// that CloudWatch Logs supports, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CWL_AnalyzeLogData_Languages.html">Supported
        /// query languages</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.QueryLanguage")]
        public Amazon.CloudWatchLogs.QueryLanguage QueryLanguage { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The query string to use. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CWL_QuerySyntax.html">CloudWatch
        /// Logs Insights Query Syntax</a>.</para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range to query. The range is inclusive, so the specified
        /// start time is included in the query. Specified as epoch time, the number of seconds
        /// since <c>January 1, 1970, 00:00:00 UTC</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? StartTime { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of log events to return in the query. If the query string uses
        /// the <c>fields</c> command, only the specified fields and their values are returned.
        /// The default is 10,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueryId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.StartQueryResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.StartQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueryId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CWLQuery (StartQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.StartQueryResponse, StartCWLQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Limit = this.Limit;
            if (this.LogGroupIdentifier != null)
            {
                context.LogGroupIdentifier = new List<System.String>(this.LogGroupIdentifier);
            }
            context.LogGroupName = this.LogGroupName;
            if (this.LogGroupNameList != null)
            {
                context.LogGroupNameList = new List<System.String>(this.LogGroupNameList);
            }
            context.QueryLanguage = this.QueryLanguage;
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.StartQueryRequest();
            
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
                request.LogGroupIdentifiers = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogGroupNameList != null)
            {
                request.LogGroupNames = cmdletContext.LogGroupNameList;
            }
            if (cmdletContext.QueryLanguage != null)
            {
                request.QueryLanguage = cmdletContext.QueryLanguage;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
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
        
        private Amazon.CloudWatchLogs.Model.StartQueryResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.StartQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "StartQuery");
            try
            {
                return client.StartQueryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? EndTime { get; set; }
            public System.Int32? Limit { get; set; }
            public List<System.String> LogGroupIdentifier { get; set; }
            public System.String LogGroupName { get; set; }
            public List<System.String> LogGroupNameList { get; set; }
            public Amazon.CloudWatchLogs.QueryLanguage QueryLanguage { get; set; }
            public System.String QueryString { get; set; }
            public System.Int64? StartTime { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.StartQueryResponse, StartCWLQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueryId;
        }
        
    }
}
