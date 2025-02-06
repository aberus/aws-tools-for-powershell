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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Updates properties on a ledger.
    /// </summary>
    [Cmdlet("Update", "QLDBLedger", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QLDB.Model.UpdateLedgerResponse")]
    [AWSCmdlet("Calls the Amazon QLDB UpdateLedger API operation.", Operation = new[] {"UpdateLedger"}, SelectReturnType = typeof(Amazon.QLDB.Model.UpdateLedgerResponse))]
    [AWSCmdletOutput("Amazon.QLDB.Model.UpdateLedgerResponse",
        "This cmdlet returns an Amazon.QLDB.Model.UpdateLedgerResponse object containing multiple properties."
    )]
    public partial class UpdateQLDBLedgerCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the ledger is protected from being deleted by any user. If not defined
        /// during ledger creation, this feature is enabled (<c>true</c>) by default.</para><para>If deletion protection is enabled, you must first disable it before you can delete
        /// the ledger. You can disable it by calling the <c>UpdateLedger</c> operation to set
        /// this parameter to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter KmsKey
        /// <summary>
        /// <para>
        /// <para>The key in Key Management Service (KMS) to use for encryption of data at rest in the
        /// ledger. For more information, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/encryption-at-rest.html">Encryption
        /// at rest</a> in the <i>Amazon QLDB Developer Guide</i>.</para><para>Use one of the following options to specify this parameter:</para><ul><li><para><c>AWS_OWNED_KMS_KEY</c>: Use an KMS key that is owned and managed by Amazon Web
        /// Services on your behalf.</para></li><li><para><b>Undefined</b>: Make no changes to the KMS key of the ledger.</para></li><li><para><b>A valid symmetric customer managed KMS key</b>: Use the specified symmetric encryption
        /// KMS key in your account that you create, own, and manage.</para><para>Amazon QLDB does not support asymmetric keys. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
        /// symmetric and asymmetric keys</a> in the <i>Key Management Service Developer Guide</i>.</para></li></ul><para>To specify a customer managed KMS key, you can use its key ID, Amazon Resource Name
        /// (ARN), alias name, or alias ARN. When using an alias name, prefix it with <c>"alias/"</c>.
        /// To specify a key in a different Amazon Web Services account, you must use the key
        /// ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// identifiers (KeyId)</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the ledger.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.UpdateLedgerResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.UpdateLedgerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QLDBLedger (UpdateLedger)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.UpdateLedgerResponse, UpdateQLDBLedgerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionProtection = this.DeletionProtection;
            context.KmsKey = this.KmsKey;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QLDB.Model.UpdateLedgerRequest();
            
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.KmsKey != null)
            {
                request.KmsKey = cmdletContext.KmsKey;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.QLDB.Model.UpdateLedgerResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.UpdateLedgerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "UpdateLedger");
            try
            {
                #if DESKTOP
                return client.UpdateLedger(request);
                #elif CORECLR
                return client.UpdateLedgerAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtection { get; set; }
            public System.String KmsKey { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.QLDB.Model.UpdateLedgerResponse, UpdateQLDBLedgerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
