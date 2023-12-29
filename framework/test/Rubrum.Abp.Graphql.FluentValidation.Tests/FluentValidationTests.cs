using CookieCrumble;
using Shouldly;
using Xunit;

namespace Rubrum.Abp.Graphql;

public class FluentValidationTests : GraphqlFluentValidationTestBase
{
    [Fact]
    public async Task Successfully()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            mutation {
                createCountry(input: { name: "Test" }) {
                    country {
                        name
                    }
                    errors {
                        ... on Error {
                            message
                        }
                    }
                }
            }
            """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Fail()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            mutation {
                createCountry(input: { name: "TestTestTestTestTestTest" }) {
                    country {
                        name
                    }
                    errors {
                        ... on Error {
                            message
                        }
                    }
                }
            }
            """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }
}
