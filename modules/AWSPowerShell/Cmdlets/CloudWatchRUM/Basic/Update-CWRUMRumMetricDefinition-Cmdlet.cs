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
using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Modifies one existing metric definition for CloudWatch RUM extended metrics. For more
    /// information about extended metrics, see <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_BatchCreateRumMetricsDefinitions.html">BatchCreateRumMetricsDefinitions</a>.
    /// </summary>
    [Cmdlet("Update", "CWRUMRumMetricDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CloudWatch RUM UpdateRumMetricDefinition API operation.", Operation = new[] {"UpdateRumMetricDefinition"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWRUMRumMetricDefinitionCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppMonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch RUM app monitor that sends these metrics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppMonitorName { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The destination to send the metrics to. Valid values are <c>CloudWatch</c> and <c>Evidently</c>.
        /// If you specify <c>Evidently</c>, you must also specify the ARN of the CloudWatchEvidently
        /// experiment that will receive the metrics and an IAM role that has permission to write
        /// to the experiment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchRUM.MetricDestination")]
        public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
        #endregion
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>This parameter is required if <c>Destination</c> is <c>Evidently</c>. If <c>Destination</c>
        /// is <c>CloudWatch</c>, do not use this parameter.</para><para>This parameter specifies the ARN of the Evidently experiment that is to receive the
        /// metrics. You must have already defined this experiment as a valid destination. For
        /// more information, see <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_PutRumMetricsDestination.html">PutRumMetricsDestination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_DimensionKey
        /// <summary>
        /// <para>
        /// <para>Use this field only if you are sending the metric to CloudWatch.</para><para>This field is a map of field paths to dimension names. It defines the dimensions to
        /// associate with this metric in CloudWatch. For extended metrics, valid values for the
        /// entries in this field are the following:</para><ul><li><para><c>"metadata.pageId": "PageId"</c></para></li><li><para><c>"metadata.browserName": "BrowserName"</c></para></li><li><para><c>"metadata.deviceType": "DeviceType"</c></para></li><li><para><c>"metadata.osName": "OSName"</c></para></li><li><para><c>"metadata.countryCode": "CountryCode"</c></para></li><li><para><c>"event_details.fileType": "FileType"</c></para></li></ul><para> For both extended metrics and custom metrics, all dimensions listed in this field
        /// must also be included in <c>EventPattern</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricDefinition_DimensionKeys")]
        public System.Collections.Hashtable MetricDefinition_DimensionKey { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_EventPattern
        /// <summary>
        /// <para>
        /// <para>The pattern that defines the metric, specified as a JSON object. RUM checks events
        /// that happen in a user's session against the pattern, and events that match the pattern
        /// are sent to the metric destination.</para><para>When you define extended metrics, the metric definition is not valid if <c>EventPattern</c>
        /// is omitted.</para><para>Example event patterns:</para><ul><li><para><c>'{ "event_type": ["com.amazon.rum.js_error_event"], "metadata": { "browserName":
        /// [ "Chrome", "Safari" ], } }'</c></para></li><li><para><c>'{ "event_type": ["com.amazon.rum.performance_navigation_event"], "metadata":
        /// { "browserName": [ "Chrome", "Firefox" ] }, "event_details": { "duration": [{ "numeric":
        /// [ "&lt;", 2000 ] }] } }'</c></para></li><li><para><c>'{ "event_type": ["com.amazon.rum.performance_navigation_event"], "metadata":
        /// { "browserName": [ "Chrome", "Safari" ], "countryCode": [ "US" ] }, "event_details":
        /// { "duration": [{ "numeric": [ "&gt;=", 2000, "&lt;", 8000 ] }] } }'</c></para></li></ul><para>If the metrics destination is <c>CloudWatch</c> and the event also matches a value
        /// in <c>DimensionKeys</c>, then the metric is published with the specified dimensions.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricDefinition_EventPattern { get; set; }
        #endregion
        
        #region Parameter MetricDefinitionId
        /// <summary>
        /// <para>
        /// <para>The ID of the metric definition to update.</para>
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
        public System.String MetricDefinitionId { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_Name
        /// <summary>
        /// <para>
        /// <para>The name for the metric that is defined in this structure. For custom metrics, you
        /// can specify any name that you like. For extended metrics, valid values are the following:</para><ul><li><para><c>PerformanceNavigationDuration</c></para></li><li><para><c>PerformanceResourceDuration </c></para></li><li><para><c>NavigationSatisfiedTransaction</c></para></li><li><para><c>NavigationToleratedTransaction</c></para></li><li><para><c>NavigationFrustratedTransaction</c></para></li><li><para><c>WebVitalsCumulativeLayoutShift</c></para></li><li><para><c>WebVitalsFirstInputDelay</c></para></li><li><para><c>WebVitalsLargestContentfulPaint</c></para></li><li><para><c>JsErrorCount</c></para></li><li><para><c>HttpErrorCount</c></para></li><li><para><c>SessionCount</c></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MetricDefinition_Name { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_Namespace
        /// <summary>
        /// <para>
        /// <para>If this structure is for a custom metric instead of an extended metrics, use this
        /// parameter to define the metric namespace for that custom metric. Do not specify this
        /// parameter if this structure is for an extended metric.</para><para>You cannot use any string that starts with <c>AWS/</c> for your namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricDefinition_Namespace { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_UnitLabel
        /// <summary>
        /// <para>
        /// <para>The CloudWatch metric unit to use for this metric. If you omit this field, the metric
        /// is recorded with no unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricDefinition_UnitLabel { get; set; }
        #endregion
        
        #region Parameter MetricDefinition_ValueKey
        /// <summary>
        /// <para>
        /// <para>The field within the event object that the metric value is sourced from.</para><para>If you omit this field, a hardcoded value of 1 is pushed as the metric value. This
        /// is useful if you want to count the number of events that the filter catches. </para><para>If this metric is sent to CloudWatch Evidently, this field will be passed to Evidently
        /// raw. Evidently will handle data extraction from the event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricDefinition_ValueKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MetricDefinitionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWRUMRumMetricDefinition (UpdateRumMetricDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse, UpdateCWRUMRumMetricDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppMonitorName = this.AppMonitorName;
            #if MODULAR
            if (this.AppMonitorName == null && ParameterWasBound(nameof(this.AppMonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppMonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Destination = this.Destination;
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationArn = this.DestinationArn;
            if (this.MetricDefinition_DimensionKey != null)
            {
                context.MetricDefinition_DimensionKey = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.MetricDefinition_DimensionKey.Keys)
                {
                    context.MetricDefinition_DimensionKey.Add((String)hashKey, (System.String)(this.MetricDefinition_DimensionKey[hashKey]));
                }
            }
            context.MetricDefinition_EventPattern = this.MetricDefinition_EventPattern;
            context.MetricDefinition_Name = this.MetricDefinition_Name;
            #if MODULAR
            if (this.MetricDefinition_Name == null && ParameterWasBound(nameof(this.MetricDefinition_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricDefinition_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricDefinition_Namespace = this.MetricDefinition_Namespace;
            context.MetricDefinition_UnitLabel = this.MetricDefinition_UnitLabel;
            context.MetricDefinition_ValueKey = this.MetricDefinition_ValueKey;
            context.MetricDefinitionId = this.MetricDefinitionId;
            #if MODULAR
            if (this.MetricDefinitionId == null && ParameterWasBound(nameof(this.MetricDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionRequest();
            
            if (cmdletContext.AppMonitorName != null)
            {
                request.AppMonitorName = cmdletContext.AppMonitorName;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            
             // populate MetricDefinition
            var requestMetricDefinitionIsNull = true;
            request.MetricDefinition = new Amazon.CloudWatchRUM.Model.MetricDefinitionRequest();
            Dictionary<System.String, System.String> requestMetricDefinition_metricDefinition_DimensionKey = null;
            if (cmdletContext.MetricDefinition_DimensionKey != null)
            {
                requestMetricDefinition_metricDefinition_DimensionKey = cmdletContext.MetricDefinition_DimensionKey;
            }
            if (requestMetricDefinition_metricDefinition_DimensionKey != null)
            {
                request.MetricDefinition.DimensionKeys = requestMetricDefinition_metricDefinition_DimensionKey;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_EventPattern = null;
            if (cmdletContext.MetricDefinition_EventPattern != null)
            {
                requestMetricDefinition_metricDefinition_EventPattern = cmdletContext.MetricDefinition_EventPattern;
            }
            if (requestMetricDefinition_metricDefinition_EventPattern != null)
            {
                request.MetricDefinition.EventPattern = requestMetricDefinition_metricDefinition_EventPattern;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_Name = null;
            if (cmdletContext.MetricDefinition_Name != null)
            {
                requestMetricDefinition_metricDefinition_Name = cmdletContext.MetricDefinition_Name;
            }
            if (requestMetricDefinition_metricDefinition_Name != null)
            {
                request.MetricDefinition.Name = requestMetricDefinition_metricDefinition_Name;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_Namespace = null;
            if (cmdletContext.MetricDefinition_Namespace != null)
            {
                requestMetricDefinition_metricDefinition_Namespace = cmdletContext.MetricDefinition_Namespace;
            }
            if (requestMetricDefinition_metricDefinition_Namespace != null)
            {
                request.MetricDefinition.Namespace = requestMetricDefinition_metricDefinition_Namespace;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_UnitLabel = null;
            if (cmdletContext.MetricDefinition_UnitLabel != null)
            {
                requestMetricDefinition_metricDefinition_UnitLabel = cmdletContext.MetricDefinition_UnitLabel;
            }
            if (requestMetricDefinition_metricDefinition_UnitLabel != null)
            {
                request.MetricDefinition.UnitLabel = requestMetricDefinition_metricDefinition_UnitLabel;
                requestMetricDefinitionIsNull = false;
            }
            System.String requestMetricDefinition_metricDefinition_ValueKey = null;
            if (cmdletContext.MetricDefinition_ValueKey != null)
            {
                requestMetricDefinition_metricDefinition_ValueKey = cmdletContext.MetricDefinition_ValueKey;
            }
            if (requestMetricDefinition_metricDefinition_ValueKey != null)
            {
                request.MetricDefinition.ValueKey = requestMetricDefinition_metricDefinition_ValueKey;
                requestMetricDefinitionIsNull = false;
            }
             // determine if request.MetricDefinition should be set to null
            if (requestMetricDefinitionIsNull)
            {
                request.MetricDefinition = null;
            }
            if (cmdletContext.MetricDefinitionId != null)
            {
                request.MetricDefinitionId = cmdletContext.MetricDefinitionId;
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
        
        private Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "UpdateRumMetricDefinition");
            try
            {
                return client.UpdateRumMetricDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppMonitorName { get; set; }
            public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
            public System.String DestinationArn { get; set; }
            public Dictionary<System.String, System.String> MetricDefinition_DimensionKey { get; set; }
            public System.String MetricDefinition_EventPattern { get; set; }
            public System.String MetricDefinition_Name { get; set; }
            public System.String MetricDefinition_Namespace { get; set; }
            public System.String MetricDefinition_UnitLabel { get; set; }
            public System.String MetricDefinition_ValueKey { get; set; }
            public System.String MetricDefinitionId { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.UpdateRumMetricDefinitionResponse, UpdateCWRUMRumMetricDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
