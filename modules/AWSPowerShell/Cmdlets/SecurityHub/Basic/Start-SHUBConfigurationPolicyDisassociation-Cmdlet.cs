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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Disassociates a target account, organizational unit, or the root from a specified
    /// configuration. When you disassociate a configuration from its target, the target inherits
    /// the configuration of the closest parent. If there’s no configuration to inherit, the
    /// target retains its settings but becomes a self-managed account. A target can be disassociated
    /// from a configuration policy or self-managed behavior. Only the Security Hub delegated
    /// administrator can invoke this operation from the home Region.
    /// </summary>
    [Cmdlet("Start", "SHUBConfigurationPolicyDisassociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub StartConfigurationPolicyDisassociation API operation.", Operation = new[] {"StartConfigurationPolicyDisassociation"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartSHUBConfigurationPolicyDisassociationCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Target_AccountId
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account ID of the target account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_AccountId { get; set; }
        #endregion
        
        #region Parameter ConfigurationPolicyIdentifier
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of a configuration policy, the universally unique
        /// identifier (UUID) of a configuration policy, or a value of <c>SELF_MANAGED_SECURITY_HUB</c>
        /// for a self-managed configuration. </para>
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
        public System.String ConfigurationPolicyIdentifier { get; set; }
        #endregion
        
        #region Parameter Target_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para> The organizational unit ID of the target organizational unit. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Target_RootId
        /// <summary>
        /// <para>
        /// <para> The ID of the organization root. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_RootId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationPolicyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SHUBConfigurationPolicyDisassociation (StartConfigurationPolicyDisassociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationResponse, StartSHUBConfigurationPolicyDisassociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationPolicyIdentifier = this.ConfigurationPolicyIdentifier;
            #if MODULAR
            if (this.ConfigurationPolicyIdentifier == null && ParameterWasBound(nameof(this.ConfigurationPolicyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationPolicyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Target_AccountId = this.Target_AccountId;
            context.Target_OrganizationalUnitId = this.Target_OrganizationalUnitId;
            context.Target_RootId = this.Target_RootId;
            
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
            var request = new Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationRequest();
            
            if (cmdletContext.ConfigurationPolicyIdentifier != null)
            {
                request.ConfigurationPolicyIdentifier = cmdletContext.ConfigurationPolicyIdentifier;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.SecurityHub.Model.Target();
            System.String requestTarget_target_AccountId = null;
            if (cmdletContext.Target_AccountId != null)
            {
                requestTarget_target_AccountId = cmdletContext.Target_AccountId;
            }
            if (requestTarget_target_AccountId != null)
            {
                request.Target.AccountId = requestTarget_target_AccountId;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_OrganizationalUnitId = null;
            if (cmdletContext.Target_OrganizationalUnitId != null)
            {
                requestTarget_target_OrganizationalUnitId = cmdletContext.Target_OrganizationalUnitId;
            }
            if (requestTarget_target_OrganizationalUnitId != null)
            {
                request.Target.OrganizationalUnitId = requestTarget_target_OrganizationalUnitId;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_RootId = null;
            if (cmdletContext.Target_RootId != null)
            {
                requestTarget_target_RootId = cmdletContext.Target_RootId;
            }
            if (requestTarget_target_RootId != null)
            {
                request.Target.RootId = requestTarget_target_RootId;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "StartConfigurationPolicyDisassociation");
            try
            {
                return client.StartConfigurationPolicyDisassociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationPolicyIdentifier { get; set; }
            public System.String Target_AccountId { get; set; }
            public System.String Target_OrganizationalUnitId { get; set; }
            public System.String Target_RootId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.StartConfigurationPolicyDisassociationResponse, StartSHUBConfigurationPolicyDisassociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
