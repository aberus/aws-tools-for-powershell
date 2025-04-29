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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Returns a URL that you can use to connect to the Jupyter server from a notebook instance.
    /// In the SageMaker AI console, when you choose <c>Open</c> next to a notebook instance,
    /// SageMaker AI opens a new tab showing the Jupyter server home page from the notebook
    /// instance. The console uses this API to get the URL and show the page.
    /// 
    ///  
    /// <para>
    ///  The IAM role or user used to call this API defines the permissions to access the
    /// notebook instance. Once the presigned URL is created, no additional permission is
    /// required to access this URL. IAM authorization policies for this API are also enforced
    /// for every HTTP request and WebSocket frame that attempts to connect to the notebook
    /// instance.
    /// </para><para>
    /// You can restrict access to this API and to the URL that it returns to a list of IP
    /// addresses that you specify. Use the <c>NotIpAddress</c> condition operator and the
    /// <c>aws:SourceIP</c> condition context key to specify the list of IP addresses that
    /// you want to have access to the notebook instance. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/security_iam_id-based-policy-examples.html#nbi-ip-filter">Limit
    /// Access to a Notebook Instance by IP Address</a>.
    /// </para><note><para>
    /// The URL that you get from a call to <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreatePresignedNotebookInstanceUrl.html">CreatePresignedNotebookInstanceUrl</a>
    /// is valid only for 5 minutes. If you try to use the URL after the 5-minute limit expires,
    /// you are directed to the Amazon Web Services console sign-in page.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SMPresignedNotebookInstanceUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreatePresignedNotebookInstanceUrl API operation.", Operation = new[] {"CreatePresignedNotebookInstanceUrl"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMPresignedNotebookInstanceUrlCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NotebookInstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the notebook instance.</para>
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
        public System.String NotebookInstanceName { get; set; }
        #endregion
        
        #region Parameter SessionExpirationDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The duration of the session, in seconds. The default is 12 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionExpirationDurationInSeconds")]
        public System.Int32? SessionExpirationDurationInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthorizedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthorizedUrl";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotebookInstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMPresignedNotebookInstanceUrl (CreatePresignedNotebookInstanceUrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse, NewSMPresignedNotebookInstanceUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NotebookInstanceName = this.NotebookInstanceName;
            #if MODULAR
            if (this.NotebookInstanceName == null && ParameterWasBound(nameof(this.NotebookInstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NotebookInstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionExpirationDurationInSecond = this.SessionExpirationDurationInSecond;
            
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
            var request = new Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlRequest();
            
            if (cmdletContext.NotebookInstanceName != null)
            {
                request.NotebookInstanceName = cmdletContext.NotebookInstanceName;
            }
            if (cmdletContext.SessionExpirationDurationInSecond != null)
            {
                request.SessionExpirationDurationInSeconds = cmdletContext.SessionExpirationDurationInSecond.Value;
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
        
        private Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreatePresignedNotebookInstanceUrl");
            try
            {
                return client.CreatePresignedNotebookInstanceUrlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NotebookInstanceName { get; set; }
            public System.Int32? SessionExpirationDurationInSecond { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreatePresignedNotebookInstanceUrlResponse, NewSMPresignedNotebookInstanceUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthorizedUrl;
        }
        
    }
}
