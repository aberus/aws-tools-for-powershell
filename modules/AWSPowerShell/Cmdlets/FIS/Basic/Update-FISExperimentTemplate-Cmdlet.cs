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
using Amazon.FIS;
using Amazon.FIS.Model;

namespace Amazon.PowerShell.Cmdlets.FIS
{
    /// <summary>
    /// Updates the specified experiment template.
    /// </summary>
    [Cmdlet("Update", "FISExperimentTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FIS.Model.ExperimentTemplate")]
    [AWSCmdlet("Calls the AWS Fault Injection Simulator UpdateExperimentTemplate API operation.", Operation = new[] {"UpdateExperimentTemplate"}, SelectReturnType = typeof(Amazon.FIS.Model.UpdateExperimentTemplateResponse))]
    [AWSCmdletOutput("Amazon.FIS.Model.ExperimentTemplate or Amazon.FIS.Model.UpdateExperimentTemplateResponse",
        "This cmdlet returns an Amazon.FIS.Model.ExperimentTemplate object.",
        "The service call response (type Amazon.FIS.Model.UpdateExperimentTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFISExperimentTemplateCmdlet : AmazonFISClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions for the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public System.Collections.Hashtable Action { get; set; }
        #endregion
        
        #region Parameter ExperimentReportConfiguration_Outputs_S3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where the experiment report will be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentReportConfiguration_Outputs_S3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the destination bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3Configuration_BucketName")]
        public System.String S3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter DataSources_CloudWatchDashboard
        /// <summary>
        /// <para>
        /// <para>The CloudWatch dashboards to include as data sources in the experiment report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperimentReportConfiguration_DataSources_CloudWatchDashboards")]
        public Amazon.FIS.Model.ReportConfigurationCloudWatchDashboardInput[] DataSources_CloudWatchDashboard { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExperimentOptions_EmptyTargetResolutionMode
        /// <summary>
        /// <para>
        /// <para>The empty target resolution mode of the experiment template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FIS.EmptyTargetResolutionMode")]
        public Amazon.FIS.EmptyTargetResolutionMode ExperimentOptions_EmptyTargetResolutionMode { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the experiment template.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsConfiguration_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination Amazon CloudWatch Logs log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_CloudWatchLogsConfiguration_LogGroupArn")]
        public System.String CloudWatchLogsConfiguration_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_LogSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LogConfiguration_LogSchemaVersion { get; set; }
        #endregion
        
        #region Parameter ExperimentReportConfiguration_PostExperimentDuration
        /// <summary>
        /// <para>
        /// <para>The duration after the experiment end time for the data sources to include in the
        /// report. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentReportConfiguration_PostExperimentDuration { get; set; }
        #endregion
        
        #region Parameter ExperimentReportConfiguration_PreExperimentDuration
        /// <summary>
        /// <para>
        /// <para>The duration before the experiment start time for the data sources to include in the
        /// report. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentReportConfiguration_PreExperimentDuration { get; set; }
        #endregion
        
        #region Parameter ExperimentReportConfiguration_Outputs_S3Configuration_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the S3 bucket where the experiment report will be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExperimentReportConfiguration_Outputs_S3Configuration_Prefix { get; set; }
        #endregion
        
        #region Parameter S3Configuration_Prefix
        /// <summary>
        /// <para>
        /// <para>The bucket prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3Configuration_Prefix")]
        public System.String S3Configuration_Prefix { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that grants the FIS service permission
        /// to perform service actions on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter StopCondition
        /// <summary>
        /// <para>
        /// <para>The stop conditions for the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StopConditions")]
        public Amazon.FIS.Model.UpdateExperimentTemplateStopConditionInput[] StopCondition { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets for the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public System.Collections.Hashtable Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExperimentTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FIS.Model.UpdateExperimentTemplateResponse).
        /// Specifying the name of a property of type Amazon.FIS.Model.UpdateExperimentTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExperimentTemplate";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FISExperimentTemplate (UpdateExperimentTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FIS.Model.UpdateExperimentTemplateResponse, UpdateFISExperimentTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new Dictionary<System.String, Amazon.FIS.Model.UpdateExperimentTemplateActionInputItem>(StringComparer.Ordinal);
                foreach (var hashKey in this.Action.Keys)
                {
                    context.Action.Add((String)hashKey, (Amazon.FIS.Model.UpdateExperimentTemplateActionInputItem)(this.Action[hashKey]));
                }
            }
            context.Description = this.Description;
            context.ExperimentOptions_EmptyTargetResolutionMode = this.ExperimentOptions_EmptyTargetResolutionMode;
            if (this.DataSources_CloudWatchDashboard != null)
            {
                context.DataSources_CloudWatchDashboard = new List<Amazon.FIS.Model.ReportConfigurationCloudWatchDashboardInput>(this.DataSources_CloudWatchDashboard);
            }
            context.ExperimentReportConfiguration_Outputs_S3Configuration_BucketName = this.ExperimentReportConfiguration_Outputs_S3Configuration_BucketName;
            context.ExperimentReportConfiguration_Outputs_S3Configuration_Prefix = this.ExperimentReportConfiguration_Outputs_S3Configuration_Prefix;
            context.ExperimentReportConfiguration_PostExperimentDuration = this.ExperimentReportConfiguration_PostExperimentDuration;
            context.ExperimentReportConfiguration_PreExperimentDuration = this.ExperimentReportConfiguration_PreExperimentDuration;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLogsConfiguration_LogGroupArn = this.CloudWatchLogsConfiguration_LogGroupArn;
            context.LogConfiguration_LogSchemaVersion = this.LogConfiguration_LogSchemaVersion;
            context.S3Configuration_BucketName = this.S3Configuration_BucketName;
            context.S3Configuration_Prefix = this.S3Configuration_Prefix;
            context.RoleArn = this.RoleArn;
            if (this.StopCondition != null)
            {
                context.StopCondition = new List<Amazon.FIS.Model.UpdateExperimentTemplateStopConditionInput>(this.StopCondition);
            }
            if (this.Target != null)
            {
                context.Target = new Dictionary<System.String, Amazon.FIS.Model.UpdateExperimentTemplateTargetInput>(StringComparer.Ordinal);
                foreach (var hashKey in this.Target.Keys)
                {
                    context.Target.Add((String)hashKey, (Amazon.FIS.Model.UpdateExperimentTemplateTargetInput)(this.Target[hashKey]));
                }
            }
            
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
            var request = new Amazon.FIS.Model.UpdateExperimentTemplateRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ExperimentOptions
            var requestExperimentOptionsIsNull = true;
            request.ExperimentOptions = new Amazon.FIS.Model.UpdateExperimentTemplateExperimentOptionsInput();
            Amazon.FIS.EmptyTargetResolutionMode requestExperimentOptions_experimentOptions_EmptyTargetResolutionMode = null;
            if (cmdletContext.ExperimentOptions_EmptyTargetResolutionMode != null)
            {
                requestExperimentOptions_experimentOptions_EmptyTargetResolutionMode = cmdletContext.ExperimentOptions_EmptyTargetResolutionMode;
            }
            if (requestExperimentOptions_experimentOptions_EmptyTargetResolutionMode != null)
            {
                request.ExperimentOptions.EmptyTargetResolutionMode = requestExperimentOptions_experimentOptions_EmptyTargetResolutionMode;
                requestExperimentOptionsIsNull = false;
            }
             // determine if request.ExperimentOptions should be set to null
            if (requestExperimentOptionsIsNull)
            {
                request.ExperimentOptions = null;
            }
            
             // populate ExperimentReportConfiguration
            var requestExperimentReportConfigurationIsNull = true;
            request.ExperimentReportConfiguration = new Amazon.FIS.Model.UpdateExperimentTemplateReportConfigurationInput();
            System.String requestExperimentReportConfiguration_experimentReportConfiguration_PostExperimentDuration = null;
            if (cmdletContext.ExperimentReportConfiguration_PostExperimentDuration != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_PostExperimentDuration = cmdletContext.ExperimentReportConfiguration_PostExperimentDuration;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_PostExperimentDuration != null)
            {
                request.ExperimentReportConfiguration.PostExperimentDuration = requestExperimentReportConfiguration_experimentReportConfiguration_PostExperimentDuration;
                requestExperimentReportConfigurationIsNull = false;
            }
            System.String requestExperimentReportConfiguration_experimentReportConfiguration_PreExperimentDuration = null;
            if (cmdletContext.ExperimentReportConfiguration_PreExperimentDuration != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_PreExperimentDuration = cmdletContext.ExperimentReportConfiguration_PreExperimentDuration;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_PreExperimentDuration != null)
            {
                request.ExperimentReportConfiguration.PreExperimentDuration = requestExperimentReportConfiguration_experimentReportConfiguration_PreExperimentDuration;
                requestExperimentReportConfigurationIsNull = false;
            }
            Amazon.FIS.Model.ExperimentTemplateReportConfigurationDataSourcesInput requestExperimentReportConfiguration_experimentReportConfiguration_DataSources = null;
            
             // populate DataSources
            var requestExperimentReportConfiguration_experimentReportConfiguration_DataSourcesIsNull = true;
            requestExperimentReportConfiguration_experimentReportConfiguration_DataSources = new Amazon.FIS.Model.ExperimentTemplateReportConfigurationDataSourcesInput();
            List<Amazon.FIS.Model.ReportConfigurationCloudWatchDashboardInput> requestExperimentReportConfiguration_experimentReportConfiguration_DataSources_dataSources_CloudWatchDashboard = null;
            if (cmdletContext.DataSources_CloudWatchDashboard != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_DataSources_dataSources_CloudWatchDashboard = cmdletContext.DataSources_CloudWatchDashboard;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_DataSources_dataSources_CloudWatchDashboard != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_DataSources.CloudWatchDashboards = requestExperimentReportConfiguration_experimentReportConfiguration_DataSources_dataSources_CloudWatchDashboard;
                requestExperimentReportConfiguration_experimentReportConfiguration_DataSourcesIsNull = false;
            }
             // determine if requestExperimentReportConfiguration_experimentReportConfiguration_DataSources should be set to null
            if (requestExperimentReportConfiguration_experimentReportConfiguration_DataSourcesIsNull)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_DataSources = null;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_DataSources != null)
            {
                request.ExperimentReportConfiguration.DataSources = requestExperimentReportConfiguration_experimentReportConfiguration_DataSources;
                requestExperimentReportConfigurationIsNull = false;
            }
            Amazon.FIS.Model.ExperimentTemplateReportConfigurationOutputsInput requestExperimentReportConfiguration_experimentReportConfiguration_Outputs = null;
            
             // populate Outputs
            var requestExperimentReportConfiguration_experimentReportConfiguration_OutputsIsNull = true;
            requestExperimentReportConfiguration_experimentReportConfiguration_Outputs = new Amazon.FIS.Model.ExperimentTemplateReportConfigurationOutputsInput();
            Amazon.FIS.Model.ReportConfigurationS3OutputInput requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration = null;
            
             // populate S3Configuration
            var requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3ConfigurationIsNull = true;
            requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration = new Amazon.FIS.Model.ReportConfigurationS3OutputInput();
            System.String requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_BucketName = null;
            if (cmdletContext.ExperimentReportConfiguration_Outputs_S3Configuration_BucketName != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_BucketName = cmdletContext.ExperimentReportConfiguration_Outputs_S3Configuration_BucketName;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_BucketName != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration.BucketName = requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_BucketName;
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3ConfigurationIsNull = false;
            }
            System.String requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_Prefix = null;
            if (cmdletContext.ExperimentReportConfiguration_Outputs_S3Configuration_Prefix != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_Prefix = cmdletContext.ExperimentReportConfiguration_Outputs_S3Configuration_Prefix;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_Prefix != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration.Prefix = requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration_experimentReportConfiguration_Outputs_S3Configuration_Prefix;
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3ConfigurationIsNull = false;
            }
             // determine if requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration should be set to null
            if (requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3ConfigurationIsNull)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration = null;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration != null)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs.S3Configuration = requestExperimentReportConfiguration_experimentReportConfiguration_Outputs_experimentReportConfiguration_Outputs_S3Configuration;
                requestExperimentReportConfiguration_experimentReportConfiguration_OutputsIsNull = false;
            }
             // determine if requestExperimentReportConfiguration_experimentReportConfiguration_Outputs should be set to null
            if (requestExperimentReportConfiguration_experimentReportConfiguration_OutputsIsNull)
            {
                requestExperimentReportConfiguration_experimentReportConfiguration_Outputs = null;
            }
            if (requestExperimentReportConfiguration_experimentReportConfiguration_Outputs != null)
            {
                request.ExperimentReportConfiguration.Outputs = requestExperimentReportConfiguration_experimentReportConfiguration_Outputs;
                requestExperimentReportConfigurationIsNull = false;
            }
             // determine if request.ExperimentReportConfiguration should be set to null
            if (requestExperimentReportConfigurationIsNull)
            {
                request.ExperimentReportConfiguration = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate LogConfiguration
            var requestLogConfigurationIsNull = true;
            request.LogConfiguration = new Amazon.FIS.Model.UpdateExperimentTemplateLogConfigurationInput();
            System.Int32? requestLogConfiguration_logConfiguration_LogSchemaVersion = null;
            if (cmdletContext.LogConfiguration_LogSchemaVersion != null)
            {
                requestLogConfiguration_logConfiguration_LogSchemaVersion = cmdletContext.LogConfiguration_LogSchemaVersion.Value;
            }
            if (requestLogConfiguration_logConfiguration_LogSchemaVersion != null)
            {
                request.LogConfiguration.LogSchemaVersion = requestLogConfiguration_logConfiguration_LogSchemaVersion.Value;
                requestLogConfigurationIsNull = false;
            }
            Amazon.FIS.Model.ExperimentTemplateCloudWatchLogsLogConfigurationInput requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration = null;
            
             // populate CloudWatchLogsConfiguration
            var requestLogConfiguration_logConfiguration_CloudWatchLogsConfigurationIsNull = true;
            requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration = new Amazon.FIS.Model.ExperimentTemplateCloudWatchLogsLogConfigurationInput();
            System.String requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogGroupArn = null;
            if (cmdletContext.CloudWatchLogsConfiguration_LogGroupArn != null)
            {
                requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogGroupArn = cmdletContext.CloudWatchLogsConfiguration_LogGroupArn;
            }
            if (requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogGroupArn != null)
            {
                requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration.LogGroupArn = requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration_cloudWatchLogsConfiguration_LogGroupArn;
                requestLogConfiguration_logConfiguration_CloudWatchLogsConfigurationIsNull = false;
            }
             // determine if requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration should be set to null
            if (requestLogConfiguration_logConfiguration_CloudWatchLogsConfigurationIsNull)
            {
                requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration = null;
            }
            if (requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration != null)
            {
                request.LogConfiguration.CloudWatchLogsConfiguration = requestLogConfiguration_logConfiguration_CloudWatchLogsConfiguration;
                requestLogConfigurationIsNull = false;
            }
            Amazon.FIS.Model.ExperimentTemplateS3LogConfigurationInput requestLogConfiguration_logConfiguration_S3Configuration = null;
            
             // populate S3Configuration
            var requestLogConfiguration_logConfiguration_S3ConfigurationIsNull = true;
            requestLogConfiguration_logConfiguration_S3Configuration = new Amazon.FIS.Model.ExperimentTemplateS3LogConfigurationInput();
            System.String requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_BucketName = null;
            if (cmdletContext.S3Configuration_BucketName != null)
            {
                requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_BucketName = cmdletContext.S3Configuration_BucketName;
            }
            if (requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_BucketName != null)
            {
                requestLogConfiguration_logConfiguration_S3Configuration.BucketName = requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_BucketName;
                requestLogConfiguration_logConfiguration_S3ConfigurationIsNull = false;
            }
            System.String requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_Prefix = null;
            if (cmdletContext.S3Configuration_Prefix != null)
            {
                requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_Prefix = cmdletContext.S3Configuration_Prefix;
            }
            if (requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_Prefix != null)
            {
                requestLogConfiguration_logConfiguration_S3Configuration.Prefix = requestLogConfiguration_logConfiguration_S3Configuration_s3Configuration_Prefix;
                requestLogConfiguration_logConfiguration_S3ConfigurationIsNull = false;
            }
             // determine if requestLogConfiguration_logConfiguration_S3Configuration should be set to null
            if (requestLogConfiguration_logConfiguration_S3ConfigurationIsNull)
            {
                requestLogConfiguration_logConfiguration_S3Configuration = null;
            }
            if (requestLogConfiguration_logConfiguration_S3Configuration != null)
            {
                request.LogConfiguration.S3Configuration = requestLogConfiguration_logConfiguration_S3Configuration;
                requestLogConfigurationIsNull = false;
            }
             // determine if request.LogConfiguration should be set to null
            if (requestLogConfigurationIsNull)
            {
                request.LogConfiguration = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.StopCondition != null)
            {
                request.StopConditions = cmdletContext.StopCondition;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.FIS.Model.UpdateExperimentTemplateResponse CallAWSServiceOperation(IAmazonFIS client, Amazon.FIS.Model.UpdateExperimentTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Fault Injection Simulator", "UpdateExperimentTemplate");
            try
            {
                return client.UpdateExperimentTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.FIS.Model.UpdateExperimentTemplateActionInputItem> Action { get; set; }
            public System.String Description { get; set; }
            public Amazon.FIS.EmptyTargetResolutionMode ExperimentOptions_EmptyTargetResolutionMode { get; set; }
            public List<Amazon.FIS.Model.ReportConfigurationCloudWatchDashboardInput> DataSources_CloudWatchDashboard { get; set; }
            public System.String ExperimentReportConfiguration_Outputs_S3Configuration_BucketName { get; set; }
            public System.String ExperimentReportConfiguration_Outputs_S3Configuration_Prefix { get; set; }
            public System.String ExperimentReportConfiguration_PostExperimentDuration { get; set; }
            public System.String ExperimentReportConfiguration_PreExperimentDuration { get; set; }
            public System.String Id { get; set; }
            public System.String CloudWatchLogsConfiguration_LogGroupArn { get; set; }
            public System.Int32? LogConfiguration_LogSchemaVersion { get; set; }
            public System.String S3Configuration_BucketName { get; set; }
            public System.String S3Configuration_Prefix { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.FIS.Model.UpdateExperimentTemplateStopConditionInput> StopCondition { get; set; }
            public Dictionary<System.String, Amazon.FIS.Model.UpdateExperimentTemplateTargetInput> Target { get; set; }
            public System.Func<Amazon.FIS.Model.UpdateExperimentTemplateResponse, UpdateFISExperimentTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExperimentTemplate;
        }
        
    }
}
