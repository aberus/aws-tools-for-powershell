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
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

namespace Amazon.PowerShell.Cmdlets.MGRF
{
    /// <summary>
    /// Modifies an existing Amazon Managed Grafana workspace. If you use this operation and
    /// omit any optional parameters, the existing values of those parameters are not changed.
    /// 
    ///  
    /// <para>
    /// To modify the user authentication methods that the workspace uses, such as SAML or
    /// Amazon Web Services SSO, use <a href="https://docs.aws.amazon.com/grafana/latest/APIReference/API_UpdateWorkspaceAuthentication.html">UpdateWorkspaceAuthentication</a>.
    /// </para><para>
    /// To modify which users in the workspace have the <code>Admin</code> and <code>Editor</code>
    /// Grafana roles, use <a href="https://docs.aws.amazon.com/grafana/latest/APIReference/API_UpdatePermissions.html">UpdatePermissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MGRFWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ManagedGrafana.Model.WorkspaceDescription")]
    [AWSCmdlet("Calls the Amazon Managed Grafana UpdateWorkspace API operation.", Operation = new[] {"UpdateWorkspace"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse))]
    [AWSCmdletOutput("Amazon.ManagedGrafana.Model.WorkspaceDescription or Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse",
        "This cmdlet returns an Amazon.ManagedGrafana.Model.WorkspaceDescription object.",
        "The service call response (type Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMGRFWorkspaceCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        #region Parameter AccountAccessType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the workspace can access Amazon Web Services resources in this Amazon
        /// Web Services account only, or whether it can also access Amazon Web Services resources
        /// in other accounts in the same organization. If you specify <code>ORGANIZATION</code>,
        /// you must specify which organizational units the workspace can access in the <code>workspaceOrganizationalUnits</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedGrafana.AccountAccessType")]
        public Amazon.ManagedGrafana.AccountAccessType AccountAccessType { get; set; }
        #endregion
        
        #region Parameter OrganizationRoleName
        /// <summary>
        /// <para>
        /// <para>The name of an IAM role that already exists to use to access resources through Organizations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationRoleName { get; set; }
        #endregion
        
        #region Parameter PermissionType
        /// <summary>
        /// <para>
        /// <para>If you specify <code>Service Managed</code>, Amazon Managed Grafana automatically
        /// creates the IAM roles and provisions the permissions that the workspace needs to use
        /// Amazon Web Services data sources and notification channels.</para><para>If you specify <code>CUSTOMER_MANAGED</code>, you will manage those roles and permissions
        /// yourself. If you are creating this workspace in a member account of an organization
        /// and that account is not a delegated administrator account, and you want the workspace
        /// to access data sources in other Amazon Web Services accounts in the organization,
        /// you must choose <code>CUSTOMER_MANAGED</code>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/AMG-manage-permissions.html">Amazon
        /// Managed Grafana permissions and policies for Amazon Web Services data sources and
        /// notification channels</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedGrafana.PermissionType")]
        public Amazon.ManagedGrafana.PermissionType PermissionType { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudFormation stack set to use to generate IAM roles to be used for
        /// this workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter WorkspaceDataSource
        /// <summary>
        /// <para>
        /// <para>Specify the Amazon Web Services data sources that you want to be queried in this workspace.
        /// Specifying these data sources here enables Amazon Managed Grafana to create IAM roles
        /// and permissions that allow Amazon Managed Grafana to read data from these sources.
        /// You must still add them as data sources in the Grafana console in the workspace.</para><para>If you don't specify a data source here, you can still add it as a data source later
        /// in the workspace console. However, you will then have to manually configure permissions
        /// for it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceDataSources")]
        public System.String[] WorkspaceDataSource { get; set; }
        #endregion
        
        #region Parameter WorkspaceDescription
        /// <summary>
        /// <para>
        /// <para>A description for the workspace. This is used only to help you identify this workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceDescription { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace to update.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>A new name for the workspace to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceName { get; set; }
        #endregion
        
        #region Parameter WorkspaceNotificationDestination
        /// <summary>
        /// <para>
        /// <para>Specify the Amazon Web Services notification channels that you plan to use in this
        /// workspace. Specifying these data sources here enables Amazon Managed Grafana to create
        /// IAM roles and permissions that allow Amazon Managed Grafana to use these channels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceNotificationDestinations")]
        public System.String[] WorkspaceNotificationDestination { get; set; }
        #endregion
        
        #region Parameter WorkspaceOrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>Specifies the organizational units that this workspace is allowed to use data sources
        /// from, if this workspace is in an account that is part of an organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceOrganizationalUnits")]
        public System.String[] WorkspaceOrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter WorkspaceRoleArn
        /// <summary>
        /// <para>
        /// <para>The workspace needs an IAM role that grants permissions to the Amazon Web Services
        /// resources that the workspace will view data from. If you already have a role that
        /// you want to use, specify it here. If you omit this field and you specify some Amazon
        /// Web Services resources in <code>workspaceDataSources</code> or <code>workspaceNotificationDestinations</code>,
        /// a new IAM role with the necessary permissions is automatically created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workspace'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse).
        /// Specifying the name of a property of type Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workspace";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkspaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGRFWorkspace (UpdateWorkspace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse, UpdateMGRFWorkspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkspaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountAccessType = this.AccountAccessType;
            context.OrganizationRoleName = this.OrganizationRoleName;
            context.PermissionType = this.PermissionType;
            context.StackSetName = this.StackSetName;
            if (this.WorkspaceDataSource != null)
            {
                context.WorkspaceDataSource = new List<System.String>(this.WorkspaceDataSource);
            }
            context.WorkspaceDescription = this.WorkspaceDescription;
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceName = this.WorkspaceName;
            if (this.WorkspaceNotificationDestination != null)
            {
                context.WorkspaceNotificationDestination = new List<System.String>(this.WorkspaceNotificationDestination);
            }
            if (this.WorkspaceOrganizationalUnit != null)
            {
                context.WorkspaceOrganizationalUnit = new List<System.String>(this.WorkspaceOrganizationalUnit);
            }
            context.WorkspaceRoleArn = this.WorkspaceRoleArn;
            
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
            var request = new Amazon.ManagedGrafana.Model.UpdateWorkspaceRequest();
            
            if (cmdletContext.AccountAccessType != null)
            {
                request.AccountAccessType = cmdletContext.AccountAccessType;
            }
            if (cmdletContext.OrganizationRoleName != null)
            {
                request.OrganizationRoleName = cmdletContext.OrganizationRoleName;
            }
            if (cmdletContext.PermissionType != null)
            {
                request.PermissionType = cmdletContext.PermissionType;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            if (cmdletContext.WorkspaceDataSource != null)
            {
                request.WorkspaceDataSources = cmdletContext.WorkspaceDataSource;
            }
            if (cmdletContext.WorkspaceDescription != null)
            {
                request.WorkspaceDescription = cmdletContext.WorkspaceDescription;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
            }
            if (cmdletContext.WorkspaceNotificationDestination != null)
            {
                request.WorkspaceNotificationDestinations = cmdletContext.WorkspaceNotificationDestination;
            }
            if (cmdletContext.WorkspaceOrganizationalUnit != null)
            {
                request.WorkspaceOrganizationalUnits = cmdletContext.WorkspaceOrganizationalUnit;
            }
            if (cmdletContext.WorkspaceRoleArn != null)
            {
                request.WorkspaceRoleArn = cmdletContext.WorkspaceRoleArn;
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
        
        private Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse CallAWSServiceOperation(IAmazonManagedGrafana client, Amazon.ManagedGrafana.Model.UpdateWorkspaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Grafana", "UpdateWorkspace");
            try
            {
                #if DESKTOP
                return client.UpdateWorkspace(request);
                #elif CORECLR
                return client.UpdateWorkspaceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ManagedGrafana.AccountAccessType AccountAccessType { get; set; }
            public System.String OrganizationRoleName { get; set; }
            public Amazon.ManagedGrafana.PermissionType PermissionType { get; set; }
            public System.String StackSetName { get; set; }
            public List<System.String> WorkspaceDataSource { get; set; }
            public System.String WorkspaceDescription { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.String WorkspaceName { get; set; }
            public List<System.String> WorkspaceNotificationDestination { get; set; }
            public List<System.String> WorkspaceOrganizationalUnit { get; set; }
            public System.String WorkspaceRoleArn { get; set; }
            public System.Func<Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse, UpdateMGRFWorkspaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workspace;
        }
        
    }
}