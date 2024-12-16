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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Creates a metric attribution. A metric attribution creates reports on the data that
    /// you import into Amazon Personalize. Depending on how you imported the data, you can
    /// view reports in Amazon CloudWatch or Amazon S3. For more information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/measuring-recommendation-impact.html">Measuring
    /// impact of recommendations</a>.
    /// </summary>
    [Cmdlet("New", "PERSMetricAttribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize CreateMetricAttribution API operation.", Operation = new[] {"CreateMetricAttribution"}, SelectReturnType = typeof(Amazon.Personalize.Model.CreateMetricAttributionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.CreateMetricAttributionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.CreateMetricAttributionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPERSMetricAttributionCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatasetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination dataset group for the metric attribution.</para>
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
        public System.String DatasetGroupArn { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Key Management Service (KMS) key that Amazon
        /// Personalize uses to encrypt or decrypt the input and output files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsOutputConfig_S3DataDestination_KmsKeyArn")]
        public System.String S3DataDestination_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>A list of metric attributes for the metric attribution. Each metric attribute specifies
        /// an event type to track and a function. Available functions are <c>SUM()</c> or <c>SAMPLECOUNT()</c>.
        /// For SUM() functions, provide the dataset type (either Interactions or Items) and column
        /// to sum as a parameter. For example SUM(Items.PRICE).</para>
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
        [Alias("Metrics")]
        public Amazon.Personalize.Model.MetricAttribute[] Metric { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the metric attribution.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_Path
        /// <summary>
        /// <para>
        /// <para>The file path of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsOutputConfig_S3DataDestination_Path")]
        public System.String S3DataDestination_Path { get; set; }
        #endregion
        
        #region Parameter MetricsOutputConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that has permissions to add
        /// data to your output Amazon S3 bucket and add metrics to Amazon CloudWatch. For more
        /// information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/measuring-recommendation-impact.html">Measuring
        /// impact of recommendations</a>.</para>
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
        public System.String MetricsOutputConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricAttributionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.CreateMetricAttributionResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.CreateMetricAttributionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricAttributionArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetGroupArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PERSMetricAttribution (CreateMetricAttribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.CreateMetricAttributionResponse, NewPERSMetricAttributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatasetGroupArn = this.DatasetGroupArn;
            #if MODULAR
            if (this.DatasetGroupArn == null && ParameterWasBound(nameof(this.DatasetGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metric != null)
            {
                context.Metric = new List<Amazon.Personalize.Model.MetricAttribute>(this.Metric);
            }
            #if MODULAR
            if (this.Metric == null && ParameterWasBound(nameof(this.Metric)))
            {
                WriteWarning("You are passing $null as a value for parameter Metric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricsOutputConfig_RoleArn = this.MetricsOutputConfig_RoleArn;
            #if MODULAR
            if (this.MetricsOutputConfig_RoleArn == null && ParameterWasBound(nameof(this.MetricsOutputConfig_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricsOutputConfig_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3DataDestination_KmsKeyArn = this.S3DataDestination_KmsKeyArn;
            context.S3DataDestination_Path = this.S3DataDestination_Path;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Personalize.Model.CreateMetricAttributionRequest();
            
            if (cmdletContext.DatasetGroupArn != null)
            {
                request.DatasetGroupArn = cmdletContext.DatasetGroupArn;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            
             // populate MetricsOutputConfig
            var requestMetricsOutputConfigIsNull = true;
            request.MetricsOutputConfig = new Amazon.Personalize.Model.MetricAttributionOutput();
            System.String requestMetricsOutputConfig_metricsOutputConfig_RoleArn = null;
            if (cmdletContext.MetricsOutputConfig_RoleArn != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_RoleArn = cmdletContext.MetricsOutputConfig_RoleArn;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_RoleArn != null)
            {
                request.MetricsOutputConfig.RoleArn = requestMetricsOutputConfig_metricsOutputConfig_RoleArn;
                requestMetricsOutputConfigIsNull = false;
            }
            Amazon.Personalize.Model.S3DataConfig requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination = null;
            
             // populate S3DataDestination
            var requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull = true;
            requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination = new Amazon.Personalize.Model.S3DataConfig();
            System.String requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn = null;
            if (cmdletContext.S3DataDestination_KmsKeyArn != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn = cmdletContext.S3DataDestination_KmsKeyArn;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination.KmsKeyArn = requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_KmsKeyArn;
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull = false;
            }
            System.String requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path = null;
            if (cmdletContext.S3DataDestination_Path != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path = cmdletContext.S3DataDestination_Path;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path != null)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination.Path = requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination_s3DataDestination_Path;
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull = false;
            }
             // determine if requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination should be set to null
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestinationIsNull)
            {
                requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination = null;
            }
            if (requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination != null)
            {
                request.MetricsOutputConfig.S3DataDestination = requestMetricsOutputConfig_metricsOutputConfig_S3DataDestination;
                requestMetricsOutputConfigIsNull = false;
            }
             // determine if request.MetricsOutputConfig should be set to null
            if (requestMetricsOutputConfigIsNull)
            {
                request.MetricsOutputConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Personalize.Model.CreateMetricAttributionResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.CreateMetricAttributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "CreateMetricAttribution");
            try
            {
                #if DESKTOP
                return client.CreateMetricAttribution(request);
                #elif CORECLR
                return client.CreateMetricAttributionAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetGroupArn { get; set; }
            public List<Amazon.Personalize.Model.MetricAttribute> Metric { get; set; }
            public System.String MetricsOutputConfig_RoleArn { get; set; }
            public System.String S3DataDestination_KmsKeyArn { get; set; }
            public System.String S3DataDestination_Path { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Personalize.Model.CreateMetricAttributionResponse, NewPERSMetricAttributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricAttributionArn;
        }
        
    }
}
