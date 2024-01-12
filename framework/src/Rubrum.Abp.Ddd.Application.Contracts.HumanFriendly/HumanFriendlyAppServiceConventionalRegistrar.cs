using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Rubrum.Abp.Ddd.HumanFriendly;

public class HumanFriendlyAppServiceConventionalRegistrar : DefaultConventionalRegistrar
{
    protected override bool IsConventionalRegistrationDisabled(Type type)
    {
        var interfaces = type.GetInterfaces();

        return !Array.Exists(
            interfaces,
            x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IHumanFriendlyAppService<,>));
    }

    protected override ServiceLifetime? GetDefaultLifeTimeOrNull(Type type)
    {
        return ServiceLifetime.Transient;
    }

    protected override List<Type> GetExposedServiceTypes(Type type)
    {
        var result = base.GetExposedServiceTypes(type);

        var humanFriendlyAppService = FindHumanFriendlyAppService(type);

        if (humanFriendlyAppService is not null)
        {
            result.Add(humanFriendlyAppService);
        }

        return result;
    }

    private static Type? FindHumanFriendlyAppService(Type type)
    {
        var interfaces = type.GetInterfaces();

        return Array.Find(
            interfaces,
            x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IHumanFriendlyAppService<,>));
    }
}
