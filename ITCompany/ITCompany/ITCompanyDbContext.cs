using ITCompany.Entities;
using ITCompany.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
        }
    }
}
