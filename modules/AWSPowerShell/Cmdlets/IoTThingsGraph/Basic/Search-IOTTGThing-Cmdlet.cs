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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// Searches for things associated with the specified entity. You can search by both device
    /// and device model.
    /// 
    ///  
    /// <para>
    /// For example, if two different devices, camera1 and camera2, implement the camera device
    /// model, the user can associate thing1 to camera1 and thing2 to camera2. <c>SearchThings(camera2)</c>
    /// will return only thing2, but <c>SearchThings(camera)</c> will return both thing1 and
    /// thing2.
    /// </para><para>
    /// This action searches for exact matches and doesn't perform partial text matching.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Search", "IOTTGThing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTThingsGraph.Model.Thing")]
    [AWSCmdlet("Calls the AWS IoT Things Graph SearchThings API operation.", Operation = new[] {"SearchThings"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.SearchThingsResponse))]
    [AWSCmdletOutput("Amazon.IoTThingsGraph.Model.Thing or Amazon.IoTThingsGraph.Model.SearchThingsResponse",
        "This cmdlet returns a collection of Amazon.IoTThingsGraph.Model.Thing objects.",
        "The service call response (type Amazon.IoTThingsGraph.Model.SearchThingsResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class SearchIOTTGThingCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EntityId
        /// <summary>
        /// <para>
        /// <para>The ID of the entity to which the things are associated.</para><para>The IDs should be in the following format.</para><para><c>urn:tdm:REGION/ACCOUNT ID/default:device:DEVICENAME</c></para>
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
        public System.String EntityId { get; set; }
        #endregion
        
        #region Parameter NamespaceVersion
        /// <summary>
        /// <para>
        /// <para>The version of the user's namespace. Defaults to the latest version of the user's
        /// namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? NamespaceVersion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The string that specifies the next page of results. Use this when you're paginating
        /// results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Things'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.SearchThingsResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.SearchThingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Things";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-IOTTGThing (SearchThings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.SearchThingsResponse, SearchIOTTGThingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EntityId = this.EntityId;
            #if MODULAR
            if (this.EntityId == null && ParameterWasBound(nameof(this.EntityId)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NamespaceVersion = this.NamespaceVersion;
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
            var request = new Amazon.IoTThingsGraph.Model.SearchThingsRequest();
            
            if (cmdletContext.EntityId != null)
            {
                request.EntityId = cmdletContext.EntityId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NamespaceVersion != null)
            {
                request.NamespaceVersion = cmdletContext.NamespaceVersion.Value;
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
        
        private Amazon.IoTThingsGraph.Model.SearchThingsResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.SearchThingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "SearchThings");
            try
            {
                return client.SearchThingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EntityId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.Int64? NamespaceVersion { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IoTThingsGraph.Model.SearchThingsResponse, SearchIOTTGThingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Things;
        }
        
    }
}
