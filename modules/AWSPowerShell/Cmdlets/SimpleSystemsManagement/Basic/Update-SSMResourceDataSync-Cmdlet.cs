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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Update a resource data sync. After you create a resource data sync for a Region, you
    /// can't change the account options for that sync. For example, if you create a sync
    /// in the us-east-2 (Ohio) Region and you choose the <c>Include only the current account</c>
    /// option, you can't edit that sync later and choose the <c>Include all accounts from
    /// my Organizations configuration</c> option. Instead, you must delete the first resource
    /// data sync, and create a new one.
    /// 
    ///  <note><para>
    /// This API operation only supports a resource data sync that was created with a SyncFromSource
    /// <c>SyncType</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SSMResourceDataSync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdateResourceDataSync API operation.", Operation = new[] {"UpdateResourceDataSync"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSMResourceDataSyncCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SyncSource_EnableAllOpsDataSource
        /// <summary>
        /// <para>
        /// <para>When you create a resource data sync, if you choose one of the Organizations options,
        /// then Systems Manager automatically enables all OpsData sources in the selected Amazon
        /// Web Services Regions for all Amazon Web Services accounts in your organization (or
        /// in the selected organization units). For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/Explorer-resource-data-sync.html">Setting
        /// up Systems Manager Explorer to display data from multiple accounts and Regions</a>
        /// in the <i>Amazon Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SyncSource_EnableAllOpsDataSources")]
        public System.Boolean? SyncSource_EnableAllOpsDataSource { get; set; }
        #endregion
        
        #region Parameter SyncSource_IncludeFutureRegion
        /// <summary>
        /// <para>
        /// <para>Whether to automatically synchronize and aggregate data from new Amazon Web Services
        /// Regions when those Regions come online.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SyncSource_IncludeFutureRegions")]
        public System.Boolean? SyncSource_IncludeFutureRegion { get; set; }
        #endregion
        
        #region Parameter AwsOrganizationsSource_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>The Organizations organization units included in the sync.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SyncSource_AwsOrganizationsSource_OrganizationalUnits")]
        public Amazon.SimpleSystemsManagement.Model.ResourceDataSyncOrganizationalUnit[] AwsOrganizationsSource_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter AwsOrganizationsSource_OrganizationSourceType
        /// <summary>
        /// <para>
        /// <para>If an Amazon Web Services organization is present, this is either <c>OrganizationalUnits</c>
        /// or <c>EntireOrganization</c>. For <c>OrganizationalUnits</c>, the data is aggregated
        /// from a set of organization units. For <c>EntireOrganization</c>, the data is aggregated
        /// from the entire Amazon Web Services organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SyncSource_AwsOrganizationsSource_OrganizationSourceType")]
        public System.String AwsOrganizationsSource_OrganizationSourceType { get; set; }
        #endregion
        
        #region Parameter SyncSource_SourceRegion
        /// <summary>
        /// <para>
        /// <para>The <c>SyncSource</c> Amazon Web Services Regions included in the resource data sync.</para>
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
        [Alias("SyncSource_SourceRegions")]
        public System.String[] SyncSource_SourceRegion { get; set; }
        #endregion
        
        #region Parameter SyncSource_SourceType
        /// <summary>
        /// <para>
        /// <para>The type of data source for the resource data sync. <c>SourceType</c> is either <c>AwsOrganizations</c>
        /// (if an organization is present in Organizations) or <c>SingleAccountMultiRegions</c>.</para>
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
        public System.String SyncSource_SourceType { get; set; }
        #endregion
        
        #region Parameter SyncName
        /// <summary>
        /// <para>
        /// <para>The name of the resource data sync you want to update.</para>
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
        public System.String SyncName { get; set; }
        #endregion
        
        #region Parameter SyncType
        /// <summary>
        /// <para>
        /// <para>The type of resource data sync. The supported <c>SyncType</c> is SyncFromSource.</para>
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
        public System.String SyncType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SyncName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMResourceDataSync (UpdateResourceDataSync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncResponse, UpdateSSMResourceDataSyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SyncName = this.SyncName;
            #if MODULAR
            if (this.SyncName == null && ParameterWasBound(nameof(this.SyncName)))
            {
                WriteWarning("You are passing $null as a value for parameter SyncName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AwsOrganizationsSource_OrganizationalUnit != null)
            {
                context.AwsOrganizationsSource_OrganizationalUnit = new List<Amazon.SimpleSystemsManagement.Model.ResourceDataSyncOrganizationalUnit>(this.AwsOrganizationsSource_OrganizationalUnit);
            }
            context.AwsOrganizationsSource_OrganizationSourceType = this.AwsOrganizationsSource_OrganizationSourceType;
            context.SyncSource_EnableAllOpsDataSource = this.SyncSource_EnableAllOpsDataSource;
            context.SyncSource_IncludeFutureRegion = this.SyncSource_IncludeFutureRegion;
            if (this.SyncSource_SourceRegion != null)
            {
                context.SyncSource_SourceRegion = new List<System.String>(this.SyncSource_SourceRegion);
            }
            #if MODULAR
            if (this.SyncSource_SourceRegion == null && ParameterWasBound(nameof(this.SyncSource_SourceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter SyncSource_SourceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SyncSource_SourceType = this.SyncSource_SourceType;
            #if MODULAR
            if (this.SyncSource_SourceType == null && ParameterWasBound(nameof(this.SyncSource_SourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter SyncSource_SourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SyncType = this.SyncType;
            #if MODULAR
            if (this.SyncType == null && ParameterWasBound(nameof(this.SyncType)))
            {
                WriteWarning("You are passing $null as a value for parameter SyncType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncRequest();
            
            if (cmdletContext.SyncName != null)
            {
                request.SyncName = cmdletContext.SyncName;
            }
            
             // populate SyncSource
            var requestSyncSourceIsNull = true;
            request.SyncSource = new Amazon.SimpleSystemsManagement.Model.ResourceDataSyncSource();
            System.Boolean? requestSyncSource_syncSource_EnableAllOpsDataSource = null;
            if (cmdletContext.SyncSource_EnableAllOpsDataSource != null)
            {
                requestSyncSource_syncSource_EnableAllOpsDataSource = cmdletContext.SyncSource_EnableAllOpsDataSource.Value;
            }
            if (requestSyncSource_syncSource_EnableAllOpsDataSource != null)
            {
                request.SyncSource.EnableAllOpsDataSources = requestSyncSource_syncSource_EnableAllOpsDataSource.Value;
                requestSyncSourceIsNull = false;
            }
            System.Boolean? requestSyncSource_syncSource_IncludeFutureRegion = null;
            if (cmdletContext.SyncSource_IncludeFutureRegion != null)
            {
                requestSyncSource_syncSource_IncludeFutureRegion = cmdletContext.SyncSource_IncludeFutureRegion.Value;
            }
            if (requestSyncSource_syncSource_IncludeFutureRegion != null)
            {
                request.SyncSource.IncludeFutureRegions = requestSyncSource_syncSource_IncludeFutureRegion.Value;
                requestSyncSourceIsNull = false;
            }
            List<System.String> requestSyncSource_syncSource_SourceRegion = null;
            if (cmdletContext.SyncSource_SourceRegion != null)
            {
                requestSyncSource_syncSource_SourceRegion = cmdletContext.SyncSource_SourceRegion;
            }
            if (requestSyncSource_syncSource_SourceRegion != null)
            {
                request.SyncSource.SourceRegions = requestSyncSource_syncSource_SourceRegion;
                requestSyncSourceIsNull = false;
            }
            System.String requestSyncSource_syncSource_SourceType = null;
            if (cmdletContext.SyncSource_SourceType != null)
            {
                requestSyncSource_syncSource_SourceType = cmdletContext.SyncSource_SourceType;
            }
            if (requestSyncSource_syncSource_SourceType != null)
            {
                request.SyncSource.SourceType = requestSyncSource_syncSource_SourceType;
                requestSyncSourceIsNull = false;
            }
            Amazon.SimpleSystemsManagement.Model.ResourceDataSyncAwsOrganizationsSource requestSyncSource_syncSource_AwsOrganizationsSource = null;
            
             // populate AwsOrganizationsSource
            var requestSyncSource_syncSource_AwsOrganizationsSourceIsNull = true;
            requestSyncSource_syncSource_AwsOrganizationsSource = new Amazon.SimpleSystemsManagement.Model.ResourceDataSyncAwsOrganizationsSource();
            List<Amazon.SimpleSystemsManagement.Model.ResourceDataSyncOrganizationalUnit> requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationalUnit = null;
            if (cmdletContext.AwsOrganizationsSource_OrganizationalUnit != null)
            {
                requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationalUnit = cmdletContext.AwsOrganizationsSource_OrganizationalUnit;
            }
            if (requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationalUnit != null)
            {
                requestSyncSource_syncSource_AwsOrganizationsSource.OrganizationalUnits = requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationalUnit;
                requestSyncSource_syncSource_AwsOrganizationsSourceIsNull = false;
            }
            System.String requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationSourceType = null;
            if (cmdletContext.AwsOrganizationsSource_OrganizationSourceType != null)
            {
                requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationSourceType = cmdletContext.AwsOrganizationsSource_OrganizationSourceType;
            }
            if (requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationSourceType != null)
            {
                requestSyncSource_syncSource_AwsOrganizationsSource.OrganizationSourceType = requestSyncSource_syncSource_AwsOrganizationsSource_awsOrganizationsSource_OrganizationSourceType;
                requestSyncSource_syncSource_AwsOrganizationsSourceIsNull = false;
            }
             // determine if requestSyncSource_syncSource_AwsOrganizationsSource should be set to null
            if (requestSyncSource_syncSource_AwsOrganizationsSourceIsNull)
            {
                requestSyncSource_syncSource_AwsOrganizationsSource = null;
            }
            if (requestSyncSource_syncSource_AwsOrganizationsSource != null)
            {
                request.SyncSource.AwsOrganizationsSource = requestSyncSource_syncSource_AwsOrganizationsSource;
                requestSyncSourceIsNull = false;
            }
             // determine if request.SyncSource should be set to null
            if (requestSyncSourceIsNull)
            {
                request.SyncSource = null;
            }
            if (cmdletContext.SyncType != null)
            {
                request.SyncType = cmdletContext.SyncType;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdateResourceDataSync");
            try
            {
                return client.UpdateResourceDataSyncAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SyncName { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.ResourceDataSyncOrganizationalUnit> AwsOrganizationsSource_OrganizationalUnit { get; set; }
            public System.String AwsOrganizationsSource_OrganizationSourceType { get; set; }
            public System.Boolean? SyncSource_EnableAllOpsDataSource { get; set; }
            public System.Boolean? SyncSource_IncludeFutureRegion { get; set; }
            public List<System.String> SyncSource_SourceRegion { get; set; }
            public System.String SyncSource_SourceType { get; set; }
            public System.String SyncType { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.UpdateResourceDataSyncResponse, UpdateSSMResourceDataSyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
