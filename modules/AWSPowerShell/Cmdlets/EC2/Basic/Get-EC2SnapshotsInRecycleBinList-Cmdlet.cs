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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Lists one or more snapshots that are currently in the Recycle Bin.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2SnapshotsInRecycleBinList")]
    [OutputType("Amazon.EC2.Model.SnapshotRecycleBinInfo")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ListSnapshotsInRecycleBin API operation.", Operation = new[] {"ListSnapshotsInRecycleBin"}, SelectReturnType = typeof(Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.SnapshotRecycleBinInfo or Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.SnapshotRecycleBinInfo objects.",
        "The service call response (type Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2SnapshotsInRecycleBinListCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The IDs of the snapshots to list. Omit this parameter to list all of the snapshots
        /// that are in the Recycle Bin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotIds")]
        public System.String[] SnapshotId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned from a previous paginated request. Pagination continues from the
        /// end of the items returned by the previous request.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshots";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse, GetEC2SnapshotsInRecycleBinListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SnapshotId != null)
            {
                context.SnapshotId = new List<System.String>(this.SnapshotId);
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
            var request = new Amazon.EC2.Model.ListSnapshotsInRecycleBinRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotIds = cmdletContext.SnapshotId;
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
        
        private Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ListSnapshotsInRecycleBinRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ListSnapshotsInRecycleBin");
            try
            {
                #if DESKTOP
                return client.ListSnapshotsInRecycleBin(request);
                #elif CORECLR
                return client.ListSnapshotsInRecycleBinAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SnapshotId { get; set; }
            public System.Func<Amazon.EC2.Model.ListSnapshotsInRecycleBinResponse, GetEC2SnapshotsInRecycleBinListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshots;
        }
        
    }
}
