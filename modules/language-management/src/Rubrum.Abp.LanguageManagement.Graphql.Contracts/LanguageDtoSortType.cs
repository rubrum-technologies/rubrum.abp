using HotChocolate.Data.Sorting;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageDtoSortType : SortInputType<LanguageDto>, IGraphqlType
{
    protected override void Configure(ISortInputTypeDescriptor<LanguageDto> descriptor)
    {
        descriptor
            .Entity<LanguageDto, string>()
            .ExtraProperties()
            .FullAudited();
    }
}
