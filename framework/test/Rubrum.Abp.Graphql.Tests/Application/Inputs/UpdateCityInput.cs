﻿namespace Rubrum.Abp.Graphql.Application.Inputs;

public class UpdateCityInput
{
    public required int Id { get; init; }
    public required Guid CountryId { get; init; }
    public required string Name { get; init; }
}