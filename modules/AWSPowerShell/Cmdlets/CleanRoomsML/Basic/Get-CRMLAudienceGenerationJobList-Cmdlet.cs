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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Returns a list of audience generation jobs.
    /// </summary>
    [Cmdlet("Get", "CRMLAudienceGenerationJobList")]
    [OutputType("Amazon.CleanRoomsML.Model.AudienceGenerationJobSummary")]
    [AWSCmdlet("Calls the CleanRoomsML ListAudienceGenerationJobs API operation.", Operation = new[] {"ListAudienceGenerationJobs"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse))]
    [AWSCmdletOutput("Amazon.CleanRoomsML.Model.AudienceGenerationJobSummary or Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse",
        "This cmdlet returns a collection of Amazon.CleanRoomsML.Model.AudienceGenerationJobSummary objects.",
        "The service call response (type Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCRMLAudienceGenerationJobListCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CollaborationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the collaboration that contains the audience generation jobs that
        /// you are interested in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CollaborationId { get; set; }
        #endregion
        
        #region Parameter ConfiguredAudienceModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configured audience model that was used for
        /// the audience generation jobs that you are interested in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfiguredAudienceModelArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum size of the results that is returned per call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token value retrieved from a previous call to access the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AudienceGenerationJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AudienceGenerationJobs";
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
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse, GetCRMLAudienceGenerationJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollaborationId = this.CollaborationId;
            context.ConfiguredAudienceModelArn = this.ConfiguredAudienceModelArn;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsRequest();
            
            if (cmdletContext.CollaborationId != null)
            {
                request.CollaborationId = cmdletContext.CollaborationId;
            }
            if (cmdletContext.ConfiguredAudienceModelArn != null)
            {
                request.ConfiguredAudienceModelArn = cmdletContext.ConfiguredAudienceModelArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "ListAudienceGenerationJobs");
            try
            {
                #if DESKTOP
                return client.ListAudienceGenerationJobs(request);
                #elif CORECLR
                return client.ListAudienceGenerationJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String CollaborationId { get; set; }
            public System.String ConfiguredAudienceModelArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.ListAudienceGenerationJobsResponse, GetCRMLAudienceGenerationJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AudienceGenerationJobs;
        }
        
    }
}
