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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Completes the lifecycle action for the specified token or instance with the specified
    /// result.
    /// 
    ///  
    /// <para>
    /// This step is a part of the procedure for adding a lifecycle hook to an Auto Scaling
    /// group:
    /// </para><ol><li><para>
    /// (Optional) Create a launch template or launch configuration with a user data script
    /// that runs while an instance is in a wait state due to a lifecycle hook.
    /// </para></li><li><para>
    /// (Optional) Create a Lambda function and a rule that allows Amazon EventBridge to invoke
    /// your Lambda function when an instance is put into a wait state due to a lifecycle
    /// hook.
    /// </para></li><li><para>
    /// (Optional) Create a notification target and an IAM role. The target can be either
    /// an Amazon SQS queue or an Amazon SNS topic. The role allows Amazon EC2 Auto Scaling
    /// to publish lifecycle notifications to the target.
    /// </para></li><li><para>
    /// Create the lifecycle hook. Specify whether the hook is used when the instances launch
    /// or terminate.
    /// </para></li><li><para>
    /// If you need more time, record the lifecycle action heartbeat to keep the instance
    /// in a wait state.
    /// </para></li><li><para><b>If you finish before the timeout period ends, send a callback by using the <a>CompleteLifecycleAction</a>
    /// API call.</b></para></li></ol><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/completing-lifecycle-hooks.html">Complete
    /// a lifecycle action</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Complete", "ASLifecycleAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling CompleteLifecycleAction API operation.", Operation = new[] {"CompleteLifecycleAction"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.CompleteLifecycleActionResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.CompleteLifecycleActionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.CompleteLifecycleActionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CompleteASLifecycleActionCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LifecycleActionResult
        /// <summary>
        /// <para>
        /// <para>The action for the group to take. You can specify either <c>CONTINUE</c> or <c>ABANDON</c>.</para>
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
        public System.String LifecycleActionResult { get; set; }
        #endregion
        
        #region Parameter LifecycleActionToken
        /// <summary>
        /// <para>
        /// <para>A universally unique identifier (UUID) that identifies a specific lifecycle action
        /// associated with an instance. Amazon EC2 Auto Scaling sends this token to the notification
        /// target you specified when you created the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LifecycleActionToken { get; set; }
        #endregion
        
        #region Parameter LifecycleHookName
        /// <summary>
        /// <para>
        /// <para>The name of the lifecycle hook.</para>
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
        public System.String LifecycleHookName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.CompleteLifecycleActionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-ASLifecycleAction (CompleteLifecycleAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.CompleteLifecycleActionResponse, CompleteASLifecycleActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            context.LifecycleActionResult = this.LifecycleActionResult;
            #if MODULAR
            if (this.LifecycleActionResult == null && ParameterWasBound(nameof(this.LifecycleActionResult)))
            {
                WriteWarning("You are passing $null as a value for parameter LifecycleActionResult which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LifecycleActionToken = this.LifecycleActionToken;
            context.LifecycleHookName = this.LifecycleHookName;
            #if MODULAR
            if (this.LifecycleHookName == null && ParameterWasBound(nameof(this.LifecycleHookName)))
            {
                WriteWarning("You are passing $null as a value for parameter LifecycleHookName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AutoScaling.Model.CompleteLifecycleActionRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.LifecycleActionResult != null)
            {
                request.LifecycleActionResult = cmdletContext.LifecycleActionResult;
            }
            if (cmdletContext.LifecycleActionToken != null)
            {
                request.LifecycleActionToken = cmdletContext.LifecycleActionToken;
            }
            if (cmdletContext.LifecycleHookName != null)
            {
                request.LifecycleHookName = cmdletContext.LifecycleHookName;
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
        
        private Amazon.AutoScaling.Model.CompleteLifecycleActionResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.CompleteLifecycleActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "CompleteLifecycleAction");
            try
            {
                #if DESKTOP
                return client.CompleteLifecycleAction(request);
                #elif CORECLR
                return client.CompleteLifecycleActionAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupName { get; set; }
            public System.String InstanceId { get; set; }
            public System.String LifecycleActionResult { get; set; }
            public System.String LifecycleActionToken { get; set; }
            public System.String LifecycleHookName { get; set; }
            public System.Func<Amazon.AutoScaling.Model.CompleteLifecycleActionResponse, CompleteASLifecycleActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
