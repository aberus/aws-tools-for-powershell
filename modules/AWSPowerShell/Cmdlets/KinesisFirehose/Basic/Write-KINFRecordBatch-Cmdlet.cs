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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Writes multiple data records into a delivery stream in a single call, which can achieve
    /// higher throughput per producer than when writing single records. To write single data
    /// records into a delivery stream, use <a>PutRecord</a>. Applications using these operations
    /// are referred to as producers.
    /// 
    ///  
    /// <para>
    /// For information about service quota, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/limits.html">Amazon
    /// Kinesis Data Firehose Quota</a>.
    /// </para><para>
    /// Each <a>PutRecordBatch</a> request supports up to 500 records. Each record in the
    /// request can be as large as 1,000 KB (before base64 encoding), up to a limit of 4 MB
    /// for the entire request. These limits cannot be changed.
    /// </para><para>
    /// You must specify the name of the delivery stream and the data record when using <a>PutRecord</a>.
    /// The data record consists of a data blob that can be up to 1,000 KB in size, and any
    /// kind of data. For example, it could be a segment from a log file, geographic location
    /// data, website clickstream data, and so on.
    /// </para><para>
    /// Kinesis Data Firehose buffers records before delivering them to the destination. To
    /// disambiguate the data blobs at the destination, a common solution is to use delimiters
    /// in the data, such as a newline (<code>\n</code>) or some other character unique within
    /// the data. This allows the consumer application to parse individual data items when
    /// reading the data from the destination.
    /// </para><para>
    /// The <a>PutRecordBatch</a> response includes a count of failed records, <code>FailedPutCount</code>,
    /// and an array of responses, <code>RequestResponses</code>. Even if the <a>PutRecordBatch</a>
    /// call succeeds, the value of <code>FailedPutCount</code> may be greater than 0, indicating
    /// that there are records for which the operation didn't succeed. Each entry in the <code>RequestResponses</code>
    /// array provides additional information about the processed record. It directly correlates
    /// with a record in the request array using the same ordering, from the top to the bottom.
    /// The response array always includes the same number of records as the request array.
    /// <code>RequestResponses</code> includes both successfully and unsuccessfully processed
    /// records. Kinesis Data Firehose tries to process all records in each <a>PutRecordBatch</a>
    /// request. A single record failure does not stop the processing of subsequent records.
    /// 
    /// </para><para>
    /// A successfully processed record includes a <code>RecordId</code> value, which is unique
    /// for the record. An unsuccessfully processed record includes <code>ErrorCode</code>
    /// and <code>ErrorMessage</code> values. <code>ErrorCode</code> reflects the type of
    /// error, and is one of the following values: <code>ServiceUnavailableException</code>
    /// or <code>InternalFailure</code>. <code>ErrorMessage</code> provides more detailed
    /// information about the error.
    /// </para><para>
    /// If there is an internal server error or a timeout, the write might have completed
    /// or it might have failed. If <code>FailedPutCount</code> is greater than 0, retry the
    /// request, resending only those records that might have failed processing. This minimizes
    /// the possible duplicate records and also reduces the total bytes sent (and corresponding
    /// charges). We recommend that you handle any duplicates at the destination.
    /// </para><para>
    /// If <a>PutRecordBatch</a> throws <code>ServiceUnavailableException</code>, back off
    /// and retry. If the exception persists, it is possible that the throughput limits have
    /// been exceeded for the delivery stream.
    /// </para><para>
    /// Data records sent to Kinesis Data Firehose are stored for 24 hours from the time they
    /// are added to a delivery stream as it attempts to send the records to the destination.
    /// If the destination is unreachable for more than 24 hours, the data is no longer available.
    /// </para><important><para>
    /// Don't concatenate two or more base64 strings to form the data fields of your records.
    /// Instead, concatenate the raw data, then perform base64 encoding.
    /// </para></important>
    /// </summary>
    [Cmdlet("Write", "KINFRecordBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisFirehose.Model.PutRecordBatchResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose PutRecordBatch API operation.", Operation = new[] {"PutRecordBatch"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.PutRecordBatchResponse))]
    [AWSCmdletOutput("Amazon.KinesisFirehose.Model.PutRecordBatchResponse",
        "This cmdlet returns an Amazon.KinesisFirehose.Model.PutRecordBatchResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteKINFRecordBatchCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
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
        public System.String DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para>One or more records.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Records")]
        public Amazon.KinesisFirehose.Model.Record[] Record { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.PutRecordBatchResponse).
        /// Specifying the name of a property of type Amazon.KinesisFirehose.Model.PutRecordBatchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Record parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Record' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Record' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliveryStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KINFRecordBatch (PutRecordBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.PutRecordBatchResponse, WriteKINFRecordBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Record;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeliveryStreamName = this.DeliveryStreamName;
            #if MODULAR
            if (this.DeliveryStreamName == null && ParameterWasBound(nameof(this.DeliveryStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Record != null)
            {
                context.Record = new List<Amazon.KinesisFirehose.Model.Record>(this.Record);
            }
            #if MODULAR
            if (this.Record == null && ParameterWasBound(nameof(this.Record)))
            {
                WriteWarning("You are passing $null as a value for parameter Record which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisFirehose.Model.PutRecordBatchRequest();
            
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
            }
            if (cmdletContext.Record != null)
            {
                request.Records = cmdletContext.Record;
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
        
        private Amazon.KinesisFirehose.Model.PutRecordBatchResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.PutRecordBatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "PutRecordBatch");
            try
            {
                #if DESKTOP
                return client.PutRecordBatch(request);
                #elif CORECLR
                return client.PutRecordBatchAsync(request).GetAwaiter().GetResult();
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
            public System.String DeliveryStreamName { get; set; }
            public List<Amazon.KinesisFirehose.Model.Record> Record { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.PutRecordBatchResponse, WriteKINFRecordBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
