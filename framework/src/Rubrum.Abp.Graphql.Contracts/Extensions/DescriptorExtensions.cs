using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;

namespace Rubrum.Abp.Graphql.Extensions;

public static class DescriptorExtensions
{
    public static IInputFieldDescriptor GetField(this IDescriptor<InputObjectTypeDefinition> descriptor, string name)
    {
        var type = descriptor.GetType();
        var method = type.GetMethods()
            .First(x =>
                x.Name == nameof(IInputObjectTypeDescriptor.Field) &&
                x.GetParameters().Length == 1 &&
                x.GetParameters()[0].ParameterType == typeof(string));

        return (IInputFieldDescriptor)method.Invoke(descriptor, [name])!;
    }

    public static IObjectFieldDescriptor GetField(this IDescriptor<ObjectTypeDefinition> descriptor, string name)
    {
        var type = descriptor.GetType();
        var method = type.GetMethods()
            .First(x => x.Name == nameof(IObjectTypeDescriptor.Field) && x.GetParameters().Length == 1);

        return (IObjectFieldDescriptor)method.Invoke(descriptor, [name])!;
    }
}
