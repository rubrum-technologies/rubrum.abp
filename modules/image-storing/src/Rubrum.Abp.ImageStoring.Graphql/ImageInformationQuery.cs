using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.DataLoader;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.ImageStoring;

[ExtendObjectType(OperationType.Query)]
public class ImageInformationQuery : IGraphqlType
{
    [Authorize]
    [GraphQLName("imageUrl")]
    public Task<string> GetImageUrlAsync(
        [ID(ImageInformationConstants.TypeName)] Guid id,
        [Service] IImageUrlByIdDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        return dataLoader.LoadAsync(id, cancellationToken);
    }

    [Authorize]
    [GraphQLName("imageUrlsByTag")]
    public Task<string[]> GetImageUrlsByTagAsync(
        string tag,
        [Service] IImageUrlsByTagDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        return dataLoader.LoadAsync(tag, cancellationToken);
    }

    [Authorize]
    [GraphQLName("image")]
    public Task<ImageInformationDto> GetImageAsync(
        [ID(ImageInformationConstants.TypeName)]
        Guid id,
        [Service] IAbpDataLoader<ImageInformationDto, Guid> dataLoader,
        CancellationToken cancellationToken)
    {
        return dataLoader.LoadAsync(id, cancellationToken);
    }

    [Authorize]
    [GraphQLName("imagesByTag")]
    public Task<ImageInformationDto[]> GetImagesByTagAsync(
        string tag,
        [Service] IImagesByTagDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        return dataLoader.LoadAsync(tag, cancellationToken);
    }
}
