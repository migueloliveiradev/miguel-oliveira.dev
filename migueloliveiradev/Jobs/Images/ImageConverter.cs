using migueloliveiradev.Repositories.Works.Projects.Images;
using migueloliveiradev.Services.Storage;
using SixLabors.ImageSharp;
using ImageModel = migueloliveiradev.Models.Works.Projetos.Image;

namespace migueloliveiradev.Jobs.Images;

public class ImageConverter : IImageConverter
{
    private readonly IStorageService storageService;
    private readonly IImagesRepository imagesRepository;
    public ImageConverter(IStorageService storageService, IImagesRepository imagesRepository)
    {
        this.storageService = storageService;
        this.imagesRepository = imagesRepository;
    }
    public async Task ConverterToWebp(int file_id, string file_name)
    {
        ImageModel image = imagesRepository.GetById(file_id);
        using Stream file = await storageService.GetImage(image.Name);
        using Image imageLoad = await Image.LoadAsync(file);
        using MemoryStream fileWebp = new();
        await imageLoad.SaveAsWebpAsync(fileWebp);
        string new_name = $"{file_name}.webp";
        await storageService.UploadImage(fileWebp, "image/webp", new_name);
        await storageService.DeleteImage(image.Name);
        image.Name = new_name;
        imagesRepository.Update(image);
    }
}
