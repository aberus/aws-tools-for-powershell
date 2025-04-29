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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Updates an existing Amazon Bedrock Data Automation Blueprint
    /// </summary>
    [Cmdlet("Update", "BDABlueprint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockDataAutomation.Model.Blueprint")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock UpdateBlueprint API operation.", Operation = new[] {"UpdateBlueprint"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomation.Model.Blueprint or Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse",
        "This cmdlet returns an Amazon.BedrockDataAutomation.Model.Blueprint object.",
        "The service call response (type Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateBDABlueprintCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BlueprintArn
        /// <summary>
        /// <para>
        /// <para>ARN generated at the server side when a Blueprint is created</para>
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
        public System.String BlueprintArn { get; set; }
        #endregion
        
        #region Parameter BlueprintStage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.BlueprintStage")]
        public Amazon.BedrockDataAutomation.BlueprintStage BlueprintStage { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsEncryptionContext
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KmsEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Schema
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Schema { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Blueprint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Blueprint";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BlueprintArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDABlueprint (UpdateBlueprint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse, UpdateBDABlueprintCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlueprintArn = this.BlueprintArn;
            #if MODULAR
            if (this.BlueprintArn == null && ParameterWasBound(nameof(this.BlueprintArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BlueprintArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlueprintStage = this.BlueprintStage;
            if (this.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                context.EncryptionConfiguration_KmsEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionConfiguration_KmsEncryptionContext.Keys)
                {
                    context.EncryptionConfiguration_KmsEncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionConfiguration_KmsEncryptionContext[hashKey]));
                }
            }
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.Schema = this.Schema;
            #if MODULAR
            if (this.Schema == null && ParameterWasBound(nameof(this.Schema)))
            {
                WriteWarning("You are passing $null as a value for parameter Schema which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockDataAutomation.Model.UpdateBlueprintRequest();
            
            if (cmdletContext.BlueprintArn != null)
            {
                request.BlueprintArn = cmdletContext.BlueprintArn;
            }
            if (cmdletContext.BlueprintStage != null)
            {
                request.BlueprintStage = cmdletContext.BlueprintStage;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.BedrockDataAutomation.Model.EncryptionConfiguration();
            Dictionary<System.String, System.String> requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = null;
            if (cmdletContext.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = cmdletContext.EncryptionConfiguration_KmsEncryptionContext;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext != null)
            {
                request.EncryptionConfiguration.KmsEncryptionContext = requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.Schema != null)
            {
                request.Schema = cmdletContext.Schema;
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
        
        private Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.UpdateBlueprintRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "UpdateBlueprint");
            try
            {
                return client.UpdateBlueprintAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BlueprintArn { get; set; }
            public Amazon.BedrockDataAutomation.BlueprintStage BlueprintStage { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public System.String Schema { get; set; }
            public System.Func<Amazon.BedrockDataAutomation.Model.UpdateBlueprintResponse, UpdateBDABlueprintCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Blueprint;
        }
        
    }
}
