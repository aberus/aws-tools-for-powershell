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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the recovery behavior of your instance to disable simplified automatic recovery
    /// or set the recovery behavior to default. The default configuration will not enable
    /// simplified automatic recovery for an unsupported instance type. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-recover.html#instance-configuration-recovery">Simplified
    /// automatic recovery</a>.
    /// 
    ///  
    /// <para>
    /// Modifies the reboot migration behavior during a user-initiated reboot of an instance
    /// that has a pending <c>system-reboot</c> event. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/schedevents_actions_reboot.html#reboot-migration">Enable
    /// or disable reboot migration</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2InstanceMaintenanceOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyInstanceMaintenanceOptions API operation.", Operation = new[] {"ModifyInstanceMaintenanceOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse object containing multiple properties."
    )]
    public partial class EditEC2InstanceMaintenanceOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoRecovery
        /// <summary>
        /// <para>
        /// <para>Disables the automatic recovery behavior of your instance or sets it to default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceAutoRecoveryState")]
        public Amazon.EC2.InstanceAutoRecoveryState AutoRecovery { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter RebootMigration
        /// <summary>
        /// <para>
        /// <para>Specifies whether to attempt reboot migration during a user-initiated reboot of an
        /// instance that has a scheduled <c>system-reboot</c> event:</para><ul><li><para><c>default</c> - Amazon EC2 attempts to migrate the instance to new hardware (reboot
        /// migration). If successful, the <c>system-reboot</c> event is cleared. If unsuccessful,
        /// an in-place reboot occurs and the event remains scheduled.</para></li><li><para><c>disabled</c> - Amazon EC2 keeps the instance on the same hardware (in-place reboot).
        /// The <c>system-reboot</c> event remains scheduled.</para></li></ul><para>This setting only applies to supported instances that have a scheduled reboot event.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/schedevents_actions_reboot.html#reboot-migration">Enable
        /// or disable reboot migration</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceRebootMigrationState")]
        public Amazon.EC2.InstanceRebootMigrationState RebootMigration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstanceMaintenanceOption (ModifyInstanceMaintenanceOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse, EditEC2InstanceMaintenanceOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoRecovery = this.AutoRecovery;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RebootMigration = this.RebootMigration;
            
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
            var request = new Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsRequest();
            
            if (cmdletContext.AutoRecovery != null)
            {
                request.AutoRecovery = cmdletContext.AutoRecovery;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.RebootMigration != null)
            {
                request.RebootMigration = cmdletContext.RebootMigration;
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
        
        private Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyInstanceMaintenanceOptions");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceMaintenanceOptions(request);
                #elif CORECLR
                return client.ModifyInstanceMaintenanceOptionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.InstanceAutoRecoveryState AutoRecovery { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.EC2.InstanceRebootMigrationState RebootMigration { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyInstanceMaintenanceOptionsResponse, EditEC2InstanceMaintenanceOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
