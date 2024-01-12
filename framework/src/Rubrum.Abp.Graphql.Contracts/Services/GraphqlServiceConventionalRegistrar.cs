using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Graphql.Services;

public class GraphqlServiceConventionalRegistrar : DefaultConventionalRegistrar
{
    protected override bool IsConventionalRegistrationDisabled(Type type)
    {
        var interfaces = type.GetInterfaces();

        return !Array.Exists(
                   interfaces,
                   x => x.IsGenericType &&
                        (x.GetGenericTypeDefinition() == typeof(IReadOnlyGraphqlService<,>) ||
                         x.GetGenericTypeDefinition() == typeof(ICrudGraphqlService<,,,>)));
    }

    protected override ServiceLifetime? GetDefaultLifeTimeOrNull(Type type)
    {
        return ServiceLifetime.Transient;
    }

    protected override List<Type> GetExposedServiceTypes(Type type)
    {
        var result = base.GetExposedServiceTypes(type);

        var readOnlyGraphqlService = FindReadOnlyGraphqlService(type);
        var crudGraphqlService = FindCrudGraphqlService(type);

        if (readOnlyGraphqlService is not null)
        {
            result.Add(readOnlyGraphqlService);
        }

        if (crudGraphqlService is not null)
        {
            result.Add(crudGraphqlService);
        }

        return result;
    }

    private static Type? FindReadOnlyGraphqlService(Type type)
    {
        var interfaces = type.GetInterfaces();

        return Array.Find(
            interfaces,
            x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IReadOnlyGraphqlService<,>));
    }

    private static Type? FindCrudGraphqlService(Type type)
    {
        var interfaces = type.GetInterfaces();

        return Array.Find(
            interfaces,
            x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICrudGraphqlService<,,,>));
    }
}
