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
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Revokes an ingress rule in an Amazon Redshift security group for a previously authorized
    /// IP range or Amazon EC2 security group. To add an ingress rule, see <a>AuthorizeClusterSecurityGroupIngress</a>.
    /// For information about managing security groups, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-security-groups.html">Amazon
    /// Redshift Cluster Security Groups</a> in the <i>Amazon Redshift Cluster Management
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Revoke", "RSClusterSecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ClusterSecurityGroup")]
    [AWSCmdlet("Calls the Amazon Redshift RevokeClusterSecurityGroupIngress API operation.", Operation = new[] {"RevokeClusterSecurityGroupIngress"}, SelectReturnType = typeof(Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.ClusterSecurityGroup or Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse",
        "This cmdlet returns an Amazon.Redshift.Model.ClusterSecurityGroup object.",
        "The service call response (type Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RevokeRSClusterSecurityGroupIngressCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CIDRIP
        /// <summary>
        /// <para>
        /// <para>The IP range for which to revoke access. This range must be a valid Classless Inter-Domain
        /// Routing (CIDR) block of IP addresses. If <c>CIDRIP</c> is specified, <c>EC2SecurityGroupName</c>
        /// and <c>EC2SecurityGroupOwnerId</c> cannot be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String CIDRIP { get; set; }
        #endregion
        
        #region Parameter ClusterSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the security Group from which to revoke the ingress rule.</para>
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
        public System.String ClusterSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the EC2 Security Group whose access is to be revoked. If <c>EC2SecurityGroupName</c>
        /// is specified, <c>EC2SecurityGroupOwnerId</c> must also be provided and <c>CIDRIP</c>
        /// cannot be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupOwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account number of the owner of the security group specified
        /// in the <c>EC2SecurityGroupName</c> parameter. The Amazon Web Services access key ID
        /// is not an acceptable value. If <c>EC2SecurityGroupOwnerId</c> is specified, <c>EC2SecurityGroupName</c>
        /// must also be provided. and <c>CIDRIP</c> cannot be provided. </para><para>Example: <c>111122223333</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupOwnerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClusterSecurityGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClusterSecurityGroup";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterSecurityGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-RSClusterSecurityGroupIngress (RevokeClusterSecurityGroupIngress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse, RevokeRSClusterSecurityGroupIngressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CIDRIP = this.CIDRIP;
            context.ClusterSecurityGroupName = this.ClusterSecurityGroupName;
            #if MODULAR
            if (this.ClusterSecurityGroupName == null && ParameterWasBound(nameof(this.ClusterSecurityGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterSecurityGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EC2SecurityGroupName = this.EC2SecurityGroupName;
            context.EC2SecurityGroupOwnerId = this.EC2SecurityGroupOwnerId;
            
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
            var request = new Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressRequest();
            
            if (cmdletContext.CIDRIP != null)
            {
                request.CIDRIP = cmdletContext.CIDRIP;
            }
            if (cmdletContext.ClusterSecurityGroupName != null)
            {
                request.ClusterSecurityGroupName = cmdletContext.ClusterSecurityGroupName;
            }
            if (cmdletContext.EC2SecurityGroupName != null)
            {
                request.EC2SecurityGroupName = cmdletContext.EC2SecurityGroupName;
            }
            if (cmdletContext.EC2SecurityGroupOwnerId != null)
            {
                request.EC2SecurityGroupOwnerId = cmdletContext.EC2SecurityGroupOwnerId;
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
        
        private Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "RevokeClusterSecurityGroupIngress");
            try
            {
                return client.RevokeClusterSecurityGroupIngressAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CIDRIP { get; set; }
            public System.String ClusterSecurityGroupName { get; set; }
            public System.String EC2SecurityGroupName { get; set; }
            public System.String EC2SecurityGroupOwnerId { get; set; }
            public System.Func<Amazon.Redshift.Model.RevokeClusterSecurityGroupIngressResponse, RevokeRSClusterSecurityGroupIngressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClusterSecurityGroup;
        }
        
    }
}
