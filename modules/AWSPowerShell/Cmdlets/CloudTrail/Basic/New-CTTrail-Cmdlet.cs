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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Creates a trail that specifies the settings for delivery of log data to an Amazon
    /// S3 bucket.
    /// </summary>
    [Cmdlet("New", "CTTrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.CreateTrailResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail CreateTrail API operation.", Operation = new[] {"CreateTrail"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.CreateTrailResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.CreateTrailResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.CreateTrailResponse object containing multiple properties."
    )]
    public partial class NewCTTrailCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CloudWatchLogsLogGroupArn
        /// <summary>
        /// <para>
        /// <para>Specifies a log group name using an Amazon Resource Name (ARN), a unique identifier
        /// that represents the log group to which CloudTrail logs will be delivered. You must
        /// use a log group that exists in your account.</para><para>Not required unless you specify <c>CloudWatchLogsRoleArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogsLogGroupArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the role for the CloudWatch Logs endpoint to assume to write to a user's
        /// log group. You must use a role that exists in your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogsRoleArn { get; set; }
        #endregion
        
        #region Parameter EnableLogFileValidation
        /// <summary>
        /// <para>
        /// <para>Specifies whether log file integrity validation is enabled. The default is false.</para><note><para>When you disable log file integrity validation, the chain of digest files is broken
        /// after one hour. CloudTrail does not create digest files for log files that were delivered
        /// during a period in which log file integrity validation was disabled. For example,
        /// if you enable log file integrity validation at noon on January 1, disable it at noon
        /// on January 2, and re-enable it at noon on January 10, digest files will not be created
        /// for the log files delivered from noon on January 2 to noon on January 10. The same
        /// applies whenever you stop CloudTrail logging or delete a trail.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableLogFileValidation { get; set; }
        #endregion
        
        #region Parameter IncludeGlobalServiceEvent
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trail is publishing events from global services such as IAM
        /// to the log files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeGlobalServiceEvents")]
        public System.Boolean? IncludeGlobalServiceEvent { get; set; }
        #endregion
        
        #region Parameter IsMultiRegionTrail
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trail is created in the current Region or in all Regions. The
        /// default is false, which creates a trail only in the Region where you are signed in.
        /// As a best practice, consider creating trails that log events in all Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsMultiRegionTrail { get; set; }
        #endregion
        
        #region Parameter IsOrganizationTrail
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trail is created for all accounts in an organization in Organizations,
        /// or only for the current Amazon Web Services account. The default is false, and cannot
        /// be true unless the call is made on behalf of an Amazon Web Services account that is
        /// the management account or delegated administrator account for an organization in Organizations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsOrganizationTrail { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the KMS key ID to use to encrypt the logs delivered by CloudTrail. The value
        /// can be an alias name prefixed by <c>alias/</c>, a fully specified ARN to an alias,
        /// a fully specified ARN to a key, or a globally unique identifier.</para><para>CloudTrail also supports KMS multi-Region keys. For more information about multi-Region
        /// keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">Using
        /// multi-Region keys</a> in the <i>Key Management Service Developer Guide</i>.</para><para>Examples:</para><ul><li><para><c>alias/MyAliasName</c></para></li><li><para><c>arn:aws:kms:us-east-2:123456789012:alias/MyAliasName</c></para></li><li><para><c>arn:aws:kms:us-east-2:123456789012:key/12345678-1234-1234-1234-123456789012</c></para></li><li><para><c>12345678-1234-1234-1234-123456789012</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the trail. The name must meet the following requirements:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), periods (.), underscores (_),
        /// or dashes (-)</para></li><li><para>Start with a letter or number, and end with a letter or number</para></li><li><para>Be between 3 and 128 characters</para></li><li><para>Have no adjacent periods, underscores or dashes. Names like <c>my-_namespace</c> and
        /// <c>my--namespace</c> are not valid.</para></li><li><para>Not be in IP address format (for example, 192.168.5.4)</para></li></ul>
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
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket designated for publishing log files. For
        /// information about bucket naming rules, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucketnamingrules.html">Bucket
        /// naming rules</a> in the <i>Amazon Simple Storage Service User Guide</i>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key prefix that comes after the name of the bucket you have
        /// designated for log file delivery. For more information, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/get-and-view-cloudtrail-log-files.html#cloudtrail-find-log-files">Finding
        /// Your CloudTrail Log Files</a>. The maximum length is 200 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SnsTopicName
        /// <summary>
        /// <para>
        /// <para>Specifies the name or ARN of the Amazon SNS topic defined for notification of log
        /// file delivery. The maximum length is 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnsTopicName { get; set; }
        #endregion
        
        #region Parameter TagsList
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CloudTrail.Model.Tag[] TagsList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.CreateTrailResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.CreateTrailResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CTTrail (CreateTrail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.CreateTrailResponse, NewCTTrailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudWatchLogsLogGroupArn = this.CloudWatchLogsLogGroupArn;
            context.CloudWatchLogsRoleArn = this.CloudWatchLogsRoleArn;
            context.EnableLogFileValidation = this.EnableLogFileValidation;
            context.IncludeGlobalServiceEvent = this.IncludeGlobalServiceEvent;
            context.IsMultiRegionTrail = this.IsMultiRegionTrail;
            context.IsOrganizationTrail = this.IsOrganizationTrail;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3BucketName = this.S3BucketName;
            #if MODULAR
            if (this.S3BucketName == null && ParameterWasBound(nameof(this.S3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3KeyPrefix = this.S3KeyPrefix;
            context.SnsTopicName = this.SnsTopicName;
            if (this.TagsList != null)
            {
                context.TagsList = new List<Amazon.CloudTrail.Model.Tag>(this.TagsList);
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
            var request = new Amazon.CloudTrail.Model.CreateTrailRequest();
            
            if (cmdletContext.CloudWatchLogsLogGroupArn != null)
            {
                request.CloudWatchLogsLogGroupArn = cmdletContext.CloudWatchLogsLogGroupArn;
            }
            if (cmdletContext.CloudWatchLogsRoleArn != null)
            {
                request.CloudWatchLogsRoleArn = cmdletContext.CloudWatchLogsRoleArn;
            }
            if (cmdletContext.EnableLogFileValidation != null)
            {
                request.EnableLogFileValidation = cmdletContext.EnableLogFileValidation.Value;
            }
            if (cmdletContext.IncludeGlobalServiceEvent != null)
            {
                request.IncludeGlobalServiceEvents = cmdletContext.IncludeGlobalServiceEvent.Value;
            }
            if (cmdletContext.IsMultiRegionTrail != null)
            {
                request.IsMultiRegionTrail = cmdletContext.IsMultiRegionTrail.Value;
            }
            if (cmdletContext.IsOrganizationTrail != null)
            {
                request.IsOrganizationTrail = cmdletContext.IsOrganizationTrail.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.S3KeyPrefix != null)
            {
                request.S3KeyPrefix = cmdletContext.S3KeyPrefix;
            }
            if (cmdletContext.SnsTopicName != null)
            {
                request.SnsTopicName = cmdletContext.SnsTopicName;
            }
            if (cmdletContext.TagsList != null)
            {
                request.TagsList = cmdletContext.TagsList;
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
        
        private Amazon.CloudTrail.Model.CreateTrailResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.CreateTrailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "CreateTrail");
            try
            {
                return client.CreateTrailAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogsLogGroupArn { get; set; }
            public System.String CloudWatchLogsRoleArn { get; set; }
            public System.Boolean? EnableLogFileValidation { get; set; }
            public System.Boolean? IncludeGlobalServiceEvent { get; set; }
            public System.Boolean? IsMultiRegionTrail { get; set; }
            public System.Boolean? IsOrganizationTrail { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public System.String S3BucketName { get; set; }
            public System.String S3KeyPrefix { get; set; }
            public System.String SnsTopicName { get; set; }
            public List<Amazon.CloudTrail.Model.Tag> TagsList { get; set; }
            public System.Func<Amazon.CloudTrail.Model.CreateTrailResponse, NewCTTrailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
