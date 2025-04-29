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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the ID format settings for your resources on a per-Region basis, for example,
    /// to view which resource types are enabled for longer IDs. This request only returns
    /// information about resource types whose ID formats can be modified; it does not return
    /// information about other resource types.
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
    /// These settings apply to the IAM user who makes the request; they do not apply to the
    /// entire Amazon Web Services account. By default, an IAM user defaults to the same settings
    /// as the root user, unless they explicitly override the settings by running the <a>ModifyIdFormat</a>
    /// command. Resources created with longer IDs are visible to all IAM users, regardless
    /// of these settings and provided that they have permission to use the relevant <c>Describe</c>
    /// command for the resource type.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2IdFormat")]
    [OutputType("Amazon.EC2.Model.IdFormat")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeIdFormat API operation.", Operation = new[] {"DescribeIdFormat"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeIdFormatResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IdFormat or Amazon.EC2.Model.DescribeIdFormatResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.IdFormat objects.",
        "The service call response (type Amazon.EC2.Model.DescribeIdFormatResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2IdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeIdFormatResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeIdFormatResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeIdFormatResponse, GetEC2IdFormatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.EC2.Model.DescribeIdFormatRequest();
            
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
        
        private Amazon.EC2.Model.DescribeIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeIdFormatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeIdFormat");
            try
            {
                return client.DescribeIdFormatAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Resource { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeIdFormatResponse, GetEC2IdFormatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statuses;
        }
        
    }
}
