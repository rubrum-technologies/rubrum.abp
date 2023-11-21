using HotChocolate.Data.Filters;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageDtoFilterType : FilterInputType<LanguageDto>, IGraphqlType
{
    protected override void Configure(IFilterInputTypeDescriptor<LanguageDto> descriptor)
    {
        descriptor
            .Entity<LanguageDto, string>()
            .ExtraProperties()
            .FullAudited();
    }
}
