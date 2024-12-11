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
using Amazon.MigrationHubStrategyRecommendations;
using Amazon.MigrationHubStrategyRecommendations.Model;

namespace Amazon.PowerShell.Cmdlets.MHS
{
    /// <summary>
    /// Retrieve the latest ID of a specific assessment task.
    /// </summary>
    [Cmdlet("Get", "MHSLatestAssessmentId")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations GetLatestAssessmentId API operation.", Operation = new[] {"GetLatestAssessmentId"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse))]
    [AWSCmdletOutput("System.String or Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMHSLatestAssessmentIdCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
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
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse, GetMHSLatestAssessmentIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdRequest();
            
            
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "GetLatestAssessmentId");
            try
            {
                #if DESKTOP
                return client.GetLatestAssessmentId(request);
                #elif CORECLR
                return client.GetLatestAssessmentIdAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.GetLatestAssessmentIdResponse, GetMHSLatestAssessmentIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
