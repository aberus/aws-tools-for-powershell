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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Checks the status of continuous backups and point in time recovery on the specified
    /// table. Continuous backups are <c>ENABLED</c> on all tables at table creation. If point
    /// in time recovery is enabled, <c>PointInTimeRecoveryStatus</c> will be set to ENABLED.
    /// 
    ///  
    /// <para>
    ///  After continuous backups and point in time recovery are enabled, you can restore
    /// to any point in time within <c>EarliestRestorableDateTime</c> and <c>LatestRestorableDateTime</c>.
    /// 
    /// </para><para><c>LatestRestorableDateTime</c> is typically 5 minutes before the current time. You
    /// can restore your table to any point in time during the last 35 days. 
    /// </para><para>
    /// You can call <c>DescribeContinuousBackups</c> at a maximum rate of 10 times per second.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBContinuousBackup")]
    [OutputType("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB DescribeContinuousBackups API operation.", Operation = new[] {"DescribeContinuousBackups"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription or Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.ContinuousBackupsDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDDBContinuousBackupCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>Name of the table for which the customer wants to check the continuous backups and
        /// point in time recovery settings.</para><para>You can also provide the Amazon Resource Name (ARN) of the table in this parameter.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContinuousBackupsDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContinuousBackupsDescription";
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
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse, GetDDBContinuousBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.DynamoDBv2.Model.DescribeContinuousBackupsRequest();
            
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
        
        private Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.DescribeContinuousBackupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DescribeContinuousBackups");
            try
            {
                #if DESKTOP
                return client.DescribeContinuousBackups(request);
                #elif CORECLR
                return client.DescribeContinuousBackupsAsync(request).GetAwaiter().GetResult();
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
            public System.String TableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse, GetDDBContinuousBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContinuousBackupsDescription;
        }
        
    }
}
