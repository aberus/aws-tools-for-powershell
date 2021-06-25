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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Creates a job that exports data from your dataset to an Amazon S3 bucket. To allow
    /// Amazon Personalize to export the training data, you must specify an service-linked
    /// IAM role that gives Amazon Personalize <code>PutObject</code> permissions for your
    /// Amazon S3 bucket. For information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/export-data.html">Exporting
    /// a dataset</a> in the Amazon Personalize developer guide. 
    /// 
    ///  
    /// <para><b>Status</b></para><para>
    /// A dataset export job can be in one of the following states:
    /// </para><ul><li><para>
    /// CREATE PENDING &gt; CREATE IN_PROGRESS &gt; ACTIVE -or- CREATE FAILED
    /// </para></li></ul><para>
    ///  To get the status of the export job, call <a>DescribeDatasetExportJob</a>, and specify
    /// the Amazon Resource Name (ARN) of the dataset export job. The dataset export is complete
    /// when the status shows as ACTIVE. If the status shows as CREATE FAILED, the response
    /// includes a <code>failureReason</code> key, which describes why the job failed. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "PERSDatasetExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize CreateDatasetExportJob API operation.", Operation = new[] {"CreateDatasetExportJob"}, SelectReturnType = typeof(Amazon.Personalize.Model.CreateDatasetExportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.CreateDatasetExportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.CreateDatasetExportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPERSDatasetExportJobCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        #region Parameter DatasetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dataset that contains the data to export.</para>
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
        public System.String DatasetArn { get; set; }
        #endregion
        
        #region Parameter IngestionMode
        /// <summary>
        /// <para>
        /// <para>The data to export, based on how you imported the data. You can choose to export only
        /// <code>BULK</code> data that you imported using a dataset import job, only <code>PUT</code>
        /// data that you imported incrementally (using the console, PutEvents, PutUsers and PutItems
        /// operations), or <code>ALL</code> for both types. The default value is <code>PUT</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Personalize.IngestionMode")]
        public Amazon.Personalize.IngestionMode IngestionMode { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name for the dataset export job.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Key Management Service (KMS) key that Amazon
        /// Personalize uses to encrypt or decrypt the input and output files of a batch inference
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobOutput_S3DataDestination_KmsKeyArn")]
        public System.String S3DataDestination_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter S3DataDestination_Path
        /// <summary>
        /// <para>
        /// <para>The file path of the Amazon S3 bucket.</para>
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
        [Alias("JobOutput_S3DataDestination_Path")]
        public System.String S3DataDestination_Path { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that has permissions to add
        /// data to your output Amazon S3 bucket.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetExportJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.CreateDatasetExportJobResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.CreateDatasetExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetExportJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetArn' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PERSDatasetExportJob (CreateDatasetExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.CreateDatasetExportJobResponse, NewPERSDatasetExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatasetArn = this.DatasetArn;
            #if MODULAR
            if (this.DatasetArn == null && ParameterWasBound(nameof(this.DatasetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IngestionMode = this.IngestionMode;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3DataDestination_KmsKeyArn = this.S3DataDestination_KmsKeyArn;
            context.S3DataDestination_Path = this.S3DataDestination_Path;
            #if MODULAR
            if (this.S3DataDestination_Path == null && ParameterWasBound(nameof(this.S3DataDestination_Path)))
            {
                WriteWarning("You are passing $null as a value for parameter S3DataDestination_Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Personalize.Model.CreateDatasetExportJobRequest();
            
            if (cmdletContext.DatasetArn != null)
            {
                request.DatasetArn = cmdletContext.DatasetArn;
            }
            if (cmdletContext.IngestionMode != null)
            {
                request.IngestionMode = cmdletContext.IngestionMode;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            
             // populate JobOutput
            var requestJobOutputIsNull = true;
            request.JobOutput = new Amazon.Personalize.Model.DatasetExportJobOutput();
            Amazon.Personalize.Model.S3DataConfig requestJobOutput_jobOutput_S3DataDestination = null;
            
             // populate S3DataDestination
            var requestJobOutput_jobOutput_S3DataDestinationIsNull = true;
            requestJobOutput_jobOutput_S3DataDestination = new Amazon.Personalize.Model.S3DataConfig();
            System.String requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn = null;
            if (cmdletContext.S3DataDestination_KmsKeyArn != null)
            {
                requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn = cmdletContext.S3DataDestination_KmsKeyArn;
            }
            if (requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn != null)
            {
                requestJobOutput_jobOutput_S3DataDestination.KmsKeyArn = requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_KmsKeyArn;
                requestJobOutput_jobOutput_S3DataDestinationIsNull = false;
            }
            System.String requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path = null;
            if (cmdletContext.S3DataDestination_Path != null)
            {
                requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path = cmdletContext.S3DataDestination_Path;
            }
            if (requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path != null)
            {
                requestJobOutput_jobOutput_S3DataDestination.Path = requestJobOutput_jobOutput_S3DataDestination_s3DataDestination_Path;
                requestJobOutput_jobOutput_S3DataDestinationIsNull = false;
            }
             // determine if requestJobOutput_jobOutput_S3DataDestination should be set to null
            if (requestJobOutput_jobOutput_S3DataDestinationIsNull)
            {
                requestJobOutput_jobOutput_S3DataDestination = null;
            }
            if (requestJobOutput_jobOutput_S3DataDestination != null)
            {
                request.JobOutput.S3DataDestination = requestJobOutput_jobOutput_S3DataDestination;
                requestJobOutputIsNull = false;
            }
             // determine if request.JobOutput should be set to null
            if (requestJobOutputIsNull)
            {
                request.JobOutput = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Personalize.Model.CreateDatasetExportJobResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.CreateDatasetExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "CreateDatasetExportJob");
            try
            {
                #if DESKTOP
                return client.CreateDatasetExportJob(request);
                #elif CORECLR
                return client.CreateDatasetExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetArn { get; set; }
            public Amazon.Personalize.IngestionMode IngestionMode { get; set; }
            public System.String JobName { get; set; }
            public System.String S3DataDestination_KmsKeyArn { get; set; }
            public System.String S3DataDestination_Path { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Personalize.Model.CreateDatasetExportJobResponse, NewPERSDatasetExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetExportJobArn;
        }
        
    }
}
