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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Updates a workgroup with the specified configuration settings.
    /// </summary>
    [Cmdlet("Update", "RSSWorkgroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.Workgroup")]
    [AWSCmdlet("Calls the Amazon Redshift Serverless UpdateWorkgroup API operation.", Operation = new[] {"UpdateWorkgroup"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.Workgroup or Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.Workgroup object.",
        "The service call response (type Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateRSSWorkgroupCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        #region Parameter BaseCapacity
        /// <summary>
        /// <para>
        /// <para>The new base data warehouse capacity in Redshift Processing Units (RPUs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BaseCapacity { get; set; }
        #endregion
        
        #region Parameter ConfigParameter
        /// <summary>
        /// <para>
        /// <para>An array of parameters to set for advanced control over a database. The options are
        /// <code>datestyle</code>, <code>enable_user_activity_logging</code>, <code>query_group</code>,
        /// <code>search_path</code>, and <code>max_query_execution_time</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigParameters")]
        public Amazon.RedshiftServerless.Model.ConfigParameter[] ConfigParameter { get; set; }
        #endregion
        
        #region Parameter EnhancedVpcRouting
        /// <summary>
        /// <para>
        /// <para>The value that specifies whether to turn on enhanced virtual private cloud (VPC) routing,
        /// which forces Amazon Redshift Serverless to route traffic through your VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnhancedVpcRouting { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether the workgroup can be accessible from a public network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An array of security group IDs to associate with the workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>An array of VPC subnet IDs to associate with the workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The name of the workgroup to update.</para>
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
        public System.String WorkgroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workgroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workgroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkgroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkgroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkgroupName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkgroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RSSWorkgroup (UpdateWorkgroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse, UpdateRSSWorkgroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkgroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BaseCapacity = this.BaseCapacity;
            if (this.ConfigParameter != null)
            {
                context.ConfigParameter = new List<Amazon.RedshiftServerless.Model.ConfigParameter>(this.ConfigParameter);
            }
            context.EnhancedVpcRouting = this.EnhancedVpcRouting;
            context.PubliclyAccessible = this.PubliclyAccessible;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            context.WorkgroupName = this.WorkgroupName;
            #if MODULAR
            if (this.WorkgroupName == null && ParameterWasBound(nameof(this.WorkgroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkgroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RedshiftServerless.Model.UpdateWorkgroupRequest();
            
            if (cmdletContext.BaseCapacity != null)
            {
                request.BaseCapacity = cmdletContext.BaseCapacity.Value;
            }
            if (cmdletContext.ConfigParameter != null)
            {
                request.ConfigParameters = cmdletContext.ConfigParameter;
            }
            if (cmdletContext.EnhancedVpcRouting != null)
            {
                request.EnhancedVpcRouting = cmdletContext.EnhancedVpcRouting.Value;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.WorkgroupName != null)
            {
                request.WorkgroupName = cmdletContext.WorkgroupName;
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
        
        private Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.UpdateWorkgroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift Serverless", "UpdateWorkgroup");
            try
            {
                #if DESKTOP
                return client.UpdateWorkgroup(request);
                #elif CORECLR
                return client.UpdateWorkgroupAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? BaseCapacity { get; set; }
            public List<Amazon.RedshiftServerless.Model.ConfigParameter> ConfigParameter { get; set; }
            public System.Boolean? EnhancedVpcRouting { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> SubnetId { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse, UpdateRSSWorkgroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workgroup;
        }
        
    }
}