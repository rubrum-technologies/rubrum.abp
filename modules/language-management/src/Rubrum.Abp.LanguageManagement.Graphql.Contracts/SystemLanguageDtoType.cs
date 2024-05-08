using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageDtoType : ObjectType<SystemLanguageDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<SystemLanguageDto> descriptor)
    {
        descriptor
            .Entity<SystemLanguageDto, string>()
            .ExtensibleObject()
            .FullAudited();

        descriptor
            .Field("code")
            .Resolve(context => context.Parent<SystemLanguageDto>().Id)
            .Type<NonNullType<StringType>>();
    }
}
