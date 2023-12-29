using CookieCrumble;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.Types;
using Shouldly;
using Xunit;
using static Rubrum.Abp.Graphql.RubrumAbpGraphqlTestConstants;

namespace Rubrum.Abp.Graphql;

public class CountryTests : RubrumAbpGraphqlTestBase
{
    private readonly IIdSerializer _idSerializer;

    public CountryTests()
    {
        _idSerializer = GetRequiredService<IIdSerializer>();
    }

    [Fact]
    public async Task FetchById()
    {
        var id = _idSerializer.Serialize(null, CountryConstants.TypeName, CountryId);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  countryById(id: "{{id}}") {
                      id
                      name
                  }
              }
              """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Fetch()
    {
        var id = _idSerializer.Serialize(null, CountryConstants.TypeName, CountryId);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  country(where: { id: { eq: "{{id}}" } }) {
                      id
                      name
                  }
              }
              """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchList()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                countries {
                    nodes {
                      id
                      name
                    }
                    pageInfo {
                      endCursor
                      hasNextPage
                      hasPreviousPage
                      startCursor
                    }
                }
            }
            """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchAny()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                countriesAny(where: { name: { eq: "USA" } })
            }
            """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchCount()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                countriesCount
            }
            """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Create()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            mutation {
                createCountry (input: { name: "USA" }) {
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
    public async Task Update()
    {
        var id = _idSerializer.Serialize(null, CountryConstants.TypeName, CountryId);
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  updateCountry (input: { id: "{{id}}", name: "USA" }) {
                      country {
                          id
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
    public async Task Delete()
    {
        var id = _idSerializer.Serialize(null, CountryConstants.TypeName, CountryId);
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  deleteCountry (input: { id: "{{id}}" }) {
                      country {
                          id
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
