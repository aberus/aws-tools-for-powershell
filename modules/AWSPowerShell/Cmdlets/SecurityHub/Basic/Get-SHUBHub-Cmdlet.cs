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
    /// Returns details about the Hub resource in your account, including the <c>HubArn</c>
    /// and the time when you enabled Security Hub.
    /// </summary>
    [Cmdlet("Get", "SHUBHub")]
    [OutputType("Amazon.SecurityHub.Model.DescribeHubResponse")]
    [AWSCmdlet("Calls the AWS Security Hub DescribeHub API operation.", Operation = new[] {"DescribeHub"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.DescribeHubResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.DescribeHubResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.DescribeHubResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSHUBHubCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HubArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Hub resource to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HubArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.DescribeHubResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.DescribeHubResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.DescribeHubResponse, GetSHUBHubCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HubArn = this.HubArn;
            
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
            var request = new Amazon.SecurityHub.Model.DescribeHubRequest();
            
            if (cmdletContext.HubArn != null)
            {
                request.HubArn = cmdletContext.HubArn;
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
        
        private Amazon.SecurityHub.Model.DescribeHubResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.DescribeHubRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "DescribeHub");
            try
            {
                #if DESKTOP
                return client.DescribeHub(request);
                #elif CORECLR
                return client.DescribeHubAsync(request).GetAwaiter().GetResult();
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
            public System.String HubArn { get; set; }
            public System.Func<Amazon.SecurityHub.Model.DescribeHubResponse, GetSHUBHubCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
