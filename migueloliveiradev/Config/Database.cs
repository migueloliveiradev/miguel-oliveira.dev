using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;

namespace migueloliveiradev.Config;

public static class Database
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
}
