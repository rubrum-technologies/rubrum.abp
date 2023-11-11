using HotChocolate.Language;
using HotChocolate.Resolvers;
using Rubrum.Abp.Graphql.Data;
using Rubrum.Abp.Graphql.Services;
using Rubrum.Abp.Graphql.Validation;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types;

public abstract class CudMutationType<TEntityDto, TKey, TService, TCreateInput, TUpdateInput> :
    ObjectTypeExtension,
    IGraphqlType
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TEntityDto, TKey, TCreateInput, TUpdateInput>,
    IDeleteGraphqlService<TEntityDto, TKey>
{
    protected abstract string TypeName { get; }
    protected abstract string FieldNameCreate { get; }
    protected abstract string FieldNameUpdate { get; }
    protected abstract string FieldNameDelete { get; }

    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name(OperationTypeNames.Mutation);

        descriptor
            .Field(FieldNameCreate)
            .Argument("input", a => a.Type<NonNullType<InputObjectType<TCreateInput>>>())
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .ResolveWith<Resolves>(x => x.CreateAsync(default!, default!));

        descriptor
            .Field(FieldNameUpdate)
            .Argument("input", a => a.Type<NonNullType<InputObjectType<TUpdateInput>>>())
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .Resolve(context =>
            {
                var service = context.Service<TService>();
                var id = GetKeyFromUpdateInput(context);
                var input = context.ArgumentValue<TUpdateInput>("input");

                return service.UpdateAsync(id, input);
            })
            .Type(typeof(TEntityDto));

        descriptor
            .Field(FieldNameDelete)
            .Argument("id", a => a.Type(typeof(TKey)).ID(TypeName))
            .UseUnitOfWork()
            .UseAbpError()
            .UseMutationConvention()
            .ResolveWith<Resolves>(x => x.DeleteAsync(default!, default!));
    }

    private class Resolves
    {
        public Task<TEntityDto> CreateAsync(TCreateInput input, [Service] TService service)
        {
            return service.CreateAsync(input);
        }

        public Task<TEntityDto> DeleteAsync(TKey id, [Service] TService service)
        {
            return service.DeleteAsync(id);
        }
    }

    private static TKey GetKeyFromUpdateInput(IResolverContext context)
    {
        var idSerializer = context.Service<IIdSerializer>();
        var input = context.ArgumentLiteral<ObjectValueNode>("input");
        var key = input.Fields.Single(x => x.Name.Value == "id");
        return (TKey)idSerializer.Deserialize((string)key.Value.Value!).Value;
    }
}

public abstract class CudMutationType<TEntityDto, TKey, TService, TCreateInput> :
    CudMutationType<TEntityDto, TKey, TService, TCreateInput, TCreateInput>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TEntityDto, TKey, TCreateInput, TCreateInput>,
    IDeleteGraphqlService<TEntityDto, TKey>
{
}