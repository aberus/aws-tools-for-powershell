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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Lists all inference events that have been found for the specified inference scheduler.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "L4EInferenceEventList")]
    [OutputType("Amazon.LookoutEquipment.Model.InferenceEventSummary")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment ListInferenceEvents API operation.", Operation = new[] {"ListInferenceEvents"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.ListInferenceEventsResponse))]
    [AWSCmdletOutput("Amazon.LookoutEquipment.Model.InferenceEventSummary or Amazon.LookoutEquipment.Model.ListInferenceEventsResponse",
        "This cmdlet returns a collection of Amazon.LookoutEquipment.Model.InferenceEventSummary objects.",
        "The service call response (type Amazon.LookoutEquipment.Model.ListInferenceEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetL4EInferenceEventListCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InferenceSchedulerName
        /// <summary>
        /// <para>
        /// <para>The name of the inference scheduler for the inference events listed. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InferenceSchedulerName { get; set; }
        #endregion
        
        #region Parameter IntervalEndTime
        /// <summary>
        /// <para>
        /// <para>Returns all the inference events with an end start time equal to or greater than less
        /// than the end time given.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? IntervalEndTime { get; set; }
        #endregion
        
        #region Parameter IntervalStartTime
        /// <summary>
        /// <para>
        /// <para> Lookout for Equipment will return all the inference events with an end time equal
        /// to or greater than the start time given.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? IntervalStartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of inference events to list. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An opaque pagination token indicating where to continue the listing of inference events.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InferenceEventSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.ListInferenceEventsResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.ListInferenceEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InferenceEventSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
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
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.ListInferenceEventsResponse, GetL4EInferenceEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InferenceSchedulerName = this.InferenceSchedulerName;
            #if MODULAR
            if (this.InferenceSchedulerName == null && ParameterWasBound(nameof(this.InferenceSchedulerName)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceSchedulerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntervalEndTime = this.IntervalEndTime;
            #if MODULAR
            if (this.IntervalEndTime == null && ParameterWasBound(nameof(this.IntervalEndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter IntervalEndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntervalStartTime = this.IntervalStartTime;
            #if MODULAR
            if (this.IntervalStartTime == null && ParameterWasBound(nameof(this.IntervalStartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter IntervalStartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.LookoutEquipment.Model.ListInferenceEventsRequest();
            
            if (cmdletContext.InferenceSchedulerName != null)
            {
                request.InferenceSchedulerName = cmdletContext.InferenceSchedulerName;
            }
            if (cmdletContext.IntervalEndTime != null)
            {
                request.IntervalEndTime = cmdletContext.IntervalEndTime.Value;
            }
            if (cmdletContext.IntervalStartTime != null)
            {
                request.IntervalStartTime = cmdletContext.IntervalStartTime.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
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
        
        private Amazon.LookoutEquipment.Model.ListInferenceEventsResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.ListInferenceEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "ListInferenceEvents");
            try
            {
                #if DESKTOP
                return client.ListInferenceEvents(request);
                #elif CORECLR
                return client.ListInferenceEventsAsync(request).GetAwaiter().GetResult();
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
            public System.String InferenceSchedulerName { get; set; }
            public System.DateTime? IntervalEndTime { get; set; }
            public System.DateTime? IntervalStartTime { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.ListInferenceEventsResponse, GetL4EInferenceEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InferenceEventSummaries;
        }
        
    }
}
