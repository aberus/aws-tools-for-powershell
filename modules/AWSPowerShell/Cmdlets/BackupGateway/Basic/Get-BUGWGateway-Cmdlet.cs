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
using Amazon.BackupGateway;
using Amazon.BackupGateway.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BUGW
{
    /// <summary>
    /// By providing the ARN (Amazon Resource Name), this API returns the gateway.
    /// </summary>
    [Cmdlet("Get", "BUGWGateway")]
    [OutputType("Amazon.BackupGateway.Model.GatewayDetails")]
    [AWSCmdlet("Calls the AWS Backup Gateway GetGateway API operation.", Operation = new[] {"GetGateway"}, SelectReturnType = typeof(Amazon.BackupGateway.Model.GetGatewayResponse))]
    [AWSCmdletOutput("Amazon.BackupGateway.Model.GatewayDetails or Amazon.BackupGateway.Model.GetGatewayResponse",
        "This cmdlet returns an Amazon.BackupGateway.Model.GatewayDetails object.",
        "The service call response (type Amazon.BackupGateway.Model.GetGatewayResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBUGWGatewayCmdlet : AmazonBackupGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GatewayArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway.</para>
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
        public System.String GatewayArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Gateway'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupGateway.Model.GetGatewayResponse).
        /// Specifying the name of a property of type Amazon.BackupGateway.Model.GetGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Gateway";
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
                context.Select = CreateSelectDelegate<Amazon.BackupGateway.Model.GetGatewayResponse, GetBUGWGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayArn = this.GatewayArn;
            #if MODULAR
            if (this.GatewayArn == null && ParameterWasBound(nameof(this.GatewayArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BackupGateway.Model.GetGatewayRequest();
            
            if (cmdletContext.GatewayArn != null)
            {
                request.GatewayArn = cmdletContext.GatewayArn;
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
        
        private Amazon.BackupGateway.Model.GetGatewayResponse CallAWSServiceOperation(IAmazonBackupGateway client, Amazon.BackupGateway.Model.GetGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Gateway", "GetGateway");
            try
            {
                return client.GetGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GatewayArn { get; set; }
            public System.Func<Amazon.BackupGateway.Model.GetGatewayResponse, GetBUGWGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Gateway;
        }
        
    }
}
