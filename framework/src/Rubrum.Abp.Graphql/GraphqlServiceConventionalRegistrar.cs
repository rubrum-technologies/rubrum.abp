using Rubrum.Abp.Graphql.Services;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Graphql;

public class GraphqlServiceConventionalRegistrar : DefaultConventionalRegistrar
{
    protected override bool IsConventionalRegistrationDisabled(Type type)
    {
        return !Array.Exists(type.GetInterfaces(), IsIReadOnlyGraphqlService) || base.IsConventionalRegistrationDisabled(type);
    }

    protected override List<Type> GetExposedServiceTypes(Type type)
    {
        var readOnlyGraphqlService = type
            .GetInterfaces()
            .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IReadOnlyGraphqlService<,>));

        return new List<Type> { type, readOnlyGraphqlService };
    }

    private static bool IsIReadOnlyGraphqlService(Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IReadOnlyGraphqlService<,>);
    }
}
