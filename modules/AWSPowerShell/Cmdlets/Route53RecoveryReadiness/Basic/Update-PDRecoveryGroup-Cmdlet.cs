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
using Amazon.Route53RecoveryReadiness;
using Amazon.Route53RecoveryReadiness.Model;

namespace Amazon.PowerShell.Cmdlets.PD
{
    /// <summary>
    /// Updates a recovery group.
    /// </summary>
    [Cmdlet("Update", "PDRecoveryGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Readiness UpdateRecoveryGroup API operation.", Operation = new[] {"UpdateRecoveryGroup"}, SelectReturnType = typeof(Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse",
        "This cmdlet returns an Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse object containing multiple properties."
    )]
    public partial class UpdatePDRecoveryGroupCmdlet : AmazonRoute53RecoveryReadinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Cell
        /// <summary>
        /// <para>
        /// <para>A list of cell Amazon Resource Names (ARNs). This list completely replaces the previous
        /// list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Cells")]
        public System.String[] Cell { get; set; }
        #endregion
        
        #region Parameter RecoveryGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a recovery group.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecoveryGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PDRecoveryGroup (UpdateRecoveryGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse, UpdatePDRecoveryGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Cell != null)
            {
                context.Cell = new List<System.String>(this.Cell);
            }
            #if MODULAR
            if (this.Cell == null && ParameterWasBound(nameof(this.Cell)))
            {
                WriteWarning("You are passing $null as a value for parameter Cell which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupRequest();
            
            if (cmdletContext.Cell != null)
            {
                request.Cells = cmdletContext.Cell;
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
        
        private Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse CallAWSServiceOperation(IAmazonRoute53RecoveryReadiness client, Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Readiness", "UpdateRecoveryGroup");
            try
            {
                return client.UpdateRecoveryGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Cell { get; set; }
            public System.String RecoveryGroupName { get; set; }
            public System.Func<Amazon.Route53RecoveryReadiness.Model.UpdateRecoveryGroupResponse, UpdatePDRecoveryGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
