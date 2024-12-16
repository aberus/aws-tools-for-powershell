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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Detects named entities in input text when you use the pre-trained model. Detects custom
    /// entities if you have a custom entity recognition model. 
    /// 
    ///  
    /// <para>
    ///  When detecting named entities using the pre-trained model, use plain text as the
    /// input. For more information about named entities, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/how-entities.html">Entities</a>
    /// in the Comprehend Developer Guide.
    /// </para><para>
    /// When you use a custom entity recognition model, you can input plain text or you can
    /// upload a single-page input document (text, PDF, Word, or image). 
    /// </para><para>
    /// If the system detects errors while processing a page in the input document, the API
    /// response includes an entry in <c>Errors</c> for each error. 
    /// </para><para>
    /// If the system detects a document-level error in your input document, the API returns
    /// an <c>InvalidRequestException</c> error response. For details about this exception,
    /// see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/idp-inputs-sync-err.html">
    /// Errors in semi-structured documents</a> in the Comprehend Developer Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "COMPEntity")]
    [OutputType("Amazon.Comprehend.Model.Entity")]
    [AWSCmdlet("Calls the Amazon Comprehend DetectEntities API operation.", Operation = new[] {"DetectEntities"}, SelectReturnType = typeof(Amazon.Comprehend.Model.DetectEntitiesResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.Entity or Amazon.Comprehend.Model.DetectEntitiesResponse",
        "This cmdlet returns a collection of Amazon.Comprehend.Model.Entity objects.",
        "The service call response (type Amazon.Comprehend.Model.DetectEntitiesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class FindCOMPEntityCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Byte
        /// <summary>
        /// <para>
        /// <para>This field applies only when you use a custom entity recognition model that was trained
        /// with PDF annotations. For other cases, enter your text input in the <c>Text</c> field.</para><para> Use the <c>Bytes</c> parameter to input a text, PDF, Word or image file. Using a
        /// plain-text file in the <c>Bytes</c> parameter is equivelent to using the <c>Text</c>
        /// parameter (the <c>Entities</c> field in the response is identical).</para><para>You can also use the <c>Bytes</c> parameter to input an Amazon Textract <c>DetectDocumentText</c>
        /// or <c>AnalyzeDocument</c> output file.</para><para>Provide the input document as a sequence of base64-encoded bytes. If your code uses
        /// an Amazon Web Services SDK to detect entities, the SDK may encode the document file
        /// bytes for you. </para><para>The maximum length of this field depends on the input document type. For details,
        /// see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/idp-inputs-sync.html">
        /// Inputs for real-time custom analysis</a> in the Comprehend Developer Guide. </para><para>If you use the <c>Bytes</c> parameter, do not use the <c>Text</c> parameter.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Byte { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_DocumentReadAction
        /// <summary>
        /// <para>
        /// <para>This field defines the Amazon Textract API operation that Amazon Comprehend uses to
        /// extract text from PDF files and image files. Enter one of the following values:</para><ul><li><para><c>TEXTRACT_DETECT_DOCUMENT_TEXT</c> - The Amazon Comprehend service uses the <c>DetectDocumentText</c>
        /// API operation. </para></li><li><para><c>TEXTRACT_ANALYZE_DOCUMENT</c> - The Amazon Comprehend service uses the <c>AnalyzeDocument</c>
        /// API operation. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentReadAction")]
        public Amazon.Comprehend.DocumentReadAction DocumentReaderConfig_DocumentReadAction { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_DocumentReadMode
        /// <summary>
        /// <para>
        /// <para>Determines the text extraction actions for PDF files. Enter one of the following values:</para><ul><li><para><c>SERVICE_DEFAULT</c> - use the Amazon Comprehend service defaults for PDF files.</para></li><li><para><c>FORCE_DOCUMENT_READ_ACTION</c> - Amazon Comprehend uses the Textract API specified
        /// by DocumentReadAction for all PDF files, including digital PDF files. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentReadMode")]
        public Amazon.Comprehend.DocumentReadMode DocumentReaderConfig_DocumentReadMode { get; set; }
        #endregion
        
        #region Parameter EndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of an endpoint that is associated with a custom entity recognition
        /// model. Provide an endpoint if you want to detect entities by using your own custom
        /// model instead of the default model that is used by Amazon Comprehend.</para><para>If you specify an endpoint, Amazon Comprehend uses the language of your custom model,
        /// and it ignores any language code that you provide in your request.</para><para>For information about endpoints, see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/manage-endpoints.html">Managing
        /// endpoints</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointArn { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_FeatureType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of Amazon Textract features to apply. If you chose <c>TEXTRACT_ANALYZE_DOCUMENT</c>
        /// as the read action, you must specify one or both of the following values:</para><ul><li><para><c>TABLES</c> - Returns additional information about any tables that are detected
        /// in the input document. </para></li><li><para><c>FORMS</c> - Returns additional information about any forms that are detected in
        /// the input document. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentReaderConfig_FeatureTypes")]
        public System.String[] DocumentReaderConfig_FeatureType { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language of the input documents. You can specify any of the primary languages
        /// supported by Amazon Comprehend. If your request includes the endpoint for a custom
        /// entity recognition model, Amazon Comprehend uses the language of your custom model,
        /// and it ignores any language code that you specify here.</para><para>All input documents must be in the same language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.LanguageCode")]
        public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>A UTF-8 text string. The maximum string size is 100 KB. If you enter text using this
        /// parameter, do not use the <c>Bytes</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entities'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.DetectEntitiesResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.DetectEntitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entities";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.DetectEntitiesResponse, FindCOMPEntityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Byte = this.Byte;
            context.DocumentReaderConfig_DocumentReadAction = this.DocumentReaderConfig_DocumentReadAction;
            context.DocumentReaderConfig_DocumentReadMode = this.DocumentReaderConfig_DocumentReadMode;
            if (this.DocumentReaderConfig_FeatureType != null)
            {
                context.DocumentReaderConfig_FeatureType = new List<System.String>(this.DocumentReaderConfig_FeatureType);
            }
            context.EndpointArn = this.EndpointArn;
            context.LanguageCode = this.LanguageCode;
            context.Text = this.Text;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Comprehend.Model.DetectEntitiesRequest();
                
                if (cmdletContext.Byte != null)
                {
                    _ByteStream = new System.IO.MemoryStream(cmdletContext.Byte);
                    request.Bytes = _ByteStream;
                }
                
                 // populate DocumentReaderConfig
                var requestDocumentReaderConfigIsNull = true;
                request.DocumentReaderConfig = new Amazon.Comprehend.Model.DocumentReaderConfig();
                Amazon.Comprehend.DocumentReadAction requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction = null;
                if (cmdletContext.DocumentReaderConfig_DocumentReadAction != null)
                {
                    requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction = cmdletContext.DocumentReaderConfig_DocumentReadAction;
                }
                if (requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction != null)
                {
                    request.DocumentReaderConfig.DocumentReadAction = requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction;
                    requestDocumentReaderConfigIsNull = false;
                }
                Amazon.Comprehend.DocumentReadMode requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode = null;
                if (cmdletContext.DocumentReaderConfig_DocumentReadMode != null)
                {
                    requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode = cmdletContext.DocumentReaderConfig_DocumentReadMode;
                }
                if (requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode != null)
                {
                    request.DocumentReaderConfig.DocumentReadMode = requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode;
                    requestDocumentReaderConfigIsNull = false;
                }
                List<System.String> requestDocumentReaderConfig_documentReaderConfig_FeatureType = null;
                if (cmdletContext.DocumentReaderConfig_FeatureType != null)
                {
                    requestDocumentReaderConfig_documentReaderConfig_FeatureType = cmdletContext.DocumentReaderConfig_FeatureType;
                }
                if (requestDocumentReaderConfig_documentReaderConfig_FeatureType != null)
                {
                    request.DocumentReaderConfig.FeatureTypes = requestDocumentReaderConfig_documentReaderConfig_FeatureType;
                    requestDocumentReaderConfigIsNull = false;
                }
                 // determine if request.DocumentReaderConfig should be set to null
                if (requestDocumentReaderConfigIsNull)
                {
                    request.DocumentReaderConfig = null;
                }
                if (cmdletContext.EndpointArn != null)
                {
                    request.EndpointArn = cmdletContext.EndpointArn;
                }
                if (cmdletContext.LanguageCode != null)
                {
                    request.LanguageCode = cmdletContext.LanguageCode;
                }
                if (cmdletContext.Text != null)
                {
                    request.Text = cmdletContext.Text;
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
            finally
            {
                if( _ByteStream != null)
                {
                    _ByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Comprehend.Model.DetectEntitiesResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.DetectEntitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "DetectEntities");
            try
            {
                #if DESKTOP
                return client.DetectEntities(request);
                #elif CORECLR
                return client.DetectEntitiesAsync(request).GetAwaiter().GetResult();
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
            public byte[] Byte { get; set; }
            public Amazon.Comprehend.DocumentReadAction DocumentReaderConfig_DocumentReadAction { get; set; }
            public Amazon.Comprehend.DocumentReadMode DocumentReaderConfig_DocumentReadMode { get; set; }
            public List<System.String> DocumentReaderConfig_FeatureType { get; set; }
            public System.String EndpointArn { get; set; }
            public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.Comprehend.Model.DetectEntitiesResponse, FindCOMPEntityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entities;
        }
        
    }
}
