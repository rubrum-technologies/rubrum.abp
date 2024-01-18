using HotChocolate.Types;
using Rubrum.Abp.Ddd.HumanFriendly;
using Rubrum.Abp.Graphql.Data;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.HumanFriendly;

public static class HumanFriendlyQueryTypeDescriptorExtensions
{
    public static IObjectTypeDescriptor HumanFriendly<TEntityDto, TKey>(
        this IObjectTypeDescriptor descriptor,
        string typeNameSingular)
        where TKey : notnull
        where TEntityDto : IEntityDto<TKey>, IHumanFriendlyId
    {
        descriptor
            .Field($"{typeNameSingular.ToLowerFirstChar()}ByHumanFriendlyId")
            .UseUnitOfWork()
            .Argument("id", x => x.Type(typeof(long)))
            .Resolve(context =>
            {
                var service = context.Service<IHumanFriendlyAppService<TEntityDto, TKey>>();
                var id = context.ArgumentValue<long>("id");

                return service.GetByHumanIdAsync(id);
            })
            .Type<NonNullType<ObjectType<TEntityDto>>>();

        return descriptor;
    }
}
