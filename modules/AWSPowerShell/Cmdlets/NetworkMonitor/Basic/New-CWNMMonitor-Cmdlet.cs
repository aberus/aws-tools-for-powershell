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
using Amazon.NetworkMonitor;
using Amazon.NetworkMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.CWNM
{
    /// <summary>
    /// Creates a monitor between a source subnet and destination IP address. Within a monitor
    /// you'll create one or more probes that monitor network traffic between your source
    /// Amazon Web Services VPC subnets and your destination IP addresses. Each probe then
    /// aggregates and sends metrics to Amazon CloudWatch.
    /// 
    ///  
    /// <para>
    /// You can also create a monitor with probes using this command. For each probe, you
    /// define the following:
    /// </para><ul><li><para><c>source</c>—The subnet IDs where the probes will be created.
    /// </para></li><li><para><c>destination</c>— The target destination IP address for the probe.
    /// </para></li><li><para><c>destinationPort</c>—Required only if the protocol is <c>TCP</c>.
    /// </para></li><li><para><c>protocol</c>—The communication protocol between the source and destination. This
    /// will be either <c>TCP</c> or <c>ICMP</c>.
    /// </para></li><li><para><c>packetSize</c>—The size of the packets. This must be a number between <c>56</c>
    /// and <c>8500</c>.
    /// </para></li><li><para>
    /// (Optional) <c>tags</c> —Key-value pairs created and assigned to the probe.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "CWNMMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkMonitor.Model.CreateMonitorResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Network Monitor CreateMonitor API operation.", Operation = new[] {"CreateMonitor"}, SelectReturnType = typeof(Amazon.NetworkMonitor.Model.CreateMonitorResponse))]
    [AWSCmdletOutput("Amazon.NetworkMonitor.Model.CreateMonitorResponse",
        "This cmdlet returns an Amazon.NetworkMonitor.Model.CreateMonitorResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCWNMMonitorCmdlet : AmazonNetworkMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AggregationPeriod
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, that metrics are aggregated and sent to Amazon CloudWatch. Valid
        /// values are either <c>30</c> or <c>60</c>. <c>60</c> is the default if no period is
        /// chosen.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? AggregationPeriod { get; set; }
        #endregion
        
        #region Parameter MonitorName
        /// <summary>
        /// <para>
        /// <para>The name identifying the monitor. It can contain only letters, underscores (_), or
        /// dashes (-), and can be up to 200 characters.</para>
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
        
        #region Parameter Probe
        /// <summary>
        /// <para>
        /// <para>Displays a list of all of the probes created for a monitor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Probes")]
        public Amazon.NetworkMonitor.Model.CreateMonitorProbeInput[] Probe { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of key-value pairs created and assigned to the monitor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure the idempotency of the request. Only returned
        /// if a client token was provided in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkMonitor.Model.CreateMonitorResponse).
        /// Specifying the name of a property of type Amazon.NetworkMonitor.Model.CreateMonitorResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWNMMonitor (CreateMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkMonitor.Model.CreateMonitorResponse, NewCWNMMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AggregationPeriod = this.AggregationPeriod;
            context.ClientToken = this.ClientToken;
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Probe != null)
            {
                context.Probe = new List<Amazon.NetworkMonitor.Model.CreateMonitorProbeInput>(this.Probe);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.NetworkMonitor.Model.CreateMonitorRequest();
            
            if (cmdletContext.AggregationPeriod != null)
            {
                request.AggregationPeriod = cmdletContext.AggregationPeriod.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
            }
            if (cmdletContext.Probe != null)
            {
                request.Probes = cmdletContext.Probe;
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
        
        private Amazon.NetworkMonitor.Model.CreateMonitorResponse CallAWSServiceOperation(IAmazonNetworkMonitor client, Amazon.NetworkMonitor.Model.CreateMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Network Monitor", "CreateMonitor");
            try
            {
                #if DESKTOP
                return client.CreateMonitor(request);
                #elif CORECLR
                return client.CreateMonitorAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String MonitorName { get; set; }
            public List<Amazon.NetworkMonitor.Model.CreateMonitorProbeInput> Probe { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NetworkMonitor.Model.CreateMonitorResponse, NewCWNMMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
