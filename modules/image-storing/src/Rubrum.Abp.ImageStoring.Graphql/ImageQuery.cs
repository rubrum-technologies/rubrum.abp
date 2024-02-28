using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.ImageStoring;

[ExtendObjectType(OperationType.Query)]
public class ImageQuery : IGraphqlType
{
    [GraphQLName("imageUrl")]
    public Task<string> GetImageUrl(
        [ID(ImageInformationConstants.TypeName)] Guid id,
        [Service] IImageUrlByIdDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        return dataLoader.LoadAsync(id, cancellationToken);
    }

    [GraphQLName("imageUrlsByTag")]
    public Task<string[]> GetImageUrlsByTag(
        string tag,
        [Service] IImageUrlsByTagDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        return dataLoader.LoadAsync(tag, cancellationToken);
    }
}
