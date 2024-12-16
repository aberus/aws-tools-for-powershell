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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Deletes a guardrail.
    /// 
    ///  <ul><li><para>
    /// To delete a guardrail, only specify the ARN of the guardrail in the <c>guardrailIdentifier</c>
    /// field. If you delete a guardrail, all of its versions will be deleted.
    /// </para></li><li><para>
    /// To delete a version of a guardrail, specify the ARN of the guardrail in the <c>guardrailIdentifier</c>
    /// field and the version in the <c>guardrailVersion</c> field.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "BDRGuardrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Bedrock DeleteGuardrail API operation.", Operation = new[] {"DeleteGuardrail"}, SelectReturnType = typeof(Amazon.Bedrock.Model.DeleteGuardrailResponse))]
    [AWSCmdletOutput("None or Amazon.Bedrock.Model.DeleteGuardrailResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Bedrock.Model.DeleteGuardrailResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveBDRGuardrailCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the guardrail. This can be an ID or the ARN.</para>
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
        public System.String GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>The version of the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.DeleteGuardrailResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GuardrailIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-BDRGuardrail (DeleteGuardrail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.DeleteGuardrailResponse, RemoveBDRGuardrailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GuardrailIdentifier = this.GuardrailIdentifier;
            #if MODULAR
            if (this.GuardrailIdentifier == null && ParameterWasBound(nameof(this.GuardrailIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardrailIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuardrailVersion = this.GuardrailVersion;
            
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
            var request = new Amazon.Bedrock.Model.DeleteGuardrailRequest();
            
            if (cmdletContext.GuardrailIdentifier != null)
            {
                request.GuardrailIdentifier = cmdletContext.GuardrailIdentifier;
            }
            if (cmdletContext.GuardrailVersion != null)
            {
                request.GuardrailVersion = cmdletContext.GuardrailVersion;
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
        
        private Amazon.Bedrock.Model.DeleteGuardrailResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.DeleteGuardrailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "DeleteGuardrail");
            try
            {
                #if DESKTOP
                return client.DeleteGuardrail(request);
                #elif CORECLR
                return client.DeleteGuardrailAsync(request).GetAwaiter().GetResult();
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
            public System.String GuardrailIdentifier { get; set; }
            public System.String GuardrailVersion { get; set; }
            public System.Func<Amazon.Bedrock.Model.DeleteGuardrailResponse, RemoveBDRGuardrailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
