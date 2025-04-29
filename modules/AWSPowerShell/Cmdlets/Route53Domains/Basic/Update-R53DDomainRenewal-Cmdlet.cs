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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// This operation renews a domain for the specified number of years. The cost of renewing
    /// your domain is billed to your Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// We recommend that you renew your domain several weeks before the expiration date.
    /// Some TLD registries delete domains before the expiration date if you haven't renewed
    /// far enough in advance. For more information about renewing domain registration, see
    /// <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/domain-renew.html">Renewing
    /// Registration for a Domain</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DDomainRenewal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains RenewDomain API operation.", Operation = new[] {"RenewDomain"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.RenewDomainResponse))]
    [AWSCmdletOutput("System.String or Amazon.Route53Domains.Model.RenewDomainResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Route53Domains.Model.RenewDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateR53DDomainRenewalCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CurrentExpiryYear
        /// <summary>
        /// <para>
        /// <para>The year when the registration for the domain is set to expire. This value must match
        /// the current expiration date for the domain.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? CurrentExpiryYear { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to renew.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DurationInYear
        /// <summary>
        /// <para>
        /// <para>The number of years that you want to renew the domain for. The maximum number of years
        /// depends on the top-level domain. For the range of valid values for your domain, see
        /// <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i>.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationInYears")]
        public System.Int32? DurationInYear { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.RenewDomainResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.RenewDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DDomainRenewal (RenewDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.RenewDomainResponse, UpdateR53DDomainRenewalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CurrentExpiryYear = this.CurrentExpiryYear;
            #if MODULAR
            if (this.CurrentExpiryYear == null && ParameterWasBound(nameof(this.CurrentExpiryYear)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentExpiryYear which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DurationInYear = this.DurationInYear;
            
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
            var request = new Amazon.Route53Domains.Model.RenewDomainRequest();
            
            if (cmdletContext.CurrentExpiryYear != null)
            {
                request.CurrentExpiryYear = cmdletContext.CurrentExpiryYear.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DurationInYear != null)
            {
                request.DurationInYears = cmdletContext.DurationInYear.Value;
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
        
        private Amazon.Route53Domains.Model.RenewDomainResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.RenewDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "RenewDomain");
            try
            {
                return client.RenewDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? CurrentExpiryYear { get; set; }
            public System.String DomainName { get; set; }
            public System.Int32? DurationInYear { get; set; }
            public System.Func<Amazon.Route53Domains.Model.RenewDomainResponse, UpdateR53DDomainRenewalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
