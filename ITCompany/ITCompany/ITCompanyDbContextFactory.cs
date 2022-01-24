using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ITCompany
{
    public class ITCompanyDbContextFactory : IDesignTimeDbContextFactory<ITCompanyDbContext>
    {
        public ITCompanyDbContext CreateDbContext(string[] args)
        {
            const string configPath = "appsettings.json";
            var optionsBuilder = new DbContextOptionsBuilder<ITCompanyDbContext>();

            var builder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            builder.SetBasePath(currentDirectory);
            builder.AddJsonFile(configPath);
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new ITCompanyDbContext(optionsBuilder.Options);
        }
    }
}
