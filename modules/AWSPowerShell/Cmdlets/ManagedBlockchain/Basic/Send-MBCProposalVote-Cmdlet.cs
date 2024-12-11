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
using Amazon.ManagedBlockchain;
using Amazon.ManagedBlockchain.Model;

namespace Amazon.PowerShell.Cmdlets.MBC
{
    /// <summary>
    /// Casts a vote for a specified <c>ProposalId</c> on behalf of a member. The member to
    /// vote as, specified by <c>VoterMemberId</c>, must be in the same Amazon Web Services
    /// account as the principal that calls the action.
    /// 
    ///  
    /// <para>
    /// Applies only to Hyperledger Fabric.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "MBCProposalVote", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain VoteOnProposal API operation.", Operation = new[] {"VoteOnProposal"}, SelectReturnType = typeof(Amazon.ManagedBlockchain.Model.VoteOnProposalResponse))]
    [AWSCmdletOutput("None or Amazon.ManagedBlockchain.Model.VoteOnProposalResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ManagedBlockchain.Model.VoteOnProposalResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendMBCProposalVoteCmdlet : AmazonManagedBlockchainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the network. </para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter ProposalId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the proposal. </para>
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
        public System.String ProposalId { get; set; }
        #endregion
        
        #region Parameter Vote
        /// <summary>
        /// <para>
        /// <para> The value of the vote. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedBlockchain.VoteValue")]
        public Amazon.ManagedBlockchain.VoteValue Vote { get; set; }
        #endregion
        
        #region Parameter VoterMemberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the member casting the vote. </para>
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
        public System.String VoterMemberId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchain.Model.VoteOnProposalResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProposalId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MBCProposalVote (VoteOnProposal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchain.Model.VoteOnProposalResponse, SendMBCProposalVoteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProposalId = this.ProposalId;
            #if MODULAR
            if (this.ProposalId == null && ParameterWasBound(nameof(this.ProposalId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProposalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Vote = this.Vote;
            #if MODULAR
            if (this.Vote == null && ParameterWasBound(nameof(this.Vote)))
            {
                WriteWarning("You are passing $null as a value for parameter Vote which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoterMemberId = this.VoterMemberId;
            #if MODULAR
            if (this.VoterMemberId == null && ParameterWasBound(nameof(this.VoterMemberId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoterMemberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ManagedBlockchain.Model.VoteOnProposalRequest();
            
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            if (cmdletContext.ProposalId != null)
            {
                request.ProposalId = cmdletContext.ProposalId;
            }
            if (cmdletContext.Vote != null)
            {
                request.Vote = cmdletContext.Vote;
            }
            if (cmdletContext.VoterMemberId != null)
            {
                request.VoterMemberId = cmdletContext.VoterMemberId;
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
        
        private Amazon.ManagedBlockchain.Model.VoteOnProposalResponse CallAWSServiceOperation(IAmazonManagedBlockchain client, Amazon.ManagedBlockchain.Model.VoteOnProposalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain", "VoteOnProposal");
            try
            {
                #if DESKTOP
                return client.VoteOnProposal(request);
                #elif CORECLR
                return client.VoteOnProposalAsync(request).GetAwaiter().GetResult();
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
            public System.String NetworkId { get; set; }
            public System.String ProposalId { get; set; }
            public Amazon.ManagedBlockchain.VoteValue Vote { get; set; }
            public System.String VoterMemberId { get; set; }
            public System.Func<Amazon.ManagedBlockchain.Model.VoteOnProposalResponse, SendMBCProposalVoteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
