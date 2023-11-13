using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.Graphql.MultilingualObjects.Models;

public class CountryType : ObjectType<Country>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
    {
        descriptor.Entity<Country, Guid>();
        descriptor.MultilingualObject<Country, CountryTranslation>();
    }
}
