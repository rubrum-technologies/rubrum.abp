using HotChocolate.Types;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class EntityType<TKey> : InterfaceType<IEntityDto<TKey>>
    where TKey : notnull
{
    protected override void Configure(IInterfaceTypeDescriptor<IEntityDto<TKey>> descriptor)
    {
        descriptor.Name($"EntityOf{typeof(TKey).Name}");

        descriptor.BindFieldsExplicitly();

        descriptor
            .Field(x => x.Id)
            .Type<NonNullType<IdType>>();
    }
}