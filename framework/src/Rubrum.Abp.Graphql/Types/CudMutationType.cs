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
    IDeleteGraphqlService<TKey>
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
            .UseAbpError()
            .UseMutationConvention()
            .ResolveWith<Resolves>(x => x.CreateAsync(default!, default!));

        descriptor
            .Field(FieldNameUpdate)
            .Argument("input", a => a.Type<NonNullType<InputObjectType<TUpdateInput>>>())
            .UseAbpError()
            .UseMutationConvention()
            .ResolveWith<Resolves>(x => x.UpdateAsync(default!, default!));

        descriptor
            .Field(FieldNameDelete)
            .Argument("id", a => a.Type(typeof(TKey)).ID(TypeName))
            .UseAbpError()
            .UseMutationConvention()
            .ResolveWith<Resolves>(x => x.DeleteAsync(default!, default!))
            .Type<EmptyType>();
    }

    private class Resolves
    {
        public Task<TEntityDto> CreateAsync(TCreateInput input, [Service] TService service)
        {
            return service.CreateAsync(input);
        }

        public Task<TEntityDto> UpdateAsync(TUpdateInput input, [Service] TService service)
        {
            return service.UpdateAsync(input);
        }

        public Task DeleteAsync(TKey id, [Service] TService service)
        {
            return service.DeleteAsync(id);
        }
    }
}

public abstract class CudMutationType<TEntityDto, TKey, TService, TCreateInput> :
    CudMutationType<TEntityDto, TKey, TService, TCreateInput, TCreateInput>
    where TKey : notnull
    where TEntityDto : IEntityDto<TKey>
    where TService : ICreateUpdateGraphqlService<TEntityDto, TKey, TCreateInput, TCreateInput>,
    IDeleteGraphqlService<TKey>
{
}
