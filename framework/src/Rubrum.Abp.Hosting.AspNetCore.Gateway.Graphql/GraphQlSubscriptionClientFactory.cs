using System.Reflection;
using HotChocolate.Fusion.Clients;
using HotChocolate.Fusion.Metadata;
using Microsoft.Extensions.Configuration;

namespace Rubrum.Abp.Hosting;

public class GraphQlSubscriptionClientFactory : IGraphQLSubscriptionClientFactory
{
    private static readonly ConstructorInfo DefaultWebSocketGraphQlSubscriptionClientFactoryConstructor = AppDomain
        .CurrentDomain
        .GetAssemblies()
        .SelectMany(x => x.GetTypes())
        .Single(x => x.Name == "DefaultWebSocketGraphQLSubscriptionClientFactory")
        .GetConstructors()
        .First(x => x.GetParameters().Length == 2);

    private readonly IConfiguration _configuration;

    private readonly IGraphQLSubscriptionClientFactory _graphQlSubscriptionClientFactory;

    public GraphQlSubscriptionClientFactory(
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory,
        IWebSocketConnectionFactory connectionFactory)
    {
        _configuration = configuration;
        _graphQlSubscriptionClientFactory = (IGraphQLSubscriptionClientFactory)DefaultWebSocketGraphQlSubscriptionClientFactoryConstructor
                .Invoke([httpClientFactory, connectionFactory]);
    }

    public IGraphQLSubscriptionClient CreateClient(IGraphQLClientConfiguration configuration)
    {
        if (configuration is WebSocketClientConfiguration webSocketClientConfig)
        {
            var uri = _configuration.GetSection("Microservices")
                .GetSection(configuration.ClientName)
                .GetValue<string>("WebSocketUrl")!
                .TrimEnd('/');

            webSocketClientConfig = new WebSocketClientConfiguration(
                webSocketClientConfig.ClientName,
                webSocketClientConfig.SubgraphName,
                new Uri(uri),
                webSocketClientConfig.SyntaxNode);

            return _graphQlSubscriptionClientFactory.CreateClient(webSocketClientConfig);
        }

        if (configuration is HttpClientConfiguration httpClientConfig)
        {
            var uri = _configuration.GetSection("Microservices")
                .GetSection(configuration.ClientName)
                .GetValue<string>("HttpUrl")!
                .TrimEnd('/');

            httpClientConfig = new HttpClientConfiguration(
                httpClientConfig.ClientName,
                httpClientConfig.SubgraphName,
                new Uri(uri),
                httpClientConfig.SyntaxNode);

            return _graphQlSubscriptionClientFactory.CreateClient(httpClientConfig);
        }

        throw new ArgumentException("TransportConfigurationNotSupported", nameof(configuration));
    }
}
