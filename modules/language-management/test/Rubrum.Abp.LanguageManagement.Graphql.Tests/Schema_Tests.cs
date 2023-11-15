using CookieCrumble;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using Xunit;
using Rubrum.Abp.Graphql;

namespace Rubrum.Abp.LanguageManagement;

public class SchemaTests : LanguageManagementGraphqlTestBase
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
