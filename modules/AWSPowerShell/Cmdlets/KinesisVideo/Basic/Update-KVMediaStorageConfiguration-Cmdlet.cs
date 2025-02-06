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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Associates a <c>SignalingChannel</c> to a stream to store the media. There are two
    /// signaling modes that you can specify :
    /// 
    ///  <ul><li><para>
    /// If <c>StorageStatus</c> is enabled, the data will be stored in the <c>StreamARN</c>
    /// provided. In order for WebRTC Ingestion to work, the stream must have data retention
    /// enabled.
    /// </para></li><li><para>
    /// If <c>StorageStatus</c> is disabled, no data will be stored, and the <c>StreamARN</c>
    /// parameter will not be needed. 
    /// </para></li></ul><important><para>
    /// If <c>StorageStatus</c> is enabled, direct peer-to-peer (master-viewer) connections
    /// no longer occur. Peers connect directly to the storage session. You must call the
    /// <c>JoinStorageSession</c> API to trigger an SDP offer send and establish a connection
    /// between a peer and the storage session. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "KVMediaStorageConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams UpdateMediaStorageConfiguration API operation.", Operation = new[] {"UpdateMediaStorageConfiguration"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKVMediaStorageConfigurationCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the channel.</para>
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
        public System.String ChannelARN { get; set; }
        #endregion
        
        #region Parameter MediaStorageConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>The status of the media storage configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KinesisVideo.MediaStorageConfigurationStatus")]
        public Amazon.KinesisVideo.MediaStorageConfigurationStatus MediaStorageConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter MediaStorageConfiguration_StreamARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the stream. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MediaStorageConfiguration_StreamARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KVMediaStorageConfiguration (UpdateMediaStorageConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationResponse, UpdateKVMediaStorageConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelARN = this.ChannelARN;
            #if MODULAR
            if (this.ChannelARN == null && ParameterWasBound(nameof(this.ChannelARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaStorageConfiguration_Status = this.MediaStorageConfiguration_Status;
            #if MODULAR
            if (this.MediaStorageConfiguration_Status == null && ParameterWasBound(nameof(this.MediaStorageConfiguration_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaStorageConfiguration_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaStorageConfiguration_StreamARN = this.MediaStorageConfiguration_StreamARN;
            
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
            var request = new Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationRequest();
            
            if (cmdletContext.ChannelARN != null)
            {
                request.ChannelARN = cmdletContext.ChannelARN;
            }
            
             // populate MediaStorageConfiguration
            var requestMediaStorageConfigurationIsNull = true;
            request.MediaStorageConfiguration = new Amazon.KinesisVideo.Model.MediaStorageConfiguration();
            Amazon.KinesisVideo.MediaStorageConfigurationStatus requestMediaStorageConfiguration_mediaStorageConfiguration_Status = null;
            if (cmdletContext.MediaStorageConfiguration_Status != null)
            {
                requestMediaStorageConfiguration_mediaStorageConfiguration_Status = cmdletContext.MediaStorageConfiguration_Status;
            }
            if (requestMediaStorageConfiguration_mediaStorageConfiguration_Status != null)
            {
                request.MediaStorageConfiguration.Status = requestMediaStorageConfiguration_mediaStorageConfiguration_Status;
                requestMediaStorageConfigurationIsNull = false;
            }
            System.String requestMediaStorageConfiguration_mediaStorageConfiguration_StreamARN = null;
            if (cmdletContext.MediaStorageConfiguration_StreamARN != null)
            {
                requestMediaStorageConfiguration_mediaStorageConfiguration_StreamARN = cmdletContext.MediaStorageConfiguration_StreamARN;
            }
            if (requestMediaStorageConfiguration_mediaStorageConfiguration_StreamARN != null)
            {
                request.MediaStorageConfiguration.StreamARN = requestMediaStorageConfiguration_mediaStorageConfiguration_StreamARN;
                requestMediaStorageConfigurationIsNull = false;
            }
             // determine if request.MediaStorageConfiguration should be set to null
            if (requestMediaStorageConfigurationIsNull)
            {
                request.MediaStorageConfiguration = null;
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
        
        private Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "UpdateMediaStorageConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateMediaStorageConfiguration(request);
                #elif CORECLR
                return client.UpdateMediaStorageConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelARN { get; set; }
            public Amazon.KinesisVideo.MediaStorageConfigurationStatus MediaStorageConfiguration_Status { get; set; }
            public System.String MediaStorageConfiguration_StreamARN { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.UpdateMediaStorageConfigurationResponse, UpdateKVMediaStorageConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
