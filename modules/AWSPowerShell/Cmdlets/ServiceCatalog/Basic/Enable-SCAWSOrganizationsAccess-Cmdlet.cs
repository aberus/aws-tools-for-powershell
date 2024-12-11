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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Enable portfolio sharing feature through Organizations. This API will allow Service
    /// Catalog to receive updates on your organization in order to sync your shares with
    /// the current structure. This API can only be called by the management account in the
    /// organization.
    /// 
    ///  
    /// <para>
    /// When you call this API, Service Catalog calls <c>organizations:EnableAWSServiceAccess</c>
    /// on your behalf so that your shares stay in sync with any changes in your Organizations
    /// structure.
    /// </para><para>
    /// Note that a delegated administrator is not authorized to invoke <c>EnableAWSOrganizationsAccess</c>.
    /// </para><important><para>
    /// If you have previously disabled Organizations access for Service Catalog, and then
    /// enable access again, the portfolio access permissions might not sync with the latest
    /// changes to the organization structure. Specifically, accounts that you removed from
    /// the organization after disabling Service Catalog access, and before you enabled access
    /// again, can retain access to the previously shared portfolio. As a result, an account
    /// that has been removed from the organization might still be able to create or manage
    /// Amazon Web Services resources when it is no longer authorized to do so. Amazon Web
    /// Services is working to resolve this issue.
    /// </para></important>
    /// </summary>
    [Cmdlet("Enable", "SCAWSOrganizationsAccess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog EnableAWSOrganizationsAccess API operation.", Operation = new[] {"EnableAWSOrganizationsAccess"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessResponse))]
    [AWSCmdletOutput("None or Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessResponse) be returned by specifying '-Select *'."
    )]
    public partial class EnableSCAWSOrganizationsAccessCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-SCAWSOrganizationsAccess (EnableAWSOrganizationsAccess)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessResponse, EnableSCAWSOrganizationsAccessCmdlet>(Select) ??
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
            var request = new Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessRequest();
            
            
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
        
        private Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "EnableAWSOrganizationsAccess");
            try
            {
                #if DESKTOP
                return client.EnableAWSOrganizationsAccess(request);
                #elif CORECLR
                return client.EnableAWSOrganizationsAccessAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ServiceCatalog.Model.EnableAWSOrganizationsAccessResponse, EnableSCAWSOrganizationsAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
