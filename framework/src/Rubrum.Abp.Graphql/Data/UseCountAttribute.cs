using System.Reflection;
using System.Runtime.CompilerServices;
using HotChocolate.Types.Descriptors;

namespace Rubrum.Abp.Graphql.Data;

public class UseCountAttribute : ObjectFieldDescriptorAttribute
{
    public UseCountAttribute([CallerLineNumber] int order = 0)
    {
        Order = order;
    }

    protected override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.UseCount();
    }
}