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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Updates a namespace with the specified settings. Unless required, you can't update
    /// multiple parameters in one request. For example, you must specify both <c>adminUsername</c>
    /// and <c>adminUserPassword</c> to update either field, but you can't update both <c>kmsKeyId</c>
    /// and <c>logExports</c> in a single request.
    /// </summary>
    [Cmdlet("Update", "RSSNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.Namespace")]
    [AWSCmdlet("Calls the Redshift Serverless UpdateNamespace API operation.", Operation = new[] {"UpdateNamespace"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.UpdateNamespaceResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.Namespace or Amazon.RedshiftServerless.Model.UpdateNamespaceResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.Namespace object.",
        "The service call response (type Amazon.RedshiftServerless.Model.UpdateNamespaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateRSSNamespaceCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdminPasswordSecretKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Key Management Service (KMS) key used to encrypt and store the namespace's
        /// admin credentials secret. You can only use this parameter if <c>manageAdminPassword</c>
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminPasswordSecretKmsKeyId { get; set; }
        #endregion
        
        #region Parameter AdminUsername
        /// <summary>
        /// <para>
        /// <para>The username of the administrator for the first database created in the namespace.
        /// This parameter must be updated together with <c>adminUserPassword</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminUsername { get; set; }
        #endregion
        
        #region Parameter AdminUserPassword
        /// <summary>
        /// <para>
        /// <para>The password of the administrator for the first database created in the namespace.
        /// This parameter must be updated together with <c>adminUsername</c>.</para><para>You can't use <c>adminUserPassword</c> if <c>manageAdminPassword</c> is true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminUserPassword { get; set; }
        #endregion
        
        #region Parameter DefaultIamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to set as a default in the namespace.
        /// This parameter must be updated together with <c>iamRoles</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultIamRoleArn { get; set; }
        #endregion
        
        #region Parameter IamRole
        /// <summary>
        /// <para>
        /// <para>A list of IAM roles to associate with the namespace. This parameter must be updated
        /// together with <c>defaultIamRoleArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IamRoles")]
        public System.String[] IamRole { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Key Management Service key used to encrypt your
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LogExport
        /// <summary>
        /// <para>
        /// <para>The types of logs the namespace can export. The export types are <c>userlog</c>, <c>connectionlog</c>,
        /// and <c>useractivitylog</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogExports")]
        public System.String[] LogExport { get; set; }
        #endregion
        
        #region Parameter ManageAdminPassword
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, Amazon Redshift uses Secrets Manager to manage the namespace's admin
        /// credentials. You can't use <c>adminUserPassword</c> if <c>manageAdminPassword</c>
        /// is true. If <c>manageAdminPassword</c> is false or not set, Amazon Redshift uses <c>adminUserPassword</c>
        /// for the admin user account's password. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageAdminPassword { get; set; }
        #endregion
        
        #region Parameter NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the namespace to update. You can't update the name of a namespace once
        /// it is created.</para>
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
        public System.String NamespaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Namespace'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.UpdateNamespaceResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.UpdateNamespaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Namespace";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NamespaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RSSNamespace (UpdateNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.UpdateNamespaceResponse, UpdateRSSNamespaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdminPasswordSecretKmsKeyId = this.AdminPasswordSecretKmsKeyId;
            context.AdminUsername = this.AdminUsername;
            context.AdminUserPassword = this.AdminUserPassword;
            context.DefaultIamRoleArn = this.DefaultIamRoleArn;
            if (this.IamRole != null)
            {
                context.IamRole = new List<System.String>(this.IamRole);
            }
            context.KmsKeyId = this.KmsKeyId;
            if (this.LogExport != null)
            {
                context.LogExport = new List<System.String>(this.LogExport);
            }
            context.ManageAdminPassword = this.ManageAdminPassword;
            context.NamespaceName = this.NamespaceName;
            #if MODULAR
            if (this.NamespaceName == null && ParameterWasBound(nameof(this.NamespaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NamespaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RedshiftServerless.Model.UpdateNamespaceRequest();
            
            if (cmdletContext.AdminPasswordSecretKmsKeyId != null)
            {
                request.AdminPasswordSecretKmsKeyId = cmdletContext.AdminPasswordSecretKmsKeyId;
            }
            if (cmdletContext.AdminUsername != null)
            {
                request.AdminUsername = cmdletContext.AdminUsername;
            }
            if (cmdletContext.AdminUserPassword != null)
            {
                request.AdminUserPassword = cmdletContext.AdminUserPassword;
            }
            if (cmdletContext.DefaultIamRoleArn != null)
            {
                request.DefaultIamRoleArn = cmdletContext.DefaultIamRoleArn;
            }
            if (cmdletContext.IamRole != null)
            {
                request.IamRoles = cmdletContext.IamRole;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LogExport != null)
            {
                request.LogExports = cmdletContext.LogExport;
            }
            if (cmdletContext.ManageAdminPassword != null)
            {
                request.ManageAdminPassword = cmdletContext.ManageAdminPassword.Value;
            }
            if (cmdletContext.NamespaceName != null)
            {
                request.NamespaceName = cmdletContext.NamespaceName;
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
        
        private Amazon.RedshiftServerless.Model.UpdateNamespaceResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.UpdateNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "UpdateNamespace");
            try
            {
                #if DESKTOP
                return client.UpdateNamespace(request);
                #elif CORECLR
                return client.UpdateNamespaceAsync(request).GetAwaiter().GetResult();
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
            public System.String AdminPasswordSecretKmsKeyId { get; set; }
            public System.String AdminUsername { get; set; }
            public System.String AdminUserPassword { get; set; }
            public System.String DefaultIamRoleArn { get; set; }
            public List<System.String> IamRole { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<System.String> LogExport { get; set; }
            public System.Boolean? ManageAdminPassword { get; set; }
            public System.String NamespaceName { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.UpdateNamespaceResponse, UpdateRSSNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Namespace;
        }
        
    }
}
