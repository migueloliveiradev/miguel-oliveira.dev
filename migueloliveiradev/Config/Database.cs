using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;

namespace migueloliveiradev.Config;

public static class Database
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
    {
        string connection = Environment.GetEnvironmentVariable("MYSQL_CONNECTION")!;

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            options.UseLazyLoadingProxies();
            options.UseSnakeCaseNamingConvention();
        });

        return services;
    }

    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        DatabaseContext context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();
        return app;
    }
}
