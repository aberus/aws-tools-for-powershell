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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Removes health-based detection from the Shield Advanced protection for a resource.
    /// Shield Advanced health-based detection uses the health of your Amazon Web Services
    /// resource to improve responsiveness and accuracy in attack detection and response.
    /// 
    /// 
    ///  
    /// <para>
    /// You define the health check in Route 53 and then associate or disassociate it with
    /// your Shield Advanced protection. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/ddos-overview.html#ddos-advanced-health-check-option">Shield
    /// Advanced Health-Based Detection</a> in the <i>WAF Developer Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SHLDHealthCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Shield DisassociateHealthCheck API operation.", Operation = new[] {"DisassociateHealthCheck"}, SelectReturnType = typeof(Amazon.Shield.Model.DisassociateHealthCheckResponse))]
    [AWSCmdletOutput("None or Amazon.Shield.Model.DisassociateHealthCheckResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Shield.Model.DisassociateHealthCheckResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSHLDHealthCheckCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HealthCheckArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the health check that is associated with the protection.</para>
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
        public System.String HealthCheckArn { get; set; }
        #endregion
        
        #region Parameter ProtectionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) for the <a>Protection</a> object to remove the health check
        /// association from. </para>
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
        public System.String ProtectionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.DisassociateHealthCheckResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HealthCheckArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SHLDHealthCheck (DisassociateHealthCheck)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.DisassociateHealthCheckResponse, RemoveSHLDHealthCheckCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HealthCheckArn = this.HealthCheckArn;
            #if MODULAR
            if (this.HealthCheckArn == null && ParameterWasBound(nameof(this.HealthCheckArn)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheckArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProtectionId = this.ProtectionId;
            #if MODULAR
            if (this.ProtectionId == null && ParameterWasBound(nameof(this.ProtectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProtectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Shield.Model.DisassociateHealthCheckRequest();
            
            if (cmdletContext.HealthCheckArn != null)
            {
                request.HealthCheckArn = cmdletContext.HealthCheckArn;
            }
            if (cmdletContext.ProtectionId != null)
            {
                request.ProtectionId = cmdletContext.ProtectionId;
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
        
        private Amazon.Shield.Model.DisassociateHealthCheckResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.DisassociateHealthCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "DisassociateHealthCheck");
            try
            {
                #if DESKTOP
                return client.DisassociateHealthCheck(request);
                #elif CORECLR
                return client.DisassociateHealthCheckAsync(request).GetAwaiter().GetResult();
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
            public System.String HealthCheckArn { get; set; }
            public System.String ProtectionId { get; set; }
            public System.Func<Amazon.Shield.Model.DisassociateHealthCheckResponse, RemoveSHLDHealthCheckCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
