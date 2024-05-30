using HotChocolate.Data.Filters;

namespace Rubrum.Abp.Graphql;

public class RubrumAbpGraphqlOptions
{
    public List<Action<IFilterConventionDescriptor>> FilterBuildActions { get; set; } = [];

    public bool EnableGlobalObjectIdentification { get; set; } = true;
}
