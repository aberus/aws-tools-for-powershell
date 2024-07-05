using Amazon;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Internal;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Net.Sockets;

namespace Amazon.PowerShell.Cmdlets.S3.Advanced
{
    /// <summary>
    /// Simple provider.
    /// </summary>
    [CmdletProvider(ProviderName, ProviderCapabilities.ShouldProcess)]
    public class AmazonS3Provider : NavigationCmdletProvider
    {

        public static readonly char pathSeparator = System.IO.Path.DirectorySeparatorChar;


        internal const string ProviderName = "AmazonS3";

        protected IAmazonS3 Client { get; private set; }

        protected ClientConfig _ClientConfig { get; set; }


        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonS3Config ClientConfig
        {
            get
            {
                return _ClientConfig as AmazonS3Config;
            }
            set
            {
                _ClientConfig = value;
            }
        }

        protected override object NewDriveDynamicParameters()
        {
            return new AmazonS3DriveParameters();
        }

        protected override bool ItemExists(string path)
        {
            return true;
            //return base.ItemExists(path);
        }

        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            // check if drive object is null
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                    new ArgumentNullException("drive"),
                    "NullDrive",
                    ErrorCategory.InvalidArgument,
                    null)
                );

                return null;
            }

            if (drive is AmazonS3DriveInfo)
            {
                return drive;
            }

            var libraryParams = DynamicParameters as AmazonS3DriveParameters;
            return new AmazonS3DriveInfo(drive);

            // create a new drive and create an ODBC connection to the new drive
            //AmazonS3DriveInfo amazonS3DriveInfo = new AmazonS3DriveInfo(drive);
            //OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();

            //builder.Driver = "Microsoft Access Driver (*.mdb)";
            //builder.Add("DBQ", drive.Root);

            //OdbcConnection conn = new OdbcConnection(builder.ConnectionString);
            //conn.Open();
            //accessDBPSDriveInfo.Connection = conn;

            //return amazonS3DriveInfo;
        }

        ///// <summary>
        ///// Creates a default Google Cloud Storage drive named gs.
        ///// </summary>
        ///// <returns>A single drive named gs.</returns>
        //protected override Collection<PSDriveInfo> InitializeDefaultDrives()
        //{
        //    return new Collection<PSDriveInfo>
        //    {
        //        new PSDriveInfo("gs", ProviderInfo, "", ProviderName, PSCredential.Empty)
        //    };
        //}

        //protected IAmazonS3 CreateClient(AWSCredentials credentials, RegionEndpoint region)
        //{
        //    var config = this.ClientConfig ?? new AmazonS3Config();
        //    if (region != null) config.RegionEndpoint = region;
        //    Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
        //    //this.CustomizeClientConfig(config);
        //    var client = new AmazonS3Client(credentials, config);
        //    return client;
        //}

        //protected IAmazonS3 CreateClient2(AWSCredentials credentials, RegionEndpoint region)
        //{
        //    var config = this.ClientConfig ?? new AmazonS3Config();
        //    if (region != null) config.RegionEndpoint = region;
        //    //Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
        //    //this.CustomizeClientConfig(config);
        //    var client = new AmazonS3Client(credentials, config);
        //    //client.BeforeRequestEvent += RequestEventHandler;
        //    //client.AfterResponseEvent += ResponseEventHandler;
        //    return client;
        //}

        protected override bool IsValidPath(string path)
        {
            return true;
        }

        //protected override void Stop()
        //{
        //    Client.Dispose();
        //}

        protected override void GetChildItems(string path, bool recurse)
        {
            WriteItemObject("test4", path, true);
            (string bucket, string key) = SplitS3Path(path);

            var driveInfo = this.PSDriveInfo as AmazonS3DriveInfo;
            var client = driveInfo.Client;
            
            if (string.IsNullOrEmpty(bucket))
            {
                WriteItemObject("test3", path, true);
                var request = new ListBucketsRequest();
                var response = client.ListBucketsAsync(request).GetAwaiter().GetResult();
                WriteItemObject(response.Buckets, path, true);
            }
            else if (string.IsNullOrEmpty(key))
            {
                //WriteItemObject("test2"+" "+bucket+" "+key, path, true);
                var request = new Amazon.S3.Model.ListObjectsV2Request()
                {
                    BucketName = bucket,
                    Delimiter = "/",
                };
                var response = client.ListObjectsV2Async(request).GetAwaiter().GetResult();
                if (response.CommonPrefixes.Count > 0)
                {
                    WriteItemObject(response.CommonPrefixes, path, true);
                }
                else if (response.S3Objects.Count > 0)
                {
                    response.S3Objects.ForEach(x => WriteItemObject(x, path, false));

                    
                }
            }
            else
            {
                //WriteItemObject("test" + " " + bucket + " " + key, path, true);
                //GetItem(path);
                var request = new Amazon.S3.Model.ListObjectsV2Request()
                {
                    BucketName = bucket,
                    Prefix = key + "/",
                    Delimiter = "/",
                };
                var response = client.ListObjectsV2Async(request).GetAwaiter().GetResult();
                if (response.CommonPrefixes.Count > 0)
                {
                    WriteItemObject(response.CommonPrefixes, path, true);
                }
                else if (response.S3Objects.Count > 0)
                {
                    response.S3Objects.ForEach(x => WriteItemObject(x, path, false));
                }
            }

            //WriteItemObject(path, path, true);
        }

        //protected override void GetChildNames(string path, ReturnContainers returnContainers)
        //{
        //    WriteItemObject("childName", path, true);
        //}

        protected override bool HasChildItems(string path)
        {
            return true;
                //GcsPath gcsPath = GcsPath.Parse(path);
            //switch (gcsPath.Type)
            //{
            //    case GcsPath.GcsPathType.Drive:
            //        return true;
            //    case GcsPath.GcsPathType.Bucket:
            //    case GcsPath.GcsPathType.Object:
            //        return GetBucketModel(gcsPath.Bucket).HasChildren(gcsPath.ObjectPath);
            //    default:
            //        throw new InvalidOperationException($"Unknown Path Type {gcsPath.Type}");
            //}
        }

        protected override void GetItem(string path)
        {
            WriteItemObject("get-item" + path, path, true);
            (string bucket, string key) = SplitS3Path(path);

            var driveInfo = this.PSDriveInfo as AmazonS3DriveInfo;
            var client = driveInfo.Client;

            if (string.IsNullOrEmpty(bucket))
            {
                //client.ListBucketsAsync(request).GetAwaiter().GetResult();

                WriteItemObject(PSDriveInfo, path, true);
            }
            //else if (string.IsNullOrEmpty(key))
            //{
            //    var request = new ListBucketsRequest();
            //    var response = client.ListBucketsAsync(request).GetAwaiter().GetResult();
            //    WriteItemObject(response.Buckets.Where(b => b.BucketName == bucket).ToList(), path, true);
            //}
            //else
            //{
            //    var request = new Amazon.S3.Model.ListObjectsV2Request()
            //    {
            //        BucketName = bucket,
            //        Prefix = key,
            //        Delimiter = "/",
            //    };
            //    var response = client.ListObjectsV2Async(request).GetAwaiter().GetResult();
            //    if (response.CommonPrefixes.Count > 0)
            //    {
            //        WriteItemObject(response.CommonPrefixes, path, true);
            //    }
            //    else if (response.S3Objects.Count > 0)
            //    {
            //        WriteItemObject(response.S3Objects, path, true);
            //    }
            //}



            //var pathSplit = path.Split(new char[] { pathSeparator /*'\\'*/ });

            //string profileName = "psp";
            //new CredentialProfileStoreChain(null).TryGetProfile(profileName, out CredentialProfile profile);
            //var creadentails = profile.GetAWSCredentials(profile.CredentialProfileStore) as Amazon.Runtime.SSOAWSCredentials;


            ////var client = CreateClient(creadentails, Amazon.RegionEndpoint.EUWest1);
            //var driveInfo = this.PSDriveInfo as AmazonS3DriveInfo;
            //var client = driveInfo.Client;


            //ListObjectsV2Request request = new ListObjectsV2Request
            //{
            //    BucketName = "psp-email-images"
            //};

            //var response = client.ListObjectsV2Async(request).GetAwaiter().GetResult();

            ////response.S3Objectsk
            //WriteItemObject(response.S3Objects.FirstOrDefault(), path, false);
        }

        //public static GcsPath Parse(string path)
        //{
        //    string bucket;
        //    string objectPath;
        //    if (string.IsNullOrEmpty(path))
        //    {
        //        bucket = null;
        //        objectPath = null;
        //    }
        //    else
        //    {
        //        int bucketLength = path.IndexOfAny(new[] { '/', '\\' });
        //        if (bucketLength < 0)
        //        {
        //            bucket = path;
        //            objectPath = null;
        //        }
        //        else
        //        {
        //            bucket = path.Substring(0, bucketLength);
        //            objectPath = path.Substring(bucketLength + 1).Replace("\\", "/");
        //        }
        //    }
        //    return new GcsPath(bucket, objectPath);
        //}

        //public GcsPathType Type
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(Bucket))
        //        {
        //            return GcsPathType.Drive;
        //        }
        //        else if (string.IsNullOrEmpty(ObjectPath))
        //        {
        //            return GcsPathType.Bucket;
        //        }
        //        else
        //        {
        //            return GcsPathType.Object;
        //        }
        //    }
        //}

        protected override bool IsItemContainer(string path)
        {
            return true;
        }

        private (string bucket, string s3Key) SplitS3Path(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return (null, null);
            }
                
            string[] s3Components = path.Split(new char[] { '\\', '/' }, 3);
            string bucket = s3Components[1];

            string s3Key = string.Empty;

            if (s3Components.Length > 2)
            {
                s3Key = s3Components[2];
            }
                
            return (bucket, s3Key);
        }

        private bool PathIsDrive(string path)
        {
            // Remove the drive name and first path separator.  If the 
            // path is reduced to nothing, it is a drive. Also if its
            // just a drive then there wont be any path separators
            //if (string.IsNullOrEmpty(path.Replace(this.PSDriveInfo.Root, "")) ||
            //    string.IsNullOrEmpty(path.Replace(this.PSDriveInfo.Root + pathSeparator, ""))
            if (string.IsNullOrEmpty(path) ||
                string.IsNullOrEmpty(path + pathSeparator))
            {
                return true;
            }
            
            
            return false;     
        }

        //protected override void GetChildItems(string path, bool recurse)
        //{
        //    GetItem(path);
        //}

        //    public static GcsPath Parse(string path)
        //    {
        //        string bucket;
        //        string objectPath;
        //        if (string.IsNullOrEmpty(path))
        //        {
        //            bucket = null;
        //            objectPath = null;
        //        }
        //        else
        //        {
        //            int bucketLength = path.IndexOfAny(new[] { '/', '\\' });
        //            if (bucketLength < 0)
        //            {
        //                bucket = path;
        //                objectPath = null;
        //            }
        //            else
        //            {
        //                bucket = path.Substring(0, bucketLength);
        //                objectPath = path.Substring(bucketLength + 1).Replace("\\", "/");
        //            }
        //        }
        //        return new GcsPath(bucket, objectPath);
        //    }

        //    public GcsPathType Type
        //    {
        //        get
        //        {
        //            if (string.IsNullOrEmpty(Bucket))
        //            {
        //                return GcsPathType.Drive;
        //            }
        //            else if (string.IsNullOrEmpty(ObjectPath))
        //            {
        //                return GcsPathType.Bucket;
        //            }
        //            else
        //            {
        //                return GcsPathType.Object;
        //            }
        //        }
        //    }
    }
}

#region AccessDBPSDriveInfo

/// <summary>
/// Any state associated with the drive should be held here.
/// In this case, it's the connection to the database.
/// </summary>
internal class AmazonS3DriveInfo : PSDriveInfo
{
    //private OdbcConnection connection;

    ///// <summary>
    ///// ODBC connection information.
    ///// </summary>
    //public OdbcConnection Connection
    //{
    //    get { return connection; }
    //    set { connection = value; }
    //}

    public IAmazonS3 Client { get; internal set; }

    private static AmazonS3DriveParameters _parameters;


    /// <summary>
    /// Constructor that takes one argument
    /// </summary>
    /// <param name="driveInfo">Drive provided by this provider</param>
    public AmazonS3DriveInfo(PSDriveInfo driveInfo)
        : base(driveInfo)
    { }

    public AmazonS3DriveInfo(string name, ProviderInfo provider, string root, string description, PSCredential credential, AmazonS3DriveParameters parameters)
        : base(name, provider, root, description, credential)
    {
        _parameters = parameters;
        Client = parameters.Client;
    }

    public AmazonS3DriveInfo(PSDriveInfo drive, AmazonS3DriveParameters parameters)
            : base(drive)
    {
        _parameters = parameters;
        Client = parameters.Client;
    }

    public string ProfileName => _parameters.ProfileName;

} // class AccessDBPSDriveInfo

public class AmazonS3DriveParameters : IAWSRegionArguments//, IAWSCredentialsArguments
{
    public object Region { get; set; }

    [Parameter(Mandatory = true)]
    public string ProfileName { get; set; }


    public AWSCredentials Credential { get; set; }


    public string ProfileLocation { get; }

    public RegionEndpoint RegionEndpoint { get; internal set; }
    public IAmazonS3 Client { get; internal set; }
}

#endregion AccessDBPSDriveInfo
