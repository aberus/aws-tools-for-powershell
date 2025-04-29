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
using Amazon.AppFabric;
using Amazon.AppFabric.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AFAB
{
    /// <summary>
    /// Returns information about an app authorization.
    /// </summary>
    [Cmdlet("Get", "AFABAppAuthorization")]
    [OutputType("Amazon.AppFabric.Model.AppAuthorization")]
    [AWSCmdlet("Calls the Amazon Web Services AppFabric GetAppAuthorization API operation.", Operation = new[] {"GetAppAuthorization"}, SelectReturnType = typeof(Amazon.AppFabric.Model.GetAppAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.AppFabric.Model.AppAuthorization or Amazon.AppFabric.Model.GetAppAuthorizationResponse",
        "This cmdlet returns an Amazon.AppFabric.Model.AppAuthorization object.",
        "The service call response (type Amazon.AppFabric.Model.GetAppAuthorizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAFABAppAuthorizationCmdlet : AmazonAppFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppAuthorizationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app authorization
        /// to use for the request.</para>
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
        public System.String AppAuthorizationIdentifier { get; set; }
        #endregion
        
        #region Parameter AppBundleIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app bundle
        /// to use for the request.</para>
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
        public System.String AppBundleIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppAuthorization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppFabric.Model.GetAppAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.AppFabric.Model.GetAppAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppAuthorization";
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
                context.Select = CreateSelectDelegate<Amazon.AppFabric.Model.GetAppAuthorizationResponse, GetAFABAppAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppAuthorizationIdentifier = this.AppAuthorizationIdentifier;
            #if MODULAR
            if (this.AppAuthorizationIdentifier == null && ParameterWasBound(nameof(this.AppAuthorizationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppAuthorizationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppBundleIdentifier = this.AppBundleIdentifier;
            #if MODULAR
            if (this.AppBundleIdentifier == null && ParameterWasBound(nameof(this.AppBundleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBundleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppFabric.Model.GetAppAuthorizationRequest();
            
            if (cmdletContext.AppAuthorizationIdentifier != null)
            {
                request.AppAuthorizationIdentifier = cmdletContext.AppAuthorizationIdentifier;
            }
            if (cmdletContext.AppBundleIdentifier != null)
            {
                request.AppBundleIdentifier = cmdletContext.AppBundleIdentifier;
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
        
        private Amazon.AppFabric.Model.GetAppAuthorizationResponse CallAWSServiceOperation(IAmazonAppFabric client, Amazon.AppFabric.Model.GetAppAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Web Services AppFabric", "GetAppAuthorization");
            try
            {
                return client.GetAppAuthorizationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppAuthorizationIdentifier { get; set; }
            public System.String AppBundleIdentifier { get; set; }
            public System.Func<Amazon.AppFabric.Model.GetAppAuthorizationResponse, GetAFABAppAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppAuthorization;
        }
        
    }
}
