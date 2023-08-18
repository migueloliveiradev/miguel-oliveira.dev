namespace migueloliveiradev.Config;

public static class StatusCode
{
    public static void UseStatusCode(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            await next();
            if (context.Response.StatusCode == 404)
            {
                context.Request.Path = "/404";
                await next();
            }
        });
    }
}
