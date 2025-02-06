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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Creates an Amazon Q Business application.
    /// 
    ///  <note><para>
    /// There are new tiers for Amazon Q Business. Not all features in Amazon Q Business Pro
    /// are also available in Amazon Q Business Lite. For information on what's included in
    /// Amazon Q Business Lite and what's included in Amazon Q Business Pro, see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/tiers.html#user-sub-tiers">Amazon
    /// Q Business tiers</a>. You must use the Amazon Q Business console to assign subscription
    /// tiers to users. 
    /// </para><para>
    /// An Amazon Q Apps service linked role will be created if it's absent in the Amazon
    /// Web Services account when <c>QAppsConfiguration</c> is enabled in the request. For
    /// more information, see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/using-service-linked-roles-qapps.html">
    /// Using service-linked roles for Q Apps</a>.
    /// </para><para>
    /// When you create an application, Amazon Q Business may securely transmit data for processing
    /// from your selected Amazon Web Services region, but within your geography. For more
    /// information, see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/cross-region-inference.html">Cross
    /// region inference in Amazon Q Business</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "QBUSApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QBusiness.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the Amazon QBusiness CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.QBusiness.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.QBusiness.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.QBusiness.Model.CreateApplicationResponse object containing multiple properties."
    )]
    public partial class NewQBUSApplicationCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttachmentsConfiguration_AttachmentsControlMode
        /// <summary>
        /// <para>
        /// <para>Status information about whether file upload functionality is activated or deactivated
        /// for your end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.AttachmentsControlMode")]
        public Amazon.QBusiness.AttachmentsControlMode AttachmentsConfiguration_AttachmentsControlMode { get; set; }
        #endregion
        
        #region Parameter ClientIdsForOIDC
        /// <summary>
        /// <para>
        /// <para>The OIDC client ID for a Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ClientIdsForOIDC { get; set; }
        #endregion
        
        #region Parameter QuickSightConfiguration_ClientNamespace
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight namespace that is used as the identity provider. For more information
        /// about QuickSight namespaces, see <a href="https://docs.aws.amazon.com/quicksight/latest/developerguide/namespace-operations.html">Namespace
        /// operations</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuickSightConfiguration_ClientNamespace { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the Amazon Q Business application. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A name for the Amazon Q Business application. </para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter IamIdentityProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an identity provider being used by an Amazon Q Business
        /// application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamIdentityProviderArn { get; set; }
        #endregion
        
        #region Parameter IdentityCenterInstanceArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the IAM Identity Center instance you are either
        /// creating for—or connecting to—your Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityCenterInstanceArn { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>The authentication type being used by a Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.IdentityType")]
        public Amazon.QBusiness.IdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key. Amazon Q Business doesn't support asymmetric keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PersonalizationConfiguration_PersonalizationControlMode
        /// <summary>
        /// <para>
        /// <para>An option to allow Amazon Q Business to customize chat responses using user specific
        /// metadata—specifically, location and job information—in your IAM Identity Center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.PersonalizationControlMode")]
        public Amazon.QBusiness.PersonalizationControlMode PersonalizationConfiguration_PersonalizationControlMode { get; set; }
        #endregion
        
        #region Parameter QAppsConfiguration_QAppsControlMode
        /// <summary>
        /// <para>
        /// <para>Status information about whether end users can create and use Amazon Q Apps in the
        /// web experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.QAppsControlMode")]
        public Amazon.QBusiness.QAppsControlMode QAppsConfiguration_QAppsControlMode { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of an IAM role with permissions to access your Amazon
        /// CloudWatch logs and metrics. If this property is not specified, Amazon Q Business
        /// will create a <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/using-service-linked-roles.html#slr-permissions">service
        /// linked role (SLR)</a> and use it as the application's role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that identify or categorize your Amazon Q Business application.
        /// You can also use tags to help control access to the application. Tag keys and values
        /// can consist of Unicode letters, digits, white space, and any of the following symbols:
        /// _ . : / = + - @.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that you provide to identify the request to create your Amazon Q Business
        /// application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.QBusiness.Model.CreateApplicationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DisplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QBUSApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.CreateApplicationResponse, NewQBUSApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachmentsConfiguration_AttachmentsControlMode = this.AttachmentsConfiguration_AttachmentsControlMode;
            if (this.ClientIdsForOIDC != null)
            {
                context.ClientIdsForOIDC = new List<System.String>(this.ClientIdsForOIDC);
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.IamIdentityProviderArn = this.IamIdentityProviderArn;
            context.IdentityCenterInstanceArn = this.IdentityCenterInstanceArn;
            context.IdentityType = this.IdentityType;
            context.PersonalizationConfiguration_PersonalizationControlMode = this.PersonalizationConfiguration_PersonalizationControlMode;
            context.QAppsConfiguration_QAppsControlMode = this.QAppsConfiguration_QAppsControlMode;
            context.QuickSightConfiguration_ClientNamespace = this.QuickSightConfiguration_ClientNamespace;
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QBusiness.Model.Tag>(this.Tag);
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
            var request = new Amazon.QBusiness.Model.CreateApplicationRequest();
            
            
             // populate AttachmentsConfiguration
            var requestAttachmentsConfigurationIsNull = true;
            request.AttachmentsConfiguration = new Amazon.QBusiness.Model.AttachmentsConfiguration();
            Amazon.QBusiness.AttachmentsControlMode requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode = null;
            if (cmdletContext.AttachmentsConfiguration_AttachmentsControlMode != null)
            {
                requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode = cmdletContext.AttachmentsConfiguration_AttachmentsControlMode;
            }
            if (requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode != null)
            {
                request.AttachmentsConfiguration.AttachmentsControlMode = requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode;
                requestAttachmentsConfigurationIsNull = false;
            }
             // determine if request.AttachmentsConfiguration should be set to null
            if (requestAttachmentsConfigurationIsNull)
            {
                request.AttachmentsConfiguration = null;
            }
            if (cmdletContext.ClientIdsForOIDC != null)
            {
                request.ClientIdsForOIDC = cmdletContext.ClientIdsForOIDC;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.QBusiness.Model.EncryptionConfiguration();
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
            if (cmdletContext.IamIdentityProviderArn != null)
            {
                request.IamIdentityProviderArn = cmdletContext.IamIdentityProviderArn;
            }
            if (cmdletContext.IdentityCenterInstanceArn != null)
            {
                request.IdentityCenterInstanceArn = cmdletContext.IdentityCenterInstanceArn;
            }
            if (cmdletContext.IdentityType != null)
            {
                request.IdentityType = cmdletContext.IdentityType;
            }
            
             // populate PersonalizationConfiguration
            var requestPersonalizationConfigurationIsNull = true;
            request.PersonalizationConfiguration = new Amazon.QBusiness.Model.PersonalizationConfiguration();
            Amazon.QBusiness.PersonalizationControlMode requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode = null;
            if (cmdletContext.PersonalizationConfiguration_PersonalizationControlMode != null)
            {
                requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode = cmdletContext.PersonalizationConfiguration_PersonalizationControlMode;
            }
            if (requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode != null)
            {
                request.PersonalizationConfiguration.PersonalizationControlMode = requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode;
                requestPersonalizationConfigurationIsNull = false;
            }
             // determine if request.PersonalizationConfiguration should be set to null
            if (requestPersonalizationConfigurationIsNull)
            {
                request.PersonalizationConfiguration = null;
            }
            
             // populate QAppsConfiguration
            var requestQAppsConfigurationIsNull = true;
            request.QAppsConfiguration = new Amazon.QBusiness.Model.QAppsConfiguration();
            Amazon.QBusiness.QAppsControlMode requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode = null;
            if (cmdletContext.QAppsConfiguration_QAppsControlMode != null)
            {
                requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode = cmdletContext.QAppsConfiguration_QAppsControlMode;
            }
            if (requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode != null)
            {
                request.QAppsConfiguration.QAppsControlMode = requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode;
                requestQAppsConfigurationIsNull = false;
            }
             // determine if request.QAppsConfiguration should be set to null
            if (requestQAppsConfigurationIsNull)
            {
                request.QAppsConfiguration = null;
            }
            
             // populate QuickSightConfiguration
            var requestQuickSightConfigurationIsNull = true;
            request.QuickSightConfiguration = new Amazon.QBusiness.Model.QuickSightConfiguration();
            System.String requestQuickSightConfiguration_quickSightConfiguration_ClientNamespace = null;
            if (cmdletContext.QuickSightConfiguration_ClientNamespace != null)
            {
                requestQuickSightConfiguration_quickSightConfiguration_ClientNamespace = cmdletContext.QuickSightConfiguration_ClientNamespace;
            }
            if (requestQuickSightConfiguration_quickSightConfiguration_ClientNamespace != null)
            {
                request.QuickSightConfiguration.ClientNamespace = requestQuickSightConfiguration_quickSightConfiguration_ClientNamespace;
                requestQuickSightConfigurationIsNull = false;
            }
             // determine if request.QuickSightConfiguration should be set to null
            if (requestQuickSightConfigurationIsNull)
            {
                request.QuickSightConfiguration = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.QBusiness.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.QBusiness.AttachmentsControlMode AttachmentsConfiguration_AttachmentsControlMode { get; set; }
            public List<System.String> ClientIdsForOIDC { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public System.String IamIdentityProviderArn { get; set; }
            public System.String IdentityCenterInstanceArn { get; set; }
            public Amazon.QBusiness.IdentityType IdentityType { get; set; }
            public Amazon.QBusiness.PersonalizationControlMode PersonalizationConfiguration_PersonalizationControlMode { get; set; }
            public Amazon.QBusiness.QAppsControlMode QAppsConfiguration_QAppsControlMode { get; set; }
            public System.String QuickSightConfiguration_ClientNamespace { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.QBusiness.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.QBusiness.Model.CreateApplicationResponse, NewQBUSApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
