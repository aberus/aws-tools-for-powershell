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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Returns the resource-based policy document attached to the resource, which can be
    /// a table or stream, in JSON format.
    /// 
    ///  
    /// <para><c>GetResourcePolicy</c> follows an <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadConsistency.html"><i>eventually consistent</i></a> model. The following list describes the outcomes
    /// when you issue the <c>GetResourcePolicy</c> request immediately after issuing another
    /// request:
    /// </para><ul><li><para>
    /// If you issue a <c>GetResourcePolicy</c> request immediately after a <c>PutResourcePolicy</c>
    /// request, DynamoDB might return a <c>PolicyNotFoundException</c>.
    /// </para></li><li><para>
    /// If you issue a <c>GetResourcePolicy</c>request immediately after a <c>DeleteResourcePolicy</c>
    /// request, DynamoDB might return the policy that was present before the deletion request.
    /// </para></li><li><para>
    /// If you issue a <c>GetResourcePolicy</c> request immediately after a <c>CreateTable</c>
    /// request, which includes a resource-based policy, DynamoDB might return a <c>ResourceNotFoundException</c>
    /// or a <c>PolicyNotFoundException</c>.
    /// </para></li></ul><para>
    /// Because <c>GetResourcePolicy</c> uses an <i>eventually consistent</i> query, the metadata
    /// for your policy or table might not be available at that moment. Wait for a few seconds,
    /// and then retry the <c>GetResourcePolicy</c> request.
    /// </para><para>
    /// After a <c>GetResourcePolicy</c> request returns a policy created using the <c>PutResourcePolicy</c>
    /// request, the policy will be applied in the authorization of requests to the resource.
    /// Because this process is eventually consistent, it will take some time to apply the
    /// policy to all requests to a resource. Policies that you attach while creating a table
    /// using the <c>CreateTable</c> request will always be applied to all requests for that
    /// table.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBResourcePolicy")]
    [OutputType("Amazon.DynamoDBv2.Model.GetResourcePolicyResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB GetResourcePolicy API operation.", Operation = new[] {"GetResourcePolicy"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.GetResourcePolicyResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.GetResourcePolicyResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.GetResourcePolicyResponse object containing multiple properties."
    )]
    public partial class GetDDBResourcePolicyCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the DynamoDB resource to which the policy is attached.
        /// The resources you can specify include tables and streams.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.GetResourcePolicyResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.GetResourcePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.GetResourcePolicyResponse, GetDDBResourcePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.GetResourcePolicyRequest();
            
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
        
        private Amazon.DynamoDBv2.Model.GetResourcePolicyResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.GetResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "GetResourcePolicy");
            try
            {
                #if DESKTOP
                return client.GetResourcePolicy(request);
                #elif CORECLR
                return client.GetResourcePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.GetResourcePolicyResponse, GetDDBResourcePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
