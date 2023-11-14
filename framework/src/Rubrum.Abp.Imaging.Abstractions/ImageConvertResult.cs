using Volo.Abp.Imaging;

namespace Rubrum.Abp.Imaging;

public class ImageConvertResult<T> : ImageProcessResult<T>
{
    public ImageConvertResult(T result, ImageProcessState state) : base(result, state)
    {
    }
}
