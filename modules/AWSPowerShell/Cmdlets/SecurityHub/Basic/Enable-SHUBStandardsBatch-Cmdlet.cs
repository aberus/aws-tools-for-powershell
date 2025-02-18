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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Enables the standards specified by the provided <c>StandardsArn</c>. To obtain the
    /// ARN for a standard, use the <c>DescribeStandards</c> operation.
    /// 
    ///  
    /// <para>
    /// For more information, see the <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/securityhub-standards.html">Security
    /// Standards</a> section of the <i>Security Hub User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "SHUBStandardsBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.StandardsSubscription")]
    [AWSCmdlet("Calls the AWS Security Hub BatchEnableStandards API operation.", Operation = new[] {"BatchEnableStandards"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.BatchEnableStandardsResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.StandardsSubscription or Amazon.SecurityHub.Model.BatchEnableStandardsResponse",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.StandardsSubscription objects.",
        "The service call response (type Amazon.SecurityHub.Model.BatchEnableStandardsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableSHUBStandardsBatchCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter StandardsSubscriptionRequest
        /// <summary>
        /// <para>
        /// <para>The list of standards checks to enable.</para>
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
        [Alias("StandardsSubscriptionRequests")]
        public Amazon.SecurityHub.Model.StandardsSubscriptionRequest[] StandardsSubscriptionRequest { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StandardsSubscriptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.BatchEnableStandardsResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.BatchEnableStandardsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StandardsSubscriptions";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StandardsSubscriptionRequest), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-SHUBStandardsBatch (BatchEnableStandards)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.BatchEnableStandardsResponse, EnableSHUBStandardsBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.StandardsSubscriptionRequest != null)
            {
                context.StandardsSubscriptionRequest = new List<Amazon.SecurityHub.Model.StandardsSubscriptionRequest>(this.StandardsSubscriptionRequest);
            }
            #if MODULAR
            if (this.StandardsSubscriptionRequest == null && ParameterWasBound(nameof(this.StandardsSubscriptionRequest)))
            {
                WriteWarning("You are passing $null as a value for parameter StandardsSubscriptionRequest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.BatchEnableStandardsRequest();
            
            if (cmdletContext.StandardsSubscriptionRequest != null)
            {
                request.StandardsSubscriptionRequests = cmdletContext.StandardsSubscriptionRequest;
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
        
        private Amazon.SecurityHub.Model.BatchEnableStandardsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchEnableStandardsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchEnableStandards");
            try
            {
                return client.BatchEnableStandardsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.StandardsSubscriptionRequest> StandardsSubscriptionRequest { get; set; }
            public System.Func<Amazon.SecurityHub.Model.BatchEnableStandardsResponse, EnableSHUBStandardsBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StandardsSubscriptions;
        }
        
    }
}
