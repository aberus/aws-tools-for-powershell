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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns all of the runtime parameters offered by the underlying database software,
    /// or engine, for a specific database in Amazon Lightsail.
    /// 
    ///  
    /// <para>
    /// In addition to the parameter names and values, this operation returns other information
    /// about each parameter. This information includes whether changes require a reboot,
    /// whether the parameter is modifiable, the allowed values, and the data types.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LSRelationalDatabaseParameter")]
    [OutputType("Amazon.Lightsail.Model.RelationalDatabaseParameter")]
    [AWSCmdlet("Calls the Amazon Lightsail GetRelationalDatabaseParameters API operation.", Operation = new[] {"GetRelationalDatabaseParameters"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.RelationalDatabaseParameter or Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.RelationalDatabaseParameter objects.",
        "The service call response (type Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLSRelationalDatabaseParameterCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your database for which to get parameters.</para>
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
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next page of results from your request.</para><para>To get a page token, perform an initial <c>GetRelationalDatabaseParameters</c> request.
        /// If your results are paginated, the response will return a next page token that you
        /// can specify as the page token in a subsequent request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'PageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-PageToken' to null for the first call then set the 'PageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Parameters'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Parameters";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of PageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse, GetLSRelationalDatabaseParameterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PageToken = this.PageToken;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            #if MODULAR
            if (this.RelationalDatabaseName == null && ParameterWasBound(nameof(this.RelationalDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Lightsail.Model.GetRelationalDatabaseParametersRequest();
            
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.PageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.PageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.PageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
        
        private Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetRelationalDatabaseParametersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetRelationalDatabaseParameters");
            try
            {
                return client.GetRelationalDatabaseParametersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PageToken { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetRelationalDatabaseParametersResponse, GetLSRelationalDatabaseParameterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Parameters;
        }
        
    }
}
