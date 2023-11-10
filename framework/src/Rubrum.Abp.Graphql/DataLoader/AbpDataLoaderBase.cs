using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;

namespace Rubrum.Abp.Graphql.DataLoader;

public class AbpDataLoaderBase<TEntity, TKey> : BatchDataLoader<TKey, TEntity>,
    IAbpDataLoader<TEntity, TKey>,
    IScopedDependency
    where TKey : notnull
    where TEntity : IEntityDto<TKey>
{
    protected readonly IAsyncQueryableExecuter AsyncExecuter;
    protected readonly IReadOnlyGraphqlService<TEntity, TKey> Service;

    public AbpDataLoaderBase(
        IBatchScheduler batchScheduler,
        IAsyncQueryableExecuter asyncExecuter,
        IReadOnlyGraphqlService<TEntity, TKey> service,
        DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        AsyncExecuter = asyncExecuter;
        Service = service;
    }

    protected async override Task<IReadOnlyDictionary<TKey, TEntity>> LoadBatchAsync(
        IReadOnlyList<TKey> keys,
        CancellationToken cancellationToken)
    {
        var query = (await Service.GetQueryableAsync())
            .Where(x=> keys.Contains(x.Id));
        var entities = await AsyncExecuter.ToListAsync(query, cancellationToken);
        return entities.ToDictionary(x => x.Id);
    }

    public async Task<TEntity?> LoadOrNullAsync(TKey? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return default;
        }

        return await LoadAsync(id, cancellationToken);
    }
}