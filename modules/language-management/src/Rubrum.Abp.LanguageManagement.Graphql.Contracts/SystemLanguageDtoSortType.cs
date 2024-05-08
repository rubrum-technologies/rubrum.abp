using HotChocolate.Data.Sorting;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Types.Ddd;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageDtoSortType : SortInputType<SystemLanguageDto>, IGraphqlType
{
    protected override void Configure(ISortInputTypeDescriptor<SystemLanguageDto> descriptor)
    {
        descriptor
            .Entity<SystemLanguageDto, string>()
            .ExtensibleObject()
            .FullAudited();
    }
}
