using HotChocolate.Resolvers;
using HotChocolate.Types.Descriptors.Definitions;

namespace Rubrum.Abp.Graphql.Data;

public static class UseAnyExtensions
{
    public static IObjectFieldDescriptor UseAny(this IObjectFieldDescriptor descriptor)
    {
        var placeholder = new FieldMiddlewareDefinition(_ => _ => default, key: "Rubrum.Abp.Graphql.AnyMiddleware");

        descriptor.Extend().Definition.MiddlewareDefinitions.Add(placeholder);

        descriptor
            .Extend()
            .OnBeforeCreate((context, definition) =>
            {
                if (definition.ResultType is null ||
                    !context.TypeInspector.TryCreateTypeInfo(definition.ResultType, out var typeInfo))
                {
                    var resultType = definition.ResolverType ?? typeof(object);
                    throw new ArgumentException(
                        $"Cannot handle the specified type `{resultType.FullName}`.",
                        nameof(descriptor));
                }

                var selectionType = typeInfo.NamedType;
                definition.ResultType = typeof(bool);
                definition.Type = context.TypeInspector.GetTypeRef(typeof(bool));

                definition.Configurations.Add(new CompleteConfiguration<ObjectFieldDefinition>(
                    (_, def) =>
                    {
                        CompileMiddleware(
                            selectionType,
                            def,
                            placeholder,
                            typeof(AnyMiddleware<>));
                    },
                    definition,
                    ApplyConfigurationOn.BeforeCompletion));
            });

        return descriptor;
    }

    private static void CompileMiddleware(
        Type type,
        ObjectFieldDefinition definition,
        FieldMiddlewareDefinition placeholder,
        Type middlewareDefinition)
    {
        var middlewareType = middlewareDefinition.MakeGenericType(type);
        var middleware = FieldClassMiddlewareFactory.Create(middlewareType);
        var index = definition.MiddlewareDefinitions.IndexOf(placeholder);
        definition.MiddlewareDefinitions[index] = new FieldMiddlewareDefinition(middleware,
            key: "Rubrum.Abp.Graphql.AnyMiddleware");
    }
}
