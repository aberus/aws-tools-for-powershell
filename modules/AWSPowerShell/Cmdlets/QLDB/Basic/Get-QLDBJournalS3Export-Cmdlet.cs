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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Returns information about a journal export job, including the ledger name, export
    /// ID, creation time, current status, and the parameters of the original export creation
    /// request.
    /// 
    ///  
    /// <para>
    /// This action does not return any expired export jobs. For more information, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/export-journal.request.html#export-journal.request.expiration">Export
    /// job expiration</a> in the <i>Amazon QLDB Developer Guide</i>.
    /// </para><para>
    /// If the export job with the given <c>ExportId</c> doesn't exist, then throws <c>ResourceNotFoundException</c>.
    /// </para><para>
    /// If the ledger with the given <c>Name</c> doesn't exist, then throws <c>ResourceNotFoundException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "QLDBJournalS3Export")]
    [OutputType("Amazon.QLDB.Model.JournalS3ExportDescription")]
    [AWSCmdlet("Calls the Amazon QLDB DescribeJournalS3Export API operation.", Operation = new[] {"DescribeJournalS3Export"}, SelectReturnType = typeof(Amazon.QLDB.Model.DescribeJournalS3ExportResponse))]
    [AWSCmdletOutput("Amazon.QLDB.Model.JournalS3ExportDescription or Amazon.QLDB.Model.DescribeJournalS3ExportResponse",
        "This cmdlet returns an Amazon.QLDB.Model.JournalS3ExportDescription object.",
        "The service call response (type Amazon.QLDB.Model.DescribeJournalS3ExportResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetQLDBJournalS3ExportCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExportId
        /// <summary>
        /// <para>
        /// <para>The UUID (represented in Base62-encoded text) of the journal export job to describe.</para>
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
        public System.String ExportId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the ledger.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.DescribeJournalS3ExportResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.DescribeJournalS3ExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportDescription";
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
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.DescribeJournalS3ExportResponse, GetQLDBJournalS3ExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExportId = this.ExportId;
            #if MODULAR
            if (this.ExportId == null && ParameterWasBound(nameof(this.ExportId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QLDB.Model.DescribeJournalS3ExportRequest();
            
            if (cmdletContext.ExportId != null)
            {
                request.ExportId = cmdletContext.ExportId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.QLDB.Model.DescribeJournalS3ExportResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.DescribeJournalS3ExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "DescribeJournalS3Export");
            try
            {
                #if DESKTOP
                return client.DescribeJournalS3Export(request);
                #elif CORECLR
                return client.DescribeJournalS3ExportAsync(request).GetAwaiter().GetResult();
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
            public System.String ExportId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.QLDB.Model.DescribeJournalS3ExportResponse, GetQLDBJournalS3ExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportDescription;
        }
        
    }
}
