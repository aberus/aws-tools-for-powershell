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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Lists the automatic tape creation policies for a gateway. If there are no automatic
    /// tape creation policies for the gateway, it returns an empty list.
    /// 
    ///  
    /// <para>
    /// This operation is only supported for tape gateways.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SGAutomaticTapeCreationPolicy")]
    [OutputType("Amazon.StorageGateway.Model.AutomaticTapeCreationPolicyInfo")]
    [AWSCmdlet("Calls the AWS Storage Gateway ListAutomaticTapeCreationPolicies API operation.", Operation = new[] {"ListAutomaticTapeCreationPolicies"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.AutomaticTapeCreationPolicyInfo or Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse",
        "This cmdlet returns a collection of Amazon.StorageGateway.Model.AutomaticTapeCreationPolicyInfo objects.",
        "The service call response (type Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSGAutomaticTapeCreationPolicyCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutomaticTapeCreationPolicyInfos'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutomaticTapeCreationPolicyInfos";
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
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse, GetSGAutomaticTapeCreationPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayARN = this.GatewayARN;
            
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
            var request = new Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
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
        
        private Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "ListAutomaticTapeCreationPolicies");
            try
            {
                return client.ListAutomaticTapeCreationPoliciesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GatewayARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.ListAutomaticTapeCreationPoliciesResponse, GetSGAutomaticTapeCreationPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutomaticTapeCreationPolicyInfos;
        }
        
    }
}
