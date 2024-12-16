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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Disassociates a specified app block builder from a specified app block.
    /// </summary>
    [Cmdlet("Remove", "APSAppBlockBuilderAppBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon AppStream DisassociateAppBlockBuilderAppBlock API operation.", Operation = new[] {"DisassociateAppBlockBuilderAppBlock"}, SelectReturnType = typeof(Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockResponse))]
    [AWSCmdletOutput("None or Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveAPSAppBlockBuilderAppBlockCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppBlockArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the app block.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppBlockArn { get; set; }
        #endregion
        
        #region Parameter AppBlockBuilderName
        /// <summary>
        /// <para>
        /// <para>The name of the app block builder.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppBlockBuilderName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-APSAppBlockBuilderAppBlock (DisassociateAppBlockBuilderAppBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockResponse, RemoveAPSAppBlockBuilderAppBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppBlockArn = this.AppBlockArn;
            #if MODULAR
            if (this.AppBlockArn == null && ParameterWasBound(nameof(this.AppBlockArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBlockArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppBlockBuilderName = this.AppBlockBuilderName;
            #if MODULAR
            if (this.AppBlockBuilderName == null && ParameterWasBound(nameof(this.AppBlockBuilderName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBlockBuilderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockRequest();
            
            if (cmdletContext.AppBlockArn != null)
            {
                request.AppBlockArn = cmdletContext.AppBlockArn;
            }
            if (cmdletContext.AppBlockBuilderName != null)
            {
                request.AppBlockBuilderName = cmdletContext.AppBlockBuilderName;
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
        
        private Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "DisassociateAppBlockBuilderAppBlock");
            try
            {
                #if DESKTOP
                return client.DisassociateAppBlockBuilderAppBlock(request);
                #elif CORECLR
                return client.DisassociateAppBlockBuilderAppBlockAsync(request).GetAwaiter().GetResult();
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
            public System.String AppBlockArn { get; set; }
            public System.String AppBlockBuilderName { get; set; }
            public System.Func<Amazon.AppStream.Model.DisassociateAppBlockBuilderAppBlockResponse, RemoveAPSAppBlockBuilderAppBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
