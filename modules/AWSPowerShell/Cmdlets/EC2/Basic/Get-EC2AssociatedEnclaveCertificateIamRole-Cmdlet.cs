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

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Returns the IAM roles that are associated with the specified ACM (ACM) certificate.
    /// It also returns the name of the Amazon S3 bucket and the Amazon S3 object key where
    /// the certificate, certificate chain, and encrypted private key bundle are stored, and
    /// the ARN of the KMS key that's used to encrypt the private key.
    /// </summary>
    [Cmdlet("Get", "EC2AssociatedEnclaveCertificateIamRole")]
    [OutputType("Amazon.EC2.Model.AssociatedRole")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetAssociatedEnclaveCertificateIamRoles API operation.", Operation = new[] {"GetAssociatedEnclaveCertificateIamRoles"}, SelectReturnType = typeof(Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AssociatedRole or Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.AssociatedRole objects.",
        "The service call response (type Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2AssociatedEnclaveCertificateIamRoleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the ACM certificate for which to view the associated IAM roles, encryption
        /// keys, and Amazon S3 object information.</para>
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
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssociatedRoles'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssociatedRoles";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse, GetEC2AssociatedEnclaveCertificateIamRoleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateArn = this.CertificateArn;
            #if MODULAR
            if (this.CertificateArn == null && ParameterWasBound(nameof(this.CertificateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
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
        
        private Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetAssociatedEnclaveCertificateIamRoles");
            try
            {
                return client.GetAssociatedEnclaveCertificateIamRolesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateArn { get; set; }
            public System.Func<Amazon.EC2.Model.GetAssociatedEnclaveCertificateIamRolesResponse, GetEC2AssociatedEnclaveCertificateIamRoleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssociatedRoles;
        }
        
    }
}
