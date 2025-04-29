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
using Amazon.ApplicationInsights;
using Amazon.ApplicationInsights.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWAI
{
    /// <summary>
    /// Adds an application that is created from a resource group.
    /// </summary>
    [Cmdlet("New", "CWAIApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationInsights.Model.ApplicationInfo")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Insights CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.ApplicationInsights.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.ApplicationInsights.Model.ApplicationInfo or Amazon.ApplicationInsights.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.ApplicationInsights.Model.ApplicationInfo object.",
        "The service call response (type Amazon.ApplicationInsights.Model.CreateApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWAIApplicationCmdlet : AmazonApplicationInsightsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttachMissingPermission
        /// <summary>
        /// <para>
        /// <para>If set to true, the managed policies for SSM and CW will be attached to the instance
        /// roles if they are missing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AttachMissingPermission { get; set; }
        #endregion
        
        #region Parameter AutoConfigEnabled
        /// <summary>
        /// <para>
        /// <para> Indicates whether Application Insights automatically configures unmonitored resources
        /// in the resource group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoConfigEnabled { get; set; }
        #endregion
        
        #region Parameter AutoCreate
        /// <summary>
        /// <para>
        /// <para> Configures all of the resources in the resource group by applying the recommended
        /// configurations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoCreate { get; set; }
        #endregion
        
        #region Parameter CWEMonitorEnabled
        /// <summary>
        /// <para>
        /// <para> Indicates whether Application Insights can listen to CloudWatch events for the application
        /// resources, such as <c>instance terminated</c>, <c>failed deployment</c>, and others.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CWEMonitorEnabled { get; set; }
        #endregion
        
        #region Parameter GroupingType
        /// <summary>
        /// <para>
        /// <para>Application Insights can create applications based on a resource group or on an account.
        /// To create an account-based application using all of the resources in the account,
        /// set this parameter to <c>ACCOUNT_BASED</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationInsights.GroupingType")]
        public Amazon.ApplicationInsights.GroupingType GroupingType { get; set; }
        #endregion
        
        #region Parameter OpsCenterEnabled
        /// <summary>
        /// <para>
        /// <para> When set to <c>true</c>, creates opsItems for any problems detected on an application.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OpsCenterEnabled { get; set; }
        #endregion
        
        #region Parameter OpsItemSNSTopicArn
        /// <summary>
        /// <para>
        /// <para> The SNS topic provided to Application Insights that is associated to the created
        /// opsItem. Allows you to receive notifications for updates to the opsItem. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpsItemSNSTopicArn { get; set; }
        #endregion
        
        #region Parameter ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resource group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter SNSNotificationArn
        /// <summary>
        /// <para>
        /// <para> The SNS notification topic ARN. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SNSNotificationArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags to add to the application. tag key (<c>Key</c>) and an associated tag
        /// value (<c>Value</c>). The maximum length of a tag key is 128 characters. The maximum
        /// length of a tag value is 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ApplicationInsights.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationInfo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationInsights.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.ApplicationInsights.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationInfo";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWAIApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationInsights.Model.CreateApplicationResponse, NewCWAIApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachMissingPermission = this.AttachMissingPermission;
            context.AutoConfigEnabled = this.AutoConfigEnabled;
            context.AutoCreate = this.AutoCreate;
            context.CWEMonitorEnabled = this.CWEMonitorEnabled;
            context.GroupingType = this.GroupingType;
            context.OpsCenterEnabled = this.OpsCenterEnabled;
            context.OpsItemSNSTopicArn = this.OpsItemSNSTopicArn;
            context.ResourceGroupName = this.ResourceGroupName;
            context.SNSNotificationArn = this.SNSNotificationArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ApplicationInsights.Model.Tag>(this.Tag);
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
            var request = new Amazon.ApplicationInsights.Model.CreateApplicationRequest();
            
            if (cmdletContext.AttachMissingPermission != null)
            {
                request.AttachMissingPermission = cmdletContext.AttachMissingPermission.Value;
            }
            if (cmdletContext.AutoConfigEnabled != null)
            {
                request.AutoConfigEnabled = cmdletContext.AutoConfigEnabled.Value;
            }
            if (cmdletContext.AutoCreate != null)
            {
                request.AutoCreate = cmdletContext.AutoCreate.Value;
            }
            if (cmdletContext.CWEMonitorEnabled != null)
            {
                request.CWEMonitorEnabled = cmdletContext.CWEMonitorEnabled.Value;
            }
            if (cmdletContext.GroupingType != null)
            {
                request.GroupingType = cmdletContext.GroupingType;
            }
            if (cmdletContext.OpsCenterEnabled != null)
            {
                request.OpsCenterEnabled = cmdletContext.OpsCenterEnabled.Value;
            }
            if (cmdletContext.OpsItemSNSTopicArn != null)
            {
                request.OpsItemSNSTopicArn = cmdletContext.OpsItemSNSTopicArn;
            }
            if (cmdletContext.ResourceGroupName != null)
            {
                request.ResourceGroupName = cmdletContext.ResourceGroupName;
            }
            if (cmdletContext.SNSNotificationArn != null)
            {
                request.SNSNotificationArn = cmdletContext.SNSNotificationArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ApplicationInsights.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonApplicationInsights client, Amazon.ApplicationInsights.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Insights", "CreateApplication");
            try
            {
                return client.CreateApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AttachMissingPermission { get; set; }
            public System.Boolean? AutoConfigEnabled { get; set; }
            public System.Boolean? AutoCreate { get; set; }
            public System.Boolean? CWEMonitorEnabled { get; set; }
            public Amazon.ApplicationInsights.GroupingType GroupingType { get; set; }
            public System.Boolean? OpsCenterEnabled { get; set; }
            public System.String OpsItemSNSTopicArn { get; set; }
            public System.String ResourceGroupName { get; set; }
            public System.String SNSNotificationArn { get; set; }
            public List<Amazon.ApplicationInsights.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ApplicationInsights.Model.CreateApplicationResponse, NewCWAIApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationInfo;
        }
        
    }
}
