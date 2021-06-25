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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// <code>ServiceSetting</code> is an account-level setting for an Amazon Web Services
    /// service. This setting defines how a user interacts with or uses a service or a feature
    /// of a service. For example, if an Amazon Web Services service charges money to the
    /// account based on feature or service usage, then the Amazon Web Services service team
    /// might create a default setting of "false". This means the user can't use this feature
    /// unless they change the setting to "true" and intentionally opt in for a paid feature.
    /// 
    ///  
    /// <para>
    /// Services map a <code>SettingId</code> object to a setting value. Amazon Web Services
    /// services teams define the default value for a <code>SettingId</code>. You can't create
    /// a new <code>SettingId</code>, but you can overwrite the default value if you have
    /// the <code>ssm:UpdateServiceSetting</code> permission for the setting. Use the <a>GetServiceSetting</a>
    /// API operation to view the current value. Use the <a>UpdateServiceSetting</a> API operation
    /// to change the default setting. 
    /// </para><para>
    /// Reset the service setting for the account to the default value as provisioned by the
    /// Amazon Web Services service team. 
    /// </para>
    /// </summary>
    [Cmdlet("Reset", "SSMServiceSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.ServiceSetting")]
    [AWSCmdlet("Calls the AWS Systems Manager ResetServiceSetting API operation.", Operation = new[] {"ResetServiceSetting"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.ServiceSetting or Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.ServiceSetting object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ResetSSMServiceSettingCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter SettingId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service setting to reset. The setting ID can
        /// be one of the following.</para><ul><li><para><code>/ssm/automation/customer-script-log-destination</code></para></li><li><para><code>/ssm/automation/customer-script-log-group-name</code></para></li><li><para><code>/ssm/documents/console/public-sharing-permission</code></para></li><li><para><code>/ssm/parameter-store/default-parameter-tier</code></para></li><li><para><code>/ssm/parameter-store/high-throughput-enabled</code></para></li><li><para><code>/ssm/managed-instance/activation-tier</code></para></li></ul>
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
        public System.String SettingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceSetting'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceSetting";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SettingId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SettingId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SettingId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SettingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-SSMServiceSetting (ResetServiceSetting)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse, ResetSSMServiceSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SettingId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SettingId = this.SettingId;
            #if MODULAR
            if (this.SettingId == null && ParameterWasBound(nameof(this.SettingId)))
            {
                WriteWarning("You are passing $null as a value for parameter SettingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.ResetServiceSettingRequest();
            
            if (cmdletContext.SettingId != null)
            {
                request.SettingId = cmdletContext.SettingId;
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
        
        private Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.ResetServiceSettingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "ResetServiceSetting");
            try
            {
                #if DESKTOP
                return client.ResetServiceSetting(request);
                #elif CORECLR
                return client.ResetServiceSettingAsync(request).GetAwaiter().GetResult();
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
            public System.String SettingId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.ResetServiceSettingResponse, ResetSSMServiceSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceSetting;
        }
        
    }
}
