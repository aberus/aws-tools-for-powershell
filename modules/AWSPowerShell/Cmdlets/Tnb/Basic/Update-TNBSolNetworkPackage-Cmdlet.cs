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
using Amazon.Tnb;
using Amazon.Tnb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Updates the operational state of a network package.
    /// 
    ///  
    /// <para>
    /// A network package is a .zip file in CSAR (Cloud Service Archive) format defines the
    /// function packages you want to deploy and the Amazon Web Services infrastructure you
    /// want to deploy them on.
    /// </para><para>
    /// A network service descriptor is a .yaml file in a network package that uses the TOSCA
    /// standard to describe the network functions you want to deploy and the Amazon Web Services
    /// infrastructure you want to deploy the network functions on.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TNBSolNetworkPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Tnb.NsdOperationalState")]
    [AWSCmdlet("Calls the AWS Telco Network Builder UpdateSolNetworkPackage API operation.", Operation = new[] {"UpdateSolNetworkPackage"}, SelectReturnType = typeof(Amazon.Tnb.Model.UpdateSolNetworkPackageResponse))]
    [AWSCmdletOutput("Amazon.Tnb.NsdOperationalState or Amazon.Tnb.Model.UpdateSolNetworkPackageResponse",
        "This cmdlet returns an Amazon.Tnb.NsdOperationalState object.",
        "The service call response (type Amazon.Tnb.Model.UpdateSolNetworkPackageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateTNBSolNetworkPackageCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NsdInfoId
        /// <summary>
        /// <para>
        /// <para>ID of the network service descriptor in the network package.</para>
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
        public System.String NsdInfoId { get; set; }
        #endregion
        
        #region Parameter NsdOperationalState
        /// <summary>
        /// <para>
        /// <para>Operational state of the network service descriptor in the network package.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Tnb.NsdOperationalState")]
        public Amazon.Tnb.NsdOperationalState NsdOperationalState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NsdOperationalState'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.UpdateSolNetworkPackageResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.UpdateSolNetworkPackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NsdOperationalState";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NsdInfoId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TNBSolNetworkPackage (UpdateSolNetworkPackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.UpdateSolNetworkPackageResponse, UpdateTNBSolNetworkPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NsdInfoId = this.NsdInfoId;
            #if MODULAR
            if (this.NsdInfoId == null && ParameterWasBound(nameof(this.NsdInfoId)))
            {
                WriteWarning("You are passing $null as a value for parameter NsdInfoId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NsdOperationalState = this.NsdOperationalState;
            #if MODULAR
            if (this.NsdOperationalState == null && ParameterWasBound(nameof(this.NsdOperationalState)))
            {
                WriteWarning("You are passing $null as a value for parameter NsdOperationalState which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Tnb.Model.UpdateSolNetworkPackageRequest();
            
            if (cmdletContext.NsdInfoId != null)
            {
                request.NsdInfoId = cmdletContext.NsdInfoId;
            }
            if (cmdletContext.NsdOperationalState != null)
            {
                request.NsdOperationalState = cmdletContext.NsdOperationalState;
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
        
        private Amazon.Tnb.Model.UpdateSolNetworkPackageResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.UpdateSolNetworkPackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "UpdateSolNetworkPackage");
            try
            {
                return client.UpdateSolNetworkPackageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NsdInfoId { get; set; }
            public Amazon.Tnb.NsdOperationalState NsdOperationalState { get; set; }
            public System.Func<Amazon.Tnb.Model.UpdateSolNetworkPackageResponse, UpdateTNBSolNetworkPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NsdOperationalState;
        }
        
    }
}
