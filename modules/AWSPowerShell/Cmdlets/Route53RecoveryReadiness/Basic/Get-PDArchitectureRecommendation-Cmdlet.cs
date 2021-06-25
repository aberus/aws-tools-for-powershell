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
using Amazon.Route53RecoveryReadiness;
using Amazon.Route53RecoveryReadiness.Model;

namespace Amazon.PowerShell.Cmdlets.PD
{
    /// <summary>
    /// Returns a collection of recommendations to improve resilliance and readiness check
    /// quality for a Recovery Group.
    /// </summary>
    [Cmdlet("Get", "PDArchitectureRecommendation")]
    [OutputType("Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Readiness GetArchitectureRecommendations API operation.", Operation = new[] {"GetArchitectureRecommendations"}, SelectReturnType = typeof(Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse",
        "This cmdlet returns an Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPDArchitectureRecommendationCmdlet : AmazonRoute53RecoveryReadinessClientCmdlet, IExecutor
    {
        
        #region Parameter RecoveryGroupName
        /// <summary>
        /// <para>
        /// Name of RecoveryGroup (top level resource)
        /// to be analyzed.
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
        public System.String RecoveryGroupName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// Upper bound on number of records to return.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// A token that can be used to resume pagination
        /// from the end of the collection.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecoveryGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecoveryGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecoveryGroupName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse, GetPDArchitectureRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecoveryGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RecoveryGroupName = this.RecoveryGroupName;
            #if MODULAR
            if (this.RecoveryGroupName == null && ParameterWasBound(nameof(this.RecoveryGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RecoveryGroupName != null)
            {
                request.RecoveryGroupName = cmdletContext.RecoveryGroupName;
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
        
        private Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse CallAWSServiceOperation(IAmazonRoute53RecoveryReadiness client, Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Readiness", "GetArchitectureRecommendations");
            try
            {
                #if DESKTOP
                return client.GetArchitectureRecommendations(request);
                #elif CORECLR
                return client.GetArchitectureRecommendationsAsync(request).GetAwaiter().GetResult();
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
            public System.String RecoveryGroupName { get; set; }
            public System.Func<Amazon.Route53RecoveryReadiness.Model.GetArchitectureRecommendationsResponse, GetPDArchitectureRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
