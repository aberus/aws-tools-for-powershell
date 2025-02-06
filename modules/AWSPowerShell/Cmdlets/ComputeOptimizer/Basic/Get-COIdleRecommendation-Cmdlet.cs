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
using Amazon.ComputeOptimizer;
using Amazon.ComputeOptimizer.Model;

namespace Amazon.PowerShell.Cmdlets.CO
{
    /// <summary>
    /// Returns idle resource recommendations. Compute Optimizer generates recommendations
    /// for idle resources that meet a specific set of requirements. For more information,
    /// see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/requirements.html">Resource
    /// requirements</a> in the <i>Compute Optimizer User Guide</i><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COIdleRecommendation")]
    [OutputType("Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse")]
    [AWSCmdlet("Calls the AWS Compute Optimizer GetIdleRecommendations API operation.", Operation = new[] {"GetIdleRecommendations"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse",
        "This cmdlet returns an Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse object containing multiple properties."
    )]
    public partial class GetCOIdleRecommendationCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Return the idle resource recommendations to the specified Amazon Web Services account
        /// IDs.</para><para>If your account is the management account or the delegated administrator of an organization,
        /// use this parameter to return the idle resource recommendations to specific member
        /// accounts.</para><para>You can only specify one account ID per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter OrderBy_Dimension
        /// <summary>
        /// <para>
        /// <para>The dimension values to sort the recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.Dimension")]
        public Amazon.ComputeOptimizer.Dimension OrderBy_Dimension { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An array of objects to specify a filter that returns a more specific list of idle
        /// resource recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ComputeOptimizer.Model.IdleRecommendationFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter OrderBy_Order
        /// <summary>
        /// <para>
        /// <para>The order to sort the recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.Order")]
        public Amazon.ComputeOptimizer.Order OrderBy_Order { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN that identifies the idle resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of idle resource recommendations to return with a single request.
        /// </para><para>To retrieve the remaining results, make another request with the returned <c>nextToken</c>
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next page of idle resource recommendations.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
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
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse, GetCOIdleRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ComputeOptimizer.Model.IdleRecommendationFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OrderBy_Dimension = this.OrderBy_Dimension;
            context.OrderBy_Order = this.OrderBy_Order;
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
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
            var request = new Amazon.ComputeOptimizer.Model.GetIdleRecommendationsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate OrderBy
            var requestOrderByIsNull = true;
            request.OrderBy = new Amazon.ComputeOptimizer.Model.OrderBy();
            Amazon.ComputeOptimizer.Dimension requestOrderBy_orderBy_Dimension = null;
            if (cmdletContext.OrderBy_Dimension != null)
            {
                requestOrderBy_orderBy_Dimension = cmdletContext.OrderBy_Dimension;
            }
            if (requestOrderBy_orderBy_Dimension != null)
            {
                request.OrderBy.Dimension = requestOrderBy_orderBy_Dimension;
                requestOrderByIsNull = false;
            }
            Amazon.ComputeOptimizer.Order requestOrderBy_orderBy_Order = null;
            if (cmdletContext.OrderBy_Order != null)
            {
                requestOrderBy_orderBy_Order = cmdletContext.OrderBy_Order;
            }
            if (requestOrderBy_orderBy_Order != null)
            {
                request.OrderBy.Order = requestOrderBy_orderBy_Order;
                requestOrderByIsNull = false;
            }
             // determine if request.OrderBy should be set to null
            if (requestOrderByIsNull)
            {
                request.OrderBy = null;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
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
        
        private Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.GetIdleRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "GetIdleRecommendations");
            try
            {
                #if DESKTOP
                return client.GetIdleRecommendations(request);
                #elif CORECLR
                return client.GetIdleRecommendationsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public List<Amazon.ComputeOptimizer.Model.IdleRecommendationFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ComputeOptimizer.Dimension OrderBy_Dimension { get; set; }
            public Amazon.ComputeOptimizer.Order OrderBy_Order { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.GetIdleRecommendationsResponse, GetCOIdleRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
