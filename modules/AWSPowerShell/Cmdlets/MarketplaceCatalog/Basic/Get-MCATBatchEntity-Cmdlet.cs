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
using Amazon.MarketplaceCatalog;
using Amazon.MarketplaceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.MCAT
{
    /// <summary>
    /// Returns metadata and content for multiple entities. This is the Batch version of the
    /// <c>DescribeEntity</c> API and uses the same IAM permission action as <c>DescribeEntity</c>
    /// API.
    /// </summary>
    [Cmdlet("Get", "MCATBatchEntity")]
    [OutputType("Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Catalog Service BatchDescribeEntities API operation.", Operation = new[] {"BatchDescribeEntities"}, SelectReturnType = typeof(Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse",
        "This cmdlet returns an Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse object containing multiple properties."
    )]
    public partial class GetMCATBatchEntityCmdlet : AmazonMarketplaceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EntityRequestList
        /// <summary>
        /// <para>
        /// <para>List of entity IDs and the catalogs the entities are present in.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.MarketplaceCatalog.Model.EntityRequest[] EntityRequestList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse, GetMCATBatchEntityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EntityRequestList != null)
            {
                context.EntityRequestList = new List<Amazon.MarketplaceCatalog.Model.EntityRequest>(this.EntityRequestList);
            }
            #if MODULAR
            if (this.EntityRequestList == null && ParameterWasBound(nameof(this.EntityRequestList)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityRequestList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesRequest();
            
            if (cmdletContext.EntityRequestList != null)
            {
                request.EntityRequestList = cmdletContext.EntityRequestList;
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
        
        private Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse CallAWSServiceOperation(IAmazonMarketplaceCatalog client, Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Catalog Service", "BatchDescribeEntities");
            try
            {
                #if DESKTOP
                return client.BatchDescribeEntities(request);
                #elif CORECLR
                return client.BatchDescribeEntitiesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.MarketplaceCatalog.Model.EntityRequest> EntityRequestList { get; set; }
            public System.Func<Amazon.MarketplaceCatalog.Model.BatchDescribeEntitiesResponse, GetMCATBatchEntityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
