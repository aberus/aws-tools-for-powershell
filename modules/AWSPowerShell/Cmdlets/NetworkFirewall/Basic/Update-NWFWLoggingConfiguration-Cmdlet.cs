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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Sets the logging configuration for the specified firewall. 
    /// 
    ///  
    /// <para>
    /// To change the logging configuration, retrieve the <a>LoggingConfiguration</a> by calling
    /// <a>DescribeLoggingConfiguration</a>, then change it and provide the modified object
    /// to this update call. You must change the logging configuration one <a>LogDestinationConfig</a>
    /// at a time inside the retrieved <a>LoggingConfiguration</a> object. 
    /// </para><para>
    /// You can perform only one of the following actions in any call to <c>UpdateLoggingConfiguration</c>:
    /// 
    /// </para><ul><li><para>
    /// Create a new log destination object by adding a single <c>LogDestinationConfig</c>
    /// array element to <c>LogDestinationConfigs</c>.
    /// </para></li><li><para>
    /// Delete a log destination object by removing a single <c>LogDestinationConfig</c> array
    /// element from <c>LogDestinationConfigs</c>.
    /// </para></li><li><para>
    /// Change the <c>LogDestination</c> setting in a single <c>LogDestinationConfig</c> array
    /// element.
    /// </para></li></ul><para>
    /// You can't change the <c>LogDestinationType</c> or <c>LogType</c> in a <c>LogDestinationConfig</c>.
    /// To change these settings, delete the existing <c>LogDestinationConfig</c> object and
    /// create a new one, using two separate calls to this update operation.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "NWFWLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateLoggingConfiguration API operation.", Operation = new[] {"UpdateLoggingConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateNWFWLoggingConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FirewallArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FirewallArn { get; set; }
        #endregion
        
        #region Parameter FirewallName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall. You can't change the name of a firewall after
        /// you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallName { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_LogDestinationConfig
        /// <summary>
        /// <para>
        /// <para>Defines the logging destinations for the logs for a firewall. Network Firewall generates
        /// logs for stateful rule groups. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_LogDestinationConfigs")]
        public Amazon.NetworkFirewall.Model.LogDestinationConfig[] LoggingConfiguration_LogDestinationConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWLoggingConfiguration (UpdateLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse, UpdateNWFWLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FirewallArn = this.FirewallArn;
            context.FirewallName = this.FirewallName;
            if (this.LoggingConfiguration_LogDestinationConfig != null)
            {
                context.LoggingConfiguration_LogDestinationConfig = new List<Amazon.NetworkFirewall.Model.LogDestinationConfig>(this.LoggingConfiguration_LogDestinationConfig);
            }
            
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
            var request = new Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationRequest();
            
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            if (cmdletContext.FirewallName != null)
            {
                request.FirewallName = cmdletContext.FirewallName;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.NetworkFirewall.Model.LoggingConfiguration();
            List<Amazon.NetworkFirewall.Model.LogDestinationConfig> requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig = null;
            if (cmdletContext.LoggingConfiguration_LogDestinationConfig != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig = cmdletContext.LoggingConfiguration_LogDestinationConfig;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig != null)
            {
                request.LoggingConfiguration.LogDestinationConfigs = requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
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
        
        private Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateLoggingConfiguration(request);
                #elif CORECLR
                return client.UpdateLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String FirewallArn { get; set; }
            public System.String FirewallName { get; set; }
            public List<Amazon.NetworkFirewall.Model.LogDestinationConfig> LoggingConfiguration_LogDestinationConfig { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateLoggingConfigurationResponse, UpdateNWFWLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
