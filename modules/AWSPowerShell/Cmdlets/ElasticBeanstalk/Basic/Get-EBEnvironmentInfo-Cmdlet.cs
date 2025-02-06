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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Retrieves the compiled information from a <a>RequestEnvironmentInfo</a> request.
    /// 
    ///  
    /// <para>
    /// Related Topics
    /// </para><ul><li><para><a>RequestEnvironmentInfo</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "EBEnvironmentInfo")]
    [OutputType("Amazon.ElasticBeanstalk.Model.EnvironmentInfoDescription")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk RetrieveEnvironmentInfo API operation.", Operation = new[] {"RetrieveEnvironmentInfo"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.EnvironmentInfoDescription or Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse",
        "This cmdlet returns a collection of Amazon.ElasticBeanstalk.Model.EnvironmentInfoDescription objects.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEBEnvironmentInfoCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the data's environment.</para><para>If no such environment is found, returns an <c>InvalidParameterValue</c> error.</para><para>Condition: You must specify either this or an EnvironmentName, or both. If you do
        /// not specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the data's environment.</para><para> If no such environment is found, returns an <c>InvalidParameterValue</c> error. </para><para> Condition: You must specify either this or an EnvironmentId, or both. If you do not
        /// specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c> error.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter InfoType
        /// <summary>
        /// <para>
        /// <para>The type of information to retrieve.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ElasticBeanstalk.EnvironmentInfoType")]
        public Amazon.ElasticBeanstalk.EnvironmentInfoType InfoType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentInfo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnvironmentInfo";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse, GetEBEnvironmentInfoCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnvironmentId = this.EnvironmentId;
            context.EnvironmentName = this.EnvironmentName;
            context.InfoType = this.InfoType;
            #if MODULAR
            if (this.InfoType == null && ParameterWasBound(nameof(this.InfoType)))
            {
                WriteWarning("You are passing $null as a value for parameter InfoType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoRequest();
            
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.InfoType != null)
            {
                request.InfoType = cmdletContext.InfoType;
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
        
        private Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "RetrieveEnvironmentInfo");
            try
            {
                #if DESKTOP
                return client.RetrieveEnvironmentInfo(request);
                #elif CORECLR
                return client.RetrieveEnvironmentInfoAsync(request).GetAwaiter().GetResult();
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
            public System.String EnvironmentId { get; set; }
            public System.String EnvironmentName { get; set; }
            public Amazon.ElasticBeanstalk.EnvironmentInfoType InfoType { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.RetrieveEnvironmentInfoResponse, GetEBEnvironmentInfoCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentInfo;
        }
        
    }
}
