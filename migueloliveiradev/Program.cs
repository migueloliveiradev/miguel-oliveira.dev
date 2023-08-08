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
        Console.WriteLine(Environment.GetEnvironmentVariable("MYSQL_CONNECTION"));
        builder.Services.ConfigureDbContext();
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureDependencyInjection();
        builder.Services.ConfigureWebOptimizer();

        WebApplication app = builder.Build();
        app.ConfigureUserIdentity();
        Console.WriteLine(app.Environment.IsDevelopment());
        if (!app.Environment.IsDevelopment())
        {
            app.ApplyMigrations();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

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