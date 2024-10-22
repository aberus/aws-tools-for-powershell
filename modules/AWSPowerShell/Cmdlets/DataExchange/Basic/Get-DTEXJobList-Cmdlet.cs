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
using Amazon.DataExchange;
using Amazon.DataExchange.Model;

namespace Amazon.PowerShell.Cmdlets.DTEX
{
    /// <summary>
    /// This operation lists your jobs sorted by CreatedAt in descending order.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DTEXJobList")]
    [OutputType("Amazon.DataExchange.Model.JobEntry")]
    [AWSCmdlet("Calls the AWS Data Exchange ListJobs API operation.", Operation = new[] {"ListJobs"}, SelectReturnType = typeof(Amazon.DataExchange.Model.ListJobsResponse))]
    [AWSCmdletOutput("Amazon.DataExchange.Model.JobEntry or Amazon.DataExchange.Model.ListJobsResponse",
        "This cmdlet returns a collection of Amazon.DataExchange.Model.JobEntry objects.",
        "The service call response (type Amazon.DataExchange.Model.ListJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDTEXJobListCmdlet : AmazonDataExchangeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for a data set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DataSetId { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for a revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results returned by a single call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token value retrieved from a previous call to access the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Jobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataExchange.Model.ListJobsResponse).
        /// Specifying the name of a property of type Amazon.DataExchange.Model.ListJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Jobs";
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
                context.Select = CreateSelectDelegate<Amazon.DataExchange.Model.ListJobsResponse, GetDTEXJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataSetId = this.DataSetId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RevisionId = this.RevisionId;
            
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
            var request = new Amazon.DataExchange.Model.ListJobsRequest();
            
            if (cmdletContext.DataSetId != null)
            {
                request.DataSetId = cmdletContext.DataSetId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
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
        
        private Amazon.DataExchange.Model.ListJobsResponse CallAWSServiceOperation(IAmazonDataExchange client, Amazon.DataExchange.Model.ListJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Exchange", "ListJobs");
            try
            {
                #if DESKTOP
                return client.ListJobs(request);
                #elif CORECLR
                return client.ListJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String DataSetId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RevisionId { get; set; }
            public System.Func<Amazon.DataExchange.Model.ListJobsResponse, GetDTEXJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Jobs;
        }
        
    }
}
