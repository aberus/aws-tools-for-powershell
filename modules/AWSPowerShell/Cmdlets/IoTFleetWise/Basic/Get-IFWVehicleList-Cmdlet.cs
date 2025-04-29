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
using Amazon.IoTFleetWise;
using Amazon.IoTFleetWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IFW
{
    /// <summary>
    /// Retrieves a list of summaries of created vehicles. 
    /// 
    ///  <note><para>
    /// This API operation uses pagination. Specify the <c>nextToken</c> parameter in the
    /// request to return more results.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "IFWVehicleList")]
    [OutputType("Amazon.IoTFleetWise.Model.VehicleSummary")]
    [AWSCmdlet("Calls the AWS IoT FleetWise ListVehicles API operation.", Operation = new[] {"ListVehicles"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.ListVehiclesResponse))]
    [AWSCmdletOutput("Amazon.IoTFleetWise.Model.VehicleSummary or Amazon.IoTFleetWise.Model.ListVehiclesResponse",
        "This cmdlet returns a collection of Amazon.IoTFleetWise.Model.VehicleSummary objects.",
        "The service call response (type Amazon.IoTFleetWise.Model.ListVehiclesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIFWVehicleListCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The fully qualified names of the attributes. You can use this optional parameter to
        /// list the vehicles containing all the attributes in the request. For example, <c>attributeNames</c>
        /// could be "<c>Vehicle.Body.Engine.Type, Vehicle.Color</c>" and the corresponding <c>attributeValues</c>
        /// could be "<c>1.3 L R2, Blue</c>" . In this case, the API will filter vehicles with
        /// an attribute name <c>Vehicle.Body.Engine.Type</c> that contains a value of <c>1.3
        /// L R2</c> AND an attribute name <c>Vehicle.Color</c> that contains a value of "<c>Blue</c>".
        /// A request must contain unique values for the <c>attributeNames</c> filter and the
        /// matching number of <c>attributeValues</c> filters to return the subset of vehicles
        /// that match the attributes filter condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter AttributeValue
        /// <summary>
        /// <para>
        /// <para>Static information about a vehicle attribute value in string format. You can use this
        /// optional parameter in conjunction with <c>attributeNames</c> to list the vehicles
        /// containing all the <c>attributeValues</c> corresponding to the <c>attributeNames</c>
        /// filter. For example, <c>attributeValues</c> could be "<c>1.3 L R2, Blue</c>" and the
        /// corresponding <c>attributeNames</c> filter could be "<c>Vehicle.Body.Engine.Type,
        /// Vehicle.Color</c>". In this case, the API will filter vehicles with attribute name
        /// <c>Vehicle.Body.Engine.Type</c> that contains a value of <c>1.3 L R2</c> AND an attribute
        /// name <c>Vehicle.Color</c> that contains a value of "<c>Blue</c>". A request must contain
        /// unique values for the <c>attributeNames</c> filter and the matching number of <c>attributeValues</c>
        /// filter to return the subset of vehicles that match the attributes filter condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeValues")]
        public System.String[] AttributeValue { get; set; }
        #endregion
        
        #region Parameter ListResponseScope
        /// <summary>
        /// <para>
        /// <para>When you set the <c>listResponseScope</c> parameter to <c>METADATA_ONLY</c>, the list
        /// response includes: vehicle name, Amazon Resource Name (ARN), creation time, and last
        /// modification time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTFleetWise.ListResponseScope")]
        public Amazon.IoTFleetWise.ListResponseScope ListResponseScope { get; set; }
        #endregion
        
        #region Parameter ModelManifestArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of a vehicle model (model manifest). You can use this
        /// optional parameter to list only the vehicles created from a certain vehicle model.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ModelManifestArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return, between 1 and 100, inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token for the next set of results.</para><para>If the results of a search are large, only a portion of the results are returned,
        /// and a <c>nextToken</c> pagination token is returned in the response. To retrieve the
        /// next set of results, reissue the search request and include the returned token. When
        /// all results have been returned, the response does not contain a pagination token value.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VehicleSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.ListVehiclesResponse).
        /// Specifying the name of a property of type Amazon.IoTFleetWise.Model.ListVehiclesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VehicleSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.ListVehiclesResponse, GetIFWVehicleListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeName != null)
            {
                context.AttributeName = new List<System.String>(this.AttributeName);
            }
            if (this.AttributeValue != null)
            {
                context.AttributeValue = new List<System.String>(this.AttributeValue);
            }
            context.ListResponseScope = this.ListResponseScope;
            context.MaxResult = this.MaxResult;
            context.ModelManifestArn = this.ModelManifestArn;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.IoTFleetWise.Model.ListVehiclesRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeNames = cmdletContext.AttributeName;
            }
            if (cmdletContext.AttributeValue != null)
            {
                request.AttributeValues = cmdletContext.AttributeValue;
            }
            if (cmdletContext.ListResponseScope != null)
            {
                request.ListResponseScope = cmdletContext.ListResponseScope;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ModelManifestArn != null)
            {
                request.ModelManifestArn = cmdletContext.ModelManifestArn;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.IoTFleetWise.Model.ListVehiclesResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.ListVehiclesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "ListVehicles");
            try
            {
                return client.ListVehiclesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AttributeName { get; set; }
            public List<System.String> AttributeValue { get; set; }
            public Amazon.IoTFleetWise.ListResponseScope ListResponseScope { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String ModelManifestArn { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.ListVehiclesResponse, GetIFWVehicleListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VehicleSummaries;
        }
        
    }
}
