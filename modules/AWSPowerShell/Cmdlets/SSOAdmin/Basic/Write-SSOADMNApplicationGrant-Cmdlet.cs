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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Adds a grant to an application.
    /// </summary>
    [Cmdlet("Write", "SSOADMNApplicationGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin PutApplicationGrant API operation.", Operation = new[] {"PutApplicationGrant"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.PutApplicationGrantResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.PutApplicationGrantResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.PutApplicationGrantResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSSOADMNApplicationGrantCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the application to update.</para>
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
        public System.String ApplicationArn { get; set; }
        #endregion
        
        #region Parameter JwtBearer_AuthorizedTokenIssuer
        /// <summary>
        /// <para>
        /// <para>A list of allowed token issuers trusted by the Identity Center instances for this
        /// application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Grant_JwtBearer_AuthorizedTokenIssuers")]
        public Amazon.SSOAdmin.Model.AuthorizedTokenIssuer[] JwtBearer_AuthorizedTokenIssuer { get; set; }
        #endregion
        
        #region Parameter GrantType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of grant to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSOAdmin.GrantType")]
        public Amazon.SSOAdmin.GrantType GrantType { get; set; }
        #endregion
        
        #region Parameter AuthorizationCode_RedirectUris
        /// <summary>
        /// <para>
        /// <para>A list of URIs that are valid locations to redirect a user's browser after the user
        /// is authorized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Grant_AuthorizationCode_RedirectUris")]
        public System.String[] AuthorizationCode_RedirectUris { get; set; }
        #endregion
        
        #region Parameter Grant_RefreshToken
        /// <summary>
        /// <para>
        /// <para>Configuration options for the <c>refresh_token</c> grant type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SSOAdmin.Model.RefreshTokenGrant Grant_RefreshToken { get; set; }
        #endregion
        
        #region Parameter Grant_TokenExchange
        /// <summary>
        /// <para>
        /// <para>Configuration options for the <c>urn:ietf:params:oauth:grant-type:token-exchange</c>
        /// grant type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SSOAdmin.Model.TokenExchangeGrant Grant_TokenExchange { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.PutApplicationGrantResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SSOADMNApplicationGrant (PutApplicationGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.PutApplicationGrantResponse, WriteSSOADMNApplicationGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationArn = this.ApplicationArn;
            #if MODULAR
            if (this.ApplicationArn == null && ParameterWasBound(nameof(this.ApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AuthorizationCode_RedirectUris != null)
            {
                context.AuthorizationCode_RedirectUris = new List<System.String>(this.AuthorizationCode_RedirectUris);
            }
            if (this.JwtBearer_AuthorizedTokenIssuer != null)
            {
                context.JwtBearer_AuthorizedTokenIssuer = new List<Amazon.SSOAdmin.Model.AuthorizedTokenIssuer>(this.JwtBearer_AuthorizedTokenIssuer);
            }
            context.Grant_RefreshToken = this.Grant_RefreshToken;
            context.Grant_TokenExchange = this.Grant_TokenExchange;
            context.GrantType = this.GrantType;
            #if MODULAR
            if (this.GrantType == null && ParameterWasBound(nameof(this.GrantType)))
            {
                WriteWarning("You are passing $null as a value for parameter GrantType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.PutApplicationGrantRequest();
            
            if (cmdletContext.ApplicationArn != null)
            {
                request.ApplicationArn = cmdletContext.ApplicationArn;
            }
            
             // populate Grant
            var requestGrantIsNull = true;
            request.Grant = new Amazon.SSOAdmin.Model.Grant();
            Amazon.SSOAdmin.Model.RefreshTokenGrant requestGrant_grant_RefreshToken = null;
            if (cmdletContext.Grant_RefreshToken != null)
            {
                requestGrant_grant_RefreshToken = cmdletContext.Grant_RefreshToken;
            }
            if (requestGrant_grant_RefreshToken != null)
            {
                request.Grant.RefreshToken = requestGrant_grant_RefreshToken;
                requestGrantIsNull = false;
            }
            Amazon.SSOAdmin.Model.TokenExchangeGrant requestGrant_grant_TokenExchange = null;
            if (cmdletContext.Grant_TokenExchange != null)
            {
                requestGrant_grant_TokenExchange = cmdletContext.Grant_TokenExchange;
            }
            if (requestGrant_grant_TokenExchange != null)
            {
                request.Grant.TokenExchange = requestGrant_grant_TokenExchange;
                requestGrantIsNull = false;
            }
            Amazon.SSOAdmin.Model.AuthorizationCodeGrant requestGrant_grant_AuthorizationCode = null;
            
             // populate AuthorizationCode
            var requestGrant_grant_AuthorizationCodeIsNull = true;
            requestGrant_grant_AuthorizationCode = new Amazon.SSOAdmin.Model.AuthorizationCodeGrant();
            List<System.String> requestGrant_grant_AuthorizationCode_authorizationCode_RedirectUris = null;
            if (cmdletContext.AuthorizationCode_RedirectUris != null)
            {
                requestGrant_grant_AuthorizationCode_authorizationCode_RedirectUris = cmdletContext.AuthorizationCode_RedirectUris;
            }
            if (requestGrant_grant_AuthorizationCode_authorizationCode_RedirectUris != null)
            {
                requestGrant_grant_AuthorizationCode.RedirectUris = requestGrant_grant_AuthorizationCode_authorizationCode_RedirectUris;
                requestGrant_grant_AuthorizationCodeIsNull = false;
            }
             // determine if requestGrant_grant_AuthorizationCode should be set to null
            if (requestGrant_grant_AuthorizationCodeIsNull)
            {
                requestGrant_grant_AuthorizationCode = null;
            }
            if (requestGrant_grant_AuthorizationCode != null)
            {
                request.Grant.AuthorizationCode = requestGrant_grant_AuthorizationCode;
                requestGrantIsNull = false;
            }
            Amazon.SSOAdmin.Model.JwtBearerGrant requestGrant_grant_JwtBearer = null;
            
             // populate JwtBearer
            var requestGrant_grant_JwtBearerIsNull = true;
            requestGrant_grant_JwtBearer = new Amazon.SSOAdmin.Model.JwtBearerGrant();
            List<Amazon.SSOAdmin.Model.AuthorizedTokenIssuer> requestGrant_grant_JwtBearer_jwtBearer_AuthorizedTokenIssuer = null;
            if (cmdletContext.JwtBearer_AuthorizedTokenIssuer != null)
            {
                requestGrant_grant_JwtBearer_jwtBearer_AuthorizedTokenIssuer = cmdletContext.JwtBearer_AuthorizedTokenIssuer;
            }
            if (requestGrant_grant_JwtBearer_jwtBearer_AuthorizedTokenIssuer != null)
            {
                requestGrant_grant_JwtBearer.AuthorizedTokenIssuers = requestGrant_grant_JwtBearer_jwtBearer_AuthorizedTokenIssuer;
                requestGrant_grant_JwtBearerIsNull = false;
            }
             // determine if requestGrant_grant_JwtBearer should be set to null
            if (requestGrant_grant_JwtBearerIsNull)
            {
                requestGrant_grant_JwtBearer = null;
            }
            if (requestGrant_grant_JwtBearer != null)
            {
                request.Grant.JwtBearer = requestGrant_grant_JwtBearer;
                requestGrantIsNull = false;
            }
             // determine if request.Grant should be set to null
            if (requestGrantIsNull)
            {
                request.Grant = null;
            }
            if (cmdletContext.GrantType != null)
            {
                request.GrantType = cmdletContext.GrantType;
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
        
        private Amazon.SSOAdmin.Model.PutApplicationGrantResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.PutApplicationGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "PutApplicationGrant");
            try
            {
                return client.PutApplicationGrantAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationArn { get; set; }
            public List<System.String> AuthorizationCode_RedirectUris { get; set; }
            public List<Amazon.SSOAdmin.Model.AuthorizedTokenIssuer> JwtBearer_AuthorizedTokenIssuer { get; set; }
            public Amazon.SSOAdmin.Model.RefreshTokenGrant Grant_RefreshToken { get; set; }
            public Amazon.SSOAdmin.Model.TokenExchangeGrant Grant_TokenExchange { get; set; }
            public Amazon.SSOAdmin.GrantType GrantType { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.PutApplicationGrantResponse, WriteSSOADMNApplicationGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
