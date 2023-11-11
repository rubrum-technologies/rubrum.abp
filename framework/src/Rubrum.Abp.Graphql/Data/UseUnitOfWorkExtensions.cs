using HotChocolate.Resolvers;
using HotChocolate.Types.Descriptors.Definitions;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace Rubrum.Abp.Graphql.Data;

public static class UseUnitOfWorkExtensions
{
    public static IObjectFieldDescriptor UseUnitOfWork(this IObjectFieldDescriptor descriptor)
    {
        var placeholder = new FieldMiddlewareDefinition(next => async context =>
            {
                var unitOfWorkManager = context.Services.GetRequiredService<IUnitOfWorkManager>();
                using var uow = unitOfWorkManager.Begin(true, true);
                await next(context).ConfigureAwait(false);
                await uow.CompleteAsync(context.RequestAborted);
            },
            key: "Rubrum.Abp.Graphql.UnitOfWorkMiddleware");

        descriptor.Extend().Definition.MiddlewareDefinitions.Add(placeholder);

        descriptor
            .Extend()
            .OnBeforeCreate((_, definition) =>
            {
                var resultType = AsyncHelper.UnwrapTask(definition.ResultType!);

                if (!resultType.IsGenericType)
                {
                    return;
                }

                var genericType = resultType.GenericTypeArguments.First();
                if (resultType == typeof(IQueryable<>).MakeGenericType(genericType))
                {
                    definition.Configurations.Add(new CompleteConfiguration<ObjectFieldDefinition>(
                        (_, def) =>
                        {
                            var middlewareType = typeof(UnitOfWorkMiddleware<>).MakeGenericType(
                                genericType);
                            var middleware = FieldClassMiddlewareFactory.Create(middlewareType);
                            var index = def.MiddlewareDefinitions.IndexOf(placeholder);
                            def.MiddlewareDefinitions[index] = new FieldMiddlewareDefinition(middleware,
                                key: "Rubrum.Abp.Graphql.UnitOfWorkMiddleware");
                        },
                        definition,
                        ApplyConfigurationOn.BeforeCompletion));
                }
            });

        return descriptor;
    }
}