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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Gets information about a data source.
    /// </summary>
    [Cmdlet("Get", "AABDataSource")]
    [OutputType("Amazon.BedrockAgent.Model.DataSource")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock GetDataSource API operation.", Operation = new[] {"GetDataSource"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.GetDataSourceResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.DataSource or Amazon.BedrockAgent.Model.GetDataSourceResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.DataSource object.",
        "The service call response (type Amazon.BedrockAgent.Model.GetDataSourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAABDataSourceCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the data source.</para>
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
        public System.String DataSourceId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the knowledge base for the data source.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSource'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.GetDataSourceResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.GetDataSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSource";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.GetDataSourceResponse, GetAABDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataSourceId = this.DataSourceId;
            #if MODULAR
            if (this.DataSourceId == null && ParameterWasBound(nameof(this.DataSourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgent.Model.GetDataSourceRequest();
            
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
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
        
        private Amazon.BedrockAgent.Model.GetDataSourceResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.GetDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "GetDataSource");
            try
            {
                #if DESKTOP
                return client.GetDataSource(request);
                #elif CORECLR
                return client.GetDataSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String DataSourceId { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.GetDataSourceResponse, GetAABDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSource;
        }
        
    }
}
