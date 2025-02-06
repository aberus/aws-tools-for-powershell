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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Creates a data access policy for OpenSearch Serverless. Access policies limit access
    /// to collections and the resources within them, and allow a user to access that data
    /// irrespective of the access mechanism or network source. For more information, see
    /// <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-data-access.html">Data
    /// access control for Amazon OpenSearch Serverless</a>.
    /// </summary>
    [Cmdlet("New", "OSSAccessPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.AccessPolicyDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless CreateAccessPolicy API operation.", Operation = new[] {"CreateAccessPolicy"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.AccessPolicyDetail or Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.AccessPolicyDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSSAccessPolicyCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the policy. Typically used to store information about the permissions
        /// defined in the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The JSON policy document to use as the content for the policy.</para>
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.AccessPolicyType")]
        public Amazon.OpenSearchServerless.AccessPolicyType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessPolicyDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessPolicyDetail";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSSAccessPolicy (CreateAccessPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse, NewOSSAccessPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchServerless.Model.CreateAccessPolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.CreateAccessPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "CreateAccessPolicy");
            try
            {
                #if DESKTOP
                return client.CreateAccessPolicy(request);
                #elif CORECLR
                return client.CreateAccessPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Policy { get; set; }
            public Amazon.OpenSearchServerless.AccessPolicyType Type { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.CreateAccessPolicyResponse, NewOSSAccessPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessPolicyDetail;
        }
        
    }
}
