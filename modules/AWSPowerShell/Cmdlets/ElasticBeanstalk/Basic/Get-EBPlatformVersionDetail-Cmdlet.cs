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
    /// Describes a platform version. Provides full details. Compare to <a>ListPlatformVersions</a>,
    /// which provides summary information about a list of platform versions.
    /// 
    ///  
    /// <para>
    /// For definitions of platform version and other platform-related terms, see <a href="https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/platforms-glossary.html">AWS
    /// Elastic Beanstalk Platforms Glossary</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EBPlatformVersionDetail")]
    [OutputType("Amazon.ElasticBeanstalk.Model.PlatformDescription")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk DescribePlatformVersion API operation.", Operation = new[] {"DescribePlatformVersion"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.PlatformDescription or Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.PlatformDescription object.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEBPlatformVersionDetailCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PlatformArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the platform version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PlatformArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PlatformDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PlatformDescription";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse, GetEBPlatformVersionDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PlatformArn = this.PlatformArn;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.DescribePlatformVersionRequest();
            
            if (cmdletContext.PlatformArn != null)
            {
                request.PlatformArn = cmdletContext.PlatformArn;
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
        
        private Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.DescribePlatformVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "DescribePlatformVersion");
            try
            {
                #if DESKTOP
                return client.DescribePlatformVersion(request);
                #elif CORECLR
                return client.DescribePlatformVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String PlatformArn { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.DescribePlatformVersionResponse, GetEBPlatformVersionDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PlatformDescription;
        }
        
    }
}
