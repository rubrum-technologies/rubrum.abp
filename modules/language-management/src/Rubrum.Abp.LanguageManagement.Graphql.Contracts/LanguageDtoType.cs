using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageDtoType : ObjectType<LanguageDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<LanguageDto> descriptor)
    {
        descriptor
            .Entity<LanguageDto, string>()
            .ExtraProperties()
            .FullAudited();

        descriptor
            .Field("code")
            .Resolve(context => context.Parent<LanguageDto>().Id)
            .Type<NonNullType<StringType>>();
    }
}
