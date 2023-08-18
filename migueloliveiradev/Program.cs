using Hangfire;
using migueloliveiradev.Config;
using migueloliveiradev.Utilities.Hangfire;

namespace migueloliveiradev;

public class Program
{
    public static async Task Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddHangfire(x => x.UseSqlServerStorage(Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_JOBS")));
        builder.Services.AddHangfireServer();
        builder.Services.AddOutputCache();
        builder.Services.AddHealthChecks();
        builder.ConfigureEnvironmentVariables();
        builder.Services.ConfigureDbContext();
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureDependencyInjection();
        builder.Services.ConfigureWebOptimizer();

        WebApplication app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.ApplyMigrations();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseOutputCache();
        }

        app.UseStatusCode();

        await app.ConfigureUserIdentity();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
       
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseHangfireDashboard("/dashboard/hangfire", new DashboardOptions
        {
            Authorization = new[] { new AuthorizationFilter() }
        });

        app.MapControllers();
        app.UseWebOptimizer();

        app.Run();
    }
}
