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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Associate the registration with an origination identity such as a phone number or
    /// sender ID.
    /// </summary>
    [Cmdlet("New", "SMSVRegistrationAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 CreateRegistrationAssociation API operation.", Operation = new[] {"CreateRegistrationAssociation"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse object containing multiple properties."
    )]
    public partial class NewSMSVRegistrationAssociationCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RegistrationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the registration.</para>
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
        public System.String RegistrationId { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the origination identity. For example this could be a <b>PhoneNumberId</b>
        /// or <b>SenderId</b>.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RegistrationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMSVRegistrationAssociation (CreateRegistrationAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse, NewSMSVRegistrationAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RegistrationId = this.RegistrationId;
            #if MODULAR
            if (this.RegistrationId == null && ParameterWasBound(nameof(this.RegistrationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistrationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationRequest();
            
            if (cmdletContext.RegistrationId != null)
            {
                request.RegistrationId = cmdletContext.RegistrationId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "CreateRegistrationAssociation");
            try
            {
                return client.CreateRegistrationAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RegistrationId { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.CreateRegistrationAssociationResponse, NewSMSVRegistrationAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
