using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Rubrum.Abp.ImageStoring;

public class NotSupportImageException : BusinessException
{
    public NotSupportImageException(
        Exception? innerException = null,
        LogLevel logLevel = LogLevel.Warning)
        : base(
            "ImageStoring:NotSupportImageExtensionException",
            null,
            null,
            innerException,
            logLevel)
    {
    }
}
