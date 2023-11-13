using HotChocolate.Types;

namespace Rubrum.Abp.Graphql.Types;

public static class InputObjectTypeExtensions
{
    public static IInputObjectTypeDescriptor<TInput> AddFieldKey<TInput, TKey>(
        this IInputObjectTypeDescriptor<TInput> descriptor,
        string typeName)
        where TKey : IType
    {
        descriptor
            .Field("id")
            .Type<NonNullType<TKey>>()
            .ID(typeName);

        return descriptor;
    }
}
