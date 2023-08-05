using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;

namespace migueloliveiradev.Config;

public static class Database
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
    {
        string connection = Environment.GetEnvironmentVariable("MYSQL_CONNECTION")!;
        Console.WriteLine($"Connection: {connection}");
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

    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        DatabaseContext context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();
        DatabaseUsersContext usersContext = scope.ServiceProvider.GetRequiredService<DatabaseUsersContext>();
        usersContext.Database.Migrate();

        return app;
    }
}
