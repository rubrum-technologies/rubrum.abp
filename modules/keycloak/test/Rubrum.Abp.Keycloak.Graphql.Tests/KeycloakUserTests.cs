using CookieCrumble;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Keycloak.Users;
using Shouldly;
using Xunit;

namespace Rubrum.Abp.Keycloak;

public class KeycloakUserTests : RubrumAbpKeycloakGraphqlTestBase
{
    private readonly IIdSerializer _idSerializer;
    private readonly IKeycloakClient _keycloakClient;
    private readonly IKeycloakUserGraphqlService _service;

    public KeycloakUserTests()
    {
        _service = GetRequiredService<IKeycloakUserGraphqlService>();
        _keycloakClient = GetRequiredService<IKeycloakClient>();
        _idSerializer = GetRequiredService<IIdSerializer>();
    }

    [Fact]
    public async Task FetchById()
    {
        var user = (await _keycloakClient.GetUsersAsync(username: "admin")).First();
        var id = _idSerializer.Serialize(null, "KeycloakUser", user.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  keycloakUserById(id: "{{id}}") {
                      userName
                  }
              }
              """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Fetch()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            """
            query {
                keycloakUser(where: { userName: { eq: "admin" } }) {
                    userName
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
                keycloakUsers(where: { userName: { eq: "admin" } }) {
                    nodes {
                      userName
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
                keycloakUsersAny(where: { userName: { eq: "admin" } })
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
                  keycloakUsersCount(where: { userName: { eq: "admin" } })
              }
            """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task Create()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  createKeycloakUser (input: { userName: "{{Guid.NewGuid()}}", firstName: "Artem", lastName: "Sharypov" }) {
                      keycloakUser {
                          firstName
                          lastName
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
        var user = (await _keycloakClient.GetUsersAsync(username: "admin")).First();
        var id = _idSerializer.Serialize(null, "KeycloakUser", user.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  updateKeycloakUser (input: { id: "{{id}}", firstName: "Artem", lastName: "Sharypov" }) {
                      keycloakUser {
                          firstName
                          lastName
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
        var user = await CreateUserAsync();
        var id = _idSerializer.Serialize(null, "KeycloakUser", user.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  deleteKeycloakUser (input: { id: "{{id}}" }) {
                      keycloakUser {
                          firstName
                          lastName
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
    public async Task ChangePassword()
    {
        var user = await CreateUserAsync();
        var id = _idSerializer.Serialize(null, "KeycloakUser", user.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  changePassword (input: { id: "{{id}}", password: "23455561236" }) {
                      keycloakUser {
                          firstName
                          lastName
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
    public async Task ChangeRolesAsync()
    {
        var user = await CreateUserAsync();
        var id = _idSerializer.Serialize(null, "KeycloakUser", user.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              mutation {
                  changeRolesForUser(input: { id: "{{id}}", roleNames: ["admin"] }) {
                      keycloakUser {
                          firstName
                          lastName
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

    private async Task<KeycloakUserDto> CreateUserAsync()
    {
        var userName = Guid.NewGuid().ToString();
        var email = $"{Guid.NewGuid()}@rubrum-technologies.ru";

        return await _service.CreateAsync(new CreateKeycloakUserInput
        {
            UserName = userName,
            FirstName = "Artem",
            LastName = "Sharypov",
            Email = email,
            IsActive = true
        });
    }
}
