using System;
using Rubrum.Abp.ImageStoring;
using Rubrum.Abp.ImageStoring.Mapper.Interfaces;

namespace Rubrum.Abp.ImageStoring.Mapper.Interfaces
{
    public partial class ImageMapper : IImageMapper
    {
        public ImageInformationDto Map(ImageInformation p1)
        {
            return p1 == null ? null : new ImageInformationDto()
            {
                Tag = p1.Tag,
                FileName = p1.FileName,
                SystemFileName = p1.SystemFileName,
                IsDisposable = p1.IsDisposable,
                EntityVersion = p1.EntityVersion,
                IsDeleted = p1.IsDeleted,
                DeleterId = p1.DeleterId,
                DeletionTime = p1.DeletionTime,
                LastModificationTime = p1.LastModificationTime,
                LastModifierId = p1.LastModifierId,
                CreationTime = p1.CreationTime,
                CreatorId = p1.CreatorId,
                Id = p1.Id
            };
        }
        public ImageInformationDto Map(ImageFile p2)
        {
            return p2 == null ? null : new ImageInformationDto()
            {
                Tag = p2.Information == null ? null : p2.Information.Tag,
                FileName = p2.Information == null ? null : p2.Information.FileName,
                SystemFileName = p2.Information == null ? null : p2.Information.SystemFileName,
                IsDisposable = funcMain1(p2.Information == null ? null : (bool?)p2.Information.IsDisposable),
                EntityVersion = funcMain2(p2.Information == null ? null : (int?)p2.Information.EntityVersion),
                IsDeleted = funcMain3(p2.Information == null ? null : (bool?)p2.Information.IsDeleted),
                DeleterId = p2.Information == null ? null : p2.Information.DeleterId,
                DeletionTime = p2.Information == null ? null : p2.Information.DeletionTime,
                LastModificationTime = p2.Information == null ? null : p2.Information.LastModificationTime,
                LastModifierId = p2.Information == null ? null : p2.Information.LastModifierId,
                CreationTime = funcMain4(p2.Information == null ? null : (DateTime?)p2.Information.CreationTime),
                CreatorId = p2.Information == null ? null : p2.Information.CreatorId,
                Id = funcMain5(p2.Information == null ? null : (Guid?)p2.Information.Id)
            };
        }
        
        private bool funcMain1(bool? p3)
        {
            return p3 == null ? false : (bool)p3;
        }
        
        private int funcMain2(int? p4)
        {
            return p4 == null ? 0 : (int)p4;
        }
        
        private bool funcMain3(bool? p5)
        {
            return p5 == null ? false : (bool)p5;
        }
        
        private DateTime funcMain4(DateTime? p6)
        {
            return p6 == null ? default(DateTime) : (DateTime)p6;
        }
        
        private Guid funcMain5(Guid? p7)
        {
            return p7 == null ? default(Guid) : (Guid)p7;
        }
    }
}