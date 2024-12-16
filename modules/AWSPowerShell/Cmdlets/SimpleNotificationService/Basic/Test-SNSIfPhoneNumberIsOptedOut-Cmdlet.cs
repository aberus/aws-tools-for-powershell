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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Accepts a phone number and indicates whether the phone holder has opted out of receiving
    /// SMS messages from your Amazon Web Services account. You cannot send SMS messages to
    /// a number that is opted out.
    /// 
    ///  
    /// <para>
    /// To resume sending messages, you can opt in the number by using the <c>OptInPhoneNumber</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "SNSIfPhoneNumberIsOptedOut")]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) CheckIfPhoneNumberIsOptedOut API operation.", Operation = new[] {"CheckIfPhoneNumberIsOptedOut"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestSNSIfPhoneNumberIsOptedOutCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number for which you want to check the opt out status.</para>
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
        public System.String PhoneNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IsOptedOut'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse).
        /// Specifying the name of a property of type Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IsOptedOut";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PhoneNumber parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PhoneNumber' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PhoneNumber' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse, TestSNSIfPhoneNumberIsOptedOutCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PhoneNumber;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PhoneNumber = this.PhoneNumber;
            #if MODULAR
            if (this.PhoneNumber == null && ParameterWasBound(nameof(this.PhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutRequest();
            
            if (cmdletContext.PhoneNumber != null)
            {
                request.PhoneNumber = cmdletContext.PhoneNumber;
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
        
        private Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "CheckIfPhoneNumberIsOptedOut");
            try
            {
                #if DESKTOP
                return client.CheckIfPhoneNumberIsOptedOut(request);
                #elif CORECLR
                return client.CheckIfPhoneNumberIsOptedOutAsync(request).GetAwaiter().GetResult();
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
            public System.String PhoneNumber { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.CheckIfPhoneNumberIsOptedOutResponse, TestSNSIfPhoneNumberIsOptedOutCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IsOptedOut;
        }
        
    }
}
