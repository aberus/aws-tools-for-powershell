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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Disassociates a trial component from a trial. This doesn't effect other trials the
    /// component is associated with. Before you can delete a component, you must disassociate
    /// the component from all trials it is associated with. To associate a trial component
    /// with a trial, call the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AssociateTrialComponent.html">AssociateTrialComponent</a>
    /// API.
    /// 
    ///  
    /// <para>
    /// To get a list of the trials a component is associated with, use the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_Search.html">Search</a>
    /// API. Specify <c>ExperimentTrialComponent</c> for the <c>Resource</c> parameter. The
    /// list appears in the response under <c>Results.TrialComponent.Parents</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "SMTrialComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.DisassociateTrialComponentResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DisassociateTrialComponent API operation.", Operation = new[] {"DisassociateTrialComponent"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DisassociateTrialComponentResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.DisassociateTrialComponentResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.DisassociateTrialComponentResponse object containing multiple properties."
    )]
    public partial class UnregisterSMTrialComponentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TrialComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the component to disassociate from the trial.</para>
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
        public System.String TrialComponentName { get; set; }
        #endregion
        
        #region Parameter TrialName
        /// <summary>
        /// <para>
        /// <para>The name of the trial to disassociate from.</para>
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
        public System.String TrialName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DisassociateTrialComponentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DisassociateTrialComponentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrialComponentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-SMTrialComponent (DisassociateTrialComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DisassociateTrialComponentResponse, UnregisterSMTrialComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TrialComponentName = this.TrialComponentName;
            #if MODULAR
            if (this.TrialComponentName == null && ParameterWasBound(nameof(this.TrialComponentName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrialComponentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrialName = this.TrialName;
            #if MODULAR
            if (this.TrialName == null && ParameterWasBound(nameof(this.TrialName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrialName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.DisassociateTrialComponentRequest();
            
            if (cmdletContext.TrialComponentName != null)
            {
                request.TrialComponentName = cmdletContext.TrialComponentName;
            }
            if (cmdletContext.TrialName != null)
            {
                request.TrialName = cmdletContext.TrialName;
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
        
        private Amazon.SageMaker.Model.DisassociateTrialComponentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DisassociateTrialComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DisassociateTrialComponent");
            try
            {
                #if DESKTOP
                return client.DisassociateTrialComponent(request);
                #elif CORECLR
                return client.DisassociateTrialComponentAsync(request).GetAwaiter().GetResult();
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
            public System.String TrialComponentName { get; set; }
            public System.String TrialName { get; set; }
            public System.Func<Amazon.SageMaker.Model.DisassociateTrialComponentResponse, UnregisterSMTrialComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
