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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Reboots some, or all, of the cache nodes within a provisioned cluster. This operation
    /// applies any modified cache parameter groups to the cluster. The reboot operation takes
    /// place as soon as possible, and results in a momentary outage to the cluster. During
    /// the reboot, the cluster status is set to REBOOTING.
    /// 
    ///  
    /// <para>
    /// The reboot causes the contents of the cache (for each cache node being rebooted) to
    /// be lost.
    /// </para><para>
    /// When the reboot is complete, a cluster event is created.
    /// </para><para>
    /// Rebooting a cluster is currently supported on Memcached and Redis OSS (cluster mode
    /// disabled) clusters. Rebooting is not supported on Redis OSS (cluster mode enabled)
    /// clusters.
    /// </para><para>
    /// If you make changes to parameters that require a Redis OSS (cluster mode enabled)
    /// cluster reboot for the changes to be applied, see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/nodes.rebooting.html">Rebooting
    /// a Cluster</a> for an alternate process.
    /// </para>
    /// </summary>
    [Cmdlet("Restart", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Calls the Amazon ElastiCache RebootCacheCluster API operation.", Operation = new[] {"RebootCacheCluster"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.RebootCacheClusterResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster or Amazon.ElastiCache.Model.RebootCacheClusterResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.CacheCluster object.",
        "The service call response (type Amazon.ElastiCache.Model.RebootCacheClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestartECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The cluster identifier. This parameter is stored as a lowercase string.</para>
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
        public System.String CacheClusterId { get; set; }
        #endregion
        
        #region Parameter CacheNodeIdsToReboot
        /// <summary>
        /// <para>
        /// <para>A list of cache node IDs to reboot. A node ID is a numeric identifier (0001, 0002,
        /// etc.). To reboot an entire cluster, specify all of the cache node IDs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] CacheNodeIdsToReboot { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.RebootCacheClusterResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.RebootCacheClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheCluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CacheClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restart-ECCacheCluster (RebootCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.RebootCacheClusterResponse, RestartECCacheClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CacheClusterId = this.CacheClusterId;
            #if MODULAR
            if (this.CacheClusterId == null && ParameterWasBound(nameof(this.CacheClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CacheNodeIdsToReboot != null)
            {
                context.CacheNodeIdsToReboot = new List<System.String>(this.CacheNodeIdsToReboot);
            }
            #if MODULAR
            if (this.CacheNodeIdsToReboot == null && ParameterWasBound(nameof(this.CacheNodeIdsToReboot)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheNodeIdsToReboot which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.RebootCacheClusterRequest();
            
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterId = cmdletContext.CacheClusterId;
            }
            if (cmdletContext.CacheNodeIdsToReboot != null)
            {
                request.CacheNodeIdsToReboot = cmdletContext.CacheNodeIdsToReboot;
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
        
        private Amazon.ElastiCache.Model.RebootCacheClusterResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.RebootCacheClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "RebootCacheCluster");
            try
            {
                #if DESKTOP
                return client.RebootCacheCluster(request);
                #elif CORECLR
                return client.RebootCacheClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String CacheClusterId { get; set; }
            public List<System.String> CacheNodeIdsToReboot { get; set; }
            public System.Func<Amazon.ElastiCache.Model.RebootCacheClusterResponse, RestartECCacheClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheCluster;
        }
        
    }
}
