using Rubrum.Abp.Graphql.Services;

namespace Rubrum.Abp.ImageStoring;

public interface IImageInformationGraphqlService : IReadOnlyGraphqlService<ImageInformationDto, Guid>;
