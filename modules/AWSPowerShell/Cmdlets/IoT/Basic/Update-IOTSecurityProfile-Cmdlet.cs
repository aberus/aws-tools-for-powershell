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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a Device Defender security profile.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateSecurityProfile</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTSecurityProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateSecurityProfileResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateSecurityProfile API operation.", Operation = new[] {"UpdateSecurityProfile"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateSecurityProfileResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateSecurityProfileResponse",
        "This cmdlet returns an Amazon.IoT.Model.UpdateSecurityProfileResponse object containing multiple properties."
    )]
    public partial class UpdateIOTSecurityProfileCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalMetricsToRetainV2
        /// <summary>
        /// <para>
        /// <para>A list of metrics whose data is retained (stored). By default, data is retained for
        /// any metric used in the profile's behaviors, but it is also retained for any metric
        /// specified here. Can be used with custom metrics; cannot be used with dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.MetricToRetain[] AdditionalMetricsToRetainV2 { get; set; }
        #endregion
        
        #region Parameter AlertTarget
        /// <summary>
        /// <para>
        /// <para>Where the alerts are sent. (Alerts are always sent to the console.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlertTargets")]
        public System.Collections.Hashtable AlertTarget { get; set; }
        #endregion
        
        #region Parameter Behavior
        /// <summary>
        /// <para>
        /// <para>Specifies the behaviors that, when violated by a device (thing), cause an alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Behaviors")]
        public Amazon.IoT.Model.Behavior[] Behavior { get; set; }
        #endregion
        
        #region Parameter DeleteAdditionalMetricsToRetain
        /// <summary>
        /// <para>
        /// <para>If true, delete all <c>additionalMetricsToRetain</c> defined for this security profile.
        /// If any <c>additionalMetricsToRetain</c> are defined in the current invocation, an
        /// exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteAdditionalMetricsToRetain { get; set; }
        #endregion
        
        #region Parameter DeleteAlertTarget
        /// <summary>
        /// <para>
        /// <para>If true, delete all <c>alertTargets</c> defined for this security profile. If any
        /// <c>alertTargets</c> are defined in the current invocation, an exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteAlertTargets")]
        public System.Boolean? DeleteAlertTarget { get; set; }
        #endregion
        
        #region Parameter DeleteBehavior
        /// <summary>
        /// <para>
        /// <para>If true, delete all <c>behaviors</c> defined for this security profile. If any <c>behaviors</c>
        /// are defined in the current invocation, an exception occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteBehaviors")]
        public System.Boolean? DeleteBehavior { get; set; }
        #endregion
        
        #region Parameter DeleteMetricsExportConfig
        /// <summary>
        /// <para>
        /// <para>Set the value as true to delete metrics export related configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteMetricsExportConfig { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the security profile. A new version is generated whenever
        /// the security profile is updated. If you specify a value that is different from the
        /// actual version, a <c>VersionConflictException</c> is thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter MetricsExportConfig_MqttTopic
        /// <summary>
        /// <para>
        /// <para>The MQTT topic that Device Defender Detect should publish messages to for metrics
        /// export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsExportConfig_MqttTopic { get; set; }
        #endregion
        
        #region Parameter MetricsExportConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>This role ARN has permission to publish MQTT messages, after which Device Defender
        /// Detect can assume the role and publish messages on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsExportConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter SecurityProfileDescription
        /// <summary>
        /// <para>
        /// <para>A description of the security profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityProfileDescription { get; set; }
        #endregion
        
        #region Parameter SecurityProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the security profile you want to update.</para>
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
        public System.String SecurityProfileName { get; set; }
        #endregion
        
        #region Parameter AdditionalMetricsToRetain
        /// <summary>
        /// <para>
        /// <para><i>Please use <a>UpdateSecurityProfileRequest$additionalMetricsToRetainV2</a> instead.</i></para><para>A list of metrics whose data is retained (stored). By default, data is retained for
        /// any metric used in the profile's <c>behaviors</c>, but it is also retained for any
        /// metric specified here. Can be used with custom metrics; cannot be used with dimensions.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use additionalMetricsToRetainV2.")]
        public System.String[] AdditionalMetricsToRetain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateSecurityProfileResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateSecurityProfileResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecurityProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSecurityProfile (UpdateSecurityProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateSecurityProfileResponse, UpdateIOTSecurityProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalMetricsToRetain != null)
            {
                context.AdditionalMetricsToRetain = new List<System.String>(this.AdditionalMetricsToRetain);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalMetricsToRetainV2 != null)
            {
                context.AdditionalMetricsToRetainV2 = new List<Amazon.IoT.Model.MetricToRetain>(this.AdditionalMetricsToRetainV2);
            }
            if (this.AlertTarget != null)
            {
                context.AlertTarget = new Dictionary<System.String, Amazon.IoT.Model.AlertTarget>(StringComparer.Ordinal);
                foreach (var hashKey in this.AlertTarget.Keys)
                {
                    context.AlertTarget.Add((String)hashKey, (Amazon.IoT.Model.AlertTarget)(this.AlertTarget[hashKey]));
                }
            }
            if (this.Behavior != null)
            {
                context.Behavior = new List<Amazon.IoT.Model.Behavior>(this.Behavior);
            }
            context.DeleteAdditionalMetricsToRetain = this.DeleteAdditionalMetricsToRetain;
            context.DeleteAlertTarget = this.DeleteAlertTarget;
            context.DeleteBehavior = this.DeleteBehavior;
            context.DeleteMetricsExportConfig = this.DeleteMetricsExportConfig;
            context.ExpectedVersion = this.ExpectedVersion;
            context.MetricsExportConfig_MqttTopic = this.MetricsExportConfig_MqttTopic;
            context.MetricsExportConfig_RoleArn = this.MetricsExportConfig_RoleArn;
            context.SecurityProfileDescription = this.SecurityProfileDescription;
            context.SecurityProfileName = this.SecurityProfileName;
            #if MODULAR
            if (this.SecurityProfileName == null && ParameterWasBound(nameof(this.SecurityProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.UpdateSecurityProfileRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AdditionalMetricsToRetain != null)
            {
                request.AdditionalMetricsToRetain = cmdletContext.AdditionalMetricsToRetain;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AdditionalMetricsToRetainV2 != null)
            {
                request.AdditionalMetricsToRetainV2 = cmdletContext.AdditionalMetricsToRetainV2;
            }
            if (cmdletContext.AlertTarget != null)
            {
                request.AlertTargets = cmdletContext.AlertTarget;
            }
            if (cmdletContext.Behavior != null)
            {
                request.Behaviors = cmdletContext.Behavior;
            }
            if (cmdletContext.DeleteAdditionalMetricsToRetain != null)
            {
                request.DeleteAdditionalMetricsToRetain = cmdletContext.DeleteAdditionalMetricsToRetain.Value;
            }
            if (cmdletContext.DeleteAlertTarget != null)
            {
                request.DeleteAlertTargets = cmdletContext.DeleteAlertTarget.Value;
            }
            if (cmdletContext.DeleteBehavior != null)
            {
                request.DeleteBehaviors = cmdletContext.DeleteBehavior.Value;
            }
            if (cmdletContext.DeleteMetricsExportConfig != null)
            {
                request.DeleteMetricsExportConfig = cmdletContext.DeleteMetricsExportConfig.Value;
            }
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            
             // populate MetricsExportConfig
            var requestMetricsExportConfigIsNull = true;
            request.MetricsExportConfig = new Amazon.IoT.Model.MetricsExportConfig();
            System.String requestMetricsExportConfig_metricsExportConfig_MqttTopic = null;
            if (cmdletContext.MetricsExportConfig_MqttTopic != null)
            {
                requestMetricsExportConfig_metricsExportConfig_MqttTopic = cmdletContext.MetricsExportConfig_MqttTopic;
            }
            if (requestMetricsExportConfig_metricsExportConfig_MqttTopic != null)
            {
                request.MetricsExportConfig.MqttTopic = requestMetricsExportConfig_metricsExportConfig_MqttTopic;
                requestMetricsExportConfigIsNull = false;
            }
            System.String requestMetricsExportConfig_metricsExportConfig_RoleArn = null;
            if (cmdletContext.MetricsExportConfig_RoleArn != null)
            {
                requestMetricsExportConfig_metricsExportConfig_RoleArn = cmdletContext.MetricsExportConfig_RoleArn;
            }
            if (requestMetricsExportConfig_metricsExportConfig_RoleArn != null)
            {
                request.MetricsExportConfig.RoleArn = requestMetricsExportConfig_metricsExportConfig_RoleArn;
                requestMetricsExportConfigIsNull = false;
            }
             // determine if request.MetricsExportConfig should be set to null
            if (requestMetricsExportConfigIsNull)
            {
                request.MetricsExportConfig = null;
            }
            if (cmdletContext.SecurityProfileDescription != null)
            {
                request.SecurityProfileDescription = cmdletContext.SecurityProfileDescription;
            }
            if (cmdletContext.SecurityProfileName != null)
            {
                request.SecurityProfileName = cmdletContext.SecurityProfileName;
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
        
        private Amazon.IoT.Model.UpdateSecurityProfileResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateSecurityProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateSecurityProfile");
            try
            {
                #if DESKTOP
                return client.UpdateSecurityProfile(request);
                #elif CORECLR
                return client.UpdateSecurityProfileAsync(request).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public List<System.String> AdditionalMetricsToRetain { get; set; }
            public List<Amazon.IoT.Model.MetricToRetain> AdditionalMetricsToRetainV2 { get; set; }
            public Dictionary<System.String, Amazon.IoT.Model.AlertTarget> AlertTarget { get; set; }
            public List<Amazon.IoT.Model.Behavior> Behavior { get; set; }
            public System.Boolean? DeleteAdditionalMetricsToRetain { get; set; }
            public System.Boolean? DeleteAlertTarget { get; set; }
            public System.Boolean? DeleteBehavior { get; set; }
            public System.Boolean? DeleteMetricsExportConfig { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
            public System.String MetricsExportConfig_MqttTopic { get; set; }
            public System.String MetricsExportConfig_RoleArn { get; set; }
            public System.String SecurityProfileDescription { get; set; }
            public System.String SecurityProfileName { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateSecurityProfileResponse, UpdateIOTSecurityProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
