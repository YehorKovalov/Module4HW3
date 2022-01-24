using System;
using ITCompany.Entities;
using ITCompany.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ITCompany
{
    public class ITCompanyDbContext : DbContext
    {
        public ITCompanyDbContext(DbContextOptions<ITCompanyDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<TitleEntity> Titles { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<OfficeEntity> Offices { get; set; }
        public DbSet<EmployeeProjectEntity> EmployeeProjects { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
