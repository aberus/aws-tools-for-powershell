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
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Returns the <c>UnlockCode</c> code value for the specified job. A particular <c>UnlockCode</c>
    /// value can be accessed for up to 360 days after the associated job has been created.
    /// 
    ///  
    /// <para>
    /// The <c>UnlockCode</c> value is a 29-character code with 25 alphanumeric characters
    /// and 4 hyphens. This code is used to decrypt the manifest file when it is passed along
    /// with the manifest to the Snow device through the Snowball client when the client is
    /// started for the first time. The only valid status for calling this API is <c>WithCustomer</c>
    /// as the manifest and <c>Unlock</c> code values are used for securing your device and
    /// should only be used when you have the device.
    /// </para><para>
    /// As a best practice, we recommend that you don't save a copy of the <c>UnlockCode</c>
    /// in the same location as the manifest file for that job. Saving these separately helps
    /// prevent unauthorized parties from gaining access to the Snow device associated with
    /// that job.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SNOWJobUnlockCode")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball GetJobUnlockCode API operation.", Operation = new[] {"GetJobUnlockCode"}, SelectReturnType = typeof(Amazon.Snowball.Model.GetJobUnlockCodeResponse))]
    [AWSCmdletOutput("System.String or Amazon.Snowball.Model.GetJobUnlockCodeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Snowball.Model.GetJobUnlockCodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSNOWJobUnlockCodeCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The ID for the job that you want to get the <c>UnlockCode</c> value for, for example
        /// <c>JID123e4567-e89b-12d3-a456-426655440000</c>.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UnlockCode'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Snowball.Model.GetJobUnlockCodeResponse).
        /// Specifying the name of a property of type Amazon.Snowball.Model.GetJobUnlockCodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UnlockCode";
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
                context.Select = CreateSelectDelegate<Amazon.Snowball.Model.GetJobUnlockCodeResponse, GetSNOWJobUnlockCodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Snowball.Model.GetJobUnlockCodeRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
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
        
        private Amazon.Snowball.Model.GetJobUnlockCodeResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.GetJobUnlockCodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "GetJobUnlockCode");
            try
            {
                #if DESKTOP
                return client.GetJobUnlockCode(request);
                #elif CORECLR
                return client.GetJobUnlockCodeAsync(request).GetAwaiter().GetResult();
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
            public System.String JobId { get; set; }
            public System.Func<Amazon.Snowball.Model.GetJobUnlockCodeResponse, GetSNOWJobUnlockCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UnlockCode;
        }
        
    }
}
