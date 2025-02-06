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
using Amazon.CodeArtifact;
using Amazon.CodeArtifact.Model;

namespace Amazon.PowerShell.Cmdlets.CA
{
    /// <summary>
    /// Creates a new package version containing one or more assets (or files).
    /// 
    ///  
    /// <para>
    /// The <c>unfinished</c> flag can be used to keep the package version in the <c>Unfinished</c>
    /// state until all of its assets have been uploaded (see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/packages-overview.html#package-version-status.html#package-version-status">Package
    /// version status</a> in the <i>CodeArtifact user guide</i>). To set the package version’s
    /// status to <c>Published</c>, omit the <c>unfinished</c> flag when uploading the final
    /// asset, or set the status using <a href="https://docs.aws.amazon.com/codeartifact/latest/APIReference/API_UpdatePackageVersionsStatus.html">UpdatePackageVersionStatus</a>.
    /// Once a package version’s status is set to <c>Published</c>, it cannot change back
    /// to <c>Unfinished</c>.
    /// </para><note><para>
    /// Only generic packages can be published using this API. For more information, see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/using-generic.html">Using
    /// generic packages</a> in the <i>CodeArtifact User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Publish", "CAPackageVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeArtifact.Model.PublishPackageVersionResponse")]
    [AWSCmdlet("Calls the AWS CodeArtifact PublishPackageVersion API operation.", Operation = new[] {"PublishPackageVersion"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.PublishPackageVersionResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.PublishPackageVersionResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.PublishPackageVersionResponse object containing multiple properties."
    )]
    public partial class PublishCAPackageVersionCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetContent
        /// <summary>
        /// <para>
        /// <para>The content of the asset to publish.</para>
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public object AssetContent { get; set; }
        #endregion
        
        #region Parameter AssetName
        /// <summary>
        /// <para>
        /// <para>The name of the asset to publish. Asset names can include Unicode letters and numbers,
        /// and the following special characters: <c>~ ! @ ^ &amp; ( ) - ` _ + [ ] { } ; , . `</c></para>
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
        public System.String AssetName { get; set; }
        #endregion
        
        #region Parameter AssetSHA256
        /// <summary>
        /// <para>
        /// <para>The SHA256 hash of the <c>assetContent</c> to publish. This value must be calculated
        /// by the caller and provided with the request (see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/using-generic.html#publishing-generic-packages">Publishing
        /// a generic package</a> in the <i>CodeArtifact User Guide</i>).</para><para>This value is used as an integrity check to verify that the <c>assetContent</c> has
        /// not changed after it was originally sent.</para>
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
        public System.String AssetSHA256 { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain that contains the repository that contains the package version
        /// to publish.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainOwner
        /// <summary>
        /// <para>
        /// <para>The 12-digit account number of the AWS account that owns the domain. It does not include
        /// dashes or spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainOwner { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>A format that specifies the type of the package version with the requested asset file.</para><para>The only supported value is <c>generic</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeArtifact.PackageFormat")]
        public Amazon.CodeArtifact.PackageFormat Format { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the package version to publish.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Package
        /// <summary>
        /// <para>
        /// <para>The name of the package version to publish.</para>
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
        public System.String Package { get; set; }
        #endregion
        
        #region Parameter PackageVersion
        /// <summary>
        /// <para>
        /// <para>The package version to publish (for example, <c>3.5.2</c>).</para>
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
        public System.String PackageVersion { get; set; }
        #endregion
        
        #region Parameter Repository
        /// <summary>
        /// <para>
        /// <para>The name of the repository that the package version will be published to.</para>
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
        public System.String Repository { get; set; }
        #endregion
        
        #region Parameter Unfinished
        /// <summary>
        /// <para>
        /// <para>Specifies whether the package version should remain in the <c>unfinished</c> state.
        /// If omitted, the package version status will be set to <c>Published</c> (see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/packages-overview.html#package-version-status">Package
        /// version status</a> in the <i>CodeArtifact User Guide</i>).</para><para>Valid values: <c>unfinished</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Unfinished { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.PublishPackageVersionResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.PublishPackageVersionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-CAPackageVersion (PublishPackageVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.PublishPackageVersionResponse, PublishCAPackageVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetContent = this.AssetContent;
            #if MODULAR
            if (this.AssetContent == null && ParameterWasBound(nameof(this.AssetContent)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetName = this.AssetName;
            #if MODULAR
            if (this.AssetName == null && ParameterWasBound(nameof(this.AssetName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetSHA256 = this.AssetSHA256;
            #if MODULAR
            if (this.AssetSHA256 == null && ParameterWasBound(nameof(this.AssetSHA256)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetSHA256 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainOwner = this.DomainOwner;
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            context.Package = this.Package;
            #if MODULAR
            if (this.Package == null && ParameterWasBound(nameof(this.Package)))
            {
                WriteWarning("You are passing $null as a value for parameter Package which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageVersion = this.PackageVersion;
            #if MODULAR
            if (this.PackageVersion == null && ParameterWasBound(nameof(this.PackageVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Repository = this.Repository;
            #if MODULAR
            if (this.Repository == null && ParameterWasBound(nameof(this.Repository)))
            {
                WriteWarning("You are passing $null as a value for parameter Repository which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Unfinished = this.Unfinished;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.Stream _AssetContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CodeArtifact.Model.PublishPackageVersionRequest();
                
                if (cmdletContext.AssetContent != null)
                {
                    _AssetContentStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.AssetContent);
                    request.AssetContent = _AssetContentStream;
                }
                if (cmdletContext.AssetName != null)
                {
                    request.AssetName = cmdletContext.AssetName;
                }
                if (cmdletContext.AssetSHA256 != null)
                {
                    request.AssetSHA256 = cmdletContext.AssetSHA256;
                }
                if (cmdletContext.Domain != null)
                {
                    request.Domain = cmdletContext.Domain;
                }
                if (cmdletContext.DomainOwner != null)
                {
                    request.DomainOwner = cmdletContext.DomainOwner;
                }
                if (cmdletContext.Format != null)
                {
                    request.Format = cmdletContext.Format;
                }
                if (cmdletContext.Namespace != null)
                {
                    request.Namespace = cmdletContext.Namespace;
                }
                if (cmdletContext.Package != null)
                {
                    request.Package = cmdletContext.Package;
                }
                if (cmdletContext.PackageVersion != null)
                {
                    request.PackageVersion = cmdletContext.PackageVersion;
                }
                if (cmdletContext.Repository != null)
                {
                    request.Repository = cmdletContext.Repository;
                }
                if (cmdletContext.Unfinished != null)
                {
                    request.Unfinished = cmdletContext.Unfinished.Value;
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
            finally
            {
                if( _AssetContentStream != null)
                {
                    _AssetContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeArtifact.Model.PublishPackageVersionResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.PublishPackageVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "PublishPackageVersion");
            try
            {
                #if DESKTOP
                return client.PublishPackageVersion(request);
                #elif CORECLR
                return client.PublishPackageVersionAsync(request).GetAwaiter().GetResult();
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
            public object AssetContent { get; set; }
            public System.String AssetName { get; set; }
            public System.String AssetSHA256 { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainOwner { get; set; }
            public Amazon.CodeArtifact.PackageFormat Format { get; set; }
            public System.String Namespace { get; set; }
            public System.String Package { get; set; }
            public System.String PackageVersion { get; set; }
            public System.String Repository { get; set; }
            public System.Boolean? Unfinished { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.PublishPackageVersionResponse, PublishCAPackageVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
