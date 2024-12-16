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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Updates details of the specified Amazon Chime Voice Connector group, such as the name
    /// and Amazon Chime Voice Connector priority ranking.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_UpdateVoiceConnectorGroup.html">UpdateVoiceConnectorGroup</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Update", "CHMVoiceConnectorGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.VoiceConnectorGroup")]
    [AWSCmdlet("Calls the Amazon Chime UpdateVoiceConnectorGroup API operation.", Operation = new[] {"UpdateVoiceConnectorGroup"}, SelectReturnType = typeof(Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.VoiceConnectorGroup or Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse",
        "This cmdlet returns an Amazon.Chime.Model.VoiceConnectorGroup object.",
        "The service call response (type Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by UpdateVoiceConnectorGroup in the Amazon Chime SDK Voice Namespace")]
    public partial class UpdateCHMVoiceConnectorGroupCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Chime Voice Connector group.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorGroupId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime Voice Connector group ID.</para>
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
        public System.String VoiceConnectorGroupId { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorItem
        /// <summary>
        /// <para>
        /// <para>The <c>VoiceConnectorItems</c> to associate with the group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("VoiceConnectorItems")]
        public Amazon.Chime.Model.VoiceConnectorItem[] VoiceConnectorItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceConnectorGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceConnectorGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMVoiceConnectorGroup (UpdateVoiceConnectorGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse, UpdateCHMVoiceConnectorGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceConnectorGroupId = this.VoiceConnectorGroupId;
            #if MODULAR
            if (this.VoiceConnectorGroupId == null && ParameterWasBound(nameof(this.VoiceConnectorGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VoiceConnectorItem != null)
            {
                context.VoiceConnectorItem = new List<Amazon.Chime.Model.VoiceConnectorItem>(this.VoiceConnectorItem);
            }
            #if MODULAR
            if (this.VoiceConnectorItem == null && ParameterWasBound(nameof(this.VoiceConnectorItem)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chime.Model.UpdateVoiceConnectorGroupRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.VoiceConnectorGroupId != null)
            {
                request.VoiceConnectorGroupId = cmdletContext.VoiceConnectorGroupId;
            }
            if (cmdletContext.VoiceConnectorItem != null)
            {
                request.VoiceConnectorItems = cmdletContext.VoiceConnectorItem;
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
        
        private Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.UpdateVoiceConnectorGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "UpdateVoiceConnectorGroup");
            try
            {
                #if DESKTOP
                return client.UpdateVoiceConnectorGroup(request);
                #elif CORECLR
                return client.UpdateVoiceConnectorGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String VoiceConnectorGroupId { get; set; }
            public List<Amazon.Chime.Model.VoiceConnectorItem> VoiceConnectorItem { get; set; }
            public System.Func<Amazon.Chime.Model.UpdateVoiceConnectorGroupResponse, UpdateCHMVoiceConnectorGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceConnectorGroup;
        }
        
    }
}
