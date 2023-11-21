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

            foreach (var cluster in proxyConfig.Clusters)
            {
                options.SwaggerEndpoint($"/api/{cluster.ClusterId.ToLower()}/swagger/v1/swagger.json",
                    $"{cluster.ClusterId} API");
                options.OAuthClientId(configuration["Swagger:ClientId"]);
                options.OAuthClientSecret(configuration["Swagger:ClientSecret"]);
            }
        });

        return app;
    }
}
