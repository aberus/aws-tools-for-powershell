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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates a transfer <i>location</i> for a Server Message Block (SMB) file server. DataSync
    /// can use this location as a source or destination for transferring data.
    /// 
    ///  
    /// <para>
    /// Before you begin, make sure that you understand how DataSync <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html#configuring-smb">accesses
    /// SMB file servers</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNLocationSmb", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationSmb API operation.", Operation = new[] {"CreateLocationSmb"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationSmbResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationSmbResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationSmbResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDSYNLocationSmbCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>Specifies the DataSync agent (or agents) that can connect to your SMB file server.
        /// You specify an agent by using its Amazon Resource Name (ARN).</para>
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
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Active Directory domain that your SMB file server belongs
        /// to. </para><para>If you have multiple Active Directory domains in your environment, configuring this
        /// parameter makes sure that DataSync connects to the right file server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>Specifies the password of the user who can mount your SMB file server and has permission
        /// to access the files and folders involved in your transfer.</para><para>For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html#configuring-smb-permissions">required
        /// permissions</a> for SMB locations.</para>
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
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter ServerHostname
        /// <summary>
        /// <para>
        /// <para>Specifies the Domain Name Service (DNS) name or IP address of the SMB file server
        /// that your DataSync agent will mount.</para><note><para>You can't specify an IP version 6 (IPv6) address.</para></note>
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
        public System.String ServerHostname { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the share exported by your SMB file server where DataSync will
        /// read or write data. You can include a subdirectory in the share path (for example,
        /// <c>/path/to/subdirectory</c>). Make sure that other SMB clients in your network can
        /// also mount this path.</para><para>To copy all data in the subdirectory, DataSync must be able to mount the SMB share
        /// and access all of its data. For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html#configuring-smb-permissions">required
        /// permissions</a> for SMB locations.</para>
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
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies labels that help you categorize, filter, and search for your Amazon Web
        /// Services resources. We recommend creating at least a name tag for your location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter User
        /// <summary>
        /// <para>
        /// <para>Specifies the user that can mount and access the files, folders, and file metadata
        /// in your SMB file server.</para><para>For information about choosing a user with the right level of access for your transfer,
        /// see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html#configuring-smb-permissions">required
        /// permissions</a> for SMB locations.</para>
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
        public System.String User { get; set; }
        #endregion
        
        #region Parameter MountOptions_Version
        /// <summary>
        /// <para>
        /// <para>By default, DataSync automatically chooses an SMB protocol version based on negotiation
        /// with your SMB file server. You also can configure DataSync to use a specific SMB version,
        /// but we recommend doing this only if DataSync has trouble negotiating with the SMB
        /// file server automatically.</para><para>These are the following options for configuring the SMB version:</para><ul><li><para><c>AUTOMATIC</c> (default): DataSync and the SMB file server negotiate the highest
        /// version of SMB that they mutually support between 2.1 and 3.1.1.</para><para>This is the recommended option. If you instead choose a specific version that your
        /// file server doesn't support, you may get an <c>Operation Not Supported</c> error.</para></li><li><para><c>SMB3</c>: Restricts the protocol negotiation to only SMB version 3.0.2.</para></li><li><para><c>SMB2</c>: Restricts the protocol negotiation to only SMB version 2.1.</para></li><li><para><c>SMB2_0</c>: Restricts the protocol negotiation to only SMB version 2.0.</para></li><li><para><c>SMB1</c>: Restricts the protocol negotiation to only SMB version 1.0.</para><note><para>The <c>SMB1</c> option isn't available when <a href="https://docs.aws.amazon.com/datasync/latest/userguide/API_CreateLocationFsxOntap.html">creating
        /// an Amazon FSx for NetApp ONTAP location</a>.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.SmbVersion")]
        public Amazon.DataSync.SmbVersion MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationSmbResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationSmbResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerHostname), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationSmb (CreateLocationSmb)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationSmbResponse, NewDSYNLocationSmbCmdlet>(Select) ??
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
            context.Domain = this.Domain;
            context.MountOptions_Version = this.MountOptions_Version;
            context.Password = this.Password;
            #if MODULAR
            if (this.Password == null && ParameterWasBound(nameof(this.Password)))
            {
                WriteWarning("You are passing $null as a value for parameter Password which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerHostname = this.ServerHostname;
            #if MODULAR
            if (this.ServerHostname == null && ParameterWasBound(nameof(this.ServerHostname)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerHostname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subdirectory = this.Subdirectory;
            #if MODULAR
            if (this.Subdirectory == null && ParameterWasBound(nameof(this.Subdirectory)))
            {
                WriteWarning("You are passing $null as a value for parameter Subdirectory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
            }
            context.User = this.User;
            #if MODULAR
            if (this.User == null && ParameterWasBound(nameof(this.User)))
            {
                WriteWarning("You are passing $null as a value for parameter User which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataSync.Model.CreateLocationSmbRequest();
            
            if (cmdletContext.AgentArn != null)
            {
                request.AgentArns = cmdletContext.AgentArn;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate MountOptions
            var requestMountOptionsIsNull = true;
            request.MountOptions = new Amazon.DataSync.Model.SmbMountOptions();
            Amazon.DataSync.SmbVersion requestMountOptions_mountOptions_Version = null;
            if (cmdletContext.MountOptions_Version != null)
            {
                requestMountOptions_mountOptions_Version = cmdletContext.MountOptions_Version;
            }
            if (requestMountOptions_mountOptions_Version != null)
            {
                request.MountOptions.Version = requestMountOptions_mountOptions_Version;
                requestMountOptionsIsNull = false;
            }
             // determine if request.MountOptions should be set to null
            if (requestMountOptionsIsNull)
            {
                request.MountOptions = null;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.ServerHostname != null)
            {
                request.ServerHostname = cmdletContext.ServerHostname;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.User != null)
            {
                request.User = cmdletContext.User;
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
        
        private Amazon.DataSync.Model.CreateLocationSmbResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationSmbRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationSmb");
            try
            {
                #if DESKTOP
                return client.CreateLocationSmb(request);
                #elif CORECLR
                return client.CreateLocationSmbAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AgentArn { get; set; }
            public System.String Domain { get; set; }
            public Amazon.DataSync.SmbVersion MountOptions_Version { get; set; }
            public System.String Password { get; set; }
            public System.String ServerHostname { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.String User { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationSmbResponse, NewDSYNLocationSmbCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
