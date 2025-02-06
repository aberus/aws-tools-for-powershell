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
using Amazon.Notifications;
using Amazon.Notifications.Model;

namespace Amazon.PowerShell.Cmdlets.UNO
{
    /// <summary>
    /// Returns the AccessStatus of Service Trust Enablement for User Notifications and Amazon
    /// Web Services Organizations.
    /// </summary>
    [Cmdlet("Get", "UNONotificationsAccessForOrganization")]
    [OutputType("Amazon.Notifications.Model.NotificationsAccessForOrganization")]
    [AWSCmdlet("Calls the AWS User Notifications GetNotificationsAccessForOrganization API operation.", Operation = new[] {"GetNotificationsAccessForOrganization"}, SelectReturnType = typeof(Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.Notifications.Model.NotificationsAccessForOrganization or Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse",
        "This cmdlet returns an Amazon.Notifications.Model.NotificationsAccessForOrganization object.",
        "The service call response (type Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetUNONotificationsAccessForOrganizationCmdlet : AmazonNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotificationsAccessForOrganization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotificationsAccessForOrganization";
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
                context.Select = CreateSelectDelegate<Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse, GetUNONotificationsAccessForOrganizationCmdlet>(Select) ??
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
            var request = new Amazon.Notifications.Model.GetNotificationsAccessForOrganizationRequest();
            
            
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
        
        private Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse CallAWSServiceOperation(IAmazonNotifications client, Amazon.Notifications.Model.GetNotificationsAccessForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS User Notifications", "GetNotificationsAccessForOrganization");
            try
            {
                #if DESKTOP
                return client.GetNotificationsAccessForOrganization(request);
                #elif CORECLR
                return client.GetNotificationsAccessForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Notifications.Model.GetNotificationsAccessForOrganizationResponse, GetUNONotificationsAccessForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotificationsAccessForOrganization;
        }
        
    }
}
