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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Adds a source identifier to an existing event notification subscription.
    /// </summary>
    [Cmdlet("Add", "DOCSourceIdentifierToSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.EventSubscription")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) AddSourceIdentifierToSubscription API operation.", Operation = new[] {"AddSourceIdentifierToSubscription"}, SelectReturnType = typeof(Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.EventSubscription or Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse",
        "This cmdlet returns an Amazon.DocDB.Model.EventSubscription object.",
        "The service call response (type Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddDOCSourceIdentifierToSubscriptionCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the event source to be added:</para><ul><li><para>If the source type is an instance, a <c>DBInstanceIdentifier</c> must be provided.</para></li><li><para>If the source type is a security group, a <c>DBSecurityGroupName</c> must be provided.</para></li><li><para>If the source type is a parameter group, a <c>DBParameterGroupName</c> must be provided.</para></li><li><para>If the source type is a snapshot, a <c>DBSnapshotIdentifier</c> must be provided.</para></li></ul>
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
        public System.String SourceIdentifier { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon DocumentDB event notification subscription that you want to
        /// add a source identifier to.</para>
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
        public System.String SubscriptionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventSubscription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventSubscription";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DOCSourceIdentifierToSubscription (AddSourceIdentifierToSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse, AddDOCSourceIdentifierToSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SourceIdentifier = this.SourceIdentifier;
            #if MODULAR
            if (this.SourceIdentifier == null && ParameterWasBound(nameof(this.SourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriptionName = this.SubscriptionName;
            #if MODULAR
            if (this.SubscriptionName == null && ParameterWasBound(nameof(this.SubscriptionName)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionRequest();
            
            if (cmdletContext.SourceIdentifier != null)
            {
                request.SourceIdentifier = cmdletContext.SourceIdentifier;
            }
            if (cmdletContext.SubscriptionName != null)
            {
                request.SubscriptionName = cmdletContext.SubscriptionName;
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
        
        private Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "AddSourceIdentifierToSubscription");
            try
            {
                return client.AddSourceIdentifierToSubscriptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SourceIdentifier { get; set; }
            public System.String SubscriptionName { get; set; }
            public System.Func<Amazon.DocDB.Model.AddSourceIdentifierToSubscriptionResponse, AddDOCSourceIdentifierToSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventSubscription;
        }
        
    }
}
