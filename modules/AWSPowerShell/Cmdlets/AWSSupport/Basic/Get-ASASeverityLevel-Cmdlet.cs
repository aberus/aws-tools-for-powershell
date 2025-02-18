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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns the list of severity levels that you can assign to a support case. The severity
    /// level for a case is also a field in the <a>CaseDetails</a> data type that you include
    /// for a <a>CreateCase</a> request.
    /// 
    ///  <note><ul><li><para>
    /// You must have a Business, Enterprise On-Ramp, or Enterprise Support plan to use the
    /// Amazon Web Services Support API. 
    /// </para></li><li><para>
    /// If you call the Amazon Web Services Support API from an account that doesn't have
    /// a Business, Enterprise On-Ramp, or Enterprise Support plan, the <c>SubscriptionRequiredException</c>
    /// error message appears. For information about changing your support plan, see <a href="http://aws.amazon.com/premiumsupport/">Amazon
    /// Web Services Support</a>.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "ASASeverityLevel")]
    [OutputType("Amazon.AWSSupport.Model.SeverityLevel")]
    [AWSCmdlet("Calls the AWS Support DescribeSeverityLevels API operation.", Operation = new[] {"DescribeSeverityLevels"}, SelectReturnType = typeof(Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse), LegacyAlias="Get-ASASeverityLevels")]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.SeverityLevel or Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse",
        "This cmdlet returns a collection of Amazon.AWSSupport.Model.SeverityLevel objects.",
        "The service call response (type Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetASASeverityLevelCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The language in which Amazon Web Services Support handles the case. Amazon Web Services
        /// Support currently supports Chinese (“zh”), English ("en"), Japanese ("ja") and Korean
        /// (“ko”). You must specify the ISO 639-1 code for the <c>language</c> parameter if you
        /// want support in that language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SeverityLevels'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse).
        /// Specifying the name of a property of type Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SeverityLevels";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse, GetASASeverityLevelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Language = this.Language;
            
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
            var request = new Amazon.AWSSupport.Model.DescribeSeverityLevelsRequest();
            
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
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
        
        private Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.DescribeSeverityLevelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support", "DescribeSeverityLevels");
            try
            {
                return client.DescribeSeverityLevelsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Language { get; set; }
            public System.Func<Amazon.AWSSupport.Model.DescribeSeverityLevelsResponse, GetASASeverityLevelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SeverityLevels;
        }
        
    }
}
