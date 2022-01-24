using System;
using ITCompany.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITCompany.EntitiesConfigs
{
    public class OfficeConfiguration : IEntityTypeConfiguration<OfficeEntity>
    {
        public void Configure(EntityTypeBuilder<OfficeEntity> builder)
        {
            builder.ToTable("Office").HasKey(o => o.OfficeId);
            builder.Property(o => o.OfficeId).ValueGeneratedOnAdd();
            builder.Property(o => o.Title).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Location).IsRequired().HasMaxLength(100);
        }
    }
}
