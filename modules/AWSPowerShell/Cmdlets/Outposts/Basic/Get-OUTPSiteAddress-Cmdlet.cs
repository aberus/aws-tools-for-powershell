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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Gets the site address of the specified site.
    /// </summary>
    [Cmdlet("Get", "OUTPSiteAddress")]
    [OutputType("Amazon.Outposts.Model.GetSiteAddressResponse")]
    [AWSCmdlet("Calls the AWS Outposts GetSiteAddress API operation.", Operation = new[] {"GetSiteAddress"}, SelectReturnType = typeof(Amazon.Outposts.Model.GetSiteAddressResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.GetSiteAddressResponse",
        "This cmdlet returns an Amazon.Outposts.Model.GetSiteAddressResponse object containing multiple properties."
    )]
    public partial class GetOUTPSiteAddressCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddressType
        /// <summary>
        /// <para>
        /// <para>The type of the address you request. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Outposts.AddressType")]
        public Amazon.Outposts.AddressType AddressType { get; set; }
        #endregion
        
        #region Parameter SiteId
        /// <summary>
        /// <para>
        /// <para> The ID or the Amazon Resource Name (ARN) of the site. </para>
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
        public System.String SiteId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.GetSiteAddressResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.GetSiteAddressResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.GetSiteAddressResponse, GetOUTPSiteAddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AddressType = this.AddressType;
            #if MODULAR
            if (this.AddressType == null && ParameterWasBound(nameof(this.AddressType)))
            {
                WriteWarning("You are passing $null as a value for parameter AddressType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SiteId = this.SiteId;
            #if MODULAR
            if (this.SiteId == null && ParameterWasBound(nameof(this.SiteId)))
            {
                WriteWarning("You are passing $null as a value for parameter SiteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Outposts.Model.GetSiteAddressRequest();
            
            if (cmdletContext.AddressType != null)
            {
                request.AddressType = cmdletContext.AddressType;
            }
            if (cmdletContext.SiteId != null)
            {
                request.SiteId = cmdletContext.SiteId;
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
        
        private Amazon.Outposts.Model.GetSiteAddressResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.GetSiteAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "GetSiteAddress");
            try
            {
                #if DESKTOP
                return client.GetSiteAddress(request);
                #elif CORECLR
                return client.GetSiteAddressAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Outposts.AddressType AddressType { get; set; }
            public System.String SiteId { get; set; }
            public System.Func<Amazon.Outposts.Model.GetSiteAddressResponse, GetOUTPSiteAddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
