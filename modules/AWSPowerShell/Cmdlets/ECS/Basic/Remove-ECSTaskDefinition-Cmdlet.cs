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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Deletes one or more task definitions.
    /// 
    ///  
    /// <para>
    /// You must deregister a task definition revision before you delete it. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_DeregisterTaskDefinition.html">DeregisterTaskDefinition</a>.
    /// </para><para>
    /// When you delete a task definition revision, it is immediately transitions from the
    /// <c>INACTIVE</c> to <c>DELETE_IN_PROGRESS</c>. Existing tasks and services that reference
    /// a <c>DELETE_IN_PROGRESS</c> task definition revision continue to run without disruption.
    /// Existing services that reference a <c>DELETE_IN_PROGRESS</c> task definition revision
    /// can still scale up or down by modifying the service's desired count.
    /// </para><para>
    /// You can't use a <c>DELETE_IN_PROGRESS</c> task definition revision to run new tasks
    /// or create new services. You also can't update an existing service to reference a <c>DELETE_IN_PROGRESS</c>
    /// task definition revision.
    /// </para><para>
    ///  A task definition revision will stay in <c>DELETE_IN_PROGRESS</c> status until all
    /// the associated tasks and services have been terminated.
    /// </para><para>
    /// When you delete all <c>INACTIVE</c> task definition revisions, the task definition
    /// name is not displayed in the console and not returned in the API. If a task definition
    /// revisions are in the <c>DELETE_IN_PROGRESS</c> state, the task definition name is
    /// displayed in the console and returned in the API. The task definition name is retained
    /// by Amazon ECS and the revision is incremented the next time you create a task definition
    /// with that name.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ECSTaskDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ECS.Model.DeleteTaskDefinitionsResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DeleteTaskDefinitions API operation.", Operation = new[] {"DeleteTaskDefinitions"}, SelectReturnType = typeof(Amazon.ECS.Model.DeleteTaskDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.DeleteTaskDefinitionsResponse",
        "This cmdlet returns an Amazon.ECS.Model.DeleteTaskDefinitionsResponse object containing multiple properties."
    )]
    public partial class RemoveECSTaskDefinitionCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <c>family</c> and <c>revision</c> (<c>family:revision</c>) or full Amazon Resource
        /// Name (ARN) of the task definition to delete. You must specify a <c>revision</c>.</para><para>You can specify up to 10 task definitions as a comma separated list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TaskDefinitions")]
        public System.String[] TaskDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DeleteTaskDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DeleteTaskDefinitionsResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskDefinition), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECSTaskDefinition (DeleteTaskDefinitions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DeleteTaskDefinitionsResponse, RemoveECSTaskDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.TaskDefinition != null)
            {
                context.TaskDefinition = new List<System.String>(this.TaskDefinition);
            }
            #if MODULAR
            if (this.TaskDefinition == null && ParameterWasBound(nameof(this.TaskDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.DeleteTaskDefinitionsRequest();
            
            if (cmdletContext.TaskDefinition != null)
            {
                request.TaskDefinitions = cmdletContext.TaskDefinition;
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
        
        private Amazon.ECS.Model.DeleteTaskDefinitionsResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DeleteTaskDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DeleteTaskDefinitions");
            try
            {
                return client.DeleteTaskDefinitionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> TaskDefinition { get; set; }
            public System.Func<Amazon.ECS.Model.DeleteTaskDefinitionsResponse, RemoveECSTaskDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
