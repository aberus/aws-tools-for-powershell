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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Gets a list of real-time log configurations.
    /// 
    ///  
    /// <para>
    /// You can optionally specify the maximum number of items to receive in the response.
    /// If the total number of items in the list exceeds the maximum that you specify, or
    /// the default maximum, the response is paginated. To get the next page of items, send
    /// a subsequent request that specifies the <c>NextMarker</c> value from the current response
    /// as the <c>Marker</c> value in the subsequent request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFRealtimeLogConfigList")]
    [OutputType("Amazon.CloudFront.Model.RealtimeLogConfigs")]
    [AWSCmdlet("Calls the Amazon CloudFront ListRealtimeLogConfigs API operation.", Operation = new[] {"ListRealtimeLogConfigs"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.RealtimeLogConfigs or Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.RealtimeLogConfigs object.",
        "The service call response (type Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFRealtimeLogConfigListCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in your list of
        /// real-time log configurations. The response includes real-time log configurations in
        /// the list that occur after the marker. To get the next page of the list, set this field's
        /// value to the value of <c>NextMarker</c> from the current page's response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of real-time log configurations that you want in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RealtimeLogConfigs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RealtimeLogConfigs";
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
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse, GetCFRealtimeLogConfigListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            
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
            var request = new Amazon.CloudFront.Model.ListRealtimeLogConfigsRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
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
        
        private Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListRealtimeLogConfigsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListRealtimeLogConfigs");
            try
            {
                #if DESKTOP
                return client.ListRealtimeLogConfigs(request);
                #elif CORECLR
                return client.ListRealtimeLogConfigsAsync(request).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public System.String MaxItem { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListRealtimeLogConfigsResponse, GetCFRealtimeLogConfigListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RealtimeLogConfigs;
        }
        
    }
}
