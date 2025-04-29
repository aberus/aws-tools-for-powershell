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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Sets the Data Catalog resource policy for access control.
    /// </summary>
    [Cmdlet("Set", "GLUEResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue PutResourcePolicy API operation.", Operation = new[] {"PutResourcePolicy"}, SelectReturnType = typeof(Amazon.Glue.Model.PutResourcePolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.PutResourcePolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.PutResourcePolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetGLUEResourcePolicyCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnableHybrid
        /// <summary>
        /// <para>
        /// <para>If <c>'TRUE'</c>, indicates that you are using both methods to grant cross-account
        /// access to Data Catalog resources:</para><ul><li><para>By directly updating the resource policy with <c>PutResourePolicy</c></para></li><li><para>By using the <b>Grant permissions</b> command on the Amazon Web Services Management
        /// Console.</para></li></ul><para>Must be set to <c>'TRUE'</c> if you have already used the Management Console to grant
        /// cross-account access, otherwise the call fails. Default is 'FALSE'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.EnableHybridValues")]
        public Amazon.Glue.EnableHybridValues EnableHybrid { get; set; }
        #endregion
        
        #region Parameter PolicyExistsCondition
        /// <summary>
        /// <para>
        /// <para>A value of <c>MUST_EXIST</c> is used to update a policy. A value of <c>NOT_EXIST</c>
        /// is used to create a new policy. If a value of <c>NONE</c> or a null value is used,
        /// the call does not depend on the existence of a policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ExistCondition")]
        public Amazon.Glue.ExistCondition PolicyExistsCondition { get; set; }
        #endregion
        
        #region Parameter PolicyHashCondition
        /// <summary>
        /// <para>
        /// <para>The hash value returned when the previous policy was set using <c>PutResourcePolicy</c>.
        /// Its purpose is to prevent concurrent modifications of a policy. Do not use this parameter
        /// if no previous policy has been set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyHashCondition { get; set; }
        #endregion
        
        #region Parameter PolicyInJson
        /// <summary>
        /// <para>
        /// <para>Contains the policy document to set, in JSON format.</para>
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
        public System.String PolicyInJson { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>Do not use. For internal use only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PolicyHash'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.PutResourcePolicyResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.PutResourcePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PolicyHash";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-GLUEResourcePolicy (PutResourcePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.PutResourcePolicyResponse, SetGLUEResourcePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnableHybrid = this.EnableHybrid;
            context.PolicyExistsCondition = this.PolicyExistsCondition;
            context.PolicyHashCondition = this.PolicyHashCondition;
            context.PolicyInJson = this.PolicyInJson;
            #if MODULAR
            if (this.PolicyInJson == null && ParameterWasBound(nameof(this.PolicyInJson)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyInJson which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceArn = this.ResourceArn;
            
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
            var request = new Amazon.Glue.Model.PutResourcePolicyRequest();
            
            if (cmdletContext.EnableHybrid != null)
            {
                request.EnableHybrid = cmdletContext.EnableHybrid;
            }
            if (cmdletContext.PolicyExistsCondition != null)
            {
                request.PolicyExistsCondition = cmdletContext.PolicyExistsCondition;
            }
            if (cmdletContext.PolicyHashCondition != null)
            {
                request.PolicyHashCondition = cmdletContext.PolicyHashCondition;
            }
            if (cmdletContext.PolicyInJson != null)
            {
                request.PolicyInJson = cmdletContext.PolicyInJson;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.Glue.Model.PutResourcePolicyResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.PutResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "PutResourcePolicy");
            try
            {
                return client.PutResourcePolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Glue.EnableHybridValues EnableHybrid { get; set; }
            public Amazon.Glue.ExistCondition PolicyExistsCondition { get; set; }
            public System.String PolicyHashCondition { get; set; }
            public System.String PolicyInJson { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.Glue.Model.PutResourcePolicyResponse, SetGLUEResourcePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PolicyHash;
        }
        
    }
}
