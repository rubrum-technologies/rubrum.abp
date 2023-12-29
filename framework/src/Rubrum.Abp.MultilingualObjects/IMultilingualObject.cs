namespace Rubrum.Abp.MultilingualObjects;

public interface IMultilingualObject<out T>
    where T : IObjectTranslation
{
    IReadOnlyList<T> Translations { get; }
}
