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
using System.Threading;
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Predicts existing visuals or generates new visuals to answer a given query.
    /// 
    ///  
    /// <para>
    /// This API uses <a href="https://docs.aws.amazon.com/singlesignon/latest/userguide/trustedidentitypropagation.html">trusted
    /// identity propagation</a> to ensure that an end user is authenticated and receives
    /// the embed URL that is specific to that user. The IAM Identity Center application that
    /// the user has logged into needs to have <a href="https://docs.aws.amazon.com/singlesignon/latest/userguide/trustedidentitypropagation-using-customermanagedapps-specify-trusted-apps.html">trusted
    /// Identity Propagation enabled for Amazon QuickSight</a> with the scope value set to
    /// <c>quicksight:read</c>. Before you use this action, make sure that you have configured
    /// the relevant Amazon QuickSight resource and permissions.
    /// </para><para>
    /// We recommend enabling the <c>QSearchStatus</c> API to unlock the full potential of
    /// <c>PredictQnA</c>. When <c>QSearchStatus</c> is enabled, it first checks the specified
    /// dashboard for any existing visuals that match the question. If no matching visuals
    /// are found, <c>PredictQnA</c> uses generative Q&amp;A to provide an answer. To update
    /// the <c>QSearchStatus</c>, see <a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_UpdateQuickSightQSearchConfiguration.html">UpdateQuickSightQSearchConfiguration</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "QSQAResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.PredictQAResultsResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight PredictQAResults API operation.", Operation = new[] {"PredictQAResults"}, SelectReturnType = typeof(Amazon.QuickSight.Model.PredictQAResultsResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.PredictQAResultsResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.PredictQAResultsResponse object containing multiple properties."
    )]
    public partial class SearchQSQAResultCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that the user wants to execute Predict QA
        /// results in.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter IncludeGeneratedAnswer
        /// <summary>
        /// <para>
        /// <para>Indicates whether generated answers are included or excluded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.IncludeGeneratedAnswer")]
        public Amazon.QuickSight.IncludeGeneratedAnswer IncludeGeneratedAnswer { get; set; }
        #endregion
        
        #region Parameter IncludeQuickSightQIndex
        /// <summary>
        /// <para>
        /// <para>Indicates whether Q indicies are included or excluded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.IncludeQuickSightQIndex")]
        public Amazon.QuickSight.IncludeQuickSightQIndex IncludeQuickSightQIndex { get; set; }
        #endregion
        
        #region Parameter MaxTopicsToConsider
        /// <summary>
        /// <para>
        /// <para>The number of maximum topics to be considered to predict QA results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxTopicsToConsider { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The query text to be used to predict QA results.</para>
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
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.PredictQAResultsResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.PredictQAResultsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-QSQAResult (PredictQAResults)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.PredictQAResultsResponse, SearchQSQAResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeGeneratedAnswer = this.IncludeGeneratedAnswer;
            context.IncludeQuickSightQIndex = this.IncludeQuickSightQIndex;
            context.MaxTopicsToConsider = this.MaxTopicsToConsider;
            context.QueryText = this.QueryText;
            #if MODULAR
            if (this.QueryText == null && ParameterWasBound(nameof(this.QueryText)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.PredictQAResultsRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.IncludeGeneratedAnswer != null)
            {
                request.IncludeGeneratedAnswer = cmdletContext.IncludeGeneratedAnswer;
            }
            if (cmdletContext.IncludeQuickSightQIndex != null)
            {
                request.IncludeQuickSightQIndex = cmdletContext.IncludeQuickSightQIndex;
            }
            if (cmdletContext.MaxTopicsToConsider != null)
            {
                request.MaxTopicsToConsider = cmdletContext.MaxTopicsToConsider.Value;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
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
        
        private Amazon.QuickSight.Model.PredictQAResultsResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.PredictQAResultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "PredictQAResults");
            try
            {
                return client.PredictQAResultsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public Amazon.QuickSight.IncludeGeneratedAnswer IncludeGeneratedAnswer { get; set; }
            public Amazon.QuickSight.IncludeQuickSightQIndex IncludeQuickSightQIndex { get; set; }
            public System.Int32? MaxTopicsToConsider { get; set; }
            public System.String QueryText { get; set; }
            public System.Func<Amazon.QuickSight.Model.PredictQAResultsResponse, SearchQSQAResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
