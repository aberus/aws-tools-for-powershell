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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Associates the specified application with the specified fleet. This is only supported
    /// for Elastic fleets.
    /// </summary>
    [Cmdlet("Register", "APSApplicationFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.ApplicationFleetAssociation")]
    [AWSCmdlet("Calls the Amazon AppStream AssociateApplicationFleet API operation.", Operation = new[] {"AssociateApplicationFleet"}, SelectReturnType = typeof(Amazon.AppStream.Model.AssociateApplicationFleetResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.ApplicationFleetAssociation or Amazon.AppStream.Model.AssociateApplicationFleetResponse",
        "This cmdlet returns an Amazon.AppStream.Model.ApplicationFleetAssociation object.",
        "The service call response (type Amazon.AppStream.Model.AssociateApplicationFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterAPSApplicationFleetCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the application.</para>
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
        public System.String ApplicationArn { get; set; }
        #endregion
        
        #region Parameter FleetName
        /// <summary>
        /// <para>
        /// <para>The name of the fleet.</para>
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
        public System.String FleetName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationFleetAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.AssociateApplicationFleetResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.AssociateApplicationFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationFleetAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-APSApplicationFleet (AssociateApplicationFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.AssociateApplicationFleetResponse, RegisterAPSApplicationFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationArn = this.ApplicationArn;
            #if MODULAR
            if (this.ApplicationArn == null && ParameterWasBound(nameof(this.ApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetName = this.FleetName;
            #if MODULAR
            if (this.FleetName == null && ParameterWasBound(nameof(this.FleetName)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppStream.Model.AssociateApplicationFleetRequest();
            
            if (cmdletContext.ApplicationArn != null)
            {
                request.ApplicationArn = cmdletContext.ApplicationArn;
            }
            if (cmdletContext.FleetName != null)
            {
                request.FleetName = cmdletContext.FleetName;
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
        
        private Amazon.AppStream.Model.AssociateApplicationFleetResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.AssociateApplicationFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "AssociateApplicationFleet");
            try
            {
                #if DESKTOP
                return client.AssociateApplicationFleet(request);
                #elif CORECLR
                return client.AssociateApplicationFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationArn { get; set; }
            public System.String FleetName { get; set; }
            public System.Func<Amazon.AppStream.Model.AssociateApplicationFleetResponse, RegisterAPSApplicationFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationFleetAssociation;
        }
        
    }
}
