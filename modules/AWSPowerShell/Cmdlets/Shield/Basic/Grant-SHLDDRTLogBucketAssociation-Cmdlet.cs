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
using Amazon.Shield;
using Amazon.Shield.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Authorizes the Shield Response Team (SRT) to access the specified Amazon S3 bucket
    /// containing log data such as Application Load Balancer access logs, CloudFront logs,
    /// or logs from third party sources. You can associate up to 10 Amazon S3 buckets with
    /// your subscription.
    /// 
    ///  
    /// <para>
    /// To use the services of the SRT and make an <c>AssociateDRTLogBucket</c> request, you
    /// must be subscribed to the <a href="http://aws.amazon.com/premiumsupport/business-support/">Business
    /// Support plan</a> or the <a href="http://aws.amazon.com/premiumsupport/enterprise-support/">Enterprise
    /// Support plan</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Grant", "SHLDDRTLogBucketAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Shield AssociateDRTLogBucket API operation.", Operation = new[] {"AssociateDRTLogBucket"}, SelectReturnType = typeof(Amazon.Shield.Model.AssociateDRTLogBucketResponse))]
    [AWSCmdletOutput("None or Amazon.Shield.Model.AssociateDRTLogBucketResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Shield.Model.AssociateDRTLogBucketResponse) be returned by specifying '-Select *'."
    )]
    public partial class GrantSHLDDRTLogBucketAssociationCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogBucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that contains the logs that you want to share.</para>
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
        public System.String LogBucket { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.AssociateDRTLogBucketResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogBucket), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Grant-SHLDDRTLogBucketAssociation (AssociateDRTLogBucket)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.AssociateDRTLogBucketResponse, GrantSHLDDRTLogBucketAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogBucket = this.LogBucket;
            #if MODULAR
            if (this.LogBucket == null && ParameterWasBound(nameof(this.LogBucket)))
            {
                WriteWarning("You are passing $null as a value for parameter LogBucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Shield.Model.AssociateDRTLogBucketRequest();
            
            if (cmdletContext.LogBucket != null)
            {
                request.LogBucket = cmdletContext.LogBucket;
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
        
        private Amazon.Shield.Model.AssociateDRTLogBucketResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.AssociateDRTLogBucketRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "AssociateDRTLogBucket");
            try
            {
                return client.AssociateDRTLogBucketAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LogBucket { get; set; }
            public System.Func<Amazon.Shield.Model.AssociateDRTLogBucketResponse, GrantSHLDDRTLogBucketAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
