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
using Amazon.DataSync;
using Amazon.DataSync.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates an Amazon Web Services resource for an on-premises storage system that you
    /// want DataSync Discovery to collect information about.
    /// </summary>
    [Cmdlet("Add", "DSYNStorageSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync AddStorageSystem API operation.", Operation = new[] {"AddStorageSystem"}, SelectReturnType = typeof(Amazon.DataSync.Model.AddStorageSystemResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.AddStorageSystemResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.AddStorageSystemResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddDSYNStorageSystemCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the DataSync agent that connects to and
        /// reads from your on-premises storage system's management interface. You can only specify
        /// one ARN.</para>
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
        [Alias("AgentArns")]
        public System.String[] AgentArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogGroupArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the Amazon CloudWatch log group for monitoring and logging discovery
        /// job events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogGroupArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies a familiar name for your on-premises storage system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Credentials_Password
        /// <summary>
        /// <para>
        /// <para>Specifies the password for your storage system's management interface.</para>
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
        public System.String Credentials_Password { get; set; }
        #endregion
        
        #region Parameter ServerConfiguration_ServerHostname
        /// <summary>
        /// <para>
        /// <para>The domain name or IP address of your storage system's management interface.</para>
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
        public System.String ServerConfiguration_ServerHostname { get; set; }
        #endregion
        
        #region Parameter ServerConfiguration_ServerPort
        /// <summary>
        /// <para>
        /// <para>The network port for accessing the storage system's management interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ServerConfiguration_ServerPort { get; set; }
        #endregion
        
        #region Parameter SystemType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of on-premises storage system that you want DataSync Discovery
        /// to collect information about.</para><note><para>DataSync Discovery currently supports NetApp Fabric-Attached Storage (FAS) and All
        /// Flash FAS (AFF) systems running ONTAP 9.7 or later.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataSync.DiscoverySystemType")]
        public Amazon.DataSync.DiscoverySystemType SystemType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies labels that help you categorize, filter, and search for your Amazon Web
        /// Services resources. We recommend creating at least a name tag for your on-premises
        /// storage system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter Credentials_Username
        /// <summary>
        /// <para>
        /// <para>Specifies the user name for your storage system's management interface.</para>
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
        public System.String Credentials_Username { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a client token to make sure requests with this API operation are idempotent.
        /// If you don't specify a client token, DataSync generates one for you automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StorageSystemArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.AddStorageSystemResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.AddStorageSystemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StorageSystemArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DSYNStorageSystem (AddStorageSystem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.AddStorageSystemResponse, AddDSYNStorageSystemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            #if MODULAR
            if (this.AgentArn == null && ParameterWasBound(nameof(this.AgentArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.CloudWatchLogGroupArn = this.CloudWatchLogGroupArn;
            context.Credentials_Password = this.Credentials_Password;
            #if MODULAR
            if (this.Credentials_Password == null && ParameterWasBound(nameof(this.Credentials_Password)))
            {
                WriteWarning("You are passing $null as a value for parameter Credentials_Password which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Credentials_Username = this.Credentials_Username;
            #if MODULAR
            if (this.Credentials_Username == null && ParameterWasBound(nameof(this.Credentials_Username)))
            {
                WriteWarning("You are passing $null as a value for parameter Credentials_Username which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.ServerConfiguration_ServerHostname = this.ServerConfiguration_ServerHostname;
            #if MODULAR
            if (this.ServerConfiguration_ServerHostname == null && ParameterWasBound(nameof(this.ServerConfiguration_ServerHostname)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerConfiguration_ServerHostname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerConfiguration_ServerPort = this.ServerConfiguration_ServerPort;
            context.SystemType = this.SystemType;
            #if MODULAR
            if (this.SystemType == null && ParameterWasBound(nameof(this.SystemType)))
            {
                WriteWarning("You are passing $null as a value for parameter SystemType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            var request = new Amazon.DataSync.Model.AddStorageSystemRequest();
            
            if (cmdletContext.AgentArn != null)
            {
                request.AgentArns = cmdletContext.AgentArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CloudWatchLogGroupArn != null)
            {
                request.CloudWatchLogGroupArn = cmdletContext.CloudWatchLogGroupArn;
            }
            
             // populate Credentials
            var requestCredentialsIsNull = true;
            request.Credentials = new Amazon.DataSync.Model.Credentials();
            System.String requestCredentials_credentials_Password = null;
            if (cmdletContext.Credentials_Password != null)
            {
                requestCredentials_credentials_Password = cmdletContext.Credentials_Password;
            }
            if (requestCredentials_credentials_Password != null)
            {
                request.Credentials.Password = requestCredentials_credentials_Password;
                requestCredentialsIsNull = false;
            }
            System.String requestCredentials_credentials_Username = null;
            if (cmdletContext.Credentials_Username != null)
            {
                requestCredentials_credentials_Username = cmdletContext.Credentials_Username;
            }
            if (requestCredentials_credentials_Username != null)
            {
                request.Credentials.Username = requestCredentials_credentials_Username;
                requestCredentialsIsNull = false;
            }
             // determine if request.Credentials should be set to null
            if (requestCredentialsIsNull)
            {
                request.Credentials = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ServerConfiguration
            var requestServerConfigurationIsNull = true;
            request.ServerConfiguration = new Amazon.DataSync.Model.DiscoveryServerConfiguration();
            System.String requestServerConfiguration_serverConfiguration_ServerHostname = null;
            if (cmdletContext.ServerConfiguration_ServerHostname != null)
            {
                requestServerConfiguration_serverConfiguration_ServerHostname = cmdletContext.ServerConfiguration_ServerHostname;
            }
            if (requestServerConfiguration_serverConfiguration_ServerHostname != null)
            {
                request.ServerConfiguration.ServerHostname = requestServerConfiguration_serverConfiguration_ServerHostname;
                requestServerConfigurationIsNull = false;
            }
            System.Int32? requestServerConfiguration_serverConfiguration_ServerPort = null;
            if (cmdletContext.ServerConfiguration_ServerPort != null)
            {
                requestServerConfiguration_serverConfiguration_ServerPort = cmdletContext.ServerConfiguration_ServerPort.Value;
            }
            if (requestServerConfiguration_serverConfiguration_ServerPort != null)
            {
                request.ServerConfiguration.ServerPort = requestServerConfiguration_serverConfiguration_ServerPort.Value;
                requestServerConfigurationIsNull = false;
            }
             // determine if request.ServerConfiguration should be set to null
            if (requestServerConfigurationIsNull)
            {
                request.ServerConfiguration = null;
            }
            if (cmdletContext.SystemType != null)
            {
                request.SystemType = cmdletContext.SystemType;
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
        
        private Amazon.DataSync.Model.AddStorageSystemResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.AddStorageSystemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "AddStorageSystem");
            try
            {
                return client.AddStorageSystemAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AgentArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CloudWatchLogGroupArn { get; set; }
            public System.String Credentials_Password { get; set; }
            public System.String Credentials_Username { get; set; }
            public System.String Name { get; set; }
            public System.String ServerConfiguration_ServerHostname { get; set; }
            public System.Int32? ServerConfiguration_ServerPort { get; set; }
            public Amazon.DataSync.DiscoverySystemType SystemType { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.AddStorageSystemResponse, AddDSYNStorageSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StorageSystemArn;
        }
        
    }
}
