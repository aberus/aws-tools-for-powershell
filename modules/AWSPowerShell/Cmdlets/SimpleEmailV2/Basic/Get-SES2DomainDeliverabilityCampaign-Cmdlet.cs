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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Retrieve all the deliverability data for a specific campaign. This data is available
    /// for a campaign only if the campaign sent email by using a domain that the Deliverability
    /// dashboard is enabled for.
    /// </summary>
    [Cmdlet("Get", "SES2DomainDeliverabilityCampaign")]
    [OutputType("Amazon.SimpleEmailV2.Model.DomainDeliverabilityCampaign")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) GetDomainDeliverabilityCampaign API operation.", Operation = new[] {"GetDomainDeliverabilityCampaign"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.DomainDeliverabilityCampaign or Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse",
        "This cmdlet returns an Amazon.SimpleEmailV2.Model.DomainDeliverabilityCampaign object.",
        "The service call response (type Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSES2DomainDeliverabilityCampaignCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CampaignId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the campaign. The Deliverability dashboard automatically
        /// generates and assigns this identifier to a campaign.</para>
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
        public System.String CampaignId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainDeliverabilityCampaign'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainDeliverabilityCampaign";
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
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse, GetSES2DomainDeliverabilityCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignId = this.CampaignId;
            #if MODULAR
            if (this.CampaignId == null && ParameterWasBound(nameof(this.CampaignId)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignRequest();
            
            if (cmdletContext.CampaignId != null)
            {
                request.CampaignId = cmdletContext.CampaignId;
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
        
        private Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "GetDomainDeliverabilityCampaign");
            try
            {
                return client.GetDomainDeliverabilityCampaignAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CampaignId { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.GetDomainDeliverabilityCampaignResponse, GetSES2DomainDeliverabilityCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainDeliverabilityCampaign;
        }
        
    }
}
