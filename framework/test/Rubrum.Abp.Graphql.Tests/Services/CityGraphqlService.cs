using System.Linq.Expressions;
using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Domain;
using Rubrum.Abp.Graphql.Services.Contracts;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public class CityGraphqlService :
    CrudGraphqlService<City, CityDto, int, CreateCityInput, UpdateCityInput>,
    ICityGraphqlService
{
    public CityGraphqlService(IRepository<City, int> repository) : base(repository)
    {
    }

    protected override Expression<Func<City, CityDto>> ToDtoExpression =>
        x => new CityDto { Id = x.Id, CountryId = x.CountryId, Name = x.Name };

    protected override Task<City> ToEntityAsync(CreateCityInput input)
    {
        var result = new City(Random.Shared.Next(), input.CountryId, input.Name);
        return Task.FromResult(result);
    }

    protected override Task ToEntityAsync(City entity, UpdateCityInput input)
    {
        entity.CountryId = input.CountryId;
        entity.Name = input.Name;

        return Task.CompletedTask;
    }
}