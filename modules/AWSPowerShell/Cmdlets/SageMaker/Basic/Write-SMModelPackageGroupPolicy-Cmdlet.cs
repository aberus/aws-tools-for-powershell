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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Adds a resouce policy to control access to a model group. For information about resoure
    /// policies, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_identity-vs-resource.html">Identity-based
    /// policies and resource-based policies</a> in the <i>Amazon Web Services Identity and
    /// Access Management User Guide.</i>.
    /// </summary>
    [Cmdlet("Write", "SMModelPackageGroupPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service PutModelPackageGroupPolicy API operation.", Operation = new[] {"PutModelPackageGroupPolicy"}, SelectReturnType = typeof(Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteSMModelPackageGroupPolicyCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ModelPackageGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the model group to add a resource policy to.</para>
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
        public System.String ModelPackageGroupName { get; set; }
        #endregion
        
        #region Parameter ResourcePolicy
        /// <summary>
        /// <para>
        /// <para>The resource policy for the model group.</para>
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
        public System.String ResourcePolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelPackageGroupArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelPackageGroupArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelPackageGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SMModelPackageGroupPolicy (PutModelPackageGroupPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse, WriteSMModelPackageGroupPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ModelPackageGroupName = this.ModelPackageGroupName;
            #if MODULAR
            if (this.ModelPackageGroupName == null && ParameterWasBound(nameof(this.ModelPackageGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelPackageGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourcePolicy = this.ResourcePolicy;
            #if MODULAR
            if (this.ResourcePolicy == null && ParameterWasBound(nameof(this.ResourcePolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourcePolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.PutModelPackageGroupPolicyRequest();
            
            if (cmdletContext.ModelPackageGroupName != null)
            {
                request.ModelPackageGroupName = cmdletContext.ModelPackageGroupName;
            }
            if (cmdletContext.ResourcePolicy != null)
            {
                request.ResourcePolicy = cmdletContext.ResourcePolicy;
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
        
        private Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.PutModelPackageGroupPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "PutModelPackageGroupPolicy");
            try
            {
                #if DESKTOP
                return client.PutModelPackageGroupPolicy(request);
                #elif CORECLR
                return client.PutModelPackageGroupPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ModelPackageGroupName { get; set; }
            public System.String ResourcePolicy { get; set; }
            public System.Func<Amazon.SageMaker.Model.PutModelPackageGroupPolicyResponse, WriteSMModelPackageGroupPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelPackageGroupArn;
        }
        
    }
}
