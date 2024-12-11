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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Updates the settings of query suggestions for an index.
    /// 
    ///  
    /// <para>
    /// Amazon Kendra supports partial updates, so you only need to provide the fields you
    /// want to update.
    /// </para><para>
    /// If an update is currently processing, you need to wait for the update to finish before
    /// making another update.
    /// </para><para>
    /// Updates to query suggestions settings might not take effect right away. The time for
    /// your updated settings to take effect depends on the updates made and the number of
    /// search queries in your index.
    /// </para><para>
    /// You can still enable/disable query suggestions at any time.
    /// </para><para><c>UpdateQuerySuggestionsConfig</c> is currently not supported in the Amazon Web
    /// Services GovCloud (US-West) region.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KNDRQuerySuggestionsConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra UpdateQuerySuggestionsConfig API operation.", Operation = new[] {"UpdateQuerySuggestionsConfig"}, SelectReturnType = typeof(Amazon.Kendra.Model.UpdateQuerySuggestionsConfigResponse))]
    [AWSCmdletOutput("None or Amazon.Kendra.Model.UpdateQuerySuggestionsConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kendra.Model.UpdateQuerySuggestionsConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKNDRQuerySuggestionsConfigCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeSuggestionsConfig_AttributeSuggestionsMode
        /// <summary>
        /// <para>
        /// <para>You can set the mode to <c>ACTIVE</c> or <c>INACTIVE</c>. You must also set <c>SuggestionTypes</c>
        /// as either <c>QUERY</c> or <c>DOCUMENT_ATTRIBUTES</c> and then call <a href="https://docs.aws.amazon.com/kendra/latest/dg/API_GetQuerySuggestions.html">GetQuerySuggestions</a>.
        /// If <c>Mode</c> to use query history is set to <c>ENABLED</c> when calling <a href="https://docs.aws.amazon.com/kendra/latest/dg/API_UpdateQuerySuggestionsConfig.html">UpdateQuerySuggestionsConfig</a>
        /// and <c>AttributeSuggestionsMode</c> to use fields/attributes is set to <c>ACTIVE</c>,
        /// and you haven't set your <c>SuggestionTypes</c> preference to <c>DOCUMENT_ATTRIBUTES</c>,
        /// then Amazon Kendra uses the query history.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.AttributeSuggestionsMode")]
        public Amazon.Kendra.AttributeSuggestionsMode AttributeSuggestionsConfig_AttributeSuggestionsMode { get; set; }
        #endregion
        
        #region Parameter IncludeQueriesWithoutUserInformation
        /// <summary>
        /// <para>
        /// <para><c>TRUE</c> to include queries without user information (i.e. all queries, irrespective
        /// of the user), otherwise <c>FALSE</c> to only include queries with user information.</para><para>If you pass user information to Amazon Kendra along with the queries, you can set
        /// this flag to <c>FALSE</c> and instruct Amazon Kendra to only consider queries with
        /// user information.</para><para>If you set to <c>FALSE</c>, Amazon Kendra only considers queries searched at least
        /// <c>MinimumQueryCount</c> times across <c>MinimumNumberOfQueryingUsers</c> unique users
        /// for suggestions.</para><para>If you set to <c>TRUE</c>, Amazon Kendra ignores all user information and learns from
        /// all queries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeQueriesWithoutUserInformation { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para> The identifier of the index with query suggestions you want to update.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter MinimumNumberOfQueryingUser
        /// <summary>
        /// <para>
        /// <para>The minimum number of unique users who must search a query in order for the query
        /// to be eligible to suggest to your users.</para><para>Increasing this number might decrease the number of suggestions. However, this ensures
        /// a query is searched by many users and is truly popular to suggest to users.</para><para>How you tune this setting depends on your specific needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinimumNumberOfQueryingUsers")]
        public System.Int32? MinimumNumberOfQueryingUser { get; set; }
        #endregion
        
        #region Parameter MinimumQueryCount
        /// <summary>
        /// <para>
        /// <para>The the minimum number of times a query must be searched in order to be eligible to
        /// suggest to your users.</para><para>Decreasing this number increases the number of suggestions. However, this affects
        /// the quality of suggestions as it sets a low bar for a query to be considered popular
        /// to suggest to users.</para><para>How you tune this setting depends on your specific needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinimumQueryCount { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>Set the mode to <c>ENABLED</c> or <c>LEARN_ONLY</c>.</para><para>By default, Amazon Kendra enables query suggestions. <c>LEARN_ONLY</c> mode allows
        /// you to turn off query suggestions. You can to update this at any time.</para><para>In <c>LEARN_ONLY</c> mode, Amazon Kendra continues to learn from new queries to keep
        /// suggestions up to date for when you are ready to switch to ENABLED mode again.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.Mode")]
        public Amazon.Kendra.Mode Mode { get; set; }
        #endregion
        
        #region Parameter QueryLogLookBackWindowInDay
        /// <summary>
        /// <para>
        /// <para>How recent your queries are in your query log time window.</para><para>The time window is the number of days from current day to past days.</para><para>By default, Amazon Kendra sets this to 180.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryLogLookBackWindowInDays")]
        public System.Int32? QueryLogLookBackWindowInDay { get; set; }
        #endregion
        
        #region Parameter AttributeSuggestionsConfig_SuggestableConfigList
        /// <summary>
        /// <para>
        /// <para>The list of fields/attributes that you want to set as suggestible for query suggestions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kendra.Model.SuggestableConfig[] AttributeSuggestionsConfig_SuggestableConfigList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.UpdateQuerySuggestionsConfigResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNDRQuerySuggestionsConfig (UpdateQuerySuggestionsConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.UpdateQuerySuggestionsConfigResponse, UpdateKNDRQuerySuggestionsConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttributeSuggestionsConfig_AttributeSuggestionsMode = this.AttributeSuggestionsConfig_AttributeSuggestionsMode;
            if (this.AttributeSuggestionsConfig_SuggestableConfigList != null)
            {
                context.AttributeSuggestionsConfig_SuggestableConfigList = new List<Amazon.Kendra.Model.SuggestableConfig>(this.AttributeSuggestionsConfig_SuggestableConfigList);
            }
            context.IncludeQueriesWithoutUserInformation = this.IncludeQueriesWithoutUserInformation;
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinimumNumberOfQueryingUser = this.MinimumNumberOfQueryingUser;
            context.MinimumQueryCount = this.MinimumQueryCount;
            context.Mode = this.Mode;
            context.QueryLogLookBackWindowInDay = this.QueryLogLookBackWindowInDay;
            
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
            var request = new Amazon.Kendra.Model.UpdateQuerySuggestionsConfigRequest();
            
            
             // populate AttributeSuggestionsConfig
            var requestAttributeSuggestionsConfigIsNull = true;
            request.AttributeSuggestionsConfig = new Amazon.Kendra.Model.AttributeSuggestionsUpdateConfig();
            Amazon.Kendra.AttributeSuggestionsMode requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeSuggestionsMode = null;
            if (cmdletContext.AttributeSuggestionsConfig_AttributeSuggestionsMode != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeSuggestionsMode = cmdletContext.AttributeSuggestionsConfig_AttributeSuggestionsMode;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeSuggestionsMode != null)
            {
                request.AttributeSuggestionsConfig.AttributeSuggestionsMode = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeSuggestionsMode;
                requestAttributeSuggestionsConfigIsNull = false;
            }
            List<Amazon.Kendra.Model.SuggestableConfig> requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestableConfigList = null;
            if (cmdletContext.AttributeSuggestionsConfig_SuggestableConfigList != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestableConfigList = cmdletContext.AttributeSuggestionsConfig_SuggestableConfigList;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestableConfigList != null)
            {
                request.AttributeSuggestionsConfig.SuggestableConfigList = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestableConfigList;
                requestAttributeSuggestionsConfigIsNull = false;
            }
             // determine if request.AttributeSuggestionsConfig should be set to null
            if (requestAttributeSuggestionsConfigIsNull)
            {
                request.AttributeSuggestionsConfig = null;
            }
            if (cmdletContext.IncludeQueriesWithoutUserInformation != null)
            {
                request.IncludeQueriesWithoutUserInformation = cmdletContext.IncludeQueriesWithoutUserInformation.Value;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.MinimumNumberOfQueryingUser != null)
            {
                request.MinimumNumberOfQueryingUsers = cmdletContext.MinimumNumberOfQueryingUser.Value;
            }
            if (cmdletContext.MinimumQueryCount != null)
            {
                request.MinimumQueryCount = cmdletContext.MinimumQueryCount.Value;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.QueryLogLookBackWindowInDay != null)
            {
                request.QueryLogLookBackWindowInDays = cmdletContext.QueryLogLookBackWindowInDay.Value;
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
        
        private Amazon.Kendra.Model.UpdateQuerySuggestionsConfigResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.UpdateQuerySuggestionsConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "UpdateQuerySuggestionsConfig");
            try
            {
                #if DESKTOP
                return client.UpdateQuerySuggestionsConfig(request);
                #elif CORECLR
                return client.UpdateQuerySuggestionsConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Kendra.AttributeSuggestionsMode AttributeSuggestionsConfig_AttributeSuggestionsMode { get; set; }
            public List<Amazon.Kendra.Model.SuggestableConfig> AttributeSuggestionsConfig_SuggestableConfigList { get; set; }
            public System.Boolean? IncludeQueriesWithoutUserInformation { get; set; }
            public System.String IndexId { get; set; }
            public System.Int32? MinimumNumberOfQueryingUser { get; set; }
            public System.Int32? MinimumQueryCount { get; set; }
            public Amazon.Kendra.Mode Mode { get; set; }
            public System.Int32? QueryLogLookBackWindowInDay { get; set; }
            public System.Func<Amazon.Kendra.Model.UpdateQuerySuggestionsConfigResponse, UpdateKNDRQuerySuggestionsConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
