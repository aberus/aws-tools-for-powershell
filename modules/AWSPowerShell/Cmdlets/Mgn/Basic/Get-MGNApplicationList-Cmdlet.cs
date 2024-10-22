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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Retrieves all applications or multiple applications by ID.
    /// </summary>
    [Cmdlet("Get", "MGNApplicationList")]
    [OutputType("Amazon.Mgn.Model.Application")]
    [AWSCmdlet("Calls the Application Migration Service ListApplications API operation.", Operation = new[] {"ListApplications"}, SelectReturnType = typeof(Amazon.Mgn.Model.ListApplicationsResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.Application or Amazon.Mgn.Model.ListApplicationsResponse",
        "This cmdlet returns a collection of Amazon.Mgn.Model.Application objects.",
        "The service call response (type Amazon.Mgn.Model.ListApplicationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMGNApplicationListCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Applications list Account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter Filters_ApplicationIDs
        /// <summary>
        /// <para>
        /// <para>Filter applications list by application ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_ApplicationIDs { get; set; }
        #endregion
        
        #region Parameter Filters_IsArchived
        /// <summary>
        /// <para>
        /// <para>Filter applications list by archival status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? Filters_IsArchived { get; set; }
        #endregion
        
        #region Parameter Filters_WaveIDs
        /// <summary>
        /// <para>
        /// <para>Filter applications list by wave ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_WaveIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum results to return when listing applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Request next token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.ListApplicationsResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.ListApplicationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.ListApplicationsResponse, GetMGNApplicationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountID = this.AccountID;
            if (this.Filters_ApplicationIDs != null)
            {
                context.Filters_ApplicationIDs = new List<System.String>(this.Filters_ApplicationIDs);
            }
            context.Filters_IsArchived = this.Filters_IsArchived;
            if (this.Filters_WaveIDs != null)
            {
                context.Filters_WaveIDs = new List<System.String>(this.Filters_WaveIDs);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Mgn.Model.ListApplicationsRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Mgn.Model.ListApplicationsRequestFilters();
            List<System.String> requestFilters_filters_ApplicationIDs = null;
            if (cmdletContext.Filters_ApplicationIDs != null)
            {
                requestFilters_filters_ApplicationIDs = cmdletContext.Filters_ApplicationIDs;
            }
            if (requestFilters_filters_ApplicationIDs != null)
            {
                request.Filters.ApplicationIDs = requestFilters_filters_ApplicationIDs;
                requestFiltersIsNull = false;
            }
            System.Boolean? requestFilters_filters_IsArchived = null;
            if (cmdletContext.Filters_IsArchived != null)
            {
                requestFilters_filters_IsArchived = cmdletContext.Filters_IsArchived.Value;
            }
            if (requestFilters_filters_IsArchived != null)
            {
                request.Filters.IsArchived = requestFilters_filters_IsArchived.Value;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_WaveIDs = null;
            if (cmdletContext.Filters_WaveIDs != null)
            {
                requestFilters_filters_WaveIDs = cmdletContext.Filters_WaveIDs;
            }
            if (requestFilters_filters_WaveIDs != null)
            {
                request.Filters.WaveIDs = requestFilters_filters_WaveIDs;
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
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Mgn.Model.ListApplicationsResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.ListApplicationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "ListApplications");
            try
            {
                #if DESKTOP
                return client.ListApplications(request);
                #elif CORECLR
                return client.ListApplicationsAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public List<System.String> Filters_ApplicationIDs { get; set; }
            public System.Boolean? Filters_IsArchived { get; set; }
            public List<System.String> Filters_WaveIDs { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Mgn.Model.ListApplicationsResponse, GetMGNApplicationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
