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
using Amazon.DocDB;
using Amazon.DocDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Modifies settings for an instance. You can change one or more database configuration
    /// parameters by specifying these parameters and the new values in the request.
    /// </summary>
    [Cmdlet("Edit", "DOCDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) ModifyDBInstance API operation.", Operation = new[] {"ModifyDBInstance"}, SelectReturnType = typeof(Amazon.DocDB.Model.ModifyDBInstanceResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBInstance or Amazon.DocDB.Model.ModifyDBInstanceResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBInstance object.",
        "The service call response (type Amazon.DocDB.Model.ModifyDBInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditDOCDBInstanceCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Specifies whether the modifications in this request and any pending modifications
        /// are asynchronously applied as soon as possible, regardless of the <c>PreferredMaintenanceWindow</c>
        /// setting for the instance. </para><para> If this parameter is set to <c>false</c>, changes to the instance are applied during
        /// the next maintenance window. Some parameter changes can cause an outage and are applied
        /// on the next reboot.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>This parameter does not apply to Amazon DocumentDB. Amazon DocumentDB does not perform
        /// minor version upgrades regardless of the value set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter CACertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>Indicates the certificate that needs to be associated with the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CACertificateIdentifier { get; set; }
        #endregion
        
        #region Parameter CertificateRotationRestart
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is restarted when you rotate your SSL/TLS certificate.</para><para>By default, the DB instance is restarted when you rotate your SSL/TLS certificate.
        /// The certificate is not updated until the DB instance is restarted.</para><important><para>Set this parameter only if you are <i>not</i> using SSL/TLS to connect to the DB instance.</para></important><para>If you are using SSL/TLS to connect to the DB instance, see <a href="https://docs.aws.amazon.com/documentdb/latest/developerguide/ca_cert_rotation.html">Updating
        /// Your Amazon DocumentDB TLS Certificates</a> and <a href="https://docs.aws.amazon.com/documentdb/latest/developerguide/security.encryption.ssl.html">
        /// Encrypting Data in Transit</a> in the <i>Amazon DocumentDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CertificateRotationRestart { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to copy all tags from the DB instance to snapshots
        /// of the DB instance. By default, tags are not copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The new compute and memory capacity of the instance; for example, <c>db.r5.large</c>.
        /// Not all instance classes are available in all Amazon Web Services Regions. </para><para>If you modify the instance class, an outage occurs during the change. The change is
        /// applied during the next maintenance window, unless <c>ApplyImmediately</c> is specified
        /// as <c>true</c> for this request. </para><para>Default: Uses existing setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The instance identifier. This value is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing <c>DBInstance</c>.</para></li></ul>
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
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceInsight
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to enable Performance Insights for the DB Instance.
        /// For more information, see <a href="https://docs.aws.amazon.com/documentdb/latest/developerguide/performance-insights.html">Using
        /// Amazon Performance Insights</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter NewDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para> The new instance identifier for the instance when renaming an instance. When you
        /// change the instance identifier, an instance reboot occurs immediately if you set <c>Apply
        /// Immediately</c> to <c>true</c>. It occurs during the next maintenance window if you
        /// set <c>Apply Immediately</c> to <c>false</c>. This value is stored as a lowercase
        /// string. </para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <c>mydbinstance</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key identifier for encryption of Performance Insights data.</para><para>The KMS key identifier is the key ARN, key ID, alias ARN, or alias name for the KMS
        /// key.</para><para>If you do not specify a value for PerformanceInsightsKMSKeyId, then Amazon DocumentDB
        /// uses your default KMS key. There is a default KMS key for your Amazon Web Services
        /// account. Your Amazon Web Services account has a different default KMS key for each
        /// Amazon Web Services region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which system maintenance can occur, which might
        /// result in an outage. Changing this parameter doesn't result in an outage except in
        /// the following situation, and the change is asynchronously applied as soon as possible.
        /// If there are pending actions that cause a reboot, and the maintenance window is changed
        /// to include the current time, changing this parameter causes a reboot of the instance.
        /// If you are moving this window to the current time, there must be at least 30 minutes
        /// between the current time and end of the window to ensure that pending changes are
        /// applied.</para><para>Default: Uses existing setting.</para><para>Format: <c>ddd:hh24:mi-ddd:hh24:mi</c></para><para>Valid days: Mon, Tue, Wed, Thu, Fri, Sat, Sun</para><para>Constraints: Must be at least 30 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PromotionTier
        /// <summary>
        /// <para>
        /// <para>A value that specifies the order in which an Amazon DocumentDB replica is promoted
        /// to the primary instance after a failure of the existing primary instance.</para><para>Default: 1</para><para>Valid values: 0-15</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PromotionTier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.ModifyDBInstanceResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.ModifyDBInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstance";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DOCDBInstance (ModifyDBInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.ModifyDBInstanceResponse, EditDOCDBInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyImmediately = this.ApplyImmediately;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.CACertificateIdentifier = this.CACertificateIdentifier;
            context.CertificateRotationRestart = this.CertificateRotationRestart;
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnablePerformanceInsight = this.EnablePerformanceInsight;
            context.NewDBInstanceIdentifier = this.NewDBInstanceIdentifier;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PromotionTier = this.PromotionTier;
            
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
            var request = new Amazon.DocDB.Model.ModifyDBInstanceRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.CACertificateIdentifier != null)
            {
                request.CACertificateIdentifier = cmdletContext.CACertificateIdentifier;
            }
            if (cmdletContext.CertificateRotationRestart != null)
            {
                request.CertificateRotationRestart = cmdletContext.CertificateRotationRestart.Value;
            }
            if (cmdletContext.CopyTagsToSnapshot != null)
            {
                request.CopyTagsToSnapshot = cmdletContext.CopyTagsToSnapshot.Value;
            }
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.EnablePerformanceInsight != null)
            {
                request.EnablePerformanceInsights = cmdletContext.EnablePerformanceInsight.Value;
            }
            if (cmdletContext.NewDBInstanceIdentifier != null)
            {
                request.NewDBInstanceIdentifier = cmdletContext.NewDBInstanceIdentifier;
            }
            if (cmdletContext.PerformanceInsightsKMSKeyId != null)
            {
                request.PerformanceInsightsKMSKeyId = cmdletContext.PerformanceInsightsKMSKeyId;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PromotionTier != null)
            {
                request.PromotionTier = cmdletContext.PromotionTier.Value;
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
        
        private Amazon.DocDB.Model.ModifyDBInstanceResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.ModifyDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "ModifyDBInstance");
            try
            {
                return client.ModifyDBInstanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String CACertificateIdentifier { get; set; }
            public System.Boolean? CertificateRotationRestart { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String NewDBInstanceIdentifier { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Int32? PromotionTier { get; set; }
            public System.Func<Amazon.DocDB.Model.ModifyDBInstanceResponse, EditDOCDBInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
