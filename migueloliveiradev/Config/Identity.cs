using Microsoft.AspNetCore.Identity;
using migueloliveiradev.Database;

namespace migueloliveiradev.Config;

public static class Identity
{
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

    public static async void ConfigureUserIdentity(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        if (!userManager.Users.Any())
        {
            IdentityUser user = new(Environment.GetEnvironmentVariable("DEFAULT_USERNAME")!)
            {
                Email = Environment.GetEnvironmentVariable("DEFAULT_EMAIL")!,
                EmailConfirmed = true,
            };
           var re = await userManager.CreateAsync(
                user,
                Environment.GetEnvironmentVariable("DEFAULT_PASSWORD")!);   
            Console.WriteLine(re);
        }
    }
}