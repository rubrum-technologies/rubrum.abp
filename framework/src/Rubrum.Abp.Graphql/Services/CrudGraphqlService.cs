using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public abstract class CrudGraphqlService<TEntity, TEntityDto, TKey, TCreateInput, TUpdateInput> :
    ReadOnlyGraphqlService<TEntity, TEntityDto, TKey>,
    ICrudGraphqlService<TEntityDto, TKey, TCreateInput, TUpdateInput>
    where TKey : notnull
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected readonly IRepository<TEntity, TKey> Repository;

    protected CrudGraphqlService(IRepository<TEntity, TKey> repository) : base(repository)
    {
        Repository = repository;
    }

    public virtual async Task<TEntityDto> CreateAsync(TCreateInput input)
    {
        var entity = await ToEntityAsync(input);
        await Repository.InsertAsync(entity, true, CancellationToken);
        return await ToDtoAsync(entity);
    }

    public virtual async Task<TEntityDto> UpdateAsync(TKey id, TUpdateInput input)
    {
        var entity = await Repository.GetAsync(id, true, CancellationToken);
        await ToEntityAsync(entity, input);
        await Repository.UpdateAsync(entity, true, CancellationToken);
        return await ToDtoAsync(entity);
    }

    public virtual async Task<TEntityDto> DeleteAsync(TKey id)
    {
        var entity = await Repository.GetAsync(id, false, CancellationToken);
        await Repository.DeleteAsync(entity);
        return await ToDtoAsync(entity);
    }

    protected abstract Task<TEntity> ToEntityAsync(TCreateInput input);
    protected abstract Task ToEntityAsync(TEntity entity, TUpdateInput input);
}

public abstract class CrudGraphqlService<TEntity, TEntityDto, TKey, TCreateInput> :
    CrudGraphqlService<TEntity, TEntityDto, TKey, TCreateInput, TCreateInput>,
    ICrudGraphqlService<TEntityDto, TKey, TCreateInput>
    where TKey : notnull
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected CrudGraphqlService(IRepository<TEntity, TKey> repository) : base(repository)
    {
    }
}

public abstract class CrudGraphqlService<TEntity, TEntityDto, TKey> :
    CrudGraphqlService<TEntity, TEntityDto, TKey, TEntityDto>,
    ICrudGraphqlService<TEntityDto, TKey>
    where TKey : notnull
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected CrudGraphqlService(IRepository<TEntity, TKey> repository) : base(repository)
    {
    }
}