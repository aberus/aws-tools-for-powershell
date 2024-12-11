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
    /// Provides information about the associations for your configuration policies and self-managed
    /// behavior. Only the Security Hub delegated administrator can invoke this operation
    /// from the home Region.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHUBConfigurationPolicyAssociationList")]
    [OutputType("Amazon.SecurityHub.Model.ConfigurationPolicyAssociationSummary")]
    [AWSCmdlet("Calls the AWS Security Hub ListConfigurationPolicyAssociations API operation.", Operation = new[] {"ListConfigurationPolicyAssociations"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.ConfigurationPolicyAssociationSummary or Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.ConfigurationPolicyAssociationSummary objects.",
        "The service call response (type Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBConfigurationPolicyAssociationListCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_AssociationStatus
        /// <summary>
        /// <para>
        /// <para> The current status of the association between a target and a configuration policy.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.ConfigurationPolicyAssociationStatus")]
        public Amazon.SecurityHub.ConfigurationPolicyAssociationStatus Filters_AssociationStatus { get; set; }
        #endregion
        
        #region Parameter Filters_AssociationType
        /// <summary>
        /// <para>
        /// <para> Indicates whether the association between a target and a configuration was directly
        /// applied by the Security Hub delegated administrator or inherited from a parent. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.AssociationType")]
        public Amazon.SecurityHub.AssociationType Filters_AssociationType { get; set; }
        #endregion
        
        #region Parameter Filters_ConfigurationPolicyId
        /// <summary>
        /// <para>
        /// <para> The ARN or UUID of the configuration policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_ConfigurationPolicyId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results that's returned by <c>ListConfigurationPolicies</c>
        /// in each page of the response. When this parameter is used, <c>ListConfigurationPolicyAssociations</c>
        /// returns the specified number of results in a single page and a <c>NextToken</c> response
        /// element. You can see the remaining results of the initial request by sending another
        /// <c>ListConfigurationPolicyAssociations</c> request with the returned <c>NextToken</c>
        /// value. A valid range for <c>MaxResults</c> is between 1 and 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The <c>NextToken</c> value that's returned from a previous paginated <c>ListConfigurationPolicyAssociations</c>
        /// request where <c>MaxResults</c> was used but the results exceeded the value of that
        /// parameter. Pagination continues from the end of the previous response that returned
        /// the <c>NextToken</c> value. This value is <c>null</c> when there are no more results
        /// to return. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigurationPolicyAssociationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigurationPolicyAssociationSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse, GetSHUBConfigurationPolicyAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_AssociationStatus = this.Filters_AssociationStatus;
            context.Filters_AssociationType = this.Filters_AssociationType;
            context.Filters_ConfigurationPolicyId = this.Filters_ConfigurationPolicyId;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.SecurityHub.Model.AssociationFilters();
            Amazon.SecurityHub.ConfigurationPolicyAssociationStatus requestFilters_filters_AssociationStatus = null;
            if (cmdletContext.Filters_AssociationStatus != null)
            {
                requestFilters_filters_AssociationStatus = cmdletContext.Filters_AssociationStatus;
            }
            if (requestFilters_filters_AssociationStatus != null)
            {
                request.Filters.AssociationStatus = requestFilters_filters_AssociationStatus;
                requestFiltersIsNull = false;
            }
            Amazon.SecurityHub.AssociationType requestFilters_filters_AssociationType = null;
            if (cmdletContext.Filters_AssociationType != null)
            {
                requestFilters_filters_AssociationType = cmdletContext.Filters_AssociationType;
            }
            if (requestFilters_filters_AssociationType != null)
            {
                request.Filters.AssociationType = requestFilters_filters_AssociationType;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_ConfigurationPolicyId = null;
            if (cmdletContext.Filters_ConfigurationPolicyId != null)
            {
                requestFilters_filters_ConfigurationPolicyId = cmdletContext.Filters_ConfigurationPolicyId;
            }
            if (requestFilters_filters_ConfigurationPolicyId != null)
            {
                request.Filters.ConfigurationPolicyId = requestFilters_filters_ConfigurationPolicyId;
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
        
        private Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "ListConfigurationPolicyAssociations");
            try
            {
                #if DESKTOP
                return client.ListConfigurationPolicyAssociations(request);
                #elif CORECLR
                return client.ListConfigurationPolicyAssociationsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SecurityHub.ConfigurationPolicyAssociationStatus Filters_AssociationStatus { get; set; }
            public Amazon.SecurityHub.AssociationType Filters_AssociationType { get; set; }
            public System.String Filters_ConfigurationPolicyId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.SecurityHub.Model.ListConfigurationPolicyAssociationsResponse, GetSHUBConfigurationPolicyAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationPolicyAssociationSummaries;
        }
        
    }
}
