namespace Rubrum.Abp.ImageStoring;

public static class ImageStoringTestConstants
{
    public static string ImageTag => "98ffe60d-6096-4504-8afe-2f963e32a961";

    public static Guid SvgId { get; } = Guid.Parse("f364a1ec-39a2-4dee-80aa-6b9eb422aebb");

    public static Guid JpegId { get; } = Guid.Parse("f28275dc-11d5-401c-aaa8-6485082d408c");

    public static Guid JpgId { get; } = Guid.Parse("cb0db529-bb65-4226-af0e-ac39614bb47f");

    public static Guid TifId { get; } = Guid.Parse("c9159663-ba7a-4739-8c40-c8c0ea223c77");

    public static Guid PngId { get; } = Guid.Parse("48ffbb3b-75de-4346-91c9-d24ae06ad682");

    public static Guid GifId { get; } = Guid.Parse("ceb5070b-a5c9-431c-8b8a-3c0ef77ae033");

    public static Guid[] ImageIds => [SvgId, JpegId, JpgId, TifId, PngId, GifId];
}
