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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Creates and returns a URL that you can use to connect to an application's extension.
    /// 
    ///  
    /// <para>
    /// The IAM role or user used to call this API defines the permissions to access the extension.
    /// After the presigned URL is created, no additional permission is required to access
    /// this URL. IAM authorization policies for this API are also enforced for every HTTP
    /// request that attempts to connect to the extension. 
    /// </para><para>
    /// You control the amount of time that the URL will be valid using the <c>SessionExpirationDurationInSeconds</c>
    /// parameter. If you do not provide this parameter, the returned URL is valid for twelve
    /// hours.
    /// </para><note><para>
    /// The URL that you get from a call to CreateApplicationPresignedUrl must be used within
    /// 3 minutes to be valid. If you first try to use the URL after the 3-minute limit expires,
    /// the service returns an HTTP 403 Forbidden error.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "KINA2ApplicationPresignedUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 CreateApplicationPresignedUrl API operation.", Operation = new[] {"CreateApplicationPresignedUrl"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKINA2ApplicationPresignedUrlCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter SessionExpirationDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The duration in seconds for which the returned URL will be valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionExpirationDurationInSeconds")]
        public System.Int64? SessionExpirationDurationInSecond { get; set; }
        #endregion
        
        #region Parameter UrlType
        /// <summary>
        /// <para>
        /// <para>The type of the extension for which to create and return a URL. Currently, the only
        /// valid extension URL type is <c>FLINK_DASHBOARD_URL</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.UrlType")]
        public Amazon.KinesisAnalyticsV2.UrlType UrlType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthorizedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthorizedUrl";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINA2ApplicationPresignedUrl (CreateApplicationPresignedUrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse, NewKINA2ApplicationPresignedUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionExpirationDurationInSecond = this.SessionExpirationDurationInSecond;
            context.UrlType = this.UrlType;
            #if MODULAR
            if (this.UrlType == null && ParameterWasBound(nameof(this.UrlType)))
            {
                WriteWarning("You are passing $null as a value for parameter UrlType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.SessionExpirationDurationInSecond != null)
            {
                request.SessionExpirationDurationInSeconds = cmdletContext.SessionExpirationDurationInSecond.Value;
            }
            if (cmdletContext.UrlType != null)
            {
                request.UrlType = cmdletContext.UrlType;
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
        
        private Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "CreateApplicationPresignedUrl");
            try
            {
                #if DESKTOP
                return client.CreateApplicationPresignedUrl(request);
                #elif CORECLR
                return client.CreateApplicationPresignedUrlAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.Int64? SessionExpirationDurationInSecond { get; set; }
            public Amazon.KinesisAnalyticsV2.UrlType UrlType { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.CreateApplicationPresignedUrlResponse, NewKINA2ApplicationPresignedUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthorizedUrl;
        }
        
    }
}
