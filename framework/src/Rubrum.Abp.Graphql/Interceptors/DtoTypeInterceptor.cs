using HotChocolate.Configuration;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Types.Descriptors.Definitions;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Interceptors;

public class DtoTypeInterceptor : TypeInterceptor
{
    public override void OnBeforeCompleteName(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        if (definition is ObjectTypeDefinition objectType && typeof(IEntityDto).IsAssignableFrom(objectType.RuntimeType))
        {
            definition.Name = definition.Name.Replace("Dto", string.Empty);
        }

        if (definition is FilterInputTypeDefinition filterType && typeof(IEntityDto).IsAssignableFrom(filterType.EntityType))
        {
            definition.Name = definition.Name.Replace("Dto", string.Empty);
        }

        if (definition is SortInputTypeDefinition sortType && typeof(IEntityDto).IsAssignableFrom(sortType.EntityType))
        {
            definition.Name = definition.Name.Replace("Dto", string.Empty);
        }
    }
}
