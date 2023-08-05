﻿using NUglify.Css;
using NUglify.JavaScript;

namespace migueloliveiradev.Config;

public static class MinifyFiles
{
    public static IServiceCollection ConfigureWebOptimizer(this IServiceCollection services)
    {
        services.AddWebOptimizer(pipeline =>
        {
            pipeline.AddCssBundle("/css/all.min.css", 
                new CssSettings() { CommentMode = CssComment.None, IgnoreAllErrors = true },
                "/lib/bootstrap/css/bootstrap.css",
                "/lib/font-awesome/css/all.css",
                
                "/css/dashboard/table.css",
                "/css/dashboard/login.css",
                "/css/dashboard/cards.css");
            //"/css/site.css"


            pipeline.AddJavaScriptBundle("/js/all.min.js", 
                new CodeSettings() { MinifyCode = true, PreserveImportantComments = false, IgnoreAllErrors = true },
                "/lib/bootstrap/js/bootstrap.js");
            
        });
        return services;
    }
}
