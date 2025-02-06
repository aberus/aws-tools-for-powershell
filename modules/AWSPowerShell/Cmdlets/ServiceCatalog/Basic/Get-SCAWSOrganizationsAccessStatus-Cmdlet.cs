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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Get the Access Status for Organizations portfolio share feature. This API can only
    /// be called by the management account in the organization or by a delegated admin.
    /// </summary>
    [Cmdlet("Get", "SCAWSOrganizationsAccessStatus")]
    [OutputType("Amazon.ServiceCatalog.AccessStatus")]
    [AWSCmdlet("Calls the AWS Service Catalog GetAWSOrganizationsAccessStatus API operation.", Operation = new[] {"GetAWSOrganizationsAccessStatus"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.AccessStatus or Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.AccessStatus object.",
        "The service call response (type Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSCAWSOrganizationsAccessStatusCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessStatus";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse, GetSCAWSOrganizationsAccessStatusCmdlet>(Select) ??
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
            var request = new Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusRequest();
            
            
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
        
        private Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "GetAWSOrganizationsAccessStatus");
            try
            {
                #if DESKTOP
                return client.GetAWSOrganizationsAccessStatus(request);
                #elif CORECLR
                return client.GetAWSOrganizationsAccessStatusAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ServiceCatalog.Model.GetAWSOrganizationsAccessStatusResponse, GetSCAWSOrganizationsAccessStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessStatus;
        }
        
    }
}
