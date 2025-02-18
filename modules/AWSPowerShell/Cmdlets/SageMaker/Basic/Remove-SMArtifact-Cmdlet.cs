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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Deletes an artifact. Either <c>ArtifactArn</c> or <c>Source</c> must be specified.
    /// </summary>
    [Cmdlet("Remove", "SMArtifact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DeleteArtifact API operation.", Operation = new[] {"DeleteArtifact"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DeleteArtifactResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.DeleteArtifactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.DeleteArtifactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveSMArtifactCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArtifactArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the artifact to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ArtifactArn { get; set; }
        #endregion
        
        #region Parameter Source_SourceType
        /// <summary>
        /// <para>
        /// <para>A list of source types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SourceTypes")]
        public Amazon.SageMaker.Model.ArtifactSourceType[] Source_SourceType { get; set; }
        #endregion
        
        #region Parameter Source_SourceUri
        /// <summary>
        /// <para>
        /// <para>The URI of the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SourceUri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ArtifactArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DeleteArtifactResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DeleteArtifactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ArtifactArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ArtifactArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SMArtifact (DeleteArtifact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DeleteArtifactResponse, RemoveSMArtifactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArtifactArn = this.ArtifactArn;
            if (this.Source_SourceType != null)
            {
                context.Source_SourceType = new List<Amazon.SageMaker.Model.ArtifactSourceType>(this.Source_SourceType);
            }
            context.Source_SourceUri = this.Source_SourceUri;
            
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
            var request = new Amazon.SageMaker.Model.DeleteArtifactRequest();
            
            if (cmdletContext.ArtifactArn != null)
            {
                request.ArtifactArn = cmdletContext.ArtifactArn;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.SageMaker.Model.ArtifactSource();
            List<Amazon.SageMaker.Model.ArtifactSourceType> requestSource_source_SourceType = null;
            if (cmdletContext.Source_SourceType != null)
            {
                requestSource_source_SourceType = cmdletContext.Source_SourceType;
            }
            if (requestSource_source_SourceType != null)
            {
                request.Source.SourceTypes = requestSource_source_SourceType;
                requestSourceIsNull = false;
            }
            System.String requestSource_source_SourceUri = null;
            if (cmdletContext.Source_SourceUri != null)
            {
                requestSource_source_SourceUri = cmdletContext.Source_SourceUri;
            }
            if (requestSource_source_SourceUri != null)
            {
                request.Source.SourceUri = requestSource_source_SourceUri;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.SageMaker.Model.DeleteArtifactResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DeleteArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DeleteArtifact");
            try
            {
                return client.DeleteArtifactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ArtifactArn { get; set; }
            public List<Amazon.SageMaker.Model.ArtifactSourceType> Source_SourceType { get; set; }
            public System.String Source_SourceUri { get; set; }
            public System.Func<Amazon.SageMaker.Model.DeleteArtifactResponse, RemoveSMArtifactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ArtifactArn;
        }
        
    }
}
