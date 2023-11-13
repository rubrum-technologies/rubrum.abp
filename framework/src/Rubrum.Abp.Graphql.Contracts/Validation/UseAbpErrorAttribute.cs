using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace Rubrum.Abp.Graphql.Validation;

public class UseAbpErrorAttribute : ObjectFieldDescriptorAttribute
{
    protected override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.Error<AbpErrorFactory>();
    }
}
