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
using Amazon.MediaStore;
using Amazon.MediaStore.Model;

namespace Amazon.PowerShell.Cmdlets.EMS
{
    /// <summary>
    /// Returns the cross-origin resource sharing (CORS) configuration information that is
    /// set for the container.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have permission to perform the <c>MediaStore:GetCorsPolicy</c>
    /// action. By default, the container owner has this permission and can grant it to others.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EMSCorsPolicy")]
    [OutputType("Amazon.MediaStore.Model.CorsRule")]
    [AWSCmdlet("Calls the AWS Elemental MediaStore GetCorsPolicy API operation.", Operation = new[] {"GetCorsPolicy"}, SelectReturnType = typeof(Amazon.MediaStore.Model.GetCorsPolicyResponse))]
    [AWSCmdletOutput("Amazon.MediaStore.Model.CorsRule or Amazon.MediaStore.Model.GetCorsPolicyResponse",
        "This cmdlet returns a collection of Amazon.MediaStore.Model.CorsRule objects.",
        "The service call response (type Amazon.MediaStore.Model.GetCorsPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMSCorsPolicyCmdlet : AmazonMediaStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerName
        /// <summary>
        /// <para>
        /// <para>The name of the container that the policy is assigned to.</para>
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
        public System.String ContainerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CorsPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaStore.Model.GetCorsPolicyResponse).
        /// Specifying the name of a property of type Amazon.MediaStore.Model.GetCorsPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CorsPolicy";
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
                context.Select = CreateSelectDelegate<Amazon.MediaStore.Model.GetCorsPolicyResponse, GetEMSCorsPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContainerName = this.ContainerName;
            #if MODULAR
            if (this.ContainerName == null && ParameterWasBound(nameof(this.ContainerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaStore.Model.GetCorsPolicyRequest();
            
            if (cmdletContext.ContainerName != null)
            {
                request.ContainerName = cmdletContext.ContainerName;
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
        
        private Amazon.MediaStore.Model.GetCorsPolicyResponse CallAWSServiceOperation(IAmazonMediaStore client, Amazon.MediaStore.Model.GetCorsPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaStore", "GetCorsPolicy");
            try
            {
                #if DESKTOP
                return client.GetCorsPolicy(request);
                #elif CORECLR
                return client.GetCorsPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerName { get; set; }
            public System.Func<Amazon.MediaStore.Model.GetCorsPolicyResponse, GetEMSCorsPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CorsPolicy;
        }
        
    }
}
