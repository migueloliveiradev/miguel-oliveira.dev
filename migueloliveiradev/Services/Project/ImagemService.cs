using Hangfire;
using migueloliveiradev.Jobs.Images;
using migueloliveiradev.Services.Storage;
using Oci.Common.Auth;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace migueloliveiradev.Services.Project;

public class ImagemService : IImageService
{
    private readonly IStorageService storageService;
    public ImagemService(IStorageService storageService)
    {
        this.storageService = storageService;
    }
    public async Task UploadImage(Stream file, string contentType, string file_id)
    {
        string file_name = $"{file_id}{contentType.Replace("image/", ".")}";
        MemoryStream memoryStream = new();
        await file.CopyToAsync(memoryStream);
        BackgroundJob.Enqueue<IImageConverter>(x => x.ConverterToWebp(memoryStream.ToArray(), contentType, $"{file_id}.webp"));
        await storageService.UploadImage(file, contentType, file_name);
    }
    public async Task DeleteImage(string name)
    {
        await storageService.DeleteImage(name);
    }
}
