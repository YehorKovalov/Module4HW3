using System;
using System.Collections.Generic;
using ITCompany.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITCompany.EntitiesConfigs
{
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money");
            builder.Property(p => p.StartedDate).IsRequired().HasColumnType("datetime2").HasMaxLength(7);
            builder.HasOne(p => p.Client)
                .WithMany(o => o.Projects)
                .HasForeignKey(p => p.ClientID)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasData(new List<ProjectEntity>()
            {
                new ProjectEntity
                {
                    ProjectId = -1,
                    Name = "Auto Builder",
                    Budget = 1000000,
                    StartedDate = DateTime.UtcNow,
                    ClientID = -1
                },
                new ProjectEntity
                {
                    ProjectId = -2,
                    Name = "Ambulance caller",
                    Budget = 240000,
                    StartedDate = DateTime.UtcNow,
                    ClientID = -2
                },
                new ProjectEntity
                {
                    ProjectId = -3,
                    Name = "Tickects Booking",
                    Budget = 1000000,
                    StartedDate = DateTime.UtcNow,
                    ClientID = -3
                },
                new ProjectEntity
                {
                    ProjectId = -4,
                    Name = "Test project 1",
                    Budget = 1000000,
                    StartedDate = DateTime.UtcNow,
                    ClientID = -4
                },
                new ProjectEntity
                {
                    ProjectId = -5,
                    Name = "Test project 2",
                    Budget = 1000000,
                    StartedDate = DateTime.UtcNow,
                    ClientID = -5
                }
            });
        }
    }
}
