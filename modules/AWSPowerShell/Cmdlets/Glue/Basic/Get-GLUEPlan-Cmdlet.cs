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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Gets code to perform a specified mapping.
    /// </summary>
    [Cmdlet("Get", "GLUEPlan")]
    [OutputType("Amazon.Glue.Model.GetPlanResponse")]
    [AWSCmdlet("Calls the AWS Glue GetPlan API operation.", Operation = new[] {"GetPlan"}, SelectReturnType = typeof(Amazon.Glue.Model.GetPlanResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.GetPlanResponse",
        "This cmdlet returns an Amazon.Glue.Model.GetPlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEPlanCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalPlanOptionsMap
        /// <summary>
        /// <para>
        /// <para>A map to hold additional optional key-value parameters.</para><para>Currently, these key-value pairs are supported:</para><ul><li><para><code>inferSchema</code>  —  Specifies whether to set <code>inferSchema</code> to
        /// true or false for the default script generated by an Glue job. For example, to set
        /// <code>inferSchema</code> to true, pass the following key value pair:</para><para><code>--additional-plan-options-map '{"inferSchema":"true"}'</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AdditionalPlanOptionsMap { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The programming language of the code to perform the mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.Language")]
        public Amazon.Glue.Language Language { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The parameters for the mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.Location Location { get; set; }
        #endregion
        
        #region Parameter Mapping
        /// <summary>
        /// <para>
        /// <para>The list of mappings from a source table to target tables.</para>
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
        public Amazon.Glue.Model.MappingEntry[] Mapping { get; set; }
        #endregion
        
        #region Parameter Sink
        /// <summary>
        /// <para>
        /// <para>The target tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sinks")]
        public Amazon.Glue.Model.CatalogEntry[] Sink { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source table.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Glue.Model.CatalogEntry Source { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetPlanResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Source parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Source' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Source' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetPlanResponse, GetGLUEPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Source;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalPlanOptionsMap != null)
            {
                context.AdditionalPlanOptionsMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalPlanOptionsMap.Keys)
                {
                    context.AdditionalPlanOptionsMap.Add((String)hashKey, (String)(this.AdditionalPlanOptionsMap[hashKey]));
                }
            }
            context.Language = this.Language;
            context.Location = this.Location;
            if (this.Mapping != null)
            {
                context.Mapping = new List<Amazon.Glue.Model.MappingEntry>(this.Mapping);
            }
            #if MODULAR
            if (this.Mapping == null && ParameterWasBound(nameof(this.Mapping)))
            {
                WriteWarning("You are passing $null as a value for parameter Mapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Sink != null)
            {
                context.Sink = new List<Amazon.Glue.Model.CatalogEntry>(this.Sink);
            }
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.GetPlanRequest();
            
            if (cmdletContext.AdditionalPlanOptionsMap != null)
            {
                request.AdditionalPlanOptionsMap = cmdletContext.AdditionalPlanOptionsMap;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.Mapping != null)
            {
                request.Mapping = cmdletContext.Mapping;
            }
            if (cmdletContext.Sink != null)
            {
                request.Sinks = cmdletContext.Sink;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
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
        
        private Amazon.Glue.Model.GetPlanResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetPlan");
            try
            {
                #if DESKTOP
                return client.GetPlan(request);
                #elif CORECLR
                return client.GetPlanAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AdditionalPlanOptionsMap { get; set; }
            public Amazon.Glue.Language Language { get; set; }
            public Amazon.Glue.Model.Location Location { get; set; }
            public List<Amazon.Glue.Model.MappingEntry> Mapping { get; set; }
            public List<Amazon.Glue.Model.CatalogEntry> Sink { get; set; }
            public Amazon.Glue.Model.CatalogEntry Source { get; set; }
            public System.Func<Amazon.Glue.Model.GetPlanResponse, GetGLUEPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
