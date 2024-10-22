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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// <note><para>
    /// The <i>aggregation Region</i> is now called the <i>home Region</i>.
    /// </para></note><para>
    /// Returns the current configuration in the calling account for cross-Region aggregation.
    /// A finding aggregator is a resource that establishes the home Region and any linked
    /// Regions.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SHUBFindingAggregator")]
    [OutputType("Amazon.SecurityHub.Model.GetFindingAggregatorResponse")]
    [AWSCmdlet("Calls the AWS Security Hub GetFindingAggregator API operation.", Operation = new[] {"GetFindingAggregator"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetFindingAggregatorResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.GetFindingAggregatorResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.GetFindingAggregatorResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSHUBFindingAggregatorCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FindingAggregatorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the finding aggregator to return details for. To obtain the ARN, use <c>ListFindingAggregators</c>.</para>
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
        public System.String FindingAggregatorArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetFindingAggregatorResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetFindingAggregatorResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetFindingAggregatorResponse, GetSHUBFindingAggregatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FindingAggregatorArn = this.FindingAggregatorArn;
            #if MODULAR
            if (this.FindingAggregatorArn == null && ParameterWasBound(nameof(this.FindingAggregatorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingAggregatorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.GetFindingAggregatorRequest();
            
            if (cmdletContext.FindingAggregatorArn != null)
            {
                request.FindingAggregatorArn = cmdletContext.FindingAggregatorArn;
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
        
        private Amazon.SecurityHub.Model.GetFindingAggregatorResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetFindingAggregatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetFindingAggregator");
            try
            {
                #if DESKTOP
                return client.GetFindingAggregator(request);
                #elif CORECLR
                return client.GetFindingAggregatorAsync(request).GetAwaiter().GetResult();
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
            public System.String FindingAggregatorArn { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetFindingAggregatorResponse, GetSHUBFindingAggregatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
