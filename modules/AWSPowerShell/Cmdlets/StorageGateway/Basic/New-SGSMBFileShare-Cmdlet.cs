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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Creates a Server Message Block (SMB) file share on an existing S3 File Gateway. In
    /// Storage Gateway, a file share is a file system mount point backed by Amazon S3 cloud
    /// storage. Storage Gateway exposes file shares using an SMB interface. This operation
    /// is only supported for S3 File Gateways.
    /// 
    ///  <important><para>
    /// S3 File Gateways require Security Token Service (Amazon Web Services STS) to be activated
    /// to enable you to create a file share. Make sure that Amazon Web Services STS is activated
    /// in the Amazon Web Services Region you are creating your S3 File Gateway in. If Amazon
    /// Web Services STS is not activated in this Amazon Web Services Region, activate it.
    /// For information about how to activate Amazon Web Services STS, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_enable-regions.html">Activating
    /// and deactivating Amazon Web Services STS in an Amazon Web Services Region</a> in the
    /// <i>Identity and Access Management User Guide</i>.
    /// </para><para>
    /// File gateways don't support creating hard or symbolic links on a file share.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "SGSMBFileShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway CreateSMBFileShare API operation.", Operation = new[] {"CreateSMBFileShare"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.CreateSMBFileShareResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.CreateSMBFileShareResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.CreateSMBFileShareResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGSMBFileShareCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessBasedEnumeration
        /// <summary>
        /// <para>
        /// <para>The files and folders on this share will only be visible to users with read access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccessBasedEnumeration { get; set; }
        #endregion
        
        #region Parameter AdminUserList
        /// <summary>
        /// <para>
        /// <para>A list of users or groups in the Active Directory that will be granted administrator
        /// privileges on the file share. These users can do all file operations as the super-user.
        /// Acceptable formats include: <c>DOMAIN\User1</c>, <c>user1</c>, <c>@group1</c>, and
        /// <c>@DOMAIN\group1</c>.</para><important><para>Use this option very carefully, because any user in this list can do anything they
        /// like on the file share, regardless of file permissions.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AdminUserList { get; set; }
        #endregion
        
        #region Parameter AuditDestinationARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the storage used for audit logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuditDestinationARN { get; set; }
        #endregion
        
        #region Parameter Authentication
        /// <summary>
        /// <para>
        /// <para>The authentication method that users use to access the file share. The default is
        /// <c>ActiveDirectory</c>.</para><para>Valid Values: <c>ActiveDirectory</c> | <c>GuestAccess</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authentication { get; set; }
        #endregion
        
        #region Parameter BucketRegion
        /// <summary>
        /// <para>
        /// <para>Specifies the Region of the S3 bucket where the SMB file share stores files.</para><note><para>This parameter is required for SMB file shares that connect to Amazon S3 through a
        /// VPC endpoint, a VPC access point, or an access point alias that points to a VPC access
        /// point.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BucketRegion { get; set; }
        #endregion
        
        #region Parameter CacheAttributes_CacheStaleTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>Refreshes a file share's cache by using Time To Live (TTL). TTL is the length of time
        /// since the last refresh after which access to the directory would cause the file gateway
        /// to first refresh that directory's contents from the Amazon S3 bucket or Amazon FSx
        /// file system. The TTL duration is in seconds.</para><para>Valid Values:0, 300 to 2,592,000 seconds (5 minutes to 30 days)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheAttributes_CacheStaleTimeoutInSeconds")]
        public System.Int32? CacheAttributes_CacheStaleTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter CaseSensitivity
        /// <summary>
        /// <para>
        /// <para>The case of an object name in an Amazon S3 bucket. For <c>ClientSpecified</c>, the
        /// client determines the case sensitivity. For <c>CaseSensitive</c>, the gateway determines
        /// the case sensitivity. The default value is <c>ClientSpecified</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StorageGateway.CaseSensitivity")]
        public Amazon.StorageGateway.CaseSensitivity CaseSensitivity { get; set; }
        #endregion
        
        #region Parameter DefaultStorageClass
        /// <summary>
        /// <para>
        /// <para>The default storage class for objects put into an Amazon S3 bucket by the S3 File
        /// Gateway. The default value is <c>S3_STANDARD</c>. Optional.</para><para>Valid Values: <c>S3_STANDARD</c> | <c>S3_INTELLIGENT_TIERING</c> | <c>S3_STANDARD_IA</c>
        /// | <c>S3_ONEZONE_IA</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultStorageClass { get; set; }
        #endregion
        
        #region Parameter EncryptionType
        /// <summary>
        /// <para>
        /// <para>A value that specifies the type of server-side encryption that the file share will
        /// use for the data that it stores in Amazon S3.</para><note><para>We recommend using <c>EncryptionType</c> instead of <c>KMSEncrypted</c> to set the
        /// file share encryption method. You do not need to provide values for both parameters.</para><para>If values for both parameters exist in the same request, then the specified encryption
        /// methods must not conflict. For example, if <c>EncryptionType</c> is <c>SseS3</c>,
        /// then <c>KMSEncrypted</c> must be <c>false</c>. If <c>EncryptionType</c> is <c>SseKms</c>
        /// or <c>DsseKms</c>, then <c>KMSEncrypted</c> must be <c>true</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StorageGateway.EncryptionType")]
        public Amazon.StorageGateway.EncryptionType EncryptionType { get; set; }
        #endregion
        
        #region Parameter FileShareName
        /// <summary>
        /// <para>
        /// <para>The name of the file share. Optional.</para><note><para><c>FileShareName</c> must be set if an S3 prefix name is set in <c>LocationARN</c>,
        /// or if an access point or access point alias is used.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileShareName { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the S3 File Gateway on which you want to create a file share.</para>
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter GuessMIMETypeEnabled
        /// <summary>
        /// <para>
        /// <para>A value that enables guessing of the MIME type for uploaded objects based on file
        /// extensions. Set this value to <c>true</c> to enable MIME type guessing, otherwise
        /// set to <c>false</c>. The default value is <c>true</c>.</para><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GuessMIMETypeEnabled { get; set; }
        #endregion
        
        #region Parameter InvalidUserList
        /// <summary>
        /// <para>
        /// <para>A list of users or groups in the Active Directory that are not allowed to access the
        /// file share. A group must be prefixed with the @ character. Acceptable formats include:
        /// <c>DOMAIN\User1</c>, <c>user1</c>, <c>@group1</c>, and <c>@DOMAIN\group1</c>. Can
        /// only be set if Authentication is set to <c>ActiveDirectory</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] InvalidUserList { get; set; }
        #endregion
        
        #region Parameter KMSKey
        /// <summary>
        /// <para>
        /// <para>Optional. The Amazon Resource Name (ARN) of a symmetric customer master key (CMK)
        /// used for Amazon S3 server-side encryption. Storage Gateway does not support asymmetric
        /// CMKs. This value must be set if <c>KMSEncrypted</c> is <c>true</c>, or if <c>EncryptionType</c>
        /// is <c>SseKms</c> or <c>DsseKms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKey { get; set; }
        #endregion
        
        #region Parameter LocationARN
        /// <summary>
        /// <para>
        /// <para>A custom ARN for the backend storage used for storing data for file shares. It includes
        /// a resource ARN with an optional prefix concatenation. The prefix must end with a forward
        /// slash (/).</para><note><para>You can specify LocationARN as a bucket ARN, access point ARN or access point alias,
        /// as shown in the following examples.</para><para>Bucket ARN:</para><para><c>arn:aws:s3:::my-bucket/prefix/</c></para><para>Access point ARN:</para><para><c>arn:aws:s3:region:account-id:accesspoint/access-point-name/prefix/</c></para><para>If you specify an access point, the bucket policy must be configured to delegate access
        /// control to the access point. For information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points-policies.html#access-points-delegating-control">Delegating
        /// access control to access points</a> in the <i>Amazon S3 User Guide</i>.</para><para>Access point alias:</para><para><c>test-ap-ab123cdef4gehijklmn5opqrstuvuse1a-s3alias</c></para></note>
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
        public System.String LocationARN { get; set; }
        #endregion
        
        #region Parameter NotificationPolicy
        /// <summary>
        /// <para>
        /// <para>The notification policy of the file share. <c>SettlingTimeInSeconds</c> controls the
        /// number of seconds to wait after the last point in time a client wrote to a file before
        /// generating an <c>ObjectUploaded</c> notification. Because clients can make many small
        /// writes to files, it's best to set this parameter for as long as possible to avoid
        /// generating multiple notifications for the same file in a small time period.</para><note><para><c>SettlingTimeInSeconds</c> has no effect on the timing of the object uploading
        /// to Amazon S3, only the timing of the notification.</para><para>This setting is not meant to specify an exact time at which the notification will
        /// be sent. In some cases, the gateway might require more than the specified delay time
        /// to generate and send notifications.</para></note><para>The following example sets <c>NotificationPolicy</c> on with <c>SettlingTimeInSeconds</c>
        /// set to 60.</para><para><c>{\"Upload\": {\"SettlingTimeInSeconds\": 60}}</c></para><para>The following example sets <c>NotificationPolicy</c> off.</para><para><c>{}</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationPolicy { get; set; }
        #endregion
        
        #region Parameter ObjectACL
        /// <summary>
        /// <para>
        /// <para>A value that sets the access control list (ACL) permission for objects in the S3 bucket
        /// that a S3 File Gateway puts objects into. The default value is <c>private</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StorageGateway.ObjectACL")]
        public Amazon.StorageGateway.ObjectACL ObjectACL { get; set; }
        #endregion
        
        #region Parameter OplocksEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether opportunistic locking is enabled for the SMB file share.</para><note><para>Enabling opportunistic locking on case-sensitive shares is not recommended for workloads
        /// that involve access to files with the same name in different case.</para></note><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OplocksEnabled { get; set; }
        #endregion
        
        #region Parameter ReadOnly
        /// <summary>
        /// <para>
        /// <para>A value that sets the write status of a file share. Set this value to <c>true</c>
        /// to set the write status to read-only, otherwise set to <c>false</c>.</para><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReadOnly { get; set; }
        #endregion
        
        #region Parameter RequesterPay
        /// <summary>
        /// <para>
        /// <para>A value that sets who pays the cost of the request and the cost associated with data
        /// download from the S3 bucket. If this value is set to <c>true</c>, the requester pays
        /// the costs; otherwise, the S3 bucket owner pays. However, the S3 bucket owner always
        /// pays the cost of storing data.</para><note><para><c>RequesterPays</c> is a configuration for the S3 bucket that backs the file share,
        /// so make sure that the configuration on the file share is the same as the S3 bucket
        /// configuration.</para></note><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequesterPays")]
        public System.Boolean? RequesterPay { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The ARN of the Identity and Access Management (IAM) role that an S3 File Gateway assumes
        /// when it accesses the underlying storage.</para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter SMBACLEnabled
        /// <summary>
        /// <para>
        /// <para>Set this value to <c>true</c> to enable access control list (ACL) on the SMB file
        /// share. Set it to <c>false</c> to map file and directory permissions to the POSIX permissions.</para><para>For more information, see <a href="https://docs.aws.amazon.com/filegateway/latest/files3/smb-acl.html">Using
        /// Windows ACLs to limit SMB file share access</a> in the <i>Amazon S3 File Gateway User
        /// Guide</i>.</para><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SMBACLEnabled { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 tags that can be assigned to the NFS file share. Each tag is a
        /// key-value pair.</para><note><para>Valid characters for key and value are letters, spaces, and numbers representable
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. The maximum
        /// length of a tag's key is 128 characters, and the maximum length for a tag's value
        /// is 256.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ValidUserList
        /// <summary>
        /// <para>
        /// <para>A list of users or groups in the Active Directory that are allowed to access the file
        /// <a href="" /> share. A group must be prefixed with the @ character. Acceptable formats
        /// include: <c>DOMAIN\User1</c>, <c>user1</c>, <c>@group1</c>, and <c>@DOMAIN\group1</c>.
        /// Can only be set if Authentication is set to <c>ActiveDirectory</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ValidUserList { get; set; }
        #endregion
        
        #region Parameter VPCEndpointDNSName
        /// <summary>
        /// <para>
        /// <para>Specifies the DNS name for the VPC endpoint that the SMB file share uses to connect
        /// to Amazon S3.</para><note><para>This parameter is required for SMB file shares that connect to Amazon S3 through a
        /// VPC endpoint, a VPC access point, or an access point alias that points to a VPC access
        /// point.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VPCEndpointDNSName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique string value that you supply that is used by S3 File Gateway to ensure idempotent
        /// file share creation.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter KMSEncrypted
        /// <summary>
        /// <para>
        /// <para>Optional. Set to <c>true</c> to use Amazon S3 server-side encryption with your own
        /// KMS key (SSE-KMS), or <c>false</c> to use a key managed by Amazon S3 (SSE-S3). To
        /// use dual-layer encryption (DSSE-KMS), set the <c>EncryptionType</c> parameter instead.</para><note><para>We recommend using <c>EncryptionType</c> instead of <c>KMSEncrypted</c> to set the
        /// file share encryption method. You do not need to provide values for both parameters.</para><para>If values for both parameters exist in the same request, then the specified encryption
        /// methods must not conflict. For example, if <c>EncryptionType</c> is <c>SseS3</c>,
        /// then <c>KMSEncrypted</c> must be <c>false</c>. If <c>EncryptionType</c> is <c>SseKms</c>
        /// or <c>DsseKms</c>, then <c>KMSEncrypted</c> must be <c>true</c>.</para></note><para>Valid Values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("KMSEncrypted is deprecated, use EncryptionType instead.")]
        public System.Boolean? KMSEncrypted { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileShareARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.CreateSMBFileShareResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.CreateSMBFileShareResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileShareARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGSMBFileShare (CreateSMBFileShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.CreateSMBFileShareResponse, NewSGSMBFileShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessBasedEnumeration = this.AccessBasedEnumeration;
            if (this.AdminUserList != null)
            {
                context.AdminUserList = new List<System.String>(this.AdminUserList);
            }
            context.AuditDestinationARN = this.AuditDestinationARN;
            context.Authentication = this.Authentication;
            context.BucketRegion = this.BucketRegion;
            context.CacheAttributes_CacheStaleTimeoutInSecond = this.CacheAttributes_CacheStaleTimeoutInSecond;
            context.CaseSensitivity = this.CaseSensitivity;
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultStorageClass = this.DefaultStorageClass;
            context.EncryptionType = this.EncryptionType;
            context.FileShareName = this.FileShareName;
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuessMIMETypeEnabled = this.GuessMIMETypeEnabled;
            if (this.InvalidUserList != null)
            {
                context.InvalidUserList = new List<System.String>(this.InvalidUserList);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KMSEncrypted = this.KMSEncrypted;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KMSKey = this.KMSKey;
            context.LocationARN = this.LocationARN;
            #if MODULAR
            if (this.LocationARN == null && ParameterWasBound(nameof(this.LocationARN)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationPolicy = this.NotificationPolicy;
            context.ObjectACL = this.ObjectACL;
            context.OplocksEnabled = this.OplocksEnabled;
            context.ReadOnly = this.ReadOnly;
            context.RequesterPay = this.RequesterPay;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SMBACLEnabled = this.SMBACLEnabled;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
            }
            if (this.ValidUserList != null)
            {
                context.ValidUserList = new List<System.String>(this.ValidUserList);
            }
            context.VPCEndpointDNSName = this.VPCEndpointDNSName;
            
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
            var request = new Amazon.StorageGateway.Model.CreateSMBFileShareRequest();
            
            if (cmdletContext.AccessBasedEnumeration != null)
            {
                request.AccessBasedEnumeration = cmdletContext.AccessBasedEnumeration.Value;
            }
            if (cmdletContext.AdminUserList != null)
            {
                request.AdminUserList = cmdletContext.AdminUserList;
            }
            if (cmdletContext.AuditDestinationARN != null)
            {
                request.AuditDestinationARN = cmdletContext.AuditDestinationARN;
            }
            if (cmdletContext.Authentication != null)
            {
                request.Authentication = cmdletContext.Authentication;
            }
            if (cmdletContext.BucketRegion != null)
            {
                request.BucketRegion = cmdletContext.BucketRegion;
            }
            
             // populate CacheAttributes
            var requestCacheAttributesIsNull = true;
            request.CacheAttributes = new Amazon.StorageGateway.Model.CacheAttributes();
            System.Int32? requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond = null;
            if (cmdletContext.CacheAttributes_CacheStaleTimeoutInSecond != null)
            {
                requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond = cmdletContext.CacheAttributes_CacheStaleTimeoutInSecond.Value;
            }
            if (requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond != null)
            {
                request.CacheAttributes.CacheStaleTimeoutInSeconds = requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond.Value;
                requestCacheAttributesIsNull = false;
            }
             // determine if request.CacheAttributes should be set to null
            if (requestCacheAttributesIsNull)
            {
                request.CacheAttributes = null;
            }
            if (cmdletContext.CaseSensitivity != null)
            {
                request.CaseSensitivity = cmdletContext.CaseSensitivity;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DefaultStorageClass != null)
            {
                request.DefaultStorageClass = cmdletContext.DefaultStorageClass;
            }
            if (cmdletContext.EncryptionType != null)
            {
                request.EncryptionType = cmdletContext.EncryptionType;
            }
            if (cmdletContext.FileShareName != null)
            {
                request.FileShareName = cmdletContext.FileShareName;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.GuessMIMETypeEnabled != null)
            {
                request.GuessMIMETypeEnabled = cmdletContext.GuessMIMETypeEnabled.Value;
            }
            if (cmdletContext.InvalidUserList != null)
            {
                request.InvalidUserList = cmdletContext.InvalidUserList;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.KMSEncrypted != null)
            {
                request.KMSEncrypted = cmdletContext.KMSEncrypted.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.KMSKey != null)
            {
                request.KMSKey = cmdletContext.KMSKey;
            }
            if (cmdletContext.LocationARN != null)
            {
                request.LocationARN = cmdletContext.LocationARN;
            }
            if (cmdletContext.NotificationPolicy != null)
            {
                request.NotificationPolicy = cmdletContext.NotificationPolicy;
            }
            if (cmdletContext.ObjectACL != null)
            {
                request.ObjectACL = cmdletContext.ObjectACL;
            }
            if (cmdletContext.OplocksEnabled != null)
            {
                request.OplocksEnabled = cmdletContext.OplocksEnabled.Value;
            }
            if (cmdletContext.ReadOnly != null)
            {
                request.ReadOnly = cmdletContext.ReadOnly.Value;
            }
            if (cmdletContext.RequesterPay != null)
            {
                request.RequesterPays = cmdletContext.RequesterPay.Value;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.SMBACLEnabled != null)
            {
                request.SMBACLEnabled = cmdletContext.SMBACLEnabled.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ValidUserList != null)
            {
                request.ValidUserList = cmdletContext.ValidUserList;
            }
            if (cmdletContext.VPCEndpointDNSName != null)
            {
                request.VPCEndpointDNSName = cmdletContext.VPCEndpointDNSName;
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
        
        private Amazon.StorageGateway.Model.CreateSMBFileShareResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateSMBFileShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateSMBFileShare");
            try
            {
                #if DESKTOP
                return client.CreateSMBFileShare(request);
                #elif CORECLR
                return client.CreateSMBFileShareAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AccessBasedEnumeration { get; set; }
            public List<System.String> AdminUserList { get; set; }
            public System.String AuditDestinationARN { get; set; }
            public System.String Authentication { get; set; }
            public System.String BucketRegion { get; set; }
            public System.Int32? CacheAttributes_CacheStaleTimeoutInSecond { get; set; }
            public Amazon.StorageGateway.CaseSensitivity CaseSensitivity { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DefaultStorageClass { get; set; }
            public Amazon.StorageGateway.EncryptionType EncryptionType { get; set; }
            public System.String FileShareName { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Boolean? GuessMIMETypeEnabled { get; set; }
            public List<System.String> InvalidUserList { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? KMSEncrypted { get; set; }
            public System.String KMSKey { get; set; }
            public System.String LocationARN { get; set; }
            public System.String NotificationPolicy { get; set; }
            public Amazon.StorageGateway.ObjectACL ObjectACL { get; set; }
            public System.Boolean? OplocksEnabled { get; set; }
            public System.Boolean? ReadOnly { get; set; }
            public System.Boolean? RequesterPay { get; set; }
            public System.String Role { get; set; }
            public System.Boolean? SMBACLEnabled { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public List<System.String> ValidUserList { get; set; }
            public System.String VPCEndpointDNSName { get; set; }
            public System.Func<Amazon.StorageGateway.Model.CreateSMBFileShareResponse, NewSGSMBFileShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileShareARN;
        }
        
    }
}
