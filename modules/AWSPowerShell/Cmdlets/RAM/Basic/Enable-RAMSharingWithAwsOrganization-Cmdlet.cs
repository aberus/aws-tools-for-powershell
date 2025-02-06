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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// Enables resource sharing within your organization in Organizations. This operation
    /// creates a service-linked role called <c>AWSServiceRoleForResourceAccessManager</c>
    /// that has the IAM managed policy named AWSResourceAccessManagerServiceRolePolicy attached.
    /// This role permits RAM to retrieve information about the organization and its structure.
    /// This lets you share resources with all of the accounts in the calling account's organization
    /// by specifying the organization ID, or all of the accounts in an organizational unit
    /// (OU) by specifying the OU ID. Until you enable sharing within the organization, you
    /// can specify only individual Amazon Web Services accounts, or for supported resource
    /// types, IAM roles and users.
    /// 
    ///  
    /// <para>
    /// You must call this operation from an IAM role or user in the organization's management
    /// account.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "RAMSharingWithAwsOrganization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) EnableSharingWithAwsOrganization API operation.", Operation = new[] {"EnableSharingWithAwsOrganization"}, SelectReturnType = typeof(Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableRAMSharingWithAwsOrganizationCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReturnValue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReturnValue";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-RAMSharingWithAwsOrganization (EnableSharingWithAwsOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse, EnableRAMSharingWithAwsOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.RAM.Model.EnableSharingWithAwsOrganizationRequest();
            
            
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
        
        private Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.EnableSharingWithAwsOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "EnableSharingWithAwsOrganization");
            try
            {
                #if DESKTOP
                return client.EnableSharingWithAwsOrganization(request);
                #elif CORECLR
                return client.EnableSharingWithAwsOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.RAM.Model.EnableSharingWithAwsOrganizationResponse, EnableRAMSharingWithAwsOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReturnValue;
        }
        
    }
}
