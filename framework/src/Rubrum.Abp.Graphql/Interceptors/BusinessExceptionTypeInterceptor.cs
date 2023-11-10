using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using Microsoft.Extensions.Logging;
using Rubrum.Abp.Graphql.Types.Ddd;
using Volo.Abp;

namespace Rubrum.Abp.Graphql.Interceptors;

public class BusinessExceptionTypeInterceptor : TypeInterceptor
{
    public override void OnBeforeRegisterDependencies(ITypeDiscoveryContext discoveryContext, DefinitionBase definition)
    {
        if (definition is not ObjectTypeDefinition def)
        {
            return;
        }

        if (typeof(BusinessException).IsAssignableFrom(def.RuntimeType))
        {
            var errorTypeRef = discoveryContext.TypeInspector.GetOutputTypeRef(typeof(BusinessErrorInterfaceType));

            def.Interfaces.Add(errorTypeRef);

            foreach (var field in def.Fields)
            {
                if (typeof(LogLevel).IsAssignableFrom(field.ResultType))
                {
                    field.Ignore = true;
                }
            }
        }
    }
}
