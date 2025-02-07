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
    /// Updates an existing Managed Service for Apache Flink application. Using this operation,
    /// you can update application code, input configuration, and output configuration. 
    /// 
    ///  
    /// <para>
    /// Managed Service for Apache Flink updates the <c>ApplicationVersionId</c> each time
    /// you update your application. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINA2Application", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail or Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.ApplicationDetail object.",
        "The service call response (type Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateKINA2ApplicationCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationConfigurationUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application configuration updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisAnalyticsV2.Model.ApplicationConfigurationUpdate ApplicationConfigurationUpdate { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application to update.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptionUpdate
        /// <summary>
        /// <para>
        /// <para>Describes application Amazon CloudWatch logging option updates. You can only update
        /// existing CloudWatch logging options with this action. To add a new CloudWatch logging
        /// option, use <a>AddApplicationCloudWatchLoggingOption</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudWatchLoggingOptionUpdates")]
        public Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOptionUpdate[] CloudWatchLoggingOptionUpdate { get; set; }
        #endregion
        
        #region Parameter ConditionalToken
        /// <summary>
        /// <para>
        /// <para>A value you use to implement strong concurrency for application updates. You must
        /// provide the <c>CurrentApplicationVersionId</c> or the <c>ConditionalToken</c>. You
        /// get the application's current <c>ConditionalToken</c> using <a>DescribeApplication</a>.
        /// For better concurrency support, use the <c>ConditionalToken</c> parameter instead
        /// of <c>CurrentApplicationVersionId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConditionalToken { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The current application version ID. You must provide the <c>CurrentApplicationVersionId</c>
        /// or the <c>ConditionalToken</c>.You can retrieve the application version ID using <a>DescribeApplication</a>.
        /// For better concurrency support, use the <c>ConditionalToken</c> parameter instead
        /// of <c>CurrentApplicationVersionId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter RunConfigurationUpdate
        /// <summary>
        /// <para>
        /// <para>Describes updates to the application's starting parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisAnalyticsV2.Model.RunConfigurationUpdate RunConfigurationUpdate { get; set; }
        #endregion
        
        #region Parameter RuntimeEnvironmentUpdate
        /// <summary>
        /// <para>
        /// <para>Updates the Managed Service for Apache Flink runtime environment used to run your
        /// code. To avoid issues you must:</para><ul><li><para>Ensure your new jar and dependencies are compatible with the new runtime selected.</para></li><li><para>Ensure your new code's state is compatible with the snapshot from which your application
        /// will start</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.RuntimeEnvironment")]
        public Amazon.KinesisAnalyticsV2.RuntimeEnvironment RuntimeEnvironmentUpdate { get; set; }
        #endregion
        
        #region Parameter ServiceExecutionRoleUpdate
        /// <summary>
        /// <para>
        /// <para>Describes updates to the service execution role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceExecutionRoleUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationDetail";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINA2Application (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse, UpdateKINA2ApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationConfigurationUpdate = this.ApplicationConfigurationUpdate;
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CloudWatchLoggingOptionUpdate != null)
            {
                context.CloudWatchLoggingOptionUpdate = new List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOptionUpdate>(this.CloudWatchLoggingOptionUpdate);
            }
            context.ConditionalToken = this.ConditionalToken;
            context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            context.RunConfigurationUpdate = this.RunConfigurationUpdate;
            context.RuntimeEnvironmentUpdate = this.RuntimeEnvironmentUpdate;
            context.ServiceExecutionRoleUpdate = this.ServiceExecutionRoleUpdate;
            
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
            var request = new Amazon.KinesisAnalyticsV2.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationConfigurationUpdate != null)
            {
                request.ApplicationConfigurationUpdate = cmdletContext.ApplicationConfigurationUpdate;
            }
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CloudWatchLoggingOptionUpdate != null)
            {
                request.CloudWatchLoggingOptionUpdates = cmdletContext.CloudWatchLoggingOptionUpdate;
            }
            if (cmdletContext.ConditionalToken != null)
            {
                request.ConditionalToken = cmdletContext.ConditionalToken;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            if (cmdletContext.RunConfigurationUpdate != null)
            {
                request.RunConfigurationUpdate = cmdletContext.RunConfigurationUpdate;
            }
            if (cmdletContext.RuntimeEnvironmentUpdate != null)
            {
                request.RuntimeEnvironmentUpdate = cmdletContext.RuntimeEnvironmentUpdate;
            }
            if (cmdletContext.ServiceExecutionRoleUpdate != null)
            {
                request.ServiceExecutionRoleUpdate = cmdletContext.ServiceExecutionRoleUpdate;
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
        
        private Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "UpdateApplication");
            try
            {
                #if DESKTOP
                return client.UpdateApplication(request);
                #elif CORECLR
                return client.UpdateApplicationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KinesisAnalyticsV2.Model.ApplicationConfigurationUpdate ApplicationConfigurationUpdate { get; set; }
            public System.String ApplicationName { get; set; }
            public List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOptionUpdate> CloudWatchLoggingOptionUpdate { get; set; }
            public System.String ConditionalToken { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public Amazon.KinesisAnalyticsV2.Model.RunConfigurationUpdate RunConfigurationUpdate { get; set; }
            public Amazon.KinesisAnalyticsV2.RuntimeEnvironment RuntimeEnvironmentUpdate { get; set; }
            public System.String ServiceExecutionRoleUpdate { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.UpdateApplicationResponse, UpdateKINA2ApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationDetail;
        }
        
    }
}
