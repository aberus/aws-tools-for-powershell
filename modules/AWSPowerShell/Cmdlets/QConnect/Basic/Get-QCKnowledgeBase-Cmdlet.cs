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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Retrieves information about the knowledge base.
    /// </summary>
    [Cmdlet("Get", "QCKnowledgeBase")]
    [OutputType("Amazon.QConnect.Model.KnowledgeBaseData")]
    [AWSCmdlet("Calls the Amazon Q Connect GetKnowledgeBase API operation.", Operation = new[] {"GetKnowledgeBase"}, SelectReturnType = typeof(Amazon.QConnect.Model.GetKnowledgeBaseResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.KnowledgeBaseData or Amazon.QConnect.Model.GetKnowledgeBaseResponse",
        "This cmdlet returns an Amazon.QConnect.Model.KnowledgeBaseData object.",
        "The service call response (type Amazon.QConnect.Model.GetKnowledgeBaseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetQCKnowledgeBaseCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. Can be either the ID or the ARN. URLs cannot
        /// contain the ARN.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KnowledgeBase'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.GetKnowledgeBaseResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.GetKnowledgeBaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KnowledgeBase";
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
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.GetKnowledgeBaseResponse, GetQCKnowledgeBaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.GetKnowledgeBaseRequest();
            
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
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
        
        private Amazon.QConnect.Model.GetKnowledgeBaseResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.GetKnowledgeBaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "GetKnowledgeBase");
            try
            {
                #if DESKTOP
                return client.GetKnowledgeBase(request);
                #elif CORECLR
                return client.GetKnowledgeBaseAsync(request).GetAwaiter().GetResult();
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
            public System.String KnowledgeBaseId { get; set; }
            public System.Func<Amazon.QConnect.Model.GetKnowledgeBaseResponse, GetQCKnowledgeBaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KnowledgeBase;
        }
        
    }
}
