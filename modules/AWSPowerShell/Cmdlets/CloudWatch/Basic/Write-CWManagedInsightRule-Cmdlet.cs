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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates a managed Contributor Insights rule for a specified Amazon Web Services resource.
    /// When you enable a managed rule, you create a Contributor Insights rule that collects
    /// data from Amazon Web Services services. You cannot edit these rules with <c>PutInsightRule</c>.
    /// The rules can be enabled, disabled, and deleted using <c>EnableInsightRules</c>, <c>DisableInsightRules</c>,
    /// and <c>DeleteInsightRules</c>. If a previously created managed rule is currently disabled,
    /// a subsequent call to this API will re-enable it. Use <c>ListManagedInsightRules</c>
    /// to describe all available rules.
    /// </summary>
    [Cmdlet("Write", "CWManagedInsightRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatch.Model.PartialFailure")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutManagedInsightRules API operation.", Operation = new[] {"PutManagedInsightRules"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutManagedInsightRulesResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.PartialFailure or Amazon.CloudWatch.Model.PutManagedInsightRulesResponse",
        "This cmdlet returns a collection of Amazon.CloudWatch.Model.PartialFailure objects.",
        "The service call response (type Amazon.CloudWatch.Model.PutManagedInsightRulesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCWManagedInsightRuleCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ManagedRule
        /// <summary>
        /// <para>
        /// <para> A list of <c>ManagedRules</c> to enable. </para>
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
        [Alias("ManagedRules")]
        public Amazon.CloudWatch.Model.ManagedRule[] ManagedRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Failures'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutManagedInsightRulesResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.PutManagedInsightRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Failures";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ManagedRule), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWManagedInsightRule (PutManagedInsightRules)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutManagedInsightRulesResponse, WriteCWManagedInsightRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ManagedRule != null)
            {
                context.ManagedRule = new List<Amazon.CloudWatch.Model.ManagedRule>(this.ManagedRule);
            }
            #if MODULAR
            if (this.ManagedRule == null && ParameterWasBound(nameof(this.ManagedRule)))
            {
                WriteWarning("You are passing $null as a value for parameter ManagedRule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.PutManagedInsightRulesRequest();
            
            if (cmdletContext.ManagedRule != null)
            {
                request.ManagedRules = cmdletContext.ManagedRule;
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
        
        private Amazon.CloudWatch.Model.PutManagedInsightRulesResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutManagedInsightRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutManagedInsightRules");
            try
            {
                return client.PutManagedInsightRulesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatch.Model.ManagedRule> ManagedRule { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutManagedInsightRulesResponse, WriteCWManagedInsightRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Failures;
        }
        
    }
}
