using Oci.Common;
using Oci.Common.Auth;
using Oci.ObjectstorageService;
using Oci.ObjectstorageService.Requests;
using System.Security;

namespace migueloliveiradev.Services.Projeto;

public class ImagemService
{
    private readonly static SimpleAuthenticationDetailsProvider config = new()
    {
        Fingerprint = Environment.GetEnvironmentVariable("OCI_FINGERPRINT"),
        UserId = Environment.GetEnvironmentVariable("OCI_USER_ID"),
        TenantId = Environment.GetEnvironmentVariable("OCI_TENANT_ID"),
        PrivateKeySupplier = new FilePrivateKeySupplier(Environment.GetEnvironmentVariable("OCI_KEY_FILE_PATH"), new SecureString()),
        Region = Region.FromRegionId(Environment.GetEnvironmentVariable("OCI_REGION_ID")),
    };

    private readonly static ObjectStorageClient osClient = new(config);

    public static async Task<string> AddImageStorage(Stream file, string contentType)
    {
        Guid name = Guid.NewGuid();
        PutObjectRequest putObjectRequest = new()
        {
            BucketName = Environment.GetEnvironmentVariable("BUCKET_NAME"),
            NamespaceName = Environment.GetEnvironmentVariable("NAMESPACE_NAME"),
            ObjectName = $"projects/{name}",
            PutObjectBody = file,
            ContentType = contentType
        };
        await osClient.PutObject(putObjectRequest);

        return GetObjectStorageUrl(name.ToString());
    }
    private static string GetObjectStorageUrl(string url)
    {
        return $"https://objectstorage.{Environment.GetEnvironmentVariable("OCI_REGION_ID")}" +
            $".oraclecloud.com/n/{Environment.GetEnvironmentVariable("NAMESPACE_NAME")}" +
            $"/b/{Environment.GetEnvironmentVariable("BUCKET_NAME")}/o/projects/{url}";
    }

    public static async Task DeleteImageStorage(string url)
    {
        string[] urlSplit = url.Split("/");
        string name = urlSplit[urlSplit.Length - 1];
        DeleteObjectRequest deleteObjectRequest = new()
        {
            BucketName = Environment.GetEnvironmentVariable("BUCKET_NAME"),
            NamespaceName = Environment.GetEnvironmentVariable("NAMESPACE_NAME"),
            ObjectName = $"projects/{name}"
        };
        await osClient.DeleteObject(deleteObjectRequest);
        return;
    }
}
