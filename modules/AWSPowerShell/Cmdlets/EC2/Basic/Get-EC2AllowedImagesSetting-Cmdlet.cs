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
    /// Gets the current state of the Allowed AMIs setting and the list of Allowed AMIs criteria
    /// at the account level in the specified Region.
    /// 
    ///  <note><para>
    /// The Allowed AMIs feature does not restrict the AMIs owned by your account. Regardless
    /// of the criteria you set, the AMIs created by your account will always be discoverable
    /// and usable by users in your account.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-allowed-amis.html">Control
    /// the discovery and use of AMIs in Amazon EC2 with Allowed AMIs</a> in <i>Amazon EC2
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2AllowedImagesSetting")]
    [OutputType("Amazon.EC2.Model.GetAllowedImagesSettingsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetAllowedImagesSettings API operation.", Operation = new[] {"GetAllowedImagesSettings"}, SelectReturnType = typeof(Amazon.EC2.Model.GetAllowedImagesSettingsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.GetAllowedImagesSettingsResponse",
        "This cmdlet returns an Amazon.EC2.Model.GetAllowedImagesSettingsResponse object containing multiple properties."
    )]
    public partial class GetEC2AllowedImagesSettingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetAllowedImagesSettingsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetAllowedImagesSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetAllowedImagesSettingsResponse, GetEC2AllowedImagesSettingCmdlet>(Select) ??
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
            var request = new Amazon.EC2.Model.GetAllowedImagesSettingsRequest();
            
            
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
        
        private Amazon.EC2.Model.GetAllowedImagesSettingsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetAllowedImagesSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetAllowedImagesSettings");
            try
            {
                #if DESKTOP
                return client.GetAllowedImagesSettings(request);
                #elif CORECLR
                return client.GetAllowedImagesSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.GetAllowedImagesSettingsResponse, GetEC2AllowedImagesSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
