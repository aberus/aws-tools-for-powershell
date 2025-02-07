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
    /// Updates the description of an egress (outbound) security group rule. You can replace
    /// an existing description, or add a description to a rule that did not have one previously.
    /// You can remove a description for a security group rule by omitting the description
    /// parameter in the request.
    /// </summary>
    [Cmdlet("Update", "EC2SecurityGroupRuleEgressDescription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) UpdateSecurityGroupRuleDescriptionsEgress API operation.", Operation = new[] {"UpdateSecurityGroupRuleDescriptionsEgress"}, SelectReturnType = typeof(Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEC2SecurityGroupRuleEgressDescriptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the security group. You must specify either the security group ID or the
        /// security group name in the request. For security groups in a nondefault VPC, you must
        /// specify the security group ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>[Default VPC] The name of the security group. You must specify either the security
        /// group ID or the security group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter IpPermission
        /// <summary>
        /// <para>
        /// <para>The IP permissions for the security group rule. You must specify either the IP permissions
        /// or the description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IpPermissions")]
        public Amazon.EC2.Model.IpPermission[] IpPermission { get; set; }
        #endregion
        
        #region Parameter SecurityGroupRuleDescription
        /// <summary>
        /// <para>
        /// <para>The description for the egress security group rules. You must specify either the description
        /// or the IP permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupRuleDescriptions")]
        public Amazon.EC2.Model.SecurityGroupRuleDescription[] SecurityGroupRuleDescription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EC2SecurityGroupRuleEgressDescription (UpdateSecurityGroupRuleDescriptionsEgress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse, UpdateEC2SecurityGroupRuleEgressDescriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GroupId = this.GroupId;
            context.GroupName = this.GroupName;
            if (this.IpPermission != null)
            {
                context.IpPermission = new List<Amazon.EC2.Model.IpPermission>(this.IpPermission);
            }
            if (this.SecurityGroupRuleDescription != null)
            {
                context.SecurityGroupRuleDescription = new List<Amazon.EC2.Model.SecurityGroupRuleDescription>(this.SecurityGroupRuleDescription);
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
            var request = new Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressRequest();
            
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.IpPermission != null)
            {
                request.IpPermissions = cmdletContext.IpPermission;
            }
            if (cmdletContext.SecurityGroupRuleDescription != null)
            {
                request.SecurityGroupRuleDescriptions = cmdletContext.SecurityGroupRuleDescription;
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
        
        private Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "UpdateSecurityGroupRuleDescriptionsEgress");
            try
            {
                #if DESKTOP
                return client.UpdateSecurityGroupRuleDescriptionsEgress(request);
                #elif CORECLR
                return client.UpdateSecurityGroupRuleDescriptionsEgressAsync(request).GetAwaiter().GetResult();
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
            public System.String GroupId { get; set; }
            public System.String GroupName { get; set; }
            public List<Amazon.EC2.Model.IpPermission> IpPermission { get; set; }
            public List<Amazon.EC2.Model.SecurityGroupRuleDescription> SecurityGroupRuleDescription { get; set; }
            public System.Func<Amazon.EC2.Model.UpdateSecurityGroupRuleDescriptionsEgressResponse, UpdateEC2SecurityGroupRuleEgressDescriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
