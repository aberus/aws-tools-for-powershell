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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the number of Config rules that are compliant and noncompliant, up to a maximum
    /// of 25 for each.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceSummaryByConfigRule")]
    [OutputType("Amazon.ConfigService.Model.ComplianceSummary")]
    [AWSCmdlet("Calls the AWS Config GetComplianceSummaryByConfigRule API operation.", Operation = new[] {"GetComplianceSummaryByConfigRule"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ComplianceSummary or Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.ComplianceSummary object.",
        "The service call response (type Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGComplianceSummaryByConfigRuleCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComplianceSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComplianceSummary";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse, GetCFGComplianceSummaryByConfigRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            // create request
            var request = new Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleRequest();
            
            
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
        
        private Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetComplianceSummaryByConfigRule");
            try
            {
                #if DESKTOP
                return client.GetComplianceSummaryByConfigRule(request);
                #elif CORECLR
                return client.GetComplianceSummaryByConfigRuleAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ConfigService.Model.GetComplianceSummaryByConfigRuleResponse, GetCFGComplianceSummaryByConfigRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComplianceSummary;
        }
        
    }
}
