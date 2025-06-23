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
using Amazon.WAF;
using Amazon.WAF.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Inserts or deletes <a>GeoMatchConstraint</a> objects in an <c>GeoMatchSet</c>. For
    /// each <c>GeoMatchConstraint</c> object, you specify the following values: 
    /// </para><ul><li><para>
    /// Whether to insert or delete the object from the array. If you want to change an <c>GeoMatchConstraint</c>
    /// object, you delete the existing object and add a new one.
    /// </para></li><li><para>
    /// The <c>Type</c>. The only valid value for <c>Type</c> is <c>Country</c>.
    /// </para></li><li><para>
    /// The <c>Value</c>, which is a two character code for the country to add to the <c>GeoMatchConstraint</c>
    /// object. Valid codes are listed in <a>GeoMatchConstraint$Value</a>.
    /// </para></li></ul><para>
    /// To create and configure an <c>GeoMatchSet</c>, perform the following steps:
    /// </para><ol><li><para>
    /// Submit a <a>CreateGeoMatchSet</a> request.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <c>ChangeToken</c>
    /// parameter of an <a>UpdateGeoMatchSet</a> request.
    /// </para></li><li><para>
    /// Submit an <c>UpdateGeoMatchSet</c> request to specify the country that you want AWS
    /// WAF to watch for.
    /// </para></li></ol><para>
    /// When you update an <c>GeoMatchSet</c>, you specify the country that you want to add
    /// and/or the country that you want to delete. If you want to change a country, you delete
    /// the existing country and add the new one.
    /// </para><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFGeoMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF UpdateGeoMatchSet API operation.", Operation = new[] {"UpdateGeoMatchSet"}, SelectReturnType = typeof(Amazon.WAF.Model.UpdateGeoMatchSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAF.Model.UpdateGeoMatchSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAF.Model.UpdateGeoMatchSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWAFGeoMatchSetCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
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
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter GeoMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <c>GeoMatchSetId</c> of the <a>GeoMatchSet</a> that you want to update. <c>GeoMatchSetId</c>
        /// is returned by <a>CreateGeoMatchSet</a> and by <a>ListGeoMatchSets</a>.</para>
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
        public System.String GeoMatchSetId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <c>GeoMatchSetUpdate</c> objects that you want to insert into or delete
        /// from an <a>GeoMatchSet</a>. For more information, see the applicable data types:</para><ul><li><para><a>GeoMatchSetUpdate</a>: Contains <c>Action</c> and <c>GeoMatchConstraint</c></para></li><li><para><a>GeoMatchConstraint</a>: Contains <c>Type</c> and <c>Value</c></para><para>You can have only one <c>Type</c> and <c>Value</c> per <c>GeoMatchConstraint</c>.
        /// To add multiple countries, include multiple <c>GeoMatchSetUpdate</c> objects in your
        /// request.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Updates")]
        public Amazon.WAF.Model.GeoMatchSetUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangeToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.UpdateGeoMatchSetResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.UpdateGeoMatchSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangeToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GeoMatchSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFGeoMatchSet (UpdateGeoMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.UpdateGeoMatchSetResponse, UpdateWAFGeoMatchSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeToken = this.ChangeToken;
            #if MODULAR
            if (this.ChangeToken == null && ParameterWasBound(nameof(this.ChangeToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GeoMatchSetId = this.GeoMatchSetId;
            #if MODULAR
            if (this.GeoMatchSetId == null && ParameterWasBound(nameof(this.GeoMatchSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter GeoMatchSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Update != null)
            {
                context.Update = new List<Amazon.WAF.Model.GeoMatchSetUpdate>(this.Update);
            }
            #if MODULAR
            if (this.Update == null && ParameterWasBound(nameof(this.Update)))
            {
                WriteWarning("You are passing $null as a value for parameter Update which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAF.Model.UpdateGeoMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.GeoMatchSetId != null)
            {
                request.GeoMatchSetId = cmdletContext.GeoMatchSetId;
            }
            if (cmdletContext.Update != null)
            {
                request.Updates = cmdletContext.Update;
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
        
        private Amazon.WAF.Model.UpdateGeoMatchSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.UpdateGeoMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "UpdateGeoMatchSet");
            try
            {
                return client.UpdateGeoMatchSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChangeToken { get; set; }
            public System.String GeoMatchSetId { get; set; }
            public List<Amazon.WAF.Model.GeoMatchSetUpdate> Update { get; set; }
            public System.Func<Amazon.WAF.Model.UpdateGeoMatchSetResponse, UpdateWAFGeoMatchSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangeToken;
        }
        
    }
}
