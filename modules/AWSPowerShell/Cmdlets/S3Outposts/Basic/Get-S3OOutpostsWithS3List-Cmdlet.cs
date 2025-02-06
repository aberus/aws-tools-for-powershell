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
using Amazon.S3Outposts;
using Amazon.S3Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.S3O
{
    /// <summary>
    /// Lists the Outposts with S3 on Outposts capacity for your Amazon Web Services account.
    /// Includes S3 on Outposts that you have access to as the Outposts owner, or as a shared
    /// user from Resource Access Manager (RAM).
    /// </summary>
    [Cmdlet("Get", "S3OOutpostsWithS3List")]
    [OutputType("Amazon.S3Outposts.Model.Outpost")]
    [AWSCmdlet("Calls the Amazon S3 Outposts ListOutpostsWithS3 API operation.", Operation = new[] {"ListOutpostsWithS3"}, SelectReturnType = typeof(Amazon.S3Outposts.Model.ListOutpostsWithS3Response))]
    [AWSCmdletOutput("Amazon.S3Outposts.Model.Outpost or Amazon.S3Outposts.Model.ListOutpostsWithS3Response",
        "This cmdlet returns a collection of Amazon.S3Outposts.Model.Outpost objects.",
        "The service call response (type Amazon.S3Outposts.Model.ListOutpostsWithS3Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3OOutpostsWithS3ListCmdlet : AmazonS3OutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of Outposts to return. The limit is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When you can get additional results from the <c>ListOutpostsWithS3</c> call, a <c>NextToken</c>
        /// parameter is returned in the output. You can then pass in a subsequent command to
        /// the <c>NextToken</c> parameter to continue listing additional Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Outposts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Outposts.Model.ListOutpostsWithS3Response).
        /// Specifying the name of a property of type Amazon.S3Outposts.Model.ListOutpostsWithS3Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Outposts";
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
                context.Select = CreateSelectDelegate<Amazon.S3Outposts.Model.ListOutpostsWithS3Response, GetS3OOutpostsWithS3ListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.S3Outposts.Model.ListOutpostsWithS3Request();
            
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
        
        private Amazon.S3Outposts.Model.ListOutpostsWithS3Response CallAWSServiceOperation(IAmazonS3Outposts client, Amazon.S3Outposts.Model.ListOutpostsWithS3Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Outposts", "ListOutpostsWithS3");
            try
            {
                #if DESKTOP
                return client.ListOutpostsWithS3(request);
                #elif CORECLR
                return client.ListOutpostsWithS3Async(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.S3Outposts.Model.ListOutpostsWithS3Response, GetS3OOutpostsWithS3ListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Outposts;
        }
        
    }
}
