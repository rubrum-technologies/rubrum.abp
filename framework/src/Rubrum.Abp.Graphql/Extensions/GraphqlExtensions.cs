using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rubrum.Abp.Graphql.Extensions;

public static class GraphqlExtensions
{
    public static IRequestExecutorBuilder GetGraphql(this IServiceCollection services)
    {
        return services.GetSingletonInstance<IRequestExecutorBuilder>();
    }
}
