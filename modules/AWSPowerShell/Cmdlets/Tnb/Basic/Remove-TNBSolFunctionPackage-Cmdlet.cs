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
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Deletes a function package.
    /// 
    ///  
    /// <para>
    /// A function package is a .zip file in CSAR (Cloud Service Archive) format that contains
    /// a network function (an ETSI standard telecommunication application) and function package
    /// descriptor that uses the TOSCA standard to describe how the network functions should
    /// run on your network.
    /// </para><para>
    /// To delete a function package, the package must be in a disabled state. To disable
    /// a function package, see <a href="https://docs.aws.amazon.com/tnb/latest/APIReference/API_UpdateSolFunctionPackage.html">UpdateSolFunctionPackage</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "TNBSolFunctionPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Telco Network Builder DeleteSolFunctionPackage API operation.", Operation = new[] {"DeleteSolFunctionPackage"}, SelectReturnType = typeof(Amazon.Tnb.Model.DeleteSolFunctionPackageResponse))]
    [AWSCmdletOutput("None or Amazon.Tnb.Model.DeleteSolFunctionPackageResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Tnb.Model.DeleteSolFunctionPackageResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveTNBSolFunctionPackageCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VnfPkgId
        /// <summary>
        /// <para>
        /// <para>ID of the function package.</para>
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
        public System.String VnfPkgId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.DeleteSolFunctionPackageResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VnfPkgId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-TNBSolFunctionPackage (DeleteSolFunctionPackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.DeleteSolFunctionPackageResponse, RemoveTNBSolFunctionPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.VnfPkgId = this.VnfPkgId;
            #if MODULAR
            if (this.VnfPkgId == null && ParameterWasBound(nameof(this.VnfPkgId)))
            {
                WriteWarning("You are passing $null as a value for parameter VnfPkgId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Tnb.Model.DeleteSolFunctionPackageRequest();
            
            if (cmdletContext.VnfPkgId != null)
            {
                request.VnfPkgId = cmdletContext.VnfPkgId;
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
        
        private Amazon.Tnb.Model.DeleteSolFunctionPackageResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.DeleteSolFunctionPackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "DeleteSolFunctionPackage");
            try
            {
                #if DESKTOP
                return client.DeleteSolFunctionPackage(request);
                #elif CORECLR
                return client.DeleteSolFunctionPackageAsync(request).GetAwaiter().GetResult();
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
            public System.String VnfPkgId { get; set; }
            public System.Func<Amazon.Tnb.Model.DeleteSolFunctionPackageResponse, RemoveTNBSolFunctionPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
