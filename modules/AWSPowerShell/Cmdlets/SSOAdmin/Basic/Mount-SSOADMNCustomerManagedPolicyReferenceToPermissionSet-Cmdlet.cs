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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Attaches the specified customer managed policy to the specified <a>PermissionSet</a>.
    /// </summary>
    [Cmdlet("Mount", "SSOADMNCustomerManagedPolicyReferenceToPermissionSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin AttachCustomerManagedPolicyReferenceToPermissionSet API operation.", Operation = new[] {"AttachCustomerManagedPolicyReferenceToPermissionSet"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetResponse) be returned by specifying '-Select *'."
    )]
    public partial class MountSSOADMNCustomerManagedPolicyReferenceToPermissionSetCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM Identity Center instance under which the operation will be executed.
        /// </para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter CustomerManagedPolicyReference_Name
        /// <summary>
        /// <para>
        /// <para>The name of the IAM policy that you have configured in each account where you want
        /// to deploy your permission set.</para>
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
        public System.String CustomerManagedPolicyReference_Name { get; set; }
        #endregion
        
        #region Parameter CustomerManagedPolicyReference_Path
        /// <summary>
        /// <para>
        /// <para>The path to the IAM policy that you have configured in each account where you want
        /// to deploy your permission set. The default is <c>/</c>. For more information, see
        /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-friendly-names">Friendly
        /// names and paths</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerManagedPolicyReference_Path { get; set; }
        #endregion
        
        #region Parameter PermissionSetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>PermissionSet</c>.</para>
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
        public System.String PermissionSetArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Mount-SSOADMNCustomerManagedPolicyReferenceToPermissionSet (AttachCustomerManagedPolicyReferenceToPermissionSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetResponse, MountSSOADMNCustomerManagedPolicyReferenceToPermissionSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomerManagedPolicyReference_Name = this.CustomerManagedPolicyReference_Name;
            #if MODULAR
            if (this.CustomerManagedPolicyReference_Name == null && ParameterWasBound(nameof(this.CustomerManagedPolicyReference_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomerManagedPolicyReference_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerManagedPolicyReference_Path = this.CustomerManagedPolicyReference_Path;
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PermissionSetArn = this.PermissionSetArn;
            #if MODULAR
            if (this.PermissionSetArn == null && ParameterWasBound(nameof(this.PermissionSetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionSetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetRequest();
            
            
             // populate CustomerManagedPolicyReference
            var requestCustomerManagedPolicyReferenceIsNull = true;
            request.CustomerManagedPolicyReference = new Amazon.SSOAdmin.Model.CustomerManagedPolicyReference();
            System.String requestCustomerManagedPolicyReference_customerManagedPolicyReference_Name = null;
            if (cmdletContext.CustomerManagedPolicyReference_Name != null)
            {
                requestCustomerManagedPolicyReference_customerManagedPolicyReference_Name = cmdletContext.CustomerManagedPolicyReference_Name;
            }
            if (requestCustomerManagedPolicyReference_customerManagedPolicyReference_Name != null)
            {
                request.CustomerManagedPolicyReference.Name = requestCustomerManagedPolicyReference_customerManagedPolicyReference_Name;
                requestCustomerManagedPolicyReferenceIsNull = false;
            }
            System.String requestCustomerManagedPolicyReference_customerManagedPolicyReference_Path = null;
            if (cmdletContext.CustomerManagedPolicyReference_Path != null)
            {
                requestCustomerManagedPolicyReference_customerManagedPolicyReference_Path = cmdletContext.CustomerManagedPolicyReference_Path;
            }
            if (requestCustomerManagedPolicyReference_customerManagedPolicyReference_Path != null)
            {
                request.CustomerManagedPolicyReference.Path = requestCustomerManagedPolicyReference_customerManagedPolicyReference_Path;
                requestCustomerManagedPolicyReferenceIsNull = false;
            }
             // determine if request.CustomerManagedPolicyReference should be set to null
            if (requestCustomerManagedPolicyReferenceIsNull)
            {
                request.CustomerManagedPolicyReference = null;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.PermissionSetArn != null)
            {
                request.PermissionSetArn = cmdletContext.PermissionSetArn;
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
        
        private Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "AttachCustomerManagedPolicyReferenceToPermissionSet");
            try
            {
                #if DESKTOP
                return client.AttachCustomerManagedPolicyReferenceToPermissionSet(request);
                #elif CORECLR
                return client.AttachCustomerManagedPolicyReferenceToPermissionSetAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomerManagedPolicyReference_Name { get; set; }
            public System.String CustomerManagedPolicyReference_Path { get; set; }
            public System.String InstanceArn { get; set; }
            public System.String PermissionSetArn { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.AttachCustomerManagedPolicyReferenceToPermissionSetResponse, MountSSOADMNCustomerManagedPolicyReferenceToPermissionSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
