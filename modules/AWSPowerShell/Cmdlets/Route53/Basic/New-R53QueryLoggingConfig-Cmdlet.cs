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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates a configuration for DNS query logging. After you create a query logging configuration,
    /// Amazon Route 53 begins to publish log data to an Amazon CloudWatch Logs log group.
    /// 
    ///  
    /// <para>
    /// DNS query logs contain information about the queries that Route 53 receives for a
    /// specified public hosted zone, such as the following:
    /// </para><ul><li><para>
    /// Route 53 edge location that responded to the DNS query
    /// </para></li><li><para>
    /// Domain or subdomain that was requested
    /// </para></li><li><para>
    /// DNS record type, such as A or AAAA
    /// </para></li><li><para>
    /// DNS response code, such as <c>NoError</c> or <c>ServFail</c></para></li></ul><dl><dt>Log Group and Resource Policy</dt><dd><para>
    /// Before you create a query logging configuration, perform the following operations.
    /// </para><note><para>
    /// If you create a query logging configuration using the Route 53 console, Route 53 performs
    /// these operations automatically.
    /// </para></note><ol><li><para>
    /// Create a CloudWatch Logs log group, and make note of the ARN, which you specify when
    /// you create a query logging configuration. Note the following:
    /// </para><ul><li><para>
    /// You must create the log group in the us-east-1 region.
    /// </para></li><li><para>
    /// You must use the same Amazon Web Services account to create the log group and the
    /// hosted zone that you want to configure query logging for.
    /// </para></li><li><para>
    /// When you create log groups for query logging, we recommend that you use a consistent
    /// prefix, for example:
    /// </para><para><c>/aws/route53/<i>hosted zone name</i></c></para><para>
    /// In the next step, you'll create a resource policy, which controls access to one or
    /// more log groups and the associated Amazon Web Services resources, such as Route 53
    /// hosted zones. There's a limit on the number of resource policies that you can create,
    /// so we recommend that you use a consistent prefix so you can use the same resource
    /// policy for all the log groups that you create for query logging.
    /// </para></li></ul></li><li><para>
    /// Create a CloudWatch Logs resource policy, and give it the permissions that Route 53
    /// needs to create log streams and to send query logs to log streams. For the value of
    /// <c>Resource</c>, specify the ARN for the log group that you created in the previous
    /// step. To use the same resource policy for all the CloudWatch Logs log groups that
    /// you created for query logging configurations, replace the hosted zone name with <c>*</c>,
    /// for example:
    /// </para><para><c>arn:aws:logs:us-east-1:123412341234:log-group:/aws/route53/*</c></para><para>
    /// To avoid the confused deputy problem, a security issue where an entity without a permission
    /// for an action can coerce a more-privileged entity to perform it, you can optionally
    /// limit the permissions that a service has to a resource in a resource-based policy
    /// by supplying the following values:
    /// </para><ul><li><para>
    /// For <c>aws:SourceArn</c>, supply the hosted zone ARN used in creating the query logging
    /// configuration. For example, <c>aws:SourceArn: arn:aws:route53:::hostedzone/hosted
    /// zone ID</c>.
    /// </para></li><li><para>
    /// For <c>aws:SourceAccount</c>, supply the account ID for the account that creates the
    /// query logging configuration. For example, <c>aws:SourceAccount:111111111111</c>.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/confused-deputy.html">The
    /// confused deputy problem</a> in the <i>Amazon Web Services IAM User Guide</i>.
    /// </para><note><para>
    /// You can't use the CloudWatch console to create or edit a resource policy. You must
    /// use the CloudWatch API, one of the Amazon Web Services SDKs, or the CLI.
    /// </para></note></li></ol></dd><dt>Log Streams and Edge Locations</dt><dd><para>
    /// When Route 53 finishes creating the configuration for DNS query logging, it does the
    /// following:
    /// </para><ul><li><para>
    /// Creates a log stream for an edge location the first time that the edge location responds
    /// to DNS queries for the specified hosted zone. That log stream is used to log all queries
    /// that Route 53 responds to for that edge location.
    /// </para></li><li><para>
    /// Begins to send query logs to the applicable log stream.
    /// </para></li></ul><para>
    /// The name of each log stream is in the following format:
    /// </para><para><c><i>hosted zone ID</i>/<i>edge location code</i></c></para><para>
    /// The edge location code is a three-letter code and an arbitrarily assigned number,
    /// for example, DFW3. The three-letter code typically corresponds with the International
    /// Air Transport Association airport code for an airport near the edge location. (These
    /// abbreviations might change in the future.) For a list of edge locations, see "The
    /// Route 53 Global Network" on the <a href="http://aws.amazon.com/route53/details/">Route
    /// 53 Product Details</a> page.
    /// </para></dd><dt>Queries That Are Logged</dt><dd><para>
    /// Query logs contain only the queries that DNS resolvers forward to Route 53. If a DNS
    /// resolver has already cached the response to a query (such as the IP address for a
    /// load balancer for example.com), the resolver will continue to return the cached response.
    /// It doesn't forward another query to Route 53 until the TTL for the corresponding resource
    /// record set expires. Depending on how many DNS queries are submitted for a resource
    /// record set, and depending on the TTL for that resource record set, query logs might
    /// contain information about only one query out of every several thousand queries that
    /// are submitted to DNS. For more information about how DNS works, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/welcome-dns-service.html">Routing
    /// Internet Traffic to Your Website or Web Application</a> in the <i>Amazon Route 53
    /// Developer Guide</i>.
    /// </para></dd><dt>Log File Format</dt><dd><para>
    /// For a list of the values in each query log and the format of each value, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/query-logs.html">Logging
    /// DNS Queries</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para></dd><dt>Pricing</dt><dd><para>
    /// For information about charges for query logs, see <a href="http://aws.amazon.com/cloudwatch/pricing/">Amazon
    /// CloudWatch Pricing</a>.
    /// </para></dd><dt>How to Stop Logging</dt><dd><para>
    /// If you want Route 53 to stop sending query logs to CloudWatch Logs, delete the query
    /// logging configuration. For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_DeleteQueryLoggingConfig.html">DeleteQueryLoggingConfig</a>.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("New", "R53QueryLoggingConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateQueryLoggingConfigResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateQueryLoggingConfig API operation.", Operation = new[] {"CreateQueryLoggingConfig"}, SelectReturnType = typeof(Amazon.Route53.Model.CreateQueryLoggingConfigResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateQueryLoggingConfigResponse",
        "This cmdlet returns an Amazon.Route53.Model.CreateQueryLoggingConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53QueryLoggingConfigCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudWatchLogsLogGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the log group that you want to Amazon Route 53
        /// to send query logs to. This is the format of the ARN:</para><para>arn:aws:logs:<i>region</i>:<i>account-id</i>:log-group:<i>log_group_name</i></para><para>To get the ARN for a log group, you can use the CloudWatch console, the <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_DescribeLogGroups.html">DescribeLogGroups</a>
        /// API action, the <a href="https://docs.aws.amazon.com/cli/latest/reference/logs/describe-log-groups.html">describe-log-groups</a>
        /// command, or the applicable command in one of the Amazon Web Services SDKs.</para>
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
        public System.String CloudWatchLogsLogGroupArn { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that you want to log queries for. You can log queries only
        /// for public hosted zones.</para>
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
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.CreateQueryLoggingConfigResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.CreateQueryLoggingConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostedZoneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53QueryLoggingConfig (CreateQueryLoggingConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.CreateQueryLoggingConfigResponse, NewR53QueryLoggingConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLogsLogGroupArn = this.CloudWatchLogsLogGroupArn;
            #if MODULAR
            if (this.CloudWatchLogsLogGroupArn == null && ParameterWasBound(nameof(this.CloudWatchLogsLogGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudWatchLogsLogGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.CreateQueryLoggingConfigRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.CloudWatchLogsLogGroupArn != null)
            {
                request.CloudWatchLogsLogGroupArn = cmdletContext.CloudWatchLogsLogGroupArn;
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
        
        private Amazon.Route53.Model.CreateQueryLoggingConfigResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateQueryLoggingConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateQueryLoggingConfig");
            try
            {
                #if DESKTOP
                return client.CreateQueryLoggingConfig(request);
                #elif CORECLR
                return client.CreateQueryLoggingConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public System.String CloudWatchLogsLogGroupArn { get; set; }
            public System.Func<Amazon.Route53.Model.CreateQueryLoggingConfigResponse, NewR53QueryLoggingConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
