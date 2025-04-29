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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a new DB parameter group.
    /// 
    ///  
    /// <para>
    /// A DB parameter group is initially created with the default parameters for the database
    /// engine used by the DB instance. To provide custom values for any of the parameters,
    /// you must modify the group after creating it using <c>ModifyDBParameterGroup</c>. Once
    /// you've created a DB parameter group, you need to associate it with your DB instance
    /// using <c>ModifyDBInstance</c>. When you associate a new DB parameter group with a
    /// running DB instance, you need to reboot the DB instance without failover for the new
    /// DB parameter group and associated settings to take effect.
    /// </para><para>
    /// This command doesn't apply to RDS Custom.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RDSDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBParameterGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBParameterGroup API operation.", Operation = new[] {"CreateDBParameterGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBParameterGroup or Amazon.RDS.Model.CreateDBParameterGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBParameterGroup object.",
        "The service call response (type Amazon.RDS.Model.CreateDBParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSDBParameterGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The DB parameter group family name. A DB parameter group can be associated with one
        /// and only one DB parameter group family, and can be applied only to a DB instance running
        /// a database engine and engine version compatible with that DB parameter group family.</para><para>To list all of the available parameter group families for a DB engine, use the following
        /// command:</para><para><c>aws rds describe-db-engine-versions --query "DBEngineVersions[].DBParameterGroupFamily"
        /// --engine &lt;engine&gt;</c></para><para>For example, to list all of the available parameter group families for the MySQL DB
        /// engine, use the following command:</para><para><c>aws rds describe-db-engine-versions --query "DBEngineVersions[].DBParameterGroupFamily"
        /// --engine mysql</c></para><note><para>The output contains duplicates.</para></note><para>The following are the valid DB engine values:</para><ul><li><para><c>aurora-mysql</c></para></li><li><para><c>aurora-postgresql</c></para></li><li><para><c>db2-ae</c></para></li><li><para><c>db2-se</c></para></li><li><para><c>mysql</c></para></li><li><para><c>oracle-ee</c></para></li><li><para><c>oracle-ee-cdb</c></para></li><li><para><c>oracle-se2</c></para></li><li><para><c>oracle-se2-cdb</c></para></li><li><para><c>postgres</c></para></li><li><para><c>sqlserver-ee</c></para></li><li><para><c>sqlserver-se</c></para></li><li><para><c>sqlserver-ex</c></para></li><li><para><c>sqlserver-web</c></para></li></ul>
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
        public System.String DBParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><note><para>This value is stored as a lowercase string.</para></note>
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
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the DB parameter group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBParameterGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateDBParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateDBParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBParameterGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBParameterGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBParameterGroup (CreateDBParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateDBParameterGroupResponse, NewRDSDBParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBParameterGroupFamily = this.DBParameterGroupFamily;
            #if MODULAR
            if (this.DBParameterGroupFamily == null && ParameterWasBound(nameof(this.DBParameterGroupFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter DBParameterGroupFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBParameterGroupName = this.DBParameterGroupName;
            #if MODULAR
            if (this.DBParameterGroupName == null && ParameterWasBound(nameof(this.DBParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.CreateDBParameterGroupRequest();
            
            if (cmdletContext.DBParameterGroupFamily != null)
            {
                request.DBParameterGroupFamily = cmdletContext.DBParameterGroupFamily;
            }
            if (cmdletContext.DBParameterGroupName != null)
            {
                request.DBParameterGroupName = cmdletContext.DBParameterGroupName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RDS.Model.CreateDBParameterGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBParameterGroup");
            try
            {
                return client.CreateDBParameterGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBParameterGroupFamily { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.CreateDBParameterGroupResponse, NewRDSDBParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBParameterGroup;
        }
        
    }
}
