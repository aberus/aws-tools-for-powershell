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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("New", "CHMVOSipMediaApplicationCall", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.SipMediaApplicationCall")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice CreateSipMediaApplicationCall API operation.", Operation = new[] {"CreateSipMediaApplicationCall"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.SipMediaApplicationCall or Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.SipMediaApplicationCall object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMVOSipMediaApplicationCallCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        #region Parameter ArgumentsMap
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ArgumentsMap { get; set; }
        #endregion
        
        #region Parameter FromPhoneNumber
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String FromPhoneNumber { get; set; }
        #endregion
        
        #region Parameter SipHeader
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SipHeaders")]
        public System.Collections.Hashtable SipHeader { get; set; }
        #endregion
        
        #region Parameter SipMediaApplicationId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String SipMediaApplicationId { get; set; }
        #endregion
        
        #region Parameter ToPhoneNumber
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ToPhoneNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SipMediaApplicationCall'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SipMediaApplicationCall";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SipMediaApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMVOSipMediaApplicationCall (CreateSipMediaApplicationCall)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse, NewCHMVOSipMediaApplicationCallCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ArgumentsMap != null)
            {
                context.ArgumentsMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ArgumentsMap.Keys)
                {
                    context.ArgumentsMap.Add((String)hashKey, (String)(this.ArgumentsMap[hashKey]));
                }
            }
            context.FromPhoneNumber = this.FromPhoneNumber;
            #if MODULAR
            if (this.FromPhoneNumber == null && ParameterWasBound(nameof(this.FromPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter FromPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SipHeader != null)
            {
                context.SipHeader = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SipHeader.Keys)
                {
                    context.SipHeader.Add((String)hashKey, (String)(this.SipHeader[hashKey]));
                }
            }
            context.SipMediaApplicationId = this.SipMediaApplicationId;
            #if MODULAR
            if (this.SipMediaApplicationId == null && ParameterWasBound(nameof(this.SipMediaApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter SipMediaApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ToPhoneNumber = this.ToPhoneNumber;
            #if MODULAR
            if (this.ToPhoneNumber == null && ParameterWasBound(nameof(this.ToPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter ToPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallRequest();
            
            if (cmdletContext.ArgumentsMap != null)
            {
                request.ArgumentsMap = cmdletContext.ArgumentsMap;
            }
            if (cmdletContext.FromPhoneNumber != null)
            {
                request.FromPhoneNumber = cmdletContext.FromPhoneNumber;
            }
            if (cmdletContext.SipHeader != null)
            {
                request.SipHeaders = cmdletContext.SipHeader;
            }
            if (cmdletContext.SipMediaApplicationId != null)
            {
                request.SipMediaApplicationId = cmdletContext.SipMediaApplicationId;
            }
            if (cmdletContext.ToPhoneNumber != null)
            {
                request.ToPhoneNumber = cmdletContext.ToPhoneNumber;
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
        
        private Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "CreateSipMediaApplicationCall");
            try
            {
                #if DESKTOP
                return client.CreateSipMediaApplicationCall(request);
                #elif CORECLR
                return client.CreateSipMediaApplicationCallAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> ArgumentsMap { get; set; }
            public System.String FromPhoneNumber { get; set; }
            public Dictionary<System.String, System.String> SipHeader { get; set; }
            public System.String SipMediaApplicationId { get; set; }
            public System.String ToPhoneNumber { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.CreateSipMediaApplicationCallResponse, NewCHMVOSipMediaApplicationCallCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SipMediaApplicationCall;
        }
        
    }
}
