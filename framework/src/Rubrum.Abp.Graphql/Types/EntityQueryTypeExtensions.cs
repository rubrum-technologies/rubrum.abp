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
        string fieldName)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Field(fieldName)
            .UseUnitOfWork()
            .Argument("id", x => x.Type(typeof(TKey)).ID(typeName))
            .ResolveWith<Resolves>(x => x.GetByIdAsync<TEntityDto, TKey>(default!, default!, default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryGet<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Field(fieldName)
            .UseUnitOfWork()
            .UseFirstOrDefault()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryGetList<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Field(fieldName)
            .UseUnitOfWork()
            .UsePaging()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .UseSorting<SortInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryAll<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Field(fieldName)
            .UseUnitOfWork()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .UseSorting<SortInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryAny<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Field(fieldName)
            .UseUnitOfWork()
            .UseAny()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQueryCount<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string fieldName)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Field(fieldName)
            .UseUnitOfWork()
            .UseCount()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync<TEntityDto, TKey>(default!));

        return descriptor;
    }

    public static IObjectTypeDescriptor EntityQuery<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string typeName,
        string typeNameSingular,
        string typeNameInPlural,
        bool isAddFieldByAll = false)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>
    {
        descriptor
            .Name(OperationTypeNames.Query)
            .EntityQueryById<TEntityDto, TKey>(typeName, $"{typeNameSingular.ToLowerFirstChar()}ById")
            .EntityQueryGet<TEntityDto, TKey>(typeNameSingular.ToLowerFirstChar())
            .EntityQueryGetList<TEntityDto, TKey>(typeNameInPlural.ToLowerFirstChar())
            .EntityQueryAny<TEntityDto, TKey>($"{typeNameInPlural.ToLowerFirstChar()}Any")
            .EntityQueryCount<TEntityDto, TKey>($"{typeNameInPlural.ToLowerFirstChar()}Count");

        if (isAddFieldByAll)
        {
            descriptor.EntityQueryAll<TEntityDto, TKey>($"{typeNameInPlural.ToLowerFirstChar()}All");
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
