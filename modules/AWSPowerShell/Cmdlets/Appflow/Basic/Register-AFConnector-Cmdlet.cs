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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Registers a new custom connector with your Amazon Web Services account. Before you
    /// can register the connector, you must deploy the associated AWS lambda function in
    /// your account.
    /// </summary>
    [Cmdlet("Register", "AFConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Appflow RegisterConnector API operation.", Operation = new[] {"RegisterConnector"}, SelectReturnType = typeof(Amazon.Appflow.Model.RegisterConnectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.Appflow.Model.RegisterConnectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Appflow.Model.RegisterConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterAFConnectorCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectorLabel
        /// <summary>
        /// <para>
        /// <para> The name of the connector. The name is unique for each <c>ConnectorRegistration</c>
        /// in your Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectorLabel { get; set; }
        #endregion
        
        #region Parameter ConnectorProvisioningType
        /// <summary>
        /// <para>
        /// <para>The provisioning type of the connector. Currently the only supported value is LAMBDA.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Appflow.ConnectorProvisioningType")]
        public Amazon.Appflow.ConnectorProvisioningType ConnectorProvisioningType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description about the connector that's being registered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Lambda_LambdaArn
        /// <summary>
        /// <para>
        /// <para>Lambda ARN of the connector being registered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectorProvisioningConfig_Lambda_LambdaArn")]
        public System.String Lambda_LambdaArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The <c>clientToken</c> parameter is an idempotency token. It ensures that your <c>RegisterConnector</c>
        /// request completes only once. You choose the value to pass. For example, if you don't
        /// receive a response from your request, you can safely retry the request with the same
        /// <c>clientToken</c> parameter value.</para><para>If you omit a <c>clientToken</c> value, the Amazon Web Services SDK that you are using
        /// inserts a value for you. This way, the SDK can safely retry requests multiple times
        /// after a network error. You must provide your own value for other use cases.</para><para>If you specify input parameters that differ from your first request, an error occurs.
        /// If you use a different value for <c>clientToken</c>, Amazon AppFlow considers it a
        /// new call to <c>RegisterConnector</c>. The token is active for 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.RegisterConnectorResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.RegisterConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Lambda_LambdaArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-AFConnector (RegisterConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.RegisterConnectorResponse, RegisterAFConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectorLabel = this.ConnectorLabel;
            context.Lambda_LambdaArn = this.Lambda_LambdaArn;
            context.ConnectorProvisioningType = this.ConnectorProvisioningType;
            context.Description = this.Description;
            
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
            var request = new Amazon.Appflow.Model.RegisterConnectorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectorLabel != null)
            {
                request.ConnectorLabel = cmdletContext.ConnectorLabel;
            }
            
             // populate ConnectorProvisioningConfig
            var requestConnectorProvisioningConfigIsNull = true;
            request.ConnectorProvisioningConfig = new Amazon.Appflow.Model.ConnectorProvisioningConfig();
            Amazon.Appflow.Model.LambdaConnectorProvisioningConfig requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda = null;
            
             // populate Lambda
            var requestConnectorProvisioningConfig_connectorProvisioningConfig_LambdaIsNull = true;
            requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda = new Amazon.Appflow.Model.LambdaConnectorProvisioningConfig();
            System.String requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn = null;
            if (cmdletContext.Lambda_LambdaArn != null)
            {
                requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn = cmdletContext.Lambda_LambdaArn;
            }
            if (requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn != null)
            {
                requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda.LambdaArn = requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda_lambda_LambdaArn;
                requestConnectorProvisioningConfig_connectorProvisioningConfig_LambdaIsNull = false;
            }
             // determine if requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda should be set to null
            if (requestConnectorProvisioningConfig_connectorProvisioningConfig_LambdaIsNull)
            {
                requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda = null;
            }
            if (requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda != null)
            {
                request.ConnectorProvisioningConfig.Lambda = requestConnectorProvisioningConfig_connectorProvisioningConfig_Lambda;
                requestConnectorProvisioningConfigIsNull = false;
            }
             // determine if request.ConnectorProvisioningConfig should be set to null
            if (requestConnectorProvisioningConfigIsNull)
            {
                request.ConnectorProvisioningConfig = null;
            }
            if (cmdletContext.ConnectorProvisioningType != null)
            {
                request.ConnectorProvisioningType = cmdletContext.ConnectorProvisioningType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.Appflow.Model.RegisterConnectorResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.RegisterConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "RegisterConnector");
            try
            {
                #if DESKTOP
                return client.RegisterConnector(request);
                #elif CORECLR
                return client.RegisterConnectorAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectorLabel { get; set; }
            public System.String Lambda_LambdaArn { get; set; }
            public Amazon.Appflow.ConnectorProvisioningType ConnectorProvisioningType { get; set; }
            public System.String Description { get; set; }
            public System.Func<Amazon.Appflow.Model.RegisterConnectorResponse, RegisterAFConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorArn;
        }
        
    }
}
