using HotChocolate.Fusion.Clients;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Rubrum.Abp.Hosting;

[DependsOn(typeof(RubrumAbpHostingAspNetCoreModule))]
public class RubrumAbpHostingAspNetCoreGatewayGraphqlModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services
            .AddSingleton<IGraphQLClientFactory, GraphQlClientFactory>()
            .AddSingleton<IGraphQLSubscriptionClientFactory, GraphQlSubscriptionClientFactory>()
            .AddFusionGatewayServer()
            .ConfigureFromFile("./gateway.fgp") // TODO: Put in options
            .UseDefaultPipeline();
    }
}
