using CookieCrumble;
using HotChocolate.Types.Relay;
using Xunit;

namespace Rubrum.Abp.Graphql.MultilingualObjects;

public class CountryTests : MultilingualObjectsTestBase
{
    [Fact]
    public async Task Fetch_By_Default()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                country {
                    id
                    translation {
                        language
                        name
                    }
                    translations {
                        language
                        name
                    }
                }
            }
            """
        ));

        result.MatchSnapshot();
    }
    
    [Fact]
    public async Task Fetch_By_Ru()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                country {
                    id
                    translation(culture: "ru") {
                        language
                        name
                    }
                    translations {
                        language
                        name
                    }
                }
            }
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Fetch_By_En()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                country {
                    id
                    translation(culture: "en") {
                        language
                        name
                    }
                    translations {
                        language
                        name
                    }
                }
            }
            """
        ));

        result.MatchSnapshot();
    }
}
