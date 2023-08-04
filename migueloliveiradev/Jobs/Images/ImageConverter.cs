using migueloliveiradev.Services.Storage;
using SixLabors.ImageSharp;

namespace migueloliveiradev.Jobs.Images;

public class ImageConverter : IImageConverter
{
    private readonly IStorageService storageService;
    public ImageConverter(IStorageService storageService)
    {
        this.storageService = storageService;
    }
    public async Task ConverterToWebp(byte[] file, string contentType, string file_name)
    {
        Console.WriteLine("Convertendo para webp");
        using var fileStream = new MemoryStream(file);
        using Image image = await Image.LoadAsync(fileStream);
        using MemoryStream fileWebp = new();
        await image.SaveAsWebpAsync(fileWebp);
        await storageService.UploadImage(fileWebp, contentType, file_name);
    }
}
