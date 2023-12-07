using System;
using System.Linq.Expressions;
using Rubrum.Abp.LanguageManagement;
using Rubrum.Abp.LanguageManagement.Mapper.Interfaces;

namespace Rubrum.Abp.LanguageManagement.Mapper.Interfaces
{
    public partial class SystemLanguageMapper : ISystemLanguageMapper
    {
        public Expression<Func<SystemLanguage, SystemLanguageDto>> Expression => p1 => new SystemLanguageDto()
        {
            Name = p1.Name,
            IsDeleted = p1.IsDeleted,
            DeleterId = p1.DeleterId,
            DeletionTime = p1.DeletionTime,
            LastModificationTime = p1.LastModificationTime,
            LastModifierId = p1.LastModifierId,
            CreationTime = p1.CreationTime,
            CreatorId = p1.CreatorId,
            Id = p1.Id
        };
        public SystemLanguageDto Map(SystemLanguage p2)
        {
            return p2 == null ? null : new SystemLanguageDto()
            {
                Name = p2.Name,
                IsDeleted = p2.IsDeleted,
                DeleterId = p2.DeleterId,
                DeletionTime = p2.DeletionTime,
                LastModificationTime = p2.LastModificationTime,
                LastModifierId = p2.LastModifierId,
                CreationTime = p2.CreationTime,
                CreatorId = p2.CreatorId,
                Id = p2.Id
            };
        }
    }
}