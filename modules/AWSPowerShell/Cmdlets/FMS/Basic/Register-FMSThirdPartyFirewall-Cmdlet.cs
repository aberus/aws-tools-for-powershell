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
using Amazon.FMS;
using Amazon.FMS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Sets the Firewall Manager policy administrator as a tenant administrator of a third-party
    /// firewall service. A tenant is an instance of the third-party firewall service that's
    /// associated with your Amazon Web Services customer account.
    /// </summary>
    [Cmdlet("Register", "FMSThirdPartyFirewall", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FMS.ThirdPartyFirewallAssociationStatus")]
    [AWSCmdlet("Calls the Firewall Management Service AssociateThirdPartyFirewall API operation.", Operation = new[] {"AssociateThirdPartyFirewall"}, SelectReturnType = typeof(Amazon.FMS.Model.AssociateThirdPartyFirewallResponse))]
    [AWSCmdletOutput("Amazon.FMS.ThirdPartyFirewallAssociationStatus or Amazon.FMS.Model.AssociateThirdPartyFirewallResponse",
        "This cmdlet returns an Amazon.FMS.ThirdPartyFirewallAssociationStatus object.",
        "The service call response (type Amazon.FMS.Model.AssociateThirdPartyFirewallResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterFMSThirdPartyFirewallCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ThirdPartyFirewall
        /// <summary>
        /// <para>
        /// <para>The name of the third-party firewall vendor.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FMS.ThirdPartyFirewall")]
        public Amazon.FMS.ThirdPartyFirewall ThirdPartyFirewall { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ThirdPartyFirewallStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.AssociateThirdPartyFirewallResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.AssociateThirdPartyFirewallResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ThirdPartyFirewallStatus";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThirdPartyFirewall), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-FMSThirdPartyFirewall (AssociateThirdPartyFirewall)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.AssociateThirdPartyFirewallResponse, RegisterFMSThirdPartyFirewallCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ThirdPartyFirewall = this.ThirdPartyFirewall;
            #if MODULAR
            if (this.ThirdPartyFirewall == null && ParameterWasBound(nameof(this.ThirdPartyFirewall)))
            {
                WriteWarning("You are passing $null as a value for parameter ThirdPartyFirewall which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FMS.Model.AssociateThirdPartyFirewallRequest();
            
            if (cmdletContext.ThirdPartyFirewall != null)
            {
                request.ThirdPartyFirewall = cmdletContext.ThirdPartyFirewall;
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
        
        private Amazon.FMS.Model.AssociateThirdPartyFirewallResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.AssociateThirdPartyFirewallRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "AssociateThirdPartyFirewall");
            try
            {
                return client.AssociateThirdPartyFirewallAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.FMS.ThirdPartyFirewall ThirdPartyFirewall { get; set; }
            public System.Func<Amazon.FMS.Model.AssociateThirdPartyFirewallResponse, RegisterFMSThirdPartyFirewallCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ThirdPartyFirewallStatus;
        }
        
    }
}
