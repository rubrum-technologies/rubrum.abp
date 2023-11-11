using HotChocolate.Types;
using Volo.Abp;

namespace Rubrum.Abp.Graphql.Types.Ddd;

public class SoftDeleteType : InterfaceType<ISoftDelete>
{
    protected override void Configure(IInterfaceTypeDescriptor<ISoftDelete> descriptor)
    {
        descriptor.Name("SoftDelete");
        descriptor.Description(
            " Used to standardize soft deleting entities. Soft-delete entities are not actually deleted, marked as IsDeleted = true in the database, but can not be retrieved to the application normally.");

        descriptor.BindFieldsExplicitly();

        descriptor
            .Field(x => x.IsDeleted)
            .Type<BooleanType>();
    }
}