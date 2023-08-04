namespace migueloliveiradev.Services.Project;

public interface IImageService
{
    Task UploadImage(Stream file, string contentType, string file_id);
    Task DeleteImage(string name);
}
