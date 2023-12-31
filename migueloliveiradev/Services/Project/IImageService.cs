﻿namespace migueloliveiradev.Services.Project;

public interface IImageService
{
    Task UploadImage(Stream file, string contentType, string file_name_id, int file_id);
    Task DeleteImage(string name);
}
