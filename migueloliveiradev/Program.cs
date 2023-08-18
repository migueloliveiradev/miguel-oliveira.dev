using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using migueloliveiradev.Config;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace migueloliveiradev;

public class Program
{
    public static void Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddHangfire(x => x.UseMemoryStorage());
        builder.Services.AddHangfireServer();
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
        }

        app.UseStatusCode();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseHangfireDashboard();

        app.UseAuthorization();
        app.MapControllers();
        app.UseWebOptimizer();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
