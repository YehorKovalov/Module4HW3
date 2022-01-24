using ITCompany.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITCompany.EntitiesConfigs
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProjectEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectEntity> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(ep => ep.EmployeeProjectId);
            builder.Property(ep => ep.EmployeeProjectId).ValueGeneratedOnAdd();
            builder.Property(ep => ep.Rate).IsRequired().HasColumnType("money");
            builder.Property(ep => ep.StartedDate).IsRequired().HasColumnType("datetime2").HasMaxLength(7);

            builder.HasOne(e => e.Employee)
                .WithMany(ep => ep.EmployeeProject)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Project)
                .WithMany(ep => ep.EmployeeProject)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
