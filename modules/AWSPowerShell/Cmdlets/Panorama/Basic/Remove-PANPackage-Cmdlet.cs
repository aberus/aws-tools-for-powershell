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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Deletes a package.
    /// 
    ///  <note><para>
    /// To delete a package, you need permission to call <c>s3:DeleteObject</c> in addition
    /// to permissions for the AWS Panorama API.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "PANPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Panorama DeletePackage API operation.", Operation = new[] {"DeletePackage"}, SelectReturnType = typeof(Amazon.Panorama.Model.DeletePackageResponse))]
    [AWSCmdletOutput("None or Amazon.Panorama.Model.DeletePackageResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Panorama.Model.DeletePackageResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemovePANPackageCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ForceDelete
        /// <summary>
        /// <para>
        /// <para>Delete the package even if it has artifacts stored in its access point. Deletes the
        /// package's artifacts from Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceDelete { get; set; }
        #endregion
        
        #region Parameter PackageId
        /// <summary>
        /// <para>
        /// <para>The package's ID.</para>
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
        public System.String PackageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.DeletePackageResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PackageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PANPackage (DeletePackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.DeletePackageResponse, RemovePANPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ForceDelete = this.ForceDelete;
            context.PackageId = this.PackageId;
            #if MODULAR
            if (this.PackageId == null && ParameterWasBound(nameof(this.PackageId)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Panorama.Model.DeletePackageRequest();
            
            if (cmdletContext.ForceDelete != null)
            {
                request.ForceDelete = cmdletContext.ForceDelete.Value;
            }
            if (cmdletContext.PackageId != null)
            {
                request.PackageId = cmdletContext.PackageId;
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
        
        private Amazon.Panorama.Model.DeletePackageResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.DeletePackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "DeletePackage");
            try
            {
                #if DESKTOP
                return client.DeletePackage(request);
                #elif CORECLR
                return client.DeletePackageAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ForceDelete { get; set; }
            public System.String PackageId { get; set; }
            public System.Func<Amazon.Panorama.Model.DeletePackageResponse, RemovePANPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
