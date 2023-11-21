using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors.Definitions;

namespace Rubrum.Abp.Graphql.Interceptors;

public class NewLineTypeInterceptor : TypeInterceptor
{
    public override void OnAfterCompleteName(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        definition.Description = definition.Description.ReplaceNewLine();

        if (definition is ObjectTypeDefinition objectType)
        {
            foreach (var field in objectType.Fields)
            {
                field.Description = field.Description.ReplaceNewLine();

                foreach (var argument in field.Arguments)
                {
                    argument.Description = argument.Description.ReplaceNewLine();
                }
            }
        }

        if (definition is InterfaceTypeDefinition interfaceType)
        {
            foreach (var field in interfaceType.Fields)
            {
                field.Description = field.Description.ReplaceNewLine();

                foreach (var argument in field.Arguments)
                {
                    argument.Description = argument.Description.ReplaceNewLine();
                }
            }
        }
        
        if (definition is InputObjectTypeDefinition inputType)
        {
            foreach (var field in inputType.Fields)
            {
                field.Description = field.Description.ReplaceNewLine();
            }
        }

        if (definition is EnumTypeDefinition enumType)
        {
            foreach (var value in enumType.Values)
            {
                value.Description = value.Description.ReplaceNewLine();
            }
        }

        if (definition is DirectiveTypeDefinition directiveType)
        {
            foreach (var argument in directiveType.Arguments)
            {
                argument.Description = argument.Description.ReplaceNewLine();
            }
        }
    }
}
