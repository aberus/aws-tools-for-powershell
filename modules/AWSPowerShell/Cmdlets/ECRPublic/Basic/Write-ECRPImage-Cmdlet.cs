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
using Amazon.ECRPublic;
using Amazon.ECRPublic.Model;

namespace Amazon.PowerShell.Cmdlets.ECRP
{
    /// <summary>
    /// Creates or updates the image manifest and tags that are associated with an image.
    /// 
    ///  
    /// <para>
    /// When an image is pushed and all new image layers have been uploaded, the PutImage
    /// API is called once to create or update the image manifest and the tags that are associated
    /// with the image.
    /// </para><note><para>
    /// This operation is used by the Amazon ECR proxy and is not generally used by customers
    /// for pulling and pushing images. In most cases, you should use the <c>docker</c> CLI
    /// to pull, tag, and push images.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "ECRPImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECRPublic.Model.Image")]
    [AWSCmdlet("Calls the Amazon Elastic Container Registry Public PutImage API operation.", Operation = new[] {"PutImage"}, SelectReturnType = typeof(Amazon.ECRPublic.Model.PutImageResponse))]
    [AWSCmdletOutput("Amazon.ECRPublic.Model.Image or Amazon.ECRPublic.Model.PutImageResponse",
        "This cmdlet returns an Amazon.ECRPublic.Model.Image object.",
        "The service call response (type Amazon.ECRPublic.Model.PutImageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteECRPImageCmdlet : AmazonECRPublicClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImageDigest
        /// <summary>
        /// <para>
        /// <para>The image digest of the image manifest that corresponds to the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageDigest { get; set; }
        #endregion
        
        #region Parameter ImageManifest
        /// <summary>
        /// <para>
        /// <para>The image manifest that corresponds to the image to be uploaded.</para>
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
        public System.String ImageManifest { get; set; }
        #endregion
        
        #region Parameter ImageManifestMediaType
        /// <summary>
        /// <para>
        /// <para>The media type of the image manifest. If you push an image manifest that doesn't contain
        /// the <c>mediaType</c> field, you must specify the <c>imageManifestMediaType</c> in
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageManifestMediaType { get; set; }
        #endregion
        
        #region Parameter ImageTag
        /// <summary>
        /// <para>
        /// <para>The tag to associate with the image. This parameter is required for images that use
        /// the Docker Image Manifest V2 Schema 2 or Open Container Initiative (OCI) formats.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageTag { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID, or registry alias, that's associated with the
        /// public registry that contains the repository where the image is put. If you do not
        /// specify a registry, the default public registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where the image is put.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Image'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECRPublic.Model.PutImageResponse).
        /// Specifying the name of a property of type Amazon.ECRPublic.Model.PutImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Image";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RepositoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECRPImage (PutImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECRPublic.Model.PutImageResponse, WriteECRPImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImageDigest = this.ImageDigest;
            context.ImageManifest = this.ImageManifest;
            #if MODULAR
            if (this.ImageManifest == null && ParameterWasBound(nameof(this.ImageManifest)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageManifest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageManifestMediaType = this.ImageManifestMediaType;
            context.ImageTag = this.ImageTag;
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECRPublic.Model.PutImageRequest();
            
            if (cmdletContext.ImageDigest != null)
            {
                request.ImageDigest = cmdletContext.ImageDigest;
            }
            if (cmdletContext.ImageManifest != null)
            {
                request.ImageManifest = cmdletContext.ImageManifest;
            }
            if (cmdletContext.ImageManifestMediaType != null)
            {
                request.ImageManifestMediaType = cmdletContext.ImageManifestMediaType;
            }
            if (cmdletContext.ImageTag != null)
            {
                request.ImageTag = cmdletContext.ImageTag;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
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
        
        private Amazon.ECRPublic.Model.PutImageResponse CallAWSServiceOperation(IAmazonECRPublic client, Amazon.ECRPublic.Model.PutImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Registry Public", "PutImage");
            try
            {
                #if DESKTOP
                return client.PutImage(request);
                #elif CORECLR
                return client.PutImageAsync(request).GetAwaiter().GetResult();
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
            public System.String ImageDigest { get; set; }
            public System.String ImageManifest { get; set; }
            public System.String ImageManifestMediaType { get; set; }
            public System.String ImageTag { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.Func<Amazon.ECRPublic.Model.PutImageResponse, WriteECRPImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Image;
        }
        
    }
}
