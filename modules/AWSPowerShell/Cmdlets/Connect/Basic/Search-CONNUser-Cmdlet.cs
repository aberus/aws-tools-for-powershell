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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Searches users in an Amazon Connect instance, with optional filtering. 
    /// 
    ///  <note><para><c>AfterContactWorkTimeLimit</c> is returned in milliseconds. 
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "CONNUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.SearchUsersResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service SearchUsers API operation.", Operation = new[] {"SearchUsers"}, SelectReturnType = typeof(Amazon.Connect.Model.SearchUsersResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.SearchUsersResponse",
        "This cmdlet returns an Amazon.Connect.Model.SearchUsersResponse object containing multiple properties."
    )]
    public partial class SearchCONNUserCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SearchCriteria_AndCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>AND</c> condition.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AndConditions")]
        public Amazon.Connect.Model.UserSearchCriteria[] SearchCriteria_AndCondition { get; set; }
        #endregion
        
        #region Parameter TagFilter_AndCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>AND</c> condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_TagFilter_AndConditions")]
        public Amazon.Connect.Model.TagCondition[] TagFilter_AndCondition { get; set; }
        #endregion
        
        #region Parameter StringCondition_ComparisonType
        /// <summary>
        /// <para>
        /// <para>The type of comparison to be made when evaluating the string condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_StringCondition_ComparisonType")]
        [AWSConstantClassSource("Amazon.Connect.StringComparisonType")]
        public Amazon.Connect.StringComparisonType StringCondition_ComparisonType { get; set; }
        #endregion
        
        #region Parameter ListCondition_Condition
        /// <summary>
        /// <para>
        /// <para>A list of Condition objects which would be applied together with an AND condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_ListCondition_Conditions")]
        public Amazon.Connect.Model.Condition[] ListCondition_Condition { get; set; }
        #endregion
        
        #region Parameter StringCondition_FieldName
        /// <summary>
        /// <para>
        /// <para>The name of the field in the string condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_StringCondition_FieldName")]
        public System.String StringCondition_FieldName { get; set; }
        #endregion
        
        #region Parameter HierarchyGroupCondition_HierarchyGroupMatchType
        /// <summary>
        /// <para>
        /// <para>The type of hierarchy group match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_HierarchyGroupCondition_HierarchyGroupMatchType")]
        [AWSConstantClassSource("Amazon.Connect.HierarchyGroupMatchType")]
        public Amazon.Connect.HierarchyGroupMatchType HierarchyGroupCondition_HierarchyGroupMatchType { get; set; }
        #endregion
        
        #region Parameter SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType
        /// <summary>
        /// <para>
        /// <para>The type of hierarchy group match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SF_UA_HierarchyGroupCondition_HierarchyGroupMatchType")]
        [AWSConstantClassSource("Amazon.Connect.HierarchyGroupMatchType")]
        public Amazon.Connect.HierarchyGroupMatchType SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType { get; set; }
        #endregion
        
        #region Parameter SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType
        /// <summary>
        /// <para>
        /// <para>The type of hierarchy group match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SF_HierarchyGroupCondition_HierarchyGroupMatchType")]
        [AWSConstantClassSource("Amazon.Connect.HierarchyGroupMatchType")]
        public Amazon.Connect.HierarchyGroupMatchType SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>OR</c> condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_OrConditions")]
        public Amazon.Connect.Model.UserSearchCriteria[] SearchCriteria_OrCondition { get; set; }
        #endregion
        
        #region Parameter TagFilter_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>OR</c> condition.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_TagFilter_OrConditions")]
        public Amazon.Connect.Model.TagCondition[][] TagFilter_OrCondition { get; set; }
        #endregion
        
        #region Parameter UserAttributeFilter_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>OR</c> condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_UserAttributeFilter_OrConditions")]
        public Amazon.Connect.Model.AttributeAndCondition[] UserAttributeFilter_OrCondition { get; set; }
        #endregion
        
        #region Parameter AndCondition_TagCondition
        /// <summary>
        /// <para>
        /// <para>A leaf node condition which can be used to specify a tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_UserAttributeFilter_AndCondition_TagConditions")]
        public Amazon.Connect.Model.TagCondition[] AndCondition_TagCondition { get; set; }
        #endregion
        
        #region Parameter SearchFilter_TagFilter_TagCondition_TagKey
        /// <summary>
        /// <para>
        /// <para>The tag key in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SF_TagFilter_TagCondition_TagKey")]
        public System.String SearchFilter_TagFilter_TagCondition_TagKey { get; set; }
        #endregion
        
        #region Parameter TagCondition_TagKey
        /// <summary>
        /// <para>
        /// <para>The tag key in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_UserAttributeFilter_TagCondition_TagKey")]
        public System.String TagCondition_TagKey { get; set; }
        #endregion
        
        #region Parameter SearchFilter_TagFilter_TagCondition_TagValue
        /// <summary>
        /// <para>
        /// <para>The tag value in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SF_TagFilter_TagCondition_TagValue")]
        public System.String SearchFilter_TagFilter_TagCondition_TagValue { get; set; }
        #endregion
        
        #region Parameter TagCondition_TagValue
        /// <summary>
        /// <para>
        /// <para>The tag value in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_UserAttributeFilter_TagCondition_TagValue")]
        public System.String TagCondition_TagValue { get; set; }
        #endregion
        
        #region Parameter ListCondition_TargetListType
        /// <summary>
        /// <para>
        /// <para>The type of target list that will be used to filter the users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_ListCondition_TargetListType")]
        [AWSConstantClassSource("Amazon.Connect.TargetListType")]
        public Amazon.Connect.TargetListType ListCondition_TargetListType { get; set; }
        #endregion
        
        #region Parameter HierarchyGroupCondition_Value
        /// <summary>
        /// <para>
        /// <para>The value in the hierarchy group condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_HierarchyGroupCondition_Value")]
        public System.String HierarchyGroupCondition_Value { get; set; }
        #endregion
        
        #region Parameter StringCondition_Value
        /// <summary>
        /// <para>
        /// <para>The value of the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_StringCondition_Value")]
        public System.String StringCondition_Value { get; set; }
        #endregion
        
        #region Parameter SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value
        /// <summary>
        /// <para>
        /// <para>The value in the hierarchy group condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SF_UA_HierarchyGroupCondition_Value")]
        public System.String SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value { get; set; }
        #endregion
        
        #region Parameter SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value
        /// <summary>
        /// <para>
        /// <para>The value in the hierarchy group condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SF_HierarchyGroupCondition_Value")]
        public System.String SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SearchUsersResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.SearchUsersResponse will result in that property being returned.
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-CONNUser (SearchUsers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SearchUsersResponse, SearchCONNUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SearchCriteria_AndCondition != null)
            {
                context.SearchCriteria_AndCondition = new List<Amazon.Connect.Model.UserSearchCriteria>(this.SearchCriteria_AndCondition);
            }
            context.HierarchyGroupCondition_HierarchyGroupMatchType = this.HierarchyGroupCondition_HierarchyGroupMatchType;
            context.HierarchyGroupCondition_Value = this.HierarchyGroupCondition_Value;
            if (this.ListCondition_Condition != null)
            {
                context.ListCondition_Condition = new List<Amazon.Connect.Model.Condition>(this.ListCondition_Condition);
            }
            context.ListCondition_TargetListType = this.ListCondition_TargetListType;
            if (this.SearchCriteria_OrCondition != null)
            {
                context.SearchCriteria_OrCondition = new List<Amazon.Connect.Model.UserSearchCriteria>(this.SearchCriteria_OrCondition);
            }
            context.StringCondition_ComparisonType = this.StringCondition_ComparisonType;
            context.StringCondition_FieldName = this.StringCondition_FieldName;
            context.StringCondition_Value = this.StringCondition_Value;
            if (this.TagFilter_AndCondition != null)
            {
                context.TagFilter_AndCondition = new List<Amazon.Connect.Model.TagCondition>(this.TagFilter_AndCondition);
            }
            if (this.TagFilter_OrCondition != null)
            {
                context.TagFilter_OrCondition = new List<List<Amazon.Connect.Model.TagCondition>>();
                foreach (var innerList in this.TagFilter_OrCondition)
                {
                    context.TagFilter_OrCondition.Add(new List<Amazon.Connect.Model.TagCondition>(innerList));
                }
            }
            context.SearchFilter_TagFilter_TagCondition_TagKey = this.SearchFilter_TagFilter_TagCondition_TagKey;
            context.SearchFilter_TagFilter_TagCondition_TagValue = this.SearchFilter_TagFilter_TagCondition_TagValue;
            context.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType = this.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType;
            context.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value = this.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value;
            if (this.AndCondition_TagCondition != null)
            {
                context.AndCondition_TagCondition = new List<Amazon.Connect.Model.TagCondition>(this.AndCondition_TagCondition);
            }
            context.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType = this.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType;
            context.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value = this.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value;
            if (this.UserAttributeFilter_OrCondition != null)
            {
                context.UserAttributeFilter_OrCondition = new List<Amazon.Connect.Model.AttributeAndCondition>(this.UserAttributeFilter_OrCondition);
            }
            context.TagCondition_TagKey = this.TagCondition_TagKey;
            context.TagCondition_TagValue = this.TagCondition_TagValue;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Connect.Model.SearchUsersRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate SearchCriteria
            var requestSearchCriteriaIsNull = true;
            request.SearchCriteria = new Amazon.Connect.Model.UserSearchCriteria();
            List<Amazon.Connect.Model.UserSearchCriteria> requestSearchCriteria_searchCriteria_AndCondition = null;
            if (cmdletContext.SearchCriteria_AndCondition != null)
            {
                requestSearchCriteria_searchCriteria_AndCondition = cmdletContext.SearchCriteria_AndCondition;
            }
            if (requestSearchCriteria_searchCriteria_AndCondition != null)
            {
                request.SearchCriteria.AndConditions = requestSearchCriteria_searchCriteria_AndCondition;
                requestSearchCriteriaIsNull = false;
            }
            List<Amazon.Connect.Model.UserSearchCriteria> requestSearchCriteria_searchCriteria_OrCondition = null;
            if (cmdletContext.SearchCriteria_OrCondition != null)
            {
                requestSearchCriteria_searchCriteria_OrCondition = cmdletContext.SearchCriteria_OrCondition;
            }
            if (requestSearchCriteria_searchCriteria_OrCondition != null)
            {
                request.SearchCriteria.OrConditions = requestSearchCriteria_searchCriteria_OrCondition;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.HierarchyGroupCondition requestSearchCriteria_searchCriteria_HierarchyGroupCondition = null;
            
             // populate HierarchyGroupCondition
            var requestSearchCriteria_searchCriteria_HierarchyGroupConditionIsNull = true;
            requestSearchCriteria_searchCriteria_HierarchyGroupCondition = new Amazon.Connect.Model.HierarchyGroupCondition();
            Amazon.Connect.HierarchyGroupMatchType requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_HierarchyGroupMatchType = null;
            if (cmdletContext.HierarchyGroupCondition_HierarchyGroupMatchType != null)
            {
                requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_HierarchyGroupMatchType = cmdletContext.HierarchyGroupCondition_HierarchyGroupMatchType;
            }
            if (requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_HierarchyGroupMatchType != null)
            {
                requestSearchCriteria_searchCriteria_HierarchyGroupCondition.HierarchyGroupMatchType = requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_HierarchyGroupMatchType;
                requestSearchCriteria_searchCriteria_HierarchyGroupConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_Value = null;
            if (cmdletContext.HierarchyGroupCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_Value = cmdletContext.HierarchyGroupCondition_Value;
            }
            if (requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_HierarchyGroupCondition.Value = requestSearchCriteria_searchCriteria_HierarchyGroupCondition_hierarchyGroupCondition_Value;
                requestSearchCriteria_searchCriteria_HierarchyGroupConditionIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_HierarchyGroupCondition should be set to null
            if (requestSearchCriteria_searchCriteria_HierarchyGroupConditionIsNull)
            {
                requestSearchCriteria_searchCriteria_HierarchyGroupCondition = null;
            }
            if (requestSearchCriteria_searchCriteria_HierarchyGroupCondition != null)
            {
                request.SearchCriteria.HierarchyGroupCondition = requestSearchCriteria_searchCriteria_HierarchyGroupCondition;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.ListCondition requestSearchCriteria_searchCriteria_ListCondition = null;
            
             // populate ListCondition
            var requestSearchCriteria_searchCriteria_ListConditionIsNull = true;
            requestSearchCriteria_searchCriteria_ListCondition = new Amazon.Connect.Model.ListCondition();
            List<Amazon.Connect.Model.Condition> requestSearchCriteria_searchCriteria_ListCondition_listCondition_Condition = null;
            if (cmdletContext.ListCondition_Condition != null)
            {
                requestSearchCriteria_searchCriteria_ListCondition_listCondition_Condition = cmdletContext.ListCondition_Condition;
            }
            if (requestSearchCriteria_searchCriteria_ListCondition_listCondition_Condition != null)
            {
                requestSearchCriteria_searchCriteria_ListCondition.Conditions = requestSearchCriteria_searchCriteria_ListCondition_listCondition_Condition;
                requestSearchCriteria_searchCriteria_ListConditionIsNull = false;
            }
            Amazon.Connect.TargetListType requestSearchCriteria_searchCriteria_ListCondition_listCondition_TargetListType = null;
            if (cmdletContext.ListCondition_TargetListType != null)
            {
                requestSearchCriteria_searchCriteria_ListCondition_listCondition_TargetListType = cmdletContext.ListCondition_TargetListType;
            }
            if (requestSearchCriteria_searchCriteria_ListCondition_listCondition_TargetListType != null)
            {
                requestSearchCriteria_searchCriteria_ListCondition.TargetListType = requestSearchCriteria_searchCriteria_ListCondition_listCondition_TargetListType;
                requestSearchCriteria_searchCriteria_ListConditionIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_ListCondition should be set to null
            if (requestSearchCriteria_searchCriteria_ListConditionIsNull)
            {
                requestSearchCriteria_searchCriteria_ListCondition = null;
            }
            if (requestSearchCriteria_searchCriteria_ListCondition != null)
            {
                request.SearchCriteria.ListCondition = requestSearchCriteria_searchCriteria_ListCondition;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.StringCondition requestSearchCriteria_searchCriteria_StringCondition = null;
            
             // populate StringCondition
            var requestSearchCriteria_searchCriteria_StringConditionIsNull = true;
            requestSearchCriteria_searchCriteria_StringCondition = new Amazon.Connect.Model.StringCondition();
            Amazon.Connect.StringComparisonType requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType = null;
            if (cmdletContext.StringCondition_ComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType = cmdletContext.StringCondition_ComparisonType;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.ComparisonType = requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName = null;
            if (cmdletContext.StringCondition_FieldName != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName = cmdletContext.StringCondition_FieldName;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.FieldName = requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value = null;
            if (cmdletContext.StringCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value = cmdletContext.StringCondition_Value;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.Value = requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_StringCondition should be set to null
            if (requestSearchCriteria_searchCriteria_StringConditionIsNull)
            {
                requestSearchCriteria_searchCriteria_StringCondition = null;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition != null)
            {
                request.SearchCriteria.StringCondition = requestSearchCriteria_searchCriteria_StringCondition;
                requestSearchCriteriaIsNull = false;
            }
             // determine if request.SearchCriteria should be set to null
            if (requestSearchCriteriaIsNull)
            {
                request.SearchCriteria = null;
            }
            
             // populate SearchFilter
            var requestSearchFilterIsNull = true;
            request.SearchFilter = new Amazon.Connect.Model.UserSearchFilter();
            Amazon.Connect.Model.ControlPlaneTagFilter requestSearchFilter_searchFilter_TagFilter = null;
            
             // populate TagFilter
            var requestSearchFilter_searchFilter_TagFilterIsNull = true;
            requestSearchFilter_searchFilter_TagFilter = new Amazon.Connect.Model.ControlPlaneTagFilter();
            List<Amazon.Connect.Model.TagCondition> requestSearchFilter_searchFilter_TagFilter_tagFilter_AndCondition = null;
            if (cmdletContext.TagFilter_AndCondition != null)
            {
                requestSearchFilter_searchFilter_TagFilter_tagFilter_AndCondition = cmdletContext.TagFilter_AndCondition;
            }
            if (requestSearchFilter_searchFilter_TagFilter_tagFilter_AndCondition != null)
            {
                requestSearchFilter_searchFilter_TagFilter.AndConditions = requestSearchFilter_searchFilter_TagFilter_tagFilter_AndCondition;
                requestSearchFilter_searchFilter_TagFilterIsNull = false;
            }
            List<List<Amazon.Connect.Model.TagCondition>> requestSearchFilter_searchFilter_TagFilter_tagFilter_OrCondition = null;
            if (cmdletContext.TagFilter_OrCondition != null)
            {
                requestSearchFilter_searchFilter_TagFilter_tagFilter_OrCondition = cmdletContext.TagFilter_OrCondition;
            }
            if (requestSearchFilter_searchFilter_TagFilter_tagFilter_OrCondition != null)
            {
                requestSearchFilter_searchFilter_TagFilter.OrConditions = requestSearchFilter_searchFilter_TagFilter_tagFilter_OrCondition;
                requestSearchFilter_searchFilter_TagFilterIsNull = false;
            }
            Amazon.Connect.Model.TagCondition requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition = null;
            
             // populate TagCondition
            var requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagConditionIsNull = true;
            requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition = new Amazon.Connect.Model.TagCondition();
            System.String requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagKey = null;
            if (cmdletContext.SearchFilter_TagFilter_TagCondition_TagKey != null)
            {
                requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagKey = cmdletContext.SearchFilter_TagFilter_TagCondition_TagKey;
            }
            if (requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagKey != null)
            {
                requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition.TagKey = requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagKey;
                requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagConditionIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagValue = null;
            if (cmdletContext.SearchFilter_TagFilter_TagCondition_TagValue != null)
            {
                requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagValue = cmdletContext.SearchFilter_TagFilter_TagCondition_TagValue;
            }
            if (requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagValue != null)
            {
                requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition.TagValue = requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition_searchFilter_TagFilter_TagCondition_TagValue;
                requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagConditionIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition should be set to null
            if (requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagConditionIsNull)
            {
                requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition = null;
            }
            if (requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition != null)
            {
                requestSearchFilter_searchFilter_TagFilter.TagCondition = requestSearchFilter_searchFilter_TagFilter_searchFilter_TagFilter_TagCondition;
                requestSearchFilter_searchFilter_TagFilterIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_TagFilter should be set to null
            if (requestSearchFilter_searchFilter_TagFilterIsNull)
            {
                requestSearchFilter_searchFilter_TagFilter = null;
            }
            if (requestSearchFilter_searchFilter_TagFilter != null)
            {
                request.SearchFilter.TagFilter = requestSearchFilter_searchFilter_TagFilter;
                requestSearchFilterIsNull = false;
            }
            Amazon.Connect.Model.ControlPlaneUserAttributeFilter requestSearchFilter_searchFilter_UserAttributeFilter = null;
            
             // populate UserAttributeFilter
            var requestSearchFilter_searchFilter_UserAttributeFilterIsNull = true;
            requestSearchFilter_searchFilter_UserAttributeFilter = new Amazon.Connect.Model.ControlPlaneUserAttributeFilter();
            List<Amazon.Connect.Model.AttributeAndCondition> requestSearchFilter_searchFilter_UserAttributeFilter_userAttributeFilter_OrCondition = null;
            if (cmdletContext.UserAttributeFilter_OrCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_userAttributeFilter_OrCondition = cmdletContext.UserAttributeFilter_OrCondition;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_userAttributeFilter_OrCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter.OrConditions = requestSearchFilter_searchFilter_UserAttributeFilter_userAttributeFilter_OrCondition;
                requestSearchFilter_searchFilter_UserAttributeFilterIsNull = false;
            }
            Amazon.Connect.Model.AttributeAndCondition requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition = null;
            
             // populate AndCondition
            var requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndConditionIsNull = true;
            requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition = new Amazon.Connect.Model.AttributeAndCondition();
            List<Amazon.Connect.Model.TagCondition> requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_andCondition_TagCondition = null;
            if (cmdletContext.AndCondition_TagCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_andCondition_TagCondition = cmdletContext.AndCondition_TagCondition;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_andCondition_TagCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition.TagConditions = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_andCondition_TagCondition;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndConditionIsNull = false;
            }
            Amazon.Connect.Model.HierarchyGroupCondition requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition = null;
            
             // populate HierarchyGroupCondition
            var requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupConditionIsNull = true;
            requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition = new Amazon.Connect.Model.HierarchyGroupCondition();
            Amazon.Connect.HierarchyGroupMatchType requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType = null;
            if (cmdletContext.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType = cmdletContext.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition.HierarchyGroupMatchType = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupConditionIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value = null;
            if (cmdletContext.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value = cmdletContext.SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition.Value = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupConditionIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition should be set to null
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupConditionIsNull)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition = null;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition.HierarchyGroupCondition = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition_searchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndConditionIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition should be set to null
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndConditionIsNull)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition = null;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter.AndCondition = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_AndCondition;
                requestSearchFilter_searchFilter_UserAttributeFilterIsNull = false;
            }
            Amazon.Connect.Model.HierarchyGroupCondition requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition = null;
            
             // populate HierarchyGroupCondition
            var requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupConditionIsNull = true;
            requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition = new Amazon.Connect.Model.HierarchyGroupCondition();
            Amazon.Connect.HierarchyGroupMatchType requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType = null;
            if (cmdletContext.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType = cmdletContext.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition.HierarchyGroupMatchType = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupConditionIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_Value = null;
            if (cmdletContext.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_Value = cmdletContext.SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_Value != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition.Value = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition_searchFilter_UserAttributeFilter_HierarchyGroupCondition_Value;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupConditionIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition should be set to null
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupConditionIsNull)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition = null;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter.HierarchyGroupCondition = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_HierarchyGroupCondition;
                requestSearchFilter_searchFilter_UserAttributeFilterIsNull = false;
            }
            Amazon.Connect.Model.TagCondition requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition = null;
            
             // populate TagCondition
            var requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagConditionIsNull = true;
            requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition = new Amazon.Connect.Model.TagCondition();
            System.String requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagKey = null;
            if (cmdletContext.TagCondition_TagKey != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagKey = cmdletContext.TagCondition_TagKey;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagKey != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition.TagKey = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagKey;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagConditionIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagValue = null;
            if (cmdletContext.TagCondition_TagValue != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagValue = cmdletContext.TagCondition_TagValue;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagValue != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition.TagValue = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition_tagCondition_TagValue;
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagConditionIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition should be set to null
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagConditionIsNull)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition = null;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition != null)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter.TagCondition = requestSearchFilter_searchFilter_UserAttributeFilter_searchFilter_UserAttributeFilter_TagCondition;
                requestSearchFilter_searchFilter_UserAttributeFilterIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_UserAttributeFilter should be set to null
            if (requestSearchFilter_searchFilter_UserAttributeFilterIsNull)
            {
                requestSearchFilter_searchFilter_UserAttributeFilter = null;
            }
            if (requestSearchFilter_searchFilter_UserAttributeFilter != null)
            {
                request.SearchFilter.UserAttributeFilter = requestSearchFilter_searchFilter_UserAttributeFilter;
                requestSearchFilterIsNull = false;
            }
             // determine if request.SearchFilter should be set to null
            if (requestSearchFilterIsNull)
            {
                request.SearchFilter = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Connect.Model.SearchUsersResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SearchUsersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SearchUsers");
            try
            {
                return client.SearchUsersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.Connect.Model.UserSearchCriteria> SearchCriteria_AndCondition { get; set; }
            public Amazon.Connect.HierarchyGroupMatchType HierarchyGroupCondition_HierarchyGroupMatchType { get; set; }
            public System.String HierarchyGroupCondition_Value { get; set; }
            public List<Amazon.Connect.Model.Condition> ListCondition_Condition { get; set; }
            public Amazon.Connect.TargetListType ListCondition_TargetListType { get; set; }
            public List<Amazon.Connect.Model.UserSearchCriteria> SearchCriteria_OrCondition { get; set; }
            public Amazon.Connect.StringComparisonType StringCondition_ComparisonType { get; set; }
            public System.String StringCondition_FieldName { get; set; }
            public System.String StringCondition_Value { get; set; }
            public List<Amazon.Connect.Model.TagCondition> TagFilter_AndCondition { get; set; }
            public List<List<Amazon.Connect.Model.TagCondition>> TagFilter_OrCondition { get; set; }
            public System.String SearchFilter_TagFilter_TagCondition_TagKey { get; set; }
            public System.String SearchFilter_TagFilter_TagCondition_TagValue { get; set; }
            public Amazon.Connect.HierarchyGroupMatchType SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType { get; set; }
            public System.String SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value { get; set; }
            public List<Amazon.Connect.Model.TagCondition> AndCondition_TagCondition { get; set; }
            public Amazon.Connect.HierarchyGroupMatchType SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType { get; set; }
            public System.String SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value { get; set; }
            public List<Amazon.Connect.Model.AttributeAndCondition> UserAttributeFilter_OrCondition { get; set; }
            public System.String TagCondition_TagKey { get; set; }
            public System.String TagCondition_TagValue { get; set; }
            public System.Func<Amazon.Connect.Model.SearchUsersResponse, SearchCONNUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
