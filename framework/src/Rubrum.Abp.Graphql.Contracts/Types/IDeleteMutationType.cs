using Rubrum.Abp.Graphql.Services;

namespace Rubrum.Abp.Graphql.Types;

public interface IDeleteMutationType<in TKey, in TService> : IGraphqlType
    where TKey : notnull
    where TService : IDeleteGraphqlService<TKey>
{
    Task DeleteAsync(TKey id, TService service);
}