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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Returns the resolution path of an engagement. For example, the escalation plan engaged
    /// in an incident might target an on-call schedule that includes several contacts in
    /// a rotation, but just one contact on-call when the incident starts. The resolution
    /// path indicates the hierarchy of <i>escalation plan &gt; on-call schedule &gt; contact</i>.
    /// </summary>
    [Cmdlet("Get", "SMCPageResolutionList")]
    [OutputType("Amazon.SSMContacts.Model.ResolutionContact")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts ListPageResolutions API operation.", Operation = new[] {"ListPageResolutions"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.ListPageResolutionsResponse))]
    [AWSCmdletOutput("Amazon.SSMContacts.Model.ResolutionContact or Amazon.SSMContacts.Model.ListPageResolutionsResponse",
        "This cmdlet returns a collection of Amazon.SSMContacts.Model.ResolutionContact objects.",
        "The service call response (type Amazon.SSMContacts.Model.ListPageResolutionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMCPageResolutionListCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PageId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the contact engaged for the incident.</para>
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
        public System.String PageId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to start the list. Use this token to get the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PageResolutions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.ListPageResolutionsResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.ListPageResolutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PageResolutions";
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
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.ListPageResolutionsResponse, GetSMCPageResolutionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NextToken = this.NextToken;
            context.PageId = this.PageId;
            #if MODULAR
            if (this.PageId == null && ParameterWasBound(nameof(this.PageId)))
            {
                WriteWarning("You are passing $null as a value for parameter PageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMContacts.Model.ListPageResolutionsRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PageId != null)
            {
                request.PageId = cmdletContext.PageId;
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
        
        private Amazon.SSMContacts.Model.ListPageResolutionsResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.ListPageResolutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "ListPageResolutions");
            try
            {
                return client.ListPageResolutionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public System.String PageId { get; set; }
            public System.Func<Amazon.SSMContacts.Model.ListPageResolutionsResponse, GetSMCPageResolutionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PageResolutions;
        }
        
    }
}
