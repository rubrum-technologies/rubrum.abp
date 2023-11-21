using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static Rubrum.Abp.LanguageManagement.RubrumAbpLanguageManagementDbProperties;

namespace Rubrum.Abp.LanguageManagement.EntityFrameworkCore;

[ConnectionStringName(ConnectionStringName)]
public interface ILanguageManagementDbContext : IAbpEfCoreDbContext
{
    DbSet<Language> Languages { get; }
}
