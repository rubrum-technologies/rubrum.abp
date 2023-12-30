using Rubrum.Abp.Graphql.Application.Dtos;
using Rubrum.Abp.Graphql.Application.Inputs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Rubrum.Abp.Graphql.Services.Contracts;

public interface ICityAppService :
    ICrudAppService<CityDto, int, PagedAndSortedResultRequestDto, CreateCityInput, UpdateCityInput>;
