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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Generates an embed URL that you can use to embed an Amazon QuickSight dashboard in
    /// your website, without having to register any reader users. Before you use this action,
    /// make sure that you have configured the dashboards and permissions.
    /// 
    ///  
    /// <para>
    /// The following rules apply to the generated URL:
    /// </para><ul><li><para>
    /// It contains a temporary bearer token. It is valid for 5 minutes after it is generated.
    /// Once redeemed within this period, it cannot be re-used again.
    /// </para></li><li><para>
    /// The URL validity period should not be confused with the actual session lifetime that
    /// can be customized using the <code><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_GenerateEmbedUrlForAnonymousUser.html#QS-GenerateEmbedUrlForAnonymousUser-request-SessionLifetimeInMinutes">SessionLifetimeInMinutes</a></code> parameter.
    /// </para><para>
    /// The resulting user session is valid for 15 minutes (default) to 10 hours (maximum).
    /// </para></li><li><para>
    /// You are charged only when the URL is used or there is interaction with Amazon QuickSight.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/embedded-analytics.html">Embedded
    /// Analytics</a> in the <i>Amazon QuickSight User Guide</i>.
    /// </para><para>
    /// For more information about the high-level steps for embedding and for an interactive
    /// demo of the ways you can customize embedding, visit the <a href="https://docs.aws.amazon.com/quicksight/latest/user/quicksight-dev-portal.html">Amazon
    /// QuickSight Developer Portal</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSEmbedUrlForAnonymousUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GenerateEmbedUrlForAnonymousUser API operation.", Operation = new[] {"GenerateEmbedUrlForAnonymousUser"}, SelectReturnType = typeof(Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQSEmbedUrlForAnonymousUserCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizedResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names for the Amazon QuickSight resources that the user is authorized
        /// to access during the lifetime of the session. If you choose <code>Dashboard</code>
        /// embedding experience, pass the list of dashboard ARNs in the account that you want
        /// the user to be able to view.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AuthorizedResourceArns")]
        public System.String[] AuthorizedResourceArn { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that contains the dashboard that you're
        /// embedding.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Dashboard_InitialDashboardId
        /// <summary>
        /// <para>
        /// <para>The dashboard ID for the dashboard that you want the user to see first. This ID is
        /// included in the output URL. When the URL in response is accessed, Amazon QuickSight
        /// renders this dashboard.</para><para>The Amazon Resource Name (ARN) of this dashboard must be included in the <code>AuthorizedResourceArns</code>
        /// parameter. Otherwise, the request will fail with <code>InvalidParameterValueException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_InitialDashboardId")]
        public System.String Dashboard_InitialDashboardId { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight namespace that the anonymous user virtually belongs to. If you
        /// are not using an Amazon QuickSight custom namespace, set this to <code>default</code>.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter SessionLifetimeInMinute
        /// <summary>
        /// <para>
        /// <para>How many minutes the session is valid. The session lifetime must be in [15-600] minutes
        /// range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionLifetimeInMinutes")]
        public System.Int64? SessionLifetimeInMinute { get; set; }
        #endregion
        
        #region Parameter SessionTag
        /// <summary>
        /// <para>
        /// <para>The session tags used for row-level security. Before you use this parameter, make
        /// sure that you have configured the relevant datasets using the <code>DataSet$RowLevelPermissionTagConfiguration</code>
        /// parameter so that session tags can be used to provide row-level security.</para><para>These are not the tags used for the Amazon Web Services resource tagging feature.
        /// For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/quicksight-dev-rls-tags.html">Using
        /// Row-Level Security (RLS) with Tags</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionTags")]
        public Amazon.QuickSight.Model.SessionTag[] SessionTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmbedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmbedUrl";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSEmbedUrlForAnonymousUser (GenerateEmbedUrlForAnonymousUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse, NewQSEmbedUrlForAnonymousUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AuthorizedResourceArn != null)
            {
                context.AuthorizedResourceArn = new List<System.String>(this.AuthorizedResourceArn);
            }
            #if MODULAR
            if (this.AuthorizedResourceArn == null && ParameterWasBound(nameof(this.AuthorizedResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizedResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Dashboard_InitialDashboardId = this.Dashboard_InitialDashboardId;
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionLifetimeInMinute = this.SessionLifetimeInMinute;
            if (this.SessionTag != null)
            {
                context.SessionTag = new List<Amazon.QuickSight.Model.SessionTag>(this.SessionTag);
            }
            
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
            var request = new Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserRequest();
            
            if (cmdletContext.AuthorizedResourceArn != null)
            {
                request.AuthorizedResourceArns = cmdletContext.AuthorizedResourceArn;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate ExperienceConfiguration
            var requestExperienceConfigurationIsNull = true;
            request.ExperienceConfiguration = new Amazon.QuickSight.Model.AnonymousUserEmbeddingExperienceConfiguration();
            Amazon.QuickSight.Model.AnonymousUserDashboardEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_Dashboard = null;
            
             // populate Dashboard
            var requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard = new Amazon.QuickSight.Model.AnonymousUserDashboardEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId = null;
            if (cmdletContext.Dashboard_InitialDashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId = cmdletContext.Dashboard_InitialDashboardId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard.InitialDashboardId = requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId;
                requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_DashboardIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard != null)
            {
                request.ExperienceConfiguration.Dashboard = requestExperienceConfiguration_experienceConfiguration_Dashboard;
                requestExperienceConfigurationIsNull = false;
            }
             // determine if request.ExperienceConfiguration should be set to null
            if (requestExperienceConfigurationIsNull)
            {
                request.ExperienceConfiguration = null;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.SessionLifetimeInMinute != null)
            {
                request.SessionLifetimeInMinutes = cmdletContext.SessionLifetimeInMinute.Value;
            }
            if (cmdletContext.SessionTag != null)
            {
                request.SessionTags = cmdletContext.SessionTag;
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
        
        private Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "GenerateEmbedUrlForAnonymousUser");
            try
            {
                #if DESKTOP
                return client.GenerateEmbedUrlForAnonymousUser(request);
                #elif CORECLR
                return client.GenerateEmbedUrlForAnonymousUserAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AuthorizedResourceArn { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String Dashboard_InitialDashboardId { get; set; }
            public System.String Namespace { get; set; }
            public System.Int64? SessionLifetimeInMinute { get; set; }
            public List<Amazon.QuickSight.Model.SessionTag> SessionTag { get; set; }
            public System.Func<Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse, NewQSEmbedUrlForAnonymousUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmbedUrl;
        }
        
    }
}
