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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Gets the file system association information. This operation is only supported for
    /// FSx File Gateways.
    /// </summary>
    [Cmdlet("Get", "SGSGFileSystemAssociation")]
    [OutputType("Amazon.StorageGateway.Model.FileSystemAssociationInfo")]
    [AWSCmdlet("Calls the AWS Storage Gateway DescribeFileSystemAssociations API operation.", Operation = new[] {"DescribeFileSystemAssociations"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.FileSystemAssociationInfo or Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse",
        "This cmdlet returns a collection of Amazon.StorageGateway.Model.FileSystemAssociationInfo objects.",
        "The service call response (type Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSGSGFileSystemAssociationCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter FileSystemAssociationARNList
        /// <summary>
        /// <para>
        /// <para>An array containing the Amazon Resource Name (ARN) of each file system association
        /// to be described.</para>
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
        public System.String[] FileSystemAssociationARNList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileSystemAssociationInfoList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileSystemAssociationInfoList";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse, GetSGSGFileSystemAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FileSystemAssociationARNList != null)
            {
                context.FileSystemAssociationARNList = new List<System.String>(this.FileSystemAssociationARNList);
            }
            #if MODULAR
            if (this.FileSystemAssociationARNList == null && ParameterWasBound(nameof(this.FileSystemAssociationARNList)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemAssociationARNList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.DescribeFileSystemAssociationsRequest();
            
            if (cmdletContext.FileSystemAssociationARNList != null)
            {
                request.FileSystemAssociationARNList = cmdletContext.FileSystemAssociationARNList;
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
        
        private Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.DescribeFileSystemAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "DescribeFileSystemAssociations");
            try
            {
                #if DESKTOP
                return client.DescribeFileSystemAssociations(request);
                #elif CORECLR
                return client.DescribeFileSystemAssociationsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> FileSystemAssociationARNList { get; set; }
            public System.Func<Amazon.StorageGateway.Model.DescribeFileSystemAssociationsResponse, GetSGSGFileSystemAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystemAssociationInfoList;
        }
        
    }
}
