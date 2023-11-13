using HotChocolate.Data.Filters;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageDtoFilterType : FilterInputType<LanguageDto>, IGraphqlType
{
    protected override void Configure(IFilterInputTypeDescriptor<LanguageDto> descriptor)
    {
        descriptor
            .Field(x => x.Id)
            .Type<IdOperationFilterInputType>();
    }
}
