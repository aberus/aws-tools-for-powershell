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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Updates the protection status of a task. You can set <c>protectionEnabled</c> to <c>true</c>
    /// to protect your task from termination during scale-in events from <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-auto-scaling.html">Service
    /// Autoscaling</a> or <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/deployment-types.html">deployments</a>.
    /// 
    ///  
    /// <para>
    /// Task-protection, by default, expires after 2 hours at which point Amazon ECS clears
    /// the <c>protectionEnabled</c> property making the task eligible for termination by
    /// a subsequent scale-in event.
    /// </para><para>
    /// You can specify a custom expiration period for task protection from 1 minute to up
    /// to 2,880 minutes (48 hours). To specify the custom expiration period, set the <c>expiresInMinutes</c>
    /// property. The <c>expiresInMinutes</c> property is always reset when you invoke this
    /// operation for a task that already has <c>protectionEnabled</c> set to <c>true</c>.
    /// You can keep extending the protection expiration period of a task by invoking this
    /// operation repeatedly.
    /// </para><para>
    /// To learn more about Amazon ECS task protection, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-scale-in-protection.html">Task
    /// scale-in protection</a> in the <i><i>Amazon Elastic Container Service Developer Guide</i></i>.
    /// </para><note><para>
    /// This operation is only supported for tasks belonging to an Amazon ECS service. Invoking
    /// this operation for a standalone task will result in an <c>TASK_NOT_VALID</c> failure.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/api_failures_messages.html">API
    /// failure reasons</a>.
    /// </para></note><important><para>
    /// If you prefer to set task protection from within the container, we recommend using
    /// the <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-scale-in-protection-endpoint.html">Task
    /// scale-in protection endpoint</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "ECSTaskProtection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.UpdateTaskProtectionResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateTaskProtection API operation.", Operation = new[] {"UpdateTaskProtection"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateTaskProtectionResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.UpdateTaskProtectionResponse",
        "This cmdlet returns an Amazon.ECS.Model.UpdateTaskProtectionResponse object containing multiple properties."
    )]
    public partial class UpdateECSTaskProtectionCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the service
        /// that the task sets exist in.</para>
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
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ExpiresInMinute
        /// <summary>
        /// <para>
        /// <para>If you set <c>protectionEnabled</c> to <c>true</c>, you can specify the duration for
        /// task protection in minutes. You can specify a value from 1 minute to up to 2,880 minutes
        /// (48 hours). During this time, your task will not be terminated by scale-in events
        /// from Service Auto Scaling or deployments. After this time period lapses, <c>protectionEnabled</c>
        /// will be reset to <c>false</c>.</para><para>If you don’t specify the time, then the task is automatically protected for 120 minutes
        /// (2 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpiresInMinutes")]
        public System.Int32? ExpiresInMinute { get; set; }
        #endregion
        
        #region Parameter ProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to mark a task for protection and <c>false</c> to unset protection,
        /// making it eligible for termination.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter Task
        /// <summary>
        /// <para>
        /// <para>A list of up to 10 task IDs or full ARN entries.</para>
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
        [Alias("Tasks")]
        public System.String[] Task { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateTaskProtectionResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateTaskProtectionResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cluster), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSTaskProtection (UpdateTaskProtection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateTaskProtectionResponse, UpdateECSTaskProtectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cluster = this.Cluster;
            #if MODULAR
            if (this.Cluster == null && ParameterWasBound(nameof(this.Cluster)))
            {
                WriteWarning("You are passing $null as a value for parameter Cluster which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpiresInMinute = this.ExpiresInMinute;
            context.ProtectionEnabled = this.ProtectionEnabled;
            #if MODULAR
            if (this.ProtectionEnabled == null && ParameterWasBound(nameof(this.ProtectionEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter ProtectionEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Task != null)
            {
                context.Task = new List<System.String>(this.Task);
            }
            #if MODULAR
            if (this.Task == null && ParameterWasBound(nameof(this.Task)))
            {
                WriteWarning("You are passing $null as a value for parameter Task which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.UpdateTaskProtectionRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ExpiresInMinute != null)
            {
                request.ExpiresInMinutes = cmdletContext.ExpiresInMinute.Value;
            }
            if (cmdletContext.ProtectionEnabled != null)
            {
                request.ProtectionEnabled = cmdletContext.ProtectionEnabled.Value;
            }
            if (cmdletContext.Task != null)
            {
                request.Tasks = cmdletContext.Task;
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
        
        private Amazon.ECS.Model.UpdateTaskProtectionResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateTaskProtectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateTaskProtection");
            try
            {
                return client.UpdateTaskProtectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Cluster { get; set; }
            public System.Int32? ExpiresInMinute { get; set; }
            public System.Boolean? ProtectionEnabled { get; set; }
            public List<System.String> Task { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateTaskProtectionResponse, UpdateECSTaskProtectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
