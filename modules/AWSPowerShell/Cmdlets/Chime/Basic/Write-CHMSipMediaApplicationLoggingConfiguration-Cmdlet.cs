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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Updates the logging configuration for the specified SIP media application.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_PutSipMediaApplicationLoggingConfiguration.html">PutSipMediaApplicationLoggingConfiguration</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "CHMSipMediaApplicationLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.SipMediaApplicationLoggingConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime PutSipMediaApplicationLoggingConfiguration API operation.", Operation = new[] {"PutSipMediaApplicationLoggingConfiguration"}, SelectReturnType = typeof(Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.SipMediaApplicationLoggingConfiguration or Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.Chime.Model.SipMediaApplicationLoggingConfiguration object.",
        "The service call response (type Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by PutSipMediaApplicationLoggingConfiguration in the Amazon Chime SDK Voice Namespace")]
    public partial class WriteCHMSipMediaApplicationLoggingConfigurationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog
        /// <summary>
        /// <para>
        /// <para>Enables application message logs for the SIP media application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLogs")]
        public System.Boolean? SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog { get; set; }
        #endregion
        
        #region Parameter SipMediaApplicationId
        /// <summary>
        /// <para>
        /// <para>The SIP media application ID.</para>
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
        public System.String SipMediaApplicationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SipMediaApplicationLoggingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SipMediaApplicationLoggingConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SipMediaApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMSipMediaApplicationLoggingConfiguration (PutSipMediaApplicationLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse, WriteCHMSipMediaApplicationLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SipMediaApplicationId = this.SipMediaApplicationId;
            #if MODULAR
            if (this.SipMediaApplicationId == null && ParameterWasBound(nameof(this.SipMediaApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter SipMediaApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog = this.SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog;
            
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
            var request = new Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationRequest();
            
            if (cmdletContext.SipMediaApplicationId != null)
            {
                request.SipMediaApplicationId = cmdletContext.SipMediaApplicationId;
            }
            
             // populate SipMediaApplicationLoggingConfiguration
            var requestSipMediaApplicationLoggingConfigurationIsNull = true;
            request.SipMediaApplicationLoggingConfiguration = new Amazon.Chime.Model.SipMediaApplicationLoggingConfiguration();
            System.Boolean? requestSipMediaApplicationLoggingConfiguration_sipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog = null;
            if (cmdletContext.SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog != null)
            {
                requestSipMediaApplicationLoggingConfiguration_sipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog = cmdletContext.SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog.Value;
            }
            if (requestSipMediaApplicationLoggingConfiguration_sipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog != null)
            {
                request.SipMediaApplicationLoggingConfiguration.EnableSipMediaApplicationMessageLogs = requestSipMediaApplicationLoggingConfiguration_sipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog.Value;
                requestSipMediaApplicationLoggingConfigurationIsNull = false;
            }
             // determine if request.SipMediaApplicationLoggingConfiguration should be set to null
            if (requestSipMediaApplicationLoggingConfigurationIsNull)
            {
                request.SipMediaApplicationLoggingConfiguration = null;
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
        
        private Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutSipMediaApplicationLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.PutSipMediaApplicationLoggingConfiguration(request);
                #elif CORECLR
                return client.PutSipMediaApplicationLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String SipMediaApplicationId { get; set; }
            public System.Boolean? SipMediaApplicationLoggingConfiguration_EnableSipMediaApplicationMessageLog { get; set; }
            public System.Func<Amazon.Chime.Model.PutSipMediaApplicationLoggingConfigurationResponse, WriteCHMSipMediaApplicationLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SipMediaApplicationLoggingConfiguration;
        }
        
    }
}
