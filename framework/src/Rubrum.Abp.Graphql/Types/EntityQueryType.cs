﻿using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using Rubrum.Abp.Graphql.Data;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public abstract class EntityQueryType<TEntityDto, TKey, TService> :
    ObjectTypeExtension,
    IGraphqlType
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : IReadOnlyGraphqlService<TEntityDto, TKey>
{
    protected abstract string TypeName { get; }
    protected abstract string TypeNameSingular { get; }
    protected abstract string TypeNameInPlural { get; }

    protected virtual string FieldNameGetById => $"{TypeNameSingular.ToLowerFirstChar()}ById";
    protected virtual string FieldNameGet => TypeNameSingular.ToLowerFirstChar();
    protected virtual string FieldNameGetList => $"{TypeNameInPlural.ToLowerFirstChar()}";
    protected virtual string FieldNameAny => $"{TypeNameInPlural.ToLowerFirstChar()}Any";
    protected virtual string FieldNameCount => $"{TypeNameInPlural.ToLowerFirstChar()}Count";

    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name(OperationTypeNames.Query);

        descriptor
            .Field(FieldNameGetById)
            .UseUnitOfWork()
            .Argument("id", x => x.Type(typeof(TKey)).ID(TypeName))
            .ResolveWith<Resolves>(x => x.GetByIdAsync(default!, default!, default!));

        descriptor
            .Field(FieldNameGet)
            .UseUnitOfWork()
            .UseFirstOrDefault()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameGetList)
            .UseUnitOfWork()
            .UsePaging()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .UseSorting<SortInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameAny)
            .UseUnitOfWork()
            .UseAny()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameCount)
            .UseUnitOfWork()
            .UseCount()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));
    }

    private class Resolves
    {
        public Task<TEntityDto> GetByIdAsync(
            TKey id,
            IAbpDataLoader<TEntityDto, TKey> dataLoader,
            CancellationToken cancellationToken)
        {
            return dataLoader.LoadAsync(id, cancellationToken);
        }

        public Task<IQueryable<TEntityDto>> GetQueryableAsync([Service] TService service)
        {
            return service.GetQueryableAsync();
        }
    }
}