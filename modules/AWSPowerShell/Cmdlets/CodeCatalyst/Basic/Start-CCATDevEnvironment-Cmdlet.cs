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
using Amazon.CodeCatalyst;
using Amazon.CodeCatalyst.Model;

namespace Amazon.PowerShell.Cmdlets.CCAT
{
    /// <summary>
    /// Starts a specified Dev Environment and puts it into an active state.
    /// </summary>
    [Cmdlet("Start", "CCATDevEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS CodeCatalyst StartDevEnvironment API operation.", Operation = new[] {"StartDevEnvironment"}, SelectReturnType = typeof(Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse",
        "This cmdlet returns an Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse object containing multiple properties."
    )]
    public partial class StartCCATDevEnvironmentCmdlet : AmazonCodeCatalystClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The system-generated unique ID of the Dev Environment. </para>
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
        
        #region Parameter Ide
        /// <summary>
        /// <para>
        /// <para>Information about the integrated development environment (IDE) configured for a Dev
        /// Environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ides")]
        public Amazon.CodeCatalyst.Model.IdeConfiguration[] Ide { get; set; }
        #endregion
        
        #region Parameter InactivityTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time the Dev Environment will run without any activity detected before
        /// stopping, in minutes. Only whole integers are allowed. Dev Environments consume compute
        /// minutes when running.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InactivityTimeoutMinutes")]
        public System.Int32? InactivityTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instace type to use for the Dev Environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeCatalyst.InstanceType")]
        public Amazon.CodeCatalyst.InstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project in the space.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter SpaceName
        /// <summary>
        /// <para>
        /// <para>The name of the space.</para>
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
        public System.String SpaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._ExecuteWithAnonymousCredentials = true;
            this._AWSSignerType = "bearer";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CCATDevEnvironment (StartDevEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse, StartCCATDevEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Ide != null)
            {
                context.Ide = new List<Amazon.CodeCatalyst.Model.IdeConfiguration>(this.Ide);
            }
            context.InactivityTimeoutMinute = this.InactivityTimeoutMinute;
            context.InstanceType = this.InstanceType;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SpaceName = this.SpaceName;
            #if MODULAR
            if (this.SpaceName == null && ParameterWasBound(nameof(this.SpaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCatalyst.Model.StartDevEnvironmentRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Ide != null)
            {
                request.Ides = cmdletContext.Ide;
            }
            if (cmdletContext.InactivityTimeoutMinute != null)
            {
                request.InactivityTimeoutMinutes = cmdletContext.InactivityTimeoutMinute.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            if (cmdletContext.SpaceName != null)
            {
                request.SpaceName = cmdletContext.SpaceName;
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
        
        private Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse CallAWSServiceOperation(IAmazonCodeCatalyst client, Amazon.CodeCatalyst.Model.StartDevEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCatalyst", "StartDevEnvironment");
            try
            {
                #if DESKTOP
                return client.StartDevEnvironment(request);
                #elif CORECLR
                return client.StartDevEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public List<Amazon.CodeCatalyst.Model.IdeConfiguration> Ide { get; set; }
            public System.Int32? InactivityTimeoutMinute { get; set; }
            public Amazon.CodeCatalyst.InstanceType InstanceType { get; set; }
            public System.String ProjectName { get; set; }
            public System.String SpaceName { get; set; }
            public System.Func<Amazon.CodeCatalyst.Model.StartDevEnvironmentResponse, StartCCATDevEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
