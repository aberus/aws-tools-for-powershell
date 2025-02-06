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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Lists the details of a <a>Protection</a> object.
    /// </summary>
    [Cmdlet("Get", "SHLDProtection")]
    [OutputType("Amazon.Shield.Model.Protection")]
    [AWSCmdlet("Calls the AWS Shield DescribeProtection API operation.", Operation = new[] {"DescribeProtection"}, SelectReturnType = typeof(Amazon.Shield.Model.DescribeProtectionResponse))]
    [AWSCmdletOutput("Amazon.Shield.Model.Protection or Amazon.Shield.Model.DescribeProtectionResponse",
        "This cmdlet returns an Amazon.Shield.Model.Protection object.",
        "The service call response (type Amazon.Shield.Model.DescribeProtectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHLDProtectionCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProtectionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) for the <a>Protection</a> object to describe. You must
        /// provide either the <c>ResourceArn</c> of the protected resource or the <c>ProtectionID</c>
        /// of the protection, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ProtectionId { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN (Amazon Resource Name) of the protected Amazon Web Services resource. You
        /// must provide either the <c>ResourceArn</c> of the protected resource or the <c>ProtectionID</c>
        /// of the protection, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Protection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.DescribeProtectionResponse).
        /// Specifying the name of a property of type Amazon.Shield.Model.DescribeProtectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Protection";
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
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.DescribeProtectionResponse, GetSHLDProtectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProtectionId = this.ProtectionId;
            context.ResourceArn = this.ResourceArn;
            
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
            var request = new Amazon.Shield.Model.DescribeProtectionRequest();
            
            if (cmdletContext.ProtectionId != null)
            {
                request.ProtectionId = cmdletContext.ProtectionId;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.Shield.Model.DescribeProtectionResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.DescribeProtectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "DescribeProtection");
            try
            {
                #if DESKTOP
                return client.DescribeProtection(request);
                #elif CORECLR
                return client.DescribeProtectionAsync(request).GetAwaiter().GetResult();
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
            public System.String ProtectionId { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.Shield.Model.DescribeProtectionResponse, GetSHLDProtectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Protection;
        }
        
    }
}
