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
using Amazon.PcaConnectorAd;
using Amazon.PcaConnectorAd.Model;

namespace Amazon.PowerShell.Cmdlets.PCAAD
{
    /// <summary>
    /// Creates a service principal name (SPN) for the service account in Active Directory.
    /// Kerberos authentication uses SPNs to associate a service instance with a service sign-in
    /// account.
    /// </summary>
    [Cmdlet("New", "PCAADServicePrincipalName", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Pca Connector Ad CreateServicePrincipalName API operation.", Operation = new[] {"CreateServicePrincipalName"}, SelectReturnType = typeof(Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameResponse))]
    [AWSCmdletOutput("None or Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewPCAADServicePrincipalNameCmdlet : AmazonPcaConnectorAdClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectorArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateConnector.html">CreateConnector</a>.</para>
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
        public System.String ConnectorArn { get; set; }
        #endregion
        
        #region Parameter DirectoryRegistrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateDirectoryRegistration.html">CreateDirectoryRegistration</a>.</para>
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
        public System.String DirectoryRegistrationArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryRegistrationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCAADServicePrincipalName (CreateServicePrincipalName)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameResponse, NewPCAADServicePrincipalNameCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectorArn = this.ConnectorArn;
            #if MODULAR
            if (this.ConnectorArn == null && ParameterWasBound(nameof(this.ConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DirectoryRegistrationArn = this.DirectoryRegistrationArn;
            #if MODULAR
            if (this.DirectoryRegistrationArn == null && ParameterWasBound(nameof(this.DirectoryRegistrationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryRegistrationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectorArn != null)
            {
                request.ConnectorArn = cmdletContext.ConnectorArn;
            }
            if (cmdletContext.DirectoryRegistrationArn != null)
            {
                request.DirectoryRegistrationArn = cmdletContext.DirectoryRegistrationArn;
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
        
        private Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameResponse CallAWSServiceOperation(IAmazonPcaConnectorAd client, Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Pca Connector Ad", "CreateServicePrincipalName");
            try
            {
                #if DESKTOP
                return client.CreateServicePrincipalName(request);
                #elif CORECLR
                return client.CreateServicePrincipalNameAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectorArn { get; set; }
            public System.String DirectoryRegistrationArn { get; set; }
            public System.Func<Amazon.PcaConnectorAd.Model.CreateServicePrincipalNameResponse, NewPCAADServicePrincipalNameCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
