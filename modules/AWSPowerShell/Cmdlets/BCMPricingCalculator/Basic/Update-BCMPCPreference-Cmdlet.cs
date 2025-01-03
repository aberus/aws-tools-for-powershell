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
using Amazon.BCMPricingCalculator;
using Amazon.BCMPricingCalculator.Model;

namespace Amazon.PowerShell.Cmdlets.BCMPC
{
    /// <summary>
    /// Updates the preferences for the Amazon Web Services Cost Explorer service.
    /// </summary>
    [Cmdlet("Update", "BCMPCPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse")]
    [AWSCmdlet("Calls the AWS Pricing Calculator UpdatePreferences API operation.", Operation = new[] {"UpdatePreferences"}, SelectReturnType = typeof(Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse))]
    [AWSCmdletOutput("Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse",
        "This cmdlet returns an Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse object containing multiple properties."
    )]
    public partial class UpdateBCMPCPreferenceCmdlet : AmazonBCMPricingCalculatorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ManagementAccountRateTypeSelection
        /// <summary>
        /// <para>
        /// <para> The updated preferred rate types for the management account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagementAccountRateTypeSelections")]
        public System.String[] ManagementAccountRateTypeSelection { get; set; }
        #endregion
        
        #region Parameter MemberAccountRateTypeSelection
        /// <summary>
        /// <para>
        /// <para> The updated preferred rate types for member accounts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemberAccountRateTypeSelections")]
        public System.String[] MemberAccountRateTypeSelection { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse).
        /// Specifying the name of a property of type Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BCMPCPreference (UpdatePreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse, UpdateBCMPCPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ManagementAccountRateTypeSelection != null)
            {
                context.ManagementAccountRateTypeSelection = new List<System.String>(this.ManagementAccountRateTypeSelection);
            }
            if (this.MemberAccountRateTypeSelection != null)
            {
                context.MemberAccountRateTypeSelection = new List<System.String>(this.MemberAccountRateTypeSelection);
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
            var request = new Amazon.BCMPricingCalculator.Model.UpdatePreferencesRequest();
            
            if (cmdletContext.ManagementAccountRateTypeSelection != null)
            {
                request.ManagementAccountRateTypeSelections = cmdletContext.ManagementAccountRateTypeSelection;
            }
            if (cmdletContext.MemberAccountRateTypeSelection != null)
            {
                request.MemberAccountRateTypeSelections = cmdletContext.MemberAccountRateTypeSelection;
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
        
        private Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse CallAWSServiceOperation(IAmazonBCMPricingCalculator client, Amazon.BCMPricingCalculator.Model.UpdatePreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Pricing Calculator", "UpdatePreferences");
            try
            {
                #if DESKTOP
                return client.UpdatePreferences(request);
                #elif CORECLR
                return client.UpdatePreferencesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ManagementAccountRateTypeSelection { get; set; }
            public List<System.String> MemberAccountRateTypeSelection { get; set; }
            public System.Func<Amazon.BCMPricingCalculator.Model.UpdatePreferencesResponse, UpdateBCMPCPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
