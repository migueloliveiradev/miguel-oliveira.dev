namespace migueloliveiradev.Services.Storage;

public interface IStorageService
{
    Task UploadImage(Stream file, string contentType, string file_name);
    Task DeleteImage(string name);
}
