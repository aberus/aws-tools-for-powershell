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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Creates a workgroup with the specified name. A workgroup can be an Apache Spark enabled
    /// workgroup or an Athena SQL workgroup.
    /// </summary>
    [Cmdlet("New", "ATHWorkGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Athena CreateWorkGroup API operation.", Operation = new[] {"CreateWorkGroup"}, SelectReturnType = typeof(Amazon.Athena.Model.CreateWorkGroupResponse))]
    [AWSCmdletOutput("None or Amazon.Athena.Model.CreateWorkGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Athena.Model.CreateWorkGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewATHWorkGroupCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Configuration_AdditionalConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies a user defined JSON string that is passed to the notebook engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AdditionalConfiguration { get; set; }
        #endregion
        
        #region Parameter QueryResultsS3AccessGrantsConfiguration_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The authentication type used for Amazon S3 access grants. Currently, only <c>DIRECTORY_IDENTITY</c>
        /// is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_QueryResultsS3AccessGrantsConfiguration_AuthenticationType")]
        [AWSConstantClassSource("Amazon.Athena.AuthenticationType")]
        public Amazon.Athena.AuthenticationType QueryResultsS3AccessGrantsConfiguration_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter Configuration_BytesScannedCutoffPerQuery
        /// <summary>
        /// <para>
        /// <para>The upper data usage limit (cutoff) for the amount of bytes a single query in a workgroup
        /// is allowed to scan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Configuration_BytesScannedCutoffPerQuery { get; set; }
        #endregion
        
        #region Parameter QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix
        /// <summary>
        /// <para>
        /// <para>When enabled, appends the user ID as an Amazon S3 path prefix to the query result
        /// output location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix")]
        public System.Boolean? QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The workgroup description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EngineVersion_EffectiveEngineVersion
        /// <summary>
        /// <para>
        /// <para>Read only. The engine version on which the query runs. If the user requests a valid
        /// engine version other than Auto, the effective engine version is the same as the engine
        /// version that the user requested. If the user requests Auto, the effective engine version
        /// is chosen by Athena. When a request to update the engine version is made by a <c>CreateWorkGroup</c>
        /// or <c>UpdateWorkGroup</c> operation, the <c>EffectiveEngineVersion</c> field is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EngineVersion_EffectiveEngineVersion")]
        public System.String EngineVersion_EffectiveEngineVersion { get; set; }
        #endregion
        
        #region Parameter IdentityCenterConfiguration_EnableIdentityCenter
        /// <summary>
        /// <para>
        /// <para>Specifies whether the workgroup is IAM Identity Center supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_IdentityCenterConfiguration_EnableIdentityCenter")]
        public System.Boolean? IdentityCenterConfiguration_EnableIdentityCenter { get; set; }
        #endregion
        
        #region Parameter Configuration_EnableMinimumEncryptionConfiguration
        /// <summary>
        /// <para>
        /// <para>Enforces a minimal level of encryption for the workgroup for query and calculation
        /// results that are written to Amazon S3. When enabled, workgroup users can set encryption
        /// only to the minimum level set by the administrator or higher when they submit queries.</para><para>The <c>EnforceWorkGroupConfiguration</c> setting takes precedence over the <c>EnableMinimumEncryptionConfiguration</c>
        /// flag. This means that if <c>EnforceWorkGroupConfiguration</c> is true, the <c>EnableMinimumEncryptionConfiguration</c>
        /// flag is ignored, and the workgroup configuration for encryption is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_EnableMinimumEncryptionConfiguration { get; set; }
        #endregion
        
        #region Parameter QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 access grants are enabled for query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrants")]
        public System.Boolean? QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_EncryptionOption
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon S3 server-side encryption with Amazon S3-managed keys (<c>SSE_S3</c>),
        /// server-side encryption with KMS-managed keys (<c>SSE_KMS</c>), or client-side encryption
        /// with KMS-managed keys (<c>CSE_KMS</c>) is used.</para><para>If a query runs in a workgroup and the workgroup overrides client-side settings, then
        /// the workgroup's setting for encryption is used. It specifies whether query results
        /// must be encrypted, for all queries that run in this workgroup. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_EncryptionConfiguration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.Athena.EncryptionOption")]
        public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter Configuration_EnforceWorkGroupConfiguration
        /// <summary>
        /// <para>
        /// <para>If set to "true", the settings for the workgroup override client-side settings. If
        /// set to "false", client-side settings are used. For more information, see <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_EnforceWorkGroupConfiguration { get; set; }
        #endregion
        
        #region Parameter Configuration_ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the execution role used to access user resources for Spark sessions and
        /// IAM Identity Center enabled workgroups. This property applies only to Spark enabled
        /// workgroups and IAM Identity Center enabled workgroups. The property is required for
        /// IAM Identity Center enabled workgroups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_ExecutionRole { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that you expect to be the owner of the Amazon S3
        /// bucket specified by <a>ResultConfiguration$OutputLocation</a>. If set, Athena uses
        /// the value for <c>ExpectedBucketOwner</c> when it makes Amazon S3 calls to your specified
        /// output location. If the <c>ExpectedBucketOwner</c> Amazon Web Services account ID
        /// does not match the actual owner of the Amazon S3 bucket, the call fails with a permissions
        /// error.</para><para>This is a client-side setting. If workgroup settings override client-side settings,
        /// then the query uses the <c>ExpectedBucketOwner</c> setting that is specified for the
        /// workgroup, and also uses the location for storing query results specified in the workgroup.
        /// See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a> and <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_ExpectedBucketOwner")]
        public System.String ResultConfiguration_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter IdentityCenterConfiguration_IdentityCenterInstanceArn
        /// <summary>
        /// <para>
        /// <para>The IAM Identity Center instance ARN that the workgroup associates to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_IdentityCenterConfiguration_IdentityCenterInstanceArn")]
        public System.String IdentityCenterConfiguration_IdentityCenterInstanceArn { get; set; }
        #endregion
        
        #region Parameter CustomerContentEncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>The customer managed KMS key that is used to encrypt the user's data stores in Athena.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerContentEncryptionConfiguration_KmsKey")]
        public System.String CustomerContentEncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>For <c>SSE_KMS</c> and <c>CSE_KMS</c>, this is the KMS key ARN or ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_EncryptionConfiguration_KmsKey")]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The workgroup name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_OutputLocation
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 where your query and calculation results are stored, such
        /// as <c>s3://path/to/query/bucket/</c>. To run the query, you must specify the query
        /// results location using one of the ways: either for individual queries using either
        /// this setting (client-side), or in the workgroup, using <a>WorkGroupConfiguration</a>.
        /// If none of them is set, Athena issues an error that no output location is provided.
        /// If workgroup settings override client-side settings, then the query uses the settings
        /// specified for the workgroup. See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_OutputLocation")]
        public System.String ResultConfiguration_OutputLocation { get; set; }
        #endregion
        
        #region Parameter Configuration_PublishCloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates that the Amazon CloudWatch metrics are enabled for the workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_PublishCloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter Configuration_RequesterPaysEnabled
        /// <summary>
        /// <para>
        /// <para>If set to <c>true</c>, allows members assigned to a workgroup to reference Amazon
        /// S3 Requester Pays buckets in queries. If set to <c>false</c>, workgroup members cannot
        /// query data from Requester Pays buckets, and queries that retrieve data from Requester
        /// Pays buckets cause an error. The default is <c>false</c>. For more information about
        /// Requester Pays buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/RequesterPaysBuckets.html">Requester
        /// Pays Buckets</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_RequesterPaysEnabled { get; set; }
        #endregion
        
        #region Parameter AclConfiguration_S3AclOption
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 canned ACL that Athena should specify when storing query results, including
        /// data files inserted by Athena as the result of statements like CTAS or INSERT INTO.
        /// Currently the only supported canned ACL is <c>BUCKET_OWNER_FULL_CONTROL</c>. If a
        /// query runs in a workgroup and the workgroup overrides client-side settings, then the
        /// Amazon S3 canned ACL specified in the workgroup's settings is used for all queries
        /// that run in the workgroup. For more information about Amazon S3 canned ACLs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/acl-overview.html#canned-acl">Canned
        /// ACL</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ResultConfiguration_AclConfiguration_S3AclOption")]
        [AWSConstantClassSource("Amazon.Athena.S3AclOption")]
        public Amazon.Athena.S3AclOption AclConfiguration_S3AclOption { get; set; }
        #endregion
        
        #region Parameter EngineVersion_SelectedEngineVersion
        /// <summary>
        /// <para>
        /// <para>The engine version requested by the user. Possible values are determined by the output
        /// of <c>ListEngineVersions</c>, including AUTO. The default is AUTO.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EngineVersion_SelectedEngineVersion")]
        public System.String EngineVersion_SelectedEngineVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of comma separated tags to add to the workgroup that is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Athena.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.CreateWorkGroupResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ATHWorkGroup (CreateWorkGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.CreateWorkGroupResponse, NewATHWorkGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_AdditionalConfiguration = this.Configuration_AdditionalConfiguration;
            context.Configuration_BytesScannedCutoffPerQuery = this.Configuration_BytesScannedCutoffPerQuery;
            context.CustomerContentEncryptionConfiguration_KmsKey = this.CustomerContentEncryptionConfiguration_KmsKey;
            context.Configuration_EnableMinimumEncryptionConfiguration = this.Configuration_EnableMinimumEncryptionConfiguration;
            context.Configuration_EnforceWorkGroupConfiguration = this.Configuration_EnforceWorkGroupConfiguration;
            context.EngineVersion_EffectiveEngineVersion = this.EngineVersion_EffectiveEngineVersion;
            context.EngineVersion_SelectedEngineVersion = this.EngineVersion_SelectedEngineVersion;
            context.Configuration_ExecutionRole = this.Configuration_ExecutionRole;
            context.IdentityCenterConfiguration_EnableIdentityCenter = this.IdentityCenterConfiguration_EnableIdentityCenter;
            context.IdentityCenterConfiguration_IdentityCenterInstanceArn = this.IdentityCenterConfiguration_IdentityCenterInstanceArn;
            context.Configuration_PublishCloudWatchMetricsEnabled = this.Configuration_PublishCloudWatchMetricsEnabled;
            context.QueryResultsS3AccessGrantsConfiguration_AuthenticationType = this.QueryResultsS3AccessGrantsConfiguration_AuthenticationType;
            context.QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix = this.QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix;
            context.QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant = this.QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant;
            context.Configuration_RequesterPaysEnabled = this.Configuration_RequesterPaysEnabled;
            context.AclConfiguration_S3AclOption = this.AclConfiguration_S3AclOption;
            context.EncryptionConfiguration_EncryptionOption = this.EncryptionConfiguration_EncryptionOption;
            context.EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.ResultConfiguration_ExpectedBucketOwner = this.ResultConfiguration_ExpectedBucketOwner;
            context.ResultConfiguration_OutputLocation = this.ResultConfiguration_OutputLocation;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Athena.Model.Tag>(this.Tag);
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
            var request = new Amazon.Athena.Model.CreateWorkGroupRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Athena.Model.WorkGroupConfiguration();
            System.String requestConfiguration_configuration_AdditionalConfiguration = null;
            if (cmdletContext.Configuration_AdditionalConfiguration != null)
            {
                requestConfiguration_configuration_AdditionalConfiguration = cmdletContext.Configuration_AdditionalConfiguration;
            }
            if (requestConfiguration_configuration_AdditionalConfiguration != null)
            {
                request.Configuration.AdditionalConfiguration = requestConfiguration_configuration_AdditionalConfiguration;
                requestConfigurationIsNull = false;
            }
            System.Int64? requestConfiguration_configuration_BytesScannedCutoffPerQuery = null;
            if (cmdletContext.Configuration_BytesScannedCutoffPerQuery != null)
            {
                requestConfiguration_configuration_BytesScannedCutoffPerQuery = cmdletContext.Configuration_BytesScannedCutoffPerQuery.Value;
            }
            if (requestConfiguration_configuration_BytesScannedCutoffPerQuery != null)
            {
                request.Configuration.BytesScannedCutoffPerQuery = requestConfiguration_configuration_BytesScannedCutoffPerQuery.Value;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_EnableMinimumEncryptionConfiguration = null;
            if (cmdletContext.Configuration_EnableMinimumEncryptionConfiguration != null)
            {
                requestConfiguration_configuration_EnableMinimumEncryptionConfiguration = cmdletContext.Configuration_EnableMinimumEncryptionConfiguration.Value;
            }
            if (requestConfiguration_configuration_EnableMinimumEncryptionConfiguration != null)
            {
                request.Configuration.EnableMinimumEncryptionConfiguration = requestConfiguration_configuration_EnableMinimumEncryptionConfiguration.Value;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_EnforceWorkGroupConfiguration = null;
            if (cmdletContext.Configuration_EnforceWorkGroupConfiguration != null)
            {
                requestConfiguration_configuration_EnforceWorkGroupConfiguration = cmdletContext.Configuration_EnforceWorkGroupConfiguration.Value;
            }
            if (requestConfiguration_configuration_EnforceWorkGroupConfiguration != null)
            {
                request.Configuration.EnforceWorkGroupConfiguration = requestConfiguration_configuration_EnforceWorkGroupConfiguration.Value;
                requestConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ExecutionRole = null;
            if (cmdletContext.Configuration_ExecutionRole != null)
            {
                requestConfiguration_configuration_ExecutionRole = cmdletContext.Configuration_ExecutionRole;
            }
            if (requestConfiguration_configuration_ExecutionRole != null)
            {
                request.Configuration.ExecutionRole = requestConfiguration_configuration_ExecutionRole;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_PublishCloudWatchMetricsEnabled = null;
            if (cmdletContext.Configuration_PublishCloudWatchMetricsEnabled != null)
            {
                requestConfiguration_configuration_PublishCloudWatchMetricsEnabled = cmdletContext.Configuration_PublishCloudWatchMetricsEnabled.Value;
            }
            if (requestConfiguration_configuration_PublishCloudWatchMetricsEnabled != null)
            {
                request.Configuration.PublishCloudWatchMetricsEnabled = requestConfiguration_configuration_PublishCloudWatchMetricsEnabled.Value;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_RequesterPaysEnabled = null;
            if (cmdletContext.Configuration_RequesterPaysEnabled != null)
            {
                requestConfiguration_configuration_RequesterPaysEnabled = cmdletContext.Configuration_RequesterPaysEnabled.Value;
            }
            if (requestConfiguration_configuration_RequesterPaysEnabled != null)
            {
                request.Configuration.RequesterPaysEnabled = requestConfiguration_configuration_RequesterPaysEnabled.Value;
                requestConfigurationIsNull = false;
            }
            Amazon.Athena.Model.CustomerContentEncryptionConfiguration requestConfiguration_configuration_CustomerContentEncryptionConfiguration = null;
            
             // populate CustomerContentEncryptionConfiguration
            var requestConfiguration_configuration_CustomerContentEncryptionConfigurationIsNull = true;
            requestConfiguration_configuration_CustomerContentEncryptionConfiguration = new Amazon.Athena.Model.CustomerContentEncryptionConfiguration();
            System.String requestConfiguration_configuration_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey = null;
            if (cmdletContext.CustomerContentEncryptionConfiguration_KmsKey != null)
            {
                requestConfiguration_configuration_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey = cmdletContext.CustomerContentEncryptionConfiguration_KmsKey;
            }
            if (requestConfiguration_configuration_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey != null)
            {
                requestConfiguration_configuration_CustomerContentEncryptionConfiguration.KmsKey = requestConfiguration_configuration_CustomerContentEncryptionConfiguration_customerContentEncryptionConfiguration_KmsKey;
                requestConfiguration_configuration_CustomerContentEncryptionConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerContentEncryptionConfiguration should be set to null
            if (requestConfiguration_configuration_CustomerContentEncryptionConfigurationIsNull)
            {
                requestConfiguration_configuration_CustomerContentEncryptionConfiguration = null;
            }
            if (requestConfiguration_configuration_CustomerContentEncryptionConfiguration != null)
            {
                request.Configuration.CustomerContentEncryptionConfiguration = requestConfiguration_configuration_CustomerContentEncryptionConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.Athena.Model.EngineVersion requestConfiguration_configuration_EngineVersion = null;
            
             // populate EngineVersion
            var requestConfiguration_configuration_EngineVersionIsNull = true;
            requestConfiguration_configuration_EngineVersion = new Amazon.Athena.Model.EngineVersion();
            System.String requestConfiguration_configuration_EngineVersion_engineVersion_EffectiveEngineVersion = null;
            if (cmdletContext.EngineVersion_EffectiveEngineVersion != null)
            {
                requestConfiguration_configuration_EngineVersion_engineVersion_EffectiveEngineVersion = cmdletContext.EngineVersion_EffectiveEngineVersion;
            }
            if (requestConfiguration_configuration_EngineVersion_engineVersion_EffectiveEngineVersion != null)
            {
                requestConfiguration_configuration_EngineVersion.EffectiveEngineVersion = requestConfiguration_configuration_EngineVersion_engineVersion_EffectiveEngineVersion;
                requestConfiguration_configuration_EngineVersionIsNull = false;
            }
            System.String requestConfiguration_configuration_EngineVersion_engineVersion_SelectedEngineVersion = null;
            if (cmdletContext.EngineVersion_SelectedEngineVersion != null)
            {
                requestConfiguration_configuration_EngineVersion_engineVersion_SelectedEngineVersion = cmdletContext.EngineVersion_SelectedEngineVersion;
            }
            if (requestConfiguration_configuration_EngineVersion_engineVersion_SelectedEngineVersion != null)
            {
                requestConfiguration_configuration_EngineVersion.SelectedEngineVersion = requestConfiguration_configuration_EngineVersion_engineVersion_SelectedEngineVersion;
                requestConfiguration_configuration_EngineVersionIsNull = false;
            }
             // determine if requestConfiguration_configuration_EngineVersion should be set to null
            if (requestConfiguration_configuration_EngineVersionIsNull)
            {
                requestConfiguration_configuration_EngineVersion = null;
            }
            if (requestConfiguration_configuration_EngineVersion != null)
            {
                request.Configuration.EngineVersion = requestConfiguration_configuration_EngineVersion;
                requestConfigurationIsNull = false;
            }
            Amazon.Athena.Model.IdentityCenterConfiguration requestConfiguration_configuration_IdentityCenterConfiguration = null;
            
             // populate IdentityCenterConfiguration
            var requestConfiguration_configuration_IdentityCenterConfigurationIsNull = true;
            requestConfiguration_configuration_IdentityCenterConfiguration = new Amazon.Athena.Model.IdentityCenterConfiguration();
            System.Boolean? requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityCenter = null;
            if (cmdletContext.IdentityCenterConfiguration_EnableIdentityCenter != null)
            {
                requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityCenter = cmdletContext.IdentityCenterConfiguration_EnableIdentityCenter.Value;
            }
            if (requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityCenter != null)
            {
                requestConfiguration_configuration_IdentityCenterConfiguration.EnableIdentityCenter = requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityCenter.Value;
                requestConfiguration_configuration_IdentityCenterConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_IdentityCenterInstanceArn = null;
            if (cmdletContext.IdentityCenterConfiguration_IdentityCenterInstanceArn != null)
            {
                requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_IdentityCenterInstanceArn = cmdletContext.IdentityCenterConfiguration_IdentityCenterInstanceArn;
            }
            if (requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_IdentityCenterInstanceArn != null)
            {
                requestConfiguration_configuration_IdentityCenterConfiguration.IdentityCenterInstanceArn = requestConfiguration_configuration_IdentityCenterConfiguration_identityCenterConfiguration_IdentityCenterInstanceArn;
                requestConfiguration_configuration_IdentityCenterConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_IdentityCenterConfiguration should be set to null
            if (requestConfiguration_configuration_IdentityCenterConfigurationIsNull)
            {
                requestConfiguration_configuration_IdentityCenterConfiguration = null;
            }
            if (requestConfiguration_configuration_IdentityCenterConfiguration != null)
            {
                request.Configuration.IdentityCenterConfiguration = requestConfiguration_configuration_IdentityCenterConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.Athena.Model.QueryResultsS3AccessGrantsConfiguration requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration = null;
            
             // populate QueryResultsS3AccessGrantsConfiguration
            var requestConfiguration_configuration_QueryResultsS3AccessGrantsConfigurationIsNull = true;
            requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration = new Amazon.Athena.Model.QueryResultsS3AccessGrantsConfiguration();
            Amazon.Athena.AuthenticationType requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_AuthenticationType = null;
            if (cmdletContext.QueryResultsS3AccessGrantsConfiguration_AuthenticationType != null)
            {
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_AuthenticationType = cmdletContext.QueryResultsS3AccessGrantsConfiguration_AuthenticationType;
            }
            if (requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_AuthenticationType != null)
            {
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration.AuthenticationType = requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_AuthenticationType;
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix = null;
            if (cmdletContext.QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix != null)
            {
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix = cmdletContext.QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix.Value;
            }
            if (requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix != null)
            {
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration.CreateUserLevelPrefix = requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix.Value;
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant = null;
            if (cmdletContext.QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant != null)
            {
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant = cmdletContext.QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant.Value;
            }
            if (requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant != null)
            {
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration.EnableS3AccessGrants = requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration_queryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant.Value;
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration should be set to null
            if (requestConfiguration_configuration_QueryResultsS3AccessGrantsConfigurationIsNull)
            {
                requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration = null;
            }
            if (requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration != null)
            {
                request.Configuration.QueryResultsS3AccessGrantsConfiguration = requestConfiguration_configuration_QueryResultsS3AccessGrantsConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.Athena.Model.ResultConfiguration requestConfiguration_configuration_ResultConfiguration = null;
            
             // populate ResultConfiguration
            var requestConfiguration_configuration_ResultConfigurationIsNull = true;
            requestConfiguration_configuration_ResultConfiguration = new Amazon.Athena.Model.ResultConfiguration();
            System.String requestConfiguration_configuration_ResultConfiguration_resultConfiguration_ExpectedBucketOwner = null;
            if (cmdletContext.ResultConfiguration_ExpectedBucketOwner != null)
            {
                requestConfiguration_configuration_ResultConfiguration_resultConfiguration_ExpectedBucketOwner = cmdletContext.ResultConfiguration_ExpectedBucketOwner;
            }
            if (requestConfiguration_configuration_ResultConfiguration_resultConfiguration_ExpectedBucketOwner != null)
            {
                requestConfiguration_configuration_ResultConfiguration.ExpectedBucketOwner = requestConfiguration_configuration_ResultConfiguration_resultConfiguration_ExpectedBucketOwner;
                requestConfiguration_configuration_ResultConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation = null;
            if (cmdletContext.ResultConfiguration_OutputLocation != null)
            {
                requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation = cmdletContext.ResultConfiguration_OutputLocation;
            }
            if (requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation != null)
            {
                requestConfiguration_configuration_ResultConfiguration.OutputLocation = requestConfiguration_configuration_ResultConfiguration_resultConfiguration_OutputLocation;
                requestConfiguration_configuration_ResultConfigurationIsNull = false;
            }
            Amazon.Athena.Model.AclConfiguration requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration = null;
            
             // populate AclConfiguration
            var requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfigurationIsNull = true;
            requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration = new Amazon.Athena.Model.AclConfiguration();
            Amazon.Athena.S3AclOption requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration_aclConfiguration_S3AclOption = null;
            if (cmdletContext.AclConfiguration_S3AclOption != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration_aclConfiguration_S3AclOption = cmdletContext.AclConfiguration_S3AclOption;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration_aclConfiguration_S3AclOption != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration.S3AclOption = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration_aclConfiguration_S3AclOption;
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration should be set to null
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfigurationIsNull)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration = null;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration != null)
            {
                requestConfiguration_configuration_ResultConfiguration.AclConfiguration = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_AclConfiguration;
                requestConfiguration_configuration_ResultConfigurationIsNull = false;
            }
            Amazon.Athena.Model.EncryptionConfiguration requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull = true;
            requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration = new Amazon.Athena.Model.EncryptionConfiguration();
            Amazon.Athena.EncryptionOption requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = null;
            if (cmdletContext.EncryptionConfiguration_EncryptionOption != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = cmdletContext.EncryptionConfiguration_EncryptionOption;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration.EncryptionOption = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption;
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.EncryptionConfiguration_KmsKey != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.EncryptionConfiguration_KmsKey;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey != null)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration.KmsKey = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey;
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration should be set to null
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfigurationIsNull)
            {
                requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration = null;
            }
            if (requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration != null)
            {
                requestConfiguration_configuration_ResultConfiguration.EncryptionConfiguration = requestConfiguration_configuration_ResultConfiguration_configuration_ResultConfiguration_EncryptionConfiguration;
                requestConfiguration_configuration_ResultConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ResultConfiguration should be set to null
            if (requestConfiguration_configuration_ResultConfigurationIsNull)
            {
                requestConfiguration_configuration_ResultConfiguration = null;
            }
            if (requestConfiguration_configuration_ResultConfiguration != null)
            {
                request.Configuration.ResultConfiguration = requestConfiguration_configuration_ResultConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Athena.Model.CreateWorkGroupResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.CreateWorkGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "CreateWorkGroup");
            try
            {
                #if DESKTOP
                return client.CreateWorkGroup(request);
                #elif CORECLR
                return client.CreateWorkGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Configuration_AdditionalConfiguration { get; set; }
            public System.Int64? Configuration_BytesScannedCutoffPerQuery { get; set; }
            public System.String CustomerContentEncryptionConfiguration_KmsKey { get; set; }
            public System.Boolean? Configuration_EnableMinimumEncryptionConfiguration { get; set; }
            public System.Boolean? Configuration_EnforceWorkGroupConfiguration { get; set; }
            public System.String EngineVersion_EffectiveEngineVersion { get; set; }
            public System.String EngineVersion_SelectedEngineVersion { get; set; }
            public System.String Configuration_ExecutionRole { get; set; }
            public System.Boolean? IdentityCenterConfiguration_EnableIdentityCenter { get; set; }
            public System.String IdentityCenterConfiguration_IdentityCenterInstanceArn { get; set; }
            public System.Boolean? Configuration_PublishCloudWatchMetricsEnabled { get; set; }
            public Amazon.Athena.AuthenticationType QueryResultsS3AccessGrantsConfiguration_AuthenticationType { get; set; }
            public System.Boolean? QueryResultsS3AccessGrantsConfiguration_CreateUserLevelPrefix { get; set; }
            public System.Boolean? QueryResultsS3AccessGrantsConfiguration_EnableS3AccessGrant { get; set; }
            public System.Boolean? Configuration_RequesterPaysEnabled { get; set; }
            public Amazon.Athena.S3AclOption AclConfiguration_S3AclOption { get; set; }
            public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
            public System.String EncryptionConfiguration_KmsKey { get; set; }
            public System.String ResultConfiguration_ExpectedBucketOwner { get; set; }
            public System.String ResultConfiguration_OutputLocation { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Athena.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Athena.Model.CreateWorkGroupResponse, NewATHWorkGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
