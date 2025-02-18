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
using Amazon.IoTEvents;
using Amazon.IoTEvents.Model;

namespace Amazon.PowerShell.Cmdlets.IOTE
{
    /// <summary>
    /// Describes a detector model. If the <c>version</c> parameter is not specified, information
    /// about the latest version is returned.
    /// </summary>
    [Cmdlet("Get", "IOTEDetectorModel")]
    [OutputType("Amazon.IoTEvents.Model.DetectorModel")]
    [AWSCmdlet("Calls the AWS IoT Events DescribeDetectorModel API operation.", Operation = new[] {"DescribeDetectorModel"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.DescribeDetectorModelResponse))]
    [AWSCmdletOutput("Amazon.IoTEvents.Model.DetectorModel or Amazon.IoTEvents.Model.DescribeDetectorModelResponse",
        "This cmdlet returns an Amazon.IoTEvents.Model.DetectorModel object.",
        "The service call response (type Amazon.IoTEvents.Model.DescribeDetectorModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTEDetectorModelCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DetectorModelName
        /// <summary>
        /// <para>
        /// <para>The name of the detector model.</para>
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
        public System.String DetectorModelName { get; set; }
        #endregion
        
        #region Parameter DetectorModelVersion
        /// <summary>
        /// <para>
        /// <para>The version of the detector model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DetectorModelVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DetectorModel'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.DescribeDetectorModelResponse).
        /// Specifying the name of a property of type Amazon.IoTEvents.Model.DescribeDetectorModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DetectorModel";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.DescribeDetectorModelResponse, GetIOTEDetectorModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DetectorModelName = this.DetectorModelName;
            #if MODULAR
            if (this.DetectorModelName == null && ParameterWasBound(nameof(this.DetectorModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DetectorModelVersion = this.DetectorModelVersion;
            
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
            var request = new Amazon.IoTEvents.Model.DescribeDetectorModelRequest();
            
            if (cmdletContext.DetectorModelName != null)
            {
                request.DetectorModelName = cmdletContext.DetectorModelName;
            }
            if (cmdletContext.DetectorModelVersion != null)
            {
                request.DetectorModelVersion = cmdletContext.DetectorModelVersion;
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
        
        private Amazon.IoTEvents.Model.DescribeDetectorModelResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.DescribeDetectorModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "DescribeDetectorModel");
            try
            {
                return client.DescribeDetectorModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DetectorModelName { get; set; }
            public System.String DetectorModelVersion { get; set; }
            public System.Func<Amazon.IoTEvents.Model.DescribeDetectorModelResponse, GetIOTEDetectorModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DetectorModel;
        }
        
    }
}
