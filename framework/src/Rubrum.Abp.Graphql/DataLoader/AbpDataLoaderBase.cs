using Rubrum.Abp.Graphql.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;
using Volo.Abp.Uow;

namespace Rubrum.Abp.Graphql.DataLoader;

public class AbpDataLoaderBase<TEntityDto, TKey>(
    IBatchScheduler batchScheduler,
    IAsyncQueryableExecuter asyncExecuter,
    IUnitOfWorkManager unitOfWorkManager,
    IReadOnlyGraphqlService<TEntityDto, TKey> service,
    DataLoaderOptions? options = null)
    : BatchDataLoader<TKey, TEntityDto>(batchScheduler, options),
        IAbpDataLoader<TEntityDto, TKey>,
        IScopedDependency
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
{
    protected IAsyncQueryableExecuter AsyncExecuter => asyncExecuter;

    protected IReadOnlyGraphqlService<TEntityDto, TKey> Service => service;

    protected IUnitOfWorkManager UnitOfWorkManager => unitOfWorkManager;

    public async Task<TEntityDto?> LoadOrNullAsync(TKey? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return default;
        }

        return await LoadAsync(id, cancellationToken);
    }

    protected override async Task<IReadOnlyDictionary<TKey, TEntityDto>> LoadBatchAsync(
        IReadOnlyList<TKey> keys,
        CancellationToken cancellationToken)
    {
        using var uow = UnitOfWorkManager.Begin(true, true);

        var query = (await Service.GetQueryableAsync())
            .Where(x => keys.Contains(x.Id));
        var entities = await AsyncExecuter.ToListAsync(query, cancellationToken);

        await uow.CompleteAsync(cancellationToken);

        return entities.ToDictionary(x => x.Id);
    }
}
