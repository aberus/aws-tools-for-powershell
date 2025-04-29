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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Given the name of a user pool group, updates any of the properties for precedence,
    /// IAM role, or description. For more information about user pool groups, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-user-groups.html">Adding
    /// groups to a user pool</a>.
    /// 
    ///  <note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "CGIPGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.GroupType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider UpdateGroup API operation.", Operation = new[] {"UpdateGroup"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.GroupType or Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.GroupType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCGIPGroupCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description of the existing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the group that you want to update.</para>
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
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter Precedence
        /// <summary>
        /// <para>
        /// <para>A non-negative integer value that specifies the precedence of this group relative
        /// to the other groups that a user can belong to in the user pool. Zero is the highest
        /// precedence value. Groups with lower <c>Precedence</c> values take precedence over
        /// groups with higher or null <c>Precedence</c> values. If a user belongs to two or more
        /// groups, it is the group with the lowest precedence value whose role ARN is given in
        /// the user's tokens for the <c>cognito:roles</c> and <c>cognito:preferred_role</c> claims.</para><para>Two groups can have the same <c>Precedence</c> value. If this happens, neither group
        /// takes precedence over the other. If two groups with the same <c>Precedence</c> have
        /// the same role ARN, that role is used in the <c>cognito:preferred_role</c> claim in
        /// tokens for users in each group. If the two groups have different role ARNs, the <c>cognito:preferred_role</c>
        /// claim isn't set in users' tokens.</para><para>The default <c>Precedence</c> value is null. The maximum <c>Precedence</c> value is
        /// <c>2^31-1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Precedence { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that you want to associate with the
        /// group. The role assignment contributes to the <c>cognito:roles</c> and <c>cognito:preferred_role</c>
        /// claims in group members' tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that contains the group you want to update.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Group'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Group";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPGroup (UpdateGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse, UpdateCGIPGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.GroupName = this.GroupName;
            #if MODULAR
            if (this.GroupName == null && ParameterWasBound(nameof(this.GroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Precedence = this.Precedence;
            context.RoleArn = this.RoleArn;
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.UpdateGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.Precedence != null)
            {
                request.Precedence = cmdletContext.Precedence.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateGroup");
            try
            {
                return client.UpdateGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String GroupName { get; set; }
            public System.Int32? Precedence { get; set; }
            public System.String RoleArn { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.UpdateGroupResponse, UpdateCGIPGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Group;
        }
        
    }
}
