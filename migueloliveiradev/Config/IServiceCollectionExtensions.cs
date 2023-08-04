using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Jobs.Images;
using migueloliveiradev.Repositories.Abouts;
using migueloliveiradev.Repositories.Contacts;
using migueloliveiradev.Repositories.Home;
using migueloliveiradev.Repositories.Home.Dashboard;
using migueloliveiradev.Repositories.SocialNetworks;
using migueloliveiradev.Repositories.Works.Projects.Images;
using migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;
using migueloliveiradev.Repositories.Works.Projects.Technologies;
using migueloliveiradev.Repositories.Works.Services;
using migueloliveiradev.Services.Project;
using migueloliveiradev.Services.Storage;

namespace migueloliveiradev.Config;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, ConfigurationManager config)
    {
        string connection = config.GetConnectionString("MYSQL_CONNECTION")!;
        services.AddDbContext<DatabaseUsersContext>(options =>
        {
            options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            options.UseLazyLoadingProxies();
        });

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            options.UseLazyLoadingProxies();
        });

        return services;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<DatabaseUsersContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            options.User.RequireUniqueEmail = true;
        });

        services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "token_auth";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(90);
                options.LoginPath = "/dashboard/login";
                options.AccessDeniedPath = "/";
                options.SlidingExpiration = true;
            });

        return services;
    }

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
