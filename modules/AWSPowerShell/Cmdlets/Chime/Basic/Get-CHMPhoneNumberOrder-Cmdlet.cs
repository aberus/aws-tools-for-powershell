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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Retrieves details for the specified phone number order, such as the order creation
    /// timestamp, phone numbers in E.164 format, product type, and order status.
    /// </summary>
    [Cmdlet("Get", "CHMPhoneNumberOrder")]
    [OutputType("Amazon.Chime.Model.PhoneNumberOrder")]
    [AWSCmdlet("Calls the Amazon Chime GetPhoneNumberOrder API operation.", Operation = new[] {"GetPhoneNumberOrder"}, SelectReturnType = typeof(Amazon.Chime.Model.GetPhoneNumberOrderResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.PhoneNumberOrder or Amazon.Chime.Model.GetPhoneNumberOrderResponse",
        "This cmdlet returns an Amazon.Chime.Model.PhoneNumberOrder object.",
        "The service call response (type Amazon.Chime.Model.GetPhoneNumberOrderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCHMPhoneNumberOrderCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PhoneNumberOrderId
        /// <summary>
        /// <para>
        /// <para>The ID for the phone number order.</para>
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
        public System.String PhoneNumberOrderId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PhoneNumberOrder'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.GetPhoneNumberOrderResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.GetPhoneNumberOrderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PhoneNumberOrder";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.GetPhoneNumberOrderResponse, GetCHMPhoneNumberOrderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PhoneNumberOrderId = this.PhoneNumberOrderId;
            #if MODULAR
            if (this.PhoneNumberOrderId == null && ParameterWasBound(nameof(this.PhoneNumberOrderId)))
            {
                WriteWarning("You are passing $null as a value for parameter PhoneNumberOrderId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chime.Model.GetPhoneNumberOrderRequest();
            
            if (cmdletContext.PhoneNumberOrderId != null)
            {
                request.PhoneNumberOrderId = cmdletContext.PhoneNumberOrderId;
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
        
        private Amazon.Chime.Model.GetPhoneNumberOrderResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.GetPhoneNumberOrderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "GetPhoneNumberOrder");
            try
            {
                #if DESKTOP
                return client.GetPhoneNumberOrder(request);
                #elif CORECLR
                return client.GetPhoneNumberOrderAsync(request).GetAwaiter().GetResult();
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
            public System.String PhoneNumberOrderId { get; set; }
            public System.Func<Amazon.Chime.Model.GetPhoneNumberOrderResponse, GetCHMPhoneNumberOrderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PhoneNumberOrder;
        }
        
    }
}
