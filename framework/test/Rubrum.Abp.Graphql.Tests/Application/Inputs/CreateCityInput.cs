namespace Rubrum.Abp.Graphql.Application.Inputs;

public class CreateCityInput
{
    public required Guid CountryId { get; init; }
    public required string Name { get; init; }
}
