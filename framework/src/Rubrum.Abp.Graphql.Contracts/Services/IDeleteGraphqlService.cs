namespace Rubrum.Abp.Graphql.Services;

public interface IDeleteGraphqlService<in TKey> : IGraphqlService
    where TKey : notnull
{
    Task DeleteAsync(TKey id);
}