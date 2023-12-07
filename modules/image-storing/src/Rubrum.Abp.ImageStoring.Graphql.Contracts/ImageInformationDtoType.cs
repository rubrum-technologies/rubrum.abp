using HotChocolate.Types;
using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.ImageStoring;

public class ImageInformationDtoType : ObjectType<ImageInformationDto>, IGraphqlType
{
    protected override void Configure(IObjectTypeDescriptor<ImageInformationDto> descriptor)
    {
        descriptor
            .Field("url")
            .Resolve(context =>
            {
                var parent = context.Parent<ImageInformationDto>();
                var dataLoader = context.Service<IImageUrlByIdDataLoader>();

                return dataLoader.LoadAsync(parent.Id, context.RequestAborted);
            })
            .Type<NonNullType<StringType>>();
    }
}
