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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Retrieves Amazon Inspector deep inspection activation status of multiple member accounts
    /// within your organization. You must be the delegated administrator of an organization
    /// in Amazon Inspector to use this API.
    /// </summary>
    [Cmdlet("Get", "INS2BatchMemberEc2DeepInspectionStatus")]
    [OutputType("Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse")]
    [AWSCmdlet("Calls the Inspector2 BatchGetMemberEc2DeepInspectionStatus API operation.", Operation = new[] {"BatchGetMemberEc2DeepInspectionStatus"}, SelectReturnType = typeof(Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse object containing multiple properties."
    )]
    public partial class GetINS2BatchMemberEc2DeepInspectionStatusCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusRequest.AccountIds
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse, GetINS2BatchMemberEc2DeepInspectionStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            
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
            var request = new Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
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
        
        private Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "BatchGetMemberEc2DeepInspectionStatus");
            try
            {
                #if DESKTOP
                return client.BatchGetMemberEc2DeepInspectionStatus(request);
                #elif CORECLR
                return client.BatchGetMemberEc2DeepInspectionStatusAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public System.Func<Amazon.Inspector2.Model.BatchGetMemberEc2DeepInspectionStatusResponse, GetINS2BatchMemberEc2DeepInspectionStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
