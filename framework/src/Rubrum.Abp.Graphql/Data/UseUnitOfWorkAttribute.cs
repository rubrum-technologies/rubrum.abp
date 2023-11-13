using System.Reflection;
using System.Runtime.CompilerServices;
using HotChocolate.Types.Descriptors;

namespace Rubrum.Abp.Graphql.Data;

public class UseUnitOfWorkAttribute : ObjectFieldDescriptorAttribute
{
    public UseUnitOfWorkAttribute([CallerLineNumber] int order = 0)
    {
        Order = order;
    }

    protected override void OnConfigure(
        IDescriptorContext descriptorContext,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.UseUnitOfWork();
    }
}