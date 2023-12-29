using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace Rubrum.Abp.Graphql.Extensions;

public static class ResolverContextExtensions
{
    public static ObjectFieldNode GetFiledForInput(this IResolverContext context, string fieldName)
    {
        var input = context.ArgumentLiteral<ObjectValueNode>("input");
        return input.Fields.Single(x => x.Name.Value == fieldName);
    }

    public static TKey GetFiledKeyForInput<TKey>(this IResolverContext context, string? fieldName = null)
        where TKey : notnull
    {
        var key = context.GetFiledForInput(fieldName ?? "id");

        var idSerializer = context.Service<IIdSerializer>();
        return (TKey)idSerializer.Deserialize((string)key.Value.Value!).Value;
    }
}
