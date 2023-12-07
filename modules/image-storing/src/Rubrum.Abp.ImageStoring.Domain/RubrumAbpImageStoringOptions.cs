namespace Rubrum.Abp.ImageStoring;

public class RubrumAbpImageStoringOptions
{
    public string NameContainer { get; set; } = "images";
    public string PrefixUrl { get; set; } = "api/image-storing/images";
    public int Lifetime { get; set; } = 60 * 10;
}
