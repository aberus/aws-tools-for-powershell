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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Returns information about a version of an <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">Lambda
    /// layer</a>, with a link to download the layer archive that's valid for 10 minutes.
    /// </summary>
    [Cmdlet("Get", "LMLayerVersion")]
    [OutputType("Amazon.Lambda.Model.GetLayerVersionResponse")]
    [AWSCmdlet("Calls the AWS Lambda GetLayerVersion API operation.", Operation = new[] {"GetLayerVersion"}, SelectReturnType = typeof(Amazon.Lambda.Model.GetLayerVersionResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.GetLayerVersionResponse",
        "This cmdlet returns an Amazon.Lambda.Model.GetLayerVersionResponse object containing multiple properties."
    )]
    public partial class GetLMLayerVersionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LayerName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the layer.</para>
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
        public System.String LayerName { get; set; }
        #endregion
        
        #region Parameter VersionNumber
        /// <summary>
        /// <para>
        /// <para>The version number.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? VersionNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.GetLayerVersionResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.GetLayerVersionResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.GetLayerVersionResponse, GetLMLayerVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LayerName = this.LayerName;
            #if MODULAR
            if (this.LayerName == null && ParameterWasBound(nameof(this.LayerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LayerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VersionNumber = this.VersionNumber;
            #if MODULAR
            if (this.VersionNumber == null && ParameterWasBound(nameof(this.VersionNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lambda.Model.GetLayerVersionRequest();
            
            if (cmdletContext.LayerName != null)
            {
                request.LayerName = cmdletContext.LayerName;
            }
            if (cmdletContext.VersionNumber != null)
            {
                request.VersionNumber = cmdletContext.VersionNumber.Value;
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
        
        private Amazon.Lambda.Model.GetLayerVersionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.GetLayerVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "GetLayerVersion");
            try
            {
                #if DESKTOP
                return client.GetLayerVersion(request);
                #elif CORECLR
                return client.GetLayerVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String LayerName { get; set; }
            public System.Int64? VersionNumber { get; set; }
            public System.Func<Amazon.Lambda.Model.GetLayerVersionResponse, GetLMLayerVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
