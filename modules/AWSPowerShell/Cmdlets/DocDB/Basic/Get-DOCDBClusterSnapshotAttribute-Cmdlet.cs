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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Returns a list of cluster snapshot attribute names and values for a manual DB cluster
    /// snapshot.
    /// 
    ///  
    /// <para>
    /// When you share snapshots with other Amazon Web Services accounts, <c>DescribeDBClusterSnapshotAttributes</c>
    /// returns the <c>restore</c> attribute and a list of IDs for the Amazon Web Services
    /// accounts that are authorized to copy or restore the manual cluster snapshot. If <c>all</c>
    /// is included in the list of values for the <c>restore</c> attribute, then the manual
    /// cluster snapshot is public and can be copied or restored by all Amazon Web Services
    /// accounts.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DOCDBClusterSnapshotAttribute")]
    [OutputType("Amazon.DocDB.Model.DBClusterSnapshotAttributesResult")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) DescribeDBClusterSnapshotAttributes API operation.", Operation = new[] {"DescribeDBClusterSnapshotAttributes"}, SelectReturnType = typeof(Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBClusterSnapshotAttributesResult or Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBClusterSnapshotAttributesResult object.",
        "The service call response (type Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDOCDBClusterSnapshotAttributeCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the cluster snapshot to describe the attributes for.</para>
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
        public System.String DBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterSnapshotAttributesResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterSnapshotAttributesResult";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse, GetDOCDBClusterSnapshotAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            #if MODULAR
            if (this.DBClusterSnapshotIdentifier == null && ParameterWasBound(nameof(this.DBClusterSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesRequest();
            
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
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
        
        private Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "DescribeDBClusterSnapshotAttributes");
            try
            {
                return client.DescribeDBClusterSnapshotAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBClusterSnapshotIdentifier { get; set; }
            public System.Func<Amazon.DocDB.Model.DescribeDBClusterSnapshotAttributesResponse, GetDOCDBClusterSnapshotAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterSnapshotAttributesResult;
        }
        
    }
}
