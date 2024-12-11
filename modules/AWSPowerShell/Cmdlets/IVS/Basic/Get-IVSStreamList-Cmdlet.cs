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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Gets summary information about live streams in your account, in the Amazon Web Services
    /// region where the API request is processed.
    /// </summary>
    [Cmdlet("Get", "IVSStreamList")]
    [OutputType("Amazon.IVS.Model.StreamSummary")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service ListStreams API operation.", Operation = new[] {"ListStreams"}, SelectReturnType = typeof(Amazon.IVS.Model.ListStreamsResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.StreamSummary or Amazon.IVS.Model.ListStreamsResponse",
        "This cmdlet returns a collection of Amazon.IVS.Model.StreamSummary objects.",
        "The service call response (type Amazon.IVS.Model.ListStreamsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIVSStreamListCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterBy_Health
        /// <summary>
        /// <para>
        /// <para>The stream’s health.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IVS.StreamHealth")]
        public Amazon.IVS.StreamHealth FilterBy_Health { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of streams to return. Default: 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The first stream to retrieve. This is used for pagination; see the <c>nextToken</c>
        /// response field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Streams'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.ListStreamsResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.ListStreamsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Streams";
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
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.ListStreamsResponse, GetIVSStreamListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterBy_Health = this.FilterBy_Health;
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
            var request = new Amazon.IVS.Model.ListStreamsRequest();
            
            
             // populate FilterBy
            var requestFilterByIsNull = true;
            request.FilterBy = new Amazon.IVS.Model.StreamFilters();
            Amazon.IVS.StreamHealth requestFilterBy_filterBy_Health = null;
            if (cmdletContext.FilterBy_Health != null)
            {
                requestFilterBy_filterBy_Health = cmdletContext.FilterBy_Health;
            }
            if (requestFilterBy_filterBy_Health != null)
            {
                request.FilterBy.Health = requestFilterBy_filterBy_Health;
                requestFilterByIsNull = false;
            }
             // determine if request.FilterBy should be set to null
            if (requestFilterByIsNull)
            {
                request.FilterBy = null;
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
        
        private Amazon.IVS.Model.ListStreamsResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.ListStreamsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "ListStreams");
            try
            {
                #if DESKTOP
                return client.ListStreams(request);
                #elif CORECLR
                return client.ListStreamsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IVS.StreamHealth FilterBy_Health { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IVS.Model.ListStreamsResponse, GetIVSStreamListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Streams;
        }
        
    }
}
