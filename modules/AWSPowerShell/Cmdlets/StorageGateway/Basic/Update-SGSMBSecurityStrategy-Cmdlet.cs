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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates the SMB security strategy level for an Amazon S3 file gateway. This action
    /// is only supported for Amazon S3 file gateways.
    /// 
    ///  <note><para>
    /// For information about configuring this setting using the Amazon Web Services console,
    /// see <a href="https://docs.aws.amazon.com/filegateway/latest/files3/security-strategy.html">Setting
    /// a security level for your gateway</a> in the <i>Amazon S3 File Gateway User Guide</i>.
    /// </para><para>
    /// A higher security strategy level can affect performance of the gateway.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SGSMBSecurityStrategy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateSMBSecurityStrategy API operation.", Operation = new[] {"UpdateSMBSecurityStrategy"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSGSMBSecurityStrategyCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter SMBSecurityStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the type of security strategy.</para><para><c>ClientSpecified</c>: If you choose this option, requests are established based
        /// on what is negotiated by the client. This option is recommended when you want to maximize
        /// compatibility across different clients in your environment. Supported only for S3
        /// File Gateway.</para><para><c>MandatorySigning</c>: If you choose this option, File Gateway only allows connections
        /// from SMBv2 or SMBv3 clients that have signing enabled. This option works with SMB
        /// clients on Microsoft Windows Vista, Windows Server 2008 or newer.</para><para><c>MandatoryEncryption</c>: If you choose this option, File Gateway only allows connections
        /// from SMBv3 clients that have encryption enabled. This option is recommended for environments
        /// that handle sensitive data. This option works with SMB clients on Microsoft Windows
        /// 8, Windows Server 2012 or newer.</para><para><c>MandatoryEncryptionNoAes128</c>: If you choose this option, File Gateway only
        /// allows connections from SMBv3 clients that use 256-bit AES encryption algorithms.
        /// 128-bit algorithms are not allowed. This option is recommended for environments that
        /// handle sensitive data. It works with SMB clients on Microsoft Windows 8, Windows Server
        /// 2012, or later.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.StorageGateway.SMBSecurityStrategy")]
        public Amazon.StorageGateway.SMBSecurityStrategy SMBSecurityStrategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayARN";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGSMBSecurityStrategy (UpdateSMBSecurityStrategy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse, UpdateSGSMBSecurityStrategyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SMBSecurityStrategy = this.SMBSecurityStrategy;
            #if MODULAR
            if (this.SMBSecurityStrategy == null && ParameterWasBound(nameof(this.SMBSecurityStrategy)))
            {
                WriteWarning("You are passing $null as a value for parameter SMBSecurityStrategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.SMBSecurityStrategy != null)
            {
                request.SMBSecurityStrategy = cmdletContext.SMBSecurityStrategy;
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
        
        private Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateSMBSecurityStrategy");
            try
            {
                #if DESKTOP
                return client.UpdateSMBSecurityStrategy(request);
                #elif CORECLR
                return client.UpdateSMBSecurityStrategyAsync(request).GetAwaiter().GetResult();
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
            public System.String GatewayARN { get; set; }
            public Amazon.StorageGateway.SMBSecurityStrategy SMBSecurityStrategy { get; set; }
            public System.Func<Amazon.StorageGateway.Model.UpdateSMBSecurityStrategyResponse, UpdateSGSMBSecurityStrategyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayARN;
        }
        
    }
}
