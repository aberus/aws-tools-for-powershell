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
    /// Describes the status of the assignment deletion request.
    /// </summary>
    [Cmdlet("Get", "SSOADMNAccountAssignmentDeletionStatus")]
    [OutputType("Amazon.SSOAdmin.Model.AccountAssignmentOperationStatus")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin DescribeAccountAssignmentDeletionStatus API operation.", Operation = new[] {"DescribeAccountAssignmentDeletionStatus"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse))]
    [AWSCmdletOutput("Amazon.SSOAdmin.Model.AccountAssignmentOperationStatus or Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse",
        "This cmdlet returns an Amazon.SSOAdmin.Model.AccountAssignmentOperationStatus object.",
        "The service call response (type Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSSOADMNAccountAssignmentDeletionStatusCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        #region Parameter AccountAssignmentDeletionRequestId
        /// <summary>
        /// <para>
        /// <para>The identifier that is used to track the request operation progress.</para>
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
        public System.String AccountAssignmentDeletionRequestId { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SSO instance under which the operation will be executed. For more information
        /// about ARNs, see <a href="/general/latest/gr/aws-arns-and-namespaces.html">Amazon Resource
        /// Names (ARNs) and Amazon Web Services Service Namespaces</a> in the <i>Amazon Web Services
        /// General Reference</i>.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountAssignmentDeletionStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse).
        /// Specifying the name of a property of type Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountAssignmentDeletionStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountAssignmentDeletionRequestId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountAssignmentDeletionRequestId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountAssignmentDeletionRequestId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse, GetSSOADMNAccountAssignmentDeletionStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountAssignmentDeletionRequestId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountAssignmentDeletionRequestId = this.AccountAssignmentDeletionRequestId;
            #if MODULAR
            if (this.AccountAssignmentDeletionRequestId == null && ParameterWasBound(nameof(this.AccountAssignmentDeletionRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountAssignmentDeletionRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusRequest();
            
            if (cmdletContext.AccountAssignmentDeletionRequestId != null)
            {
                request.AccountAssignmentDeletionRequestId = cmdletContext.AccountAssignmentDeletionRequestId;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
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
        
        private Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "DescribeAccountAssignmentDeletionStatus");
            try
            {
                #if DESKTOP
                return client.DescribeAccountAssignmentDeletionStatus(request);
                #elif CORECLR
                return client.DescribeAccountAssignmentDeletionStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountAssignmentDeletionRequestId { get; set; }
            public System.String InstanceArn { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.DescribeAccountAssignmentDeletionStatusResponse, GetSSOADMNAccountAssignmentDeletionStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountAssignmentDeletionStatus;
        }
        
    }
}
