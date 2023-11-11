using HotChocolate.Types;

namespace Rubrum.Abp.Graphql.Types;

public static class InputObjectTypeExtensions
{
    public static IInputObjectTypeDescriptor<TInput> AddFieldKey<TInput, TKey>(
        this IInputObjectTypeDescriptor<TInput> descriptor,
        string typeName)
        where TKey : notnull
    {
        descriptor
            .Field("id")
            .Type(typeof(TKey))
            .ID(typeName);

        return descriptor;
    }
}