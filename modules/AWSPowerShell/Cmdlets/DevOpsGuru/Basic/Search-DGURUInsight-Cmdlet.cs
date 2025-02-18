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
using System.Threading;
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Returns a list of insights in your Amazon Web Services account. You can specify which
    /// insights are returned by their start time, one or more statuses (<c>ONGOING</c> or
    /// <c>CLOSED</c>), one or more severities (<c>LOW</c>, <c>MEDIUM</c>, and <c>HIGH</c>),
    /// and type (<c>REACTIVE</c> or <c>PROACTIVE</c>). 
    /// 
    ///  
    /// <para>
    ///  Use the <c>Filters</c> parameter to specify status and severity search parameters.
    /// Use the <c>Type</c> parameter to specify <c>REACTIVE</c> or <c>PROACTIVE</c> in your
    /// search. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "DGURUInsight", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsGuru.Model.SearchInsightsResponse")]
    [AWSCmdlet("Calls the Amazon DevOps Guru SearchInsights API operation.", Operation = new[] {"SearchInsights"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.SearchInsightsResponse))]
    [AWSCmdletOutput("Amazon.DevOpsGuru.Model.SearchInsightsResponse",
        "This cmdlet returns an Amazon.DevOpsGuru.Model.SearchInsightsResponse object containing multiple properties."
    )]
    public partial class SearchDGURUInsightCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_ResourceCollection
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DevOpsGuru.Model.ResourceCollection Filters_ResourceCollection { get; set; }
        #endregion
        
        #region Parameter ServiceCollection_ServiceName
        /// <summary>
        /// <para>
        /// <para>An array of strings that each specifies the name of an Amazon Web Services service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ServiceCollection_ServiceNames")]
        public System.String[] ServiceCollection_ServiceName { get; set; }
        #endregion
        
        #region Parameter Filters_Severity
        /// <summary>
        /// <para>
        /// <para> An array of severity values used to search for insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Severities")]
        public System.String[] Filters_Severity { get; set; }
        #endregion
        
        #region Parameter StartTimeRange
        /// <summary>
        /// <para>
        /// <para> The start of the time range passed in. Returned insights occurred after this time.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.DevOpsGuru.Model.StartTimeRange StartTimeRange { get; set; }
        #endregion
        
        #region Parameter Filters_Status
        /// <summary>
        /// <para>
        /// <para> An array of status values used to search for insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Statuses")]
        public System.String[] Filters_Status { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para> The type of insights you are searching for (<c>REACTIVE</c> or <c>PROACTIVE</c>).
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DevOpsGuru.InsightType")]
        public Amazon.DevOpsGuru.InsightType Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to use to retrieve the next page of results for this operation.
        /// If this value is null, it retrieves the first page.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.SearchInsightsResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.SearchInsightsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Type), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-DGURUInsight (SearchInsights)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.SearchInsightsResponse, SearchDGURUInsightCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_ResourceCollection = this.Filters_ResourceCollection;
            if (this.ServiceCollection_ServiceName != null)
            {
                context.ServiceCollection_ServiceName = new List<System.String>(this.ServiceCollection_ServiceName);
            }
            if (this.Filters_Severity != null)
            {
                context.Filters_Severity = new List<System.String>(this.Filters_Severity);
            }
            if (this.Filters_Status != null)
            {
                context.Filters_Status = new List<System.String>(this.Filters_Status);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTimeRange = this.StartTimeRange;
            #if MODULAR
            if (this.StartTimeRange == null && ParameterWasBound(nameof(this.StartTimeRange)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTimeRange which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.DevOpsGuru.Model.SearchInsightsRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.DevOpsGuru.Model.SearchInsightsFilters();
            Amazon.DevOpsGuru.Model.ResourceCollection requestFilters_filters_ResourceCollection = null;
            if (cmdletContext.Filters_ResourceCollection != null)
            {
                requestFilters_filters_ResourceCollection = cmdletContext.Filters_ResourceCollection;
            }
            if (requestFilters_filters_ResourceCollection != null)
            {
                request.Filters.ResourceCollection = requestFilters_filters_ResourceCollection;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Severity = null;
            if (cmdletContext.Filters_Severity != null)
            {
                requestFilters_filters_Severity = cmdletContext.Filters_Severity;
            }
            if (requestFilters_filters_Severity != null)
            {
                request.Filters.Severities = requestFilters_filters_Severity;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Status = null;
            if (cmdletContext.Filters_Status != null)
            {
                requestFilters_filters_Status = cmdletContext.Filters_Status;
            }
            if (requestFilters_filters_Status != null)
            {
                request.Filters.Statuses = requestFilters_filters_Status;
                requestFiltersIsNull = false;
            }
            Amazon.DevOpsGuru.Model.ServiceCollection requestFilters_filters_ServiceCollection = null;
            
             // populate ServiceCollection
            var requestFilters_filters_ServiceCollectionIsNull = true;
            requestFilters_filters_ServiceCollection = new Amazon.DevOpsGuru.Model.ServiceCollection();
            List<System.String> requestFilters_filters_ServiceCollection_serviceCollection_ServiceName = null;
            if (cmdletContext.ServiceCollection_ServiceName != null)
            {
                requestFilters_filters_ServiceCollection_serviceCollection_ServiceName = cmdletContext.ServiceCollection_ServiceName;
            }
            if (requestFilters_filters_ServiceCollection_serviceCollection_ServiceName != null)
            {
                requestFilters_filters_ServiceCollection.ServiceNames = requestFilters_filters_ServiceCollection_serviceCollection_ServiceName;
                requestFilters_filters_ServiceCollectionIsNull = false;
            }
             // determine if requestFilters_filters_ServiceCollection should be set to null
            if (requestFilters_filters_ServiceCollectionIsNull)
            {
                requestFilters_filters_ServiceCollection = null;
            }
            if (requestFilters_filters_ServiceCollection != null)
            {
                request.Filters.ServiceCollection = requestFilters_filters_ServiceCollection;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.StartTimeRange != null)
            {
                request.StartTimeRange = cmdletContext.StartTimeRange;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.DevOpsGuru.Model.SearchInsightsResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.SearchInsightsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "SearchInsights");
            try
            {
                return client.SearchInsightsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DevOpsGuru.Model.ResourceCollection Filters_ResourceCollection { get; set; }
            public List<System.String> ServiceCollection_ServiceName { get; set; }
            public List<System.String> Filters_Severity { get; set; }
            public List<System.String> Filters_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.DevOpsGuru.Model.StartTimeRange StartTimeRange { get; set; }
            public Amazon.DevOpsGuru.InsightType Type { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.SearchInsightsResponse, SearchDGURUInsightCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
