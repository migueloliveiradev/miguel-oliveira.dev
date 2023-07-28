using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;

namespace migueloliveiradev.Config;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, ConfigurationManager config)
    {
        string connectionString = config.GetConnectionString("MYSQL_CONNECTION")!;
        services.AddDbContext<DatabaseUsersContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddDbContext<DatabaseContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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
}
