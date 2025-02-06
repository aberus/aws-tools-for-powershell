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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Stores a geofence geometry in a given geofence collection, or updates the geometry
    /// of an existing geofence if a geofence ID is included in the request.
    /// </summary>
    [Cmdlet("Set", "LOCGeofence", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.PutGeofenceResponse")]
    [AWSCmdlet("Calls the Amazon Location Service PutGeofence API operation.", Operation = new[] {"PutGeofence"}, SelectReturnType = typeof(Amazon.LocationService.Model.PutGeofenceResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.PutGeofenceResponse",
        "This cmdlet returns an Amazon.LocationService.Model.PutGeofenceResponse object containing multiple properties."
    )]
    public partial class SetLOCGeofenceCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Circle_Center
        /// <summary>
        /// <para>
        /// <para>A single point geometry, specifying the center of the circle, using <a href="https://gisgeography.com/wgs84-world-geodetic-system/">WGS
        /// 84</a> coordinates, in the form <c>[longitude, latitude]</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Geometry_Circle_Center")]
        public System.Double[] Circle_Center { get; set; }
        #endregion
        
        #region Parameter CollectionName
        /// <summary>
        /// <para>
        /// <para>The geofence collection to store the geofence in.</para>
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
        public System.String CollectionName { get; set; }
        #endregion
        
        #region Parameter Geometry_Geobuf
        /// <summary>
        /// <para>
        /// <para>Geobuf is a compact binary encoding for geographic data that provides lossless compression
        /// of GeoJSON polygons. The Geobuf must be Base64-encoded.</para><para>A polygon in Geobuf format can have up to 100,000 vertices.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Geometry_Geobuf { get; set; }
        #endregion
        
        #region Parameter GeofenceId
        /// <summary>
        /// <para>
        /// <para>An identifier for the geofence. For example, <c>ExampleGeofence-1</c>.</para>
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
        public System.String GeofenceId { get; set; }
        #endregion
        
        #region Parameter GeofenceProperty
        /// <summary>
        /// <para>
        /// <para>Associates one of more properties with the geofence. A property is a key-value pair
        /// stored with the geofence and added to any geofence event triggered with that geofence.</para><para>Format: <c>"key" : "value"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GeofenceProperties")]
        public System.Collections.Hashtable GeofenceProperty { get; set; }
        #endregion
        
        #region Parameter Geometry_Polygon
        /// <summary>
        /// <para>
        /// <para>A polygon is a list of linear rings which are each made up of a list of vertices.</para><para>Each vertex is a 2-dimensional point of the form: <c>[longitude, latitude]</c>. This
        /// is represented as an array of doubles of length 2 (so <c>[double, double]</c>).</para><para>An array of 4 or more vertices, where the first and last vertex are the same (to form
        /// a closed boundary), is called a linear ring. The linear ring vertices must be listed
        /// in counter-clockwise order around the ring’s interior. The linear ring is represented
        /// as an array of vertices, or an array of arrays of doubles (<c>[[double, double], ...]</c>).</para><para>A geofence consists of a single linear ring. To allow for future expansion, the Polygon
        /// parameter takes an array of linear rings, which is represented as an array of arrays
        /// of arrays of doubles (<c>[[[double, double], ...], ...]</c>).</para><para>A linear ring for use in geofences can consist of between 4 and 1,000 vertices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[][][] Geometry_Polygon { get; set; }
        #endregion
        
        #region Parameter Circle_Radius
        /// <summary>
        /// <para>
        /// <para>The radius of the circle in meters. Must be greater than zero and no larger than 100,000
        /// (100 kilometers).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Geometry_Circle_Radius")]
        public System.Double? Circle_Radius { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.PutGeofenceResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.PutGeofenceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-LOCGeofence (PutGeofence)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.PutGeofenceResponse, SetLOCGeofenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollectionName = this.CollectionName;
            #if MODULAR
            if (this.CollectionName == null && ParameterWasBound(nameof(this.CollectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GeofenceId = this.GeofenceId;
            #if MODULAR
            if (this.GeofenceId == null && ParameterWasBound(nameof(this.GeofenceId)))
            {
                WriteWarning("You are passing $null as a value for parameter GeofenceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GeofenceProperty != null)
            {
                context.GeofenceProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GeofenceProperty.Keys)
                {
                    context.GeofenceProperty.Add((String)hashKey, (System.String)(this.GeofenceProperty[hashKey]));
                }
            }
            if (this.Circle_Center != null)
            {
                context.Circle_Center = new List<System.Double>(this.Circle_Center);
            }
            context.Circle_Radius = this.Circle_Radius;
            context.Geometry_Geobuf = this.Geometry_Geobuf;
            if (this.Geometry_Polygon != null)
            {
                context.Geometry_Polygon = new List<List<List<System.Double>>>();
                foreach (var innerList in this.Geometry_Polygon)
                {
                    var innerListCopy = new List<List<System.Double>>();
                    context.Geometry_Polygon.Add(innerListCopy);
                    foreach (var innermostList in innerList)
                    {
                        var innermostListCopy = new List<System.Double>(innermostList);
                        innerListCopy.Add(innermostListCopy);
                    }
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
            System.IO.MemoryStream _Geometry_GeobufStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.LocationService.Model.PutGeofenceRequest();
                
                if (cmdletContext.CollectionName != null)
                {
                    request.CollectionName = cmdletContext.CollectionName;
                }
                if (cmdletContext.GeofenceId != null)
                {
                    request.GeofenceId = cmdletContext.GeofenceId;
                }
                if (cmdletContext.GeofenceProperty != null)
                {
                    request.GeofenceProperties = cmdletContext.GeofenceProperty;
                }
                
                 // populate Geometry
                var requestGeometryIsNull = true;
                request.Geometry = new Amazon.LocationService.Model.GeofenceGeometry();
                System.IO.MemoryStream requestGeometry_geometry_Geobuf = null;
                if (cmdletContext.Geometry_Geobuf != null)
                {
                    _Geometry_GeobufStream = new System.IO.MemoryStream(cmdletContext.Geometry_Geobuf);
                    requestGeometry_geometry_Geobuf = _Geometry_GeobufStream;
                }
                if (requestGeometry_geometry_Geobuf != null)
                {
                    request.Geometry.Geobuf = requestGeometry_geometry_Geobuf;
                    requestGeometryIsNull = false;
                }
                List<List<List<System.Double>>> requestGeometry_geometry_Polygon = null;
                if (cmdletContext.Geometry_Polygon != null)
                {
                    requestGeometry_geometry_Polygon = cmdletContext.Geometry_Polygon;
                }
                if (requestGeometry_geometry_Polygon != null)
                {
                    request.Geometry.Polygon = requestGeometry_geometry_Polygon;
                    requestGeometryIsNull = false;
                }
                Amazon.LocationService.Model.Circle requestGeometry_geometry_Circle = null;
                
                 // populate Circle
                var requestGeometry_geometry_CircleIsNull = true;
                requestGeometry_geometry_Circle = new Amazon.LocationService.Model.Circle();
                List<System.Double> requestGeometry_geometry_Circle_circle_Center = null;
                if (cmdletContext.Circle_Center != null)
                {
                    requestGeometry_geometry_Circle_circle_Center = cmdletContext.Circle_Center;
                }
                if (requestGeometry_geometry_Circle_circle_Center != null)
                {
                    requestGeometry_geometry_Circle.Center = requestGeometry_geometry_Circle_circle_Center;
                    requestGeometry_geometry_CircleIsNull = false;
                }
                System.Double? requestGeometry_geometry_Circle_circle_Radius = null;
                if (cmdletContext.Circle_Radius != null)
                {
                    requestGeometry_geometry_Circle_circle_Radius = cmdletContext.Circle_Radius.Value;
                }
                if (requestGeometry_geometry_Circle_circle_Radius != null)
                {
                    requestGeometry_geometry_Circle.Radius = requestGeometry_geometry_Circle_circle_Radius.Value;
                    requestGeometry_geometry_CircleIsNull = false;
                }
                 // determine if requestGeometry_geometry_Circle should be set to null
                if (requestGeometry_geometry_CircleIsNull)
                {
                    requestGeometry_geometry_Circle = null;
                }
                if (requestGeometry_geometry_Circle != null)
                {
                    request.Geometry.Circle = requestGeometry_geometry_Circle;
                    requestGeometryIsNull = false;
                }
                 // determine if request.Geometry should be set to null
                if (requestGeometryIsNull)
                {
                    request.Geometry = null;
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
            finally
            {
                if( _Geometry_GeobufStream != null)
                {
                    _Geometry_GeobufStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LocationService.Model.PutGeofenceResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.PutGeofenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "PutGeofence");
            try
            {
                #if DESKTOP
                return client.PutGeofence(request);
                #elif CORECLR
                return client.PutGeofenceAsync(request).GetAwaiter().GetResult();
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
            public System.String CollectionName { get; set; }
            public System.String GeofenceId { get; set; }
            public Dictionary<System.String, System.String> GeofenceProperty { get; set; }
            public List<System.Double> Circle_Center { get; set; }
            public System.Double? Circle_Radius { get; set; }
            public byte[] Geometry_Geobuf { get; set; }
            public List<List<List<System.Double>>> Geometry_Polygon { get; set; }
            public System.Func<Amazon.LocationService.Model.PutGeofenceResponse, SetLOCGeofenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
