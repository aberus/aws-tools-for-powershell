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
using Amazon.SupplyChain;
using Amazon.SupplyChain.Model;

namespace Amazon.PowerShell.Cmdlets.SUPCH
{
    /// <summary>
    /// Send the data payload for the event with real-time data for analysis or monitoring.
    /// The real-time data events are stored in an Amazon Web Services service before being
    /// processed and stored in data lake.
    /// </summary>
    [Cmdlet("Send", "SUPCHDataIntegrationEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Supply Chain SendDataIntegrationEvent API operation.", Operation = new[] {"SendDataIntegrationEvent"}, SelectReturnType = typeof(Amazon.SupplyChain.Model.SendDataIntegrationEventResponse))]
    [AWSCmdletOutput("System.String or Amazon.SupplyChain.Model.SendDataIntegrationEventResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SupplyChain.Model.SendDataIntegrationEventResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSUPCHDataIntegrationEventCmdlet : AmazonSupplyChainClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Data
        /// <summary>
        /// <para>
        /// <para>The data payload of the event, should follow the data schema of the target dataset,
        /// or see <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/data-model-asc.html">Data
        /// entities supported in AWS Supply Chain</a>. To send single data record, use JsonObject
        /// format; to send multiple data records, use JsonArray format.</para><para>Note that for AWS Supply Chain dataset under <b>asc</b> namespace, it has a connection_id
        /// internal field that is not allowed to be provided by client directly, they will be
        /// auto populated.</para>
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
        public System.String Data { get; set; }
        #endregion
        
        #region Parameter DatasetTarget_DatasetIdentifier
        /// <summary>
        /// <para>
        /// <para>The datalake dataset ARN identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetTarget_DatasetIdentifier { get; set; }
        #endregion
        
        #region Parameter EventGroupId
        /// <summary>
        /// <para>
        /// <para>Event identifier (for example, orderId for InboundOrder) used for data sharding or
        /// partitioning. Noted under one eventGroupId of same eventType and instanceId, events
        /// are processed sequentially in the order they are received by the server.</para>
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
        public System.String EventGroupId { get; set; }
        #endregion
        
        #region Parameter EventTimestamp
        /// <summary>
        /// <para>
        /// <para>The timestamp (in epoch seconds) associated with the event. If not provided, it will
        /// be assigned with current timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EventTimestamp { get; set; }
        #endregion
        
        #region Parameter EventType
        /// <summary>
        /// <para>
        /// <para>The data event type.</para><ul><li><para><b>scn.data.dataset</b> - Send data directly to any specified dataset.</para></li><li><para><b>scn.data.supplyplan</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/supply-plan-entity.html">supply_plan</a>
        /// dataset.</para></li><li><para><b>scn.data.shipmentstoporder</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/replenishment-shipment-stop-order-entity.html">shipment_stop_order</a>
        /// dataset.</para></li><li><para><b>scn.data.shipmentstop</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/replenishment-shipment-stop-entity.html">shipment_stop</a>
        /// dataset.</para></li><li><para><b>scn.data.shipment</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/replenishment-shipment-entity.html">shipment</a>
        /// dataset.</para></li><li><para><b>scn.data.reservation</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/planning-reservation-entity.html">reservation</a>
        /// dataset.</para></li><li><para><b>scn.data.processproduct</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/operation-process-product-entity.html">process_product</a>
        /// dataset.</para></li><li><para><b>scn.data.processoperation</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/operation-process-operation-entity.html">process_operation</a>
        /// dataset.</para></li><li><para><b>scn.data.processheader</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/operation-process-header-entity.html">process_header</a>
        /// dataset.</para></li><li><para><b>scn.data.forecast</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/forecast-forecast-entity.html">forecast</a>
        /// dataset.</para></li><li><para><b>scn.data.inventorylevel</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/inventory_mgmnt-inv-level-entity.html">inv_level</a>
        /// dataset.</para></li><li><para><b>scn.data.inboundorder</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/replenishment-inbound-order-entity.html">inbound_order</a>
        /// dataset.</para></li><li><para><b>scn.data.inboundorderline</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/replenishment-inbound-order-line-entity.html">inbound_order_line</a>
        /// dataset.</para></li><li><para><b>scn.data.inboundorderlineschedule</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/replenishment-inbound-order-line-schedule-entity.html">inbound_order_line_schedule</a>
        /// dataset.</para></li><li><para><b>scn.data.outboundorderline</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/outbound-fulfillment-order-line-entity.html">outbound_order_line</a>
        /// dataset.</para></li><li><para><b>scn.data.outboundshipment</b> - Send data to <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/outbound-fulfillment-shipment-entity.html">outbound_shipment</a>
        /// dataset.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationEventType")]
        public Amazon.SupplyChain.DataIntegrationEventType EventType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The AWS Supply Chain instance identifier.</para>
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
        
        #region Parameter DatasetTarget_OperationType
        /// <summary>
        /// <para>
        /// <para>The target dataset load operation type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SupplyChain.DataIntegrationEventDatasetOperationType")]
        public Amazon.SupplyChain.DataIntegrationEventDatasetOperationType DatasetTarget_OperationType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotent client token. The token is active for 8 hours, and within its lifetime,
        /// it ensures the request completes only once upon retry with same client token. If omitted,
        /// the AWS SDK generates a unique value so that AWS SDK can safely retry the request
        /// upon network errors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupplyChain.Model.SendDataIntegrationEventResponse).
        /// Specifying the name of a property of type Amazon.SupplyChain.Model.SendDataIntegrationEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SUPCHDataIntegrationEvent (SendDataIntegrationEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupplyChain.Model.SendDataIntegrationEventResponse, SendSUPCHDataIntegrationEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Data = this.Data;
            #if MODULAR
            if (this.Data == null && ParameterWasBound(nameof(this.Data)))
            {
                WriteWarning("You are passing $null as a value for parameter Data which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetTarget_DatasetIdentifier = this.DatasetTarget_DatasetIdentifier;
            context.DatasetTarget_OperationType = this.DatasetTarget_OperationType;
            context.EventGroupId = this.EventGroupId;
            #if MODULAR
            if (this.EventGroupId == null && ParameterWasBound(nameof(this.EventGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter EventGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventTimestamp = this.EventTimestamp;
            context.EventType = this.EventType;
            #if MODULAR
            if (this.EventType == null && ParameterWasBound(nameof(this.EventType)))
            {
                WriteWarning("You are passing $null as a value for parameter EventType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SupplyChain.Model.SendDataIntegrationEventRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Data != null)
            {
                request.Data = cmdletContext.Data;
            }
            
             // populate DatasetTarget
            var requestDatasetTargetIsNull = true;
            request.DatasetTarget = new Amazon.SupplyChain.Model.DataIntegrationEventDatasetTargetConfiguration();
            System.String requestDatasetTarget_datasetTarget_DatasetIdentifier = null;
            if (cmdletContext.DatasetTarget_DatasetIdentifier != null)
            {
                requestDatasetTarget_datasetTarget_DatasetIdentifier = cmdletContext.DatasetTarget_DatasetIdentifier;
            }
            if (requestDatasetTarget_datasetTarget_DatasetIdentifier != null)
            {
                request.DatasetTarget.DatasetIdentifier = requestDatasetTarget_datasetTarget_DatasetIdentifier;
                requestDatasetTargetIsNull = false;
            }
            Amazon.SupplyChain.DataIntegrationEventDatasetOperationType requestDatasetTarget_datasetTarget_OperationType = null;
            if (cmdletContext.DatasetTarget_OperationType != null)
            {
                requestDatasetTarget_datasetTarget_OperationType = cmdletContext.DatasetTarget_OperationType;
            }
            if (requestDatasetTarget_datasetTarget_OperationType != null)
            {
                request.DatasetTarget.OperationType = requestDatasetTarget_datasetTarget_OperationType;
                requestDatasetTargetIsNull = false;
            }
             // determine if request.DatasetTarget should be set to null
            if (requestDatasetTargetIsNull)
            {
                request.DatasetTarget = null;
            }
            if (cmdletContext.EventGroupId != null)
            {
                request.EventGroupId = cmdletContext.EventGroupId;
            }
            if (cmdletContext.EventTimestamp != null)
            {
                request.EventTimestamp = cmdletContext.EventTimestamp.Value;
            }
            if (cmdletContext.EventType != null)
            {
                request.EventType = cmdletContext.EventType;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.SupplyChain.Model.SendDataIntegrationEventResponse CallAWSServiceOperation(IAmazonSupplyChain client, Amazon.SupplyChain.Model.SendDataIntegrationEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Supply Chain", "SendDataIntegrationEvent");
            try
            {
                #if DESKTOP
                return client.SendDataIntegrationEvent(request);
                #elif CORECLR
                return client.SendDataIntegrationEventAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Data { get; set; }
            public System.String DatasetTarget_DatasetIdentifier { get; set; }
            public Amazon.SupplyChain.DataIntegrationEventDatasetOperationType DatasetTarget_OperationType { get; set; }
            public System.String EventGroupId { get; set; }
            public System.DateTime? EventTimestamp { get; set; }
            public Amazon.SupplyChain.DataIntegrationEventType EventType { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.SupplyChain.Model.SendDataIntegrationEventResponse, SendSUPCHDataIntegrationEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventId;
        }
        
    }
}
