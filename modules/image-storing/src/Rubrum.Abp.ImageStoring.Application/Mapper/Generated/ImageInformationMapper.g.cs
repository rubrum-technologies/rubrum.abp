using System;
using System.Linq.Expressions;
using Rubrum.Abp.ImageStoring;
using Rubrum.Abp.ImageStoring.Mapper;

namespace Rubrum.Abp.ImageStoring.Mapper
{
    public partial class ImageInformationMapper : IImageInformationMapper
    {
        public Expression<Func<ImageInformation, ImageInformationDto>> Projection => p1 => new ImageInformationDto()
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
        public ImageInformationDto Map(ImageInformation p2)
        {
            return p2 == null ? null : new ImageInformationDto()
            {
                Tag = p2.Tag,
                FileName = p2.FileName,
                SystemFileName = p2.SystemFileName,
                IsDisposable = p2.IsDisposable,
                EntityVersion = p2.EntityVersion,
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
        public ImageInformationDto Map(ImageFile p3)
        {
            return p3 == null ? null : new ImageInformationDto()
            {
                Tag = p3.Tag,
                FileName = p3.Information == null ? null : p3.Information.FileName,
                SystemFileName = p3.SystemFileName,
                IsDisposable = p3.IsDisposable,
                EntityVersion = funcMain1(p3.Information == null ? null : (int?)p3.Information.EntityVersion),
                IsDeleted = funcMain2(p3.Information == null ? null : (bool?)p3.Information.IsDeleted),
                DeleterId = p3.Information == null ? null : p3.Information.DeleterId,
                DeletionTime = p3.Information == null ? null : p3.Information.DeletionTime,
                LastModificationTime = p3.Information == null ? null : p3.Information.LastModificationTime,
                LastModifierId = p3.Information == null ? null : p3.Information.LastModifierId,
                CreationTime = funcMain3(p3.Information == null ? null : (DateTime?)p3.Information.CreationTime),
                CreatorId = p3.Information == null ? null : p3.Information.CreatorId,
                Id = p3.Id
            };
        }
        
        private int funcMain1(int? p4)
        {
            return p4 == null ? 0 : (int)p4;
        }
        
        private bool funcMain2(bool? p5)
        {
            return p5 == null ? false : (bool)p5;
        }
        
        private DateTime funcMain3(DateTime? p6)
        {
            return p6 == null ? default(DateTime) : (DateTime)p6;
        }
    }
}