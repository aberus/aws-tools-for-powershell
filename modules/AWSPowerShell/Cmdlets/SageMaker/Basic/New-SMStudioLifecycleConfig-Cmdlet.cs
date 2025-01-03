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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a new Amazon SageMaker AI Studio Lifecycle Configuration.
    /// </summary>
    [Cmdlet("New", "SMStudioLifecycleConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateStudioLifecycleConfig API operation.", Operation = new[] {"CreateStudioLifecycleConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMStudioLifecycleConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StudioLifecycleConfigAppType
        /// <summary>
        /// <para>
        /// <para>The App type that the Lifecycle Configuration is attached to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.StudioLifecycleConfigAppType")]
        public Amazon.SageMaker.StudioLifecycleConfigAppType StudioLifecycleConfigAppType { get; set; }
        #endregion
        
        #region Parameter StudioLifecycleConfigContent
        /// <summary>
        /// <para>
        /// <para>The content of your Amazon SageMaker AI Studio Lifecycle Configuration script. This
        /// content must be base64 encoded.</para>
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
        public System.String StudioLifecycleConfigContent { get; set; }
        #endregion
        
        #region Parameter StudioLifecycleConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon SageMaker AI Studio Lifecycle Configuration to create.</para>
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
        public System.String StudioLifecycleConfigName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be associated with the Lifecycle Configuration. Each tag consists of a key
        /// and an optional value. Tag keys must be unique per resource. Tags are searchable using
        /// the Search API. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StudioLifecycleConfigArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StudioLifecycleConfigArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StudioLifecycleConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMStudioLifecycleConfig (CreateStudioLifecycleConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse, NewSMStudioLifecycleConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StudioLifecycleConfigAppType = this.StudioLifecycleConfigAppType;
            #if MODULAR
            if (this.StudioLifecycleConfigAppType == null && ParameterWasBound(nameof(this.StudioLifecycleConfigAppType)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioLifecycleConfigAppType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StudioLifecycleConfigContent = this.StudioLifecycleConfigContent;
            #if MODULAR
            if (this.StudioLifecycleConfigContent == null && ParameterWasBound(nameof(this.StudioLifecycleConfigContent)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioLifecycleConfigContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StudioLifecycleConfigName = this.StudioLifecycleConfigName;
            #if MODULAR
            if (this.StudioLifecycleConfigName == null && ParameterWasBound(nameof(this.StudioLifecycleConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioLifecycleConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.SageMaker.Model.CreateStudioLifecycleConfigRequest();
            
            if (cmdletContext.StudioLifecycleConfigAppType != null)
            {
                request.StudioLifecycleConfigAppType = cmdletContext.StudioLifecycleConfigAppType;
            }
            if (cmdletContext.StudioLifecycleConfigContent != null)
            {
                request.StudioLifecycleConfigContent = cmdletContext.StudioLifecycleConfigContent;
            }
            if (cmdletContext.StudioLifecycleConfigName != null)
            {
                request.StudioLifecycleConfigName = cmdletContext.StudioLifecycleConfigName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateStudioLifecycleConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateStudioLifecycleConfig");
            try
            {
                #if DESKTOP
                return client.CreateStudioLifecycleConfig(request);
                #elif CORECLR
                return client.CreateStudioLifecycleConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.StudioLifecycleConfigAppType StudioLifecycleConfigAppType { get; set; }
            public System.String StudioLifecycleConfigContent { get; set; }
            public System.String StudioLifecycleConfigName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateStudioLifecycleConfigResponse, NewSMStudioLifecycleConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StudioLifecycleConfigArn;
        }
        
    }
}
