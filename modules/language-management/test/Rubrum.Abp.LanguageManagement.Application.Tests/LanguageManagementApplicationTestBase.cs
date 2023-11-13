using Rubrum.Abp.LanguageManagement.EntityFrameworkCore;

namespace Rubrum.Abp.LanguageManagement;

public abstract class LanguageManagementApplicationTestBase :
    LanguageManagementTestBase<RubrumAbpLanguageManagementApplicationTestModule>
{
    protected virtual void UsingDbContext(Action<ILanguageManagementDbContext> action)
    {
        using var dbContext = GetRequiredService<ILanguageManagementDbContext>();
        action.Invoke(dbContext);
    }

    protected virtual T UsingDbContext<T>(Func<ILanguageManagementDbContext, T> action)
    {
        using var dbContext = GetRequiredService<ILanguageManagementDbContext>();
        return action.Invoke(dbContext);
    }
}
