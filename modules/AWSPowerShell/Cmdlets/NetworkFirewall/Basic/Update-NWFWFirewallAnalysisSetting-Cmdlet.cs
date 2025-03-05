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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Enables specific types of firewall analysis on a specific firewall you define.
    /// </summary>
    [Cmdlet("Update", "NWFWFirewallAnalysisSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateFirewallAnalysisSettings API operation.", Operation = new[] {"UpdateFirewallAnalysisSettings"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWFirewallAnalysisSettingCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EnabledAnalysisType
        /// <summary>
        /// <para>
        /// <para>An optional setting indicating the specific traffic analysis types to enable on the
        /// firewall. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnabledAnalysisTypes")]
        public System.String[] EnabledAnalysisType { get; set; }
        #endregion
        
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
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>An optional token that you can use for optimistic locking. Network Firewall returns
        /// a token to your requests that access the firewall. The token marks the state of the
        /// firewall resource at the time of the request. </para><para>To make an unconditional change to the firewall, omit the token in your update request.
        /// Without the token, Network Firewall performs your updates regardless of whether the
        /// firewall has changed since you last retrieved it.</para><para>To make a conditional change to the firewall, provide the token in your update request.
        /// Network Firewall uses the token to ensure that the firewall hasn't changed since you
        /// last retrieved it. If it has changed, the operation fails with an <c>InvalidTokenException</c>.
        /// If this happens, retrieve the firewall again to get a current copy of it with a new
        /// token. Reapply your changes as needed, then try the operation again using the new
        /// token. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWFirewallAnalysisSetting (UpdateFirewallAnalysisSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse, UpdateNWFWFirewallAnalysisSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.EnabledAnalysisType != null)
            {
                context.EnabledAnalysisType = new List<System.String>(this.EnabledAnalysisType);
            }
            context.FirewallArn = this.FirewallArn;
            context.FirewallName = this.FirewallName;
            context.UpdateToken = this.UpdateToken;
            
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
            var request = new Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsRequest();
            
            if (cmdletContext.EnabledAnalysisType != null)
            {
                request.EnabledAnalysisTypes = cmdletContext.EnabledAnalysisType;
            }
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            if (cmdletContext.FirewallName != null)
            {
                request.FirewallName = cmdletContext.FirewallName;
            }
            if (cmdletContext.UpdateToken != null)
            {
                request.UpdateToken = cmdletContext.UpdateToken;
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
        
        private Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateFirewallAnalysisSettings");
            try
            {
                #if DESKTOP
                return client.UpdateFirewallAnalysisSettings(request);
                #elif CORECLR
                return client.UpdateFirewallAnalysisSettingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> EnabledAnalysisType { get; set; }
            public System.String FirewallArn { get; set; }
            public System.String FirewallName { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateFirewallAnalysisSettingsResponse, UpdateNWFWFirewallAnalysisSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
