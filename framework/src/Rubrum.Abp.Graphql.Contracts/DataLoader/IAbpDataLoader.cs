using GreenDonut;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.DataLoader;

public interface IAbpDataLoader<TEntity, in TKey> : IDataLoader<TKey, TEntity>
    where TKey : notnull
    where TEntity : IEntityDto<TKey>
{
    Task<TEntity?> LoadOrNullAsync(TKey? id, CancellationToken cancellationToken);
}
