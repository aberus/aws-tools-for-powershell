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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a custom set of DHCP options. After you create a DHCP option set, you associate
    /// it with a VPC. After you associate a DHCP option set with a VPC, all existing and
    /// newly launched instances in the VPC use this set of DHCP options.
    /// 
    ///  
    /// <para>
    /// The following are the individual DHCP options you can specify. For more information,
    /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_DHCP_Options.html">DHCP
    /// option sets</a> in the <i>Amazon VPC User Guide</i>.
    /// </para><ul><li><para><c>domain-name</c> - If you're using AmazonProvidedDNS in <c>us-east-1</c>, specify
    /// <c>ec2.internal</c>. If you're using AmazonProvidedDNS in any other Region, specify
    /// <c>region.compute.internal</c>. Otherwise, specify a custom domain name. This value
    /// is used to complete unqualified DNS hostnames.
    /// </para><para>
    /// Some Linux operating systems accept multiple domain names separated by spaces. However,
    /// Windows and other Linux operating systems treat the value as a single domain, which
    /// results in unexpected behavior. If your DHCP option set is associated with a VPC that
    /// has instances running operating systems that treat the value as a single domain, specify
    /// only one domain name.
    /// </para></li><li><para><c>domain-name-servers</c> - The IP addresses of up to four DNS servers, or AmazonProvidedDNS.
    /// To specify multiple domain name servers in a single parameter, separate the IP addresses
    /// using commas. To have your instances receive custom DNS hostnames as specified in
    /// <c>domain-name</c>, you must specify a custom DNS server.
    /// </para></li><li><para><c>ntp-servers</c> - The IP addresses of up to eight Network Time Protocol (NTP)
    /// servers (four IPv4 addresses and four IPv6 addresses).
    /// </para></li><li><para><c>netbios-name-servers</c> - The IP addresses of up to four NetBIOS name servers.
    /// </para></li><li><para><c>netbios-node-type</c> - The NetBIOS node type (1, 2, 4, or 8). We recommend that
    /// you specify 2. Broadcast and multicast are not supported. For more information about
    /// NetBIOS node types, see <a href="https://www.ietf.org/rfc/rfc2132.txt">RFC 2132</a>.
    /// </para></li><li><para><c>ipv6-address-preferred-lease-time</c> - A value (in seconds, minutes, hours, or
    /// years) for how frequently a running instance with an IPv6 assigned to it goes through
    /// DHCPv6 lease renewal. Acceptable values are between 140 and 2147483647 seconds (approximately
    /// 68 years). If no value is entered, the default lease time is 140 seconds. If you use
    /// long-term addressing for EC2 instances, you can increase the lease time and avoid
    /// frequent lease renewal requests. Lease renewal typically occurs when half of the lease
    /// time has elapsed.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "EC2DhcpOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.DhcpOptions")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateDhcpOptions API operation.", Operation = new[] {"CreateDhcpOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateDhcpOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DhcpOptions or Amazon.EC2.Model.CreateDhcpOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.DhcpOptions object.",
        "The service call response (type Amazon.EC2.Model.CreateDhcpOptionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2DhcpOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DhcpConfiguration
        /// <summary>
        /// <para>
        /// <para>A DHCP configuration option.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DhcpConfigurations")]
        public Amazon.EC2.Model.DhcpConfiguration[] DhcpConfiguration { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the DHCP option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DhcpOptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateDhcpOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateDhcpOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DhcpOptions";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DhcpConfiguration), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2DhcpOption (CreateDhcpOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateDhcpOptionsResponse, NewEC2DhcpOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DhcpConfiguration != null)
            {
                context.DhcpConfiguration = new List<Amazon.EC2.Model.DhcpConfiguration>(this.DhcpConfiguration);
            }
            #if MODULAR
            if (this.DhcpConfiguration == null && ParameterWasBound(nameof(this.DhcpConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter DhcpConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateDhcpOptionsRequest();
            
            if (cmdletContext.DhcpConfiguration != null)
            {
                request.DhcpConfigurations = cmdletContext.DhcpConfiguration;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateDhcpOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateDhcpOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateDhcpOptions");
            try
            {
                #if DESKTOP
                return client.CreateDhcpOptions(request);
                #elif CORECLR
                return client.CreateDhcpOptionsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.DhcpConfiguration> DhcpConfiguration { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateDhcpOptionsResponse, NewEC2DhcpOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DhcpOptions;
        }
        
    }
}
