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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Updates an existing Launch Configuration Template by ID.
    /// </summary>
    [Cmdlet("Update", "EDRSLaunchConfigurationTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Drs.Model.LaunchConfigurationTemplate")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service UpdateLaunchConfigurationTemplate API operation.", Operation = new[] {"UpdateLaunchConfigurationTemplate"}, SelectReturnType = typeof(Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.LaunchConfigurationTemplate or Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse",
        "This cmdlet returns an Amazon.Drs.Model.LaunchConfigurationTemplate object.",
        "The service call response (type Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEDRSLaunchConfigurationTemplateCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CopyPrivateIp
        /// <summary>
        /// <para>
        /// <para>Copy private IP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyPrivateIp { get; set; }
        #endregion
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>Copy tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter ExportBucketArn
        /// <summary>
        /// <para>
        /// <para>S3 bucket ARN to export Source Network templates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportBucketArn { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationTemplateID
        /// <summary>
        /// <para>
        /// <para>Launch Configuration Template ID.</para>
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
        public System.String LaunchConfigurationTemplateID { get; set; }
        #endregion
        
        #region Parameter LaunchDisposition
        /// <summary>
        /// <para>
        /// <para>Launch disposition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Drs.LaunchDisposition")]
        public Amazon.Drs.LaunchDisposition LaunchDisposition { get; set; }
        #endregion
        
        #region Parameter LaunchIntoSourceInstance
        /// <summary>
        /// <para>
        /// <para>DRS will set the 'launch into instance ID' of any source server when performing a
        /// drill, recovery or failback to the previous region or availability zone, using the
        /// instance ID of the source instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LaunchIntoSourceInstance { get; set; }
        #endregion
        
        #region Parameter Licensing_OsByol
        /// <summary>
        /// <para>
        /// <para>Whether to enable "Bring your own license" or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Licensing_OsByol { get; set; }
        #endregion
        
        #region Parameter PostLaunchEnabled
        /// <summary>
        /// <para>
        /// <para>Whether we want to activate post-launch actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PostLaunchEnabled { get; set; }
        #endregion
        
        #region Parameter TargetInstanceTypeRightSizingMethod
        /// <summary>
        /// <para>
        /// <para>Target instance type right-sizing method.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Drs.TargetInstanceTypeRightSizingMethod")]
        public Amazon.Drs.TargetInstanceTypeRightSizingMethod TargetInstanceTypeRightSizingMethod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LaunchConfigurationTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LaunchConfigurationTemplate";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LaunchConfigurationTemplateID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EDRSLaunchConfigurationTemplate (UpdateLaunchConfigurationTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse, UpdateEDRSLaunchConfigurationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CopyPrivateIp = this.CopyPrivateIp;
            context.CopyTag = this.CopyTag;
            context.ExportBucketArn = this.ExportBucketArn;
            context.LaunchConfigurationTemplateID = this.LaunchConfigurationTemplateID;
            #if MODULAR
            if (this.LaunchConfigurationTemplateID == null && ParameterWasBound(nameof(this.LaunchConfigurationTemplateID)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchConfigurationTemplateID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchDisposition = this.LaunchDisposition;
            context.LaunchIntoSourceInstance = this.LaunchIntoSourceInstance;
            context.Licensing_OsByol = this.Licensing_OsByol;
            context.PostLaunchEnabled = this.PostLaunchEnabled;
            context.TargetInstanceTypeRightSizingMethod = this.TargetInstanceTypeRightSizingMethod;
            
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
            var request = new Amazon.Drs.Model.UpdateLaunchConfigurationTemplateRequest();
            
            if (cmdletContext.CopyPrivateIp != null)
            {
                request.CopyPrivateIp = cmdletContext.CopyPrivateIp.Value;
            }
            if (cmdletContext.CopyTag != null)
            {
                request.CopyTags = cmdletContext.CopyTag.Value;
            }
            if (cmdletContext.ExportBucketArn != null)
            {
                request.ExportBucketArn = cmdletContext.ExportBucketArn;
            }
            if (cmdletContext.LaunchConfigurationTemplateID != null)
            {
                request.LaunchConfigurationTemplateID = cmdletContext.LaunchConfigurationTemplateID;
            }
            if (cmdletContext.LaunchDisposition != null)
            {
                request.LaunchDisposition = cmdletContext.LaunchDisposition;
            }
            if (cmdletContext.LaunchIntoSourceInstance != null)
            {
                request.LaunchIntoSourceInstance = cmdletContext.LaunchIntoSourceInstance.Value;
            }
            
             // populate Licensing
            var requestLicensingIsNull = true;
            request.Licensing = new Amazon.Drs.Model.Licensing();
            System.Boolean? requestLicensing_licensing_OsByol = null;
            if (cmdletContext.Licensing_OsByol != null)
            {
                requestLicensing_licensing_OsByol = cmdletContext.Licensing_OsByol.Value;
            }
            if (requestLicensing_licensing_OsByol != null)
            {
                request.Licensing.OsByol = requestLicensing_licensing_OsByol.Value;
                requestLicensingIsNull = false;
            }
             // determine if request.Licensing should be set to null
            if (requestLicensingIsNull)
            {
                request.Licensing = null;
            }
            if (cmdletContext.PostLaunchEnabled != null)
            {
                request.PostLaunchEnabled = cmdletContext.PostLaunchEnabled.Value;
            }
            if (cmdletContext.TargetInstanceTypeRightSizingMethod != null)
            {
                request.TargetInstanceTypeRightSizingMethod = cmdletContext.TargetInstanceTypeRightSizingMethod;
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
        
        private Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.UpdateLaunchConfigurationTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "UpdateLaunchConfigurationTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateLaunchConfigurationTemplate(request);
                #elif CORECLR
                return client.UpdateLaunchConfigurationTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CopyPrivateIp { get; set; }
            public System.Boolean? CopyTag { get; set; }
            public System.String ExportBucketArn { get; set; }
            public System.String LaunchConfigurationTemplateID { get; set; }
            public Amazon.Drs.LaunchDisposition LaunchDisposition { get; set; }
            public System.Boolean? LaunchIntoSourceInstance { get; set; }
            public System.Boolean? Licensing_OsByol { get; set; }
            public System.Boolean? PostLaunchEnabled { get; set; }
            public Amazon.Drs.TargetInstanceTypeRightSizingMethod TargetInstanceTypeRightSizingMethod { get; set; }
            public System.Func<Amazon.Drs.Model.UpdateLaunchConfigurationTemplateResponse, UpdateEDRSLaunchConfigurationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchConfigurationTemplate;
        }
        
    }
}
