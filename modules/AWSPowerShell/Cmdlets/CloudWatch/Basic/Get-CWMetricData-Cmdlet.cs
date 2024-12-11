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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// You can use the <c>GetMetricData</c> API to retrieve CloudWatch metric values. The
    /// operation can also include a CloudWatch Metrics Insights query, and one or more metric
    /// math functions.
    /// 
    ///  
    /// <para>
    /// A <c>GetMetricData</c> operation that does not include a query can retrieve as many
    /// as 500 different metrics in a single request, with a total of as many as 100,800 data
    /// points. You can also optionally perform metric math expressions on the values of the
    /// returned statistics, to create new time series that represent new insights into your
    /// data. For example, using Lambda metrics, you could divide the Errors metric by the
    /// Invocations metric to get an error rate time series. For more information about metric
    /// math expressions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/using-metric-math.html#metric-math-syntax">Metric
    /// Math Syntax and Functions</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para><para>
    /// If you include a Metrics Insights query, each <c>GetMetricData</c> operation can include
    /// only one query. But the same <c>GetMetricData</c> operation can also retrieve other
    /// metrics. Metrics Insights queries can query only the most recent three hours of metric
    /// data. For more information about Metrics Insights, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/query_with_cloudwatch-metrics-insights.html">Query
    /// your metrics with CloudWatch Metrics Insights</a>.
    /// </para><para>
    /// Calls to the <c>GetMetricData</c> API have a different pricing structure than calls
    /// to <c>GetMetricStatistics</c>. For more information about pricing, see <a href="https://aws.amazon.com/cloudwatch/pricing/">Amazon
    /// CloudWatch Pricing</a>.
    /// </para><para>
    /// Amazon CloudWatch retains metric data as follows:
    /// </para><ul><li><para>
    /// Data points with a period of less than 60 seconds are available for 3 hours. These
    /// data points are high-resolution metrics and are available only for custom metrics
    /// that have been defined with a <c>StorageResolution</c> of 1.
    /// </para></li><li><para>
    /// Data points with a period of 60 seconds (1-minute) are available for 15 days.
    /// </para></li><li><para>
    /// Data points with a period of 300 seconds (5-minute) are available for 63 days.
    /// </para></li><li><para>
    /// Data points with a period of 3600 seconds (1 hour) are available for 455 days (15
    /// months).
    /// </para></li></ul><para>
    /// Data points that are initially published with a shorter period are aggregated together
    /// for long-term storage. For example, if you collect data using a period of 1 minute,
    /// the data remains available for 15 days with 1-minute resolution. After 15 days, this
    /// data is still available, but is aggregated and retrievable only with a resolution
    /// of 5 minutes. After 63 days, the data is further aggregated and is available with
    /// a resolution of 1 hour.
    /// </para><para>
    /// If you omit <c>Unit</c> in your request, all data that was collected with any unit
    /// is returned, along with the corresponding units that were specified when the data
    /// was reported to CloudWatch. If you specify a unit, the operation returns only data
    /// that was collected with that unit specified. If you specify a unit that does not match
    /// the data collected, the results of the operation are null. CloudWatch does not perform
    /// unit conversions.
    /// </para><para><b>Using Metrics Insights queries with metric math</b></para><para>
    /// You can't mix a Metric Insights query and metric math syntax in the same expression,
    /// but you can reference results from a Metrics Insights query within other Metric math
    /// expressions. A Metrics Insights query without a <b>GROUP BY</b> clause returns a single
    /// time-series (TS), and can be used as input for a metric math expression that expects
    /// a single time series. A Metrics Insights query with a <b>GROUP BY</b> clause returns
    /// an array of time-series (TS[]), and can be used as input for a metric math expression
    /// that expects an array of time series. 
    /// </para><br/><br/>In the AWS.Tools.CloudWatch module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWMetricData")]
    [OutputType("Amazon.CloudWatch.Model.GetMetricDataResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetMetricData API operation.", Operation = new[] {"GetMetricData"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.GetMetricDataResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.GetMetricDataResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.GetMetricDataResponse object containing multiple properties."
    )]
    public partial class GetCWMetricDataCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UtcEndTime
        /// <summary>
        /// <para>
        /// <para>The time stamp indicating the latest data to be returned.</para><para>The value specified is exclusive; results include data points up to the specified
        /// time stamp.</para><para>For better performance, specify <c>StartTime</c> and <c>EndTime</c> values that align
        /// with the value of the metric's <c>Period</c> and sync up with the beginning and end
        /// of an hour. For example, if the <c>Period</c> of a metric is 5 minutes, specifying
        /// 12:05 or 12:30 as <c>EndTime</c> can get a faster response from CloudWatch than setting
        /// 12:07 or 12:29 as the <c>EndTime</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? UtcEndTime { get; set; }
        #endregion
        
        #region Parameter MaxDatapoint
        /// <summary>
        /// <para>
        /// <para>The maximum number of data points the request should return before paginating. If
        /// you omit this, the default of 100,800 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxDatapoints")]
        public System.Int32? MaxDatapoint { get; set; }
        #endregion
        
        #region Parameter MetricDataQuery
        /// <summary>
        /// <para>
        /// <para>The metric queries to be returned. A single <c>GetMetricData</c> call can include
        /// as many as 500 <c>MetricDataQuery</c> structures. Each of these structures can specify
        /// either a metric to retrieve, a Metrics Insights query, or a math expression to perform
        /// on retrieved data. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MetricDataQueries")]
        public Amazon.CloudWatch.Model.MetricDataQuery[] MetricDataQuery { get; set; }
        #endregion
        
        #region Parameter ScanBy
        /// <summary>
        /// <para>
        /// <para>The order in which data points should be returned. <c>TimestampDescending</c> returns
        /// the newest data first and paginates when the <c>MaxDatapoints</c> limit is reached.
        /// <c>TimestampAscending</c> returns the oldest data first and paginates when the <c>MaxDatapoints</c>
        /// limit is reached.</para><para>If you omit this parameter, the default of <c>TimestampDescending</c> is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.ScanBy")]
        public Amazon.CloudWatch.ScanBy ScanBy { get; set; }
        #endregion
        
        #region Parameter UtcStartTime
        /// <summary>
        /// <para>
        /// <para>The time stamp indicating the earliest data to be returned.</para><para>The value specified is inclusive; results include data points with the specified time
        /// stamp. </para><para>CloudWatch rounds the specified time stamp as follows:</para><ul><li><para>Start time less than 15 days ago - Round down to the nearest whole minute. For example,
        /// 12:32:34 is rounded down to 12:32:00.</para></li><li><para>Start time between 15 and 63 days ago - Round down to the nearest 5-minute clock interval.
        /// For example, 12:32:34 is rounded down to 12:30:00.</para></li><li><para>Start time greater than 63 days ago - Round down to the nearest 1-hour clock interval.
        /// For example, 12:32:34 is rounded down to 12:00:00.</para></li></ul><para>If you set <c>Period</c> to 5, 10, or 30, the start time of your request is rounded
        /// down to the nearest time that corresponds to even 5-, 10-, or 30-second divisions
        /// of a minute. For example, if you make a query at (HH:mm:ss) 01:05:23 for the previous
        /// 10-second period, the start time of your request is rounded down and you receive data
        /// from 01:05:10 to 01:05:20. If you make a query at 15:07:17 for the previous 5 minutes
        /// of data, using a period of 5 seconds, you receive data timestamped between 15:02:15
        /// and 15:07:15. </para><para>For better performance, specify <c>StartTime</c> and <c>EndTime</c> values that align
        /// with the value of the metric's <c>Period</c> and sync up with the beginning and end
        /// of an hour. For example, if the <c>Period</c> of a metric is 5 minutes, specifying
        /// 12:05 or 12:30 as <c>StartTime</c> can get a faster response from CloudWatch than
        /// setting 12:07 or 12:29 as the <c>StartTime</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? UtcStartTime { get; set; }
        #endregion
        
        #region Parameter LabelOptions_Timezone
        /// <summary>
        /// <para>
        /// <para>The time zone to use for metric data return in this operation. The format is <c>+</c>
        /// or <c>-</c> followed by four digits. The first two digits indicate the number of hours
        /// ahead or behind of UTC, and the final two digits are the number of minutes. For example,
        /// +0130 indicates a time zone that is 1 hour and 30 minutes ahead of UTC. The default
        /// is +0000. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LabelOptions_Timezone { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use EndTimeUtc instead. Setting either EndTime or EndTimeUtc
        /// results in both EndTime and EndTimeUtc being assigned, the latest assignment to either
        /// one of the two property is reflected in the value of both. EndTime is provided for
        /// backwards compatibility only and assigning a non-Utc DateTime to it results in the
        /// wrong timestamp being passed to the service.</para><para>The time stamp indicating the latest data to be returned.</para><para>The value specified is exclusive; results include data points up to the specified
        /// time stamp.</para><para>For better performance, specify <c>StartTime</c> and <c>EndTime</c> values that align
        /// with the value of the metric's <c>Period</c> and sync up with the beginning and end
        /// of an hour. For example, if the <c>Period</c> of a metric is 5 minutes, specifying
        /// 12:05 or 12:30 as <c>EndTime</c> can get a faster response from CloudWatch than setting
        /// 12:07 or 12:29 as the <c>EndTime</c>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcEndTime instead.")]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Include this value, if it was returned by the previous <c>GetMetricData</c> operation,
        /// to get the next set of data points.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.CloudWatch module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use StartTimeUtc instead. Setting either StartTime or
        /// StartTimeUtc results in both StartTime and StartTimeUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. StartTime
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The time stamp indicating the earliest data to be returned.</para><para>The value specified is inclusive; results include data points with the specified time
        /// stamp. </para><para>CloudWatch rounds the specified time stamp as follows:</para><ul><li><para>Start time less than 15 days ago - Round down to the nearest whole minute. For example,
        /// 12:32:34 is rounded down to 12:32:00.</para></li><li><para>Start time between 15 and 63 days ago - Round down to the nearest 5-minute clock interval.
        /// For example, 12:32:34 is rounded down to 12:30:00.</para></li><li><para>Start time greater than 63 days ago - Round down to the nearest 1-hour clock interval.
        /// For example, 12:32:34 is rounded down to 12:00:00.</para></li></ul><para>If you set <c>Period</c> to 5, 10, or 30, the start time of your request is rounded
        /// down to the nearest time that corresponds to even 5-, 10-, or 30-second divisions
        /// of a minute. For example, if you make a query at (HH:mm:ss) 01:05:23 for the previous
        /// 10-second period, the start time of your request is rounded down and you receive data
        /// from 01:05:10 to 01:05:20. If you make a query at 15:07:17 for the previous 5 minutes
        /// of data, using a period of 5 seconds, you receive data timestamped between 15:02:15
        /// and 15:07:15. </para><para>For better performance, specify <c>StartTime</c> and <c>EndTime</c> values that align
        /// with the value of the metric's <c>Period</c> and sync up with the beginning and end
        /// of an hour. For example, if the <c>Period</c> of a metric is 5 minutes, specifying
        /// 12:05 or 12:30 as <c>StartTime</c> can get a faster response from CloudWatch than
        /// setting 12:07 or 12:29 as the <c>StartTime</c>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcStartTime instead.")]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.GetMetricDataResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.GetMetricDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.GetMetricDataResponse, GetCWMetricDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.UtcEndTime = this.UtcEndTime;
            #if MODULAR
            if (this.UtcEndTime == null && ParameterWasBound(nameof(this.UtcEndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter UtcEndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LabelOptions_Timezone = this.LabelOptions_Timezone;
            context.MaxDatapoint = this.MaxDatapoint;
            if (this.MetricDataQuery != null)
            {
                context.MetricDataQuery = new List<Amazon.CloudWatch.Model.MetricDataQuery>(this.MetricDataQuery);
            }
            #if MODULAR
            if (this.MetricDataQuery == null && ParameterWasBound(nameof(this.MetricDataQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricDataQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ScanBy = this.ScanBy;
            context.UtcStartTime = this.UtcStartTime;
            #if MODULAR
            if (this.UtcStartTime == null && ParameterWasBound(nameof(this.UtcStartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter UtcStartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StartTime = this.StartTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CloudWatch.Model.GetMetricDataRequest();
            
            if (cmdletContext.UtcEndTime != null)
            {
                request.EndTimeUtc = cmdletContext.UtcEndTime.Value;
            }
            
             // populate LabelOptions
            var requestLabelOptionsIsNull = true;
            request.LabelOptions = new Amazon.CloudWatch.Model.LabelOptions();
            System.String requestLabelOptions_labelOptions_Timezone = null;
            if (cmdletContext.LabelOptions_Timezone != null)
            {
                requestLabelOptions_labelOptions_Timezone = cmdletContext.LabelOptions_Timezone;
            }
            if (requestLabelOptions_labelOptions_Timezone != null)
            {
                request.LabelOptions.Timezone = requestLabelOptions_labelOptions_Timezone;
                requestLabelOptionsIsNull = false;
            }
             // determine if request.LabelOptions should be set to null
            if (requestLabelOptionsIsNull)
            {
                request.LabelOptions = null;
            }
            if (cmdletContext.MaxDatapoint != null)
            {
                request.MaxDatapoints = cmdletContext.MaxDatapoint.Value;
            }
            if (cmdletContext.MetricDataQuery != null)
            {
                request.MetricDataQueries = cmdletContext.MetricDataQuery;
            }
            if (cmdletContext.ScanBy != null)
            {
                request.ScanBy = cmdletContext.ScanBy;
            }
            if (cmdletContext.UtcStartTime != null)
            {
                request.StartTimeUtc = cmdletContext.UtcStartTime.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                if (cmdletContext.UtcEndTime != null)
                {
                    throw new System.ArgumentException("Parameters EndTime and UtcEndTime are mutually exclusive.", nameof(this.EndTime));
                }
                request.EndTime = cmdletContext.EndTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                if (cmdletContext.UtcStartTime != null)
                {
                    throw new System.ArgumentException("Parameters StartTime and UtcStartTime are mutually exclusive.", nameof(this.StartTime));
                }
                request.StartTime = cmdletContext.StartTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatch.Model.GetMetricDataRequest();
            
            if (cmdletContext.UtcEndTime != null)
            {
                request.EndTimeUtc = cmdletContext.UtcEndTime.Value;
            }
            
             // populate LabelOptions
            var requestLabelOptionsIsNull = true;
            request.LabelOptions = new Amazon.CloudWatch.Model.LabelOptions();
            System.String requestLabelOptions_labelOptions_Timezone = null;
            if (cmdletContext.LabelOptions_Timezone != null)
            {
                requestLabelOptions_labelOptions_Timezone = cmdletContext.LabelOptions_Timezone;
            }
            if (requestLabelOptions_labelOptions_Timezone != null)
            {
                request.LabelOptions.Timezone = requestLabelOptions_labelOptions_Timezone;
                requestLabelOptionsIsNull = false;
            }
             // determine if request.LabelOptions should be set to null
            if (requestLabelOptionsIsNull)
            {
                request.LabelOptions = null;
            }
            if (cmdletContext.MaxDatapoint != null)
            {
                request.MaxDatapoints = cmdletContext.MaxDatapoint.Value;
            }
            if (cmdletContext.MetricDataQuery != null)
            {
                request.MetricDataQueries = cmdletContext.MetricDataQuery;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ScanBy != null)
            {
                request.ScanBy = cmdletContext.ScanBy;
            }
            if (cmdletContext.UtcStartTime != null)
            {
                request.StartTimeUtc = cmdletContext.UtcStartTime.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                if (cmdletContext.UtcEndTime != null)
                {
                    throw new System.ArgumentException("Parameters EndTime and UtcEndTime are mutually exclusive.", nameof(this.EndTime));
                }
                request.EndTime = cmdletContext.EndTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                if (cmdletContext.UtcStartTime != null)
                {
                    throw new System.ArgumentException("Parameters StartTime and UtcStartTime are mutually exclusive.", nameof(this.StartTime));
                }
                request.StartTime = cmdletContext.StartTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatch.Model.GetMetricDataResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "GetMetricData");
            try
            {
                #if DESKTOP
                return client.GetMetricData(request);
                #elif CORECLR
                return client.GetMetricDataAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? UtcEndTime { get; set; }
            public System.String LabelOptions_Timezone { get; set; }
            public System.Int32? MaxDatapoint { get; set; }
            public List<Amazon.CloudWatch.Model.MetricDataQuery> MetricDataQuery { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.CloudWatch.ScanBy ScanBy { get; set; }
            public System.DateTime? UtcStartTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? EndTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CloudWatch.Model.GetMetricDataResponse, GetCWMetricDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
