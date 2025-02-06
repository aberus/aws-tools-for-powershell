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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Describes one or more of your scheduling policies.
    /// </summary>
    [Cmdlet("Get", "BATSchedulingPolicy")]
    [OutputType("Amazon.Batch.Model.SchedulingPolicyDetail")]
    [AWSCmdlet("Calls the AWS Batch DescribeSchedulingPolicies API operation.", Operation = new[] {"DescribeSchedulingPolicies"}, SelectReturnType = typeof(Amazon.Batch.Model.DescribeSchedulingPoliciesResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.SchedulingPolicyDetail or Amazon.Batch.Model.DescribeSchedulingPoliciesResponse",
        "This cmdlet returns a collection of Amazon.Batch.Model.SchedulingPolicyDetail objects.",
        "The service call response (type Amazon.Batch.Model.DescribeSchedulingPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBATSchedulingPolicyCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>A list of up to 100 scheduling policy Amazon Resource Name (ARN) entries.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Arns")]
        public System.String[] Arn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SchedulingPolicies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.DescribeSchedulingPoliciesResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.DescribeSchedulingPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SchedulingPolicies";
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
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.DescribeSchedulingPoliciesResponse, GetBATSchedulingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Arn != null)
            {
                context.Arn = new List<System.String>(this.Arn);
            }
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Batch.Model.DescribeSchedulingPoliciesRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arns = cmdletContext.Arn;
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
        
        private Amazon.Batch.Model.DescribeSchedulingPoliciesResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.DescribeSchedulingPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "DescribeSchedulingPolicies");
            try
            {
                #if DESKTOP
                return client.DescribeSchedulingPolicies(request);
                #elif CORECLR
                return client.DescribeSchedulingPoliciesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Arn { get; set; }
            public System.Func<Amazon.Batch.Model.DescribeSchedulingPoliciesResponse, GetBATSchedulingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SchedulingPolicies;
        }
        
    }
}
