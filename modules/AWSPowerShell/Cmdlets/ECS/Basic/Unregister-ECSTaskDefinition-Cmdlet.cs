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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Deregisters the specified task definition by family and revision. Upon deregistration,
    /// the task definition is marked as <c>INACTIVE</c>. Existing tasks and services that
    /// reference an <c>INACTIVE</c> task definition continue to run without disruption. Existing
    /// services that reference an <c>INACTIVE</c> task definition can still scale up or down
    /// by modifying the service's desired count. If you want to delete a task definition
    /// revision, you must first deregister the task definition revision.
    /// 
    ///  
    /// <para>
    /// You can't use an <c>INACTIVE</c> task definition to run new tasks or create new services,
    /// and you can't update an existing service to reference an <c>INACTIVE</c> task definition.
    /// However, there may be up to a 10-minute window following deregistration where these
    /// restrictions have not yet taken effect.
    /// </para><note><para>
    /// At this time, <c>INACTIVE</c> task definitions remain discoverable in your account
    /// indefinitely. However, this behavior is subject to change in the future. We don't
    /// recommend that you rely on <c>INACTIVE</c> task definitions persisting beyond the
    /// lifecycle of any associated tasks and services.
    /// </para></note><para>
    /// You must deregister a task definition revision before you delete it. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_DeleteTaskDefinitions.html">DeleteTaskDefinitions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "ECSTaskDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.TaskDefinition")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DeregisterTaskDefinition API operation.", Operation = new[] {"DeregisterTaskDefinition"}, SelectReturnType = typeof(Amazon.ECS.Model.DeregisterTaskDefinitionResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.TaskDefinition or Amazon.ECS.Model.DeregisterTaskDefinitionResponse",
        "This cmdlet returns an Amazon.ECS.Model.TaskDefinition object.",
        "The service call response (type Amazon.ECS.Model.DeregisterTaskDefinitionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UnregisterECSTaskDefinitionCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <c>family</c> and <c>revision</c> (<c>family:revision</c>) or full Amazon Resource
        /// Name (ARN) of the task definition to deregister. You must specify a <c>revision</c>.</para>
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
        public System.String TaskDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskDefinition'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DeregisterTaskDefinitionResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DeregisterTaskDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskDefinition";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskDefinition), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-ECSTaskDefinition (DeregisterTaskDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DeregisterTaskDefinitionResponse, UnregisterECSTaskDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TaskDefinition = this.TaskDefinition;
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
            var request = new Amazon.ECS.Model.DeregisterTaskDefinitionRequest();
            
            if (cmdletContext.TaskDefinition != null)
            {
                request.TaskDefinition = cmdletContext.TaskDefinition;
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
        
        private Amazon.ECS.Model.DeregisterTaskDefinitionResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DeregisterTaskDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DeregisterTaskDefinition");
            try
            {
                #if DESKTOP
                return client.DeregisterTaskDefinition(request);
                #elif CORECLR
                return client.DeregisterTaskDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String TaskDefinition { get; set; }
            public System.Func<Amazon.ECS.Model.DeregisterTaskDefinitionResponse, UnregisterECSTaskDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskDefinition;
        }
        
    }
}
