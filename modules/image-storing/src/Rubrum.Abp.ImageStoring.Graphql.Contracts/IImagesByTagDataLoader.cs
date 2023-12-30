using GreenDonut;

namespace Rubrum.Abp.ImageStoring;

public interface IImagesByTagDataLoader : IDataLoader<string, ImageInformationDto[]>;
