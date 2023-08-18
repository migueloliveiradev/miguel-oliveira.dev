using Oci.Common;
using Oci.Common.Auth;
using Oci.ObjectstorageService;
using Oci.ObjectstorageService.Requests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace migueloliveiradev.Services.Storage;

public class StorageService : IStorageService
{
    private readonly SimpleAuthenticationDetailsProvider config;
    private readonly ObjectStorageClient osClient;
    private readonly bool isDevelopment;
    public StorageService()
    {
        config = new()
        {
            Fingerprint = Environment.GetEnvironmentVariable("OCI_FINGERPRINT"),
            UserId = Environment.GetEnvironmentVariable("OCI_USER_ID"),
            TenantId = Environment.GetEnvironmentVariable("OCI_TENANT_ID"),
            PrivateKeySupplier = new StringPrivateKeySupplier(Environment.GetEnvironmentVariable("OCI_KEY_FILE_CONTENT")!),
            Region = Region.FromRegionId(Environment.GetEnvironmentVariable("OCI_REGION_ID")),
        };
        osClient = new(config);
        isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    }

    public Task UploadImage(Stream file, string contentType, string file_name)
    {
        if (!isDevelopment)
        {
            return UploadImageCloud(file, contentType, file_name);
        }
        return UploadImageLocal(file, file_name);
    }

    private Task UploadImageCloud(Stream file, string contentType, string file_name)
    {
        PutObjectRequest putObjectRequest = new()
        {
            BucketName = Environment.GetEnvironmentVariable("BUCKET_NAME"),
            NamespaceName = Environment.GetEnvironmentVariable("NAMESPACE_NAME"),
            ObjectName = $"projects/{file_name}",
            PutObjectBody = file,
            ContentType = contentType
        };
        return osClient.PutObject(putObjectRequest);
    }

    private async Task UploadImageLocal(Stream file, string file_name)
    {
        string path = Path.Combine(Environment.GetEnvironmentVariable("WEB_ROOT_PATH")!, "img", "projects", file_name);
        using FileStream output = new(path, FileMode.Create);
        file.Position = 0;
        file.Seek(0, SeekOrigin.Begin);
        await file.CopyToAsync(output);
    }

    public Task DeleteImage(string name)
    {
        if (isDevelopment)
        {
            return DeleteImageLocal(name);
        }
        return DeleteImageCloud(name);
    }

    private async Task DeleteImageCloud(string name)
    {
        DeleteObjectRequest deleteObjectRequest = new()
        {
            BucketName = Environment.GetEnvironmentVariable("BUCKET_NAME"),
            NamespaceName = Environment.GetEnvironmentVariable("NAMESPACE_NAME"),
            ObjectName = $"projects/{name}"
        };
        await osClient.DeleteObject(deleteObjectRequest);
    }

    private Task DeleteImageLocal(string name)
    {
        string path = Path.Combine(Environment.GetEnvironmentVariable("WEB_ROOT_PATH")!, "img", "projects", name);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        return Task.CompletedTask;
    }
}

public class StringPrivateKeySupplier : ISupplier<RsaKeyParameters>
{
    private readonly string _privateKey;

    public StringPrivateKeySupplier(string privateKey)
    {
        _privateKey = privateKey;
    }

    public RsaKeyParameters GetKey()
    {
        using (TextReader privateKeyTextReader = new StringReader(_privateKey))
        {
            var pemReader = new PemReader(privateKeyTextReader);
            return (RsaKeyParameters)pemReader.ReadObject();
        }
    }
}