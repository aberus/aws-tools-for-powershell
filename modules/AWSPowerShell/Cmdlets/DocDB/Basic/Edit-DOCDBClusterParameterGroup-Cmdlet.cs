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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Modifies the parameters of a cluster parameter group. To modify more than one parameter,
    /// submit a list of the following: <c>ParameterName</c>, <c>ParameterValue</c>, and <c>ApplyMethod</c>.
    /// A maximum of 20 parameters can be modified in a single request. 
    /// 
    ///  <note><para>
    /// Changes to dynamic parameters are applied immediately. Changes to static parameters
    /// require a reboot or maintenance window before the change can take effect.
    /// </para></note><important><para>
    /// After you create a cluster parameter group, you should wait at least 5 minutes before
    /// creating your first cluster that uses that cluster parameter group as the default
    /// parameter group. This allows Amazon DocumentDB to fully complete the create action
    /// before the parameter group is used as the default for a new cluster. This step is
    /// especially important for parameters that are critical when creating the default database
    /// for a cluster, such as the character set for the default database defined by the <c>character_set_database</c>
    /// parameter.
    /// </para></important>
    /// </summary>
    [Cmdlet("Edit", "DOCDBClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) ModifyDBClusterParameterGroup API operation.", Operation = new[] {"ModifyDBClusterParameterGroup"}, SelectReturnType = typeof(Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditDOCDBClusterParameterGroupCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster parameter group to modify.</para>
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
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of parameters in the cluster parameter group to modify.</para>
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
        [Alias("Parameters")]
        public Amazon.DocDB.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterParameterGroupName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterParameterGroupName";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterParameterGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DOCDBClusterParameterGroup (ModifyDBClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse, EditDOCDBClusterParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            #if MODULAR
            if (this.DBClusterParameterGroupName == null && ParameterWasBound(nameof(this.DBClusterParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.DocDB.Model.Parameter>(this.Parameter);
            }
            #if MODULAR
            if (this.Parameter == null && ParameterWasBound(nameof(this.Parameter)))
            {
                WriteWarning("You are passing $null as a value for parameter Parameter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.ModifyDBClusterParameterGroupRequest();
            
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
        
        private Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.ModifyDBClusterParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "ModifyDBClusterParameterGroup");
            try
            {
                #if DESKTOP
                return client.ModifyDBClusterParameterGroup(request);
                #elif CORECLR
                return client.ModifyDBClusterParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterParameterGroupName { get; set; }
            public List<Amazon.DocDB.Model.Parameter> Parameter { get; set; }
            public System.Func<Amazon.DocDB.Model.ModifyDBClusterParameterGroupResponse, EditDOCDBClusterParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterParameterGroupName;
        }
        
    }
}
