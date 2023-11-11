using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Linq;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using Volo.Abp.Threading;
using Volo.Abp.Uow;
using Volo.Abp.Users;
using Yarp.ReverseProxy.Utilities;

namespace Rubrum.Abp.Graphql.Services;

public abstract class GraphqlService :
    IGraphqlService,
    IUnitOfWorkEnabled,
    IAuditingEnabled,
    ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;

    protected IUnitOfWorkManager UnitOfWorkManager => LazyServiceProvider
        .LazyGetRequiredService<IUnitOfWorkManager>();

    protected IUnitOfWork? CurrentUnitOfWork => UnitOfWorkManager.Current;

    protected IAsyncQueryableExecuter AsyncExecuter => LazyServiceProvider
        .LazyGetRequiredService<IAsyncQueryableExecuter>();

    protected IGuidGenerator GuidGenerator => LazyServiceProvider
        .LazyGetService<IGuidGenerator>(SimpleGuidGenerator.Instance);

    protected ILoggerFactory? LoggerFactory => LazyServiceProvider
        .LazyGetService<ILoggerFactory>();

    protected ILogger Logger => LazyServiceProvider.LazyGetService<ILogger>(_ =>
        LoggerFactory?.CreateLogger(GetType().FullName!) ?? NullLogger.Instance);

    protected ICurrentTenant CurrentTenant => LazyServiceProvider
        .LazyGetRequiredService<ICurrentTenant>();

    protected IDataFilter DataFilter => LazyServiceProvider
        .LazyGetRequiredService<IDataFilter>();

    protected ICurrentUser CurrentUser => LazyServiceProvider
        .LazyGetRequiredService<ICurrentUser>();

    protected ISettingProvider SettingProvider => LazyServiceProvider
        .LazyGetRequiredService<ISettingProvider>();

    protected IClock Clock => LazyServiceProvider
        .LazyGetRequiredService<IClock>();

    protected IAuthorizationService AuthorizationService => LazyServiceProvider
        .LazyGetRequiredService<IAuthorizationService>();

    protected IStringLocalizerFactory StringLocalizerFactory => LazyServiceProvider
        .LazyGetRequiredService<IStringLocalizerFactory>();

    protected ICancellationTokenProvider CancellationTokenProvider => LazyServiceProvider
        .LazyGetRequiredService<ICancellationTokenProvider>();

    protected CancellationToken CancellationToken => CancellationTokenProvider.Token;
}