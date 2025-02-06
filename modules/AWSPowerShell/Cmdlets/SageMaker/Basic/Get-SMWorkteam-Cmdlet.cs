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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Gets information about a specific work team. You can see information such as the creation
    /// date, the last updated date, membership information, and the work team's Amazon Resource
    /// Name (ARN).
    /// </summary>
    [Cmdlet("Get", "SMWorkteam")]
    [OutputType("Amazon.SageMaker.Model.Workteam")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DescribeWorkteam API operation.", Operation = new[] {"DescribeWorkteam"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DescribeWorkteamResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.Workteam or Amazon.SageMaker.Model.DescribeWorkteamResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.Workteam object.",
        "The service call response (type Amazon.SageMaker.Model.DescribeWorkteamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMWorkteamCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter WorkteamName
        /// <summary>
        /// <para>
        /// <para>The name of the work team to return a description of.</para>
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
        public System.String WorkteamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workteam'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DescribeWorkteamResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DescribeWorkteamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workteam";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DescribeWorkteamResponse, GetSMWorkteamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.WorkteamName = this.WorkteamName;
            #if MODULAR
            if (this.WorkteamName == null && ParameterWasBound(nameof(this.WorkteamName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkteamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.DescribeWorkteamRequest();
            
            if (cmdletContext.WorkteamName != null)
            {
                request.WorkteamName = cmdletContext.WorkteamName;
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
        
        private Amazon.SageMaker.Model.DescribeWorkteamResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DescribeWorkteamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DescribeWorkteam");
            try
            {
                #if DESKTOP
                return client.DescribeWorkteam(request);
                #elif CORECLR
                return client.DescribeWorkteamAsync(request).GetAwaiter().GetResult();
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
            public System.String WorkteamName { get; set; }
            public System.Func<Amazon.SageMaker.Model.DescribeWorkteamResponse, GetSMWorkteamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workteam;
        }
        
    }
}
