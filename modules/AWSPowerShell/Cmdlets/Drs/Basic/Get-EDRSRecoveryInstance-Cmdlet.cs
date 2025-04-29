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
using Amazon.Drs;
using Amazon.Drs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Lists all Recovery Instances or multiple Recovery Instances by ID.
    /// </summary>
    [Cmdlet("Get", "EDRSRecoveryInstance")]
    [OutputType("Amazon.Drs.Model.RecoveryInstance")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service DescribeRecoveryInstances API operation.", Operation = new[] {"DescribeRecoveryInstances"}, SelectReturnType = typeof(Amazon.Drs.Model.DescribeRecoveryInstancesResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.RecoveryInstance or Amazon.Drs.Model.DescribeRecoveryInstancesResponse",
        "This cmdlet returns a collection of Amazon.Drs.Model.RecoveryInstance objects.",
        "The service call response (type Amazon.Drs.Model.DescribeRecoveryInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEDRSRecoveryInstanceCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_RecoveryInstanceIDs
        /// <summary>
        /// <para>
        /// <para>An array of Recovery Instance IDs that should be returned. An empty array means all
        /// Recovery Instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_RecoveryInstanceIDs { get; set; }
        #endregion
        
        #region Parameter Filters_SourceServerIDs
        /// <summary>
        /// <para>
        /// <para>An array of Source Server IDs for which associated Recovery Instances should be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_SourceServerIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of Recovery Instances to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token of the next Recovery Instance to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.DescribeRecoveryInstancesResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.DescribeRecoveryInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.DescribeRecoveryInstancesResponse, GetEDRSRecoveryInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_RecoveryInstanceIDs != null)
            {
                context.Filters_RecoveryInstanceIDs = new List<System.String>(this.Filters_RecoveryInstanceIDs);
            }
            if (this.Filters_SourceServerIDs != null)
            {
                context.Filters_SourceServerIDs = new List<System.String>(this.Filters_SourceServerIDs);
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
            var request = new Amazon.Drs.Model.DescribeRecoveryInstancesRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Drs.Model.DescribeRecoveryInstancesRequestFilters();
            List<System.String> requestFilters_filters_RecoveryInstanceIDs = null;
            if (cmdletContext.Filters_RecoveryInstanceIDs != null)
            {
                requestFilters_filters_RecoveryInstanceIDs = cmdletContext.Filters_RecoveryInstanceIDs;
            }
            if (requestFilters_filters_RecoveryInstanceIDs != null)
            {
                request.Filters.RecoveryInstanceIDs = requestFilters_filters_RecoveryInstanceIDs;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_SourceServerIDs = null;
            if (cmdletContext.Filters_SourceServerIDs != null)
            {
                requestFilters_filters_SourceServerIDs = cmdletContext.Filters_SourceServerIDs;
            }
            if (requestFilters_filters_SourceServerIDs != null)
            {
                request.Filters.SourceServerIDs = requestFilters_filters_SourceServerIDs;
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
        
        private Amazon.Drs.Model.DescribeRecoveryInstancesResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.DescribeRecoveryInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "DescribeRecoveryInstances");
            try
            {
                return client.DescribeRecoveryInstancesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Filters_RecoveryInstanceIDs { get; set; }
            public List<System.String> Filters_SourceServerIDs { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Drs.Model.DescribeRecoveryInstancesResponse, GetEDRSRecoveryInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
