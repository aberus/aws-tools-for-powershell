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
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Disconnects a specified participant from a specified stage. If the participant is
    /// publishing using an <a>IngestConfiguration</a>, DisconnectParticipant also updates
    /// the <c>stageArn</c> in the IngestConfiguration to be an empty string.
    /// </summary>
    [Cmdlet("Disconnect", "IVSRTParticipant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime DisconnectParticipant API operation.", Operation = new[] {"DisconnectParticipant"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.DisconnectParticipantResponse))]
    [AWSCmdletOutput("None or Amazon.IVSRealTime.Model.DisconnectParticipantResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IVSRealTime.Model.DisconnectParticipantResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisconnectIVSRTParticipantCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ParticipantId
        /// <summary>
        /// <para>
        /// <para>Identifier of the participant to be disconnected. IVS assigns this; it is returned
        /// by <a>CreateParticipantToken</a> (for streams using WebRTC ingest) or <a>CreateIngestConfiguration</a>
        /// (for streams using RTMP ingest).</para>
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
        public System.String ParticipantId { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>Description of why this participant is being disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter StageArn
        /// <summary>
        /// <para>
        /// <para>ARN of the stage to which the participant is attached.</para>
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
        public System.String StageArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.DisconnectParticipantResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ParticipantId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ParticipantId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ParticipantId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ParticipantId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disconnect-IVSRTParticipant (DisconnectParticipant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.DisconnectParticipantResponse, DisconnectIVSRTParticipantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ParticipantId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ParticipantId = this.ParticipantId;
            #if MODULAR
            if (this.ParticipantId == null && ParameterWasBound(nameof(this.ParticipantId)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Reason = this.Reason;
            context.StageArn = this.StageArn;
            #if MODULAR
            if (this.StageArn == null && ParameterWasBound(nameof(this.StageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IVSRealTime.Model.DisconnectParticipantRequest();
            
            if (cmdletContext.ParticipantId != null)
            {
                request.ParticipantId = cmdletContext.ParticipantId;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
            }
            if (cmdletContext.StageArn != null)
            {
                request.StageArn = cmdletContext.StageArn;
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
        
        private Amazon.IVSRealTime.Model.DisconnectParticipantResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.DisconnectParticipantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "DisconnectParticipant");
            try
            {
                #if DESKTOP
                return client.DisconnectParticipant(request);
                #elif CORECLR
                return client.DisconnectParticipantAsync(request).GetAwaiter().GetResult();
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
            public System.String ParticipantId { get; set; }
            public System.String Reason { get; set; }
            public System.String StageArn { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.DisconnectParticipantResponse, DisconnectIVSRTParticipantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
