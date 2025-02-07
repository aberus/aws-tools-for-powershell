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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// The live source to delete.
    /// </summary>
    [Cmdlet("Remove", "EMTLiveSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor DeleteLiveSource API operation.", Operation = new[] {"DeleteLiveSource"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.DeleteLiveSourceResponse))]
    [AWSCmdletOutput("None or Amazon.MediaTailor.Model.DeleteLiveSourceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MediaTailor.Model.DeleteLiveSourceResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveEMTLiveSourceCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LiveSourceName
        /// <summary>
        /// <para>
        /// <para>The name of the live source.</para>
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
        public System.String LiveSourceName { get; set; }
        #endregion
        
        #region Parameter SourceLocationName
        /// <summary>
        /// <para>
        /// <para>The name of the source location associated with this Live Source.</para>
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
        public System.String SourceLocationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.DeleteLiveSourceResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EMTLiveSource (DeleteLiveSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.DeleteLiveSourceResponse, RemoveEMTLiveSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LiveSourceName = this.LiveSourceName;
            #if MODULAR
            if (this.LiveSourceName == null && ParameterWasBound(nameof(this.LiveSourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter LiveSourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceLocationName = this.SourceLocationName;
            #if MODULAR
            if (this.SourceLocationName == null && ParameterWasBound(nameof(this.SourceLocationName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceLocationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaTailor.Model.DeleteLiveSourceRequest();
            
            if (cmdletContext.LiveSourceName != null)
            {
                request.LiveSourceName = cmdletContext.LiveSourceName;
            }
            if (cmdletContext.SourceLocationName != null)
            {
                request.SourceLocationName = cmdletContext.SourceLocationName;
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
        
        private Amazon.MediaTailor.Model.DeleteLiveSourceResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.DeleteLiveSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "DeleteLiveSource");
            try
            {
                #if DESKTOP
                return client.DeleteLiveSource(request);
                #elif CORECLR
                return client.DeleteLiveSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String LiveSourceName { get; set; }
            public System.String SourceLocationName { get; set; }
            public System.Func<Amazon.MediaTailor.Model.DeleteLiveSourceResponse, RemoveEMTLiveSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
