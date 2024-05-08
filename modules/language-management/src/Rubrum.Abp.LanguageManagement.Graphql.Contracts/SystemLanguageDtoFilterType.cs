using HotChocolate.Data.Filters;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageDtoFilterType : FilterInputType<SystemLanguageDto>, IGraphqlType
{
    protected override void Configure(IFilterInputTypeDescriptor<SystemLanguageDto> descriptor)
    {
        descriptor
            .Entity<SystemLanguageDto, string>()
            .ExtensibleObject()
            .FullAudited();
    }
}
