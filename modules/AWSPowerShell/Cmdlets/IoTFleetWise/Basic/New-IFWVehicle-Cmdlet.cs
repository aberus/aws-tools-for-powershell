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
    /// Creates a vehicle, which is an instance of a vehicle model (model manifest). Vehicles
    /// created from the same vehicle model consist of the same signals inherited from the
    /// vehicle model.
    /// 
    ///  <note><para>
    ///  If you have an existing Amazon Web Services IoT thing, you can use Amazon Web Services
    /// IoT FleetWise to create a vehicle and collect data from your thing. 
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/create-vehicle-cli.html">Create
    /// a vehicle (AWS CLI)</a> in the <i>Amazon Web Services IoT FleetWise Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IFWVehicle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTFleetWise.Model.CreateVehicleResponse")]
    [AWSCmdlet("Calls the AWS IoT FleetWise CreateVehicle API operation.", Operation = new[] {"CreateVehicle"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.CreateVehicleResponse))]
    [AWSCmdletOutput("Amazon.IoTFleetWise.Model.CreateVehicleResponse",
        "This cmdlet returns an Amazon.IoTFleetWise.Model.CreateVehicleResponse object containing multiple properties."
    )]
    public partial class NewIFWVehicleCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociationBehavior
        /// <summary>
        /// <para>
        /// <para> An option to create a new Amazon Web Services IoT thing when creating a vehicle,
        /// or to validate an existing Amazon Web Services IoT thing as a vehicle. </para><para>Default: <code /></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTFleetWise.VehicleAssociationBehavior")]
        public Amazon.IoTFleetWise.VehicleAssociationBehavior AssociationBehavior { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>Static information about a vehicle in a key-value pair. For example: <c>"engineType"</c>
        /// : <c>"1.3 L R2"</c></para><para>To use attributes with Campaigns or State Templates, you must include them using the
        /// request parameters <c>dataExtraDimensions</c> and/or <c>metadataExtraDimensions</c>
        /// (for state templates only) when creating your campaign/state template. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter DecoderManifestArn
        /// <summary>
        /// <para>
        /// <para> The ARN of a decoder manifest. </para>
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
        public System.String DecoderManifestArn { get; set; }
        #endregion
        
        #region Parameter ModelManifestArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name ARN of a vehicle model. </para>
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
        public System.String ModelManifestArn { get; set; }
        #endregion
        
        #region Parameter StateTemplate
        /// <summary>
        /// <para>
        /// <para>Associate state templates with the vehicle. You can monitor the last known state of
        /// the vehicle in near real time.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StateTemplates")]
        public Amazon.IoTFleetWise.Model.StateTemplateAssociation[] StateTemplate { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the vehicle.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTFleetWise.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VehicleName
        /// <summary>
        /// <para>
        /// <para> The unique ID of the vehicle to create. </para>
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
        public System.String VehicleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.CreateVehicleResponse).
        /// Specifying the name of a property of type Amazon.IoTFleetWise.Model.CreateVehicleResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VehicleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IFWVehicle (CreateVehicle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.CreateVehicleResponse, NewIFWVehicleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociationBehavior = this.AssociationBehavior;
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.DecoderManifestArn = this.DecoderManifestArn;
            #if MODULAR
            if (this.DecoderManifestArn == null && ParameterWasBound(nameof(this.DecoderManifestArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DecoderManifestArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelManifestArn = this.ModelManifestArn;
            #if MODULAR
            if (this.ModelManifestArn == null && ParameterWasBound(nameof(this.ModelManifestArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelManifestArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StateTemplate != null)
            {
                context.StateTemplate = new List<Amazon.IoTFleetWise.Model.StateTemplateAssociation>(this.StateTemplate);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTFleetWise.Model.Tag>(this.Tag);
            }
            context.VehicleName = this.VehicleName;
            #if MODULAR
            if (this.VehicleName == null && ParameterWasBound(nameof(this.VehicleName)))
            {
                WriteWarning("You are passing $null as a value for parameter VehicleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTFleetWise.Model.CreateVehicleRequest();
            
            if (cmdletContext.AssociationBehavior != null)
            {
                request.AssociationBehavior = cmdletContext.AssociationBehavior;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.DecoderManifestArn != null)
            {
                request.DecoderManifestArn = cmdletContext.DecoderManifestArn;
            }
            if (cmdletContext.ModelManifestArn != null)
            {
                request.ModelManifestArn = cmdletContext.ModelManifestArn;
            }
            if (cmdletContext.StateTemplate != null)
            {
                request.StateTemplates = cmdletContext.StateTemplate;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VehicleName != null)
            {
                request.VehicleName = cmdletContext.VehicleName;
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
        
        private Amazon.IoTFleetWise.Model.CreateVehicleResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.CreateVehicleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "CreateVehicle");
            try
            {
                return client.CreateVehicleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.IoTFleetWise.VehicleAssociationBehavior AssociationBehavior { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String DecoderManifestArn { get; set; }
            public System.String ModelManifestArn { get; set; }
            public List<Amazon.IoTFleetWise.Model.StateTemplateAssociation> StateTemplate { get; set; }
            public List<Amazon.IoTFleetWise.Model.Tag> Tag { get; set; }
            public System.String VehicleName { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.CreateVehicleResponse, NewIFWVehicleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
