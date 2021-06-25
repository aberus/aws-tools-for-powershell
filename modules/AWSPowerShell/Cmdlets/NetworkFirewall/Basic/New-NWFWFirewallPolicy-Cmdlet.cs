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
    /// Creates the firewall policy for the firewall according to the specifications. 
    /// 
    ///  
    /// <para>
    /// An AWS Network Firewall firewall policy defines the behavior of a firewall, in a collection
    /// of stateless and stateful rule groups and other settings. You can use one firewall
    /// policy for multiple firewalls. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "NWFWFirewallPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateFirewallPolicy API operation.", Operation = new[] {"CreateFirewallPolicy"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewNWFWFirewallPolicyCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the firewall policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want Network Firewall to just check the validity of the request,
        /// rather than run the request. </para><para>If set to <code>TRUE</code>, Network Firewall checks whether the request can run successfully,
        /// but doesn't actually make the requested changes. The call returns the value that the
        /// request would return if you ran it with dry run set to <code>FALSE</code>, but doesn't
        /// make additions or changes to your resources. This option allows you to make sure that
        /// you have the required permissions to run the request and that your request parameters
        /// are valid. </para><para>If set to <code>FALSE</code>, Network Firewall makes the requested changes to your
        /// resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall policy. You can't change the name of a firewall
        /// policy after you create it.</para>
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
        public System.String FirewallPolicyName { get; set; }
        #endregion
        
        #region Parameter StatefulEngineOptions_RuleOrder
        /// <summary>
        /// <para>
        /// <para>Indicates how to manage the order of stateful rule evaluation for the policy. By default,
        /// Network Firewall leaves the rule evaluation order up to the Suricata rule processing
        /// engine. If you set this to <code>STRICT_ORDER</code>, your rules are evaluated in
        /// the exact order that you provide them in the policy. With strict ordering, the rule
        /// groups are evaluated by order of priority, starting from the lowest number, and the
        /// rules in each rule group are processed in the order that they're defined. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulEngineOptions_RuleOrder")]
        [AWSConstantClassSource("Amazon.NetworkFirewall.RuleOrder")]
        public Amazon.NetworkFirewall.RuleOrder StatefulEngineOptions_RuleOrder { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatefulDefaultAction
        /// <summary>
        /// <para>
        /// <para>The default actions to take on a packet that doesn't match any stateful rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulDefaultActions")]
        public System.String[] FirewallPolicy_StatefulDefaultAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatefulRuleGroupReference
        /// <summary>
        /// <para>
        /// <para>References to the stateful rule groups that are used in the policy. These define the
        /// inspection criteria in stateful rules. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulRuleGroupReferences")]
        public Amazon.NetworkFirewall.Model.StatefulRuleGroupReference[] FirewallPolicy_StatefulRuleGroupReference { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessCustomAction
        /// <summary>
        /// <para>
        /// <para>The custom action definitions that are available for use in the firewall policy's
        /// <code>StatelessDefaultActions</code> setting. You name each custom action that you
        /// define, and then you can use it by name in your default actions specifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatelessCustomActions")]
        public Amazon.NetworkFirewall.Model.CustomAction[] FirewallPolicy_StatelessCustomAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessDefaultAction
        /// <summary>
        /// <para>
        /// <para>The actions to take on a packet if it doesn't match any of the stateless rules in
        /// the policy. If you want non-matching packets to be forwarded for stateful inspection,
        /// specify <code>aws:forward_to_sfe</code>. </para><para>You must specify one of the standard actions: <code>aws:pass</code>, <code>aws:drop</code>,
        /// or <code>aws:forward_to_sfe</code>. In addition, you can specify custom actions that
        /// are compatible with your standard section choice.</para><para>For example, you could specify <code>["aws:pass"]</code> or you could specify <code>["aws:pass",
        /// “customActionName”]</code>. For information about compatibility, see the custom action
        /// descriptions under <a>CustomAction</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FirewallPolicy_StatelessDefaultActions")]
        public System.String[] FirewallPolicy_StatelessDefaultAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessFragmentDefaultAction
        /// <summary>
        /// <para>
        /// <para>The actions to take on a fragmented UDP packet if it doesn't match any of the stateless
        /// rules in the policy. Network Firewall only manages UDP packet fragments and silently
        /// drops packet fragments for other protocols. If you want non-matching fragmented UDP
        /// packets to be forwarded for stateful inspection, specify <code>aws:forward_to_sfe</code>.
        /// </para><para>You must specify one of the standard actions: <code>aws:pass</code>, <code>aws:drop</code>,
        /// or <code>aws:forward_to_sfe</code>. In addition, you can specify custom actions that
        /// are compatible with your standard section choice.</para><para>For example, you could specify <code>["aws:pass"]</code> or you could specify <code>["aws:pass",
        /// “customActionName”]</code>. For information about compatibility, see the custom action
        /// descriptions under <a>CustomAction</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FirewallPolicy_StatelessFragmentDefaultActions")]
        public System.String[] FirewallPolicy_StatelessFragmentDefaultAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessRuleGroupReference
        /// <summary>
        /// <para>
        /// <para>References to the stateless rule groups that are used in the policy. These define
        /// the matching criteria in stateless rules. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatelessRuleGroupReferences")]
        public Amazon.NetworkFirewall.Model.StatelessRuleGroupReference[] FirewallPolicy_StatelessRuleGroupReference { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key:value pairs to associate with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkFirewall.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallPolicyName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallPolicyName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallPolicyName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallPolicyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWFirewallPolicy (CreateFirewallPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse, NewNWFWFirewallPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallPolicyName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            if (this.FirewallPolicy_StatefulDefaultAction != null)
            {
                context.FirewallPolicy_StatefulDefaultAction = new List<System.String>(this.FirewallPolicy_StatefulDefaultAction);
            }
            context.StatefulEngineOptions_RuleOrder = this.StatefulEngineOptions_RuleOrder;
            if (this.FirewallPolicy_StatefulRuleGroupReference != null)
            {
                context.FirewallPolicy_StatefulRuleGroupReference = new List<Amazon.NetworkFirewall.Model.StatefulRuleGroupReference>(this.FirewallPolicy_StatefulRuleGroupReference);
            }
            if (this.FirewallPolicy_StatelessCustomAction != null)
            {
                context.FirewallPolicy_StatelessCustomAction = new List<Amazon.NetworkFirewall.Model.CustomAction>(this.FirewallPolicy_StatelessCustomAction);
            }
            if (this.FirewallPolicy_StatelessDefaultAction != null)
            {
                context.FirewallPolicy_StatelessDefaultAction = new List<System.String>(this.FirewallPolicy_StatelessDefaultAction);
            }
            #if MODULAR
            if (this.FirewallPolicy_StatelessDefaultAction == null && ParameterWasBound(nameof(this.FirewallPolicy_StatelessDefaultAction)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallPolicy_StatelessDefaultAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FirewallPolicy_StatelessFragmentDefaultAction != null)
            {
                context.FirewallPolicy_StatelessFragmentDefaultAction = new List<System.String>(this.FirewallPolicy_StatelessFragmentDefaultAction);
            }
            #if MODULAR
            if (this.FirewallPolicy_StatelessFragmentDefaultAction == null && ParameterWasBound(nameof(this.FirewallPolicy_StatelessFragmentDefaultAction)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallPolicy_StatelessFragmentDefaultAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FirewallPolicy_StatelessRuleGroupReference != null)
            {
                context.FirewallPolicy_StatelessRuleGroupReference = new List<Amazon.NetworkFirewall.Model.StatelessRuleGroupReference>(this.FirewallPolicy_StatelessRuleGroupReference);
            }
            context.FirewallPolicyName = this.FirewallPolicyName;
            #if MODULAR
            if (this.FirewallPolicyName == null && ParameterWasBound(nameof(this.FirewallPolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallPolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkFirewall.Model.Tag>(this.Tag);
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
            var request = new Amazon.NetworkFirewall.Model.CreateFirewallPolicyRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate FirewallPolicy
            var requestFirewallPolicyIsNull = true;
            request.FirewallPolicy = new Amazon.NetworkFirewall.Model.FirewallPolicy();
            List<System.String> requestFirewallPolicy_firewallPolicy_StatefulDefaultAction = null;
            if (cmdletContext.FirewallPolicy_StatefulDefaultAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulDefaultAction = cmdletContext.FirewallPolicy_StatefulDefaultAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulDefaultAction != null)
            {
                request.FirewallPolicy.StatefulDefaultActions = requestFirewallPolicy_firewallPolicy_StatefulDefaultAction;
                requestFirewallPolicyIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.StatefulRuleGroupReference> requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference = null;
            if (cmdletContext.FirewallPolicy_StatefulRuleGroupReference != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference = cmdletContext.FirewallPolicy_StatefulRuleGroupReference;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference != null)
            {
                request.FirewallPolicy.StatefulRuleGroupReferences = requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference;
                requestFirewallPolicyIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.CustomAction> requestFirewallPolicy_firewallPolicy_StatelessCustomAction = null;
            if (cmdletContext.FirewallPolicy_StatelessCustomAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessCustomAction = cmdletContext.FirewallPolicy_StatelessCustomAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessCustomAction != null)
            {
                request.FirewallPolicy.StatelessCustomActions = requestFirewallPolicy_firewallPolicy_StatelessCustomAction;
                requestFirewallPolicyIsNull = false;
            }
            List<System.String> requestFirewallPolicy_firewallPolicy_StatelessDefaultAction = null;
            if (cmdletContext.FirewallPolicy_StatelessDefaultAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessDefaultAction = cmdletContext.FirewallPolicy_StatelessDefaultAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessDefaultAction != null)
            {
                request.FirewallPolicy.StatelessDefaultActions = requestFirewallPolicy_firewallPolicy_StatelessDefaultAction;
                requestFirewallPolicyIsNull = false;
            }
            List<System.String> requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction = null;
            if (cmdletContext.FirewallPolicy_StatelessFragmentDefaultAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction = cmdletContext.FirewallPolicy_StatelessFragmentDefaultAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction != null)
            {
                request.FirewallPolicy.StatelessFragmentDefaultActions = requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction;
                requestFirewallPolicyIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.StatelessRuleGroupReference> requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference = null;
            if (cmdletContext.FirewallPolicy_StatelessRuleGroupReference != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference = cmdletContext.FirewallPolicy_StatelessRuleGroupReference;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference != null)
            {
                request.FirewallPolicy.StatelessRuleGroupReferences = requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference;
                requestFirewallPolicyIsNull = false;
            }
            Amazon.NetworkFirewall.Model.StatefulEngineOptions requestFirewallPolicy_firewallPolicy_StatefulEngineOptions = null;
            
             // populate StatefulEngineOptions
            var requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull = true;
            requestFirewallPolicy_firewallPolicy_StatefulEngineOptions = new Amazon.NetworkFirewall.Model.StatefulEngineOptions();
            Amazon.NetworkFirewall.RuleOrder requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder = null;
            if (cmdletContext.StatefulEngineOptions_RuleOrder != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder = cmdletContext.StatefulEngineOptions_RuleOrder;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions.RuleOrder = requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder;
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull = false;
            }
             // determine if requestFirewallPolicy_firewallPolicy_StatefulEngineOptions should be set to null
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions = null;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions != null)
            {
                request.FirewallPolicy.StatefulEngineOptions = requestFirewallPolicy_firewallPolicy_StatefulEngineOptions;
                requestFirewallPolicyIsNull = false;
            }
             // determine if request.FirewallPolicy should be set to null
            if (requestFirewallPolicyIsNull)
            {
                request.FirewallPolicy = null;
            }
            if (cmdletContext.FirewallPolicyName != null)
            {
                request.FirewallPolicyName = cmdletContext.FirewallPolicyName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateFirewallPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateFirewallPolicy");
            try
            {
                #if DESKTOP
                return client.CreateFirewallPolicy(request);
                #elif CORECLR
                return client.CreateFirewallPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public List<System.String> FirewallPolicy_StatefulDefaultAction { get; set; }
            public Amazon.NetworkFirewall.RuleOrder StatefulEngineOptions_RuleOrder { get; set; }
            public List<Amazon.NetworkFirewall.Model.StatefulRuleGroupReference> FirewallPolicy_StatefulRuleGroupReference { get; set; }
            public List<Amazon.NetworkFirewall.Model.CustomAction> FirewallPolicy_StatelessCustomAction { get; set; }
            public List<System.String> FirewallPolicy_StatelessDefaultAction { get; set; }
            public List<System.String> FirewallPolicy_StatelessFragmentDefaultAction { get; set; }
            public List<Amazon.NetworkFirewall.Model.StatelessRuleGroupReference> FirewallPolicy_StatelessRuleGroupReference { get; set; }
            public System.String FirewallPolicyName { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateFirewallPolicyResponse, NewNWFWFirewallPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
