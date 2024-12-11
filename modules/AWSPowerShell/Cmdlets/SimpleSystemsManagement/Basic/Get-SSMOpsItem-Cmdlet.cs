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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Get information about an OpsItem by using the ID. You must have permission in Identity
    /// and Access Management (IAM) to view information about an OpsItem. For more information,
    /// see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter-setup.html">Set
    /// up OpsCenter</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.
    /// 
    ///  
    /// <para>
    /// Operations engineers and IT professionals use Amazon Web Services Systems Manager
    /// OpsCenter to view, investigate, and remediate operational issues impacting the performance
    /// and health of their Amazon Web Services resources. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter.html">Amazon
    /// Web Services Systems Manager OpsCenter</a> in the <i>Amazon Web Services Systems Manager
    /// User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SSMOpsItem")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.OpsItem")]
    [AWSCmdlet("Calls the AWS Systems Manager GetOpsItem API operation.", Operation = new[] {"GetOpsItem"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.OpsItem or Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.OpsItem object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMOpsItemCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OpsItemArn
        /// <summary>
        /// <para>
        /// <para>The OpsItem Amazon Resource Name (ARN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpsItemArn { get; set; }
        #endregion
        
        #region Parameter OpsItemId
        /// <summary>
        /// <para>
        /// <para>The ID of the OpsItem that you want to get.</para>
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
        public System.String OpsItemId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OpsItem'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OpsItem";
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
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse, GetSSMOpsItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OpsItemArn = this.OpsItemArn;
            context.OpsItemId = this.OpsItemId;
            #if MODULAR
            if (this.OpsItemId == null && ParameterWasBound(nameof(this.OpsItemId)))
            {
                WriteWarning("You are passing $null as a value for parameter OpsItemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetOpsItemRequest();
            
            if (cmdletContext.OpsItemArn != null)
            {
                request.OpsItemArn = cmdletContext.OpsItemArn;
            }
            if (cmdletContext.OpsItemId != null)
            {
                request.OpsItemId = cmdletContext.OpsItemId;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetOpsItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetOpsItem");
            try
            {
                #if DESKTOP
                return client.GetOpsItem(request);
                #elif CORECLR
                return client.GetOpsItemAsync(request).GetAwaiter().GetResult();
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
            public System.String OpsItemArn { get; set; }
            public System.String OpsItemId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetOpsItemResponse, GetSSMOpsItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OpsItem;
        }
        
    }
}
