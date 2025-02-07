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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Gets the object definitions for a set of objects associated with the pipeline. Object
    /// definitions are composed of a set of fields that define the properties of the object.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DPObject")]
    [OutputType("Amazon.DataPipeline.Model.PipelineObject")]
    [AWSCmdlet("Calls the AWS Data Pipeline DescribeObjects API operation.", Operation = new[] {"DescribeObjects"}, SelectReturnType = typeof(Amazon.DataPipeline.Model.DescribeObjectsResponse))]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.PipelineObject or Amazon.DataPipeline.Model.DescribeObjectsResponse",
        "This cmdlet returns a collection of Amazon.DataPipeline.Model.PipelineObject objects.",
        "The service call response (type Amazon.DataPipeline.Model.DescribeObjectsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDPObjectCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EvaluateExpression
        /// <summary>
        /// <para>
        /// <para>Indicates whether any expressions in the object should be evaluated when the object
        /// descriptions are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluateExpressions")]
        public System.Boolean? EvaluateExpression { get; set; }
        #endregion
        
        #region Parameter ObjectId
        /// <summary>
        /// <para>
        /// <para>The IDs of the pipeline objects that contain the definitions to be described. You
        /// can pass as many as 25 identifiers in a single call to <c>DescribeObjects</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ObjectIds")]
        public System.String[] ObjectId { get; set; }
        #endregion
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline that contains the object definitions.</para>
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
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The starting point for the results to be returned. For the first call, this value
        /// should be empty. As long as there are more results, continue to call <c>DescribeObjects</c>
        /// with the marker value from the previous call to retrieve the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PipelineObjects'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataPipeline.Model.DescribeObjectsResponse).
        /// Specifying the name of a property of type Amazon.DataPipeline.Model.DescribeObjectsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PipelineObjects";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.DataPipeline.Model.DescribeObjectsResponse, GetDPObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EvaluateExpression = this.EvaluateExpression;
            context.Marker = this.Marker;
            if (this.ObjectId != null)
            {
                context.ObjectId = new List<System.String>(this.ObjectId);
            }
            #if MODULAR
            if (this.ObjectId == null && ParameterWasBound(nameof(this.ObjectId)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineId = this.PipelineId;
            #if MODULAR
            if (this.PipelineId == null && ParameterWasBound(nameof(this.PipelineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataPipeline.Model.DescribeObjectsRequest();
            
            if (cmdletContext.EvaluateExpression != null)
            {
                request.EvaluateExpressions = cmdletContext.EvaluateExpression.Value;
            }
            if (cmdletContext.ObjectId != null)
            {
                request.ObjectIds = cmdletContext.ObjectId;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.DataPipeline.Model.DescribeObjectsResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.DescribeObjectsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "DescribeObjects");
            try
            {
                #if DESKTOP
                return client.DescribeObjects(request);
                #elif CORECLR
                return client.DescribeObjectsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? EvaluateExpression { get; set; }
            public System.String Marker { get; set; }
            public List<System.String> ObjectId { get; set; }
            public System.String PipelineId { get; set; }
            public System.Func<Amazon.DataPipeline.Model.DescribeObjectsResponse, GetDPObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PipelineObjects;
        }
        
    }
}
