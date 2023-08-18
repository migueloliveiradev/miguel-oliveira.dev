using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace migueloliveiradev.Utilities.Hangfire;

public class AuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        HttpContext httpContext = context.GetHttpContext();

        return httpContext.User.Identity!.IsAuthenticated;
    }
}
