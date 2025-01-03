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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Retrieves information about the specified access log subscription.
    /// </summary>
    [Cmdlet("Get", "VPCLAccessLogSubscription")]
    [OutputType("Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse")]
    [AWSCmdlet("Calls the VPC Lattice GetAccessLogSubscription API operation.", Operation = new[] {"GetAccessLogSubscription"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse object containing multiple properties."
    )]
    public partial class GetVPCLAccessLogSubscriptionCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessLogSubscriptionIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the access log subscription.</para>
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
        public System.String AccessLogSubscriptionIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse, GetVPCLAccessLogSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessLogSubscriptionIdentifier = this.AccessLogSubscriptionIdentifier;
            #if MODULAR
            if (this.AccessLogSubscriptionIdentifier == null && ParameterWasBound(nameof(this.AccessLogSubscriptionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessLogSubscriptionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.GetAccessLogSubscriptionRequest();
            
            if (cmdletContext.AccessLogSubscriptionIdentifier != null)
            {
                request.AccessLogSubscriptionIdentifier = cmdletContext.AccessLogSubscriptionIdentifier;
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
        
        private Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.GetAccessLogSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "GetAccessLogSubscription");
            try
            {
                #if DESKTOP
                return client.GetAccessLogSubscription(request);
                #elif CORECLR
                return client.GetAccessLogSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessLogSubscriptionIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.GetAccessLogSubscriptionResponse, GetVPCLAccessLogSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
