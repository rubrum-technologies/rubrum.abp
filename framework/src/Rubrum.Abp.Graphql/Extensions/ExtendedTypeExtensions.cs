using HotChocolate.Internal;

namespace Rubrum.Abp.Graphql.Extensions;

public static class ExtendedTypeExtensions
{
    public static Type? TryGetRuntimeType(this IExtendedType extendedType)
    {
        if (extendedType.Kind == ExtendedTypeKind.Runtime)
        {
            return extendedType.Source;
        }

        if (extendedType.IsArray)
        {
            if (extendedType.ElementType is null)
            {
                return null;
            }

            var runtimeType = TryGetRuntimeType(extendedType.ElementType);
            return runtimeType is null ? null : Array.CreateInstance(runtimeType, 0).GetType();
        }

        if (extendedType.IsList)
        {
            if (extendedType.ElementType is null)
            {
                return null;
            }

            var runtimeType = TryGetRuntimeType(extendedType.ElementType);
            return runtimeType is null ? null : typeof(List<>).MakeGenericType(runtimeType);
        }

        if (typeof(InputObjectType).IsAssignableFrom(extendedType))
        {
            var baseType = extendedType.Type.BaseType;
            while (baseType is not null &&
                   (!baseType.IsGenericType || baseType.GetGenericTypeDefinition() != typeof(InputObjectType<>)))
            {
                baseType = baseType.BaseType;
            }

            return baseType?.GenericTypeArguments[0];
        }

        if (typeof(ScalarType).IsAssignableFrom(extendedType))
        {
            var baseType = extendedType.Type.BaseType;
            while (baseType is not null &&
                   (!baseType.IsGenericType || baseType.GetGenericTypeDefinition() != typeof(ScalarType<>)))
            {
                baseType = baseType.BaseType;
            }

            if (baseType is null)
            {
                return null;
            }

            var runtimeType = baseType.GenericTypeArguments[0];
            if (runtimeType.IsValueType && extendedType.IsNullable)
            {
                return typeof(Nullable<>).MakeGenericType(runtimeType);
            }

            return runtimeType;
        }

        return null;
    }
}