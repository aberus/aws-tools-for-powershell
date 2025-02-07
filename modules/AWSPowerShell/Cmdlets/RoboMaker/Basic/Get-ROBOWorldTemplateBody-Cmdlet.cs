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
using Amazon.RoboMaker;
using Amazon.RoboMaker.Model;

namespace Amazon.PowerShell.Cmdlets.ROBO
{
    /// <summary>
    /// <important><para>
    /// End of support notice: On September 10, 2025, Amazon Web Services will discontinue
    /// support for Amazon Web Services RoboMaker. After September 10, 2025, you will no longer
    /// be able to access the Amazon Web Services RoboMaker console or Amazon Web Services
    /// RoboMaker resources. For more information on transitioning to Batch to help run containerized
    /// simulations, visit <a href="https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/">https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/</a>.
    /// 
    /// </para></important><para>
    /// Gets the world template body.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ROBOWorldTemplateBody")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS RoboMaker GetWorldTemplateBody API operation.", Operation = new[] {"GetWorldTemplateBody"}, SelectReturnType = typeof(Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse))]
    [AWSCmdletOutput("System.String or Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetROBOWorldTemplateBodyCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GenerationJob
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (arn) of the world generator job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerationJob { get; set; }
        #endregion
        
        #region Parameter Template
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (arn) of the world template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Template { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TemplateBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse).
        /// Specifying the name of a property of type Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TemplateBody";
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
                context.Select = CreateSelectDelegate<Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse, GetROBOWorldTemplateBodyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GenerationJob = this.GenerationJob;
            context.Template = this.Template;
            
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
            var request = new Amazon.RoboMaker.Model.GetWorldTemplateBodyRequest();
            
            if (cmdletContext.GenerationJob != null)
            {
                request.GenerationJob = cmdletContext.GenerationJob;
            }
            if (cmdletContext.Template != null)
            {
                request.Template = cmdletContext.Template;
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
        
        private Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.GetWorldTemplateBodyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "GetWorldTemplateBody");
            try
            {
                #if DESKTOP
                return client.GetWorldTemplateBody(request);
                #elif CORECLR
                return client.GetWorldTemplateBodyAsync(request).GetAwaiter().GetResult();
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
            public System.String GenerationJob { get; set; }
            public System.String Template { get; set; }
            public System.Func<Amazon.RoboMaker.Model.GetWorldTemplateBodyResponse, GetROBOWorldTemplateBodyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TemplateBody;
        }
        
    }
}
