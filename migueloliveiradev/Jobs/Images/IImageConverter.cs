namespace migueloliveiradev.Jobs.Images;

public interface IImageConverter
{
    Task ConverterToWebp(int file_id, string file_name);
}
