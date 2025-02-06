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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Stops creating a solution version that is in a state of CREATE_PENDING or CREATE IN_PROGRESS.
    /// 
    /// 
    ///  
    /// <para>
    /// Depending on the current state of the solution version, the solution version state
    /// changes as follows:
    /// </para><ul><li><para>
    /// CREATE_PENDING &gt; CREATE_STOPPED
    /// </para><para>
    /// or
    /// </para></li><li><para>
    /// CREATE_IN_PROGRESS &gt; CREATE_STOPPING &gt; CREATE_STOPPED
    /// </para></li></ul><para>
    /// You are billed for all of the training completed up until you stop the solution version
    /// creation. You cannot resume creating a solution version once it has been stopped.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "PERSSolutionVersionCreation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Personalize StopSolutionVersionCreation API operation.", Operation = new[] {"StopSolutionVersionCreation"}, SelectReturnType = typeof(Amazon.Personalize.Model.StopSolutionVersionCreationResponse))]
    [AWSCmdletOutput("None or Amazon.Personalize.Model.StopSolutionVersionCreationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Personalize.Model.StopSolutionVersionCreationResponse) be returned by specifying '-Select *'."
    )]
    public partial class StopPERSSolutionVersionCreationCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SolutionVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the solution version you want to stop creating.</para>
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
        public System.String SolutionVersionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.StopSolutionVersionCreationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SolutionVersionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-PERSSolutionVersionCreation (StopSolutionVersionCreation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.StopSolutionVersionCreationResponse, StopPERSSolutionVersionCreationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SolutionVersionArn = this.SolutionVersionArn;
            #if MODULAR
            if (this.SolutionVersionArn == null && ParameterWasBound(nameof(this.SolutionVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SolutionVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Personalize.Model.StopSolutionVersionCreationRequest();
            
            if (cmdletContext.SolutionVersionArn != null)
            {
                request.SolutionVersionArn = cmdletContext.SolutionVersionArn;
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
        
        private Amazon.Personalize.Model.StopSolutionVersionCreationResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.StopSolutionVersionCreationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "StopSolutionVersionCreation");
            try
            {
                #if DESKTOP
                return client.StopSolutionVersionCreation(request);
                #elif CORECLR
                return client.StopSolutionVersionCreationAsync(request).GetAwaiter().GetResult();
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
            public System.String SolutionVersionArn { get; set; }
            public System.Func<Amazon.Personalize.Model.StopSolutionVersionCreationResponse, StopPERSSolutionVersionCreationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
