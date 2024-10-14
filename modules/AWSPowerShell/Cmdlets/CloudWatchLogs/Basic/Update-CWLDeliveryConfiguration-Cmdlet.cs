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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Use this operation to update the configuration of a <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_Delivery.html">delivery</a>
    /// to change either the S3 path pattern or the format of the delivered logs. You can't
    /// use this operation to change the source or destination of the delivery.
    /// </summary>
    [Cmdlet("Update", "CWLDeliveryConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs UpdateDeliveryConfiguration API operation.", Operation = new[] {"UpdateDeliveryConfiguration"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCWLDeliveryConfigurationCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3DeliveryConfiguration_EnableHiveCompatiblePath
        /// <summary>
        /// <para>
        /// <para>This parameter causes the S3 objects that contain delivered logs to use a prefix structure
        /// that allows for integration with Apache Hive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? S3DeliveryConfiguration_EnableHiveCompatiblePath { get; set; }
        #endregion
        
        #region Parameter FieldDelimiter
        /// <summary>
        /// <para>
        /// <para>The field delimiter to use between record fields when the final output format of a
        /// delivery is in <c>Plain</c>, <c>W3C</c>, or <c>Raw</c> format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldDelimiter { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the delivery to be updated by this request.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter RecordField
        /// <summary>
        /// <para>
        /// <para>The list of record fields to be delivered to the destination, in order. If the delivery’s
        /// log source has mandatory fields, they must be included in this list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecordFields")]
        public System.String[] RecordField { get; set; }
        #endregion
        
        #region Parameter S3DeliveryConfiguration_SuffixPath
        /// <summary>
        /// <para>
        /// <para>This string allows re-configuring the S3 object prefix to contain either static or
        /// variable sections. The valid variables to use in the suffix path will vary by each
        /// log source. See ConfigurationTemplate$allowedSuffixPathFields for more info on what
        /// values are supported in the suffix path for each log source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DeliveryConfiguration_SuffixPath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWLDeliveryConfiguration (UpdateDeliveryConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationResponse, UpdateCWLDeliveryConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FieldDelimiter = this.FieldDelimiter;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RecordField != null)
            {
                context.RecordField = new List<System.String>(this.RecordField);
            }
            context.S3DeliveryConfiguration_EnableHiveCompatiblePath = this.S3DeliveryConfiguration_EnableHiveCompatiblePath;
            context.S3DeliveryConfiguration_SuffixPath = this.S3DeliveryConfiguration_SuffixPath;
            
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
            var request = new Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationRequest();
            
            if (cmdletContext.FieldDelimiter != null)
            {
                request.FieldDelimiter = cmdletContext.FieldDelimiter;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.RecordField != null)
            {
                request.RecordFields = cmdletContext.RecordField;
            }
            
             // populate S3DeliveryConfiguration
            var requestS3DeliveryConfigurationIsNull = true;
            request.S3DeliveryConfiguration = new Amazon.CloudWatchLogs.Model.S3DeliveryConfiguration();
            System.Boolean? requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath = null;
            if (cmdletContext.S3DeliveryConfiguration_EnableHiveCompatiblePath != null)
            {
                requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath = cmdletContext.S3DeliveryConfiguration_EnableHiveCompatiblePath.Value;
            }
            if (requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath != null)
            {
                request.S3DeliveryConfiguration.EnableHiveCompatiblePath = requestS3DeliveryConfiguration_s3DeliveryConfiguration_EnableHiveCompatiblePath.Value;
                requestS3DeliveryConfigurationIsNull = false;
            }
            System.String requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath = null;
            if (cmdletContext.S3DeliveryConfiguration_SuffixPath != null)
            {
                requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath = cmdletContext.S3DeliveryConfiguration_SuffixPath;
            }
            if (requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath != null)
            {
                request.S3DeliveryConfiguration.SuffixPath = requestS3DeliveryConfiguration_s3DeliveryConfiguration_SuffixPath;
                requestS3DeliveryConfigurationIsNull = false;
            }
             // determine if request.S3DeliveryConfiguration should be set to null
            if (requestS3DeliveryConfigurationIsNull)
            {
                request.S3DeliveryConfiguration = null;
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
        
        private Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "UpdateDeliveryConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateDeliveryConfiguration(request);
                #elif CORECLR
                return client.UpdateDeliveryConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String FieldDelimiter { get; set; }
            public System.String Id { get; set; }
            public List<System.String> RecordField { get; set; }
            public System.Boolean? S3DeliveryConfiguration_EnableHiveCompatiblePath { get; set; }
            public System.String S3DeliveryConfiguration_SuffixPath { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.UpdateDeliveryConfigurationResponse, UpdateCWLDeliveryConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
