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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Adds a logging configuration for the specified Amazon Chime Voice Connector. The logging
    /// configuration specifies whether SIP message logs are enabled for sending to Amazon
    /// CloudWatch Logs.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_PutVoiceConnectorLoggingConfiguration.html">PutVoiceConnectorLoggingConfiguration</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "CHMVoiceConnectorLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.LoggingConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime PutVoiceConnectorLoggingConfiguration API operation.", Operation = new[] {"PutVoiceConnectorLoggingConfiguration"}, SelectReturnType = typeof(Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.LoggingConfiguration or Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.Chime.Model.LoggingConfiguration object.",
        "The service call response (type Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by PutVoiceConnectorLoggingConfiguration in the Amazon Chime SDK Voice Namespace")]
    public partial class WriteCHMVoiceConnectorLoggingConfigurationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoggingConfiguration_EnableMediaMetricLog
        /// <summary>
        /// <para>
        /// <para>Boolean that enables logging of detailed media metrics for Voice Connectors to Amazon
        /// CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_EnableMediaMetricLogs")]
        public System.Boolean? LoggingConfiguration_EnableMediaMetricLog { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_EnableSIPLog
        /// <summary>
        /// <para>
        /// <para>Boolean that enables SIP message logs to Amazon CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_EnableSIPLogs")]
        public System.Boolean? LoggingConfiguration_EnableSIPLog { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime Voice Connector ID.</para>
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
        public System.String VoiceConnectorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoggingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoggingConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVoiceConnectorLoggingConfiguration (PutVoiceConnectorLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse, WriteCHMVoiceConnectorLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoggingConfiguration_EnableMediaMetricLog = this.LoggingConfiguration_EnableMediaMetricLog;
            context.LoggingConfiguration_EnableSIPLog = this.LoggingConfiguration_EnableSIPLog;
            context.VoiceConnectorId = this.VoiceConnectorId;
            #if MODULAR
            if (this.VoiceConnectorId == null && ParameterWasBound(nameof(this.VoiceConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationRequest();
            
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.Chime.Model.LoggingConfiguration();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog = null;
            if (cmdletContext.LoggingConfiguration_EnableMediaMetricLog != null)
            {
                requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog = cmdletContext.LoggingConfiguration_EnableMediaMetricLog.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog != null)
            {
                request.LoggingConfiguration.EnableMediaMetricLogs = requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog.Value;
                requestLoggingConfigurationIsNull = false;
            }
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_EnableSIPLog = null;
            if (cmdletContext.LoggingConfiguration_EnableSIPLog != null)
            {
                requestLoggingConfiguration_loggingConfiguration_EnableSIPLog = cmdletContext.LoggingConfiguration_EnableSIPLog.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_EnableSIPLog != null)
            {
                request.LoggingConfiguration.EnableSIPLogs = requestLoggingConfiguration_loggingConfiguration_EnableSIPLog.Value;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            if (cmdletContext.VoiceConnectorId != null)
            {
                request.VoiceConnectorId = cmdletContext.VoiceConnectorId;
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
        
        private Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutVoiceConnectorLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorLoggingConfiguration(request);
                #elif CORECLR
                return client.PutVoiceConnectorLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? LoggingConfiguration_EnableMediaMetricLog { get; set; }
            public System.Boolean? LoggingConfiguration_EnableSIPLog { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.Chime.Model.PutVoiceConnectorLoggingConfigurationResponse, WriteCHMVoiceConnectorLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingConfiguration;
        }
        
    }
}
