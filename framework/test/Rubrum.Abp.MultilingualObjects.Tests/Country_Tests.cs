using Rubrum.Abp.MultilingualObjects.Models;
using Shouldly;
using Xunit;

namespace Rubrum.Abp.MultilingualObjects;

public class CountryTests
{
    private readonly Country _country = new("Россия");

    [Fact]
    public void AddTranslation()
    {
        _country.ChangeTranslation(new CountryTranslation("en", "USA"));
        var translation = _country.FindTranslation("en");
        translation.ShouldNotBeNull();
    }
}
