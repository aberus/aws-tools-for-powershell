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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates a machine learning (ML) project that is created from a template that sets
    /// up an ML pipeline from training to deploying an approved model.
    /// 
    ///  <note><para>
    /// You must not update a project that is in use. If you update the <c>ServiceCatalogProvisioningUpdateDetails</c>
    /// of a project that is active or being created, or updated, you may lose resources already
    /// created by the project.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SMProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateProject API operation.", Operation = new[] {"UpdateProject"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateProjectResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateProjectResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateProjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMProjectCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProjectDescription
        /// <summary>
        /// <para>
        /// <para>The description for the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectDescription { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter ServiceCatalogProvisioningUpdateDetails_ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The ID of the provisioning artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceCatalogProvisioningUpdateDetails_ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter
        /// <summary>
        /// <para>
        /// <para>A list of key value pairs that you specify when you provision a product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceCatalogProvisioningUpdateDetails_ProvisioningParameters")]
        public Amazon.SageMaker.Model.ProvisioningParameter[] ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>. In addition, the project must have tag update constraints
        /// set in order to include this parameter in the request. For more information, see <a href="https://docs.aws.amazon.com/servicecatalog/latest/adminguide/constraints-resourceupdate.html">Amazon
        /// Web Services Service Catalog Tag Update Constraints</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateProvidersToUpdate
        /// <summary>
        /// <para>
        /// <para> The template providers to update in the project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.UpdateTemplateProvider[] TemplateProvidersToUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProjectArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateProjectResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProjectArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMProject (UpdateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateProjectResponse, UpdateSMProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ProjectDescription = this.ProjectDescription;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceCatalogProvisioningUpdateDetails_ProvisioningArtifactId = this.ServiceCatalogProvisioningUpdateDetails_ProvisioningArtifactId;
            if (this.ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter != null)
            {
                context.ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter = new List<Amazon.SageMaker.Model.ProvisioningParameter>(this.ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            if (this.TemplateProvidersToUpdate != null)
            {
                context.TemplateProvidersToUpdate = new List<Amazon.SageMaker.Model.UpdateTemplateProvider>(this.TemplateProvidersToUpdate);
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
            var request = new Amazon.SageMaker.Model.UpdateProjectRequest();
            
            if (cmdletContext.ProjectDescription != null)
            {
                request.ProjectDescription = cmdletContext.ProjectDescription;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            
             // populate ServiceCatalogProvisioningUpdateDetails
            var requestServiceCatalogProvisioningUpdateDetailsIsNull = true;
            request.ServiceCatalogProvisioningUpdateDetails = new Amazon.SageMaker.Model.ServiceCatalogProvisioningUpdateDetails();
            System.String requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningArtifactId = null;
            if (cmdletContext.ServiceCatalogProvisioningUpdateDetails_ProvisioningArtifactId != null)
            {
                requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningArtifactId = cmdletContext.ServiceCatalogProvisioningUpdateDetails_ProvisioningArtifactId;
            }
            if (requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningArtifactId != null)
            {
                request.ServiceCatalogProvisioningUpdateDetails.ProvisioningArtifactId = requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningArtifactId;
                requestServiceCatalogProvisioningUpdateDetailsIsNull = false;
            }
            List<Amazon.SageMaker.Model.ProvisioningParameter> requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningParameter = null;
            if (cmdletContext.ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter != null)
            {
                requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningParameter = cmdletContext.ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter;
            }
            if (requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningParameter != null)
            {
                request.ServiceCatalogProvisioningUpdateDetails.ProvisioningParameters = requestServiceCatalogProvisioningUpdateDetails_serviceCatalogProvisioningUpdateDetails_ProvisioningParameter;
                requestServiceCatalogProvisioningUpdateDetailsIsNull = false;
            }
             // determine if request.ServiceCatalogProvisioningUpdateDetails should be set to null
            if (requestServiceCatalogProvisioningUpdateDetailsIsNull)
            {
                request.ServiceCatalogProvisioningUpdateDetails = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateProvidersToUpdate != null)
            {
                request.TemplateProvidersToUpdate = cmdletContext.TemplateProvidersToUpdate;
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
        
        private Amazon.SageMaker.Model.UpdateProjectResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateProject");
            try
            {
                #if DESKTOP
                return client.UpdateProject(request);
                #elif CORECLR
                return client.UpdateProjectAsync(request).GetAwaiter().GetResult();
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
            public System.String ProjectDescription { get; set; }
            public System.String ProjectName { get; set; }
            public System.String ServiceCatalogProvisioningUpdateDetails_ProvisioningArtifactId { get; set; }
            public List<Amazon.SageMaker.Model.ProvisioningParameter> ServiceCatalogProvisioningUpdateDetails_ProvisioningParameter { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public List<Amazon.SageMaker.Model.UpdateTemplateProvider> TemplateProvidersToUpdate { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateProjectResponse, UpdateSMProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProjectArn;
        }
        
    }
}
