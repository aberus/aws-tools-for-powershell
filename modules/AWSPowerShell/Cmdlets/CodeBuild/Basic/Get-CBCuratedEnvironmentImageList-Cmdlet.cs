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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Gets information about Docker images that are managed by CodeBuild.
    /// </summary>
    [Cmdlet("Get", "CBCuratedEnvironmentImageList")]
    [OutputType("Amazon.CodeBuild.Model.EnvironmentPlatform")]
    [AWSCmdlet("Calls the AWS CodeBuild ListCuratedEnvironmentImages API operation.", Operation = new[] {"ListCuratedEnvironmentImages"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.EnvironmentPlatform or Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse",
        "This cmdlet returns a collection of Amazon.CodeBuild.Model.EnvironmentPlatform objects.",
        "The service call response (type Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCBCuratedEnvironmentImageListCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Platforms'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Platforms";
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
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse, GetCBCuratedEnvironmentImageListCmdlet>(Select) ??
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
            var request = new Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesRequest();
            
            
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
        
        private Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "ListCuratedEnvironmentImages");
            try
            {
                #if DESKTOP
                return client.ListCuratedEnvironmentImages(request);
                #elif CORECLR
                return client.ListCuratedEnvironmentImagesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CodeBuild.Model.ListCuratedEnvironmentImagesResponse, GetCBCuratedEnvironmentImageListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Platforms;
        }
        
    }
}
