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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Creates or updates a destination to receive extended metrics from CloudWatch RUM.
    /// You can send extended metrics to CloudWatch or to a CloudWatch Evidently experiment.
    /// 
    ///  
    /// <para>
    /// For more information about extended metrics, see <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_BatchCreateRumMetricDefinitions.html">BatchCreateRumMetricDefinitions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWRUMRumMetricsDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CloudWatch RUM PutRumMetricsDestination API operation.", Operation = new[] {"PutRumMetricsDestination"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWRUMRumMetricsDestinationCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppMonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch RUM app monitor that will send the metrics.</para>
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
        public System.String AppMonitorName { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>Defines the destination to send the metrics to. Valid values are <c>CloudWatch</c>
        /// and <c>Evidently</c>. If you specify <c>Evidently</c>, you must also specify the ARN
        /// of the CloudWatchEvidently experiment that is to be the destination and an IAM role
        /// that has permission to write to the experiment.</para>
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
        /// <para>Use this parameter only if <c>Destination</c> is <c>Evidently</c>. This parameter
        /// specifies the ARN of the Evidently experiment that will receive the extended metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>This parameter is required if <c>Destination</c> is <c>Evidently</c>. If <c>Destination</c>
        /// is <c>CloudWatch</c>, don't use this parameter.</para><para>This parameter specifies the ARN of an IAM role that RUM will assume to write to the
        /// Evidently experiment that you are sending metrics to. This role must have permission
        /// to write to that experiment.</para><para>If you specify this parameter, you must be signed on to a role that has <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_use_passrole.html">PassRole</a>
        /// permissions attached to it, to allow the role to be passed. The <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/auth-and-access-control-cw.html#managed-policies-cloudwatch-RUM">
        /// CloudWatchAmazonCloudWatchRUMFullAccess</a> policy doesn't include <c>PassRole</c>
        /// permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppMonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWRUMRumMetricsDestination (PutRumMetricsDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationResponse, WriteCWRUMRumMetricsDestinationCmdlet>(Select) ??
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
            context.IamRoleArn = this.IamRoleArn;
            
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
            var request = new Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationRequest();
            
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
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
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
        
        private Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "PutRumMetricsDestination");
            try
            {
                return client.PutRumMetricsDestinationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IamRoleArn { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.PutRumMetricsDestinationResponse, WriteCWRUMRumMetricsDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
