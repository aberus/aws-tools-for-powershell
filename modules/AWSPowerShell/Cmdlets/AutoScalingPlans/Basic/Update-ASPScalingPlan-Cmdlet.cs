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
using Amazon.AutoScalingPlans;
using Amazon.AutoScalingPlans.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ASP
{
    /// <summary>
    /// Updates the specified scaling plan.
    /// 
    ///  
    /// <para>
    /// You cannot update a scaling plan if it is in the process of being created, updated,
    /// or deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ASPScalingPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling Plans UpdateScalingPlan API operation.", Operation = new[] {"UpdateScalingPlan"}, SelectReturnType = typeof(Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateASPScalingPlanCmdlet : AmazonAutoScalingPlansClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationSource_CloudFormationStackARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a AWS CloudFormation stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationSource_CloudFormationStackARN { get; set; }
        #endregion
        
        #region Parameter ScalingInstruction
        /// <summary>
        /// <para>
        /// <para>The scaling instructions.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/plans/APIReference/API_ScalingInstruction.html">ScalingInstruction</a>
        /// in the <i>AWS Auto Scaling API Reference</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScalingInstructions")]
        public Amazon.AutoScalingPlans.Model.ScalingInstruction[] ScalingInstruction { get; set; }
        #endregion
        
        #region Parameter ScalingPlanName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling plan.</para>
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
        public System.String ScalingPlanName { get; set; }
        #endregion
        
        #region Parameter ScalingPlanVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the scaling plan. The only valid value is <c>1</c>. Currently,
        /// you cannot have multiple scaling plan versions.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? ScalingPlanVersion { get; set; }
        #endregion
        
        #region Parameter ApplicationSource_TagFilter
        /// <summary>
        /// <para>
        /// <para>A set of tags (up to 50).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationSource_TagFilters")]
        public Amazon.AutoScalingPlans.Model.TagFilter[] ApplicationSource_TagFilter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScalingPlanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASPScalingPlan (UpdateScalingPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse, UpdateASPScalingPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationSource_CloudFormationStackARN = this.ApplicationSource_CloudFormationStackARN;
            if (this.ApplicationSource_TagFilter != null)
            {
                context.ApplicationSource_TagFilter = new List<Amazon.AutoScalingPlans.Model.TagFilter>(this.ApplicationSource_TagFilter);
            }
            if (this.ScalingInstruction != null)
            {
                context.ScalingInstruction = new List<Amazon.AutoScalingPlans.Model.ScalingInstruction>(this.ScalingInstruction);
            }
            context.ScalingPlanName = this.ScalingPlanName;
            #if MODULAR
            if (this.ScalingPlanName == null && ParameterWasBound(nameof(this.ScalingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingPlanVersion = this.ScalingPlanVersion;
            #if MODULAR
            if (this.ScalingPlanVersion == null && ParameterWasBound(nameof(this.ScalingPlanVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingPlanVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AutoScalingPlans.Model.UpdateScalingPlanRequest();
            
            
             // populate ApplicationSource
            var requestApplicationSourceIsNull = true;
            request.ApplicationSource = new Amazon.AutoScalingPlans.Model.ApplicationSource();
            System.String requestApplicationSource_applicationSource_CloudFormationStackARN = null;
            if (cmdletContext.ApplicationSource_CloudFormationStackARN != null)
            {
                requestApplicationSource_applicationSource_CloudFormationStackARN = cmdletContext.ApplicationSource_CloudFormationStackARN;
            }
            if (requestApplicationSource_applicationSource_CloudFormationStackARN != null)
            {
                request.ApplicationSource.CloudFormationStackARN = requestApplicationSource_applicationSource_CloudFormationStackARN;
                requestApplicationSourceIsNull = false;
            }
            List<Amazon.AutoScalingPlans.Model.TagFilter> requestApplicationSource_applicationSource_TagFilter = null;
            if (cmdletContext.ApplicationSource_TagFilter != null)
            {
                requestApplicationSource_applicationSource_TagFilter = cmdletContext.ApplicationSource_TagFilter;
            }
            if (requestApplicationSource_applicationSource_TagFilter != null)
            {
                request.ApplicationSource.TagFilters = requestApplicationSource_applicationSource_TagFilter;
                requestApplicationSourceIsNull = false;
            }
             // determine if request.ApplicationSource should be set to null
            if (requestApplicationSourceIsNull)
            {
                request.ApplicationSource = null;
            }
            if (cmdletContext.ScalingInstruction != null)
            {
                request.ScalingInstructions = cmdletContext.ScalingInstruction;
            }
            if (cmdletContext.ScalingPlanName != null)
            {
                request.ScalingPlanName = cmdletContext.ScalingPlanName;
            }
            if (cmdletContext.ScalingPlanVersion != null)
            {
                request.ScalingPlanVersion = cmdletContext.ScalingPlanVersion.Value;
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
        
        private Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse CallAWSServiceOperation(IAmazonAutoScalingPlans client, Amazon.AutoScalingPlans.Model.UpdateScalingPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling Plans", "UpdateScalingPlan");
            try
            {
                return client.UpdateScalingPlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationSource_CloudFormationStackARN { get; set; }
            public List<Amazon.AutoScalingPlans.Model.TagFilter> ApplicationSource_TagFilter { get; set; }
            public List<Amazon.AutoScalingPlans.Model.ScalingInstruction> ScalingInstruction { get; set; }
            public System.String ScalingPlanName { get; set; }
            public System.Int64? ScalingPlanVersion { get; set; }
            public System.Func<Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse, UpdateASPScalingPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
