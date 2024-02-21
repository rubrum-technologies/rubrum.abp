using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Configuration;

namespace Rubrum.Abp.Hosting;

public static class YarpSwaggerUiBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerUiWithYarp(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var serviceProvider = app.ApplicationServices;

            options.RoutePrefix = "api/swagger";
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var proxyConfig = serviceProvider.GetRequiredService<IProxyConfigProvider>().GetConfig();

            var routes = proxyConfig.Routes;

            foreach (var route in routes)
            {
                if (route.Metadata?.TryGetValue("Swagger", out var url) == true)
                {
                    options.SwaggerEndpoint(
                        $"{url}/swagger/v1/swagger.json",
                        $"{route.ClusterId} API");
                    options.OAuthClientId(configuration["Swagger:ClientId"]);
                    options.OAuthClientSecret(configuration["Swagger:ClientSecret"]);
                }
            }
        });

        return app;
    }
}
