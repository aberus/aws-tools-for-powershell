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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Updates the status or configuration of a private certificate authority (CA). Your
    /// private CA must be in the <c>ACTIVE</c> or <c>DISABLED</c> state before you can update
    /// it. You can disable a private CA that is in the <c>ACTIVE</c> state or make a CA that
    /// is in the <c>DISABLED</c> state active again.
    /// 
    ///  <note><para>
    /// Both Amazon Web Services Private CA and the IAM principal must have permission to
    /// write to the S3 bucket that you specify. If the IAM principal making the call does
    /// not have permission to write to the bucket, then an exception is thrown. For more
    /// information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/crl-planning.html#s3-policies">Access
    /// policies for CRLs in Amazon S3</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "PCACertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority UpdateCertificateAuthority API operation.", Operation = new[] {"UpdateCertificateAuthority"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.UpdateCertificateAuthorityResponse))]
    [AWSCmdletOutput("None or Amazon.ACMPCA.Model.UpdateCertificateAuthorityResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ACMPCA.Model.UpdateCertificateAuthorityResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdatePCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the private CA that issued the certificate to be revoked.
        /// This must be of the form:</para><para><c>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></c></para>
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
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter RevocationConfiguration
        /// <summary>
        /// <para>
        /// <para>Contains information to enable support for Online Certificate Status Protocol (OCSP),
        /// certificate revocation list (CRL), both protocols, or neither. If you don't supply
        /// this parameter, existing capibilites remain unchanged. For more information, see the
        /// <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_OcspConfiguration.html">OcspConfiguration</a>
        /// and <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_CrlConfiguration.html">CrlConfiguration</a>
        /// types.</para><para>The following requirements apply to revocation configurations.</para><ul><li><para>A configuration disabling CRLs or OCSP must contain only the <c>Enabled=False</c>
        /// parameter, and will fail if other parameters such as <c>CustomCname</c> or <c>ExpirationInDays</c>
        /// are included.</para></li><li><para>In a CRL configuration, the <c>S3BucketName</c> parameter must conform to <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucketnamingrules.html">Amazon
        /// S3 bucket naming rules</a>.</para></li><li><para>A configuration containing a custom Canonical Name (CNAME) parameter for CRLs or OCSP
        /// must conform to <a href="https://www.ietf.org/rfc/rfc2396.txt">RFC2396</a> restrictions
        /// on the use of special characters in a CNAME. </para></li><li><para>In a CRL or OCSP configuration, the value of a CNAME parameter must not include a
        /// protocol prefix such as "http://" or "https://".</para></li></ul><important><para> If you update the <c>S3BucketName</c> of <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_CrlConfiguration.html">CrlConfiguration</a>,
        /// you can break revocation for existing certificates. In other words, if you call <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_UpdateCertificateAuthority.html">UpdateCertificateAuthority</a>
        /// to update the CRL configuration's S3 bucket name, Amazon Web Services Private CA only
        /// writes CRLs to the new S3 bucket. Certificates issued prior to this point will have
        /// the old S3 bucket name in your CRL Distribution Point (CDP) extension, essentially
        /// breaking revocation. If you must update the S3 bucket, you'll need to reissue old
        /// certificates to keep the revocation working. Alternatively, you can use a <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_CrlConfiguration.html#privateca-Type-CrlConfiguration-CustomCname">CustomCname</a>
        /// in your CRL configuration if you might need to change the S3 bucket name in the future.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ACMPCA.Model.RevocationConfiguration RevocationConfiguration { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Status of your private CA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ACMPCA.CertificateAuthorityStatus")]
        public Amazon.ACMPCA.CertificateAuthorityStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.UpdateCertificateAuthorityResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCACertificateAuthority (UpdateCertificateAuthority)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.UpdateCertificateAuthorityResponse, UpdatePCACertificateAuthorityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevocationConfiguration = this.RevocationConfiguration;
            context.Status = this.Status;
            
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
            var request = new Amazon.ACMPCA.Model.UpdateCertificateAuthorityRequest();
            
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.RevocationConfiguration != null)
            {
                request.RevocationConfiguration = cmdletContext.RevocationConfiguration;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.ACMPCA.Model.UpdateCertificateAuthorityResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.UpdateCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "UpdateCertificateAuthority");
            try
            {
                return client.UpdateCertificateAuthorityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateAuthorityArn { get; set; }
            public Amazon.ACMPCA.Model.RevocationConfiguration RevocationConfiguration { get; set; }
            public Amazon.ACMPCA.CertificateAuthorityStatus Status { get; set; }
            public System.Func<Amazon.ACMPCA.Model.UpdateCertificateAuthorityResponse, UpdatePCACertificateAuthorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
