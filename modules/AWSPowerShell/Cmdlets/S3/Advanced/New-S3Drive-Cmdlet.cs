/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
using System.Management.Automation;
using System.Net;
using Amazon.PowerShell.Cmdlets.S3.Advanced;
using Amazon.PowerShell.Common;
using Amazon.S3.Util;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Tests that an S3 Bucket exists
    /// </summary>
    [Cmdlet("New", "S3Drive")]
    [OutputType(typeof(bool))]
    [AWSCmdlet("Tests that an S3 bucket exists.", Operation = new[] { "" })]
    [AWSCmdletOutput("System.Boolean", "Returns true if the bucket exists, false if it doesn't. Returns true even if the bucket exists but belongs to a different account.")]
    public class NewS3DriveCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        #region Parameter BucketName
        /// <summary>
        /// The name of the bucket to test existence and access.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                BucketName = this.BucketName
            };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            string _driveName = "s3";


            var amazonS3DriveParameters = new AmazonS3DriveParameters()
            {
                Credential = _CurrentCredentials,
                RegionEndpoint = _RegionEndpoint,
                Client = CreateClient(_CurrentCredentials, _RegionEndpoint)
            };

            


            PSDriveInfo s3Drive = new AmazonS3DriveInfo(_driveName, this.SessionState.Provider.GetOne(AmazonS3Provider.ProviderName), "\\", "Amazon S3", null, amazonS3DriveParameters);

            this.SessionState.Drive.New(s3Drive, "local");

            return s3Drive;


//            using (var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint))
//            {
//                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3");

//#if DESKTOP
//                var exists = AmazonS3Util.DoesS3BucketExistV2(client, cmdletContext.BucketName);
//#elif CORECLR
//                var exists = AmazonS3Util.DoesS3BucketExistV2Async(client, cmdletContext.BucketName).GetAwaiter().GetResult();
//#else
//#error "Unknown build edition"
//#endif
//                var output = new CmdletOutput
//                {
//                    PipelineOutput = exists
//                };
//                return output;
//            }
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }
        }
    }
}
