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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Update an origin access identity.
    /// </summary>
    [Cmdlet("Update", "CFCloudFrontOriginAccessIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentity")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateCloudFrontOriginAccessIdentity API operation.", Operation = new[] {"UpdateCloudFrontOriginAccessIdentity"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentity or Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CloudFrontOriginAccessIdentity object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFCloudFrontOriginAccessIdentityCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique value (for example, a date-time stamp) that ensures that the request can't
        /// be replayed.</para><para>If the value of <c>CallerReference</c> is new (regardless of the content of the <c>CloudFrontOriginAccessIdentityConfig</c>
        /// object), a new origin access identity is created.</para><para>If the <c>CallerReference</c> is a value already sent in a previous identity request,
        /// and the content of the <c>CloudFrontOriginAccessIdentityConfig</c> is identical to
        /// the original request (ignoring white space), the response includes the same information
        /// returned to the original request.</para><para>If the <c>CallerReference</c> is a value you already sent in a previous request to
        /// create an identity, but the content of the <c>CloudFrontOriginAccessIdentityConfig</c>
        /// is different from the original request, CloudFront returns a <c>CloudFrontOriginAccessIdentityAlreadyExists</c>
        /// error. </para>
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
        public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the origin access identity. The comment cannot be longer than
        /// 128 characters.</para>
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
        public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identity's id.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <c>ETag</c> header that you received when retrieving the identity's
        /// configuration. For example: <c>E2QWRUHAPOMQZL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CloudFrontOriginAccessIdentity'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CloudFrontOriginAccessIdentity";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFCloudFrontOriginAccessIdentity (UpdateCloudFrontOriginAccessIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse, UpdateCFCloudFrontOriginAccessIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudFrontOriginAccessIdentityConfig_CallerReference = this.CloudFrontOriginAccessIdentityConfig_CallerReference;
            #if MODULAR
            if (this.CloudFrontOriginAccessIdentityConfig_CallerReference == null && ParameterWasBound(nameof(this.CloudFrontOriginAccessIdentityConfig_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudFrontOriginAccessIdentityConfig_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudFrontOriginAccessIdentityConfig_Comment = this.CloudFrontOriginAccessIdentityConfig_Comment;
            #if MODULAR
            if (this.CloudFrontOriginAccessIdentityConfig_Comment == null && ParameterWasBound(nameof(this.CloudFrontOriginAccessIdentityConfig_Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudFrontOriginAccessIdentityConfig_Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            
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
            var request = new Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityRequest();
            
            
             // populate CloudFrontOriginAccessIdentityConfig
            var requestCloudFrontOriginAccessIdentityConfigIsNull = true;
            request.CloudFrontOriginAccessIdentityConfig = new Amazon.CloudFront.Model.CloudFrontOriginAccessIdentityConfig();
            System.String requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference = null;
            if (cmdletContext.CloudFrontOriginAccessIdentityConfig_CallerReference != null)
            {
                requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference = cmdletContext.CloudFrontOriginAccessIdentityConfig_CallerReference;
            }
            if (requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference != null)
            {
                request.CloudFrontOriginAccessIdentityConfig.CallerReference = requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference;
                requestCloudFrontOriginAccessIdentityConfigIsNull = false;
            }
            System.String requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment = null;
            if (cmdletContext.CloudFrontOriginAccessIdentityConfig_Comment != null)
            {
                requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment = cmdletContext.CloudFrontOriginAccessIdentityConfig_Comment;
            }
            if (requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment != null)
            {
                request.CloudFrontOriginAccessIdentityConfig.Comment = requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment;
                requestCloudFrontOriginAccessIdentityConfigIsNull = false;
            }
             // determine if request.CloudFrontOriginAccessIdentityConfig should be set to null
            if (requestCloudFrontOriginAccessIdentityConfigIsNull)
            {
                request.CloudFrontOriginAccessIdentityConfig = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
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
        
        private Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateCloudFrontOriginAccessIdentity");
            try
            {
                #if DESKTOP
                return client.UpdateCloudFrontOriginAccessIdentity(request);
                #elif CORECLR
                return client.UpdateCloudFrontOriginAccessIdentityAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
            public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse, UpdateCFCloudFrontOriginAccessIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CloudFrontOriginAccessIdentity;
        }
        
    }
}
