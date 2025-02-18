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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the ID format settings for resources for the specified IAM user, IAM role,
    /// or root user. For example, you can view the resource types that are enabled for longer
    /// IDs. This request only returns information about resource types whose ID formats can
    /// be modified; it does not return information about other resource types. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/resource-ids.html">Resource
    /// IDs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>. 
    /// 
    ///  
    /// <para>
    /// The following resource types support longer IDs: <c>bundle</c> | <c>conversion-task</c>
    /// | <c>customer-gateway</c> | <c>dhcp-options</c> | <c>elastic-ip-allocation</c> | <c>elastic-ip-association</c>
    /// | <c>export-task</c> | <c>flow-log</c> | <c>image</c> | <c>import-task</c> | <c>instance</c>
    /// | <c>internet-gateway</c> | <c>network-acl</c> | <c>network-acl-association</c> |
    /// <c>network-interface</c> | <c>network-interface-attachment</c> | <c>prefix-list</c>
    /// | <c>reservation</c> | <c>route-table</c> | <c>route-table-association</c> | <c>security-group</c>
    /// | <c>snapshot</c> | <c>subnet</c> | <c>subnet-cidr-block-association</c> | <c>volume</c>
    /// | <c>vpc</c> | <c>vpc-cidr-block-association</c> | <c>vpc-endpoint</c> | <c>vpc-peering-connection</c>
    /// | <c>vpn-connection</c> | <c>vpn-gateway</c>. 
    /// </para><para>
    /// These settings apply to the principal specified in the request. They do not apply
    /// to the principal that makes the request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2IdentityIdFormat")]
    [OutputType("Amazon.EC2.Model.IdFormat")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeIdentityIdFormat API operation.", Operation = new[] {"DescribeIdentityIdFormat"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeIdentityIdFormatResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IdFormat or Amazon.EC2.Model.DescribeIdentityIdFormatResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.IdFormat objects.",
        "The service call response (type Amazon.EC2.Model.DescribeIdentityIdFormatResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2IdentityIdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PrincipalArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the principal, which can be an IAM role, IAM user, or the root user.</para>
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
        public System.String PrincipalArn { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The type of resource: <c>bundle</c> | <c>conversion-task</c> | <c>customer-gateway</c>
        /// | <c>dhcp-options</c> | <c>elastic-ip-allocation</c> | <c>elastic-ip-association</c>
        /// | <c>export-task</c> | <c>flow-log</c> | <c>image</c> | <c>import-task</c> | <c>instance</c>
        /// | <c>internet-gateway</c> | <c>network-acl</c> | <c>network-acl-association</c> |
        /// <c>network-interface</c> | <c>network-interface-attachment</c> | <c>prefix-list</c>
        /// | <c>reservation</c> | <c>route-table</c> | <c>route-table-association</c> | <c>security-group</c>
        /// | <c>snapshot</c> | <c>subnet</c> | <c>subnet-cidr-block-association</c> | <c>volume</c>
        /// | <c>vpc</c> | <c>vpc-cidr-block-association</c> | <c>vpc-endpoint</c> | <c>vpc-peering-connection</c>
        /// | <c>vpn-connection</c> | <c>vpn-gateway</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeIdentityIdFormatResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeIdentityIdFormatResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Statuses";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeIdentityIdFormatResponse, GetEC2IdentityIdFormatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PrincipalArn = this.PrincipalArn;
            #if MODULAR
            if (this.PrincipalArn == null && ParameterWasBound(nameof(this.PrincipalArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Resource = this.Resource;
            
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
            var request = new Amazon.EC2.Model.DescribeIdentityIdFormatRequest();
            
            if (cmdletContext.PrincipalArn != null)
            {
                request.PrincipalArn = cmdletContext.PrincipalArn;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
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
        
        private Amazon.EC2.Model.DescribeIdentityIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeIdentityIdFormatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeIdentityIdFormat");
            try
            {
                return client.DescribeIdentityIdFormatAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PrincipalArn { get; set; }
            public System.String Resource { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeIdentityIdFormatResponse, GetEC2IdentityIdFormatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statuses;
        }
        
    }
}
