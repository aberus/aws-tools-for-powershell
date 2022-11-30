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
using Amazon.SageMakerGeospatial;
using Amazon.SageMakerGeospatial.Model;

namespace Amazon.PowerShell.Cmdlets.SMGS
{
    /// <summary>
    /// Retrieves details of a Vector Enrichment Job for a given job Amazon Resource Name
    /// (ARN).
    /// </summary>
    [Cmdlet("Get", "SMGSVectorEnrichmentJob")]
    [OutputType("Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse")]
    [AWSCmdlet("Calls the SageMaker Geospatial GetVectorEnrichmentJob API operation.", Operation = new[] {"GetVectorEnrichmentJob"}, SelectReturnType = typeof(Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse))]
    [AWSCmdletOutput("Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse",
        "This cmdlet returns an Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMGSVectorEnrichmentJobCmdlet : AmazonSageMakerGeospatialClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Vector Enrichment job.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse, GetSMGSVectorEnrichmentJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
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
        
        private Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse CallAWSServiceOperation(IAmazonSageMakerGeospatial client, Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Geospatial", "GetVectorEnrichmentJob");
            try
            {
                #if DESKTOP
                return client.GetVectorEnrichmentJob(request);
                #elif CORECLR
                return client.GetVectorEnrichmentJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.Func<Amazon.SageMakerGeospatial.Model.GetVectorEnrichmentJobResponse, GetSMGSVectorEnrichmentJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
