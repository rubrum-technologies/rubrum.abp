using HotChocolate.Language;
using HotChocolate.Resolvers;
using Rubrum.Abp.Graphql.Data;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Services;
using Rubrum.Abp.Graphql.Validation;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public abstract class EntityMutationType<TEntityDto, TKey, TService, TCreateInput, TUpdateInput> :
    ObjectTypeExtension,
    IGraphqlType
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICrudGraphqlService<TEntityDto, TKey, TCreateInput, TUpdateInput>
{
    protected abstract string TypeName { get; }
    protected abstract string TypeNameSingular { get; }
    protected abstract string TypeNameInPlural { get; }
    protected virtual string FieldNameCreate => $"create{TypeNameSingular}";
    protected virtual string FieldNameUpdate => $"update{TypeNameSingular}";
    protected virtual string FieldNameDelete => $"delete{TypeNameSingular}";

    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name(OperationTypeNames.Mutation);

        descriptor
            .Field(FieldNameCreate)
            .Argument("input", a => a.Type<NonNullType<InputObjectType<TCreateInput>>>())
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .Resolve(context =>
            {
                var service = context.Service<TService>();
                return service.CreateAsync(context.ArgumentValue<TCreateInput>("input"));
            })
            .Type(typeof(TEntityDto));

        descriptor
            .Field(FieldNameUpdate)
            .Argument("input", a => a.Type<NonNullType<InputObjectType<TUpdateInput>>>())
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .Resolve(context =>
            {
                var id = GetKeyFromUpdateInput(context);
                var input = context.ArgumentValue<TUpdateInput>("input");
                var service = context.Service<TService>();

                return service.UpdateAsync(id, input);
            })
            .Type(typeof(TEntityDto));

        descriptor
            .Field(FieldNameDelete)
            .Argument("id", a => a.Type(typeof(TKey)).ID(TypeName))
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .Resolve(async context =>
            {
                var id = context.ArgumentValue<TKey>("id");
                var service = context.Service<TService>();
                var dataLoader = context.Service<IAbpDataLoader<TEntityDto, TKey>>();

                var entity = await dataLoader.LoadAsync(id, context.RequestAborted);
                await service.DeleteAsync(id);
                return entity;
            })
            .Type(typeof(TEntityDto));
    }

    private static TKey GetKeyFromUpdateInput(IResolverContext context)
    {
        var idSerializer = context.Service<IIdSerializer>();
        var input = context.ArgumentLiteral<ObjectValueNode>("input");
        var key = input.Fields.Single(x => x.Name.Value == "id");
        return (TKey)idSerializer.Deserialize((string)key.Value.Value!).Value;
    }
}