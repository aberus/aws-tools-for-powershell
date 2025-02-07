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
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.SMS
{
    /// <summary>
    /// Updates the specified settings for the specified replication job.
    /// </summary>
    [Cmdlet("Update", "SMSReplicationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Server Migration Service UpdateReplicationJob API operation.", Operation = new[] {"UpdateReplicationJob"}, SelectReturnType = typeof(Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse))]
    [AWSCmdletOutput("None or Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMSReplicationJobCmdlet : AmazonServerMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the replication job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>When true, the replication job produces encrypted AMIs. For more information, <c>KmsKeyId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter Frequency
        /// <summary>
        /// <para>
        /// <para>The time between consecutive replication runs, in hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Frequency { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the KMS key for replication jobs that produce encrypted AMIs. This value
        /// can be any of the following:</para><ul><li><para>KMS key ID</para></li><li><para>KMS key alias</para></li><li><para>ARN referring to the KMS key ID</para></li><li><para>ARN referring to the KMS key alias</para></li></ul><para>If encrypted is enabled but a KMS key ID is not specified, the customer's default
        /// KMS key for Amazon EBS is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The license type to be used for the AMI created by a successful replication run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServerMigrationService.LicenseType")]
        public Amazon.ServerMigrationService.LicenseType LicenseType { get; set; }
        #endregion
        
        #region Parameter NextReplicationRunStartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the next replication run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? NextReplicationRunStartTime { get; set; }
        #endregion
        
        #region Parameter NumberOfRecentAmisToKeep
        /// <summary>
        /// <para>
        /// <para>The maximum number of SMS-created AMIs to retain. The oldest is deleted after the
        /// maximum number is reached and a new AMI is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NumberOfRecentAmisToKeep { get; set; }
        #endregion
        
        #region Parameter ReplicationJobId
        /// <summary>
        /// <para>
        /// <para>The ID of the replication job.</para>
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
        public System.String ReplicationJobId { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to be used by Server Migration Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationJobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMSReplicationJob (UpdateReplicationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse, UpdateSMSReplicationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Encrypted = this.Encrypted;
            context.Frequency = this.Frequency;
            context.KmsKeyId = this.KmsKeyId;
            context.LicenseType = this.LicenseType;
            context.NextReplicationRunStartTime = this.NextReplicationRunStartTime;
            context.NumberOfRecentAmisToKeep = this.NumberOfRecentAmisToKeep;
            context.ReplicationJobId = this.ReplicationJobId;
            #if MODULAR
            if (this.ReplicationJobId == null && ParameterWasBound(nameof(this.ReplicationJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleName = this.RoleName;
            
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
            var request = new Amazon.ServerMigrationService.Model.UpdateReplicationJobRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.Frequency != null)
            {
                request.Frequency = cmdletContext.Frequency.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LicenseType != null)
            {
                request.LicenseType = cmdletContext.LicenseType;
            }
            if (cmdletContext.NextReplicationRunStartTime != null)
            {
                request.NextReplicationRunStartTime = cmdletContext.NextReplicationRunStartTime.Value;
            }
            if (cmdletContext.NumberOfRecentAmisToKeep != null)
            {
                request.NumberOfRecentAmisToKeep = cmdletContext.NumberOfRecentAmisToKeep.Value;
            }
            if (cmdletContext.ReplicationJobId != null)
            {
                request.ReplicationJobId = cmdletContext.ReplicationJobId;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
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
        
        private Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse CallAWSServiceOperation(IAmazonServerMigrationService client, Amazon.ServerMigrationService.Model.UpdateReplicationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Server Migration Service", "UpdateReplicationJob");
            try
            {
                #if DESKTOP
                return client.UpdateReplicationJob(request);
                #elif CORECLR
                return client.UpdateReplicationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Int32? Frequency { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.ServerMigrationService.LicenseType LicenseType { get; set; }
            public System.DateTime? NextReplicationRunStartTime { get; set; }
            public System.Int32? NumberOfRecentAmisToKeep { get; set; }
            public System.String ReplicationJobId { get; set; }
            public System.String RoleName { get; set; }
            public System.Func<Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse, UpdateSMSReplicationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
