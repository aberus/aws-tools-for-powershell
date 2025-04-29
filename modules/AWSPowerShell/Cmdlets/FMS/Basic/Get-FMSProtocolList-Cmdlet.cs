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
using Amazon.FMS;
using Amazon.FMS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Returns information about the specified Firewall Manager protocols list.
    /// </summary>
    [Cmdlet("Get", "FMSProtocolList")]
    [OutputType("Amazon.FMS.Model.GetProtocolsListResponse")]
    [AWSCmdlet("Calls the Firewall Management Service GetProtocolsList API operation.", Operation = new[] {"GetProtocolsList"}, SelectReturnType = typeof(Amazon.FMS.Model.GetProtocolsListResponse))]
    [AWSCmdletOutput("Amazon.FMS.Model.GetProtocolsListResponse",
        "This cmdlet returns an Amazon.FMS.Model.GetProtocolsListResponse object containing multiple properties."
    )]
    public partial class GetFMSProtocolListCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DefaultList
        /// <summary>
        /// <para>
        /// <para>Specifies whether the list to retrieve is a default list owned by Firewall Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DefaultList { get; set; }
        #endregion
        
        #region Parameter ListId
        /// <summary>
        /// <para>
        /// <para>The ID of the Firewall Manager protocols list that you want the details for.</para>
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
        public System.String ListId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.GetProtocolsListResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.GetProtocolsListResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.GetProtocolsListResponse, GetFMSProtocolListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultList = this.DefaultList;
            context.ListId = this.ListId;
            #if MODULAR
            if (this.ListId == null && ParameterWasBound(nameof(this.ListId)))
            {
                WriteWarning("You are passing $null as a value for parameter ListId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FMS.Model.GetProtocolsListRequest();
            
            if (cmdletContext.DefaultList != null)
            {
                request.DefaultList = cmdletContext.DefaultList.Value;
            }
            if (cmdletContext.ListId != null)
            {
                request.ListId = cmdletContext.ListId;
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
        
        private Amazon.FMS.Model.GetProtocolsListResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.GetProtocolsListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "GetProtocolsList");
            try
            {
                return client.GetProtocolsListAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DefaultList { get; set; }
            public System.String ListId { get; set; }
            public System.Func<Amazon.FMS.Model.GetProtocolsListResponse, GetFMSProtocolListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
