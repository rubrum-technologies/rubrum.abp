using CookieCrumble;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using Xunit;

namespace Rubrum.Abp.Keycloak;

public class SchemaTests : RubrumAbpKeycloakGraphqlTestBase
{
    private readonly IRequestExecutorBuilder _builder;

    public SchemaTests()
    {
        _builder = GetRequiredService<IRequestExecutorBuilder>();
    }

    [Fact]
    public async Task SchemaChangeTest()
    {
        var schema = await _builder.BuildSchemaAsync();
        schema.MatchSnapshot();
    }
}
