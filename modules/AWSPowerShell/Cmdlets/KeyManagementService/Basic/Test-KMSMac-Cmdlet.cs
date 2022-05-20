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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Verifies the hash-based message authentication code (HMAC) for a specified message,
    /// HMAC KMS key, and MAC algorithm. To verify the HMAC, <code>VerifyMac</code> computes
    /// an HMAC using the message, HMAC KMS key, and MAC algorithm that you specify, and compares
    /// the computed HMAC to the HMAC that you specify. If the HMACs are identical, the verification
    /// succeeds; otherwise, it fails.
    /// 
    ///  
    /// <para>
    /// Verification indicates that the message hasn't changed since the HMAC was calculated,
    /// and the specified key was used to generate and verify the HMAC.
    /// </para><para>
    /// This operation is part of KMS support for HMAC KMS keys. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/hmac.html">HMAC
    /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <code>KeyId</code> parameter. 
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:VerifyMac</a>
    /// (key policy)
    /// </para><para><b>Related operations</b>: <a>GenerateMac</a></para>
    /// </summary>
    [Cmdlet("Test", "KMSMac")]
    [OutputType("Amazon.KeyManagementService.Model.VerifyMacResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service VerifyMac API operation.", Operation = new[] {"VerifyMac"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.VerifyMacResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.VerifyMacResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.VerifyMacResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestKMSMacCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>Use a grant token when your permission to call this operation comes from a new grant
        /// that has not yet achieved <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">Grant
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#using-grant-token">Using
        /// a grant token</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key that will be used in the verification.</para><para>Enter a key ID of the KMS key that was used to generate the HMAC. If you identify
        /// a different KMS key, the <code>VerifyMac</code> operation fails.</para>
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
        
        #region Parameter Mac
        /// <summary>
        /// <para>
        /// <para>The HMAC to verify. Enter the HMAC that was generated by the <a>GenerateMac</a> operation
        /// when you specified the same message, HMAC KMS key, and MAC algorithm as the values
        /// specified in this request.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Mac { get; set; }
        #endregion
        
        #region Parameter MacAlgorithm
        /// <summary>
        /// <para>
        /// <para>The MAC algorithm that will be used in the verification. Enter the same MAC algorithm
        /// that was used to compute the HMAC. This algorithm must be supported by the HMAC KMS
        /// key identified by the <code>KeyId</code> parameter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.MacAlgorithmSpec")]
        public Amazon.KeyManagementService.MacAlgorithmSpec MacAlgorithm { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The message that will be used in the verification. Enter the same message that was
        /// used to generate the HMAC.</para><para><a>GenerateMac</a> and <code>VerifyMac</code> do not provide special handling for
        /// message digests. If you generated an HMAC for a hash digest of a message, you must
        /// verify the HMAC for the same hash digest.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Message { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.VerifyMacResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.VerifyMacResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Message parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Message' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Message' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.VerifyMacResponse, TestKMSMacCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Message;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.GrantToken != null)
            {
                context.GrantToken = new List<System.String>(this.GrantToken);
            }
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mac = this.Mac;
            #if MODULAR
            if (this.Mac == null && ParameterWasBound(nameof(this.Mac)))
            {
                WriteWarning("You are passing $null as a value for parameter Mac which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MacAlgorithm = this.MacAlgorithm;
            #if MODULAR
            if (this.MacAlgorithm == null && ParameterWasBound(nameof(this.MacAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter MacAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Message = this.Message;
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _MacStream = null;
            System.IO.MemoryStream _MessageStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.VerifyMacRequest();
                
                if (cmdletContext.GrantToken != null)
                {
                    request.GrantTokens = cmdletContext.GrantToken;
                }
                if (cmdletContext.KeyId != null)
                {
                    request.KeyId = cmdletContext.KeyId;
                }
                if (cmdletContext.Mac != null)
                {
                    _MacStream = new System.IO.MemoryStream(cmdletContext.Mac);
                    request.Mac = _MacStream;
                }
                if (cmdletContext.MacAlgorithm != null)
                {
                    request.MacAlgorithm = cmdletContext.MacAlgorithm;
                }
                if (cmdletContext.Message != null)
                {
                    _MessageStream = new System.IO.MemoryStream(cmdletContext.Message);
                    request.Message = _MessageStream;
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
                if( _MacStream != null)
                {
                    _MacStream.Dispose();
                }
                if( _MessageStream != null)
                {
                    _MessageStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.VerifyMacResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.VerifyMacRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "VerifyMac");
            try
            {
                #if DESKTOP
                return client.VerifyMac(request);
                #elif CORECLR
                return client.VerifyMacAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public byte[] Mac { get; set; }
            public Amazon.KeyManagementService.MacAlgorithmSpec MacAlgorithm { get; set; }
            public byte[] Message { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.VerifyMacResponse, TestKMSMacCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}