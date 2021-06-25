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
using Amazon.EBS;
using Amazon.EBS.Model;

namespace Amazon.PowerShell.Cmdlets.EBS
{
    /// <summary>
    /// Writes a block of data to a snapshot. If the specified block contains data, the existing
    /// data is overwritten. The target snapshot must be in the <code>pending</code> state.
    /// 
    ///  
    /// <para>
    /// Data written to a snapshot must be aligned with 512-KiB sectors.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EBSSnapshotBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EBS.Model.PutSnapshotBlockResponse")]
    [AWSCmdlet("Calls the Amazon EBS PutSnapshotBlock API operation.", Operation = new[] {"PutSnapshotBlock"}, SelectReturnType = typeof(Amazon.EBS.Model.PutSnapshotBlockResponse))]
    [AWSCmdletOutput("Amazon.EBS.Model.PutSnapshotBlockResponse",
        "This cmdlet returns an Amazon.EBS.Model.PutSnapshotBlockResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEBSSnapshotBlockCmdlet : AmazonEBSClientCmdlet, IExecutor
    {
        
        #region Parameter BlockData
        /// <summary>
        /// <para>
        /// <para>The data to write to the block.</para><para>The block data is not signed as part of the Signature Version 4 signing process. As
        /// a result, you must generate and provide a Base64-encoded SHA256 checksum for the block
        /// data using the <b>x-amz-Checksum</b> header. Also, you must specify the checksum algorithm
        /// using the <b>x-amz-Checksum-Algorithm</b> header. The checksum that you provide is
        /// part of the Signature Version 4 signing process. It is validated against a checksum
        /// generated by Amazon EBS to ensure the validity and authenticity of the data. If the
        /// checksums do not correspond, the request fails. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-accessing-snapshot.html#ebsapis-using-checksums">
        /// Using checksums with the EBS direct APIs</a> in the <i>Amazon Elastic Compute Cloud
        /// User Guide</i>.</para>
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public object BlockData { get; set; }
        #endregion
        
        #region Parameter BlockIndex
        /// <summary>
        /// <para>
        /// <para>The block index of the block in which to write the data. A block index is a logical
        /// index in units of <code>512</code> KiB blocks. To identify the block index, divide
        /// the logical offset of the data in the logical volume by the block size (logical offset
        /// of data/<code>524288</code>). The logical offset of the data must be <code>512</code>
        /// KiB aligned.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? BlockIndex { get; set; }
        #endregion
        
        #region Parameter Checksum
        /// <summary>
        /// <para>
        /// <para>A Base64-encoded SHA256 checksum of the data. Only SHA256 checksums are supported.</para>
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
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm used to generate the checksum. Currently, the only supported algorithm
        /// is <code>SHA256</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EBS.ChecksumAlgorithm")]
        public Amazon.EBS.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter DataLength
        /// <summary>
        /// <para>
        /// <para>The size of the data to write to the block, in bytes. Currently, the only supported
        /// size is <code>524288</code> bytes.</para><para>Valid values: <code>524288</code></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? DataLength { get; set; }
        #endregion
        
        #region Parameter Progress
        /// <summary>
        /// <para>
        /// <para>The progress of the write process, as a percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Progress { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the snapshot.</para>
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
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EBS.Model.PutSnapshotBlockResponse).
        /// Specifying the name of a property of type Amazon.EBS.Model.PutSnapshotBlockResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SnapshotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EBSSnapshotBlock (PutSnapshotBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EBS.Model.PutSnapshotBlockResponse, WriteEBSSnapshotBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SnapshotId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BlockData = this.BlockData;
            #if MODULAR
            if (this.BlockData == null && ParameterWasBound(nameof(this.BlockData)))
            {
                WriteWarning("You are passing $null as a value for parameter BlockData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlockIndex = this.BlockIndex;
            #if MODULAR
            if (this.BlockIndex == null && ParameterWasBound(nameof(this.BlockIndex)))
            {
                WriteWarning("You are passing $null as a value for parameter BlockIndex which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Checksum = this.Checksum;
            #if MODULAR
            if (this.Checksum == null && ParameterWasBound(nameof(this.Checksum)))
            {
                WriteWarning("You are passing $null as a value for parameter Checksum which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            #if MODULAR
            if (this.ChecksumAlgorithm == null && ParameterWasBound(nameof(this.ChecksumAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter ChecksumAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataLength = this.DataLength;
            #if MODULAR
            if (this.DataLength == null && ParameterWasBound(nameof(this.DataLength)))
            {
                WriteWarning("You are passing $null as a value for parameter DataLength which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Progress = this.Progress;
            context.SnapshotId = this.SnapshotId;
            #if MODULAR
            if (this.SnapshotId == null && ParameterWasBound(nameof(this.SnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.Stream _BlockDataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.EBS.Model.PutSnapshotBlockRequest();
                
                if (cmdletContext.BlockData != null)
                {
                    _BlockDataStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.BlockData);
                    request.BlockData = _BlockDataStream;
                }
                if (cmdletContext.BlockIndex != null)
                {
                    request.BlockIndex = cmdletContext.BlockIndex.Value;
                }
                if (cmdletContext.Checksum != null)
                {
                    request.Checksum = cmdletContext.Checksum;
                }
                if (cmdletContext.ChecksumAlgorithm != null)
                {
                    request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
                }
                if (cmdletContext.DataLength != null)
                {
                    request.DataLength = cmdletContext.DataLength.Value;
                }
                if (cmdletContext.Progress != null)
                {
                    request.Progress = cmdletContext.Progress.Value;
                }
                if (cmdletContext.SnapshotId != null)
                {
                    request.SnapshotId = cmdletContext.SnapshotId;
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
                if( _BlockDataStream != null)
                {
                    _BlockDataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EBS.Model.PutSnapshotBlockResponse CallAWSServiceOperation(IAmazonEBS client, Amazon.EBS.Model.PutSnapshotBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EBS", "PutSnapshotBlock");
            try
            {
                #if DESKTOP
                return client.PutSnapshotBlock(request);
                #elif CORECLR
                return client.PutSnapshotBlockAsync(request).GetAwaiter().GetResult();
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
            public object BlockData { get; set; }
            public System.Int32? BlockIndex { get; set; }
            public System.String Checksum { get; set; }
            public Amazon.EBS.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.Int32? DataLength { get; set; }
            public System.Int32? Progress { get; set; }
            public System.String SnapshotId { get; set; }
            public System.Func<Amazon.EBS.Model.PutSnapshotBlockResponse, WriteEBSSnapshotBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
