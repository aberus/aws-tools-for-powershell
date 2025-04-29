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
using Amazon.Macie2;
using Amazon.Macie2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Changes the configuration settings and status of automated sensitive data discovery
    /// for an organization or standalone account.
    /// </summary>
    [Cmdlet("Update", "MAC2AutomatedDiscoveryConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Macie 2 UpdateAutomatedDiscoveryConfiguration API operation.", Operation = new[] {"UpdateAutomatedDiscoveryConfiguration"}, SelectReturnType = typeof(Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateMAC2AutomatedDiscoveryConfigurationCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoEnableOrganizationMember
        /// <summary>
        /// <para>
        /// <para>Specifies whether to automatically enable automated sensitive data discovery for accounts
        /// in the organization. Valid values are: ALL (default), enable it for all existing accounts
        /// and new member accounts; NEW, enable it only for new member accounts; and, NONE, don't
        /// enable it for any accounts.</para><para>If you specify NEW or NONE, automated sensitive data discovery continues to be enabled
        /// for any existing accounts that it's currently enabled for. To enable or disable it
        /// for individual member accounts, specify NEW or NONE, and then enable or disable it
        /// for each account by using the BatchUpdateAutomatedDiscoveryAccounts operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoEnableOrganizationMembers")]
        [AWSConstantClassSource("Amazon.Macie2.AutoEnableMode")]
        public Amazon.Macie2.AutoEnableMode AutoEnableOrganizationMember { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new status of automated sensitive data discovery for the organization or account.
        /// Valid values are: ENABLED, start or resume all automated sensitive data discovery
        /// activities; and, DISABLED, stop performing all automated sensitive data discovery
        /// activities.</para><para>If you specify DISABLED for an administrator account, you also disable automated sensitive
        /// data discovery for all member accounts in the organization.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Macie2.AutomatedDiscoveryStatus")]
        public Amazon.Macie2.AutomatedDiscoveryStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Status), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MAC2AutomatedDiscoveryConfiguration (UpdateAutomatedDiscoveryConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationResponse, UpdateMAC2AutomatedDiscoveryConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoEnableOrganizationMember = this.AutoEnableOrganizationMember;
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationRequest();
            
            if (cmdletContext.AutoEnableOrganizationMember != null)
            {
                request.AutoEnableOrganizationMembers = cmdletContext.AutoEnableOrganizationMember;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "UpdateAutomatedDiscoveryConfiguration");
            try
            {
                return client.UpdateAutomatedDiscoveryConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Macie2.AutoEnableMode AutoEnableOrganizationMember { get; set; }
            public Amazon.Macie2.AutomatedDiscoveryStatus Status { get; set; }
            public System.Func<Amazon.Macie2.Model.UpdateAutomatedDiscoveryConfigurationResponse, UpdateMAC2AutomatedDiscoveryConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
