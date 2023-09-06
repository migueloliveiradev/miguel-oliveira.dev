using Hangfire;
using migueloliveiradev.Jobs.Images;
using migueloliveiradev.Services.Storage;

namespace migueloliveiradev.Services.Project;

public class ImagemService : IImageService
{
    private readonly IStorageService storageService;
    public ImagemService(IStorageService storageService)
    {
        this.storageService = storageService;
    }
    public async Task UploadImage(Stream file, string contentType, string file_name_id, int file_id)
    {
        string file_name = $"{file_name_id}{contentType.Replace("image/", ".")}";
        MemoryStream memoryStream = new();
        await file.CopyToAsync(memoryStream);
        await storageService.UploadImage(file, contentType, file_name);
        BackgroundJob.Enqueue<IImageConverter>(x => x.ConverterToWebp(file_id, file_name_id));
    }
    public async Task DeleteImage(string name)
    {
        await storageService.DeleteImage(name);
    }
}
