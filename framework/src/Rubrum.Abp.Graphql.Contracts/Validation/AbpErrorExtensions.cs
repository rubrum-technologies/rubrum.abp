using HotChocolate.Types;

namespace Rubrum.Abp.Graphql.Validation;

public static class AbpErrorExtensions
{
    public static IObjectFieldDescriptor UseAbpError(this IObjectFieldDescriptor descriptor)
    {
        return descriptor.Error<AbpErrorFactory>();
    }
}