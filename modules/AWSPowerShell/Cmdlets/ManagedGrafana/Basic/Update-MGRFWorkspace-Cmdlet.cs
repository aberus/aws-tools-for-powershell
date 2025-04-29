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
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGRF
{
    /// <summary>
    /// Modifies an existing Amazon Managed Grafana workspace. If you use this operation and
    /// omit any optional parameters, the existing values of those parameters are not changed.
    /// 
    ///  
    /// <para>
    /// To modify the user authentication methods that the workspace uses, such as SAML or
    /// IAM Identity Center, use <a href="https://docs.aws.amazon.com/grafana/latest/APIReference/API_UpdateWorkspaceAuthentication.html">UpdateWorkspaceAuthentication</a>.
    /// </para><para>
    /// To modify which users in the workspace have the <c>Admin</c> and <c>Editor</c> Grafana
    /// roles, use <a href="https://docs.aws.amazon.com/grafana/latest/APIReference/API_UpdatePermissions.html">UpdatePermissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MGRFWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ManagedGrafana.Model.WorkspaceDescription")]
    [AWSCmdlet("Calls the Amazon Managed Grafana UpdateWorkspace API operation.", Operation = new[] {"UpdateWorkspace"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse))]
    [AWSCmdletOutput("Amazon.ManagedGrafana.Model.WorkspaceDescription or Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse",
        "This cmdlet returns an Amazon.ManagedGrafana.Model.WorkspaceDescription object.",
        "The service call response (type Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMGRFWorkspaceCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountAccessType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the workspace can access Amazon Web Services resources in this Amazon
        /// Web Services account only, or whether it can also access Amazon Web Services resources
        /// in other accounts in the same organization. If you specify <c>ORGANIZATION</c>, you
        /// must specify which organizational units the workspace can access in the <c>workspaceOrganizationalUnits</c>
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
        /// <para>The name of an IAM role that already exists to use to access resources through Organizations.
        /// This can only be used with a workspace that has the <c>permissionType</c> set to <c>CUSTOMER_MANAGED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationRoleName { get; set; }
        #endregion
        
        #region Parameter PermissionType
        /// <summary>
        /// <para>
        /// <para>Use this parameter if you want to change a workspace from <c>SERVICE_MANAGED</c> to
        /// <c>CUSTOMER_MANAGED</c>. This allows you to manage the permissions that the workspace
        /// uses to access datasources and notification channels. If the workspace is in a member
        /// Amazon Web Services account of an organization, and that account is not a delegated
        /// administrator account, and you want the workspace to access data sources in other
        /// Amazon Web Services accounts in the organization, you must choose <c>CUSTOMER_MANAGED</c>.</para><para>If you specify this as <c>CUSTOMER_MANAGED</c>, you must also specify a <c>workspaceRoleArn</c>
        /// that the workspace will use for accessing Amazon Web Services resources.</para><para>For more information on the role and permissions needed, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/AMG-manage-permissions.html">Amazon
        /// Managed Grafana permissions and policies for Amazon Web Services data sources and
        /// notification channels</a></para><note><para>Do not use this to convert a <c>CUSTOMER_MANAGED</c> workspace to <c>SERVICE_MANAGED</c>.
        /// Do not include this parameter if you want to leave the workspace as <c>SERVICE_MANAGED</c>.</para><para>You can convert a <c>CUSTOMER_MANAGED</c> workspace to <c>SERVICE_MANAGED</c> using
        /// the Amazon Managed Grafana console. For more information, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/AMG-datasource-and-notification.html">Managing
        /// permissions for data sources and notification channels</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedGrafana.PermissionType")]
        public Amazon.ManagedGrafana.PermissionType PermissionType { get; set; }
        #endregion
        
        #region Parameter NetworkAccessControl_PrefixListId
        /// <summary>
        /// <para>
        /// <para>An array of prefix list IDs. A prefix list is a list of CIDR ranges of IP addresses.
        /// The IP addresses specified are allowed to access your workspace. If the list is not
        /// included in the configuration (passed an empty array) then no IP addresses are allowed
        /// to access the workspace. You create a prefix list using the Amazon VPC console.</para><para>Prefix list IDs have the format <c>pl-<i>1a2b3c4d</i></c>.</para><para>For more information about prefix lists, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/managed-prefix-lists.html">Group
        /// CIDR blocks using managed prefix lists</a>in the <i>Amazon Virtual Private Cloud User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkAccessControl_PrefixListIds")]
        public System.String[] NetworkAccessControl_PrefixListId { get; set; }
        #endregion
        
        #region Parameter RemoveNetworkAccessConfiguration
        /// <summary>
        /// <para>
        /// <para>Whether to remove the network access configuration from the workspace.</para><para>Setting this to <c>true</c> and providing a <c>networkAccessControl</c> to set will
        /// return an error.</para><para>If you remove this configuration by setting this to <c>true</c>, then all IP addresses
        /// and VPC endpoints will be allowed. Standard Grafana authentication and authorization
        /// will still be required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveNetworkAccessConfiguration { get; set; }
        #endregion
        
        #region Parameter RemoveVpcConfiguration
        /// <summary>
        /// <para>
        /// <para>Whether to remove the VPC configuration from the workspace.</para><para>Setting this to <c>true</c> and providing a <c>vpcConfiguration</c> to set will return
        /// an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveVpcConfiguration { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The list of Amazon EC2 security group IDs attached to the Amazon VPC for your Grafana
        /// workspace to connect. Duplicates not allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SecurityGroupIds")]
        public System.String[] VpcConfiguration_SecurityGroupId { get; set; }
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
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The list of Amazon EC2 subnet IDs created in the Amazon VPC for your Grafana workspace
        /// to connect. Duplicates not allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter NetworkAccessControl_VpceId
        /// <summary>
        /// <para>
        /// <para>An array of Amazon VPC endpoint IDs for the workspace. You can create VPC endpoints
        /// to your Amazon Managed Grafana workspace for access from within a VPC. If a <c>NetworkAccessConfiguration</c>
        /// is specified then only VPC endpoints specified here are allowed to access the workspace.
        /// If you pass in an empty array of strings, then no VPCs are allowed to access the workspace.</para><para>VPC endpoint IDs have the format <c>vpce-<i>1a2b3c4d</i></c>.</para><para>For more information about creating an interface VPC endpoint, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/VPC-endpoints">Interface
        /// VPC endpoints</a> in the <i>Amazon Managed Grafana User Guide</i>.</para><note><para>The only VPC endpoints that can be specified here are interface VPC endpoints for
        /// Grafana workspaces (using the <c>com.amazonaws.[region].grafana-workspace</c> service
        /// endpoint). Other VPC endpoints are ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkAccessControl_VpceIds")]
        public System.String[] NetworkAccessControl_VpceId { get; set; }
        #endregion
        
        #region Parameter WorkspaceDataSource
        /// <summary>
        /// <para>
        /// <para>This parameter is for internal use only, and should not be used.</para>
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
        /// <para>Specifies an IAM role that grants permissions to Amazon Web Services resources that
        /// the workspace accesses, such as data sources and notification channels. If this workspace
        /// has <c>permissionType</c><c>CUSTOMER_MANAGED</c>, then this role is required.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGRFWorkspace (UpdateWorkspace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.UpdateWorkspaceResponse, UpdateMGRFWorkspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountAccessType = this.AccountAccessType;
            if (this.NetworkAccessControl_PrefixListId != null)
            {
                context.NetworkAccessControl_PrefixListId = new List<System.String>(this.NetworkAccessControl_PrefixListId);
            }
            if (this.NetworkAccessControl_VpceId != null)
            {
                context.NetworkAccessControl_VpceId = new List<System.String>(this.NetworkAccessControl_VpceId);
            }
            context.OrganizationRoleName = this.OrganizationRoleName;
            context.PermissionType = this.PermissionType;
            context.RemoveNetworkAccessConfiguration = this.RemoveNetworkAccessConfiguration;
            context.RemoveVpcConfiguration = this.RemoveVpcConfiguration;
            context.StackSetName = this.StackSetName;
            if (this.VpcConfiguration_SecurityGroupId != null)
            {
                context.VpcConfiguration_SecurityGroupId = new List<System.String>(this.VpcConfiguration_SecurityGroupId);
            }
            if (this.VpcConfiguration_SubnetId != null)
            {
                context.VpcConfiguration_SubnetId = new List<System.String>(this.VpcConfiguration_SubnetId);
            }
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
            
             // populate NetworkAccessControl
            var requestNetworkAccessControlIsNull = true;
            request.NetworkAccessControl = new Amazon.ManagedGrafana.Model.NetworkAccessConfiguration();
            List<System.String> requestNetworkAccessControl_networkAccessControl_PrefixListId = null;
            if (cmdletContext.NetworkAccessControl_PrefixListId != null)
            {
                requestNetworkAccessControl_networkAccessControl_PrefixListId = cmdletContext.NetworkAccessControl_PrefixListId;
            }
            if (requestNetworkAccessControl_networkAccessControl_PrefixListId != null)
            {
                request.NetworkAccessControl.PrefixListIds = requestNetworkAccessControl_networkAccessControl_PrefixListId;
                requestNetworkAccessControlIsNull = false;
            }
            List<System.String> requestNetworkAccessControl_networkAccessControl_VpceId = null;
            if (cmdletContext.NetworkAccessControl_VpceId != null)
            {
                requestNetworkAccessControl_networkAccessControl_VpceId = cmdletContext.NetworkAccessControl_VpceId;
            }
            if (requestNetworkAccessControl_networkAccessControl_VpceId != null)
            {
                request.NetworkAccessControl.VpceIds = requestNetworkAccessControl_networkAccessControl_VpceId;
                requestNetworkAccessControlIsNull = false;
            }
             // determine if request.NetworkAccessControl should be set to null
            if (requestNetworkAccessControlIsNull)
            {
                request.NetworkAccessControl = null;
            }
            if (cmdletContext.OrganizationRoleName != null)
            {
                request.OrganizationRoleName = cmdletContext.OrganizationRoleName;
            }
            if (cmdletContext.PermissionType != null)
            {
                request.PermissionType = cmdletContext.PermissionType;
            }
            if (cmdletContext.RemoveNetworkAccessConfiguration != null)
            {
                request.RemoveNetworkAccessConfiguration = cmdletContext.RemoveNetworkAccessConfiguration.Value;
            }
            if (cmdletContext.RemoveVpcConfiguration != null)
            {
                request.RemoveVpcConfiguration = cmdletContext.RemoveVpcConfiguration.Value;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.ManagedGrafana.Model.VpcConfiguration();
            List<System.String> requestVpcConfiguration_vpcConfiguration_SecurityGroupId = null;
            if (cmdletContext.VpcConfiguration_SecurityGroupId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SecurityGroupId = cmdletContext.VpcConfiguration_SecurityGroupId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SecurityGroupId != null)
            {
                request.VpcConfiguration.SecurityGroupIds = requestVpcConfiguration_vpcConfiguration_SecurityGroupId;
                requestVpcConfigurationIsNull = false;
            }
            List<System.String> requestVpcConfiguration_vpcConfiguration_SubnetId = null;
            if (cmdletContext.VpcConfiguration_SubnetId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SubnetId = cmdletContext.VpcConfiguration_SubnetId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SubnetId != null)
            {
                request.VpcConfiguration.SubnetIds = requestVpcConfiguration_vpcConfiguration_SubnetId;
                requestVpcConfigurationIsNull = false;
            }
             // determine if request.VpcConfiguration should be set to null
            if (requestVpcConfigurationIsNull)
            {
                request.VpcConfiguration = null;
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
                return client.UpdateWorkspaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> NetworkAccessControl_PrefixListId { get; set; }
            public List<System.String> NetworkAccessControl_VpceId { get; set; }
            public System.String OrganizationRoleName { get; set; }
            public Amazon.ManagedGrafana.PermissionType PermissionType { get; set; }
            public System.Boolean? RemoveNetworkAccessConfiguration { get; set; }
            public System.Boolean? RemoveVpcConfiguration { get; set; }
            public System.String StackSetName { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
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
