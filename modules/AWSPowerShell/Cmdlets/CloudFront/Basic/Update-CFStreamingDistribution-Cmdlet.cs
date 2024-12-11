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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Update a streaming distribution.
    /// </summary>
    [Cmdlet("Update", "CFStreamingDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.StreamingDistribution")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateStreamingDistribution API operation.", Operation = new[] {"UpdateStreamingDistribution"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateStreamingDistributionResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.StreamingDistribution or Amazon.CloudFront.Model.UpdateStreamingDistributionResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.StreamingDistribution object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateStreamingDistributionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFStreamingDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to store the access logs in, for example, <c>myawslogbucket.s3.amazonaws.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Logging_Bucket")]
        public System.String Logging_Bucket { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique value (for example, a date-time stamp) that ensures that the request can't
        /// be replayed.</para><para>If the value of <c>CallerReference</c> is new (regardless of the content of the <c>StreamingDistributionConfig</c>
        /// object), CloudFront creates a new distribution.</para><para>If <c>CallerReference</c> is a value that you already sent in a previous request to
        /// create a distribution, CloudFront returns a <c>DistributionAlreadyExists</c> error.</para>
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
        public System.String StreamingDistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Comment
        /// <summary>
        /// <para>
        /// <para>Any comments you want to include about the streaming distribution.</para>
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
        public System.String StreamingDistributionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter S3Origin_DomainName
        /// <summary>
        /// <para>
        /// <para>The DNS name of the Amazon S3 origin.</para>
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
        [Alias("StreamingDistributionConfig_S3Origin_DomainName")]
        public System.String S3Origin_DomainName { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether the streaming distribution is enabled to accept user requests for content.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? StreamingDistributionConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter Logging_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want CloudFront to save access logs to an Amazon S3 bucket.
        /// If you don't want to enable logging when you create a streaming distribution or if
        /// you want to disable logging for an existing streaming distribution, specify <c>false</c>
        /// for <c>Enabled</c>, and specify <c>empty Bucket</c> and <c>Prefix</c> elements. If
        /// you specify <c>false</c> for <c>Enabled</c> but you specify values for <c>Bucket</c>
        /// and <c>Prefix</c>, the values are automatically deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Logging_Enabled")]
        public System.Boolean? Logging_Enabled { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// <para>This field is <c>true</c> if any of the Amazon Web Services accounts in the list are
        /// configured as trusted signers. If not, this field is <c>false</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StreamingDistributionConfig_TrustedSigners_Enabled")]
        public System.Boolean? TrustedSigners_Enabled { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The streaming distribution's id.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <c>ETag</c> header that you received when retrieving the streaming
        /// distribution's configuration. For example: <c>E2QWRUHAPOMQZL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter Aliases_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the CNAME aliases, if any, that you want to associate
        /// with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Aliases_Items")]
        public System.String[] Aliases_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services account identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter S3Origin_OriginAccessIdentity
        /// <summary>
        /// <para>
        /// <para>The CloudFront origin access identity to associate with the distribution. Use an origin
        /// access identity to configure the distribution so that end users can only access objects
        /// in an Amazon S3 bucket through CloudFront.</para><para>If you want end users to be able to access objects using either the CloudFront URL
        /// or the Amazon S3 URL, specify an empty <c>OriginAccessIdentity</c> element.</para><para>To delete the origin access identity from an existing distribution, update the distribution
        /// configuration and include an empty <c>OriginAccessIdentity</c> element.</para><para>To replace the origin access identity, update the distribution configuration and specify
        /// the new origin access identity.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/private-content-restricting-access-to-s3.html">Using
        /// an Origin Access Identity to Restrict Access to Your Amazon S3 Content</a> in the
        /// <i> Amazon CloudFront Developer Guide</i>.</para>
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
        [Alias("StreamingDistributionConfig_S3Origin_OriginAccessIdentity")]
        public System.String S3Origin_OriginAccessIdentity { get; set; }
        #endregion
        
        #region Parameter Logging_Prefix
        /// <summary>
        /// <para>
        /// <para>An optional string that you want CloudFront to prefix to the access log filenames
        /// for this streaming distribution, for example, <c>myprefix/</c>. If you want to enable
        /// logging, but you don't want to specify a prefix, you still must include an empty <c>Prefix</c>
        /// element in the <c>Logging</c> element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Logging_Prefix")]
        public System.String Logging_Prefix { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_PriceClass
        /// <summary>
        /// <para>
        /// <para>A complex type that contains information about price class for this streaming distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFront.PriceClass")]
        public Amazon.CloudFront.PriceClass StreamingDistributionConfig_PriceClass { get; set; }
        #endregion
        
        #region Parameter Aliases_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of CNAME aliases, if any, that you want to associate with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Aliases_Quantity")]
        public System.Int32? Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Amazon Web Services accounts in the list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StreamingDistributionConfig_TrustedSigners_Quantity")]
        public System.Int32? TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamingDistribution'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateStreamingDistributionResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateStreamingDistributionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamingDistribution";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFStreamingDistribution (UpdateStreamingDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateStreamingDistributionResponse, UpdateCFStreamingDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            if (this.Aliases_Item != null)
            {
                context.Aliases_Item = new List<System.String>(this.Aliases_Item);
            }
            context.Aliases_Quantity = this.Aliases_Quantity;
            context.StreamingDistributionConfig_CallerReference = this.StreamingDistributionConfig_CallerReference;
            #if MODULAR
            if (this.StreamingDistributionConfig_CallerReference == null && ParameterWasBound(nameof(this.StreamingDistributionConfig_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingDistributionConfig_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamingDistributionConfig_Comment = this.StreamingDistributionConfig_Comment;
            #if MODULAR
            if (this.StreamingDistributionConfig_Comment == null && ParameterWasBound(nameof(this.StreamingDistributionConfig_Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingDistributionConfig_Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamingDistributionConfig_Enabled = this.StreamingDistributionConfig_Enabled;
            #if MODULAR
            if (this.StreamingDistributionConfig_Enabled == null && ParameterWasBound(nameof(this.StreamingDistributionConfig_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingDistributionConfig_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Logging_Bucket = this.Logging_Bucket;
            context.Logging_Enabled = this.Logging_Enabled;
            context.Logging_Prefix = this.Logging_Prefix;
            context.StreamingDistributionConfig_PriceClass = this.StreamingDistributionConfig_PriceClass;
            context.S3Origin_DomainName = this.S3Origin_DomainName;
            #if MODULAR
            if (this.S3Origin_DomainName == null && ParameterWasBound(nameof(this.S3Origin_DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Origin_DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Origin_OriginAccessIdentity = this.S3Origin_OriginAccessIdentity;
            #if MODULAR
            if (this.S3Origin_OriginAccessIdentity == null && ParameterWasBound(nameof(this.S3Origin_OriginAccessIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Origin_OriginAccessIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            #if MODULAR
            if (this.TrustedSigners_Enabled == null && ParameterWasBound(nameof(this.TrustedSigners_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustedSigners_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TrustedSigners_Item != null)
            {
                context.TrustedSigners_Item = new List<System.String>(this.TrustedSigners_Item);
            }
            context.TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            #if MODULAR
            if (this.TrustedSigners_Quantity == null && ParameterWasBound(nameof(this.TrustedSigners_Quantity)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustedSigners_Quantity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.UpdateStreamingDistributionRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            
             // populate StreamingDistributionConfig
            var requestStreamingDistributionConfigIsNull = true;
            request.StreamingDistributionConfig = new Amazon.CloudFront.Model.StreamingDistributionConfig();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference = null;
            if (cmdletContext.StreamingDistributionConfig_CallerReference != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference = cmdletContext.StreamingDistributionConfig_CallerReference;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference != null)
            {
                request.StreamingDistributionConfig.CallerReference = requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference;
                requestStreamingDistributionConfigIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Comment = null;
            if (cmdletContext.StreamingDistributionConfig_Comment != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Comment = cmdletContext.StreamingDistributionConfig_Comment;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Comment != null)
            {
                request.StreamingDistributionConfig.Comment = requestStreamingDistributionConfig_streamingDistributionConfig_Comment;
                requestStreamingDistributionConfigIsNull = false;
            }
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_Enabled = null;
            if (cmdletContext.StreamingDistributionConfig_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Enabled = cmdletContext.StreamingDistributionConfig_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Enabled != null)
            {
                request.StreamingDistributionConfig.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_Enabled.Value;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.PriceClass requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass = null;
            if (cmdletContext.StreamingDistributionConfig_PriceClass != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass = cmdletContext.StreamingDistributionConfig_PriceClass;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass != null)
            {
                request.StreamingDistributionConfig.PriceClass = requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Aliases requestStreamingDistributionConfig_streamingDistributionConfig_Aliases = null;
            
             // populate Aliases
            var requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.Aliases_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item = cmdletContext.Aliases_Item;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases.Items = requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item;
                requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.Aliases_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity = cmdletContext.Aliases_Quantity.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases.Quantity = requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_Aliases should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Aliases != null)
            {
                request.StreamingDistributionConfig.Aliases = requestStreamingDistributionConfig_streamingDistributionConfig_Aliases;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.S3Origin requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin = null;
            
             // populate S3Origin
            var requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin = new Amazon.CloudFront.Model.S3Origin();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName = null;
            if (cmdletContext.S3Origin_DomainName != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName = cmdletContext.S3Origin_DomainName;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin.DomainName = requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName;
                requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = null;
            if (cmdletContext.S3Origin_OriginAccessIdentity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = cmdletContext.S3Origin_OriginAccessIdentity;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin.OriginAccessIdentity = requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity;
                requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin != null)
            {
                request.StreamingDistributionConfig.S3Origin = requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.StreamingLoggingConfig requestStreamingDistributionConfig_streamingDistributionConfig_Logging = null;
            
             // populate Logging
            var requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_Logging = new Amazon.CloudFront.Model.StreamingLoggingConfig();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.Logging_Bucket != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket = cmdletContext.Logging_Bucket;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Bucket = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.Logging_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled = cmdletContext.Logging_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.Logging_Prefix != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix = cmdletContext.Logging_Prefix;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Prefix = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_Logging should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging != null)
            {
                request.StreamingDistributionConfig.Logging = requestStreamingDistributionConfig_streamingDistributionConfig_Logging;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.TrustedSigners requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners = null;
            
             // populate TrustedSigners
            var requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.TrustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = cmdletContext.TrustedSigners_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
            List<System.String> requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.TrustedSigners_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item = cmdletContext.TrustedSigners_Item;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Items = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.TrustedSigners_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = cmdletContext.TrustedSigners_Quantity.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Quantity = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners != null)
            {
                request.StreamingDistributionConfig.TrustedSigners = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners;
                requestStreamingDistributionConfigIsNull = false;
            }
             // determine if request.StreamingDistributionConfig should be set to null
            if (requestStreamingDistributionConfigIsNull)
            {
                request.StreamingDistributionConfig = null;
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
        
        private Amazon.CloudFront.Model.UpdateStreamingDistributionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateStreamingDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateStreamingDistribution");
            try
            {
                #if DESKTOP
                return client.UpdateStreamingDistribution(request);
                #elif CORECLR
                return client.UpdateStreamingDistributionAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public List<System.String> Aliases_Item { get; set; }
            public System.Int32? Aliases_Quantity { get; set; }
            public System.String StreamingDistributionConfig_CallerReference { get; set; }
            public System.String StreamingDistributionConfig_Comment { get; set; }
            public System.Boolean? StreamingDistributionConfig_Enabled { get; set; }
            public System.String Logging_Bucket { get; set; }
            public System.Boolean? Logging_Enabled { get; set; }
            public System.String Logging_Prefix { get; set; }
            public Amazon.CloudFront.PriceClass StreamingDistributionConfig_PriceClass { get; set; }
            public System.String S3Origin_DomainName { get; set; }
            public System.String S3Origin_OriginAccessIdentity { get; set; }
            public System.Boolean? TrustedSigners_Enabled { get; set; }
            public List<System.String> TrustedSigners_Item { get; set; }
            public System.Int32? TrustedSigners_Quantity { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateStreamingDistributionResponse, UpdateCFStreamingDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamingDistribution;
        }
        
    }
}
