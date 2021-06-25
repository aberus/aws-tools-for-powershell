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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Shows usage limits on a cluster. Results are filtered based on the combination of
    /// input usage limit identifier, cluster identifier, and feature type parameters:
    /// 
    ///  <ul><li><para>
    /// If usage limit identifier, cluster identifier, and feature type are not provided,
    /// then all usage limit objects for the current account in the current region are returned.
    /// </para></li><li><para>
    /// If usage limit identifier is provided, then the corresponding usage limit object is
    /// returned.
    /// </para></li><li><para>
    /// If cluster identifier is provided, then all usage limit objects for the specified
    /// cluster are returned.
    /// </para></li><li><para>
    /// If cluster identifier and feature type are provided, then all usage limit objects
    /// for the combination of cluster and feature are returned.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RSUsageLimit")]
    [OutputType("Amazon.Redshift.Model.UsageLimit")]
    [AWSCmdlet("Calls the Amazon Redshift DescribeUsageLimits API operation.", Operation = new[] {"DescribeUsageLimits"}, SelectReturnType = typeof(Amazon.Redshift.Model.DescribeUsageLimitsResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.UsageLimit or Amazon.Redshift.Model.DescribeUsageLimitsResponse",
        "This cmdlet returns a collection of Amazon.Redshift.Model.UsageLimit objects.",
        "The service call response (type Amazon.Redshift.Model.DescribeUsageLimitsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRSUsageLimitCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster for which you want to describe usage limits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter FeatureType
        /// <summary>
        /// <para>
        /// <para>The feature type for which you want to describe usage limits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.UsageLimitFeatureType")]
        public Amazon.Redshift.UsageLimitFeatureType FeatureType { get; set; }
        #endregion
        
        #region Parameter TagKey
        /// <summary>
        /// <para>
        /// <para>A tag key or keys for which you want to return all matching usage limit objects that
        /// are associated with the specified key or keys. For example, suppose that you have
        /// parameter groups that are tagged with keys called <code>owner</code> and <code>environment</code>.
        /// If you specify both of these tag keys in the request, Amazon Redshift returns a response
        /// with the usage limit objects have either or both of these tag keys associated with
        /// them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagKeys")]
        public System.String[] TagKey { get; set; }
        #endregion
        
        #region Parameter TagValue
        /// <summary>
        /// <para>
        /// <para>A tag value or values for which you want to return all matching usage limit objects
        /// that are associated with the specified tag value or values. For example, suppose that
        /// you have parameter groups that are tagged with values called <code>admin</code> and
        /// <code>test</code>. If you specify both of these tag values in the request, Amazon
        /// Redshift returns a response with the usage limit objects that have either or both
        /// of these tag values associated with them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagValues")]
        public System.String[] TagValue { get; set; }
        #endregion
        
        #region Parameter UsageLimitId
        /// <summary>
        /// <para>
        /// <para>The identifier of the usage limit to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UsageLimitId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the starting point to return a set of response
        /// records. When the results of a <a>DescribeUsageLimits</a> request exceed the value
        /// specified in <code>MaxRecords</code>, Amazon Web Services returns a value in the <code>Marker</code>
        /// field of the response. You can retrieve the next set of response records by providing
        /// the returned marker value in the <code>Marker</code> parameter and retrying the request.
        /// </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of response records to return in each call. If the number of remaining
        /// response records exceeds the specified <code>MaxRecords</code> value, a value is returned
        /// in a <code>marker</code> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned marker value. </para><para>Default: <code>100</code></para><para>Constraints: minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UsageLimits'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.DescribeUsageLimitsResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.DescribeUsageLimitsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UsageLimits";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.DescribeUsageLimitsResponse, GetRSUsageLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.FeatureType = this.FeatureType;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            if (this.TagKey != null)
            {
                context.TagKey = new List<System.String>(this.TagKey);
            }
            if (this.TagValue != null)
            {
                context.TagValue = new List<System.String>(this.TagValue);
            }
            context.UsageLimitId = this.UsageLimitId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Redshift.Model.DescribeUsageLimitsRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.FeatureType != null)
            {
                request.FeatureType = cmdletContext.FeatureType;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.TagKey != null)
            {
                request.TagKeys = cmdletContext.TagKey;
            }
            if (cmdletContext.TagValue != null)
            {
                request.TagValues = cmdletContext.TagValue;
            }
            if (cmdletContext.UsageLimitId != null)
            {
                request.UsageLimitId = cmdletContext.UsageLimitId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.Redshift.Model.DescribeUsageLimitsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DescribeUsageLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DescribeUsageLimits");
            try
            {
                #if DESKTOP
                return client.DescribeUsageLimits(request);
                #elif CORECLR
                return client.DescribeUsageLimitsAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public Amazon.Redshift.UsageLimitFeatureType FeatureType { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public List<System.String> TagKey { get; set; }
            public List<System.String> TagValue { get; set; }
            public System.String UsageLimitId { get; set; }
            public System.Func<Amazon.Redshift.Model.DescribeUsageLimitsResponse, GetRSUsageLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UsageLimits;
        }
        
    }
}
