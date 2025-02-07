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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Gets the content for the specified Network Access Scope.
    /// </summary>
    [Cmdlet("Get", "EC2NetworkInsightsAccessScopeContent")]
    [OutputType("Amazon.EC2.Model.NetworkInsightsAccessScopeContent")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetNetworkInsightsAccessScopeContent API operation.", Operation = new[] {"GetNetworkInsightsAccessScopeContent"}, SelectReturnType = typeof(Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInsightsAccessScopeContent or Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse",
        "This cmdlet returns an Amazon.EC2.Model.NetworkInsightsAccessScopeContent object.",
        "The service call response (type Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2NetworkInsightsAccessScopeContentCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NetworkInsightsAccessScopeId
        /// <summary>
        /// <para>
        /// <para>The ID of the Network Access Scope.</para>
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
        public System.String NetworkInsightsAccessScopeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkInsightsAccessScopeContent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkInsightsAccessScopeContent";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse, GetEC2NetworkInsightsAccessScopeContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NetworkInsightsAccessScopeId = this.NetworkInsightsAccessScopeId;
            #if MODULAR
            if (this.NetworkInsightsAccessScopeId == null && ParameterWasBound(nameof(this.NetworkInsightsAccessScopeId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInsightsAccessScopeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentRequest();
            
            if (cmdletContext.NetworkInsightsAccessScopeId != null)
            {
                request.NetworkInsightsAccessScopeId = cmdletContext.NetworkInsightsAccessScopeId;
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
        
        private Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetNetworkInsightsAccessScopeContent");
            try
            {
                #if DESKTOP
                return client.GetNetworkInsightsAccessScopeContent(request);
                #elif CORECLR
                return client.GetNetworkInsightsAccessScopeContentAsync(request).GetAwaiter().GetResult();
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
            public System.String NetworkInsightsAccessScopeId { get; set; }
            public System.Func<Amazon.EC2.Model.GetNetworkInsightsAccessScopeContentResponse, GetEC2NetworkInsightsAccessScopeContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkInsightsAccessScopeContent;
        }
        
    }
}
