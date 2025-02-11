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
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.IO;
using Amazon.PowerShell.Utils;
using System.Threading;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <para>
    /// Downloads an S3 object, optionally including sub-objects, to a local file or folder location. Returns a
    /// FileInfo or DirectoryInfo instance to the downloaded file or the containing folder.
    /// </para>
    /// <para>
    /// Note that you can pipe an Amazon.S3.Model.S3Object instance to this cmdlet and its members will be used to
    /// satisfy the BucketName, Key and optionally VersionId (if an S3ObjectVersion instance is supplied), parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Read", "S3Object", DefaultParameterSetName = ParamSet_ToLocalFile)]
    [OutputType(new Type[] { typeof(System.IO.FileInfo), typeof(System.IO.DirectoryInfo) })]
    [AWSCmdlet("Downloads one or more objects from an S3 bucket to the local file system.", Operation = new[] { "GetObject" })]
    [AWSCmdletOutput("System.IO.FileInfo instance if reading a single object or System.IO.DirectoryInfo instance for multi-object read.",
        "Returns a System.IO.FileInfo instance representing the local file if reading a single object or a System.IO.DirectoryInfo instance to the root parent folder if reading multiple objects."
    )]
    public class ReadS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string ParamSet_ToLocalFile = "DownloadFile";
        const string ParamSet_ToLocalFolder = "DownloadFolder";
        const string ParamSet_FromS3Object = "FromS3ObjectToFileOrFolder"; 

        // try and anticipate all the ways a user might mean 'get everything from root'
        internal static readonly string[] rootIndicators = new string[] { "/", @"\", "*", "/*", @"\*" };
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        #region Bucket Params

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// Name of the bucket that holds the content to be downloaded.
        /// </para>
        ///  
        /// <para>
        ///  <b>Directory buckets</b> - When you use this operation with a directory bucket, you
        /// must use virtual-hosted-style requests in the format <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c> <i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
        /// (for example, <c> <i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). For information
        /// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Object Lambda access points</b> - When you use this action with an Object Lambda
        /// access point, you must direct requests to the Object Lambda access point hostname.
        /// The Object Lambda access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-object-lambda.<i>Region</i>.amazonaws.com.
        /// </para>
        ///  <note> 
        /// <para>
        /// Access points and Object Lambda access points are not supported by directory buckets.
        /// </para>
        ///  </note> 
        /// <para>
        ///  <b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <c> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #endregion

        #region File Download Parameters

        #region Parameter Key
        /// <summary>
        /// The key that identifies the single object in S3.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_ToLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Key { get; set; }
        #endregion

        #region Parameter File
        /// <summary>
        /// The full path to the local file that will be created.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = ParamSet_ToLocalFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter(ParameterSets = new[] { ParamSet_ToLocalFile })]
        public System.String File { get; set; }
        #endregion

        #region Parameter Version
        /// <summary>
        /// If specified, the specific version of the S3 object is returned.
        /// </summary>
        [Alias("Version")]
        [Parameter(Position = 3, ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion


        #endregion

        #region Folder Download Parameters

        #region Parameter KeyPrefix
        /// <summary>
        /// <para>
        /// The key prefix that identifies the set of S3 objects to be downloaded. The
        /// key structure is preserved as the folder hierarchy under the destination folder.
        /// </para>
        /// <para>
        /// To indicate that all content in the bucket is to be downloaded, values of 
        /// '/', '\', '*', '/*' or '\*' may be used for this parameter.
        /// </summary>
        [Alias("Prefix")]
        [Parameter(Position = 1, ParameterSetName = ParamSet_ToLocalFolder, ValueFromPipelineByPropertyName = true)]
        public System.String KeyPrefix { get; set; }
        #endregion

        #region Parameter Folder
        /// <summary>
        /// The full path to a local folder; all downloaded content will be placed under this folder,
        /// with subfolders maintaining the S3 object key hierarchies.
        /// </summary>
        [Alias("Directory")]
        [Parameter(Position = 2, ParameterSetName = ParamSet_ToLocalFolder, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter(ParameterSets = new[] { ParamSet_ToLocalFolder })]
        public System.String Folder { get; set; }
        #endregion

        #region Parameter DisableSlashCorrection
        /// <summary>
        /// By default if KeyPrefix doesn't have a trailing '/' then a '/' is appended to mimic a virtual S3 directory. If the 
        /// KeyPrefix is not meant to be S3 virtual directory set DisableSlashCorrection to true to disable the behavior 
        /// for adding a trailing '/' to the KeyPrefix value.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFolder, ValueFromPipelineByPropertyName = true)]
        public bool DisableSlashCorrection { get; set; }
        #endregion

        #endregion

        #region S3Object Download Parameters

        #region Parameter S3Object
        /// <summary>
        /// <para>
        /// Amazon.S3.Model.S3Object instance containing the bucketname and key of the object to download. 
        /// If the supplied object is an Amazon.S3.Model.S3ObjectVersion instance (derived from S3Object), 
        /// the version of the object to download will be inferred automatically. 
        /// </para>
        /// <para>
        /// The object identified by the supplied S3Object can be downloaded to a specific file (by supplying 
        /// a value for the -File parameter) or to a folder (specified using the -Folder parameter). When 
        /// downloading to a folder, the object key is used as the filename. Note that object keys that are not 
        /// valid filenames for the host system could cause an exception to be thrown.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipeline=true, ParameterSetName=ParamSet_FromS3Object, Mandatory=true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public S3Object S3Object { get; set; }
        #endregion

        #endregion

        #region Common Optional Parameters

        #region Parameter ModifiedSinceDate
        /// <summary>
        /// If specified, only  objects that have been modified since this date will be downloaded.
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime ModifiedSinceDate { get; set; }
        #endregion

        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// If specified, only objects that have not been modified since this date will be downloaded.
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime UnmodifiedSinceDate { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm to be used with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 to use to decrypt the object.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion

        #region Parameter ChecksumMode
        /// <summary>
        /// This must be enabled to retrieve the checksum. In addition, if you enable <code>ChecksumMode</code> 
        /// and the object is KMS encrypted, you must have permission to the <code>kms:Decrypt</code> action
        /// for the request to succeed.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_ToLocalFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_FromS3Object, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumMode")]
        public ChecksumMode ChecksumMode { get; set; }
        #endregion

        #endregion

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                BucketName = this.BucketName
            };

            switch (this.ParameterSetName)
            {
                case ParamSet_ToLocalFile:
                    {
                        context.Key = AmazonS3Helper.CleanKey(this.Key);
                        base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.Key, context.Key);
                        context.File = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.File);
                        context.VersionId = this.VersionId;
                    }
                    break;

                case ParamSet_ToLocalFolder:
                    {
                        context.OriginalKeyPrefix = this.KeyPrefix;
                        context.KeyPrefix = rootIndicators.Contains<string>(this.KeyPrefix, StringComparer.OrdinalIgnoreCase) 
                            ? "/" : AmazonS3Helper.CleanKey(this.KeyPrefix);
                        base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.KeyPrefix, context.KeyPrefix);
                        context.Folder = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.Folder);
                        context.DisableSlashCorrection = this.DisableSlashCorrection;
                    }
                    break;

                case ParamSet_FromS3Object:
                    {
                        context.BucketName = this.S3Object.BucketName;
                        context.Key = this.S3Object.Key;
                        var s3ObjectVersion = this.S3Object as S3ObjectVersion;
                        context.VersionId = s3ObjectVersion == null ? null : s3ObjectVersion.VersionId;

                        if (this.ParameterWasBound("File"))
                        {
                            context.File = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.File);
                        }
                        else
                        {
                            var path = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.Folder);
                            context.File = Path.Combine(path, S3Object.Key);
                        }
                    }
                    break;
            }

#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("ModifiedSinceDate"))
                context.ModifiedSinceDate = this.ModifiedSinceDate;
            if (ParameterWasBound("UnmodifiedSinceDate"))
                context.UnmodifiedSinceDate = this.UnmodifiedSinceDate;
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            if (ParameterWasBound("ServerSideEncryptionCustomerMethod"))
                context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;

            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;

            if (ParameterWasBound("ChecksumMode"))
                context.ChecksumMode = this.ChecksumMode;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (!string.IsNullOrEmpty(cmdletContext.File))
                return DownloadFileFromS3(cmdletContext);
            else
                return DownloadFolderFromS3(cmdletContext);
        }

        CmdletOutput DownloadFileFromS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityDownloadRequest
            {
                BucketName = cmdletContext.BucketName,
                FilePath = cmdletContext.File,
                Key = cmdletContext.Key
            };

            if (!string.IsNullOrEmpty(cmdletContext.VersionId))
                request.VersionId = cmdletContext.VersionId;
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ModifiedSinceDate.HasValue)
            {
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
            {
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
            request.ChecksumMode = cmdletContext.ChecksumMode;

            CmdletOutput output;
            using (var tu = new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint)))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 object download APIs");

                var runner = new ProgressRunner(this);
                var tracker = new DownloadFileProgressTracker(runner, handler => request.WriteObjectProgressEvent += handler, cmdletContext.Key);

                output = runner.SafeRun(() => tu.DownloadAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult(), tracker);
                if (output.ErrorResponse == null)
                    output.PipelineOutput = new FileInfo(cmdletContext.File);
            }
            return output;
        }

        CmdletOutput DownloadFolderFromS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityDownloadDirectoryRequest
            {
                BucketName = cmdletContext.BucketName,
                LocalDirectory = cmdletContext.Folder,
                S3Directory = cmdletContext.KeyPrefix,
                DisableSlashCorrection = cmdletContext.DisableSlashCorrection
            };

#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ModifiedSinceDate.HasValue)
            {
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
            {
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            CmdletOutput output;
            using (var tu = new TransferUtility(Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint)))
            {
                Utils.Common.WriteVerboseEndpointMessage(this, Client.Config, "Amazon S3 object download APIs");

                var runner = new ProgressRunner(this);
                var tracker = new DownloadFolderProgressTracker(runner, handler => request.DownloadedDirectoryProgressEvent += handler);

                output = runner.SafeRun(() => tu.DownloadDirectoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult(), tracker);
                if (output.ErrorResponse == null)
                    output.PipelineOutput = new DirectoryInfo(cmdletContext.Folder);

                WriteVerbose(string.Format("Downloaded {0} object(s) from bucket '{1}' with keyprefix '{2}' to '{3}'",
                                           tracker.DownloadedCount,
                                           cmdletContext.BucketName,
                                           cmdletContext.OriginalKeyPrefix,
                                           cmdletContext.Folder));
            }

            return output;
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }

            public String Key { get; set; }
            public String File { get; set; }
            public string VersionId { get; set; }

            public String OriginalKeyPrefix { get; set; }
            public String KeyPrefix { get; set; }
            public String Folder { get; set; }
            public DateTime? ModifiedSinceDate { get; set; }
            public DateTime? UnmodifiedSinceDate { get; set; }

            public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public string ServerSideEncryptionCustomerProvidedKey { get; set; }
            public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

            public ChecksumMode ChecksumMode { get; set; }

            public bool DisableSlashCorrection { get; set; }
        }

        internal class DownloadFileProgressTracker : ProgressTracker<WriteObjectProgressArgs>
        {
            int _currentPercent = 0;
            readonly string _key;
            const string DownloadingFileActivity = "Downloading";
            const string ProgressMsgFormat = "File {0}...{1}%";

            public override string Activity
            {
                get { return DownloadingFileActivity; }
            }

            public DownloadFileProgressTracker(ProgressRunner runner, Action<EventHandler<WriteObjectProgressArgs>> subscribe, string key)
                : base(runner, subscribe)
            {
                this._key = key;

                ReportProgress(0, ProgressMsgFormat, _key, 0);
            }

            public override void ReportProgress(WriteObjectProgressArgs args)
            {
                if (args.PercentDone != _currentPercent)
                {
                    _currentPercent = args.PercentDone;
                    ReportProgress(args.PercentDone, ProgressMsgFormat, _key, args.PercentDone);
                }                
            }
        }

        internal class DownloadFolderProgressTracker : ProgressTracker<DownloadDirectoryProgressArgs>
        {
            int _fileDownloadCount = 0;
            string _currentFile = string.Empty;
            const string DownloadingFolderActivity = "Downloading";

            public override string Activity
            {
                get { return DownloadingFolderActivity; }
            }

            public DownloadFolderProgressTracker(ProgressRunner runner, Action<EventHandler<DownloadDirectoryProgressArgs>> subscribe)
                : base(runner, subscribe)
            {
                ReportProgress(0, "Downloading files...");
            }

            public int DownloadedCount { get { return _fileDownloadCount; } }

            public override void ReportProgress(DownloadDirectoryProgressArgs args)
            {
                if (string.Compare(_currentFile, args.CurrentFile, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _currentFile = args.CurrentFile;
                    _fileDownloadCount = args.NumberOfFilesDownloaded;
                    ReportProgress(args.NumberOfFilesDownloaded, args.TotalNumberOfFiles, "Downloaded {0} files, current file {1}", args.NumberOfFilesDownloaded, args.CurrentFile);
                }
            }
        }

    }
}
