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
using Amazon.TimestreamWrite;
using Amazon.TimestreamWrite.Model;

namespace Amazon.PowerShell.Cmdlets.TSW
{
    /// <summary>
    /// Returns information about the table, including the table name, database name, retention
    /// duration of the memory store and the magnetic store. <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/ts-limits.html">Service
    /// quotas apply</a>. See <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/code-samples.describe-table.html">code
    /// sample</a> for details.
    /// </summary>
    [Cmdlet("Get", "TSWTable")]
    [OutputType("Amazon.TimestreamWrite.Model.Table")]
    [AWSCmdlet("Calls the Amazon Timestream Write DescribeTable API operation.", Operation = new[] {"DescribeTable"}, SelectReturnType = typeof(Amazon.TimestreamWrite.Model.DescribeTableResponse))]
    [AWSCmdletOutput("Amazon.TimestreamWrite.Model.Table or Amazon.TimestreamWrite.Model.DescribeTableResponse",
        "This cmdlet returns an Amazon.TimestreamWrite.Model.Table object.",
        "The service call response (type Amazon.TimestreamWrite.Model.DescribeTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTSWTableCmdlet : AmazonTimestreamWriteClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the Timestream database.</para>
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
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Timestream table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Table'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamWrite.Model.DescribeTableResponse).
        /// Specifying the name of a property of type Amazon.TimestreamWrite.Model.DescribeTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Table";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamWrite.Model.DescribeTableResponse, GetTSWTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TimestreamWrite.Model.DescribeTableRequest();
            
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.TimestreamWrite.Model.DescribeTableResponse CallAWSServiceOperation(IAmazonTimestreamWrite client, Amazon.TimestreamWrite.Model.DescribeTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Write", "DescribeTable");
            try
            {
                #if DESKTOP
                return client.DescribeTable(request);
                #elif CORECLR
                return client.DescribeTableAsync(request).GetAwaiter().GetResult();
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
            public System.String DatabaseName { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.TimestreamWrite.Model.DescribeTableResponse, GetTSWTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Table;
        }
        
    }
}
