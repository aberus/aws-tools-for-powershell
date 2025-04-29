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
using Amazon.Private5G;
using Amazon.Private5G.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PV5G
{
    /// <summary>
    /// Activates the specified network site.
    /// </summary>
    [Cmdlet("Enable", "PV5GNetworkSite", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Private5G.Model.NetworkSite")]
    [AWSCmdlet("Calls the AWS Private 5G ActivateNetworkSite API operation.", Operation = new[] {"ActivateNetworkSite"}, SelectReturnType = typeof(Amazon.Private5G.Model.ActivateNetworkSiteResponse))]
    [AWSCmdletOutput("Amazon.Private5G.Model.NetworkSite or Amazon.Private5G.Model.ActivateNetworkSiteResponse",
        "This cmdlet returns an Amazon.Private5G.Model.NetworkSite object.",
        "The service call response (type Amazon.Private5G.Model.ActivateNetworkSiteResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnablePV5GNetworkSiteCmdlet : AmazonPrivate5GClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CommitmentConfiguration_AutomaticRenewal
        /// <summary>
        /// <para>
        /// <para>Determines whether the commitment period for a radio unit is set to automatically
        /// renew for an additional 1 year after your current commitment period expires.</para><para>Set to <c>True</c>, if you want your commitment period to automatically renew. Set
        /// to <c>False</c> if you do not want your commitment to automatically renew.</para><para>You can do the following:</para><ul><li><para>Set a 1-year commitment to automatically renew for an additional 1 year. The hourly
        /// rate for the additional year will continue to be the same as your existing 1-year
        /// rate.</para></li><li><para>Set a 3-year commitment to automatically renew for an additional 1 year. The hourly
        /// rate for the additional year will continue to be the same as your existing 3-year
        /// rate.</para></li><li><para>Turn off a previously-enabled automatic renewal on a 1-year or 3-year commitment.</para></li></ul><para>You cannot use the automatic-renewal option for a 60-day commitment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CommitmentConfiguration_AutomaticRenewal { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_City
        /// <summary>
        /// <para>
        /// <para>The city for this address.</para>
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
        public System.String ShippingAddress_City { get; set; }
        #endregion
        
        #region Parameter CommitmentConfiguration_CommitmentLength
        /// <summary>
        /// <para>
        /// <para>The duration of the commitment period for the radio unit. You can choose a 60-day,
        /// 1-year, or 3-year period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Private5G.CommitmentLength")]
        public Amazon.Private5G.CommitmentLength CommitmentConfiguration_CommitmentLength { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Company
        /// <summary>
        /// <para>
        /// <para>The company name for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Company { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Country
        /// <summary>
        /// <para>
        /// <para>The country for this address.</para>
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
        public System.String ShippingAddress_Country { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The recipient's email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_EmailAddress { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Name
        /// <summary>
        /// <para>
        /// <para>The recipient's name for this address.</para>
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
        public System.String ShippingAddress_Name { get; set; }
        #endregion
        
        #region Parameter NetworkSiteArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network site.</para>
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
        public System.String NetworkSiteArn { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The recipient's phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code for this address.</para>
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
        public System.String ShippingAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_StateOrProvince
        /// <summary>
        /// <para>
        /// <para>The state or province for this address.</para>
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
        public System.String ShippingAddress_StateOrProvince { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Street1
        /// <summary>
        /// <para>
        /// <para>The first line of the street address.</para>
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
        public System.String ShippingAddress_Street1 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Street2
        /// <summary>
        /// <para>
        /// <para>The second line of the street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Street2 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Street3
        /// <summary>
        /// <para>
        /// <para>The third line of the street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Street3 { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkSite'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Private5G.Model.ActivateNetworkSiteResponse).
        /// Specifying the name of a property of type Amazon.Private5G.Model.ActivateNetworkSiteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkSite";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkSiteArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-PV5GNetworkSite (ActivateNetworkSite)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Private5G.Model.ActivateNetworkSiteResponse, EnablePV5GNetworkSiteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CommitmentConfiguration_AutomaticRenewal = this.CommitmentConfiguration_AutomaticRenewal;
            context.CommitmentConfiguration_CommitmentLength = this.CommitmentConfiguration_CommitmentLength;
            context.NetworkSiteArn = this.NetworkSiteArn;
            #if MODULAR
            if (this.NetworkSiteArn == null && ParameterWasBound(nameof(this.NetworkSiteArn)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkSiteArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_City = this.ShippingAddress_City;
            #if MODULAR
            if (this.ShippingAddress_City == null && ParameterWasBound(nameof(this.ShippingAddress_City)))
            {
                WriteWarning("You are passing $null as a value for parameter ShippingAddress_City which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_Company = this.ShippingAddress_Company;
            context.ShippingAddress_Country = this.ShippingAddress_Country;
            #if MODULAR
            if (this.ShippingAddress_Country == null && ParameterWasBound(nameof(this.ShippingAddress_Country)))
            {
                WriteWarning("You are passing $null as a value for parameter ShippingAddress_Country which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_EmailAddress = this.ShippingAddress_EmailAddress;
            context.ShippingAddress_Name = this.ShippingAddress_Name;
            #if MODULAR
            if (this.ShippingAddress_Name == null && ParameterWasBound(nameof(this.ShippingAddress_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ShippingAddress_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_PhoneNumber = this.ShippingAddress_PhoneNumber;
            context.ShippingAddress_PostalCode = this.ShippingAddress_PostalCode;
            #if MODULAR
            if (this.ShippingAddress_PostalCode == null && ParameterWasBound(nameof(this.ShippingAddress_PostalCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ShippingAddress_PostalCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_StateOrProvince = this.ShippingAddress_StateOrProvince;
            #if MODULAR
            if (this.ShippingAddress_StateOrProvince == null && ParameterWasBound(nameof(this.ShippingAddress_StateOrProvince)))
            {
                WriteWarning("You are passing $null as a value for parameter ShippingAddress_StateOrProvince which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_Street1 = this.ShippingAddress_Street1;
            #if MODULAR
            if (this.ShippingAddress_Street1 == null && ParameterWasBound(nameof(this.ShippingAddress_Street1)))
            {
                WriteWarning("You are passing $null as a value for parameter ShippingAddress_Street1 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_Street2 = this.ShippingAddress_Street2;
            context.ShippingAddress_Street3 = this.ShippingAddress_Street3;
            
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
            var request = new Amazon.Private5G.Model.ActivateNetworkSiteRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CommitmentConfiguration
            var requestCommitmentConfigurationIsNull = true;
            request.CommitmentConfiguration = new Amazon.Private5G.Model.CommitmentConfiguration();
            System.Boolean? requestCommitmentConfiguration_commitmentConfiguration_AutomaticRenewal = null;
            if (cmdletContext.CommitmentConfiguration_AutomaticRenewal != null)
            {
                requestCommitmentConfiguration_commitmentConfiguration_AutomaticRenewal = cmdletContext.CommitmentConfiguration_AutomaticRenewal.Value;
            }
            if (requestCommitmentConfiguration_commitmentConfiguration_AutomaticRenewal != null)
            {
                request.CommitmentConfiguration.AutomaticRenewal = requestCommitmentConfiguration_commitmentConfiguration_AutomaticRenewal.Value;
                requestCommitmentConfigurationIsNull = false;
            }
            Amazon.Private5G.CommitmentLength requestCommitmentConfiguration_commitmentConfiguration_CommitmentLength = null;
            if (cmdletContext.CommitmentConfiguration_CommitmentLength != null)
            {
                requestCommitmentConfiguration_commitmentConfiguration_CommitmentLength = cmdletContext.CommitmentConfiguration_CommitmentLength;
            }
            if (requestCommitmentConfiguration_commitmentConfiguration_CommitmentLength != null)
            {
                request.CommitmentConfiguration.CommitmentLength = requestCommitmentConfiguration_commitmentConfiguration_CommitmentLength;
                requestCommitmentConfigurationIsNull = false;
            }
             // determine if request.CommitmentConfiguration should be set to null
            if (requestCommitmentConfigurationIsNull)
            {
                request.CommitmentConfiguration = null;
            }
            if (cmdletContext.NetworkSiteArn != null)
            {
                request.NetworkSiteArn = cmdletContext.NetworkSiteArn;
            }
            
             // populate ShippingAddress
            var requestShippingAddressIsNull = true;
            request.ShippingAddress = new Amazon.Private5G.Model.Address();
            System.String requestShippingAddress_shippingAddress_City = null;
            if (cmdletContext.ShippingAddress_City != null)
            {
                requestShippingAddress_shippingAddress_City = cmdletContext.ShippingAddress_City;
            }
            if (requestShippingAddress_shippingAddress_City != null)
            {
                request.ShippingAddress.City = requestShippingAddress_shippingAddress_City;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Company = null;
            if (cmdletContext.ShippingAddress_Company != null)
            {
                requestShippingAddress_shippingAddress_Company = cmdletContext.ShippingAddress_Company;
            }
            if (requestShippingAddress_shippingAddress_Company != null)
            {
                request.ShippingAddress.Company = requestShippingAddress_shippingAddress_Company;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Country = null;
            if (cmdletContext.ShippingAddress_Country != null)
            {
                requestShippingAddress_shippingAddress_Country = cmdletContext.ShippingAddress_Country;
            }
            if (requestShippingAddress_shippingAddress_Country != null)
            {
                request.ShippingAddress.Country = requestShippingAddress_shippingAddress_Country;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_EmailAddress = null;
            if (cmdletContext.ShippingAddress_EmailAddress != null)
            {
                requestShippingAddress_shippingAddress_EmailAddress = cmdletContext.ShippingAddress_EmailAddress;
            }
            if (requestShippingAddress_shippingAddress_EmailAddress != null)
            {
                request.ShippingAddress.EmailAddress = requestShippingAddress_shippingAddress_EmailAddress;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Name = null;
            if (cmdletContext.ShippingAddress_Name != null)
            {
                requestShippingAddress_shippingAddress_Name = cmdletContext.ShippingAddress_Name;
            }
            if (requestShippingAddress_shippingAddress_Name != null)
            {
                request.ShippingAddress.Name = requestShippingAddress_shippingAddress_Name;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_PhoneNumber = null;
            if (cmdletContext.ShippingAddress_PhoneNumber != null)
            {
                requestShippingAddress_shippingAddress_PhoneNumber = cmdletContext.ShippingAddress_PhoneNumber;
            }
            if (requestShippingAddress_shippingAddress_PhoneNumber != null)
            {
                request.ShippingAddress.PhoneNumber = requestShippingAddress_shippingAddress_PhoneNumber;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_PostalCode = null;
            if (cmdletContext.ShippingAddress_PostalCode != null)
            {
                requestShippingAddress_shippingAddress_PostalCode = cmdletContext.ShippingAddress_PostalCode;
            }
            if (requestShippingAddress_shippingAddress_PostalCode != null)
            {
                request.ShippingAddress.PostalCode = requestShippingAddress_shippingAddress_PostalCode;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_StateOrProvince = null;
            if (cmdletContext.ShippingAddress_StateOrProvince != null)
            {
                requestShippingAddress_shippingAddress_StateOrProvince = cmdletContext.ShippingAddress_StateOrProvince;
            }
            if (requestShippingAddress_shippingAddress_StateOrProvince != null)
            {
                request.ShippingAddress.StateOrProvince = requestShippingAddress_shippingAddress_StateOrProvince;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Street1 = null;
            if (cmdletContext.ShippingAddress_Street1 != null)
            {
                requestShippingAddress_shippingAddress_Street1 = cmdletContext.ShippingAddress_Street1;
            }
            if (requestShippingAddress_shippingAddress_Street1 != null)
            {
                request.ShippingAddress.Street1 = requestShippingAddress_shippingAddress_Street1;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Street2 = null;
            if (cmdletContext.ShippingAddress_Street2 != null)
            {
                requestShippingAddress_shippingAddress_Street2 = cmdletContext.ShippingAddress_Street2;
            }
            if (requestShippingAddress_shippingAddress_Street2 != null)
            {
                request.ShippingAddress.Street2 = requestShippingAddress_shippingAddress_Street2;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Street3 = null;
            if (cmdletContext.ShippingAddress_Street3 != null)
            {
                requestShippingAddress_shippingAddress_Street3 = cmdletContext.ShippingAddress_Street3;
            }
            if (requestShippingAddress_shippingAddress_Street3 != null)
            {
                request.ShippingAddress.Street3 = requestShippingAddress_shippingAddress_Street3;
                requestShippingAddressIsNull = false;
            }
             // determine if request.ShippingAddress should be set to null
            if (requestShippingAddressIsNull)
            {
                request.ShippingAddress = null;
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
        
        private Amazon.Private5G.Model.ActivateNetworkSiteResponse CallAWSServiceOperation(IAmazonPrivate5G client, Amazon.Private5G.Model.ActivateNetworkSiteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Private 5G", "ActivateNetworkSite");
            try
            {
                return client.ActivateNetworkSiteAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? CommitmentConfiguration_AutomaticRenewal { get; set; }
            public Amazon.Private5G.CommitmentLength CommitmentConfiguration_CommitmentLength { get; set; }
            public System.String NetworkSiteArn { get; set; }
            public System.String ShippingAddress_City { get; set; }
            public System.String ShippingAddress_Company { get; set; }
            public System.String ShippingAddress_Country { get; set; }
            public System.String ShippingAddress_EmailAddress { get; set; }
            public System.String ShippingAddress_Name { get; set; }
            public System.String ShippingAddress_PhoneNumber { get; set; }
            public System.String ShippingAddress_PostalCode { get; set; }
            public System.String ShippingAddress_StateOrProvince { get; set; }
            public System.String ShippingAddress_Street1 { get; set; }
            public System.String ShippingAddress_Street2 { get; set; }
            public System.String ShippingAddress_Street3 { get; set; }
            public System.Func<Amazon.Private5G.Model.ActivateNetworkSiteResponse, EnablePV5GNetworkSiteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkSite;
        }
        
    }
}
