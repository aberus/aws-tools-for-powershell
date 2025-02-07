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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Associates a branch network interface with a trunk network interface.
    /// 
    ///  
    /// <para>
    /// Before you create the association, use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateNetworkInterface.html">CreateNetworkInterface</a>
    /// command and set the interface type to <c>trunk</c>. You must also create a network
    /// interface for each branch network interface that you want to associate with the trunk
    /// network interface.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2TrunkInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TrunkInterfaceAssociation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AssociateTrunkInterface API operation.", Operation = new[] {"AssociateTrunkInterface"}, SelectReturnType = typeof(Amazon.EC2.Model.AssociateTrunkInterfaceResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TrunkInterfaceAssociation or Amazon.EC2.Model.AssociateTrunkInterfaceResponse",
        "This cmdlet returns an Amazon.EC2.Model.TrunkInterfaceAssociation object.",
        "The service call response (type Amazon.EC2.Model.AssociateTrunkInterfaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterEC2TrunkInterfaceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BranchInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the branch network interface.</para>
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
        public System.String BranchInterfaceId { get; set; }
        #endregion
        
        #region Parameter GreKey
        /// <summary>
        /// <para>
        /// <para>The application key. This applies to the GRE protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GreKey { get; set; }
        #endregion
        
        #region Parameter TrunkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the trunk network interface.</para>
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
        public System.String TrunkInterfaceId { get; set; }
        #endregion
        
        #region Parameter VlanId
        /// <summary>
        /// <para>
        /// <para>The ID of the VLAN. This applies to the VLAN protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VlanId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InterfaceAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AssociateTrunkInterfaceResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AssociateTrunkInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InterfaceAssociation";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2TrunkInterface (AssociateTrunkInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AssociateTrunkInterfaceResponse, RegisterEC2TrunkInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BranchInterfaceId = this.BranchInterfaceId;
            #if MODULAR
            if (this.BranchInterfaceId == null && ParameterWasBound(nameof(this.BranchInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter BranchInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.GreKey = this.GreKey;
            context.TrunkInterfaceId = this.TrunkInterfaceId;
            #if MODULAR
            if (this.TrunkInterfaceId == null && ParameterWasBound(nameof(this.TrunkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrunkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VlanId = this.VlanId;
            
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
            var request = new Amazon.EC2.Model.AssociateTrunkInterfaceRequest();
            
            if (cmdletContext.BranchInterfaceId != null)
            {
                request.BranchInterfaceId = cmdletContext.BranchInterfaceId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GreKey != null)
            {
                request.GreKey = cmdletContext.GreKey.Value;
            }
            if (cmdletContext.TrunkInterfaceId != null)
            {
                request.TrunkInterfaceId = cmdletContext.TrunkInterfaceId;
            }
            if (cmdletContext.VlanId != null)
            {
                request.VlanId = cmdletContext.VlanId.Value;
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
        
        private Amazon.EC2.Model.AssociateTrunkInterfaceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssociateTrunkInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AssociateTrunkInterface");
            try
            {
                #if DESKTOP
                return client.AssociateTrunkInterface(request);
                #elif CORECLR
                return client.AssociateTrunkInterfaceAsync(request).GetAwaiter().GetResult();
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
            public System.String BranchInterfaceId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? GreKey { get; set; }
            public System.String TrunkInterfaceId { get; set; }
            public System.Int32? VlanId { get; set; }
            public System.Func<Amazon.EC2.Model.AssociateTrunkInterfaceResponse, RegisterEC2TrunkInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InterfaceAssociation;
        }
        
    }
}
