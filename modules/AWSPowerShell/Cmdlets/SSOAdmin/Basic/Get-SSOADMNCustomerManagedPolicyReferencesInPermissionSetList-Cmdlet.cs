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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Lists all customer managed policies attached to a specified <a>PermissionSet</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SSOADMNCustomerManagedPolicyReferencesInPermissionSetList")]
    [OutputType("Amazon.SSOAdmin.Model.CustomerManagedPolicyReference")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin ListCustomerManagedPolicyReferencesInPermissionSet API operation.", Operation = new[] {"ListCustomerManagedPolicyReferencesInPermissionSet"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse))]
    [AWSCmdletOutput("Amazon.SSOAdmin.Model.CustomerManagedPolicyReference or Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse",
        "This cmdlet returns a collection of Amazon.SSOAdmin.Model.CustomerManagedPolicyReference objects.",
        "The service call response (type Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSSOADMNCustomerManagedPolicyReferencesInPermissionSetListCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services SSO instance under which the operation will be
        /// executed. </para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter PermissionSetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <code>PermissionSet</code>. </para>
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
        public System.String PermissionSetArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to display for the list call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token for the list API. Initially the value is null. Use the output
        /// of previous API calls to make subsequent calls.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomerManagedPolicyReferences'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse).
        /// Specifying the name of a property of type Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomerManagedPolicyReferences";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PermissionSetArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PermissionSetArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PermissionSetArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse, GetSSOADMNCustomerManagedPolicyReferencesInPermissionSetListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PermissionSetArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PermissionSetArn = this.PermissionSetArn;
            #if MODULAR
            if (this.PermissionSetArn == null && ParameterWasBound(nameof(this.PermissionSetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionSetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetRequest();
            
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PermissionSetArn != null)
            {
                request.PermissionSetArn = cmdletContext.PermissionSetArn;
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
        
        private Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "ListCustomerManagedPolicyReferencesInPermissionSet");
            try
            {
                #if DESKTOP
                return client.ListCustomerManagedPolicyReferencesInPermissionSet(request);
                #elif CORECLR
                return client.ListCustomerManagedPolicyReferencesInPermissionSetAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PermissionSetArn { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.ListCustomerManagedPolicyReferencesInPermissionSetResponse, GetSSOADMNCustomerManagedPolicyReferencesInPermissionSetListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomerManagedPolicyReferences;
        }
        
    }
}