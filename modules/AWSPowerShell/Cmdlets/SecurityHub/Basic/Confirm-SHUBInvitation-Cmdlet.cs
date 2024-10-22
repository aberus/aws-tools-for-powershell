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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// This method is deprecated. Instead, use <c>AcceptAdministratorInvitation</c>.
    /// 
    ///  
    /// <para>
    /// The Security Hub console continues to use <c>AcceptInvitation</c>. It will eventually
    /// change to use <c>AcceptAdministratorInvitation</c>. Any IAM policies that specifically
    /// control access to this function must continue to use <c>AcceptInvitation</c>. You
    /// should also add <c>AcceptAdministratorInvitation</c> to your policies to ensure that
    /// the correct permissions are in place after the console begins to use <c>AcceptAdministratorInvitation</c>.
    /// </para><para>
    /// Accepts the invitation to be a member account and be monitored by the Security Hub
    /// administrator account that the invitation was sent from.
    /// </para><para>
    /// This operation is only used by member accounts that are not added through Organizations.
    /// </para><para>
    /// When the member account accepts the invitation, permission is granted to the administrator
    /// account to view findings generated in the member account.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Confirm", "SHUBInvitation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub AcceptInvitation API operation.", Operation = new[] {"AcceptInvitation"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.AcceptInvitationResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.AcceptInvitationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.AcceptInvitationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("This API has been deprecated, use AcceptAdministratorInvitation API instead.")]
    public partial class ConfirmSHUBInvitationCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InvitationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the invitation sent from the Security Hub administrator account.</para>
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
        public System.String InvitationId { get; set; }
        #endregion
        
        #region Parameter MasterId
        /// <summary>
        /// <para>
        /// <para>The account ID of the Security Hub administrator account that sent the invitation.</para>
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
        public System.String MasterId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.AcceptInvitationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InvitationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-SHUBInvitation (AcceptInvitation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.AcceptInvitationResponse, ConfirmSHUBInvitationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InvitationId = this.InvitationId;
            #if MODULAR
            if (this.InvitationId == null && ParameterWasBound(nameof(this.InvitationId)))
            {
                WriteWarning("You are passing $null as a value for parameter InvitationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MasterId = this.MasterId;
            #if MODULAR
            if (this.MasterId == null && ParameterWasBound(nameof(this.MasterId)))
            {
                WriteWarning("You are passing $null as a value for parameter MasterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.AcceptInvitationRequest();
            
            if (cmdletContext.InvitationId != null)
            {
                request.InvitationId = cmdletContext.InvitationId;
            }
            if (cmdletContext.MasterId != null)
            {
                request.MasterId = cmdletContext.MasterId;
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
        
        private Amazon.SecurityHub.Model.AcceptInvitationResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.AcceptInvitationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "AcceptInvitation");
            try
            {
                #if DESKTOP
                return client.AcceptInvitation(request);
                #elif CORECLR
                return client.AcceptInvitationAsync(request).GetAwaiter().GetResult();
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
            public System.String InvitationId { get; set; }
            public System.String MasterId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.AcceptInvitationResponse, ConfirmSHUBInvitationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
