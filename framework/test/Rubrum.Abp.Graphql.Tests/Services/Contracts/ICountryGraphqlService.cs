using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;

namespace Rubrum.Abp.Graphql.Services.Contracts;

public interface ICountryGraphqlService : ICrudGraphqlService<CountryDto, Guid, CreateCountryInput, UpdateCountryInput>;
