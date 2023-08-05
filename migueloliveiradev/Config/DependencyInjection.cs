using migueloliveiradev.Jobs.Images;
using migueloliveiradev.Repositories.Abouts;
using migueloliveiradev.Repositories.Contacts;
using migueloliveiradev.Repositories.Home.Dashboard;
using migueloliveiradev.Repositories.Home;
using migueloliveiradev.Repositories.SocialNetworks;
using migueloliveiradev.Repositories.Works.Projects.Images;
using migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;
using migueloliveiradev.Repositories.Works.Projects.Technologies;
using migueloliveiradev.Repositories.Works.Services;
using migueloliveiradev.Services.Project;
using migueloliveiradev.Services.Storage;

namespace migueloliveiradev.Config;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IProjectsRepository, ProjectsRepository>();
        services.AddScoped<IAboutRepository, AboutRepository>();
        services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
        services.AddScoped<IImagesRepository, ImagesRepository>();
        services.AddScoped<ITechnologyRepository, TechnologyRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IHomeRepository, HomeRepository>();
        services.AddScoped<IHomeDashboardRepository, HomeDashboardRepository>();
        services.AddScoped<IImageConverter, ImageConverter>();
        services.AddScoped<IImageService, ImagemService>();
        services.AddScoped<IStorageService, StorageService>();

        return services;
    }
}
