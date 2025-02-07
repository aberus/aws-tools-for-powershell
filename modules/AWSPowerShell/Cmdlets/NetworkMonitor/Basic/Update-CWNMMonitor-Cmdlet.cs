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
using Amazon.NetworkMonitor;
using Amazon.NetworkMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.CWNM
{
    /// <summary>
    /// Updates the <c>aggregationPeriod</c> for a monitor. Monitors support an <c>aggregationPeriod</c>
    /// of either <c>30</c> or <c>60</c> seconds. This action requires the <c>monitorName</c>
    /// and <c>probeId</c> parameter. Run <c>ListMonitors</c> to get a list of monitor names.
    /// </summary>
    [Cmdlet("Update", "CWNMMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkMonitor.Model.UpdateMonitorResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Network Monitor UpdateMonitor API operation.", Operation = new[] {"UpdateMonitor"}, SelectReturnType = typeof(Amazon.NetworkMonitor.Model.UpdateMonitorResponse))]
    [AWSCmdletOutput("Amazon.NetworkMonitor.Model.UpdateMonitorResponse",
        "This cmdlet returns an Amazon.NetworkMonitor.Model.UpdateMonitorResponse object containing multiple properties."
    )]
    public partial class UpdateCWNMMonitorCmdlet : AmazonNetworkMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AggregationPeriod
        /// <summary>
        /// <para>
        /// <para>The aggregation time, in seconds, to change to. This must be either <c>30</c> or <c>60</c>.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? AggregationPeriod { get; set; }
        #endregion
        
        #region Parameter MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor to update. </para>
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
        public System.String MonitorName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkMonitor.Model.UpdateMonitorResponse).
        /// Specifying the name of a property of type Amazon.NetworkMonitor.Model.UpdateMonitorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWNMMonitor (UpdateMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkMonitor.Model.UpdateMonitorResponse, UpdateCWNMMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AggregationPeriod = this.AggregationPeriod;
            #if MODULAR
            if (this.AggregationPeriod == null && ParameterWasBound(nameof(this.AggregationPeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter AggregationPeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkMonitor.Model.UpdateMonitorRequest();
            
            if (cmdletContext.AggregationPeriod != null)
            {
                request.AggregationPeriod = cmdletContext.AggregationPeriod.Value;
            }
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
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
        
        private Amazon.NetworkMonitor.Model.UpdateMonitorResponse CallAWSServiceOperation(IAmazonNetworkMonitor client, Amazon.NetworkMonitor.Model.UpdateMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Network Monitor", "UpdateMonitor");
            try
            {
                #if DESKTOP
                return client.UpdateMonitor(request);
                #elif CORECLR
                return client.UpdateMonitorAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? AggregationPeriod { get; set; }
            public System.String MonitorName { get; set; }
            public System.Func<Amazon.NetworkMonitor.Model.UpdateMonitorResponse, UpdateCWNMMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
