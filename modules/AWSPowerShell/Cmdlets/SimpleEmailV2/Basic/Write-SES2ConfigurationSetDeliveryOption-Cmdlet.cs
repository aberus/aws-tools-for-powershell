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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Associate a configuration set with a dedicated IP pool. You can use dedicated IP pools
    /// to create groups of dedicated IP addresses for sending specific types of email.
    /// </summary>
    [Cmdlet("Write", "SES2ConfigurationSetDeliveryOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutConfigurationSetDeliveryOptions API operation.", Operation = new[] {"PutConfigurationSetDeliveryOptions"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSES2ConfigurationSetDeliveryOptionCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to associate with a dedicated IP pool.</para>
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
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter MaxDeliverySecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that Amazon SES API v2 will attempt delivery
        /// of email. If specified, the value must greater than or equal to 300 seconds (5 minutes)
        /// and less than or equal to 50400 seconds (840 minutes). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxDeliverySeconds")]
        public System.Int64? MaxDeliverySecond { get; set; }
        #endregion
        
        #region Parameter SendingPoolName
        /// <summary>
        /// <para>
        /// <para>The name of the dedicated IP pool to associate with the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SendingPoolName { get; set; }
        #endregion
        
        #region Parameter TlsPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether messages that use the configuration set are required to use Transport
        /// Layer Security (TLS). If the value is <c>Require</c>, messages are only delivered
        /// if a TLS connection can be established. If the value is <c>Optional</c>, messages
        /// can be delivered in plain text if a TLS connection can't be established.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.TlsPolicy")]
        public Amazon.SimpleEmailV2.TlsPolicy TlsPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2ConfigurationSetDeliveryOption (PutConfigurationSetDeliveryOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsResponse, WriteSES2ConfigurationSetDeliveryOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxDeliverySecond = this.MaxDeliverySecond;
            context.SendingPoolName = this.SendingPoolName;
            context.TlsPolicy = this.TlsPolicy;
            
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
            var request = new Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.MaxDeliverySecond != null)
            {
                request.MaxDeliverySeconds = cmdletContext.MaxDeliverySecond.Value;
            }
            if (cmdletContext.SendingPoolName != null)
            {
                request.SendingPoolName = cmdletContext.SendingPoolName;
            }
            if (cmdletContext.TlsPolicy != null)
            {
                request.TlsPolicy = cmdletContext.TlsPolicy;
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
        
        private Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutConfigurationSetDeliveryOptions");
            try
            {
                return client.PutConfigurationSetDeliveryOptionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public System.Int64? MaxDeliverySecond { get; set; }
            public System.String SendingPoolName { get; set; }
            public Amazon.SimpleEmailV2.TlsPolicy TlsPolicy { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutConfigurationSetDeliveryOptionsResponse, WriteSES2ConfigurationSetDeliveryOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
