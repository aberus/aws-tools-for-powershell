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
using Amazon.LocationService;
using Amazon.LocationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// A batch request to retrieve all device positions.
    /// </summary>
    [Cmdlet("Get", "LOCDevicePositionList")]
    [OutputType("Amazon.LocationService.Model.ListDevicePositionsResponseEntry")]
    [AWSCmdlet("Calls the Amazon Location Service ListDevicePositions API operation.", Operation = new[] {"ListDevicePositions"}, SelectReturnType = typeof(Amazon.LocationService.Model.ListDevicePositionsResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.ListDevicePositionsResponseEntry or Amazon.LocationService.Model.ListDevicePositionsResponse",
        "This cmdlet returns a collection of Amazon.LocationService.Model.ListDevicePositionsResponseEntry objects.",
        "The service call response (type Amazon.LocationService.Model.ListDevicePositionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLOCDevicePositionListCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterGeometry_Polygon
        /// <summary>
        /// <para>
        /// <para>The set of arrays which define the polygon. A polygon can have between 4 and 1000
        /// vertices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[][][] FilterGeometry_Polygon { get; set; }
        #endregion
        
        #region Parameter TrackerName
        /// <summary>
        /// <para>
        /// <para>The tracker resource containing the requested devices.</para>
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
        public System.String TrackerName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional limit for the number of entries returned in a single call.</para><para>Default value: <c>100</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token specifying which page of results to return in the response. If
        /// no token is provided, the default page is the first page.</para><para>Default value: <c>null</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.ListDevicePositionsResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.ListDevicePositionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entries";
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
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.ListDevicePositionsResponse, GetLOCDevicePositionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterGeometry_Polygon != null)
            {
                context.FilterGeometry_Polygon = new List<List<List<System.Double>>>();
                foreach (var innerList in this.FilterGeometry_Polygon)
                {
                    var innerListCopy = new List<List<System.Double>>();
                    context.FilterGeometry_Polygon.Add(innerListCopy);
                    foreach (var innermostList in innerList)
                    {
                        var innermostListCopy = new List<System.Double>(innermostList);
                        innerListCopy.Add(innermostListCopy);
                    }
                }
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TrackerName = this.TrackerName;
            #if MODULAR
            if (this.TrackerName == null && ParameterWasBound(nameof(this.TrackerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.ListDevicePositionsRequest();
            
            
             // populate FilterGeometry
            var requestFilterGeometryIsNull = true;
            request.FilterGeometry = new Amazon.LocationService.Model.TrackingFilterGeometry();
            List<List<List<System.Double>>> requestFilterGeometry_filterGeometry_Polygon = null;
            if (cmdletContext.FilterGeometry_Polygon != null)
            {
                requestFilterGeometry_filterGeometry_Polygon = cmdletContext.FilterGeometry_Polygon;
            }
            if (requestFilterGeometry_filterGeometry_Polygon != null)
            {
                request.FilterGeometry.Polygon = requestFilterGeometry_filterGeometry_Polygon;
                requestFilterGeometryIsNull = false;
            }
             // determine if request.FilterGeometry should be set to null
            if (requestFilterGeometryIsNull)
            {
                request.FilterGeometry = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TrackerName != null)
            {
                request.TrackerName = cmdletContext.TrackerName;
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
        
        private Amazon.LocationService.Model.ListDevicePositionsResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.ListDevicePositionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "ListDevicePositions");
            try
            {
                return client.ListDevicePositionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<List<List<System.Double>>> FilterGeometry_Polygon { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String TrackerName { get; set; }
            public System.Func<Amazon.LocationService.Model.ListDevicePositionsResponse, GetLOCDevicePositionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entries;
        }
        
    }
}
