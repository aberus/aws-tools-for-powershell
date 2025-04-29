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
using Amazon.ECR;
using Amazon.ECR.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Updates an existing pull through cache rule.
    /// </summary>
    [Cmdlet("Update", "ECRPullThroughCacheRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry UpdatePullThroughCacheRule API operation.", Operation = new[] {"UpdatePullThroughCacheRule"}, SelectReturnType = typeof(Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse",
        "This cmdlet returns an Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse object containing multiple properties."
    )]
    public partial class UpdateECRPullThroughCacheRuleCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CredentialArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Secrets Manager secret that
        /// identifies the credentials to authenticate to the upstream registry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CredentialArn { get; set; }
        #endregion
        
        #region Parameter CustomRoleArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the IAM role to be assumed by Amazon ECR to authenticate
        /// to the ECR upstream registry. This role must be in the same account as the registry
        /// that you are configuring.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomRoleArn { get; set; }
        #endregion
        
        #region Parameter EcrRepositoryPrefix
        /// <summary>
        /// <para>
        /// <para>The repository name prefix to use when caching images from the source registry.</para>
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
        public System.String EcrRepositoryPrefix { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry associated with the
        /// pull through cache rule. If you do not specify a registry, the default registry is
        /// assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CredentialArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECRPullThroughCacheRule (UpdatePullThroughCacheRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse, UpdateECRPullThroughCacheRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CredentialArn = this.CredentialArn;
            context.CustomRoleArn = this.CustomRoleArn;
            context.EcrRepositoryPrefix = this.EcrRepositoryPrefix;
            #if MODULAR
            if (this.EcrRepositoryPrefix == null && ParameterWasBound(nameof(this.EcrRepositoryPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter EcrRepositoryPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistryId = this.RegistryId;
            
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
            var request = new Amazon.ECR.Model.UpdatePullThroughCacheRuleRequest();
            
            if (cmdletContext.CredentialArn != null)
            {
                request.CredentialArn = cmdletContext.CredentialArn;
            }
            if (cmdletContext.CustomRoleArn != null)
            {
                request.CustomRoleArn = cmdletContext.CustomRoleArn;
            }
            if (cmdletContext.EcrRepositoryPrefix != null)
            {
                request.EcrRepositoryPrefix = cmdletContext.EcrRepositoryPrefix;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
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
        
        private Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.UpdatePullThroughCacheRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "UpdatePullThroughCacheRule");
            try
            {
                return client.UpdatePullThroughCacheRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CredentialArn { get; set; }
            public System.String CustomRoleArn { get; set; }
            public System.String EcrRepositoryPrefix { get; set; }
            public System.String RegistryId { get; set; }
            public System.Func<Amazon.ECR.Model.UpdatePullThroughCacheRuleResponse, UpdateECRPullThroughCacheRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
