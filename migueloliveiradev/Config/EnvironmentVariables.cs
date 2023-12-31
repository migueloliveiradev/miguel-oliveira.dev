﻿namespace migueloliveiradev.Config;

public static class EnvironmentVariables
{
    public static void ConfigureEnvironmentVariables(this WebApplicationBuilder app)
    {
        if (!File.Exists(".env"))
        {
            Console.WriteLine("File .env not found");
            return;
        }
        foreach (string line in File.ReadAllLines(".env").Where(p => !p.StartsWith('#') || string.IsNullOrWhiteSpace(p)))
        {
            string[] parts = line.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
        Environment.SetEnvironmentVariable("WEB_ROOT_PATH", app.Environment.WebRootPath);
    }
}
