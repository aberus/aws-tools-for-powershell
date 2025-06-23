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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a data quality ruleset with DQDL rules applied to a specified Glue table.
    /// 
    ///  
    /// <para>
    /// You create the ruleset using the Data Quality Definition Language (DQDL). For more
    /// information, see the Glue developer guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GLUEDataQualityRuleset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue CreateDataQualityRuleset API operation.", Operation = new[] {"CreateDataQualityRuleset"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateDataQualityRulesetResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.CreateDataQualityRulesetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.CreateDataQualityRulesetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGLUEDataQualityRulesetCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TargetTable_CatalogId
        /// <summary>
        /// <para>
        /// <para>The catalog id where the Glue table exists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetTable_CatalogId { get; set; }
        #endregion
        
        #region Parameter TargetTable_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database where the Glue table exists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetTable_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DataQualitySecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the security configuration created with the data quality encryption option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataQualitySecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the data quality ruleset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the data quality ruleset.</para>
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
        
        #region Parameter Ruleset
        /// <summary>
        /// <para>
        /// <para>A Data Quality Definition Language (DQDL) ruleset. For more information, see the Glue
        /// developer guide.</para>
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
        public System.String Ruleset { get; set; }
        #endregion
        
        #region Parameter TargetTable_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetTable_TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags applied to the data quality ruleset.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Used for idempotency and is recommended to be set to a random ID (such as a UUID)
        /// to avoid creating or starting multiple instances of the same resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateDataQualityRulesetResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateDataQualityRulesetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEDataQualityRuleset (CreateDataQualityRuleset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateDataQualityRulesetResponse, NewGLUEDataQualityRulesetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DataQualitySecurityConfiguration = this.DataQualitySecurityConfiguration;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ruleset = this.Ruleset;
            #if MODULAR
            if (this.Ruleset == null && ParameterWasBound(nameof(this.Ruleset)))
            {
                WriteWarning("You are passing $null as a value for parameter Ruleset which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TargetTable_CatalogId = this.TargetTable_CatalogId;
            context.TargetTable_DatabaseName = this.TargetTable_DatabaseName;
            context.TargetTable_TableName = this.TargetTable_TableName;
            
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
            var request = new Amazon.Glue.Model.CreateDataQualityRulesetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataQualitySecurityConfiguration != null)
            {
                request.DataQualitySecurityConfiguration = cmdletContext.DataQualitySecurityConfiguration;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Ruleset != null)
            {
                request.Ruleset = cmdletContext.Ruleset;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TargetTable
            var requestTargetTableIsNull = true;
            request.TargetTable = new Amazon.Glue.Model.DataQualityTargetTable();
            System.String requestTargetTable_targetTable_CatalogId = null;
            if (cmdletContext.TargetTable_CatalogId != null)
            {
                requestTargetTable_targetTable_CatalogId = cmdletContext.TargetTable_CatalogId;
            }
            if (requestTargetTable_targetTable_CatalogId != null)
            {
                request.TargetTable.CatalogId = requestTargetTable_targetTable_CatalogId;
                requestTargetTableIsNull = false;
            }
            System.String requestTargetTable_targetTable_DatabaseName = null;
            if (cmdletContext.TargetTable_DatabaseName != null)
            {
                requestTargetTable_targetTable_DatabaseName = cmdletContext.TargetTable_DatabaseName;
            }
            if (requestTargetTable_targetTable_DatabaseName != null)
            {
                request.TargetTable.DatabaseName = requestTargetTable_targetTable_DatabaseName;
                requestTargetTableIsNull = false;
            }
            System.String requestTargetTable_targetTable_TableName = null;
            if (cmdletContext.TargetTable_TableName != null)
            {
                requestTargetTable_targetTable_TableName = cmdletContext.TargetTable_TableName;
            }
            if (requestTargetTable_targetTable_TableName != null)
            {
                request.TargetTable.TableName = requestTargetTable_targetTable_TableName;
                requestTargetTableIsNull = false;
            }
             // determine if request.TargetTable should be set to null
            if (requestTargetTableIsNull)
            {
                request.TargetTable = null;
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
        
        private Amazon.Glue.Model.CreateDataQualityRulesetResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateDataQualityRulesetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateDataQualityRuleset");
            try
            {
                return client.CreateDataQualityRulesetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DataQualitySecurityConfiguration { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Ruleset { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TargetTable_CatalogId { get; set; }
            public System.String TargetTable_DatabaseName { get; set; }
            public System.String TargetTable_TableName { get; set; }
            public System.Func<Amazon.Glue.Model.CreateDataQualityRulesetResponse, NewGLUEDataQualityRulesetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
