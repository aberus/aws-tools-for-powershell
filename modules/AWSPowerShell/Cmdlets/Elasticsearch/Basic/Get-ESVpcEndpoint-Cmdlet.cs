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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Describes one or more Amazon OpenSearch Service-managed VPC endpoints.
    /// </summary>
    [Cmdlet("Get", "ESVpcEndpoint")]
    [OutputType("Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse")]
    [AWSCmdlet("Calls the Amazon Elasticsearch DescribeVpcEndpoints API operation.", Operation = new[] {"DescribeVpcEndpoints"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse",
        "This cmdlet returns an Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse object containing multiple properties."
    )]
    public partial class GetESVpcEndpointCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The unique identifiers of the endpoints to get information about.</para>
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
        [Alias("VpcEndpointIds")]
        public System.String[] VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse, GetESVpcEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.VpcEndpointId != null)
            {
                context.VpcEndpointId = new List<System.String>(this.VpcEndpointId);
            }
            #if MODULAR
            if (this.VpcEndpointId == null && ParameterWasBound(nameof(this.VpcEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Elasticsearch.Model.DescribeVpcEndpointsRequest();
            
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointIds = cmdletContext.VpcEndpointId;
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
        
        private Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.DescribeVpcEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "DescribeVpcEndpoints");
            try
            {
                #if DESKTOP
                return client.DescribeVpcEndpoints(request);
                #elif CORECLR
                return client.DescribeVpcEndpointsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> VpcEndpointId { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.DescribeVpcEndpointsResponse, GetESVpcEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
