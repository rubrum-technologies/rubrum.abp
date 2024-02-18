using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using Rubrum.Abp.Graphql.Data;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public static class EntityQueryTypeExtensions
{
    public static IObjectTypeDescriptor EntityQueryById<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string typeName,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .UseUnitOfWork()
            .Argument("id", x => x.Type(typeof(TKey)).ID(typeName))
            .ResolveWith<Resolves>(x => x.GetByIdAsync<TEntityDto, TKey>(default!, default!, default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryGet<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .UseUnitOfWork()
            .UseFirstOrDefault()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryGetList<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .UseUnitOfWork()
            .UsePaging()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .UseSorting<SortInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryAll<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .UseUnitOfWork()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .UseSorting<SortInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryAny<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .UseUnitOfWork()
            .UseAny()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryCount<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName,
        bool isAuthorize)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        var field = descriptor.Field(fieldName);

        if (isAuthorize)
        {
            field.Authorize();
        }

        field
            .UseUnitOfWork()
            .UseCount()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQuery<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        EntityQueryOptions options)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        var typeName = options.TypeName;
        var typeNameSingular = options.TypeNameSingular;
        var typeNameInPlural = options.TypeNameInPlural;
        var isAuthorize = options.IsAuthorize;

        descriptor
            .Name(OperationTypeNames.Query)
            .EntityQueryById<TEntityDto, TKey>(typeName, $"{typeNameSingular.ToLowerFirstChar()}ById", isAuthorize)
            .EntityQueryGet<TEntityDto, TKey>(typeNameSingular.ToLowerFirstChar(), isAuthorize)
            .EntityQueryGetList<TEntityDto, TKey>(typeNameInPlural.ToLowerFirstChar(), isAuthorize)
            .EntityQueryAny<TEntityDto, TKey>($"{typeNameInPlural.ToLowerFirstChar()}Any", isAuthorize)
            .EntityQueryCount<TEntityDto, TKey>($"{typeNameInPlural.ToLowerFirstChar()}Count", isAuthorize);

        if (options.IsAddFieldByAll)
        {
            descriptor.EntityQueryAll<TEntityDto, TKey>($"{typeNameInPlural.ToLowerFirstChar()}All", isAuthorize);
        }

        return descriptor;
    }

    private sealed class Resolves
    {
        public Task<TEntityDto> GetByIdAsync<TEntityDto, TKey>(
            TKey id,
            IAbpDataLoader<TEntityDto, TKey> dataLoader,
            CancellationToken cancellationToken)
            where TKey : notnull
            where TEntityDto : IEntityDto<TKey>
        {
            return dataLoader.LoadAsync(id, cancellationToken);
        }

        public Task<IQueryable<TEntityDto>> GetQueryableAsync<TEntityDto, TKey>(
            [Service] IReadOnlyGraphqlService<TEntityDto, TKey> service)
            where TKey : notnull
            where TEntityDto : IEntityDto<TKey>
        {
            return service.GetQueryableAsync();
        }
    }
}
