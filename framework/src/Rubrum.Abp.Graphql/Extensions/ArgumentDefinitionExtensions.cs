using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;

namespace Rubrum.Abp.Graphql.Extensions;

public static class ArgumentDefinitionExtensions
{
    public static Type? TryGetRuntimeType(this ArgumentDefinition argument)
    {
        if (argument.Parameter?.ParameterType is { } type)
        {
            return type;
        }

        if (argument.Type is ExtendedTypeReference extendedType)
        {
            return extendedType.Type.TryGetRuntimeType();
        }

        return null;
    }
}