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
using Amazon.OSIS;
using Amazon.OSIS.Model;

namespace Amazon.PowerShell.Cmdlets.OSIS
{
    /// <summary>
    /// Retrieves information about a specific blueprint for OpenSearch Ingestion. Blueprints
    /// are templates for the configuration needed for a <c>CreatePipeline</c> request. For
    /// more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/creating-pipeline.html#pipeline-blueprint">Using
    /// blueprints to create a pipeline</a>.
    /// </summary>
    [Cmdlet("Get", "OSISPipelineBlueprint")]
    [OutputType("Amazon.OSIS.Model.PipelineBlueprint")]
    [AWSCmdlet("Calls the Amazon OpenSearch Ingestion GetPipelineBlueprint API operation.", Operation = new[] {"GetPipelineBlueprint"}, SelectReturnType = typeof(Amazon.OSIS.Model.GetPipelineBlueprintResponse))]
    [AWSCmdletOutput("Amazon.OSIS.Model.PipelineBlueprint or Amazon.OSIS.Model.GetPipelineBlueprintResponse",
        "This cmdlet returns an Amazon.OSIS.Model.PipelineBlueprint object.",
        "The service call response (type Amazon.OSIS.Model.GetPipelineBlueprintResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOSISPipelineBlueprintCmdlet : AmazonOSISClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BlueprintName
        /// <summary>
        /// <para>
        /// <para>The name of the blueprint to retrieve.</para>
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
        public System.String BlueprintName { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format format of the blueprint to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Format { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Blueprint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OSIS.Model.GetPipelineBlueprintResponse).
        /// Specifying the name of a property of type Amazon.OSIS.Model.GetPipelineBlueprintResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Blueprint";
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
                context.Select = CreateSelectDelegate<Amazon.OSIS.Model.GetPipelineBlueprintResponse, GetOSISPipelineBlueprintCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlueprintName = this.BlueprintName;
            #if MODULAR
            if (this.BlueprintName == null && ParameterWasBound(nameof(this.BlueprintName)))
            {
                WriteWarning("You are passing $null as a value for parameter BlueprintName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Format = this.Format;
            
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
            var request = new Amazon.OSIS.Model.GetPipelineBlueprintRequest();
            
            if (cmdletContext.BlueprintName != null)
            {
                request.BlueprintName = cmdletContext.BlueprintName;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
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
        
        private Amazon.OSIS.Model.GetPipelineBlueprintResponse CallAWSServiceOperation(IAmazonOSIS client, Amazon.OSIS.Model.GetPipelineBlueprintRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Ingestion", "GetPipelineBlueprint");
            try
            {
                #if DESKTOP
                return client.GetPipelineBlueprint(request);
                #elif CORECLR
                return client.GetPipelineBlueprintAsync(request).GetAwaiter().GetResult();
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
            public System.String BlueprintName { get; set; }
            public System.String Format { get; set; }
            public System.Func<Amazon.OSIS.Model.GetPipelineBlueprintResponse, GetOSISPipelineBlueprintCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Blueprint;
        }
        
    }
}
