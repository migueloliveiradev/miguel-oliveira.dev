using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Oci.Common;
using Oci.Common.Auth;
using Oci.ObjectstorageService;
using Oci.ObjectstorageService.Requests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;

namespace migueloliveiradev.Services.Project;

public class ImagemService
{
    private readonly static SimpleAuthenticationDetailsProvider config = new()
    {
        Fingerprint = Environment.GetEnvironmentVariable("OCI_FINGERPRINT"),
        UserId = Environment.GetEnvironmentVariable("OCI_USER_ID"),
        TenantId = Environment.GetEnvironmentVariable("OCI_TENANT_ID"),
        PrivateKeySupplier = new StringPrivateKeySupplier(Environment.GetEnvironmentVariable("OCI_KEY_FILE_CONTENT")!),
        Region = Region.FromRegionId(Environment.GetEnvironmentVariable("OCI_REGION_ID")),
    };

    private readonly static ObjectStorageClient osClient = new(config);

    public static async Task UploadImageStorage(Stream file, string contentType, string file_name, string file_name_webp)
    {
        Stream imageWebp = await ConverterImageToWebp(file);
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            await UploadImageLocal(file, file_name);
            await UploadImageLocal(imageWebp, file_name_webp);
            return;
        }

        await UploadImageCloud(file, contentType, file_name);
        return;
    }

    public static async Task DeleteImageStorage(string url)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            await DeleteImageLocal(url);
        }
        else
        {
            await DeleteImageCloud(url);
        }
    }

    private static async Task DeleteImageCloud(string name)
    {
        DeleteObjectRequest deleteObjectRequest = new()
        {
            BucketName = Environment.GetEnvironmentVariable("BUCKET_NAME"),
            NamespaceName = Environment.GetEnvironmentVariable("NAMESPACE_NAME"),
            ObjectName = $"projects/{name}"
        };
        await osClient.DeleteObject(deleteObjectRequest);
        return;
    }

    private static Task DeleteImageLocal(string name)
    {
        string path = Path.Combine(Environment.GetEnvironmentVariable("WEB_ROOT_PATH")!, "img", "projects", name);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        return Task.CompletedTask;
    }

    private static async Task UploadImageCloud(Stream file, string contentType, string file_name)
    {
        PutObjectRequest putObjectRequest = new()
        {
            BucketName = Environment.GetEnvironmentVariable("BUCKET_NAME"),
            NamespaceName = Environment.GetEnvironmentVariable("NAMESPACE_NAME"),
            ObjectName = $"projects/{file_name}",
            PutObjectBody = file,
            ContentType = contentType
        };
        await osClient.PutObject(putObjectRequest);

        return;
    }

    private static async Task UploadImageLocal(Stream file, string file_name)
    {
        string path = Path.Combine(Environment.GetEnvironmentVariable("WEB_ROOT_PATH")!, "img", "projects");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        using FileStream fs = new(Path.Combine(path, file_name), FileMode.Create);
        file.Seek(0, SeekOrigin.Begin);
        await file.CopyToAsync(fs);
        return;
    }

    private static async Task<Stream> ConverterImageToWebp(Stream stream)
    {
        using Image image = await Image.LoadAsync(stream);

        using (MemoryStream imageWebp = new())
        {
            await image.SaveAsync(imageWebp, new WebpEncoder() { Quality = 100 });
            return new MemoryStream(imageWebp.ToArray());
        };
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
