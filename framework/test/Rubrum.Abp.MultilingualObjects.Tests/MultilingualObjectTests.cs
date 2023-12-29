using Rubrum.Abp.MultilingualObjects.Models;
using Shouldly;
using Xunit;

namespace Rubrum.Abp.MultilingualObjects;

public class MultilingualObjectTests
{
    private readonly Country _country = new("Россия");

    [Fact]
    public void FindTranslation()
    {
        var translation = _country.FindTranslation("ru");
        translation.ShouldNotBeNull();
    }

    [Fact]
    public void FindTranslation_Translation_Not_Found()
    {
        var translation = _country.FindTranslation("en");
        translation.ShouldBeNull();
    }

    [Fact]
    public void GetTranslation()
    {
        var translation = _country.GetTranslation("ru");
        translation.ShouldNotBeNull();
    }

    [Fact]
    public void GetTranslation_Translation_Not_Found()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            _country.GetTranslation("en");
        });
    }
}
