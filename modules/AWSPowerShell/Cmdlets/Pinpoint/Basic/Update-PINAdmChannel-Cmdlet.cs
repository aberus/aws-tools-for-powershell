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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Enables the ADM channel for an application or updates the status and settings of the
    /// ADM channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINAdmChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ADMChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateAdmChannel API operation.", Operation = new[] {"UpdateAdmChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateAdmChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ADMChannelResponse or Amazon.Pinpoint.Model.UpdateAdmChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.ADMChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateAdmChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINAdmChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ADMChannelRequest_ClientId
        /// <summary>
        /// <para>
        /// <para>The Client ID that you received from Amazon to send messages by using ADM.</para>
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
        public System.String ADMChannelRequest_ClientId { get; set; }
        #endregion
        
        #region Parameter ADMChannelRequest_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The Client Secret that you received from Amazon to send messages by using ADM.</para>
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
        public System.String ADMChannelRequest_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ADMChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the ADM channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ADMChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ADMChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateAdmChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateAdmChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ADMChannelResponse";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINAdmChannel (UpdateAdmChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateAdmChannelResponse, UpdatePINAdmChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ADMChannelRequest_ClientId = this.ADMChannelRequest_ClientId;
            #if MODULAR
            if (this.ADMChannelRequest_ClientId == null && ParameterWasBound(nameof(this.ADMChannelRequest_ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ADMChannelRequest_ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ADMChannelRequest_ClientSecret = this.ADMChannelRequest_ClientSecret;
            #if MODULAR
            if (this.ADMChannelRequest_ClientSecret == null && ParameterWasBound(nameof(this.ADMChannelRequest_ClientSecret)))
            {
                WriteWarning("You are passing $null as a value for parameter ADMChannelRequest_ClientSecret which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ADMChannelRequest_Enabled = this.ADMChannelRequest_Enabled;
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.UpdateAdmChannelRequest();
            
            
             // populate ADMChannelRequest
            var requestADMChannelRequestIsNull = true;
            request.ADMChannelRequest = new Amazon.Pinpoint.Model.ADMChannelRequest();
            System.String requestADMChannelRequest_aDMChannelRequest_ClientId = null;
            if (cmdletContext.ADMChannelRequest_ClientId != null)
            {
                requestADMChannelRequest_aDMChannelRequest_ClientId = cmdletContext.ADMChannelRequest_ClientId;
            }
            if (requestADMChannelRequest_aDMChannelRequest_ClientId != null)
            {
                request.ADMChannelRequest.ClientId = requestADMChannelRequest_aDMChannelRequest_ClientId;
                requestADMChannelRequestIsNull = false;
            }
            System.String requestADMChannelRequest_aDMChannelRequest_ClientSecret = null;
            if (cmdletContext.ADMChannelRequest_ClientSecret != null)
            {
                requestADMChannelRequest_aDMChannelRequest_ClientSecret = cmdletContext.ADMChannelRequest_ClientSecret;
            }
            if (requestADMChannelRequest_aDMChannelRequest_ClientSecret != null)
            {
                request.ADMChannelRequest.ClientSecret = requestADMChannelRequest_aDMChannelRequest_ClientSecret;
                requestADMChannelRequestIsNull = false;
            }
            System.Boolean? requestADMChannelRequest_aDMChannelRequest_Enabled = null;
            if (cmdletContext.ADMChannelRequest_Enabled != null)
            {
                requestADMChannelRequest_aDMChannelRequest_Enabled = cmdletContext.ADMChannelRequest_Enabled.Value;
            }
            if (requestADMChannelRequest_aDMChannelRequest_Enabled != null)
            {
                request.ADMChannelRequest.Enabled = requestADMChannelRequest_aDMChannelRequest_Enabled.Value;
                requestADMChannelRequestIsNull = false;
            }
             // determine if request.ADMChannelRequest should be set to null
            if (requestADMChannelRequestIsNull)
            {
                request.ADMChannelRequest = null;
            }
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
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
        
        private Amazon.Pinpoint.Model.UpdateAdmChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateAdmChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateAdmChannel");
            try
            {
                #if DESKTOP
                return client.UpdateAdmChannel(request);
                #elif CORECLR
                return client.UpdateAdmChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String ADMChannelRequest_ClientId { get; set; }
            public System.String ADMChannelRequest_ClientSecret { get; set; }
            public System.Boolean? ADMChannelRequest_Enabled { get; set; }
            public System.String ApplicationId { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateAdmChannelResponse, UpdatePINAdmChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ADMChannelResponse;
        }
        
    }
}
