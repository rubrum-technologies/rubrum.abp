using System.Reflection;
using HotChocolate.Fusion.Clients;
using HotChocolate.Fusion.Metadata;
using Microsoft.Extensions.Configuration;

namespace Rubrum.Abp.Hosting;

public class GraphQlClientFactory : IGraphQLClientFactory
{
    private static readonly ConstructorInfo DefaultHttpGraphQlClientFactoryConstructor = AppDomain.CurrentDomain
        .GetAssemblies()
        .SelectMany(x => x.GetTypes())
        .Single(x => x.Name == "DefaultHttpGraphQLClientFactory")
        .GetConstructors()
        .First(x => x.GetParameters().Length == 1);

    private readonly IConfiguration _configuration;

    private readonly IGraphQLClientFactory _graphQlClientFactory;

    public GraphQlClientFactory(
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _graphQlClientFactory = (IGraphQLClientFactory)DefaultHttpGraphQlClientFactoryConstructor
            .Invoke([httpClientFactory]);
    }

    public IGraphQLClient CreateClient(HttpClientConfiguration configuration)
    {
        var uri = _configuration.GetSection("Microservices")
            .GetSection(configuration.ClientName)
            .GetValue<string>("HttpUrl")!
            .TrimEnd('/');

        configuration = new HttpClientConfiguration(
            configuration.ClientName,
            configuration.SubgraphName,
            new Uri(uri),
            configuration.SyntaxNode);

        return _graphQlClientFactory.CreateClient(configuration);
    }
}
