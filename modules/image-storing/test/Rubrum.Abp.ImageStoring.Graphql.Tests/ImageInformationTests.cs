using CookieCrumble;
using HotChocolate.Types.Relay;
using Shouldly;
using Xunit;
using static Rubrum.Abp.ImageStoring.ImageStoringTestConstants;

namespace Rubrum.Abp.ImageStoring;

public sealed class ImageInformationTests : ImageStoringGraphqlTestBase
{
    private readonly IImageInformationRepository _repository;
    private readonly IIdSerializer _idSerializer;

    public ImageInformationTests()
    {
        _repository = GetRequiredService<IImageInformationRepository>();
        _idSerializer = GetRequiredService<IIdSerializer>();
    }

    [Fact]
    public async Task FetchUrlById()
    {
        var image = await _repository.GetAsync(JpegId);
        var id = _idSerializer.Serialize(null, ImageInformationConstants.TypeName, image.Id);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  imageUrl(id: "{{id}}")
              }
              """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchUrlsByTag()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  imageUrlsByTag(tag: "{{ImageTag}}")
              }
              """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchById()
    {
        var id = _idSerializer.Serialize(null, ImageInformationConstants.TypeName, GifId);

        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  image(id: "{{id}}") {
                    id
                    tag
                    fileName
                    systemFileName
                    isDisposable
                    entityVersion
                    url
                  }
              }
              """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchByTag()
    {
        await using var result = await ExecuteRequestAsync(b => b.SetQuery(
            $$"""
              query {
                  imagesByTag(tag: "{{ImageTag}}"){
                    id
                    tag
                    fileName
                    systemFileName
                    isDisposable
                    entityVersion
                    url
                  }
              }
              """));

        result.ShouldNotBeNull();

        result.MatchSnapshot();
    }
}
