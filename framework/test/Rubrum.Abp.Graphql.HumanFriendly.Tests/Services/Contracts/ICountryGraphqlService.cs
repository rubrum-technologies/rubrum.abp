using Rubrum.Abp.Graphql.HumanFriendly.Application;
using Rubrum.Abp.Graphql.Services;

namespace Rubrum.Abp.Graphql.HumanFriendly.Services.Contracts;

public interface ICountryGraphqlService : ICountryAppService, IReadOnlyGraphqlService<CountryDto, Guid>;
