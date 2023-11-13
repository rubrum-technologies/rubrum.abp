using System;
using System.Linq.Expressions;
using Rubrum.Abp.LanguageManagement;
using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;

namespace Rubrum.Abp.LanguageManagement.Mapper.Interfaces
{
    public partial class LanguageMapper : ILanguageMapper
    {
        public Expression<Func<Language, LanguageDto>> Expression => p1 => new LanguageDto()
        {
            Name = p1.Name,
            Id = p1.Id
        };
        public LanguageDto Map(Language p2)
        {
            return p2 == null ? null : new LanguageDto()
            {
                Name = p2.Name,
                Id = p2.Id
            };
        }
    }
}
