using CookieCrumble;
using HotChocolate.Types.Relay;
using Shouldly;
using Xunit;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageTests : LanguageManagementGraphqlTestBase
{
    private readonly IIdSerializer _idSerializer;

    public SystemLanguageTests()
    {
        _idSerializer = GetRequiredService<IIdSerializer>();
    }

    [Fact]
    public async Task FetchById()
    {
        var id = _idSerializer.Serialize(null, SystemLanguageConstants.TypeName, "ru");

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  systemLanguageById(id: "{{id}}") {
                      id
                      code
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
        var id = _idSerializer.Serialize(null, SystemLanguageConstants.TypeName, "en");

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  systemLanguage(where: { id: { eq: "{{id}}" } }) {
                      id
                      code
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
                systemLanguages {
                    nodes {
                      id
                      code
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
                systemLanguagesAny(where: { name: { eq: "Русский" } })
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
                systemLanguagesCount
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
                createSystemLanguage (input: { code: "test", name: "Test" }) {
                    systemLanguage {
                        id
                        code
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
        var id = _idSerializer.Serialize(null, SystemLanguageConstants.TypeName, "zh");
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  updateSystemLanguage (input: { id: "{{id}}", name: "CH" }) {
                      systemLanguage {
                          id
                          code
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
        var id = _idSerializer.Serialize(null, SystemLanguageConstants.TypeName, "gu");
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  deleteSystemLanguage (input: { id: "{{id}}" }) {
                      systemLanguage {
                          id
                          code
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
