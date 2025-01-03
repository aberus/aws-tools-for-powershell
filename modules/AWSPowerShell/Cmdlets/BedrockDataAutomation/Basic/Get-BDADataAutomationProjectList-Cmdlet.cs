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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Lists all existing Amazon Bedrock Data Automation Projects<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BDADataAutomationProjectList")]
    [OutputType("Amazon.BedrockDataAutomation.Model.DataAutomationProjectSummary")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock ListDataAutomationProjects API operation.", Operation = new[] {"ListDataAutomationProjects"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomation.Model.DataAutomationProjectSummary or Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse",
        "This cmdlet returns a collection of Amazon.BedrockDataAutomation.Model.DataAutomationProjectSummary objects.",
        "The service call response (type Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDADataAutomationProjectListCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BlueprintFilter_BlueprintArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BlueprintFilter_BlueprintArn { get; set; }
        #endregion
        
        #region Parameter BlueprintFilter_BlueprintStage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.BlueprintStage")]
        public Amazon.BedrockDataAutomation.BlueprintStage BlueprintFilter_BlueprintStage { get; set; }
        #endregion
        
        #region Parameter BlueprintFilter_BlueprintVersion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BlueprintFilter_BlueprintVersion { get; set; }
        #endregion
        
        #region Parameter ProjectStageFilter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DataAutomationProjectStageFilter")]
        public Amazon.BedrockDataAutomation.DataAutomationProjectStageFilter ProjectStageFilter { get; set; }
        #endregion
        
        #region Parameter ResourceOwner
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.ResourceOwner")]
        public Amazon.BedrockDataAutomation.ResourceOwner ResourceOwner { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Projects'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Projects";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse, GetBDADataAutomationProjectListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlueprintFilter_BlueprintArn = this.BlueprintFilter_BlueprintArn;
            context.BlueprintFilter_BlueprintStage = this.BlueprintFilter_BlueprintStage;
            context.BlueprintFilter_BlueprintVersion = this.BlueprintFilter_BlueprintVersion;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProjectStageFilter = this.ProjectStageFilter;
            context.ResourceOwner = this.ResourceOwner;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsRequest();
            
            
             // populate BlueprintFilter
            var requestBlueprintFilterIsNull = true;
            request.BlueprintFilter = new Amazon.BedrockDataAutomation.Model.BlueprintFilter();
            System.String requestBlueprintFilter_blueprintFilter_BlueprintArn = null;
            if (cmdletContext.BlueprintFilter_BlueprintArn != null)
            {
                requestBlueprintFilter_blueprintFilter_BlueprintArn = cmdletContext.BlueprintFilter_BlueprintArn;
            }
            if (requestBlueprintFilter_blueprintFilter_BlueprintArn != null)
            {
                request.BlueprintFilter.BlueprintArn = requestBlueprintFilter_blueprintFilter_BlueprintArn;
                requestBlueprintFilterIsNull = false;
            }
            Amazon.BedrockDataAutomation.BlueprintStage requestBlueprintFilter_blueprintFilter_BlueprintStage = null;
            if (cmdletContext.BlueprintFilter_BlueprintStage != null)
            {
                requestBlueprintFilter_blueprintFilter_BlueprintStage = cmdletContext.BlueprintFilter_BlueprintStage;
            }
            if (requestBlueprintFilter_blueprintFilter_BlueprintStage != null)
            {
                request.BlueprintFilter.BlueprintStage = requestBlueprintFilter_blueprintFilter_BlueprintStage;
                requestBlueprintFilterIsNull = false;
            }
            System.String requestBlueprintFilter_blueprintFilter_BlueprintVersion = null;
            if (cmdletContext.BlueprintFilter_BlueprintVersion != null)
            {
                requestBlueprintFilter_blueprintFilter_BlueprintVersion = cmdletContext.BlueprintFilter_BlueprintVersion;
            }
            if (requestBlueprintFilter_blueprintFilter_BlueprintVersion != null)
            {
                request.BlueprintFilter.BlueprintVersion = requestBlueprintFilter_blueprintFilter_BlueprintVersion;
                requestBlueprintFilterIsNull = false;
            }
             // determine if request.BlueprintFilter should be set to null
            if (requestBlueprintFilterIsNull)
            {
                request.BlueprintFilter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ProjectStageFilter != null)
            {
                request.ProjectStageFilter = cmdletContext.ProjectStageFilter;
            }
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "ListDataAutomationProjects");
            try
            {
                #if DESKTOP
                return client.ListDataAutomationProjects(request);
                #elif CORECLR
                return client.ListDataAutomationProjectsAsync(request).GetAwaiter().GetResult();
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
            public System.String BlueprintFilter_BlueprintArn { get; set; }
            public Amazon.BedrockDataAutomation.BlueprintStage BlueprintFilter_BlueprintStage { get; set; }
            public System.String BlueprintFilter_BlueprintVersion { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.BedrockDataAutomation.DataAutomationProjectStageFilter ProjectStageFilter { get; set; }
            public Amazon.BedrockDataAutomation.ResourceOwner ResourceOwner { get; set; }
            public System.Func<Amazon.BedrockDataAutomation.Model.ListDataAutomationProjectsResponse, GetBDADataAutomationProjectListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Projects;
        }
        
    }
}
