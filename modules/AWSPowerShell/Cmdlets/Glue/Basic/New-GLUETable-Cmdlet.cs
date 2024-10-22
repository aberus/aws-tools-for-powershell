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
    /// Creates a new table definition in the Data Catalog.
    /// </summary>
    [Cmdlet("New", "GLUETable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue CreateTable API operation.", Operation = new[] {"CreateTable"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateTableResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.CreateTableResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.CreateTableResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUETableCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog in which to create the <c>Table</c>. If none is supplied,
        /// the Amazon Web Services account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The catalog database in which to create the new table. For Hive compatibility, this
        /// name is entirely lowercase.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter IcebergInput_MetadataOperation
        /// <summary>
        /// <para>
        /// <para>A required metadata operation. Can only be set to <c>CREATE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_MetadataOperation")]
        [AWSConstantClassSource("Amazon.Glue.MetadataOperation")]
        public Amazon.Glue.MetadataOperation IcebergInput_MetadataOperation { get; set; }
        #endregion
        
        #region Parameter PartitionIndex
        /// <summary>
        /// <para>
        /// <para>A list of partition indexes, <c>PartitionIndex</c> structures, to create in the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PartitionIndexes")]
        public Amazon.Glue.Model.PartitionIndex[] PartitionIndex { get; set; }
        #endregion
        
        #region Parameter TableInput
        /// <summary>
        /// <para>
        /// <para>The <c>TableInput</c> object that defines the metadata table to create in the catalog.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Glue.Model.TableInput TableInput { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The ID of the transaction.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter IcebergInput_Version
        /// <summary>
        /// <para>
        /// <para>The table version for the Iceberg table. Defaults to 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenTableFormatInput_IcebergInput_Version")]
        public System.String IcebergInput_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateTableResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUETable (CreateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateTableResponse, NewGLUETableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CatalogId = this.CatalogId;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IcebergInput_MetadataOperation = this.IcebergInput_MetadataOperation;
            context.IcebergInput_Version = this.IcebergInput_Version;
            if (this.PartitionIndex != null)
            {
                context.PartitionIndex = new List<Amazon.Glue.Model.PartitionIndex>(this.PartitionIndex);
            }
            context.TableInput = this.TableInput;
            #if MODULAR
            if (this.TableInput == null && ParameterWasBound(nameof(this.TableInput)))
            {
                WriteWarning("You are passing $null as a value for parameter TableInput which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransactionId = this.TransactionId;
            
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
            var request = new Amazon.Glue.Model.CreateTableRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            
             // populate OpenTableFormatInput
            var requestOpenTableFormatInputIsNull = true;
            request.OpenTableFormatInput = new Amazon.Glue.Model.OpenTableFormatInput();
            Amazon.Glue.Model.IcebergInput requestOpenTableFormatInput_openTableFormatInput_IcebergInput = null;
            
             // populate IcebergInput
            var requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull = true;
            requestOpenTableFormatInput_openTableFormatInput_IcebergInput = new Amazon.Glue.Model.IcebergInput();
            Amazon.Glue.MetadataOperation requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation = null;
            if (cmdletContext.IcebergInput_MetadataOperation != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation = cmdletContext.IcebergInput_MetadataOperation;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput.MetadataOperation = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_MetadataOperation;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull = false;
            }
            System.String requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version = null;
            if (cmdletContext.IcebergInput_Version != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version = cmdletContext.IcebergInput_Version;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version != null)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput.Version = requestOpenTableFormatInput_openTableFormatInput_IcebergInput_icebergInput_Version;
                requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull = false;
            }
             // determine if requestOpenTableFormatInput_openTableFormatInput_IcebergInput should be set to null
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInputIsNull)
            {
                requestOpenTableFormatInput_openTableFormatInput_IcebergInput = null;
            }
            if (requestOpenTableFormatInput_openTableFormatInput_IcebergInput != null)
            {
                request.OpenTableFormatInput.IcebergInput = requestOpenTableFormatInput_openTableFormatInput_IcebergInput;
                requestOpenTableFormatInputIsNull = false;
            }
             // determine if request.OpenTableFormatInput should be set to null
            if (requestOpenTableFormatInputIsNull)
            {
                request.OpenTableFormatInput = null;
            }
            if (cmdletContext.PartitionIndex != null)
            {
                request.PartitionIndexes = cmdletContext.PartitionIndex;
            }
            if (cmdletContext.TableInput != null)
            {
                request.TableInput = cmdletContext.TableInput;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
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
        
        private Amazon.Glue.Model.CreateTableResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateTable");
            try
            {
                #if DESKTOP
                return client.CreateTable(request);
                #elif CORECLR
                return client.CreateTableAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String DatabaseName { get; set; }
            public Amazon.Glue.MetadataOperation IcebergInput_MetadataOperation { get; set; }
            public System.String IcebergInput_Version { get; set; }
            public List<Amazon.Glue.Model.PartitionIndex> PartitionIndex { get; set; }
            public Amazon.Glue.Model.TableInput TableInput { get; set; }
            public System.String TransactionId { get; set; }
            public System.Func<Amazon.Glue.Model.CreateTableResponse, NewGLUETableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
