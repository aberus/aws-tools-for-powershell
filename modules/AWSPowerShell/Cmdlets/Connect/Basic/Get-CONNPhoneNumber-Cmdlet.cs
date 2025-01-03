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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Gets details and status of a phone number that’s claimed to your Amazon Connect instance
    /// or traffic distribution group.
    /// 
    ///  <important><para>
    /// If the number is claimed to a traffic distribution group, and you are calling in the
    /// Amazon Web Services Region where the traffic distribution group was created, you can
    /// use either a phone number ARN or UUID value for the <c>PhoneNumberId</c> URI request
    /// parameter. However, if the number is claimed to a traffic distribution group and you
    /// are calling this API in the alternate Amazon Web Services Region associated with the
    /// traffic distribution group, you must provide a full phone number ARN. If a UUID is
    /// provided in this scenario, you receive a <c>ResourceNotFoundException</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "CONNPhoneNumber")]
    [OutputType("Amazon.Connect.Model.ClaimedPhoneNumberSummary")]
    [AWSCmdlet("Calls the Amazon Connect Service DescribePhoneNumber API operation.", Operation = new[] {"DescribePhoneNumber"}, SelectReturnType = typeof(Amazon.Connect.Model.DescribePhoneNumberResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.ClaimedPhoneNumberSummary or Amazon.Connect.Model.DescribePhoneNumberResponse",
        "This cmdlet returns an Amazon.Connect.Model.ClaimedPhoneNumberSummary object.",
        "The service call response (type Amazon.Connect.Model.DescribePhoneNumberResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCONNPhoneNumberCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PhoneNumberId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the phone number.</para>
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
        public System.String PhoneNumberId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClaimedPhoneNumberSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.DescribePhoneNumberResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.DescribePhoneNumberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClaimedPhoneNumberSummary";
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
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.DescribePhoneNumberResponse, GetCONNPhoneNumberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PhoneNumberId = this.PhoneNumberId;
            #if MODULAR
            if (this.PhoneNumberId == null && ParameterWasBound(nameof(this.PhoneNumberId)))
            {
                WriteWarning("You are passing $null as a value for parameter PhoneNumberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.DescribePhoneNumberRequest();
            
            if (cmdletContext.PhoneNumberId != null)
            {
                request.PhoneNumberId = cmdletContext.PhoneNumberId;
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
        
        private Amazon.Connect.Model.DescribePhoneNumberResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.DescribePhoneNumberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "DescribePhoneNumber");
            try
            {
                #if DESKTOP
                return client.DescribePhoneNumber(request);
                #elif CORECLR
                return client.DescribePhoneNumberAsync(request).GetAwaiter().GetResult();
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
            public System.String PhoneNumberId { get; set; }
            public System.Func<Amazon.Connect.Model.DescribePhoneNumberResponse, GetCONNPhoneNumberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClaimedPhoneNumberSummary;
        }
        
    }
}
