using Hangfire;
using Hangfire.MemoryStorage;
using migueloliveiradev.Config;

namespace migueloliveiradev;

public class Program
{
    public static void Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddHangfire(x => x.UseMemoryStorage());

        builder.Services.ConfigureDbContext(builder.Configuration);
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureDependencyInjection();
        builder.ConfigureEnvironmentVariables();

        WebApplication app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseHangfireDashboard();
        BackgroundJobServer server = new();

        app.UseAuthorization();
        app.MapControllers();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}