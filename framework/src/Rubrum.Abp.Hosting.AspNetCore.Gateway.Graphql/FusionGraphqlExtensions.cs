using Microsoft.Extensions.DependencyInjection;

namespace Rubrum.Abp.Hosting;

public static class FusionGraphqlExtensions
{
    public static FusionGatewayBuilder GetFusion(this IServiceCollection services)
    {
        return services.GetSingletonInstance<FusionGatewayBuilder>();
    }
}
