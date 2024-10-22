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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Lists the rule executions that have occurred in a pipeline configured for conditions
    /// with rules.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CPRuleExecutionList")]
    [OutputType("Amazon.CodePipeline.Model.RuleExecutionDetail")]
    [AWSCmdlet("Calls the AWS CodePipeline ListRuleExecutions API operation.", Operation = new[] {"ListRuleExecutions"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.ListRuleExecutionsResponse))]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.RuleExecutionDetail or Amazon.CodePipeline.Model.ListRuleExecutionsResponse",
        "This cmdlet returns a collection of Amazon.CodePipeline.Model.RuleExecutionDetail objects.",
        "The service call response (type Amazon.CodePipeline.Model.ListRuleExecutionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCPRuleExecutionListCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LatestInPipelineExecution_PipelineExecutionId
        /// <summary>
        /// <para>
        /// <para>The execution ID for the latest execution in the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_LatestInPipelineExecution_PipelineExecutionId")]
        public System.String LatestInPipelineExecution_PipelineExecutionId { get; set; }
        #endregion
        
        #region Parameter Filter_PipelineExecutionId
        /// <summary>
        /// <para>
        /// <para>The pipeline execution ID used to filter rule execution history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_PipelineExecutionId { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline for which you want to get execution summary information.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter LatestInPipelineExecution_StartTimeRange
        /// <summary>
        /// <para>
        /// <para>The start time to filter on for the latest execution in the pipeline. Valid options:</para><ul><li><para>All</para></li><li><para>Latest</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_LatestInPipelineExecution_StartTimeRange")]
        [AWSConstantClassSource("Amazon.CodePipeline.StartTimeRange")]
        public Amazon.CodePipeline.StartTimeRange LatestInPipelineExecution_StartTimeRange { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another call with the returned nextToken value. Pipeline history is
        /// limited to the most recent 12 months, based on pipeline execution start times. Default
        /// value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token that was returned from the previous <c>ListRuleExecutions</c> call, which
        /// can be used to return the next set of rule executions in the list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuleExecutionDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.ListRuleExecutionsResponse).
        /// Specifying the name of a property of type Amazon.CodePipeline.Model.ListRuleExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleExecutionDetails";
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
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.ListRuleExecutionsResponse, GetCPRuleExecutionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LatestInPipelineExecution_PipelineExecutionId = this.LatestInPipelineExecution_PipelineExecutionId;
            context.LatestInPipelineExecution_StartTimeRange = this.LatestInPipelineExecution_StartTimeRange;
            context.Filter_PipelineExecutionId = this.Filter_PipelineExecutionId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CodePipeline.Model.ListRuleExecutionsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.CodePipeline.Model.RuleExecutionFilter();
            System.String requestFilter_filter_PipelineExecutionId = null;
            if (cmdletContext.Filter_PipelineExecutionId != null)
            {
                requestFilter_filter_PipelineExecutionId = cmdletContext.Filter_PipelineExecutionId;
            }
            if (requestFilter_filter_PipelineExecutionId != null)
            {
                request.Filter.PipelineExecutionId = requestFilter_filter_PipelineExecutionId;
                requestFilterIsNull = false;
            }
            Amazon.CodePipeline.Model.LatestInPipelineExecutionFilter requestFilter_filter_LatestInPipelineExecution = null;
            
             // populate LatestInPipelineExecution
            var requestFilter_filter_LatestInPipelineExecutionIsNull = true;
            requestFilter_filter_LatestInPipelineExecution = new Amazon.CodePipeline.Model.LatestInPipelineExecutionFilter();
            System.String requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_PipelineExecutionId = null;
            if (cmdletContext.LatestInPipelineExecution_PipelineExecutionId != null)
            {
                requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_PipelineExecutionId = cmdletContext.LatestInPipelineExecution_PipelineExecutionId;
            }
            if (requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_PipelineExecutionId != null)
            {
                requestFilter_filter_LatestInPipelineExecution.PipelineExecutionId = requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_PipelineExecutionId;
                requestFilter_filter_LatestInPipelineExecutionIsNull = false;
            }
            Amazon.CodePipeline.StartTimeRange requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_StartTimeRange = null;
            if (cmdletContext.LatestInPipelineExecution_StartTimeRange != null)
            {
                requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_StartTimeRange = cmdletContext.LatestInPipelineExecution_StartTimeRange;
            }
            if (requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_StartTimeRange != null)
            {
                requestFilter_filter_LatestInPipelineExecution.StartTimeRange = requestFilter_filter_LatestInPipelineExecution_latestInPipelineExecution_StartTimeRange;
                requestFilter_filter_LatestInPipelineExecutionIsNull = false;
            }
             // determine if requestFilter_filter_LatestInPipelineExecution should be set to null
            if (requestFilter_filter_LatestInPipelineExecutionIsNull)
            {
                requestFilter_filter_LatestInPipelineExecution = null;
            }
            if (requestFilter_filter_LatestInPipelineExecution != null)
            {
                request.Filter.LatestInPipelineExecution = requestFilter_filter_LatestInPipelineExecution;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
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
        
        private Amazon.CodePipeline.Model.ListRuleExecutionsResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.ListRuleExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "ListRuleExecutions");
            try
            {
                #if DESKTOP
                return client.ListRuleExecutions(request);
                #elif CORECLR
                return client.ListRuleExecutionsAsync(request).GetAwaiter().GetResult();
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
            public System.String LatestInPipelineExecution_PipelineExecutionId { get; set; }
            public Amazon.CodePipeline.StartTimeRange LatestInPipelineExecution_StartTimeRange { get; set; }
            public System.String Filter_PipelineExecutionId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PipelineName { get; set; }
            public System.Func<Amazon.CodePipeline.Model.ListRuleExecutionsResponse, GetCPRuleExecutionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleExecutionDetails;
        }
        
    }
}
