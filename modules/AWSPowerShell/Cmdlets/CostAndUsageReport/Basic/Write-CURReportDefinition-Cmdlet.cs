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
using Amazon.CostAndUsageReport;
using Amazon.CostAndUsageReport.Model;

namespace Amazon.PowerShell.Cmdlets.CUR
{
    /// <summary>
    /// Creates a new report using the description that you provide.
    /// </summary>
    [Cmdlet("Write", "CURReportDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Cost and Usage Report PutReportDefinition API operation.", Operation = new[] {"PutReportDefinition"}, SelectReturnType = typeof(Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse))]
    [AWSCmdletOutput("None or Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCURReportDefinitionCmdlet : AmazonCostAndUsageReportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReportDefinition_AdditionalArtifact
        /// <summary>
        /// <para>
        /// <para>A list of manifests that you want Amazon Web Services to create for this report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportDefinition_AdditionalArtifacts")]
        public System.String[] ReportDefinition_AdditionalArtifact { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_AdditionalSchemaElement
        /// <summary>
        /// <para>
        /// <para>A list of strings that indicate additional content that Amazon Web Services includes
        /// in the report, such as individual resource IDs. </para>
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
        [Alias("ReportDefinition_AdditionalSchemaElements")]
        public System.String[] ReportDefinition_AdditionalSchemaElement { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_BillingViewArn
        /// <summary>
        /// <para>
        /// <para> The Amazon resource name of the billing view. The <c>BillingViewArn</c> is needed
        /// to create Amazon Web Services Cost and Usage Report for each billing group maintained
        /// in the Amazon Web Services Billing Conductor service. The <c>BillingViewArn</c> for
        /// a billing group can be constructed as: <c>arn:aws:billing::payer-account-id:billingview/billing-group-primary-account-id</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReportDefinition_BillingViewArn { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_Compression
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.CompressionFormat")]
        public Amazon.CostAndUsageReport.CompressionFormat ReportDefinition_Compression { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_Format
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.ReportFormat")]
        public Amazon.CostAndUsageReport.ReportFormat ReportDefinition_Format { get; set; }
        #endregion
        
        #region Parameter ReportStatus_LastDelivery
        /// <summary>
        /// <para>
        /// <para>A timestamp that gives the date of a report delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportDefinition_ReportStatus_LastDelivery")]
        public System.String ReportStatus_LastDelivery { get; set; }
        #endregion
        
        #region Parameter ReportStatus_LastStatus
        /// <summary>
        /// <para>
        /// <para>An enum that gives the status of a report delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportDefinition_ReportStatus_LastStatus")]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.LastStatus")]
        public Amazon.CostAndUsageReport.LastStatus ReportStatus_LastStatus { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_RefreshClosedReport
        /// <summary>
        /// <para>
        /// <para>Whether you want Amazon Web Services to update your reports after they have been finalized
        /// if Amazon Web Services detects charges related to previous months. These charges can
        /// include refunds, credits, or support fees.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportDefinition_RefreshClosedReports")]
        public System.Boolean? ReportDefinition_RefreshClosedReport { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_ReportName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ReportDefinition_ReportName { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_ReportVersioning
        /// <summary>
        /// <para>
        /// <para>Whether you want Amazon Web Services to overwrite the previous version of each report
        /// or to deliver the report in addition to the previous versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.ReportVersioning")]
        public Amazon.CostAndUsageReport.ReportVersioning ReportDefinition_ReportVersioning { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_S3Bucket
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ReportDefinition_S3Bucket { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_S3Prefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ReportDefinition_S3Prefix { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_S3Region
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.AWSRegion")]
        public Amazon.CostAndUsageReport.AWSRegion ReportDefinition_S3Region { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the report definition resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CostAndUsageReport.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_TimeUnit
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.TimeUnit")]
        public Amazon.CostAndUsageReport.TimeUnit ReportDefinition_TimeUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReportDefinition_ReportName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CURReportDefinition (PutReportDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse, WriteCURReportDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ReportDefinition_AdditionalArtifact != null)
            {
                context.ReportDefinition_AdditionalArtifact = new List<System.String>(this.ReportDefinition_AdditionalArtifact);
            }
            if (this.ReportDefinition_AdditionalSchemaElement != null)
            {
                context.ReportDefinition_AdditionalSchemaElement = new List<System.String>(this.ReportDefinition_AdditionalSchemaElement);
            }
            #if MODULAR
            if (this.ReportDefinition_AdditionalSchemaElement == null && ParameterWasBound(nameof(this.ReportDefinition_AdditionalSchemaElement)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_AdditionalSchemaElement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportDefinition_BillingViewArn = this.ReportDefinition_BillingViewArn;
            context.ReportDefinition_Compression = this.ReportDefinition_Compression;
            #if MODULAR
            if (this.ReportDefinition_Compression == null && ParameterWasBound(nameof(this.ReportDefinition_Compression)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_Compression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportDefinition_Format = this.ReportDefinition_Format;
            #if MODULAR
            if (this.ReportDefinition_Format == null && ParameterWasBound(nameof(this.ReportDefinition_Format)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportDefinition_RefreshClosedReport = this.ReportDefinition_RefreshClosedReport;
            context.ReportDefinition_ReportName = this.ReportDefinition_ReportName;
            #if MODULAR
            if (this.ReportDefinition_ReportName == null && ParameterWasBound(nameof(this.ReportDefinition_ReportName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_ReportName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportStatus_LastDelivery = this.ReportStatus_LastDelivery;
            context.ReportStatus_LastStatus = this.ReportStatus_LastStatus;
            context.ReportDefinition_ReportVersioning = this.ReportDefinition_ReportVersioning;
            context.ReportDefinition_S3Bucket = this.ReportDefinition_S3Bucket;
            #if MODULAR
            if (this.ReportDefinition_S3Bucket == null && ParameterWasBound(nameof(this.ReportDefinition_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportDefinition_S3Prefix = this.ReportDefinition_S3Prefix;
            #if MODULAR
            if (this.ReportDefinition_S3Prefix == null && ParameterWasBound(nameof(this.ReportDefinition_S3Prefix)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_S3Prefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportDefinition_S3Region = this.ReportDefinition_S3Region;
            #if MODULAR
            if (this.ReportDefinition_S3Region == null && ParameterWasBound(nameof(this.ReportDefinition_S3Region)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_S3Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportDefinition_TimeUnit = this.ReportDefinition_TimeUnit;
            #if MODULAR
            if (this.ReportDefinition_TimeUnit == null && ParameterWasBound(nameof(this.ReportDefinition_TimeUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportDefinition_TimeUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CostAndUsageReport.Model.Tag>(this.Tag);
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
            var request = new Amazon.CostAndUsageReport.Model.PutReportDefinitionRequest();
            
            
             // populate ReportDefinition
            var requestReportDefinitionIsNull = true;
            request.ReportDefinition = new Amazon.CostAndUsageReport.Model.ReportDefinition();
            List<System.String> requestReportDefinition_reportDefinition_AdditionalArtifact = null;
            if (cmdletContext.ReportDefinition_AdditionalArtifact != null)
            {
                requestReportDefinition_reportDefinition_AdditionalArtifact = cmdletContext.ReportDefinition_AdditionalArtifact;
            }
            if (requestReportDefinition_reportDefinition_AdditionalArtifact != null)
            {
                request.ReportDefinition.AdditionalArtifacts = requestReportDefinition_reportDefinition_AdditionalArtifact;
                requestReportDefinitionIsNull = false;
            }
            List<System.String> requestReportDefinition_reportDefinition_AdditionalSchemaElement = null;
            if (cmdletContext.ReportDefinition_AdditionalSchemaElement != null)
            {
                requestReportDefinition_reportDefinition_AdditionalSchemaElement = cmdletContext.ReportDefinition_AdditionalSchemaElement;
            }
            if (requestReportDefinition_reportDefinition_AdditionalSchemaElement != null)
            {
                request.ReportDefinition.AdditionalSchemaElements = requestReportDefinition_reportDefinition_AdditionalSchemaElement;
                requestReportDefinitionIsNull = false;
            }
            System.String requestReportDefinition_reportDefinition_BillingViewArn = null;
            if (cmdletContext.ReportDefinition_BillingViewArn != null)
            {
                requestReportDefinition_reportDefinition_BillingViewArn = cmdletContext.ReportDefinition_BillingViewArn;
            }
            if (requestReportDefinition_reportDefinition_BillingViewArn != null)
            {
                request.ReportDefinition.BillingViewArn = requestReportDefinition_reportDefinition_BillingViewArn;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.CompressionFormat requestReportDefinition_reportDefinition_Compression = null;
            if (cmdletContext.ReportDefinition_Compression != null)
            {
                requestReportDefinition_reportDefinition_Compression = cmdletContext.ReportDefinition_Compression;
            }
            if (requestReportDefinition_reportDefinition_Compression != null)
            {
                request.ReportDefinition.Compression = requestReportDefinition_reportDefinition_Compression;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.ReportFormat requestReportDefinition_reportDefinition_Format = null;
            if (cmdletContext.ReportDefinition_Format != null)
            {
                requestReportDefinition_reportDefinition_Format = cmdletContext.ReportDefinition_Format;
            }
            if (requestReportDefinition_reportDefinition_Format != null)
            {
                request.ReportDefinition.Format = requestReportDefinition_reportDefinition_Format;
                requestReportDefinitionIsNull = false;
            }
            System.Boolean? requestReportDefinition_reportDefinition_RefreshClosedReport = null;
            if (cmdletContext.ReportDefinition_RefreshClosedReport != null)
            {
                requestReportDefinition_reportDefinition_RefreshClosedReport = cmdletContext.ReportDefinition_RefreshClosedReport.Value;
            }
            if (requestReportDefinition_reportDefinition_RefreshClosedReport != null)
            {
                request.ReportDefinition.RefreshClosedReports = requestReportDefinition_reportDefinition_RefreshClosedReport.Value;
                requestReportDefinitionIsNull = false;
            }
            System.String requestReportDefinition_reportDefinition_ReportName = null;
            if (cmdletContext.ReportDefinition_ReportName != null)
            {
                requestReportDefinition_reportDefinition_ReportName = cmdletContext.ReportDefinition_ReportName;
            }
            if (requestReportDefinition_reportDefinition_ReportName != null)
            {
                request.ReportDefinition.ReportName = requestReportDefinition_reportDefinition_ReportName;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.ReportVersioning requestReportDefinition_reportDefinition_ReportVersioning = null;
            if (cmdletContext.ReportDefinition_ReportVersioning != null)
            {
                requestReportDefinition_reportDefinition_ReportVersioning = cmdletContext.ReportDefinition_ReportVersioning;
            }
            if (requestReportDefinition_reportDefinition_ReportVersioning != null)
            {
                request.ReportDefinition.ReportVersioning = requestReportDefinition_reportDefinition_ReportVersioning;
                requestReportDefinitionIsNull = false;
            }
            System.String requestReportDefinition_reportDefinition_S3Bucket = null;
            if (cmdletContext.ReportDefinition_S3Bucket != null)
            {
                requestReportDefinition_reportDefinition_S3Bucket = cmdletContext.ReportDefinition_S3Bucket;
            }
            if (requestReportDefinition_reportDefinition_S3Bucket != null)
            {
                request.ReportDefinition.S3Bucket = requestReportDefinition_reportDefinition_S3Bucket;
                requestReportDefinitionIsNull = false;
            }
            System.String requestReportDefinition_reportDefinition_S3Prefix = null;
            if (cmdletContext.ReportDefinition_S3Prefix != null)
            {
                requestReportDefinition_reportDefinition_S3Prefix = cmdletContext.ReportDefinition_S3Prefix;
            }
            if (requestReportDefinition_reportDefinition_S3Prefix != null)
            {
                request.ReportDefinition.S3Prefix = requestReportDefinition_reportDefinition_S3Prefix;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.AWSRegion requestReportDefinition_reportDefinition_S3Region = null;
            if (cmdletContext.ReportDefinition_S3Region != null)
            {
                requestReportDefinition_reportDefinition_S3Region = cmdletContext.ReportDefinition_S3Region;
            }
            if (requestReportDefinition_reportDefinition_S3Region != null)
            {
                request.ReportDefinition.S3Region = requestReportDefinition_reportDefinition_S3Region;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.TimeUnit requestReportDefinition_reportDefinition_TimeUnit = null;
            if (cmdletContext.ReportDefinition_TimeUnit != null)
            {
                requestReportDefinition_reportDefinition_TimeUnit = cmdletContext.ReportDefinition_TimeUnit;
            }
            if (requestReportDefinition_reportDefinition_TimeUnit != null)
            {
                request.ReportDefinition.TimeUnit = requestReportDefinition_reportDefinition_TimeUnit;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.Model.ReportStatus requestReportDefinition_reportDefinition_ReportStatus = null;
            
             // populate ReportStatus
            var requestReportDefinition_reportDefinition_ReportStatusIsNull = true;
            requestReportDefinition_reportDefinition_ReportStatus = new Amazon.CostAndUsageReport.Model.ReportStatus();
            System.String requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastDelivery = null;
            if (cmdletContext.ReportStatus_LastDelivery != null)
            {
                requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastDelivery = cmdletContext.ReportStatus_LastDelivery;
            }
            if (requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastDelivery != null)
            {
                requestReportDefinition_reportDefinition_ReportStatus.LastDelivery = requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastDelivery;
                requestReportDefinition_reportDefinition_ReportStatusIsNull = false;
            }
            Amazon.CostAndUsageReport.LastStatus requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastStatus = null;
            if (cmdletContext.ReportStatus_LastStatus != null)
            {
                requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastStatus = cmdletContext.ReportStatus_LastStatus;
            }
            if (requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastStatus != null)
            {
                requestReportDefinition_reportDefinition_ReportStatus.LastStatus = requestReportDefinition_reportDefinition_ReportStatus_reportStatus_LastStatus;
                requestReportDefinition_reportDefinition_ReportStatusIsNull = false;
            }
             // determine if requestReportDefinition_reportDefinition_ReportStatus should be set to null
            if (requestReportDefinition_reportDefinition_ReportStatusIsNull)
            {
                requestReportDefinition_reportDefinition_ReportStatus = null;
            }
            if (requestReportDefinition_reportDefinition_ReportStatus != null)
            {
                request.ReportDefinition.ReportStatus = requestReportDefinition_reportDefinition_ReportStatus;
                requestReportDefinitionIsNull = false;
            }
             // determine if request.ReportDefinition should be set to null
            if (requestReportDefinitionIsNull)
            {
                request.ReportDefinition = null;
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
        
        private Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse CallAWSServiceOperation(IAmazonCostAndUsageReport client, Amazon.CostAndUsageReport.Model.PutReportDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost and Usage Report", "PutReportDefinition");
            try
            {
                #if DESKTOP
                return client.PutReportDefinition(request);
                #elif CORECLR
                return client.PutReportDefinitionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ReportDefinition_AdditionalArtifact { get; set; }
            public List<System.String> ReportDefinition_AdditionalSchemaElement { get; set; }
            public System.String ReportDefinition_BillingViewArn { get; set; }
            public Amazon.CostAndUsageReport.CompressionFormat ReportDefinition_Compression { get; set; }
            public Amazon.CostAndUsageReport.ReportFormat ReportDefinition_Format { get; set; }
            public System.Boolean? ReportDefinition_RefreshClosedReport { get; set; }
            public System.String ReportDefinition_ReportName { get; set; }
            public System.String ReportStatus_LastDelivery { get; set; }
            public Amazon.CostAndUsageReport.LastStatus ReportStatus_LastStatus { get; set; }
            public Amazon.CostAndUsageReport.ReportVersioning ReportDefinition_ReportVersioning { get; set; }
            public System.String ReportDefinition_S3Bucket { get; set; }
            public System.String ReportDefinition_S3Prefix { get; set; }
            public Amazon.CostAndUsageReport.AWSRegion ReportDefinition_S3Region { get; set; }
            public Amazon.CostAndUsageReport.TimeUnit ReportDefinition_TimeUnit { get; set; }
            public List<Amazon.CostAndUsageReport.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse, WriteCURReportDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
