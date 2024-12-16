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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Sets the logging options.
    /// 
    ///  
    /// <para>
    /// NOTE: use of this command is not recommended. Use <c>SetV2LoggingOptions</c> instead.
    /// </para><para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">SetLoggingOptions</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "IOTLoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT SetLoggingOptions API operation.", Operation = new[] {"SetLoggingOptions"}, SelectReturnType = typeof(Amazon.IoT.Model.SetLoggingOptionsResponse), LegacyAlias="Set-IOTLoggingOptions")]
    [AWSCmdletOutput("None or Amazon.IoT.Model.SetLoggingOptionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.SetLoggingOptionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetIOTLoggingOptionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoggingOptionsPayload_LogLevel
        /// <summary>
        /// <para>
        /// <para>The log level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.LogLevel")]
        public Amazon.IoT.LogLevel LoggingOptionsPayload_LogLevel { get; set; }
        #endregion
        
        #region Parameter LoggingOptionsPayload_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access.</para>
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
        public System.String LoggingOptionsPayload_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.SetLoggingOptionsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoggingOptionsPayload_RoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTLoggingOption (SetLoggingOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.SetLoggingOptionsResponse, SetIOTLoggingOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoggingOptionsPayload_LogLevel = this.LoggingOptionsPayload_LogLevel;
            context.LoggingOptionsPayload_RoleArn = this.LoggingOptionsPayload_RoleArn;
            #if MODULAR
            if (this.LoggingOptionsPayload_RoleArn == null && ParameterWasBound(nameof(this.LoggingOptionsPayload_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggingOptionsPayload_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.SetLoggingOptionsRequest();
            
            
             // populate LoggingOptionsPayload
            var requestLoggingOptionsPayloadIsNull = true;
            request.LoggingOptionsPayload = new Amazon.IoT.Model.LoggingOptionsPayload();
            Amazon.IoT.LogLevel requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel = null;
            if (cmdletContext.LoggingOptionsPayload_LogLevel != null)
            {
                requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel = cmdletContext.LoggingOptionsPayload_LogLevel;
            }
            if (requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel != null)
            {
                request.LoggingOptionsPayload.LogLevel = requestLoggingOptionsPayload_loggingOptionsPayload_LogLevel;
                requestLoggingOptionsPayloadIsNull = false;
            }
            System.String requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn = null;
            if (cmdletContext.LoggingOptionsPayload_RoleArn != null)
            {
                requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn = cmdletContext.LoggingOptionsPayload_RoleArn;
            }
            if (requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn != null)
            {
                request.LoggingOptionsPayload.RoleArn = requestLoggingOptionsPayload_loggingOptionsPayload_RoleArn;
                requestLoggingOptionsPayloadIsNull = false;
            }
             // determine if request.LoggingOptionsPayload should be set to null
            if (requestLoggingOptionsPayloadIsNull)
            {
                request.LoggingOptionsPayload = null;
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
        
        private Amazon.IoT.Model.SetLoggingOptionsResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.SetLoggingOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "SetLoggingOptions");
            try
            {
                #if DESKTOP
                return client.SetLoggingOptions(request);
                #elif CORECLR
                return client.SetLoggingOptionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoT.LogLevel LoggingOptionsPayload_LogLevel { get; set; }
            public System.String LoggingOptionsPayload_RoleArn { get; set; }
            public System.Func<Amazon.IoT.Model.SetLoggingOptionsResponse, SetIOTLoggingOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
