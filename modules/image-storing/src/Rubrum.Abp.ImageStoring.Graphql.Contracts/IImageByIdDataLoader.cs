using GreenDonut;

namespace Rubrum.Abp.ImageStoring;

public interface IImageByIdDataLoader : IDataLoader<Guid, ImageInformationDto>;
