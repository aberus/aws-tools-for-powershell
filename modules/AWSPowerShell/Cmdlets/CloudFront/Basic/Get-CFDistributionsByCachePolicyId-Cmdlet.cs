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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Gets a list of distribution IDs for distributions that have a cache behavior that's
    /// associated with the specified cache policy.
    /// 
    ///  
    /// <para>
    /// You can optionally specify the maximum number of items to receive in the response.
    /// If the total number of items in the list exceeds the maximum that you specify, or
    /// the default maximum, the response is paginated. To get the next page of items, send
    /// a subsequent request that specifies the <c>NextMarker</c> value from the current response
    /// as the <c>Marker</c> value in the subsequent request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFDistributionsByCachePolicyId")]
    [OutputType("Amazon.CloudFront.Model.DistributionIdList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListDistributionsByCachePolicyId API operation.", Operation = new[] {"ListDistributionsByCachePolicyId"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.DistributionIdList or Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.DistributionIdList object.",
        "The service call response (type Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFDistributionsByCachePolicyIdCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CachePolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the cache policy whose associated distribution IDs you want to list.</para>
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
        public System.String CachePolicyId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in your list of
        /// distribution IDs. The response includes distribution IDs in the list that occur after
        /// the marker. To get the next page of the list, set this field's value to the value
        /// of <c>NextMarker</c> from the current page's response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of distribution IDs that you want in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionIdList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionIdList";
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
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse, GetCFDistributionsByCachePolicyIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CachePolicyId = this.CachePolicyId;
            #if MODULAR
            if (this.CachePolicyId == null && ParameterWasBound(nameof(this.CachePolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter CachePolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            
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
            var request = new Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdRequest();
            
            if (cmdletContext.CachePolicyId != null)
            {
                request.CachePolicyId = cmdletContext.CachePolicyId;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
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
        
        private Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListDistributionsByCachePolicyId");
            try
            {
                #if DESKTOP
                return client.ListDistributionsByCachePolicyId(request);
                #elif CORECLR
                return client.ListDistributionsByCachePolicyIdAsync(request).GetAwaiter().GetResult();
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
            public System.String CachePolicyId { get; set; }
            public System.String Marker { get; set; }
            public System.String MaxItem { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListDistributionsByCachePolicyIdResponse, GetCFDistributionsByCachePolicyIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionIdList;
        }
        
    }
}
