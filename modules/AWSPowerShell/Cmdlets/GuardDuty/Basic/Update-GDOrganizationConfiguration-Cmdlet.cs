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
    /// Updates the delegated administrator account with the values provided.
    /// 
    ///  
    /// <para>
    /// There might be regional differences because some data sources might not be available
    /// in all the Amazon Web Services Regions where GuardDuty is presently supported. For
    /// more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/guardduty_regions.html">Regions
    /// and endpoints</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GDOrganizationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon GuardDuty UpdateOrganizationConfiguration API operation.", Operation = new[] {"UpdateOrganizationConfiguration"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.UpdateOrganizationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.GuardDuty.Model.UpdateOrganizationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.GuardDuty.Model.UpdateOrganizationConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGDOrganizationConfigurationCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        #region Parameter AutoEnable
        /// <summary>
        /// <para>
        /// <para>Indicates whether to automatically enable member accounts in the organization.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AutoEnable { get; set; }
        #endregion
        
        #region Parameter AuditLogs_AutoEnable
        /// <summary>
        /// <para>
        /// <para>A value that contains information on whether Kubernetes audit logs should be enabled
        /// automatically as a data source for the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_Kubernetes_AuditLogs_AutoEnable")]
        public System.Boolean? AuditLogs_AutoEnable { get; set; }
        #endregion
        
        #region Parameter EbsVolumes_AutoEnable
        /// <summary>
        /// <para>
        /// <para>Whether scanning EBS volumes should be auto-enabled for new members joining the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes_AutoEnable")]
        public System.Boolean? EbsVolumes_AutoEnable { get; set; }
        #endregion
        
        #region Parameter S3Logs_AutoEnable
        /// <summary>
        /// <para>
        /// <para>A value that contains information on whether S3 data event logs will be enabled automatically
        /// as a data source for the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_S3Logs_AutoEnable")]
        public System.Boolean? S3Logs_AutoEnable { get; set; }
        #endregion
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The ID of the detector to update the delegated administrator for.</para>
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
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>A list of features that will be configured for the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Features")]
        public Amazon.GuardDuty.Model.OrganizationFeatureConfiguration[] Feature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.UpdateOrganizationConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DetectorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DetectorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DetectorId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GDOrganizationConfiguration (UpdateOrganizationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.UpdateOrganizationConfigurationResponse, UpdateGDOrganizationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DetectorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoEnable = this.AutoEnable;
            #if MODULAR
            if (this.AutoEnable == null && ParameterWasBound(nameof(this.AutoEnable)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoEnable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuditLogs_AutoEnable = this.AuditLogs_AutoEnable;
            context.EbsVolumes_AutoEnable = this.EbsVolumes_AutoEnable;
            context.S3Logs_AutoEnable = this.S3Logs_AutoEnable;
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Feature != null)
            {
                context.Feature = new List<Amazon.GuardDuty.Model.OrganizationFeatureConfiguration>(this.Feature);
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
            var request = new Amazon.GuardDuty.Model.UpdateOrganizationConfigurationRequest();
            
            if (cmdletContext.AutoEnable != null)
            {
                request.AutoEnable = cmdletContext.AutoEnable.Value;
            }
            
             // populate DataSources
            var requestDataSourcesIsNull = true;
            request.DataSources = new Amazon.GuardDuty.Model.OrganizationDataSourceConfigurations();
            Amazon.GuardDuty.Model.OrganizationKubernetesConfiguration requestDataSources_dataSources_Kubernetes = null;
            
             // populate Kubernetes
            var requestDataSources_dataSources_KubernetesIsNull = true;
            requestDataSources_dataSources_Kubernetes = new Amazon.GuardDuty.Model.OrganizationKubernetesConfiguration();
            Amazon.GuardDuty.Model.OrganizationKubernetesAuditLogsConfiguration requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = null;
            
             // populate AuditLogs
            var requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogsIsNull = true;
            requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = new Amazon.GuardDuty.Model.OrganizationKubernetesAuditLogsConfiguration();
            System.Boolean? requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_AutoEnable = null;
            if (cmdletContext.AuditLogs_AutoEnable != null)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_AutoEnable = cmdletContext.AuditLogs_AutoEnable.Value;
            }
            if (requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_AutoEnable != null)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs.AutoEnable = requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_AutoEnable.Value;
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
            Amazon.GuardDuty.Model.OrganizationMalwareProtectionConfiguration requestDataSources_dataSources_MalwareProtection = null;
            
             // populate MalwareProtection
            var requestDataSources_dataSources_MalwareProtectionIsNull = true;
            requestDataSources_dataSources_MalwareProtection = new Amazon.GuardDuty.Model.OrganizationMalwareProtectionConfiguration();
            Amazon.GuardDuty.Model.OrganizationScanEc2InstanceWithFindings requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = null;
            
             // populate ScanEc2InstanceWithFindings
            var requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindingsIsNull = true;
            requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = new Amazon.GuardDuty.Model.OrganizationScanEc2InstanceWithFindings();
            Amazon.GuardDuty.Model.OrganizationEbsVolumes requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes = null;
            
             // populate EbsVolumes
            var requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumesIsNull = true;
            requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes = new Amazon.GuardDuty.Model.OrganizationEbsVolumes();
            System.Boolean? requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes_ebsVolumes_AutoEnable = null;
            if (cmdletContext.EbsVolumes_AutoEnable != null)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes_ebsVolumes_AutoEnable = cmdletContext.EbsVolumes_AutoEnable.Value;
            }
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes_ebsVolumes_AutoEnable != null)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes.AutoEnable = requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes_ebsVolumes_AutoEnable.Value;
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumesIsNull = false;
            }
             // determine if requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes should be set to null
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumesIsNull)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes = null;
            }
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes != null)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings.EbsVolumes = requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes;
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
            Amazon.GuardDuty.Model.OrganizationS3LogsConfiguration requestDataSources_dataSources_S3Logs = null;
            
             // populate S3Logs
            var requestDataSources_dataSources_S3LogsIsNull = true;
            requestDataSources_dataSources_S3Logs = new Amazon.GuardDuty.Model.OrganizationS3LogsConfiguration();
            System.Boolean? requestDataSources_dataSources_S3Logs_s3Logs_AutoEnable = null;
            if (cmdletContext.S3Logs_AutoEnable != null)
            {
                requestDataSources_dataSources_S3Logs_s3Logs_AutoEnable = cmdletContext.S3Logs_AutoEnable.Value;
            }
            if (requestDataSources_dataSources_S3Logs_s3Logs_AutoEnable != null)
            {
                requestDataSources_dataSources_S3Logs.AutoEnable = requestDataSources_dataSources_S3Logs_s3Logs_AutoEnable.Value;
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
            if (cmdletContext.Feature != null)
            {
                request.Features = cmdletContext.Feature;
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
        
        private Amazon.GuardDuty.Model.UpdateOrganizationConfigurationResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.UpdateOrganizationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "UpdateOrganizationConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateOrganizationConfiguration(request);
                #elif CORECLR
                return client.UpdateOrganizationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AutoEnable { get; set; }
            public System.Boolean? AuditLogs_AutoEnable { get; set; }
            public System.Boolean? EbsVolumes_AutoEnable { get; set; }
            public System.Boolean? S3Logs_AutoEnable { get; set; }
            public System.String DetectorId { get; set; }
            public List<Amazon.GuardDuty.Model.OrganizationFeatureConfiguration> Feature { get; set; }
            public System.Func<Amazon.GuardDuty.Model.UpdateOrganizationConfigurationResponse, UpdateGDOrganizationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
