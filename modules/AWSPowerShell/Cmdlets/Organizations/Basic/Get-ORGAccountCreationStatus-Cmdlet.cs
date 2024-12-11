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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Retrieves the current status of an asynchronous request to create an account.
    /// 
    ///  
    /// <para>
    /// This operation can be called only from the organization's management account or by
    /// a member account that is a delegated administrator for an Amazon Web Services service.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ORGAccountCreationStatus")]
    [OutputType("Amazon.Organizations.Model.CreateAccountStatus")]
    [AWSCmdlet("Calls the AWS Organizations DescribeCreateAccountStatus API operation.", Operation = new[] {"DescribeCreateAccountStatus"}, SelectReturnType = typeof(Amazon.Organizations.Model.DescribeCreateAccountStatusResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.CreateAccountStatus or Amazon.Organizations.Model.DescribeCreateAccountStatusResponse",
        "This cmdlet returns an Amazon.Organizations.Model.CreateAccountStatus object.",
        "The service call response (type Amazon.Organizations.Model.DescribeCreateAccountStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetORGAccountCreationStatusCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreateAccountRequestId
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>Id</c> value that uniquely identifies the <c>CreateAccount</c> request.
        /// You can get the value from the <c>CreateAccountStatus.Id</c> response in an earlier
        /// <a>CreateAccount</a> request, or from the <a>ListCreateAccountStatus</a> operation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for a create account
        /// request ID string requires "car-" followed by from 8 to 32 lowercase letters or digits.</para>
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
        public System.String CreateAccountRequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CreateAccountStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.DescribeCreateAccountStatusResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.DescribeCreateAccountStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CreateAccountStatus";
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
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.DescribeCreateAccountStatusResponse, GetORGAccountCreationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreateAccountRequestId = this.CreateAccountRequestId;
            #if MODULAR
            if (this.CreateAccountRequestId == null && ParameterWasBound(nameof(this.CreateAccountRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter CreateAccountRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Organizations.Model.DescribeCreateAccountStatusRequest();
            
            if (cmdletContext.CreateAccountRequestId != null)
            {
                request.CreateAccountRequestId = cmdletContext.CreateAccountRequestId;
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
        
        private Amazon.Organizations.Model.DescribeCreateAccountStatusResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DescribeCreateAccountStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DescribeCreateAccountStatus");
            try
            {
                #if DESKTOP
                return client.DescribeCreateAccountStatus(request);
                #elif CORECLR
                return client.DescribeCreateAccountStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String CreateAccountRequestId { get; set; }
            public System.Func<Amazon.Organizations.Model.DescribeCreateAccountStatusResponse, GetORGAccountCreationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CreateAccountStatus;
        }
        
    }
}
