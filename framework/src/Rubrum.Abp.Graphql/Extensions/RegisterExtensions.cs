using System.Reflection;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Services;
using Rubrum.Abp.Graphql.Types;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Reflection;

namespace Rubrum.Abp.Graphql.Extensions;

public static class RegisterExtensions
{
    private readonly static MethodInfo RegisterServiceMethod =
        typeof(RequestExecutorBuilderExtensions)
            .GetMethods()
            .First(x => x.Name == "RegisterService" && x.GetParameters().Length == 2);

    public static IRequestExecutorBuilder RegisterGraphqlTypes(this IRequestExecutorBuilder builder)
    {
        var services = builder.Services;
        var typeFinder = services.GetSingletonInstance<ITypeFinder>();

        var types = typeFinder.Types
            .Where(x => typeof(IGraphqlType).IsAssignableFrom(x) &&
                        x is { IsClass: true, IsPublic: true, IsAbstract: false, IsGenericParameter: false })
            .ToList();

        builder.AddTypes(types.ToArray());

        return builder;
    }

    public static IRequestExecutorBuilder RegisterDataLoaders(this IRequestExecutorBuilder builder)
    {
        var services = builder.Services;
        var types = GetEntityDtoTypes(services.GetSingletonInstance<ITypeFinder>());

        foreach (var type in types)
        {
            var keyType = GetKeyEntityDto(type);

            if (keyType is null)
            {
                continue;
            }

            var dataLoaderType = typeof(IAbpDataLoader<,>).MakeGenericType(type, keyType);
            services.AddScoped(
                dataLoaderType,
                typeof(AbpDataLoaderBase<,>).MakeGenericType(type, keyType));

            RegisterServiceMethod
                .MakeGenericMethod(dataLoaderType)
                .Invoke(null, new object?[] { builder, ServiceKind.Default });
        }

        return builder;
    }

    public static IRequestExecutorBuilder RegisterGraphqlServices(this IRequestExecutorBuilder builder)
    {
        var services = builder.Services;
        var typeFinder = services.GetSingletonInstance<ITypeFinder>();
        var types = typeFinder.Types
            .Where(x => typeof(IGraphqlService).IsAssignableFrom(x) &&
                        x is { IsInterface: true, IsGenericType: false })
            .ToList();

        foreach (var type in types)
        {
            RegisterServiceMethod
                .MakeGenericMethod(type)
                .Invoke(null, new object?[] { builder, ServiceKind.Default });
        }

        return builder;
    }

    private static List<Type> GetEntityDtoTypes(ITypeFinder typeFinder)
    {
        var types = typeFinder.Types
            .Where(IsEntityDtoType)
            .Select(x => x.BaseType!.GenericTypeArguments.First())
            .ToList();

        return types;
    }

    private static bool IsEntityDtoType(Type type)
    {
        if (!(type.IsSubclassOf(typeof(ObjectType)) || type.IsSubclassOf(typeof(InterfaceType))))
        {
            return false;
        }

        if (type is not { IsPublic: true, BaseType.GenericTypeArguments.Length: 1 })
        {
            return false;
        }

        var entityType = type.BaseType.GenericTypeArguments.First();
        return entityType is { IsClass: true } && typeof(IEntityDto).IsAssignableFrom(entityType);
    }

    private static Type? GetKeyEntityDto(Type type)
    {
        var entityInterface = type.GetInterfaces()
            .FirstOrDefault(x => typeof(IEntityDto).IsAssignableFrom(x) && x.GenericTypeArguments.Length == 1);
        return entityInterface?.GenericTypeArguments.First();
    }
}