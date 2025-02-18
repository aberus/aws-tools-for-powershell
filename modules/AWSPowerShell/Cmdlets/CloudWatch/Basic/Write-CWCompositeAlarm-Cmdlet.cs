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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates or updates a <i>composite alarm</i>. When you create a composite alarm, you
    /// specify a rule expression for the alarm that takes into account the alarm states of
    /// other alarms that you have created. The composite alarm goes into ALARM state only
    /// if all conditions of the rule are met.
    /// 
    ///  
    /// <para>
    /// The alarms specified in a composite alarm's rule expression can include metric alarms
    /// and other composite alarms. The rule expression of a composite alarm can include as
    /// many as 100 underlying alarms. Any single alarm can be included in the rule expressions
    /// of as many as 150 composite alarms.
    /// </para><para>
    /// Using composite alarms can reduce alarm noise. You can create multiple metric alarms,
    /// and also create a composite alarm and set up alerts only for the composite alarm.
    /// For example, you could create a composite alarm that goes into ALARM state only when
    /// more than one of the underlying metric alarms are in ALARM state.
    /// </para><para>
    /// Composite alarms can take the following actions:
    /// </para><ul><li><para>
    /// Notify Amazon SNS topics.
    /// </para></li><li><para>
    /// Invoke Lambda functions.
    /// </para></li><li><para>
    /// Create OpsItems in Systems Manager Ops Center.
    /// </para></li><li><para>
    /// Create incidents in Systems Manager Incident Manager.
    /// </para></li></ul><note><para>
    /// It is possible to create a loop or cycle of composite alarms, where composite alarm
    /// A depends on composite alarm B, and composite alarm B also depends on composite alarm
    /// A. In this scenario, you can't delete any composite alarm that is part of the cycle
    /// because there is always still a composite alarm that depends on that alarm that you
    /// want to delete.
    /// </para><para>
    /// To get out of such a situation, you must break the cycle by changing the rule of one
    /// of the composite alarms in the cycle to remove a dependency that creates the cycle.
    /// The simplest change to make to break a cycle is to change the <c>AlarmRule</c> of
    /// one of the alarms to <c>false</c>. 
    /// </para><para>
    /// Additionally, the evaluation of composite alarms stops if CloudWatch detects a cycle
    /// in the evaluation path. 
    /// </para></note><para>
    /// When this operation creates an alarm, the alarm state is immediately set to <c>INSUFFICIENT_DATA</c>.
    /// The alarm is then evaluated and its state is set appropriately. Any actions associated
    /// with the new state are then executed. For a composite alarm, this initial time after
    /// creation is the only time that the alarm can be in <c>INSUFFICIENT_DATA</c> state.
    /// </para><para>
    /// When you update an existing alarm, its state is left unchanged, but the update completely
    /// overwrites the previous configuration of the alarm.
    /// </para><para>
    /// To use this operation, you must be signed on with the <c>cloudwatch:PutCompositeAlarm</c>
    /// permission that is scoped to <c>*</c>. You can't create a composite alarms if your
    /// <c>cloudwatch:PutCompositeAlarm</c> permission has a narrower scope.
    /// </para><para>
    /// If you are an IAM user, you must have <c>iam:CreateServiceLinkedRole</c> to create
    /// a composite alarm that has Systems Manager OpsItem actions.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWCompositeAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutCompositeAlarm API operation.", Operation = new[] {"PutCompositeAlarm"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutCompositeAlarmResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.PutCompositeAlarmResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.PutCompositeAlarmResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWCompositeAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether actions should be executed during any changes to the alarm state
        /// of the composite alarm. The default is <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ActionsEnabled { get; set; }
        #endregion
        
        #region Parameter ActionsSuppressor
        /// <summary>
        /// <para>
        /// <para> Actions will be suppressed if the suppressor alarm is in the <c>ALARM</c> state.
        /// <c>ActionsSuppressor</c> can be an AlarmName or an Amazon Resource Name (ARN) from
        /// an existing alarm. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionsSuppressor { get; set; }
        #endregion
        
        #region Parameter ActionsSuppressorExtensionPeriod
        /// <summary>
        /// <para>
        /// <para> The maximum time in seconds that the composite alarm waits after suppressor alarm
        /// goes out of the <c>ALARM</c> state. After this time, the composite alarm performs
        /// its actions. </para><important><para><c>ExtensionPeriod</c> is required only when <c>ActionsSuppressor</c> is specified.
        /// </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ActionsSuppressorExtensionPeriod { get; set; }
        #endregion
        
        #region Parameter ActionsSuppressorWaitPeriod
        /// <summary>
        /// <para>
        /// <para> The maximum time in seconds that the composite alarm waits for the suppressor alarm
        /// to go into the <c>ALARM</c> state. After this time, the composite alarm performs its
        /// actions. </para><important><para><c>WaitPeriod</c> is required only when <c>ActionsSuppressor</c> is specified. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ActionsSuppressorWaitPeriod { get; set; }
        #endregion
        
        #region Parameter AlarmAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <c>ALARM</c> state from
        /// any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: ]</para><para><b>Amazon SNS actions:</b></para><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul><para><b>Systems Manager actions:</b></para><para><c>arn:aws:ssm:<i>region</i>:<i>account-id</i>:opsitem:<i>severity</i></c></para><para><b>Start a Amazon Q Developer operational investigation</b></para><para><c>arn:aws:aiops:<i>region</i>:<i>account-id</i>:investigation-group:<i>ingestigation-group-id</i></c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmActions")]
        public System.String[] AlarmAction { get; set; }
        #endregion
        
        #region Parameter AlarmDescription
        /// <summary>
        /// <para>
        /// <para>The description for the composite alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlarmDescription { get; set; }
        #endregion
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name for the composite alarm. This name must be unique within the Region.</para>
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
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter AlarmRule
        /// <summary>
        /// <para>
        /// <para>An expression that specifies which other alarms are to be evaluated to determine this
        /// composite alarm's state. For each alarm that you reference, you designate a function
        /// that specifies whether that alarm needs to be in ALARM state, OK state, or INSUFFICIENT_DATA
        /// state. You can use operators (AND, OR and NOT) to combine multiple functions in a
        /// single expression. You can use parenthesis to logically group the functions in your
        /// expression.</para><para>You can use either alarm names or ARNs to reference the other alarms that are to be
        /// evaluated.</para><para>Functions can include the following:</para><ul><li><para><c>ALARM("<i>alarm-name</i> or <i>alarm-ARN</i>")</c> is TRUE if the named alarm
        /// is in ALARM state.</para></li><li><para><c>OK("<i>alarm-name</i> or <i>alarm-ARN</i>")</c> is TRUE if the named alarm is
        /// in OK state.</para></li><li><para><c>INSUFFICIENT_DATA("<i>alarm-name</i> or <i>alarm-ARN</i>")</c> is TRUE if the
        /// named alarm is in INSUFFICIENT_DATA state.</para></li><li><para><c>TRUE</c> always evaluates to TRUE.</para></li><li><para><c>FALSE</c> always evaluates to FALSE.</para></li></ul><para>TRUE and FALSE are useful for testing a complex <c>AlarmRule</c> structure, and for
        /// testing your alarm actions.</para><para>Alarm names specified in <c>AlarmRule</c> can be surrounded with double-quotes ("),
        /// but do not have to be.</para><para>The following are some examples of <c>AlarmRule</c>:</para><ul><li><para><c>ALARM(CPUUtilizationTooHigh) AND ALARM(DiskReadOpsTooHigh)</c> specifies that
        /// the composite alarm goes into ALARM state only if both CPUUtilizationTooHigh and DiskReadOpsTooHigh
        /// alarms are in ALARM state.</para></li><li><para><c>ALARM(CPUUtilizationTooHigh) AND NOT ALARM(DeploymentInProgress)</c> specifies
        /// that the alarm goes to ALARM state if CPUUtilizationTooHigh is in ALARM state and
        /// DeploymentInProgress is not in ALARM state. This example reduces alarm noise during
        /// a known deployment window.</para></li><li><para><c>(ALARM(CPUUtilizationTooHigh) OR ALARM(DiskReadOpsTooHigh)) AND OK(NetworkOutTooHigh)</c>
        /// goes into ALARM state if CPUUtilizationTooHigh OR DiskReadOpsTooHigh is in ALARM state,
        /// and if NetworkOutTooHigh is in OK state. This provides another example of using a
        /// composite alarm to prevent noise. This rule ensures that you are not notified with
        /// an alarm action on high CPU or disk usage if a known network problem is also occurring.</para></li></ul><para>The <c>AlarmRule</c> can specify as many as 100 "children" alarms. The <c>AlarmRule</c>
        /// expression can have as many as 500 elements. Elements are child alarms, TRUE or FALSE
        /// statements, and parentheses.</para>
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
        public System.String AlarmRule { get; set; }
        #endregion
        
        #region Parameter InsufficientDataAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <c>INSUFFICIENT_DATA</c>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: ]</para><para><b>Amazon SNS actions:</b></para><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InsufficientDataActions")]
        public System.String[] InsufficientDataAction { get; set; }
        #endregion
        
        #region Parameter OKAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to an <c>OK</c> state from any
        /// other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: ]</para><para><b>Amazon SNS actions:</b></para><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OKActions")]
        public System.String[] OKAction { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the alarm. You can associate as many as
        /// 50 tags with an alarm. To be able to associate tags with the alarm when you create
        /// the alarm, you must have the <c>cloudwatch:TagResource</c> permission.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>If you are using this operation to update an existing alarm, any tags you specify
        /// in this parameter are ignored. To change the tags of an existing alarm, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_TagResource.html">TagResource</a>
        /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_UntagResource.html">UntagResource</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudWatch.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutCompositeAlarmResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AlarmName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWCompositeAlarm (PutCompositeAlarm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutCompositeAlarmResponse, WriteCWCompositeAlarmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionsEnabled = this.ActionsEnabled;
            context.ActionsSuppressor = this.ActionsSuppressor;
            context.ActionsSuppressorExtensionPeriod = this.ActionsSuppressorExtensionPeriod;
            context.ActionsSuppressorWaitPeriod = this.ActionsSuppressorWaitPeriod;
            if (this.AlarmAction != null)
            {
                context.AlarmAction = new List<System.String>(this.AlarmAction);
            }
            context.AlarmDescription = this.AlarmDescription;
            context.AlarmName = this.AlarmName;
            #if MODULAR
            if (this.AlarmName == null && ParameterWasBound(nameof(this.AlarmName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlarmName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AlarmRule = this.AlarmRule;
            #if MODULAR
            if (this.AlarmRule == null && ParameterWasBound(nameof(this.AlarmRule)))
            {
                WriteWarning("You are passing $null as a value for parameter AlarmRule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InsufficientDataAction != null)
            {
                context.InsufficientDataAction = new List<System.String>(this.InsufficientDataAction);
            }
            if (this.OKAction != null)
            {
                context.OKAction = new List<System.String>(this.OKAction);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudWatch.Model.Tag>(this.Tag);
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
            var request = new Amazon.CloudWatch.Model.PutCompositeAlarmRequest();
            
            if (cmdletContext.ActionsEnabled != null)
            {
                request.ActionsEnabled = cmdletContext.ActionsEnabled.Value;
            }
            if (cmdletContext.ActionsSuppressor != null)
            {
                request.ActionsSuppressor = cmdletContext.ActionsSuppressor;
            }
            if (cmdletContext.ActionsSuppressorExtensionPeriod != null)
            {
                request.ActionsSuppressorExtensionPeriod = cmdletContext.ActionsSuppressorExtensionPeriod.Value;
            }
            if (cmdletContext.ActionsSuppressorWaitPeriod != null)
            {
                request.ActionsSuppressorWaitPeriod = cmdletContext.ActionsSuppressorWaitPeriod.Value;
            }
            if (cmdletContext.AlarmAction != null)
            {
                request.AlarmActions = cmdletContext.AlarmAction;
            }
            if (cmdletContext.AlarmDescription != null)
            {
                request.AlarmDescription = cmdletContext.AlarmDescription;
            }
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmName = cmdletContext.AlarmName;
            }
            if (cmdletContext.AlarmRule != null)
            {
                request.AlarmRule = cmdletContext.AlarmRule;
            }
            if (cmdletContext.InsufficientDataAction != null)
            {
                request.InsufficientDataActions = cmdletContext.InsufficientDataAction;
            }
            if (cmdletContext.OKAction != null)
            {
                request.OKActions = cmdletContext.OKAction;
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
        
        private Amazon.CloudWatch.Model.PutCompositeAlarmResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutCompositeAlarmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutCompositeAlarm");
            try
            {
                return client.PutCompositeAlarmAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ActionsEnabled { get; set; }
            public System.String ActionsSuppressor { get; set; }
            public System.Int32? ActionsSuppressorExtensionPeriod { get; set; }
            public System.Int32? ActionsSuppressorWaitPeriod { get; set; }
            public List<System.String> AlarmAction { get; set; }
            public System.String AlarmDescription { get; set; }
            public System.String AlarmName { get; set; }
            public System.String AlarmRule { get; set; }
            public List<System.String> InsufficientDataAction { get; set; }
            public List<System.String> OKAction { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutCompositeAlarmResponse, WriteCWCompositeAlarmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
