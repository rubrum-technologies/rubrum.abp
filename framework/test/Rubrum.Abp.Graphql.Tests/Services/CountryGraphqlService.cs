using System.Linq.Expressions;
using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Rubrum.Abp.Graphql.Domain;
using Rubrum.Abp.Graphql.Services.Contracts;
using Volo.Abp.Domain.Repositories;

namespace Rubrum.Abp.Graphql.Services;

public class CountryGraphqlService :
    CrudGraphqlService<Country, CountryDto, Guid, CreateCountryInput, UpdateCountryInput>,
    ICountryGraphqlService
{
    public CountryGraphqlService(IRepository<Country, Guid> repository) : base(repository)
    {
    }

    protected override Expression<Func<Country, CountryDto>> ToDtoExpression =>
        x => new CountryDto { Id = x.Id, Name = x.Name };

    protected override Task<Country> ToEntityAsync(CreateCountryInput input)
    {
        return Task.FromResult(new Country(GuidGenerator.Create(), input.Name));
    }

    protected override Task ToEntityAsync(Country entity, UpdateCountryInput input)
    {
        entity.Name = input.Name;
        return Task.CompletedTask;
    }
}