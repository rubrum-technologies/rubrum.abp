using Rubrum.Abp.Graphql.Services;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Graphql;

public class GraphqlServiceConventionalRegistrar : DefaultConventionalRegistrar
{
    protected override bool IsConventionalRegistrationDisabled(Type type)
    {
        return !type.GetInterfaces()
                   .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IReadOnlyGraphqlService<,>)) ||
               base.IsConventionalRegistrationDisabled(type);
    }

    protected override List<Type> GetExposedServiceTypes(Type type)
    {
        var readOnlyGraphqlService = type
            .GetInterfaces()
            .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IReadOnlyGraphqlService<,>));

        return new List<Type> { type, readOnlyGraphqlService };
    }
}