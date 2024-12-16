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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Deletes one or more import tasks, each identified by their import ID. Each import
    /// task has a number of records that can identify servers or applications. 
    /// 
    ///  
    /// <para>
    /// Amazon Web Services Application Discovery Service has built-in matching logic that
    /// will identify when discovered servers match existing entries that you've previously
    /// discovered, the information for the already-existing discovered server is updated.
    /// When you delete an import task that contains records that were used to match, the
    /// information in those matched records that comes from the deleted records will also
    /// be deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ADSImportDataBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataError")]
    [AWSCmdlet("Calls the AWS Application Discovery Service BatchDeleteImportData API operation.", Operation = new[] {"BatchDeleteImportData"}, SelectReturnType = typeof(Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse))]
    [AWSCmdletOutput("Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataError or Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse",
        "This cmdlet returns a collection of Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataError objects.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveADSImportDataBatchCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeleteHistory
        /// <summary>
        /// <para>
        /// <para> Set to <c>true</c> to remove the deleted import task from <a>DescribeImportTasks</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteHistory { get; set; }
        #endregion
        
        #region Parameter ImportTaskId
        /// <summary>
        /// <para>
        /// <para>The IDs for the import tasks that you want to delete.</para>
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
        [Alias("ImportTaskIds")]
        public System.String[] ImportTaskId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse).
        /// Specifying the name of a property of type Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImportTaskId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ADSImportDataBatch (BatchDeleteImportData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse, RemoveADSImportDataBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeleteHistory = this.DeleteHistory;
            if (this.ImportTaskId != null)
            {
                context.ImportTaskId = new List<System.String>(this.ImportTaskId);
            }
            #if MODULAR
            if (this.ImportTaskId == null && ParameterWasBound(nameof(this.ImportTaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportTaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataRequest();
            
            if (cmdletContext.DeleteHistory != null)
            {
                request.DeleteHistory = cmdletContext.DeleteHistory.Value;
            }
            if (cmdletContext.ImportTaskId != null)
            {
                request.ImportTaskIds = cmdletContext.ImportTaskId;
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
        
        private Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Application Discovery Service", "BatchDeleteImportData");
            try
            {
                #if DESKTOP
                return client.BatchDeleteImportData(request);
                #elif CORECLR
                return client.BatchDeleteImportDataAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeleteHistory { get; set; }
            public List<System.String> ImportTaskId { get; set; }
            public System.Func<Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse, RemoveADSImportDataBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
