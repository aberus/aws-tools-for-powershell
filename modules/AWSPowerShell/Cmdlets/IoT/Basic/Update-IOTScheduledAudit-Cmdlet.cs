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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a scheduled audit, including which checks are performed and how often the
    /// audit takes place.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateScheduledAudit</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTScheduledAudit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT UpdateScheduledAudit API operation.", Operation = new[] {"UpdateScheduledAudit"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateScheduledAuditResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoT.Model.UpdateScheduledAuditResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoT.Model.UpdateScheduledAuditResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTScheduledAuditCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DayOfMonth
        /// <summary>
        /// <para>
        /// <para>The day of the month on which the scheduled audit takes place. This can be <c>1</c>
        /// through <c>31</c> or <c>LAST</c>. This field is required if the <c>frequency</c> parameter
        /// is set to <c>MONTHLY</c>. If days 29-31 are specified, and the month does not have
        /// that many days, the audit takes place on the "LAST" day of the month.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DayOfMonth { get; set; }
        #endregion
        
        #region Parameter DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The day of the week on which the scheduled audit takes place. This can be one of <c>SUN</c>,
        /// <c>MON</c>, <c>TUE</c>, <c>WED</c>, <c>THU</c>, <c>FRI</c>, or <c>SAT</c>. This field
        /// is required if the "frequency" parameter is set to <c>WEEKLY</c> or <c>BIWEEKLY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.DayOfWeek")]
        public Amazon.IoT.DayOfWeek DayOfWeek { get; set; }
        #endregion
        
        #region Parameter Frequency
        /// <summary>
        /// <para>
        /// <para>How often the scheduled audit takes place, either <c>DAILY</c>, <c>WEEKLY</c>, <c>BIWEEKLY</c>,
        /// or <c>MONTHLY</c>. The start time of each audit is determined by the system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.AuditFrequency")]
        public Amazon.IoT.AuditFrequency Frequency { get; set; }
        #endregion
        
        #region Parameter ScheduledAuditName
        /// <summary>
        /// <para>
        /// <para>The name of the scheduled audit. (Max. 128 chars)</para>
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
        public System.String ScheduledAuditName { get; set; }
        #endregion
        
        #region Parameter TargetCheckName
        /// <summary>
        /// <para>
        /// <para>Which checks are performed during the scheduled audit. Checks must be enabled for
        /// your account. (Use <c>DescribeAccountAuditConfiguration</c> to see the list of all
        /// checks, including those that are enabled or use <c>UpdateAccountAuditConfiguration</c>
        /// to select which checks are enabled.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetCheckNames")]
        public System.String[] TargetCheckName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScheduledAuditArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateScheduledAuditResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateScheduledAuditResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScheduledAuditArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduledAuditName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTScheduledAudit (UpdateScheduledAudit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateScheduledAuditResponse, UpdateIOTScheduledAuditCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DayOfMonth = this.DayOfMonth;
            context.DayOfWeek = this.DayOfWeek;
            context.Frequency = this.Frequency;
            context.ScheduledAuditName = this.ScheduledAuditName;
            #if MODULAR
            if (this.ScheduledAuditName == null && ParameterWasBound(nameof(this.ScheduledAuditName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledAuditName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetCheckName != null)
            {
                context.TargetCheckName = new List<System.String>(this.TargetCheckName);
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
            var request = new Amazon.IoT.Model.UpdateScheduledAuditRequest();
            
            if (cmdletContext.DayOfMonth != null)
            {
                request.DayOfMonth = cmdletContext.DayOfMonth;
            }
            if (cmdletContext.DayOfWeek != null)
            {
                request.DayOfWeek = cmdletContext.DayOfWeek;
            }
            if (cmdletContext.Frequency != null)
            {
                request.Frequency = cmdletContext.Frequency;
            }
            if (cmdletContext.ScheduledAuditName != null)
            {
                request.ScheduledAuditName = cmdletContext.ScheduledAuditName;
            }
            if (cmdletContext.TargetCheckName != null)
            {
                request.TargetCheckNames = cmdletContext.TargetCheckName;
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
        
        private Amazon.IoT.Model.UpdateScheduledAuditResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateScheduledAuditRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateScheduledAudit");
            try
            {
                #if DESKTOP
                return client.UpdateScheduledAudit(request);
                #elif CORECLR
                return client.UpdateScheduledAuditAsync(request).GetAwaiter().GetResult();
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
            public System.String DayOfMonth { get; set; }
            public Amazon.IoT.DayOfWeek DayOfWeek { get; set; }
            public Amazon.IoT.AuditFrequency Frequency { get; set; }
            public System.String ScheduledAuditName { get; set; }
            public List<System.String> TargetCheckName { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateScheduledAuditResponse, UpdateIOTScheduledAuditCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScheduledAuditArn;
        }
        
    }
}
