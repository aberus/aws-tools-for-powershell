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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Enables or updates server-side encryption using an Amazon Web Services KMS key for
    /// a specified stream. 
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// Starting encryption is an asynchronous operation. Upon receiving the request, Kinesis
    /// Data Streams returns immediately and sets the status of the stream to <c>UPDATING</c>.
    /// After the update is complete, Kinesis Data Streams sets the status of the stream back
    /// to <c>ACTIVE</c>. Updating or applying encryption normally takes a few seconds to
    /// complete, but it can take minutes. You can continue to read and write data to your
    /// stream while its status is <c>UPDATING</c>. Once the status of the stream is <c>ACTIVE</c>,
    /// encryption begins for records written to the stream. 
    /// </para><para>
    /// API Limits: You can successfully apply a new Amazon Web Services KMS key for server-side
    /// encryption 25 times in a rolling 24-hour period.
    /// </para><para>
    /// Note: It can take up to 5 seconds after the stream is in an <c>ACTIVE</c> status before
    /// all records written to the stream are encrypted. After you enable encryption, you
    /// can verify that encryption is applied by inspecting the API response from <c>PutRecord</c>
    /// or <c>PutRecords</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "KINStreamEncryption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis StartStreamEncryption API operation.", Operation = new[] {"StartStreamEncryption"}, SelectReturnType = typeof(Amazon.Kinesis.Model.StartStreamEncryptionResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.StartStreamEncryptionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.StartStreamEncryptionResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartKINStreamEncryptionCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EncryptionType
        /// <summary>
        /// <para>
        /// <para>The encryption type to use. The only valid value is <c>KMS</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Kinesis.EncryptionType")]
        public Amazon.Kinesis.EncryptionType EncryptionType { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The GUID for the customer-managed Amazon Web Services KMS key to use for encryption.
        /// This value can be a globally unique identifier, a fully specified Amazon Resource
        /// Name (ARN) to either an alias or a key, or an alias name prefixed by "alias/".You
        /// can also use a master key owned by Kinesis Data Streams by specifying the alias <c>aws/kinesis</c>.</para><ul><li><para>Key ARN example: <c>arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</c></para></li><li><para>Alias ARN example: <c>arn:aws:kms:us-east-1:123456789012:alias/MyAliasName</c></para></li><li><para>Globally unique key ID example: <c>12345678-1234-1234-1234-123456789012</c></para></li><li><para>Alias name example: <c>alias/MyAliasName</c></para></li><li><para>Master key owned by Kinesis Data Streams: <c>alias/aws/kinesis</c></para></li></ul>
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
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream for which to start encrypting records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.StartStreamEncryptionResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-KINStreamEncryption (StartStreamEncryption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.StartStreamEncryptionResponse, StartKINStreamEncryptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EncryptionType = this.EncryptionType;
            #if MODULAR
            if (this.EncryptionType == null && ParameterWasBound(nameof(this.EncryptionType)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.Kinesis.Model.StartStreamEncryptionRequest();
            
            if (cmdletContext.EncryptionType != null)
            {
                request.EncryptionType = cmdletContext.EncryptionType;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        private Amazon.Kinesis.Model.StartStreamEncryptionResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.StartStreamEncryptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "StartStreamEncryption");
            try
            {
                return client.StartStreamEncryptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Kinesis.EncryptionType EncryptionType { get; set; }
            public System.String KeyId { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.StartStreamEncryptionResponse, StartKINStreamEncryptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
