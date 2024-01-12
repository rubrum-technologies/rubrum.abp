using Rubrum.Abp.Ddd.HumanFriendly;
using Rubrum.Abp.Graphql.HumanFriendly.Application;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.Graphql.HumanFriendly.Services.Contracts;

public interface ICountryAppService :
    IReadOnlyAppService<CountryDto, Guid, PagedAndSortedResultRequestDto>,
    IHumanFriendlyAppService<CountryDto, Guid>;
