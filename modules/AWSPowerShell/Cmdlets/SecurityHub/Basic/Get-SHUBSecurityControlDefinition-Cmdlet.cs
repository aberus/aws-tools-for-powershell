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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Retrieves the definition of a security control. The definition includes the control
    /// title, description, Region availability, parameter definitions, and other details.
    /// </summary>
    [Cmdlet("Get", "SHUBSecurityControlDefinition")]
    [OutputType("Amazon.SecurityHub.Model.SecurityControlDefinition")]
    [AWSCmdlet("Calls the AWS Security Hub GetSecurityControlDefinition API operation.", Operation = new[] {"GetSecurityControlDefinition"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.SecurityControlDefinition or Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.SecurityControlDefinition object.",
        "The service call response (type Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBSecurityControlDefinitionCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SecurityControlId
        /// <summary>
        /// <para>
        /// <para> The ID of the security control to retrieve the definition for. This field doesn’t
        /// accept an Amazon Resource Name (ARN). </para>
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
        public System.String SecurityControlId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityControlDefinition'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityControlDefinition";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse, GetSHUBSecurityControlDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SecurityControlId = this.SecurityControlId;
            #if MODULAR
            if (this.SecurityControlId == null && ParameterWasBound(nameof(this.SecurityControlId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityControlId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.GetSecurityControlDefinitionRequest();
            
            if (cmdletContext.SecurityControlId != null)
            {
                request.SecurityControlId = cmdletContext.SecurityControlId;
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
        
        private Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetSecurityControlDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetSecurityControlDefinition");
            try
            {
                #if DESKTOP
                return client.GetSecurityControlDefinition(request);
                #elif CORECLR
                return client.GetSecurityControlDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String SecurityControlId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetSecurityControlDefinitionResponse, GetSHUBSecurityControlDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityControlDefinition;
        }
        
    }
}
