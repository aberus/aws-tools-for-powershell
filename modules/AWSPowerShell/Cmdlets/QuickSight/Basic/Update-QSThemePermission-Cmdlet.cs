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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates the resource permissions for a theme. Permissions apply to the action to grant
    /// or revoke permissions on, for example <c>"quicksight:DescribeTheme"</c>.
    /// 
    ///  
    /// <para>
    /// Theme permissions apply in groupings. Valid groupings include the following for the
    /// three levels of permissions, which are user, owner, or no permissions: 
    /// </para><ul><li><para>
    /// User
    /// </para><ul><li><para><c>"quicksight:DescribeTheme"</c></para></li><li><para><c>"quicksight:DescribeThemeAlias"</c></para></li><li><para><c>"quicksight:ListThemeAliases"</c></para></li><li><para><c>"quicksight:ListThemeVersions"</c></para></li></ul></li><li><para>
    /// Owner
    /// </para><ul><li><para><c>"quicksight:DescribeTheme"</c></para></li><li><para><c>"quicksight:DescribeThemeAlias"</c></para></li><li><para><c>"quicksight:ListThemeAliases"</c></para></li><li><para><c>"quicksight:ListThemeVersions"</c></para></li><li><para><c>"quicksight:DeleteTheme"</c></para></li><li><para><c>"quicksight:UpdateTheme"</c></para></li><li><para><c>"quicksight:CreateThemeAlias"</c></para></li><li><para><c>"quicksight:DeleteThemeAlias"</c></para></li><li><para><c>"quicksight:UpdateThemeAlias"</c></para></li><li><para><c>"quicksight:UpdateThemePermissions"</c></para></li><li><para><c>"quicksight:DescribeThemePermissions"</c></para></li></ul></li><li><para>
    /// To specify no permissions, omit the permissions list.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "QSThemePermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateThemePermissionsResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateThemePermissions API operation.", Operation = new[] {"UpdateThemePermissions"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateThemePermissionsResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateThemePermissionsResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateThemePermissionsResponse object containing multiple properties."
    )]
    public partial class UpdateQSThemePermissionCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the theme.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter GrantPermission
        /// <summary>
        /// <para>
        /// <para>A list of resource permissions to be granted for the theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantPermissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] GrantPermission { get; set; }
        #endregion
        
        #region Parameter RevokePermission
        /// <summary>
        /// <para>
        /// <para>A list of resource permissions to be revoked from the theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevokePermissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] RevokePermission { get; set; }
        #endregion
        
        #region Parameter ThemeId
        /// <summary>
        /// <para>
        /// <para>The ID for the theme.</para>
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
        public System.String ThemeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateThemePermissionsResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateThemePermissionsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThemeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSThemePermission (UpdateThemePermissions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateThemePermissionsResponse, UpdateQSThemePermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GrantPermission != null)
            {
                context.GrantPermission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.GrantPermission);
            }
            if (this.RevokePermission != null)
            {
                context.RevokePermission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.RevokePermission);
            }
            context.ThemeId = this.ThemeId;
            #if MODULAR
            if (this.ThemeId == null && ParameterWasBound(nameof(this.ThemeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ThemeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.UpdateThemePermissionsRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.GrantPermission != null)
            {
                request.GrantPermissions = cmdletContext.GrantPermission;
            }
            if (cmdletContext.RevokePermission != null)
            {
                request.RevokePermissions = cmdletContext.RevokePermission;
            }
            if (cmdletContext.ThemeId != null)
            {
                request.ThemeId = cmdletContext.ThemeId;
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
        
        private Amazon.QuickSight.Model.UpdateThemePermissionsResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateThemePermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateThemePermissions");
            try
            {
                #if DESKTOP
                return client.UpdateThemePermissions(request);
                #elif CORECLR
                return client.UpdateThemePermissionsAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> GrantPermission { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> RevokePermission { get; set; }
            public System.String ThemeId { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateThemePermissionsResponse, UpdateQSThemePermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
