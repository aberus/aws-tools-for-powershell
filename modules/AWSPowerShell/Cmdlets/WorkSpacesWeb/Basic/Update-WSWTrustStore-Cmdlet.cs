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
using Amazon.WorkSpacesWeb;
using Amazon.WorkSpacesWeb.Model;

namespace Amazon.PowerShell.Cmdlets.WSW
{
    /// <summary>
    /// Updates the trust store.
    /// </summary>
    [Cmdlet("Update", "WSWTrustStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Web UpdateTrustStore API operation.", Operation = new[] {"UpdateTrustStore"}, SelectReturnType = typeof(Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse))]
    [AWSCmdletOutput("System.String or Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWSWTrustStoreCmdlet : AmazonWorkSpacesWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificatesToAdd
        /// <summary>
        /// <para>
        /// <para>A list of CA certificates to add to the trust store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.IO.MemoryStream[] CertificatesToAdd { get; set; }
        #endregion
        
        #region Parameter CertificatesToDelete
        /// <summary>
        /// <para>
        /// <para>A list of CA certificates to delete from a trust store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CertificatesToDelete { get; set; }
        #endregion
        
        #region Parameter TrustStoreArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the trust store.</para>
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
        public System.String TrustStoreArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, subsequent retries
        /// with the same client token return the result from the original successful request.
        /// </para><para>If you do not specify a client token, one is automatically generated by the Amazon
        /// Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustStoreArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustStoreArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrustStoreArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrustStoreArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrustStoreArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrustStoreArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WSWTrustStore (UpdateTrustStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse, UpdateWSWTrustStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrustStoreArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CertificatesToAdd != null)
            {
                context.CertificatesToAdd = new List<System.IO.MemoryStream>(this.CertificatesToAdd);
            }
            if (this.CertificatesToDelete != null)
            {
                context.CertificatesToDelete = new List<System.String>(this.CertificatesToDelete);
            }
            context.ClientToken = this.ClientToken;
            context.TrustStoreArn = this.TrustStoreArn;
            #if MODULAR
            if (this.TrustStoreArn == null && ParameterWasBound(nameof(this.TrustStoreArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustStoreArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpacesWeb.Model.UpdateTrustStoreRequest();
            
            if (cmdletContext.CertificatesToAdd != null)
            {
                request.CertificatesToAdd = cmdletContext.CertificatesToAdd;
            }
            if (cmdletContext.CertificatesToDelete != null)
            {
                request.CertificatesToDelete = cmdletContext.CertificatesToDelete;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.TrustStoreArn != null)
            {
                request.TrustStoreArn = cmdletContext.TrustStoreArn;
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
        
        private Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse CallAWSServiceOperation(IAmazonWorkSpacesWeb client, Amazon.WorkSpacesWeb.Model.UpdateTrustStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Web", "UpdateTrustStore");
            try
            {
                #if DESKTOP
                return client.UpdateTrustStore(request);
                #elif CORECLR
                return client.UpdateTrustStoreAsync(request).GetAwaiter().GetResult();
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
            public List<System.IO.MemoryStream> CertificatesToAdd { get; set; }
            public List<System.String> CertificatesToDelete { get; set; }
            public System.String ClientToken { get; set; }
            public System.String TrustStoreArn { get; set; }
            public System.Func<Amazon.WorkSpacesWeb.Model.UpdateTrustStoreResponse, UpdateWSWTrustStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustStoreArn;
        }
        
    }
}
