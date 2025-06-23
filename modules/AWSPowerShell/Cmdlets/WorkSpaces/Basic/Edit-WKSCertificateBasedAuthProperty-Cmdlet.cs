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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modifies the properties of the certificate-based authentication you want to use with
    /// your WorkSpaces.
    /// </summary>
    [Cmdlet("Edit", "WKSCertificateBasedAuthProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifyCertificateBasedAuthProperties API operation.", Operation = new[] {"ModifyCertificateBasedAuthProperties"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditWKSCertificateBasedAuthPropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateBasedAuthProperties_CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Certificate Manager Private
        /// CA resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateBasedAuthProperties_CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter PropertiesToDelete
        /// <summary>
        /// <para>
        /// <para>The properties of the certificate-based authentication you want to delete.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PropertiesToDelete { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The resource identifiers, in the form of directory IDs.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter CertificateBasedAuthProperties_Status
        /// <summary>
        /// <para>
        /// <para>The status of the certificate-based authentication properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.CertificateBasedAuthStatusEnum")]
        public Amazon.WorkSpaces.CertificateBasedAuthStatusEnum CertificateBasedAuthProperties_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSCertificateBasedAuthProperty (ModifyCertificateBasedAuthProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesResponse, EditWKSCertificateBasedAuthPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateBasedAuthProperties_CertificateAuthorityArn = this.CertificateBasedAuthProperties_CertificateAuthorityArn;
            context.CertificateBasedAuthProperties_Status = this.CertificateBasedAuthProperties_Status;
            if (this.PropertiesToDelete != null)
            {
                context.PropertiesToDelete = new List<System.String>(this.PropertiesToDelete);
            }
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesRequest();
            
            
             // populate CertificateBasedAuthProperties
            var requestCertificateBasedAuthPropertiesIsNull = true;
            request.CertificateBasedAuthProperties = new Amazon.WorkSpaces.Model.CertificateBasedAuthProperties();
            System.String requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn = null;
            if (cmdletContext.CertificateBasedAuthProperties_CertificateAuthorityArn != null)
            {
                requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn = cmdletContext.CertificateBasedAuthProperties_CertificateAuthorityArn;
            }
            if (requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn != null)
            {
                request.CertificateBasedAuthProperties.CertificateAuthorityArn = requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn;
                requestCertificateBasedAuthPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.CertificateBasedAuthStatusEnum requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status = null;
            if (cmdletContext.CertificateBasedAuthProperties_Status != null)
            {
                requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status = cmdletContext.CertificateBasedAuthProperties_Status;
            }
            if (requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status != null)
            {
                request.CertificateBasedAuthProperties.Status = requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status;
                requestCertificateBasedAuthPropertiesIsNull = false;
            }
             // determine if request.CertificateBasedAuthProperties should be set to null
            if (requestCertificateBasedAuthPropertiesIsNull)
            {
                request.CertificateBasedAuthProperties = null;
            }
            if (cmdletContext.PropertiesToDelete != null)
            {
                request.PropertiesToDelete = cmdletContext.PropertiesToDelete;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
        
        private Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyCertificateBasedAuthProperties");
            try
            {
                return client.ModifyCertificateBasedAuthPropertiesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateBasedAuthProperties_CertificateAuthorityArn { get; set; }
            public Amazon.WorkSpaces.CertificateBasedAuthStatusEnum CertificateBasedAuthProperties_Status { get; set; }
            public List<System.String> PropertiesToDelete { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifyCertificateBasedAuthPropertiesResponse, EditWKSCertificateBasedAuthPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
