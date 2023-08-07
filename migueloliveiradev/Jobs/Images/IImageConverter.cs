namespace migueloliveiradev.Jobs.Images;

public interface IImageConverter
{
    Task ConverterToWebp(byte[] file, string contentType, string file_name);
}
