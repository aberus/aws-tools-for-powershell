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
    /// Retrieves the details of a maintenance window task.
    /// 
    ///  <note><para>
    /// For maintenance window tasks without a specified target, you can't supply values for
    /// <c>--max-errors</c> and <c>--max-concurrency</c>. Instead, the system inserts a placeholder
    /// value of <c>1</c>, which may be reported in the response to this command. These values
    /// don't affect the running of your task and can be ignored.
    /// </para></note><para>
    /// To retrieve a list of tasks in a maintenance window, instead use the <a>DescribeMaintenanceWindowTasks</a>
    /// command.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SSMMaintenanceWindowTask")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager GetMaintenanceWindowTask API operation.", Operation = new[] {"GetMaintenanceWindowTask"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse object containing multiple properties."
    )]
    public partial class GetSSMMaintenanceWindowTaskCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WindowId
        /// <summary>
        /// <para>
        /// <para>The maintenance window ID that includes the task to retrieve.</para>
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
        public System.String WindowId { get; set; }
        #endregion
        
        #region Parameter WindowTaskId
        /// <summary>
        /// <para>
        /// <para>The maintenance window task ID to retrieve.</para>
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
        public System.String WindowTaskId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse, GetSSMMaintenanceWindowTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.WindowId = this.WindowId;
            #if MODULAR
            if (this.WindowId == null && ParameterWasBound(nameof(this.WindowId)))
            {
                WriteWarning("You are passing $null as a value for parameter WindowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WindowTaskId = this.WindowTaskId;
            #if MODULAR
            if (this.WindowTaskId == null && ParameterWasBound(nameof(this.WindowTaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter WindowTaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskRequest();
            
            if (cmdletContext.WindowId != null)
            {
                request.WindowId = cmdletContext.WindowId;
            }
            if (cmdletContext.WindowTaskId != null)
            {
                request.WindowTaskId = cmdletContext.WindowTaskId;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetMaintenanceWindowTask");
            try
            {
                return client.GetMaintenanceWindowTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String WindowId { get; set; }
            public System.String WindowTaskId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowTaskResponse, GetSSMMaintenanceWindowTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
