using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using Rubrum.Abp.Graphql.Data;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public abstract class ReadOnlyQueryType<TEntityDto, TKey, TService, TFilterInput, TSortInput> :
    ObjectTypeExtension,
    IGraphqlType
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : IReadOnlyGraphqlService<TEntityDto, TKey>
    where TFilterInput : FilterInputType<TEntityDto>
    where TSortInput : SortInputType<TEntityDto>
{
    protected abstract string TypeName { get; }
    protected abstract string FieldNameGetById { get; }
    protected abstract string FieldNameGet { get; }
    protected abstract string FieldNameGetList { get; }
    protected abstract string FieldNameAny { get; }
    protected abstract string FieldNameCount { get; }

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
            .UseFiltering<TFilterInput>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameGetList)
            .UseUnitOfWork()
            .UsePaging()
            .UseFiltering<TFilterInput>()
            .UseSorting<TSortInput>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameAny)
            .UseUnitOfWork()
            .UseAny()
            .UseFiltering<TFilterInput>()
            .ResolveWith<Resolves>(x => x.GetQueryableAsync(default!));

        descriptor
            .Field(FieldNameCount)
            .UseUnitOfWork()
            .UseCount()
            .UseFiltering<TFilterInput>()
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