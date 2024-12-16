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
    /// Gets a resource policy that manages access for a model group. For information about
    /// resource policies, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_identity-vs-resource.html">Identity-based
    /// policies and resource-based policies</a> in the <i>Amazon Web Services Identity and
    /// Access Management User Guide.</i>.
    /// </summary>
    [Cmdlet("Get", "SMModelPackageGroupPolicy")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service GetModelPackageGroupPolicy API operation.", Operation = new[] {"GetModelPackageGroupPolicy"}, SelectReturnType = typeof(Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMModelPackageGroupPolicyCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ModelPackageGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the model group for which to get the resource policy.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourcePolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourcePolicy";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse, GetSMModelPackageGroupPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ModelPackageGroupName = this.ModelPackageGroupName;
            #if MODULAR
            if (this.ModelPackageGroupName == null && ParameterWasBound(nameof(this.ModelPackageGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelPackageGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.GetModelPackageGroupPolicyRequest();
            
            if (cmdletContext.ModelPackageGroupName != null)
            {
                request.ModelPackageGroupName = cmdletContext.ModelPackageGroupName;
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
        
        private Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.GetModelPackageGroupPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "GetModelPackageGroupPolicy");
            try
            {
                #if DESKTOP
                return client.GetModelPackageGroupPolicy(request);
                #elif CORECLR
                return client.GetModelPackageGroupPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SageMaker.Model.GetModelPackageGroupPolicyResponse, GetSMModelPackageGroupPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourcePolicy;
        }
        
    }
}
