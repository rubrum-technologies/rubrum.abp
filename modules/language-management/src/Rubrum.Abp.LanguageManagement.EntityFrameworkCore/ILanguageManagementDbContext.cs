using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rubrum.Abp.LanguageManagement.EntityFrameworkCore;

public interface ILanguageManagementDbContext : IAbpEfCoreDbContext
{
    DbSet<Language> Languages { get; }
}
