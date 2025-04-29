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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Returns detailed information about command execution for an invocation or plugin.
    /// The Run Command API follows an eventual consistency model, due to the distributed
    /// nature of the system supporting the API. This means that the result of an API command
    /// you run that affects your resources might not be immediately visible to all subsequent
    /// commands you run. You should keep this in mind when you carry out an API command that
    /// immediately follows a previous API command.
    /// 
    ///  
    /// <para><c>GetCommandInvocation</c> only gives the execution status of a plugin in a document.
    /// To get the command execution status on a specific managed node, use <a>ListCommandInvocations</a>.
    /// To get the command execution status across managed nodes, use <a>ListCommands</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SSMCommandInvocationDetail")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager GetCommandInvocation API operation.", Operation = new[] {"GetCommandInvocation"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse object containing multiple properties."
    )]
    public partial class GetSSMCommandInvocationDetailCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CommandId
        /// <summary>
        /// <para>
        /// <para>(Required) The parent command ID of the invocation plugin.</para>
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
        public System.String CommandId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>(Required) The ID of the managed node targeted by the command. A <i>managed node</i>
        /// can be an Amazon Elastic Compute Cloud (Amazon EC2) instance, edge device, and on-premises
        /// server or VM in your hybrid environment that is configured for Amazon Web Services
        /// Systems Manager.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PluginName
        /// <summary>
        /// <para>
        /// <para>The name of the step for which you want detailed results. If the document contains
        /// only one step, you can omit the name and details for that step. If the document contains
        /// more than one step, you must specify the name of the step for which you want to view
        /// details. Be sure to specify the name of the step, not the name of a plugin like <c>aws:RunShellScript</c>.</para><para>To find the <c>PluginName</c>, check the document content and find the name of the
        /// step you want details for. Alternatively, use <a>ListCommandInvocations</a> with the
        /// <c>CommandId</c> and <c>Details</c> parameters. The <c>PluginName</c> is the <c>Name</c>
        /// attribute of the <c>CommandPlugin</c> object in the <c>CommandPlugins</c> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PluginName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse, GetSSMCommandInvocationDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CommandId = this.CommandId;
            #if MODULAR
            if (this.CommandId == null && ParameterWasBound(nameof(this.CommandId)))
            {
                WriteWarning("You are passing $null as a value for parameter CommandId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PluginName = this.PluginName;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetCommandInvocationRequest();
            
            if (cmdletContext.CommandId != null)
            {
                request.CommandId = cmdletContext.CommandId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.PluginName != null)
            {
                request.PluginName = cmdletContext.PluginName;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetCommandInvocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetCommandInvocation");
            try
            {
                return client.GetCommandInvocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CommandId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String PluginName { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetCommandInvocationResponse, GetSSMCommandInvocationDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
