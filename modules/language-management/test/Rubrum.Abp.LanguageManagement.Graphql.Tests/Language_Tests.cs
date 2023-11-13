using CookieCrumble;
using HotChocolate.Types.Relay;
using Xunit;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageTests : LanguageManagementGraphqlTestBase
{
    private readonly IIdSerializer _idSerializer;

    public LanguageTests()
    {
        _idSerializer = GetRequiredService<IIdSerializer>();
    }

    [Fact]
    public async Task FetchById()
    {
        var id = _idSerializer.Serialize(null, LanguageConstants.TypeName, "ru");

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  languageById(id: "{{id}}") {
                      id
                      code
                      name
                  }
              }
              """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Fetch()
    {
        var id = _idSerializer.Serialize(null, LanguageConstants.TypeName, "en");

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  language(where: { id: { eq: "{{id}}" } }) {
                      id
                      code
                      name
                  }
              }
              """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchList()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                languages {
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
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchAny()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                languagesAny(where: { name: { eq: "Русский" } })
            }
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchCount()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                languagesCount
            }
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Create()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            mutation {
                createLanguage (input: { code: "test", name: "Test" }) {
                    language {
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
            """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Update()
    {
        var id = _idSerializer.Serialize(null, LanguageConstants.TypeName, "zh");
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  updateLanguage (input: { id: "{{id}}", name: "CH" }) {
                      language {
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
              """
        ));

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Delete()
    {
        var id = _idSerializer.Serialize(null, LanguageConstants.TypeName, "gu");
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  deleteLanguage (input: { id: "{{id}}" }) {
                      language {
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
              """
        ));

        result.MatchSnapshot();
    }
}
