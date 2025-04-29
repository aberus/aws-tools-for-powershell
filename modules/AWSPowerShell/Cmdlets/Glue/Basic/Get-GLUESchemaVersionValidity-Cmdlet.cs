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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Validates the supplied schema. This call has no side effects, it simply validates
    /// using the supplied schema using <c>DataFormat</c> as the format. Since it does not
    /// take a schema set name, no compatibility checks are performed.
    /// </summary>
    [Cmdlet("Get", "GLUESchemaVersionValidity")]
    [OutputType("Amazon.Glue.Model.CheckSchemaVersionValidityResponse")]
    [AWSCmdlet("Calls the AWS Glue CheckSchemaVersionValidity API operation.", Operation = new[] {"CheckSchemaVersionValidity"}, SelectReturnType = typeof(Amazon.Glue.Model.CheckSchemaVersionValidityResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.CheckSchemaVersionValidityResponse",
        "This cmdlet returns an Amazon.Glue.Model.CheckSchemaVersionValidityResponse object containing multiple properties."
    )]
    public partial class GetGLUESchemaVersionValidityCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataFormat
        /// <summary>
        /// <para>
        /// <para>The data format of the schema definition. Currently <c>AVRO</c>, <c>JSON</c> and <c>PROTOBUF</c>
        /// are supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Glue.DataFormat")]
        public Amazon.Glue.DataFormat DataFormat { get; set; }
        #endregion
        
        #region Parameter SchemaDefinition
        /// <summary>
        /// <para>
        /// <para>The definition of the schema that has to be validated.</para>
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
        public System.String SchemaDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CheckSchemaVersionValidityResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CheckSchemaVersionValidityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CheckSchemaVersionValidityResponse, GetGLUESchemaVersionValidityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataFormat = this.DataFormat;
            #if MODULAR
            if (this.DataFormat == null && ParameterWasBound(nameof(this.DataFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter DataFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchemaDefinition = this.SchemaDefinition;
            #if MODULAR
            if (this.SchemaDefinition == null && ParameterWasBound(nameof(this.SchemaDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.CheckSchemaVersionValidityRequest();
            
            if (cmdletContext.DataFormat != null)
            {
                request.DataFormat = cmdletContext.DataFormat;
            }
            if (cmdletContext.SchemaDefinition != null)
            {
                request.SchemaDefinition = cmdletContext.SchemaDefinition;
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
        
        private Amazon.Glue.Model.CheckSchemaVersionValidityResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CheckSchemaVersionValidityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CheckSchemaVersionValidity");
            try
            {
                return client.CheckSchemaVersionValidityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Glue.DataFormat DataFormat { get; set; }
            public System.String SchemaDefinition { get; set; }
            public System.Func<Amazon.Glue.Model.CheckSchemaVersionValidityResponse, GetGLUESchemaVersionValidityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
