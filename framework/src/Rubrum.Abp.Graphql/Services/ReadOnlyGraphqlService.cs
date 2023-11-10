using System.Linq.Expressions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public abstract class ReadOnlyGraphqlService<TEntity, TEntityDto, TKey> :
    GraphqlService,
    IReadOnlyGraphqlService<TEntityDto, TKey>
    where TKey : notnull
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected readonly IReadOnlyRepository<TEntity, TKey> ReadOnlyRepository;

    protected ReadOnlyGraphqlService(IReadOnlyRepository<TEntity, TKey> repository)
    {
        ReadOnlyRepository = repository;
    }

    protected abstract Expression<Func<TEntity, TEntityDto>> ToDtoExpression { get; }

    public async Task<TEntityDto> GetByIdAsync(TKey id)
    {
        var query = await ReadOnlyRepository.GetQueryableAsync();

        return await AsyncExecuter.FirstAsync(query.Select(ToDtoExpression));
    }

    public async Task<IQueryable<TEntityDto>> GetQueryableAsync()
    {
        var query = await ReadOnlyRepository.GetQueryableAsync();

        return query.Select(ToDtoExpression);
    }

    protected virtual Task<TEntityDto> ToDtoAsync(TEntity entity)
    {
        return Task.FromResult(ToDtoExpression.Compile().Invoke(entity));
    }
}