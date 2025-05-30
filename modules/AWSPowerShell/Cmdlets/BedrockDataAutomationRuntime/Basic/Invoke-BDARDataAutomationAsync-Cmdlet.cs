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
using Amazon.BedrockDataAutomationRuntime;
using Amazon.BedrockDataAutomationRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDAR
{
    /// <summary>
    /// Async API: Invoke data automation.
    /// </summary>
    [Cmdlet("Invoke", "BDARDataAutomationAsync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Runtime for Amazon Bedrock Data Automation InvokeDataAutomationAsync API operation.", Operation = new[] {"InvokeDataAutomationAsync"}, SelectReturnType = typeof(Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBDARDataAutomationAsyncCmdlet : AmazonBedrockDataAutomationRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Blueprint
        /// <summary>
        /// <para>
        /// <para>Blueprint list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Blueprints")]
        public Amazon.BedrockDataAutomationRuntime.Model.Blueprint[] Blueprint { get; set; }
        #endregion
        
        #region Parameter DataAutomationProfileArn
        /// <summary>
        /// <para>
        /// <para>Data automation profile ARN</para>
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
        public System.String DataAutomationProfileArn { get; set; }
        #endregion
        
        #region Parameter DataAutomationConfiguration_DataAutomationProjectArn
        /// <summary>
        /// <para>
        /// <para>Data automation project arn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataAutomationConfiguration_DataAutomationProjectArn { get; set; }
        #endregion
        
        #region Parameter TimestampSegment_EndTimeMilli
        /// <summary>
        /// <para>
        /// <para>End timestamp in milliseconds</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_EndTimeMillis")]
        public System.Int64? TimestampSegment_EndTimeMilli { get; set; }
        #endregion
        
        #region Parameter EventBridgeConfiguration_EventBridgeEnabled
        /// <summary>
        /// <para>
        /// <para>Event bridge flag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled")]
        public System.Boolean? EventBridgeConfiguration_EventBridgeEnabled { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsEncryptionContext
        /// <summary>
        /// <para>
        /// <para>KMS encryption context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KmsEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Customer KMS key used for encryption</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_S3Uri
        /// <summary>
        /// <para>
        /// <para>S3 uri.</para>
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
        public System.String InputConfiguration_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_S3Uri
        /// <summary>
        /// <para>
        /// <para>S3 uri.</para>
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
        public System.String OutputConfiguration_S3Uri { get; set; }
        #endregion
        
        #region Parameter DataAutomationConfiguration_Stage
        /// <summary>
        /// <para>
        /// <para>Data automation stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomationRuntime.DataAutomationStage")]
        public Amazon.BedrockDataAutomationRuntime.DataAutomationStage DataAutomationConfiguration_Stage { get; set; }
        #endregion
        
        #region Parameter TimestampSegment_StartTimeMilli
        /// <summary>
        /// <para>
        /// <para>Start timestamp in milliseconds</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_StartTimeMillis")]
        public System.Int64? TimestampSegment_StartTimeMilli { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.BedrockDataAutomationRuntime.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvocationArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataAutomationConfiguration_DataAutomationProjectArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDARDataAutomationAsync (InvokeDataAutomationAsync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse, InvokeBDARDataAutomationAsyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Blueprint != null)
            {
                context.Blueprint = new List<Amazon.BedrockDataAutomationRuntime.Model.Blueprint>(this.Blueprint);
            }
            context.ClientToken = this.ClientToken;
            context.DataAutomationConfiguration_DataAutomationProjectArn = this.DataAutomationConfiguration_DataAutomationProjectArn;
            context.DataAutomationConfiguration_Stage = this.DataAutomationConfiguration_Stage;
            context.DataAutomationProfileArn = this.DataAutomationProfileArn;
            #if MODULAR
            if (this.DataAutomationProfileArn == null && ParameterWasBound(nameof(this.DataAutomationProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAutomationProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                context.EncryptionConfiguration_KmsEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionConfiguration_KmsEncryptionContext.Keys)
                {
                    context.EncryptionConfiguration_KmsEncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionConfiguration_KmsEncryptionContext[hashKey]));
                }
            }
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.TimestampSegment_EndTimeMilli = this.TimestampSegment_EndTimeMilli;
            context.TimestampSegment_StartTimeMilli = this.TimestampSegment_StartTimeMilli;
            context.InputConfiguration_S3Uri = this.InputConfiguration_S3Uri;
            #if MODULAR
            if (this.InputConfiguration_S3Uri == null && ParameterWasBound(nameof(this.InputConfiguration_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfiguration_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventBridgeConfiguration_EventBridgeEnabled = this.EventBridgeConfiguration_EventBridgeEnabled;
            context.OutputConfiguration_S3Uri = this.OutputConfiguration_S3Uri;
            #if MODULAR
            if (this.OutputConfiguration_S3Uri == null && ParameterWasBound(nameof(this.OutputConfiguration_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfiguration_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.BedrockDataAutomationRuntime.Model.Tag>(this.Tag);
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
            var request = new Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncRequest();
            
            if (cmdletContext.Blueprint != null)
            {
                request.Blueprints = cmdletContext.Blueprint;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DataAutomationConfiguration
            var requestDataAutomationConfigurationIsNull = true;
            request.DataAutomationConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.DataAutomationConfiguration();
            System.String requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn = null;
            if (cmdletContext.DataAutomationConfiguration_DataAutomationProjectArn != null)
            {
                requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn = cmdletContext.DataAutomationConfiguration_DataAutomationProjectArn;
            }
            if (requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn != null)
            {
                request.DataAutomationConfiguration.DataAutomationProjectArn = requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn;
                requestDataAutomationConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomationRuntime.DataAutomationStage requestDataAutomationConfiguration_dataAutomationConfiguration_Stage = null;
            if (cmdletContext.DataAutomationConfiguration_Stage != null)
            {
                requestDataAutomationConfiguration_dataAutomationConfiguration_Stage = cmdletContext.DataAutomationConfiguration_Stage;
            }
            if (requestDataAutomationConfiguration_dataAutomationConfiguration_Stage != null)
            {
                request.DataAutomationConfiguration.Stage = requestDataAutomationConfiguration_dataAutomationConfiguration_Stage;
                requestDataAutomationConfigurationIsNull = false;
            }
             // determine if request.DataAutomationConfiguration should be set to null
            if (requestDataAutomationConfigurationIsNull)
            {
                request.DataAutomationConfiguration = null;
            }
            if (cmdletContext.DataAutomationProfileArn != null)
            {
                request.DataAutomationProfileArn = cmdletContext.DataAutomationProfileArn;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.EncryptionConfiguration();
            Dictionary<System.String, System.String> requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = null;
            if (cmdletContext.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = cmdletContext.EncryptionConfiguration_KmsEncryptionContext;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext != null)
            {
                request.EncryptionConfiguration.KmsEncryptionContext = requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate InputConfiguration
            var requestInputConfigurationIsNull = true;
            request.InputConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.InputConfiguration();
            System.String requestInputConfiguration_inputConfiguration_S3Uri = null;
            if (cmdletContext.InputConfiguration_S3Uri != null)
            {
                requestInputConfiguration_inputConfiguration_S3Uri = cmdletContext.InputConfiguration_S3Uri;
            }
            if (requestInputConfiguration_inputConfiguration_S3Uri != null)
            {
                request.InputConfiguration.S3Uri = requestInputConfiguration_inputConfiguration_S3Uri;
                requestInputConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomationRuntime.Model.AssetProcessingConfiguration requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration = null;
            
             // populate AssetProcessingConfiguration
            var requestInputConfiguration_inputConfiguration_AssetProcessingConfigurationIsNull = true;
            requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.AssetProcessingConfiguration();
            Amazon.BedrockDataAutomationRuntime.Model.VideoAssetProcessingConfiguration requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video = null;
            
             // populate Video
            var requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_VideoIsNull = true;
            requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video = new Amazon.BedrockDataAutomationRuntime.Model.VideoAssetProcessingConfiguration();
            Amazon.BedrockDataAutomationRuntime.Model.VideoSegmentConfiguration requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration = null;
            
             // populate SegmentConfiguration
            var requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfigurationIsNull = true;
            requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.VideoSegmentConfiguration();
            Amazon.BedrockDataAutomationRuntime.Model.TimestampSegment requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment = null;
            
             // populate TimestampSegment
            var requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegmentIsNull = true;
            requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment = new Amazon.BedrockDataAutomationRuntime.Model.TimestampSegment();
            System.Int64? requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_EndTimeMilli = null;
            if (cmdletContext.TimestampSegment_EndTimeMilli != null)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_EndTimeMilli = cmdletContext.TimestampSegment_EndTimeMilli.Value;
            }
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_EndTimeMilli != null)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment.EndTimeMillis = requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_EndTimeMilli.Value;
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegmentIsNull = false;
            }
            System.Int64? requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_StartTimeMilli = null;
            if (cmdletContext.TimestampSegment_StartTimeMilli != null)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_StartTimeMilli = cmdletContext.TimestampSegment_StartTimeMilli.Value;
            }
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_StartTimeMilli != null)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment.StartTimeMillis = requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment_timestampSegment_StartTimeMilli.Value;
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegmentIsNull = false;
            }
             // determine if requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment should be set to null
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegmentIsNull)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment = null;
            }
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment != null)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration.TimestampSegment = requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration_TimestampSegment;
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfigurationIsNull = false;
            }
             // determine if requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration should be set to null
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfigurationIsNull)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration = null;
            }
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration != null)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video.SegmentConfiguration = requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video_inputConfiguration_AssetProcessingConfiguration_Video_SegmentConfiguration;
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_VideoIsNull = false;
            }
             // determine if requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video should be set to null
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_VideoIsNull)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video = null;
            }
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video != null)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration.Video = requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration_inputConfiguration_AssetProcessingConfiguration_Video;
                requestInputConfiguration_inputConfiguration_AssetProcessingConfigurationIsNull = false;
            }
             // determine if requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration should be set to null
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfigurationIsNull)
            {
                requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration = null;
            }
            if (requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration != null)
            {
                request.InputConfiguration.AssetProcessingConfiguration = requestInputConfiguration_inputConfiguration_AssetProcessingConfiguration;
                requestInputConfigurationIsNull = false;
            }
             // determine if request.InputConfiguration should be set to null
            if (requestInputConfigurationIsNull)
            {
                request.InputConfiguration = null;
            }
            
             // populate NotificationConfiguration
            var requestNotificationConfigurationIsNull = true;
            request.NotificationConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.NotificationConfiguration();
            Amazon.BedrockDataAutomationRuntime.Model.EventBridgeConfiguration requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = null;
            
             // populate EventBridgeConfiguration
            var requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull = true;
            requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.EventBridgeConfiguration();
            System.Boolean? requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_eventBridgeConfiguration_EventBridgeEnabled = null;
            if (cmdletContext.EventBridgeConfiguration_EventBridgeEnabled != null)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_eventBridgeConfiguration_EventBridgeEnabled = cmdletContext.EventBridgeConfiguration_EventBridgeEnabled.Value;
            }
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_eventBridgeConfiguration_EventBridgeEnabled != null)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration.EventBridgeEnabled = requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_eventBridgeConfiguration_EventBridgeEnabled.Value;
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull = false;
            }
             // determine if requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration should be set to null
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = null;
            }
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration != null)
            {
                request.NotificationConfiguration.EventBridgeConfiguration = requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration;
                requestNotificationConfigurationIsNull = false;
            }
             // determine if request.NotificationConfiguration should be set to null
            if (requestNotificationConfigurationIsNull)
            {
                request.NotificationConfiguration = null;
            }
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.OutputConfiguration();
            System.String requestOutputConfiguration_outputConfiguration_S3Uri = null;
            if (cmdletContext.OutputConfiguration_S3Uri != null)
            {
                requestOutputConfiguration_outputConfiguration_S3Uri = cmdletContext.OutputConfiguration_S3Uri;
            }
            if (requestOutputConfiguration_outputConfiguration_S3Uri != null)
            {
                request.OutputConfiguration.S3Uri = requestOutputConfiguration_outputConfiguration_S3Uri;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse CallAWSServiceOperation(IAmazonBedrockDataAutomationRuntime client, Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Runtime for Amazon Bedrock Data Automation", "InvokeDataAutomationAsync");
            try
            {
                return client.InvokeDataAutomationAsyncAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockDataAutomationRuntime.Model.Blueprint> Blueprint { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DataAutomationConfiguration_DataAutomationProjectArn { get; set; }
            public Amazon.BedrockDataAutomationRuntime.DataAutomationStage DataAutomationConfiguration_Stage { get; set; }
            public System.String DataAutomationProfileArn { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public System.Int64? TimestampSegment_EndTimeMilli { get; set; }
            public System.Int64? TimestampSegment_StartTimeMilli { get; set; }
            public System.String InputConfiguration_S3Uri { get; set; }
            public System.Boolean? EventBridgeConfiguration_EventBridgeEnabled { get; set; }
            public System.String OutputConfiguration_S3Uri { get; set; }
            public List<Amazon.BedrockDataAutomationRuntime.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationAsyncResponse, InvokeBDARDataAutomationAsyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvocationArn;
        }
        
    }
}
