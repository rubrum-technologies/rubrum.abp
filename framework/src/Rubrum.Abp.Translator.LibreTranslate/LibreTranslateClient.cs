using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;
using Volo.Abp.Threading;

namespace Rubrum.Abp.Translator;

public class LibreTranslateClient : ILibreTranslateClient, ITransientDependency
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IJsonSerializer _jsonSerializer;
    private readonly LibreTranslateOptions _options;
    private readonly ICancellationTokenProvider _cancellationTokenProvider;

    public LibreTranslateClient(
        IHttpClientFactory httpClientFactory,
        IJsonSerializer jsonSerializer,
        IOptions<LibreTranslateOptions> options,
        ICancellationTokenProvider cancellationTokenProvider)
    {
        _httpClientFactory = httpClientFactory;
        _jsonSerializer = jsonSerializer;
        _options = options.Value;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public async Task<ICollection<SupportedLanguage>> GetLanguagesAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken = _cancellationTokenProvider.FallbackToProvider(cancellationToken);

        using var client = GetHttpClient();
        using var response = await client.GetAsync(CreateUri("/languages"), cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        return _jsonSerializer.Deserialize<ICollection<SupportedLanguage>>(json);
    }

    public async Task<TranslatedText> TranslateAsync(
        string q,
        string source,
        string target,
        CancellationToken cancellationToken = default)
    {
        cancellationToken = _cancellationTokenProvider.FallbackToProvider(cancellationToken);

        using var client = GetHttpClient();
        using var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "q", q }, { "source", source }, { "target", target }, { "api_key", string.Empty }
        });
        using var response = await client.PostAsync(CreateUri("/translate"), content, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        return _jsonSerializer.Deserialize<TranslatedText>(json);
    }

    private Uri CreateUri(string path)
    {
        var url = _options.Url.TrimEnd('/');
        path = path.TrimStart('/').TrimEnd('/');

        return new Uri($"{url}/{path}");
    }

    private HttpClient GetHttpClient()
    {
        return _httpClientFactory.CreateClient("libre-translate");
    }
}
