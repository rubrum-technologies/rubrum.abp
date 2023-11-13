using Rubrum.Abp.MultilingualObjects;
using Volo.Abp.Application.Dtos;

namespace Rubrum.Abp.Graphql.MultilingualObjects.Models;

public class Country : EntityDto<Guid>, IMultilingualObject<CountryTranslation>
{
    private readonly List<CountryTranslation> _translations = new();

    public Country(string name)
    {
        _translations.Add(new CountryTranslation("ru", name));
    }

    public IReadOnlyList<CountryTranslation> Translations => _translations.AsReadOnly();

    public void ChangeTranslation(CountryTranslation translation)
    {
        _translations.RemoveAll(x => x.Language == translation.Language);
        _translations.Add(translation);
    }
}
