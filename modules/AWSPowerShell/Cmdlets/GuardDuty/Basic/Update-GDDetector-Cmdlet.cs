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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Updates the GuardDuty detector specified by the detector ID.
    /// 
    ///  
    /// <para>
    /// Specifying both EKS Runtime Monitoring (<c>EKS_RUNTIME_MONITORING</c>) and Runtime
    /// Monitoring (<c>RUNTIME_MONITORING</c>) will cause an error. You can add only one of
    /// these two features because Runtime Monitoring already includes the threat detection
    /// for Amazon EKS resources. For more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/runtime-monitoring.html">Runtime
    /// Monitoring</a>.
    /// </para><para>
    /// There might be regional differences because some data sources might not be available
    /// in all the Amazon Web Services Regions where GuardDuty is presently supported. For
    /// more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/guardduty_regions.html">Regions
    /// and endpoints</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GDDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon GuardDuty UpdateDetector API operation.", Operation = new[] {"UpdateDetector"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.UpdateDetectorResponse))]
    [AWSCmdletOutput("None or Amazon.GuardDuty.Model.UpdateDetectorResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.GuardDuty.Model.UpdateDetectorResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGDDetectorCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the detector to update.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter ScanEc2InstanceWithFindings_EbsVolume
        /// <summary>
        /// <para>
        /// <para>Describes the configuration for scanning EBS volumes as data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes")]
        public System.Boolean? ScanEc2InstanceWithFindings_EbsVolume { get; set; }
        #endregion
        
        #region Parameter AuditLogs_Enable
        /// <summary>
        /// <para>
        /// <para>The status of Kubernetes audit logs as a data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_Kubernetes_AuditLogs_Enable")]
        public System.Boolean? AuditLogs_Enable { get; set; }
        #endregion
        
        #region Parameter S3Logs_Enable
        /// <summary>
        /// <para>
        /// <para> The status of S3 data event logs as a data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_S3Logs_Enable")]
        public System.Boolean? S3Logs_Enable { get; set; }
        #endregion
        
        #region Parameter Enable
        /// <summary>
        /// <para>
        /// <para>Specifies whether the detector is enabled or not enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enable { get; set; }
        #endregion
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>Provides the features that will be updated for the detector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Features")]
        public Amazon.GuardDuty.Model.DetectorFeatureConfiguration[] Feature { get; set; }
        #endregion
        
        #region Parameter FindingPublishingFrequency
        /// <summary>
        /// <para>
        /// <para>An enum value that specifies how frequently findings are exported, such as to CloudWatch
        /// Events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GuardDuty.FindingPublishingFrequency")]
        public Amazon.GuardDuty.FindingPublishingFrequency FindingPublishingFrequency { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.UpdateDetectorResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GDDetector (UpdateDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.UpdateDetectorResponse, UpdateGDDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuditLogs_Enable = this.AuditLogs_Enable;
            context.ScanEc2InstanceWithFindings_EbsVolume = this.ScanEc2InstanceWithFindings_EbsVolume;
            context.S3Logs_Enable = this.S3Logs_Enable;
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Enable = this.Enable;
            if (this.Feature != null)
            {
                context.Feature = new List<Amazon.GuardDuty.Model.DetectorFeatureConfiguration>(this.Feature);
            }
            context.FindingPublishingFrequency = this.FindingPublishingFrequency;
            
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
            var request = new Amazon.GuardDuty.Model.UpdateDetectorRequest();
            
            
             // populate DataSources
            var requestDataSourcesIsNull = true;
            request.DataSources = new Amazon.GuardDuty.Model.DataSourceConfigurations();
            Amazon.GuardDuty.Model.KubernetesConfiguration requestDataSources_dataSources_Kubernetes = null;
            
             // populate Kubernetes
            var requestDataSources_dataSources_KubernetesIsNull = true;
            requestDataSources_dataSources_Kubernetes = new Amazon.GuardDuty.Model.KubernetesConfiguration();
            Amazon.GuardDuty.Model.KubernetesAuditLogsConfiguration requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = null;
            
             // populate AuditLogs
            var requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogsIsNull = true;
            requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = new Amazon.GuardDuty.Model.KubernetesAuditLogsConfiguration();
            System.Boolean? requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable = null;
            if (cmdletContext.AuditLogs_Enable != null)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable = cmdletContext.AuditLogs_Enable.Value;
            }
            if (requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable != null)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs.Enable = requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable.Value;
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogsIsNull = false;
            }
             // determine if requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs should be set to null
            if (requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogsIsNull)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = null;
            }
            if (requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs != null)
            {
                requestDataSources_dataSources_Kubernetes.AuditLogs = requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs;
                requestDataSources_dataSources_KubernetesIsNull = false;
            }
             // determine if requestDataSources_dataSources_Kubernetes should be set to null
            if (requestDataSources_dataSources_KubernetesIsNull)
            {
                requestDataSources_dataSources_Kubernetes = null;
            }
            if (requestDataSources_dataSources_Kubernetes != null)
            {
                request.DataSources.Kubernetes = requestDataSources_dataSources_Kubernetes;
                requestDataSourcesIsNull = false;
            }
            Amazon.GuardDuty.Model.MalwareProtectionConfiguration requestDataSources_dataSources_MalwareProtection = null;
            
             // populate MalwareProtection
            var requestDataSources_dataSources_MalwareProtectionIsNull = true;
            requestDataSources_dataSources_MalwareProtection = new Amazon.GuardDuty.Model.MalwareProtectionConfiguration();
            Amazon.GuardDuty.Model.ScanEc2InstanceWithFindings requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = null;
            
             // populate ScanEc2InstanceWithFindings
            var requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindingsIsNull = true;
            requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = new Amazon.GuardDuty.Model.ScanEc2InstanceWithFindings();
            System.Boolean? requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume = null;
            if (cmdletContext.ScanEc2InstanceWithFindings_EbsVolume != null)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume = cmdletContext.ScanEc2InstanceWithFindings_EbsVolume.Value;
            }
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume != null)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings.EbsVolumes = requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume.Value;
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindingsIsNull = false;
            }
             // determine if requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings should be set to null
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindingsIsNull)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = null;
            }
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings != null)
            {
                requestDataSources_dataSources_MalwareProtection.ScanEc2InstanceWithFindings = requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings;
                requestDataSources_dataSources_MalwareProtectionIsNull = false;
            }
             // determine if requestDataSources_dataSources_MalwareProtection should be set to null
            if (requestDataSources_dataSources_MalwareProtectionIsNull)
            {
                requestDataSources_dataSources_MalwareProtection = null;
            }
            if (requestDataSources_dataSources_MalwareProtection != null)
            {
                request.DataSources.MalwareProtection = requestDataSources_dataSources_MalwareProtection;
                requestDataSourcesIsNull = false;
            }
            Amazon.GuardDuty.Model.S3LogsConfiguration requestDataSources_dataSources_S3Logs = null;
            
             // populate S3Logs
            var requestDataSources_dataSources_S3LogsIsNull = true;
            requestDataSources_dataSources_S3Logs = new Amazon.GuardDuty.Model.S3LogsConfiguration();
            System.Boolean? requestDataSources_dataSources_S3Logs_s3Logs_Enable = null;
            if (cmdletContext.S3Logs_Enable != null)
            {
                requestDataSources_dataSources_S3Logs_s3Logs_Enable = cmdletContext.S3Logs_Enable.Value;
            }
            if (requestDataSources_dataSources_S3Logs_s3Logs_Enable != null)
            {
                requestDataSources_dataSources_S3Logs.Enable = requestDataSources_dataSources_S3Logs_s3Logs_Enable.Value;
                requestDataSources_dataSources_S3LogsIsNull = false;
            }
             // determine if requestDataSources_dataSources_S3Logs should be set to null
            if (requestDataSources_dataSources_S3LogsIsNull)
            {
                requestDataSources_dataSources_S3Logs = null;
            }
            if (requestDataSources_dataSources_S3Logs != null)
            {
                request.DataSources.S3Logs = requestDataSources_dataSources_S3Logs;
                requestDataSourcesIsNull = false;
            }
             // determine if request.DataSources should be set to null
            if (requestDataSourcesIsNull)
            {
                request.DataSources = null;
            }
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.Enable != null)
            {
                request.Enable = cmdletContext.Enable.Value;
            }
            if (cmdletContext.Feature != null)
            {
                request.Features = cmdletContext.Feature;
            }
            if (cmdletContext.FindingPublishingFrequency != null)
            {
                request.FindingPublishingFrequency = cmdletContext.FindingPublishingFrequency;
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
        
        private Amazon.GuardDuty.Model.UpdateDetectorResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.UpdateDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "UpdateDetector");
            try
            {
                #if DESKTOP
                return client.UpdateDetector(request);
                #elif CORECLR
                return client.UpdateDetectorAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AuditLogs_Enable { get; set; }
            public System.Boolean? ScanEc2InstanceWithFindings_EbsVolume { get; set; }
            public System.Boolean? S3Logs_Enable { get; set; }
            public System.String DetectorId { get; set; }
            public System.Boolean? Enable { get; set; }
            public List<Amazon.GuardDuty.Model.DetectorFeatureConfiguration> Feature { get; set; }
            public Amazon.GuardDuty.FindingPublishingFrequency FindingPublishingFrequency { get; set; }
            public System.Func<Amazon.GuardDuty.Model.UpdateDetectorResponse, UpdateGDDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
