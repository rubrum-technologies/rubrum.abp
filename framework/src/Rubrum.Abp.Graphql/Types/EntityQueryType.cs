using HotChocolate.Data.Filters;
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

    protected virtual string FieldNameForGetById => $"{TypeNameSingular.ToLowerFirstChar()}ById";

    protected virtual string FieldNameForGet => TypeNameSingular.ToLowerFirstChar();

    protected virtual string FieldNameForGetList => $"{TypeNameInPlural.ToLowerFirstChar()}";

    protected virtual string FieldNameForAll => $"{TypeNameInPlural.ToLowerFirstChar()}All";

    protected virtual string FieldNameForAny => $"{TypeNameInPlural.ToLowerFirstChar()}Any";

    protected virtual string FieldNameForCount => $"{TypeNameInPlural.ToLowerFirstChar()}Count";

    protected virtual bool IsAddFieldByAll => false;

    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name(OperationTypeNames.Query);

        descriptor
            .Field(FieldNameForGetById)
            .UseUnitOfWork()
            .Argument("id", x => x.Type(typeof(TKey)).ID(TypeName))
            .ResolveWith<Resolves>(x => x.GetByIdAsync(default!, default!, default!));

        descriptor
            .Field(FieldNameForGet)
            .UseUnitOfWork()
            .UseFirstOrDefault()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameForGetList)
            .UseUnitOfWork()
            .UsePaging()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .UseSorting<SortInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        if (IsAddFieldByAll)
        {
            descriptor
                .Field(FieldNameForAll)
                .UseUnitOfWork()
                .UseFiltering<FilterInputType<TEntityDto>>()
                .UseSorting<SortInputType<TEntityDto>>()
                .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));
        }

        descriptor
            .Field(FieldNameForAny)
            .UseUnitOfWork()
            .UseAny()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameForCount)
            .UseUnitOfWork()
            .UseCount()
            .UseFiltering<FilterInputType<TEntityDto>>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));
    }

    private sealed class Resolves
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
