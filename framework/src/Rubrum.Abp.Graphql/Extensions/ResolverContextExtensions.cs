using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace Rubrum.Abp.Graphql.Extensions;

public static class ResolverContextExtensions
{
    public static TKey GetFiledKeyForInput<TKey>(this IResolverContext context)
        where TKey : notnull
    {
        var idSerializer = context.Service<IIdSerializer>();
        var input = context.ArgumentLiteral<ObjectValueNode>("input");
        var key = input.Fields.Single(x => x.Name.Value == "id");
        return (TKey)idSerializer.Deserialize((string)key.Value.Value!).Value;
    }
}
