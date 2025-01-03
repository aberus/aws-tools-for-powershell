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
    /// Creates a network interface in the specified subnet.
    /// 
    ///  
    /// <para>
    /// The number of IP addresses you can assign to a network interface varies by instance
    /// type.
    /// </para><para>
    /// For more information about network interfaces, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-eni.html">Elastic
    /// network interfaces</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2NetworkInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.NetworkInterface")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateNetworkInterface API operation.", Operation = new[] {"CreateNetworkInterface"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateNetworkInterfaceResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInterface or Amazon.EC2.Model.CreateNetworkInterfaceResponse",
        "This cmdlet returns an Amazon.EC2.Model.NetworkInterface object.",
        "The service call response (type Amazon.EC2.Model.CreateNetworkInterfaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2NetworkInterfaceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnablePrimaryIpv6
        /// <summary>
        /// <para>
        /// <para>If you’re creating a network interface in a dual-stack or IPv6-only subnet, you have
        /// the option to assign a primary IPv6 IP address. A primary IPv6 address is an IPv6
        /// GUA address associated with an ENI that you have enabled to use a primary IPv6 address.
        /// Use this option if the instance that this ENI will be attached to relies on its IPv6
        /// address not changing. Amazon Web Services will automatically assign an IPv6 address
        /// associated with the ENI attached to your instance to be the primary IPv6 address.
        /// Once you enable an IPv6 GUA address to be a primary IPv6, you cannot disable it. When
        /// you enable an IPv6 GUA address to be a primary IPv6, the first IPv6 GUA will be made
        /// the primary IPv6 address until the instance is terminated or the network interface
        /// is detached. If you have multiple IPv6 addresses associated with an ENI attached to
        /// your instance and you enable a primary IPv6 address, the first IPv6 GUA address associated
        /// with the ENI becomes the primary IPv6 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePrimaryIpv6 { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("GroupId","Groups")]
        public System.String[] Group { get; set; }
        #endregion
        
        #region Parameter InterfaceType
        /// <summary>
        /// <para>
        /// <para>The type of network interface. The default is <c>interface</c>.</para><para>If you specify <c>efa-only</c>, do not assign any IP addresses to the network interface.
        /// EFA-only network interfaces do not support IP addresses.</para><para>The only supported values are <c>interface</c>, <c>efa</c>, <c>efa-only</c>, and <c>trunk</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.NetworkInterfaceCreationType")]
        public Amazon.EC2.NetworkInterfaceCreationType InterfaceType { get; set; }
        #endregion
        
        #region Parameter Ipv4PrefixCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv4 prefixes that Amazon Web Services automatically assigns to the
        /// network interface.</para><para>You can't specify a count of IPv4 prefixes if you've specified one of the following:
        /// specific IPv4 prefixes, specific private IPv4 addresses, or a count of private IPv4
        /// addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv4PrefixCount { get; set; }
        #endregion
        
        #region Parameter Ipv4Prefix
        /// <summary>
        /// <para>
        /// <para>The IPv4 prefixes assigned to the network interface.</para><para>You can't specify IPv4 prefixes if you've specified one of the following: a count
        /// of IPv4 prefixes, specific private IPv4 addresses, or a count of private IPv4 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv4Prefixes")]
        public Amazon.EC2.Model.Ipv4PrefixSpecificationRequest[] Ipv4Prefix { get; set; }
        #endregion
        
        #region Parameter Ipv6AddressCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv6 addresses to assign to a network interface. Amazon EC2 automatically
        /// selects the IPv6 addresses from the subnet range.</para><para>You can't specify a count of IPv6 addresses using this parameter if you've specified
        /// one of the following: specific IPv6 addresses, specific IPv6 prefixes, or a count
        /// of IPv6 prefixes.</para><para>If your subnet has the <c>AssignIpv6AddressOnCreation</c> attribute set, you can override
        /// that setting by specifying 0 as the IPv6 address count.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv6AddressCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>The IPv6 addresses from the IPv6 CIDR block range of your subnet.</para><para>You can't specify IPv6 addresses using this parameter if you've specified one of the
        /// following: a count of IPv6 addresses, specific IPv6 prefixes, or a count of IPv6 prefixes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv6Addresses")]
        public Amazon.EC2.Model.InstanceIpv6Address[] Ipv6Address { get; set; }
        #endregion
        
        #region Parameter Ipv6PrefixCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv6 prefixes that Amazon Web Services automatically assigns to the
        /// network interface.</para><para>You can't specify a count of IPv6 prefixes if you've specified one of the following:
        /// specific IPv6 prefixes, specific IPv6 addresses, or a count of IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv6PrefixCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Prefix
        /// <summary>
        /// <para>
        /// <para>The IPv6 prefixes assigned to the network interface.</para><para>You can't specify IPv6 prefixes if you've specified one of the following: a count
        /// of IPv6 prefixes, specific IPv6 addresses, or a count of IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv6Prefixes")]
        public Amazon.EC2.Model.Ipv6PrefixSpecificationRequest[] Ipv6Prefix { get; set; }
        #endregion
        
        #region Parameter Operator_Principal
        /// <summary>
        /// <para>
        /// <para>The service provider that manages the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Operator_Principal { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>The primary private IPv4 address of the network interface. If you don't specify an
        /// IPv4 address, Amazon EC2 selects one for you from the subnet's IPv4 CIDR range. If
        /// you specify an IP address, you cannot indicate any IP addresses specified in <c>privateIpAddresses</c>
        /// as primary (only one IP address can be designated as primary).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddressSet
        /// <summary>
        /// <para>
        /// <para>The private IPv4 addresses.</para><para>You can't specify private IPv4 addresses if you've specified one of the following:
        /// a count of private IPv4 addresses, specific IPv4 prefixes, or a count of IPv4 prefixes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivateIpAddresses")]
        public Amazon.EC2.Model.PrivateIpAddressSpecification[] PrivateIpAddressSet { get; set; }
        #endregion
        
        #region Parameter SecondaryPrivateIpAddressCount
        /// <summary>
        /// <para>
        /// <para>The number of secondary private IPv4 addresses to assign to a network interface. When
        /// you specify a number of secondary IPv4 addresses, Amazon EC2 selects these IP addresses
        /// within the subnet's IPv4 CIDR range. You can't specify this option and specify more
        /// than one private IP address using <c>privateIpAddresses</c>.</para><para>You can't specify a count of private IPv4 addresses if you've specified one of the
        /// following: specific private IPv4 addresses, specific IPv4 prefixes, or a count of
        /// IPv4 prefixes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet to associate with the network interface.</para>
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
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the new network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ConnectionTrackingSpecification_TcpEstablishedTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout (in seconds) for idle TCP connections in an established state. Min: 60 seconds.
        /// Max: 432000 seconds (5 days). Default: 432000 seconds. Recommended: Less than 432000
        /// seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionTrackingSpecification_TcpEstablishedTimeout { get; set; }
        #endregion
        
        #region Parameter ConnectionTrackingSpecification_UdpStreamTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout (in seconds) for idle UDP flows classified as streams which have seen more
        /// than one request-response transaction. Min: 60 seconds. Max: 180 seconds (3 minutes).
        /// Default: 180 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionTrackingSpecification_UdpStreamTimeout { get; set; }
        #endregion
        
        #region Parameter ConnectionTrackingSpecification_UdpTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout (in seconds) for idle UDP flows that have seen traffic only in a single direction
        /// or a single request-response transaction. Min: 30 seconds. Max: 60 seconds. Default:
        /// 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionTrackingSpecification_UdpTimeout { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkInterface'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateNetworkInterfaceResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateNetworkInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkInterface";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubnetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NetworkInterface (CreateNetworkInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateNetworkInterfaceResponse, NewEC2NetworkInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectionTrackingSpecification_TcpEstablishedTimeout = this.ConnectionTrackingSpecification_TcpEstablishedTimeout;
            context.ConnectionTrackingSpecification_UdpStreamTimeout = this.ConnectionTrackingSpecification_UdpStreamTimeout;
            context.ConnectionTrackingSpecification_UdpTimeout = this.ConnectionTrackingSpecification_UdpTimeout;
            context.Description = this.Description;
            context.EnablePrimaryIpv6 = this.EnablePrimaryIpv6;
            if (this.Group != null)
            {
                context.Group = new List<System.String>(this.Group);
            }
            context.InterfaceType = this.InterfaceType;
            context.Ipv4PrefixCount = this.Ipv4PrefixCount;
            if (this.Ipv4Prefix != null)
            {
                context.Ipv4Prefix = new List<Amazon.EC2.Model.Ipv4PrefixSpecificationRequest>(this.Ipv4Prefix);
            }
            context.Ipv6AddressCount = this.Ipv6AddressCount;
            if (this.Ipv6Address != null)
            {
                context.Ipv6Address = new List<Amazon.EC2.Model.InstanceIpv6Address>(this.Ipv6Address);
            }
            context.Ipv6PrefixCount = this.Ipv6PrefixCount;
            if (this.Ipv6Prefix != null)
            {
                context.Ipv6Prefix = new List<Amazon.EC2.Model.Ipv6PrefixSpecificationRequest>(this.Ipv6Prefix);
            }
            context.Operator_Principal = this.Operator_Principal;
            context.PrivateIpAddress = this.PrivateIpAddress;
            if (this.PrivateIpAddressSet != null)
            {
                context.PrivateIpAddressSet = new List<Amazon.EC2.Model.PrivateIpAddressSpecification>(this.PrivateIpAddressSet);
            }
            context.SecondaryPrivateIpAddressCount = this.SecondaryPrivateIpAddressCount;
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateNetworkInterfaceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConnectionTrackingSpecification
            var requestConnectionTrackingSpecificationIsNull = true;
            request.ConnectionTrackingSpecification = new Amazon.EC2.Model.ConnectionTrackingSpecificationRequest();
            System.Int32? requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout = null;
            if (cmdletContext.ConnectionTrackingSpecification_TcpEstablishedTimeout != null)
            {
                requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout = cmdletContext.ConnectionTrackingSpecification_TcpEstablishedTimeout.Value;
            }
            if (requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout != null)
            {
                request.ConnectionTrackingSpecification.TcpEstablishedTimeout = requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout.Value;
                requestConnectionTrackingSpecificationIsNull = false;
            }
            System.Int32? requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout = null;
            if (cmdletContext.ConnectionTrackingSpecification_UdpStreamTimeout != null)
            {
                requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout = cmdletContext.ConnectionTrackingSpecification_UdpStreamTimeout.Value;
            }
            if (requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout != null)
            {
                request.ConnectionTrackingSpecification.UdpStreamTimeout = requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout.Value;
                requestConnectionTrackingSpecificationIsNull = false;
            }
            System.Int32? requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout = null;
            if (cmdletContext.ConnectionTrackingSpecification_UdpTimeout != null)
            {
                requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout = cmdletContext.ConnectionTrackingSpecification_UdpTimeout.Value;
            }
            if (requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout != null)
            {
                request.ConnectionTrackingSpecification.UdpTimeout = requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout.Value;
                requestConnectionTrackingSpecificationIsNull = false;
            }
             // determine if request.ConnectionTrackingSpecification should be set to null
            if (requestConnectionTrackingSpecificationIsNull)
            {
                request.ConnectionTrackingSpecification = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnablePrimaryIpv6 != null)
            {
                request.EnablePrimaryIpv6 = cmdletContext.EnablePrimaryIpv6.Value;
            }
            if (cmdletContext.Group != null)
            {
                request.Groups = cmdletContext.Group;
            }
            if (cmdletContext.InterfaceType != null)
            {
                request.InterfaceType = cmdletContext.InterfaceType;
            }
            if (cmdletContext.Ipv4PrefixCount != null)
            {
                request.Ipv4PrefixCount = cmdletContext.Ipv4PrefixCount.Value;
            }
            if (cmdletContext.Ipv4Prefix != null)
            {
                request.Ipv4Prefixes = cmdletContext.Ipv4Prefix;
            }
            if (cmdletContext.Ipv6AddressCount != null)
            {
                request.Ipv6AddressCount = cmdletContext.Ipv6AddressCount.Value;
            }
            if (cmdletContext.Ipv6Address != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Address;
            }
            if (cmdletContext.Ipv6PrefixCount != null)
            {
                request.Ipv6PrefixCount = cmdletContext.Ipv6PrefixCount.Value;
            }
            if (cmdletContext.Ipv6Prefix != null)
            {
                request.Ipv6Prefixes = cmdletContext.Ipv6Prefix;
            }
            
             // populate Operator
            var requestOperatorIsNull = true;
            request.Operator = new Amazon.EC2.Model.OperatorRequest();
            System.String requestOperator_operator_Principal = null;
            if (cmdletContext.Operator_Principal != null)
            {
                requestOperator_operator_Principal = cmdletContext.Operator_Principal;
            }
            if (requestOperator_operator_Principal != null)
            {
                request.Operator.Principal = requestOperator_operator_Principal;
                requestOperatorIsNull = false;
            }
             // determine if request.Operator should be set to null
            if (requestOperatorIsNull)
            {
                request.Operator = null;
            }
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddress = cmdletContext.PrivateIpAddress;
            }
            if (cmdletContext.PrivateIpAddressSet != null)
            {
                request.PrivateIpAddresses = cmdletContext.PrivateIpAddressSet;
            }
            if (cmdletContext.SecondaryPrivateIpAddressCount != null)
            {
                request.SecondaryPrivateIpAddressCount = cmdletContext.SecondaryPrivateIpAddressCount.Value;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
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
        
        private Amazon.EC2.Model.CreateNetworkInterfaceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNetworkInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateNetworkInterface");
            try
            {
                #if DESKTOP
                return client.CreateNetworkInterface(request);
                #elif CORECLR
                return client.CreateNetworkInterfaceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Int32? ConnectionTrackingSpecification_TcpEstablishedTimeout { get; set; }
            public System.Int32? ConnectionTrackingSpecification_UdpStreamTimeout { get; set; }
            public System.Int32? ConnectionTrackingSpecification_UdpTimeout { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnablePrimaryIpv6 { get; set; }
            public List<System.String> Group { get; set; }
            public Amazon.EC2.NetworkInterfaceCreationType InterfaceType { get; set; }
            public System.Int32? Ipv4PrefixCount { get; set; }
            public List<Amazon.EC2.Model.Ipv4PrefixSpecificationRequest> Ipv4Prefix { get; set; }
            public System.Int32? Ipv6AddressCount { get; set; }
            public List<Amazon.EC2.Model.InstanceIpv6Address> Ipv6Address { get; set; }
            public System.Int32? Ipv6PrefixCount { get; set; }
            public List<Amazon.EC2.Model.Ipv6PrefixSpecificationRequest> Ipv6Prefix { get; set; }
            public System.String Operator_Principal { get; set; }
            public System.String PrivateIpAddress { get; set; }
            public List<Amazon.EC2.Model.PrivateIpAddressSpecification> PrivateIpAddressSet { get; set; }
            public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
            public System.String SubnetId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateNetworkInterfaceResponse, NewEC2NetworkInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkInterface;
        }
        
    }
}
