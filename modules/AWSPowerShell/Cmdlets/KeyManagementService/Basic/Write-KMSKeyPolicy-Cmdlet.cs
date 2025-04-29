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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Attaches a key policy to the specified KMS key. 
    /// 
    ///  
    /// <para>
    /// For more information about key policies, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">Key
    /// Policies</a> in the <i>Key Management Service Developer Guide</i>. For help writing
    /// and formatting a JSON policy document, see the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies.html">IAM
    /// JSON Policy Reference</a> in the <i><i>Identity and Access Management User Guide</i></i>. For examples of adding a key policy in multiple programming languages, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-key-policies.html#put-policy">Setting
    /// a key policy</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:PutKeyPolicy</a>
    /// (key policy)
    /// </para><para><b>Related operations</b>: <a>GetKeyPolicy</a></para><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "KMSKeyPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service PutKeyPolicy API operation.", Operation = new[] {"PutKeyPolicy"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.PutKeyPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.PutKeyPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.PutKeyPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteKMSKeyPolicyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BypassPolicyLockoutSafetyCheck
        /// <summary>
        /// <para>
        /// <para>Skips ("bypasses") the key policy lockout safety check. The default value is false.</para><important><para>Setting this value to true increases the risk that the KMS key becomes unmanageable.
        /// Do not set this value to true indiscriminately.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-default.html#prevent-unmanageable-key">Default
        /// key policy</a> in the <i>Key Management Service Developer Guide</i>.</para></important><para>Use this parameter only when you intend to prevent the principal that is making the
        /// request from making a subsequent <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_PutKeyPolicy.html">PutKeyPolicy</a>
        /// request on the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Sets the key policy on the specified KMS key.</para><para>Specify the key ID or key ARN of the KMS key.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The key policy to attach to the KMS key.</para><para>The key policy must meet the following criteria:</para><ul><li><para>The key policy must allow the calling principal to make a subsequent <c>PutKeyPolicy</c>
        /// request on the KMS key. This reduces the risk that the KMS key becomes unmanageable.
        /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-default.html#prevent-unmanageable-key">Default
        /// key policy</a> in the <i>Key Management Service Developer Guide</i>. (To omit this
        /// condition, set <c>BypassPolicyLockoutSafetyCheck</c> to true.)</para></li><li><para>Each statement in the key policy must contain one or more principals. The principals
        /// in the key policy must exist and be visible to KMS. When you create a new Amazon Web
        /// Services principal, you might need to enforce a delay before including the new principal
        /// in a key policy because the new principal might not be immediately visible to KMS.
        /// For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/troubleshoot_general.html#troubleshoot_general_eventual-consistency">Changes
        /// that I make are not always immediately visible</a> in the <i>Amazon Web Services Identity
        /// and Access Management User Guide</i>.</para></li></ul><para>A key policy document can include only the following characters:</para><ul><li><para>Printable ASCII characters from the space character (<c>\u0020</c>) through the end
        /// of the ASCII character range.</para></li><li><para>Printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// <c>\u00FF</c>).</para></li><li><para>The tab (<c>\u0009</c>), line feed (<c>\u000A</c>), and carriage return (<c>\u000D</c>)
        /// special characters</para></li></ul><para>For information about key policies, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">Key
        /// policies in KMS</a> in the <i>Key Management Service Developer Guide</i>.For help
        /// writing and formatting a JSON policy document, see the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies.html">IAM
        /// JSON Policy Reference</a> in the <i><i>Identity and Access Management User Guide</i></i>.</para>
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
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the key policy. If no policy name is specified, the default value is <c>default</c>.
        /// The only valid value is <c>default</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.PutKeyPolicyResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KMSKeyPolicy (PutKeyPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.PutKeyPolicyResponse, WriteKMSKeyPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BypassPolicyLockoutSafetyCheck = this.BypassPolicyLockoutSafetyCheck;
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyName = this.PolicyName;
            
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
            var request = new Amazon.KeyManagementService.Model.PutKeyPolicyRequest();
            
            if (cmdletContext.BypassPolicyLockoutSafetyCheck != null)
            {
                request.BypassPolicyLockoutSafetyCheck = cmdletContext.BypassPolicyLockoutSafetyCheck.Value;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
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
        
        private Amazon.KeyManagementService.Model.PutKeyPolicyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.PutKeyPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "PutKeyPolicy");
            try
            {
                return client.PutKeyPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
            public System.String KeyId { get; set; }
            public System.String Policy { get; set; }
            public System.String PolicyName { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.PutKeyPolicyResponse, WriteKMSKeyPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
