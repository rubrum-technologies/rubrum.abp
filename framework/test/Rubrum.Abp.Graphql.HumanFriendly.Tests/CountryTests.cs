using CookieCrumble;
using Shouldly;
using Xunit;

namespace Rubrum.Abp.Graphql.HumanFriendly;

public class CountryTests : RubrumAbpGraphqlHumanFriendlyTestBase
{
    [Fact]
    public async Task FetchById()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                countryByHumanFriendlyId(id: 1) {
                    id
                    name
                    humanFriendlyId
                }
            }
            """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }
}
