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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// The list of the test sets
    /// </summary>
    [Cmdlet("Get", "LMBV2TestSetList")]
    [OutputType("Amazon.LexModelsV2.Model.TestSetSummary")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListTestSets API operation.", Operation = new[] {"ListTestSets"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListTestSetsResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.TestSetSummary or Amazon.LexModelsV2.Model.ListTestSetsResponse",
        "This cmdlet returns a collection of Amazon.LexModelsV2.Model.TestSetSummary objects.",
        "The service call response (type Amazon.LexModelsV2.Model.ListTestSetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLMBV2TestSetListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SortBy_Attribute
        /// <summary>
        /// <para>
        /// <para>Specifies whether to sort the test sets by name or by the time they were last updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.TestSetSortAttribute")]
        public Amazon.LexModelsV2.TestSetSortAttribute SortBy_Attribute { get; set; }
        #endregion
        
        #region Parameter SortBy_Order
        /// <summary>
        /// <para>
        /// <para>Specifies whether to sort in ascending or descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.SortOrder")]
        public Amazon.LexModelsV2.SortOrder SortBy_Order { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of test sets to return in each page. If there are fewer results
        /// than the max page size, only the actual number of results are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response from the ListTestSets operation contains more results than specified
        /// in the maxResults parameter, a token is returned in the response. Use that token in
        /// the nextToken parameter to return the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TestSets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListTestSetsResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListTestSetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TestSets";
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
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListTestSetsResponse, GetLMBV2TestSetListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy_Attribute = this.SortBy_Attribute;
            context.SortBy_Order = this.SortBy_Order;
            
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
            var request = new Amazon.LexModelsV2.Model.ListTestSetsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.LexModelsV2.Model.TestSetSortBy();
            Amazon.LexModelsV2.TestSetSortAttribute requestSortBy_sortBy_Attribute = null;
            if (cmdletContext.SortBy_Attribute != null)
            {
                requestSortBy_sortBy_Attribute = cmdletContext.SortBy_Attribute;
            }
            if (requestSortBy_sortBy_Attribute != null)
            {
                request.SortBy.Attribute = requestSortBy_sortBy_Attribute;
                requestSortByIsNull = false;
            }
            Amazon.LexModelsV2.SortOrder requestSortBy_sortBy_Order = null;
            if (cmdletContext.SortBy_Order != null)
            {
                requestSortBy_sortBy_Order = cmdletContext.SortBy_Order;
            }
            if (requestSortBy_sortBy_Order != null)
            {
                request.SortBy.Order = requestSortBy_sortBy_Order;
                requestSortByIsNull = false;
            }
             // determine if request.SortBy should be set to null
            if (requestSortByIsNull)
            {
                request.SortBy = null;
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
        
        private Amazon.LexModelsV2.Model.ListTestSetsResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListTestSetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListTestSets");
            try
            {
                #if DESKTOP
                return client.ListTestSets(request);
                #elif CORECLR
                return client.ListTestSetsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LexModelsV2.TestSetSortAttribute SortBy_Attribute { get; set; }
            public Amazon.LexModelsV2.SortOrder SortBy_Order { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListTestSetsResponse, GetLMBV2TestSetListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TestSets;
        }
        
    }
}
