namespace Rubrum.Abp.ImageStoring;

public class ChangeTagInput
{
    public required List<Guid> Ids { get; init; }

    public string? Tag { get; init; }
}
