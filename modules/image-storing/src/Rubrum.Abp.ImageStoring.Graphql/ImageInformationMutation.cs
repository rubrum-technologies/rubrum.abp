using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Rubrum.Abp.Graphql.Types;
using Rubrum.Abp.Graphql.Validation;

namespace Rubrum.Abp.ImageStoring;

[ExtendObjectType(OperationType.Mutation)]
public class ImageInformationMutation : IGraphqlType
{
    [GraphQLName("deleteImage")]
    [UseAbpError]
    [UseMutationConvention]
    public async Task<ImageInformationDto> DeleteAsync(
        [ID(ImageInformationConstants.TypeName)] Guid id,
        [Service] IImageByIdDataLoader dataLoader,
        [Service] IImageAppService service,
        CancellationToken cancellationToken)
    {
        var image = await dataLoader.LoadAsync(id, cancellationToken);

        await service.DeleteAsync(id);

        return image;
    }
}
