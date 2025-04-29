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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// List the wireless gateway tasks definitions registered to your AWS account.
    /// </summary>
    [Cmdlet("Get", "IOTWWirelessGatewayTaskDefinitionList")]
    [OutputType("Amazon.IoTWireless.Model.UpdateWirelessGatewayTaskEntry")]
    [AWSCmdlet("Calls the AWS IoT Wireless ListWirelessGatewayTaskDefinitions API operation.", Operation = new[] {"ListWirelessGatewayTaskDefinitions"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.UpdateWirelessGatewayTaskEntry or Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse",
        "This cmdlet returns a collection of Amazon.IoTWireless.Model.UpdateWirelessGatewayTaskEntry objects.",
        "The service call response (type Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTWWirelessGatewayTaskDefinitionListCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TaskDefinitionType
        /// <summary>
        /// <para>
        /// <para>A filter to list only the wireless gateway task definitions that use this task definition
        /// type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.WirelessGatewayTaskDefinitionType")]
        public Amazon.IoTWireless.WirelessGatewayTaskDefinitionType TaskDefinitionType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in this operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>To retrieve the next set of results, the <c>nextToken</c> value from a previous response;
        /// otherwise <b>null</b> to receive the first set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskDefinitions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskDefinitions";
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
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse, GetIOTWWirelessGatewayTaskDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TaskDefinitionType = this.TaskDefinitionType;
            
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
            var request = new Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TaskDefinitionType != null)
            {
                request.TaskDefinitionType = cmdletContext.TaskDefinitionType;
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
        
        private Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "ListWirelessGatewayTaskDefinitions");
            try
            {
                return client.ListWirelessGatewayTaskDefinitionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.IoTWireless.WirelessGatewayTaskDefinitionType TaskDefinitionType { get; set; }
            public System.Func<Amazon.IoTWireless.Model.ListWirelessGatewayTaskDefinitionsResponse, GetIOTWWirelessGatewayTaskDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskDefinitions;
        }
        
    }
}
