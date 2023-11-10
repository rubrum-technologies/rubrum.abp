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

    public async Task<TEntityDto> CreateAsync(TCreateInput input)
    {
        var entity = await ToEntityAsync(input);
        await Repository.InsertAsync(entity, true, CancellationToken);
        return await ToDtoAsync(entity);
    }

    public async Task<TEntityDto> UpdateAsync(TUpdateInput input)
    {
        var entity = await ToEntityAsync(input);
        await Repository.UpdateAsync(entity, true, CancellationToken);
        return await ToDtoAsync(entity);
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await Repository.GetAsync(id, false, CancellationToken);
        await Repository.DeleteAsync(entity);
    }

    protected abstract Task<TEntity> ToEntityAsync(TCreateInput input);
    protected abstract Task<TEntity> ToEntityAsync(TUpdateInput input);
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