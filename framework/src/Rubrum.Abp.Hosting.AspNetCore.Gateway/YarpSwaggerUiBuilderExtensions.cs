using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Yarp.ReverseProxy.Configuration;

namespace Rubrum.Abp.Hosting;

public static class YarpSwaggerUiBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerUiWithYarp(
        this IApplicationBuilder app,
        ApplicationInitializationContext context)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "api/swagger";
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            var proxyConfig = context.ServiceProvider.GetRequiredService<IProxyConfigProvider>().GetConfig();

            foreach (var clusterId in proxyConfig.Clusters.Select(x => x.ClusterId))
            {
                options.SwaggerEndpoint(
                    $"/api/{clusterId.ToLower()}/swagger/v1/swagger.json",
                    $"{clusterId} API");
                options.OAuthClientId(configuration["Swagger:ClientId"]);
                options.OAuthClientSecret(configuration["Swagger:ClientSecret"]);
            }
        });

        return app;
    }
}
