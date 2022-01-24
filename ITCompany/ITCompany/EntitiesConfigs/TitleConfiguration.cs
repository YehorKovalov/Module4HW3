using ITCompany.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITCompany.EntitiesConfigs
{
    public class TitleConfiguration : IEntityTypeConfiguration<TitleEntity>
    {
        public void Configure(EntityTypeBuilder<TitleEntity> builder)
        {
            builder.ToTable("Title").HasKey(t => t.TitleId);
            builder.Property(t => t.TitleId).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
        }
    }
}
