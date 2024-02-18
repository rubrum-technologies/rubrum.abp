using Rubrum.Abp.Graphql.Data;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Extensions;
using Rubrum.Abp.Graphql.Validation;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.Graphql.Types;

public static class EntityMutationTypeExtensions
{
    public static IObjectTypeDescriptor EntityMutationCreate<TEntityDto, TKey, TService, TCreateInput>(
        this IObjectTypeDescriptor descriptor,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
        where TService : ICreateAppService<TEntityDto, TCreateInput>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .Argument("input", a => a.Type<NonNullType<InputObjectType<TCreateInput>>>())
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .Resolve(context =>
            {
                var service = context.Service<TService>();
                return service.CreateAsync(context.ArgumentValue<TCreateInput>("input"));
            })
            .Type<NonNullType<ObjectType<TEntityDto>>>();

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityMutationUpdate<TEntityDto, TKey, TService, TUpdateInput>(
        this IObjectTypeDescriptor descriptor,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
        where TService : IUpdateAppService<TEntityDto, TKey, TUpdateInput>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .Argument("input", a => a.Type<NonNullType<InputObjectType<TUpdateInput>>>())
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .Resolve(context =>
            {
                var id = context.GetFiledKeyForInput<TKey>();
                var input = context.ArgumentValue<TUpdateInput>("input");
                var service = context.Service<TService>();

                return service.UpdateAsync(id, input);
            })
            .Type<NonNullType<ObjectType<TEntityDto>>>();

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityMutationDelete<TEntityDto, TKey, TService>(
        this IObjectTypeDescriptor descriptor,
        string typeName,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
        where TService : IDeleteAppService<TKey>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .Argument("id", a => a.Type<NonNullType<InputObjectType<TKey>>>().ID(typeName))
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .Resolve(async context =>
            {
                var id = context.ArgumentValue<TKey>("id");
                var service = context.Service<TService>();
                var dataLoader = context.Service<IAbpDataLoader<TEntityDto, TKey>>();

                var entity = await dataLoader.LoadAsync(id, context.RequestAborted);
                await service.DeleteAsync(id);
                return entity;
            })
            .Type<NonNullType<ObjectType<TEntityDto>>>();

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityMutation<TEntityDto, TKey, TService, TCreateInput, TUpdateInput>(
        this IObjectTypeDescriptor descriptor,
        EntityMutationOptions options)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
        where TService : ICreateUpdateAppService<TEntityDto, TKey, TCreateInput, TUpdateInput>, IDeleteAppService<TKey>
    {
        var typeName = options.TypeName;
        var typeNameSingular = options.TypeNameSingular;
        var isAuthorize = options.IsAuthorize;

        descriptor
            .Name(OperationTypeNames.Mutation)
            .EntityMutationCreate<TEntityDto, TKey, TService, TCreateInput>($"create{typeNameSingular}", isAuthorize)
            .EntityMutationUpdate<TEntityDto, TKey, TService, TUpdateInput>($"update{typeNameSingular}", isAuthorize)
            .EntityMutationDelete<TEntityDto, TKey, TService>(typeName, $"delete{typeNameSingular}", isAuthorize);

        return descriptor;
    }
}
