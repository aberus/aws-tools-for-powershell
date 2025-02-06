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
using Amazon.ResourceExplorer2;
using Amazon.ResourceExplorer2.Model;

namespace Amazon.PowerShell.Cmdlets.AREX
{
    /// <summary>
    /// Retrieves the status of your account's Amazon Web Services service access, and validates
    /// the service linked role required to access the multi-account search feature. Only
    /// the management account can invoke this API call.
    /// </summary>
    [Cmdlet("Get", "AREXAccountLevelServiceConfiguration")]
    [OutputType("Amazon.ResourceExplorer2.Model.OrgConfiguration")]
    [AWSCmdlet("Calls the AWS Resource Explorer GetAccountLevelServiceConfiguration API operation.", Operation = new[] {"GetAccountLevelServiceConfiguration"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ResourceExplorer2.Model.OrgConfiguration or Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse",
        "This cmdlet returns an Amazon.ResourceExplorer2.Model.OrgConfiguration object.",
        "The service call response (type Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAREXAccountLevelServiceConfigurationCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrgConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrgConfiguration";
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
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse, GetAREXAccountLevelServiceConfigurationCmdlet>(Select) ??
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
            var request = new Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationRequest();
            
            
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
        
        private Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "GetAccountLevelServiceConfiguration");
            try
            {
                #if DESKTOP
                return client.GetAccountLevelServiceConfiguration(request);
                #elif CORECLR
                return client.GetAccountLevelServiceConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ResourceExplorer2.Model.GetAccountLevelServiceConfigurationResponse, GetAREXAccountLevelServiceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrgConfiguration;
        }
        
    }
}
