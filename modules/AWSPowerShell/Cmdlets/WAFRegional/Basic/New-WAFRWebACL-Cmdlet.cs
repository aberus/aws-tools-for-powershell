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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Creates a <c>WebACL</c>, which contains the <c>Rules</c> that identify the CloudFront
    /// web requests that you want to allow, block, or count. AWS WAF evaluates <c>Rules</c>
    /// in order based on the value of <c>Priority</c> for each <c>Rule</c>.
    /// </para><para>
    /// You also specify a default action, either <c>ALLOW</c> or <c>BLOCK</c>. If a web request
    /// doesn't match any of the <c>Rules</c> in a <c>WebACL</c>, AWS WAF responds to the
    /// request with the default action. 
    /// </para><para>
    /// To create and configure a <c>WebACL</c>, perform the following steps:
    /// </para><ol><li><para>
    /// Create and update the <c>ByteMatchSet</c> objects and other predicates that you want
    /// to include in <c>Rules</c>. For more information, see <a>CreateByteMatchSet</a>, <a>UpdateByteMatchSet</a>,
    /// <a>CreateIPSet</a>, <a>UpdateIPSet</a>, <a>CreateSqlInjectionMatchSet</a>, and <a>UpdateSqlInjectionMatchSet</a>.
    /// </para></li><li><para>
    /// Create and update the <c>Rules</c> that you want to include in the <c>WebACL</c>.
    /// For more information, see <a>CreateRule</a> and <a>UpdateRule</a>.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of a <c>CreateWebACL</c> request.
    /// </para></li><li><para>
    /// Submit a <c>CreateWebACL</c> request.
    /// </para></li><li><para>
    /// Use <c>GetChangeToken</c> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of an <a>UpdateWebACL</a> request.
    /// </para></li><li><para>
    /// Submit an <a>UpdateWebACL</a> request to specify the <c>Rules</c> that you want to
    /// include in the <c>WebACL</c>, to specify the default action, and to associate the
    /// <c>WebACL</c> with a CloudFront distribution.
    /// </para></li></ol><para>
    /// For more information about how to use the AWS WAF API, see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS
    /// WAF Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFRWebACL")]
    [OutputType("Amazon.WAFRegional.Model.CreateWebACLResponse")]
    [AWSCmdlet("Calls the AWS WAF Regional CreateWebACL API operation.", Operation = new[] {"CreateWebACL"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.CreateWebACLResponse))]
    [AWSCmdletOutput("Amazon.WAFRegional.Model.CreateWebACLResponse",
        "This cmdlet returns an Amazon.WAFRegional.Model.CreateWebACLResponse object containing multiple properties."
    )]
    public partial class NewWAFRWebACLCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
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
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>A friendly name or description for the metrics for this <c>WebACL</c>.The name can
        /// contain only alphanumeric characters (A-Z, a-z, 0-9), with maximum length 128 and
        /// minimum length one. It can't contain whitespace or metric names reserved for AWS WAF,
        /// including "All" and "Default_Action." You can't change <c>MetricName</c> after you
        /// create the <c>WebACL</c>.</para>
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
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name or description of the <a>WebACL</a>. You can't change <c>Name</c>
        /// after you create the <c>WebACL</c>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WAFRegional.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DefaultAction_Type
        /// <summary>
        /// <para>
        /// <para>Specifies how you want AWS WAF to respond to requests that match the settings in a
        /// <c>Rule</c>. Valid settings include the following:</para><ul><li><para><c>ALLOW</c>: AWS WAF allows requests</para></li><li><para><c>BLOCK</c>: AWS WAF blocks requests</para></li><li><para><c>COUNT</c>: AWS WAF increments a counter of the requests that match all of the
        /// conditions in the rule. AWS WAF then continues to inspect the web request based on
        /// the remaining rules in the web ACL. You can't specify <c>COUNT</c> for the default
        /// action for a <c>WebACL</c>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFRegional.WafActionType")]
        public Amazon.WAFRegional.WafActionType DefaultAction_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.CreateWebACLResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.CreateWebACLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.CreateWebACLResponse, NewWAFRWebACLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultAction_Type = this.DefaultAction_Type;
            #if MODULAR
            if (this.DefaultAction_Type == null && ParameterWasBound(nameof(this.DefaultAction_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultAction_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WAFRegional.Model.Tag>(this.Tag);
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
            var request = new Amazon.WAFRegional.Model.CreateWebACLRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            
             // populate DefaultAction
            var requestDefaultActionIsNull = true;
            request.DefaultAction = new Amazon.WAFRegional.Model.WafAction();
            Amazon.WAFRegional.WafActionType requestDefaultAction_defaultAction_Type = null;
            if (cmdletContext.DefaultAction_Type != null)
            {
                requestDefaultAction_defaultAction_Type = cmdletContext.DefaultAction_Type;
            }
            if (requestDefaultAction_defaultAction_Type != null)
            {
                request.DefaultAction.Type = requestDefaultAction_defaultAction_Type;
                requestDefaultActionIsNull = false;
            }
             // determine if request.DefaultAction should be set to null
            if (requestDefaultActionIsNull)
            {
                request.DefaultAction = null;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.WAFRegional.Model.CreateWebACLResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.CreateWebACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "CreateWebACL");
            try
            {
                #if DESKTOP
                return client.CreateWebACL(request);
                #elif CORECLR
                return client.CreateWebACLAsync(request).GetAwaiter().GetResult();
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
            public System.String ChangeToken { get; set; }
            public Amazon.WAFRegional.WafActionType DefaultAction_Type { get; set; }
            public System.String MetricName { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.WAFRegional.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WAFRegional.Model.CreateWebACLResponse, NewWAFRWebACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
