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
using System.Threading;
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Associates the specified security groups with the specified Application Load Balancer
    /// or Network Load Balancer. The specified security groups override the previously associated
    /// security groups.
    /// 
    ///  
    /// <para>
    /// You can't perform this operation on a Network Load Balancer unless you specified a
    /// security group for the load balancer when you created it.
    /// </para><para>
    /// You can't associate a security group with a Gateway Load Balancer.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ELB2SecurityGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 SetSecurityGroups API operation.", Operation = new[] {"SetSecurityGroups"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetELB2SecurityGroupCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic
        /// <summary>
        /// <para>
        /// <para>Indicates whether to evaluate inbound security group rules for traffic sent to a Network
        /// Load Balancer through Amazon Web Services PrivateLink. The default is <c>on</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.EnforceSecurityGroupInboundRulesOnPrivateLinkTrafficEnum")]
        public Amazon.ElasticLoadBalancingV2.EnforceSecurityGroupInboundRulesOnPrivateLinkTrafficEnum EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic { get; set; }
        #endregion
        
        #region Parameter LoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the load balancer.</para>
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
        public System.String LoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups.</para>
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
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityGroupIds'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityGroupIds";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-ELB2SecurityGroup (SetSecurityGroups)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse, SetELB2SecurityGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic = this.EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic;
            context.LoadBalancerArn = this.LoadBalancerArn;
            #if MODULAR
            if (this.LoadBalancerArn == null && ParameterWasBound(nameof(this.LoadBalancerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
            }
            #if MODULAR
            if (this.SecurityGroup == null && ParameterWasBound(nameof(this.SecurityGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsRequest();
            
            if (cmdletContext.EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic != null)
            {
                request.EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic = cmdletContext.EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic;
            }
            if (cmdletContext.LoadBalancerArn != null)
            {
                request.LoadBalancerArn = cmdletContext.LoadBalancerArn;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "SetSecurityGroups");
            try
            {
                return client.SetSecurityGroupsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ElasticLoadBalancingV2.EnforceSecurityGroupInboundRulesOnPrivateLinkTrafficEnum EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic { get; set; }
            public System.String LoadBalancerArn { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.SetSecurityGroupsResponse, SetELB2SecurityGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityGroupIds;
        }
        
    }
}
