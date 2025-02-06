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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Describes all trust stores for the specified account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ELB2TrustStore")]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.TrustStore")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 DescribeTrustStores API operation.", Operation = new[] {"DescribeTrustStores"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.TrustStore or Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.TrustStore objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetELB2TrustStoreCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The names of the trust stores.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Names")]
        public System.String[] Name { get; set; }
        #endregion
        
        #region Parameter TrustStoreArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the trust store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustStoreArns")]
        public System.String[] TrustStoreArn { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The marker for the next set of results. (You received this marker from a previous
        /// call.)</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustStores'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustStores";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse, GetELB2TrustStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Marker = this.Marker;
            if (this.Name != null)
            {
                context.Name = new List<System.String>(this.Name);
            }
            context.PageSize = this.PageSize;
            if (this.TrustStoreArn != null)
            {
                context.TrustStoreArn = new List<System.String>(this.TrustStoreArn);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Names = cmdletContext.Name;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.TrustStoreArn != null)
            {
                request.TrustStoreArns = cmdletContext.TrustStoreArn;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextMarker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "DescribeTrustStores");
            try
            {
                #if DESKTOP
                return client.DescribeTrustStores(request);
                #elif CORECLR
                return client.DescribeTrustStoresAsync(request).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public List<System.String> Name { get; set; }
            public System.Int32? PageSize { get; set; }
            public List<System.String> TrustStoreArn { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.DescribeTrustStoresResponse, GetELB2TrustStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustStores;
        }
        
    }
}
