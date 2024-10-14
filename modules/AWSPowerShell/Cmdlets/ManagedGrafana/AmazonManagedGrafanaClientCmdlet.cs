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
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

namespace Amazon.PowerShell.Cmdlets.MGRF
{
    [AWSClientCmdlet("Amazon Managed Grafana", "MGRF", "2020-08-18", "ManagedGrafana")]
    public abstract partial class AmazonManagedGrafanaClientCmdlet : ServiceCmdlet
    {
        protected IAmazonManagedGrafana Client { get; private set; }
        
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonManagedGrafanaConfig ClientConfig
        {
            get
            {
                return base._ClientConfig as AmazonManagedGrafanaConfig;
            }
            set
            {
                base._ClientConfig = value;
            }
        }
        
        protected IAmazonManagedGrafana CreateClient(AWSCredentials credentials, RegionEndpoint region)
        {
            var config = this.ClientConfig ?? new AmazonManagedGrafanaConfig();
            if (region != null) config.RegionEndpoint = region;
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonManagedGrafanaClient(credentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void BeginProcessing()
        {
            base.AWSServiceId = AmazonManagedGrafanaConfig.ServiceId.ToString();
            
            base.BeginProcessing();
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_CurrentCredentials, _RegionEndpoint);
        }
    }
}
