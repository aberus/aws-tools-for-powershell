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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Update an existing workload.
    /// </summary>
    [Cmdlet("Update", "WATWorkload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.Workload")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool UpdateWorkload API operation.", Operation = new[] {"UpdateWorkload"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.UpdateWorkloadResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.Workload or Amazon.WellArchitected.Model.UpdateWorkloadResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.Workload object.",
        "The service call response (type Amazon.WellArchitected.Model.UpdateWorkloadResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWATWorkloadCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>List of AppRegistry application ARNs to associate to the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Applications")]
        public System.String[] Application { get; set; }
        #endregion
        
        #region Parameter ArchitecturalDesign
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArchitecturalDesign { get; set; }
        #endregion
        
        #region Parameter AwsRegion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsRegions")]
        public System.String[] AwsRegion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.WorkloadEnvironment")]
        public Amazon.WellArchitected.WorkloadEnvironment Environment { get; set; }
        #endregion
        
        #region Parameter ImprovementStatus
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.WorkloadImprovementStatus")]
        public Amazon.WellArchitected.WorkloadImprovementStatus ImprovementStatus { get; set; }
        #endregion
        
        #region Parameter Industry
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Industry { get; set; }
        #endregion
        
        #region Parameter IndustryType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndustryType { get; set; }
        #endregion
        
        #region Parameter IsReviewOwnerUpdateAcknowledged
        /// <summary>
        /// <para>
        /// <para>Flag indicating whether the workload owner has acknowledged that the <i>Review owner</i>
        /// field is required.</para><para>If a <b>Review owner</b> is not added to the workload within 60 days of acknowledgement,
        /// access to the workload is restricted until an owner is added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsReviewOwnerUpdateAcknowledged { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_IssueManagementStatus
        /// <summary>
        /// <para>
        /// <para>Workload-level: Jira issue management status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.WorkloadIssueManagementStatus")]
        public Amazon.WellArchitected.WorkloadIssueManagementStatus JiraConfiguration_IssueManagementStatus { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_IssueManagementType
        /// <summary>
        /// <para>
        /// <para>Workload-level: Jira issue management type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.IssueManagementType")]
        public Amazon.WellArchitected.IssueManagementType JiraConfiguration_IssueManagementType { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_JiraProjectKey
        /// <summary>
        /// <para>
        /// <para>Workload-level: Jira project key to sync workloads to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JiraConfiguration_JiraProjectKey { get; set; }
        #endregion
        
        #region Parameter NonAwsRegion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NonAwsRegions")]
        public System.String[] NonAwsRegion { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter PillarPriority
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PillarPriorities")]
        public System.String[] PillarPriority { get; set; }
        #endregion
        
        #region Parameter ReviewOwner
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReviewOwner { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfig_TrustedAdvisorIntegrationStatus
        /// <summary>
        /// <para>
        /// <para>Discovery integration status in respect to Trusted Advisor for the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.TrustedAdvisorIntegrationStatus")]
        public Amazon.WellArchitected.TrustedAdvisorIntegrationStatus DiscoveryConfig_TrustedAdvisorIntegrationStatus { get; set; }
        #endregion
        
        #region Parameter WorkloadId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String WorkloadId { get; set; }
        #endregion
        
        #region Parameter WorkloadName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkloadName { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfig_WorkloadResourceDefinition
        /// <summary>
        /// <para>
        /// <para>The mode to use for identifying resources associated with the workload.</para><para>You can specify <c>WORKLOAD_METADATA</c>, <c>APP_REGISTRY</c>, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DiscoveryConfig_WorkloadResourceDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workload'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.UpdateWorkloadResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.UpdateWorkloadResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workload";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkloadId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WATWorkload (UpdateWorkload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.UpdateWorkloadResponse, UpdateWATWorkloadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            if (this.Application != null)
            {
                context.Application = new List<System.String>(this.Application);
            }
            context.ArchitecturalDesign = this.ArchitecturalDesign;
            if (this.AwsRegion != null)
            {
                context.AwsRegion = new List<System.String>(this.AwsRegion);
            }
            context.Description = this.Description;
            context.DiscoveryConfig_TrustedAdvisorIntegrationStatus = this.DiscoveryConfig_TrustedAdvisorIntegrationStatus;
            if (this.DiscoveryConfig_WorkloadResourceDefinition != null)
            {
                context.DiscoveryConfig_WorkloadResourceDefinition = new List<System.String>(this.DiscoveryConfig_WorkloadResourceDefinition);
            }
            context.Environment = this.Environment;
            context.ImprovementStatus = this.ImprovementStatus;
            context.Industry = this.Industry;
            context.IndustryType = this.IndustryType;
            context.IsReviewOwnerUpdateAcknowledged = this.IsReviewOwnerUpdateAcknowledged;
            context.JiraConfiguration_IssueManagementStatus = this.JiraConfiguration_IssueManagementStatus;
            context.JiraConfiguration_IssueManagementType = this.JiraConfiguration_IssueManagementType;
            context.JiraConfiguration_JiraProjectKey = this.JiraConfiguration_JiraProjectKey;
            if (this.NonAwsRegion != null)
            {
                context.NonAwsRegion = new List<System.String>(this.NonAwsRegion);
            }
            context.Note = this.Note;
            if (this.PillarPriority != null)
            {
                context.PillarPriority = new List<System.String>(this.PillarPriority);
            }
            context.ReviewOwner = this.ReviewOwner;
            context.WorkloadId = this.WorkloadId;
            #if MODULAR
            if (this.WorkloadId == null && ParameterWasBound(nameof(this.WorkloadId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkloadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkloadName = this.WorkloadName;
            
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
            var request = new Amazon.WellArchitected.Model.UpdateWorkloadRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.Application != null)
            {
                request.Applications = cmdletContext.Application;
            }
            if (cmdletContext.ArchitecturalDesign != null)
            {
                request.ArchitecturalDesign = cmdletContext.ArchitecturalDesign;
            }
            if (cmdletContext.AwsRegion != null)
            {
                request.AwsRegions = cmdletContext.AwsRegion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DiscoveryConfig
            var requestDiscoveryConfigIsNull = true;
            request.DiscoveryConfig = new Amazon.WellArchitected.Model.WorkloadDiscoveryConfig();
            Amazon.WellArchitected.TrustedAdvisorIntegrationStatus requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus = null;
            if (cmdletContext.DiscoveryConfig_TrustedAdvisorIntegrationStatus != null)
            {
                requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus = cmdletContext.DiscoveryConfig_TrustedAdvisorIntegrationStatus;
            }
            if (requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus != null)
            {
                request.DiscoveryConfig.TrustedAdvisorIntegrationStatus = requestDiscoveryConfig_discoveryConfig_TrustedAdvisorIntegrationStatus;
                requestDiscoveryConfigIsNull = false;
            }
            List<System.String> requestDiscoveryConfig_discoveryConfig_WorkloadResourceDefinition = null;
            if (cmdletContext.DiscoveryConfig_WorkloadResourceDefinition != null)
            {
                requestDiscoveryConfig_discoveryConfig_WorkloadResourceDefinition = cmdletContext.DiscoveryConfig_WorkloadResourceDefinition;
            }
            if (requestDiscoveryConfig_discoveryConfig_WorkloadResourceDefinition != null)
            {
                request.DiscoveryConfig.WorkloadResourceDefinition = requestDiscoveryConfig_discoveryConfig_WorkloadResourceDefinition;
                requestDiscoveryConfigIsNull = false;
            }
             // determine if request.DiscoveryConfig should be set to null
            if (requestDiscoveryConfigIsNull)
            {
                request.DiscoveryConfig = null;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.ImprovementStatus != null)
            {
                request.ImprovementStatus = cmdletContext.ImprovementStatus;
            }
            if (cmdletContext.Industry != null)
            {
                request.Industry = cmdletContext.Industry;
            }
            if (cmdletContext.IndustryType != null)
            {
                request.IndustryType = cmdletContext.IndustryType;
            }
            if (cmdletContext.IsReviewOwnerUpdateAcknowledged != null)
            {
                request.IsReviewOwnerUpdateAcknowledged = cmdletContext.IsReviewOwnerUpdateAcknowledged.Value;
            }
            
             // populate JiraConfiguration
            var requestJiraConfigurationIsNull = true;
            request.JiraConfiguration = new Amazon.WellArchitected.Model.WorkloadJiraConfigurationInput();
            Amazon.WellArchitected.WorkloadIssueManagementStatus requestJiraConfiguration_jiraConfiguration_IssueManagementStatus = null;
            if (cmdletContext.JiraConfiguration_IssueManagementStatus != null)
            {
                requestJiraConfiguration_jiraConfiguration_IssueManagementStatus = cmdletContext.JiraConfiguration_IssueManagementStatus;
            }
            if (requestJiraConfiguration_jiraConfiguration_IssueManagementStatus != null)
            {
                request.JiraConfiguration.IssueManagementStatus = requestJiraConfiguration_jiraConfiguration_IssueManagementStatus;
                requestJiraConfigurationIsNull = false;
            }
            Amazon.WellArchitected.IssueManagementType requestJiraConfiguration_jiraConfiguration_IssueManagementType = null;
            if (cmdletContext.JiraConfiguration_IssueManagementType != null)
            {
                requestJiraConfiguration_jiraConfiguration_IssueManagementType = cmdletContext.JiraConfiguration_IssueManagementType;
            }
            if (requestJiraConfiguration_jiraConfiguration_IssueManagementType != null)
            {
                request.JiraConfiguration.IssueManagementType = requestJiraConfiguration_jiraConfiguration_IssueManagementType;
                requestJiraConfigurationIsNull = false;
            }
            System.String requestJiraConfiguration_jiraConfiguration_JiraProjectKey = null;
            if (cmdletContext.JiraConfiguration_JiraProjectKey != null)
            {
                requestJiraConfiguration_jiraConfiguration_JiraProjectKey = cmdletContext.JiraConfiguration_JiraProjectKey;
            }
            if (requestJiraConfiguration_jiraConfiguration_JiraProjectKey != null)
            {
                request.JiraConfiguration.JiraProjectKey = requestJiraConfiguration_jiraConfiguration_JiraProjectKey;
                requestJiraConfigurationIsNull = false;
            }
             // determine if request.JiraConfiguration should be set to null
            if (requestJiraConfigurationIsNull)
            {
                request.JiraConfiguration = null;
            }
            if (cmdletContext.NonAwsRegion != null)
            {
                request.NonAwsRegions = cmdletContext.NonAwsRegion;
            }
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
            }
            if (cmdletContext.PillarPriority != null)
            {
                request.PillarPriorities = cmdletContext.PillarPriority;
            }
            if (cmdletContext.ReviewOwner != null)
            {
                request.ReviewOwner = cmdletContext.ReviewOwner;
            }
            if (cmdletContext.WorkloadId != null)
            {
                request.WorkloadId = cmdletContext.WorkloadId;
            }
            if (cmdletContext.WorkloadName != null)
            {
                request.WorkloadName = cmdletContext.WorkloadName;
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
        
        private Amazon.WellArchitected.Model.UpdateWorkloadResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.UpdateWorkloadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "UpdateWorkload");
            try
            {
                #if DESKTOP
                return client.UpdateWorkload(request);
                #elif CORECLR
                return client.UpdateWorkloadAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public List<System.String> Application { get; set; }
            public System.String ArchitecturalDesign { get; set; }
            public List<System.String> AwsRegion { get; set; }
            public System.String Description { get; set; }
            public Amazon.WellArchitected.TrustedAdvisorIntegrationStatus DiscoveryConfig_TrustedAdvisorIntegrationStatus { get; set; }
            public List<System.String> DiscoveryConfig_WorkloadResourceDefinition { get; set; }
            public Amazon.WellArchitected.WorkloadEnvironment Environment { get; set; }
            public Amazon.WellArchitected.WorkloadImprovementStatus ImprovementStatus { get; set; }
            public System.String Industry { get; set; }
            public System.String IndustryType { get; set; }
            public System.Boolean? IsReviewOwnerUpdateAcknowledged { get; set; }
            public Amazon.WellArchitected.WorkloadIssueManagementStatus JiraConfiguration_IssueManagementStatus { get; set; }
            public Amazon.WellArchitected.IssueManagementType JiraConfiguration_IssueManagementType { get; set; }
            public System.String JiraConfiguration_JiraProjectKey { get; set; }
            public List<System.String> NonAwsRegion { get; set; }
            public System.String Note { get; set; }
            public List<System.String> PillarPriority { get; set; }
            public System.String ReviewOwner { get; set; }
            public System.String WorkloadId { get; set; }
            public System.String WorkloadName { get; set; }
            public System.Func<Amazon.WellArchitected.Model.UpdateWorkloadResponse, UpdateWATWorkloadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workload;
        }
        
    }
}
