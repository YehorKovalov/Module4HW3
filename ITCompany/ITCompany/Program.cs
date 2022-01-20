using System.IO;
using System.Threading.Tasks;
using ITCompany.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ITCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            const string configPath = "appsettings.json";
            var builder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            builder.SetBasePath(currentDirectory);
            builder.AddJsonFile(configPath);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionBuilder = new DbContextOptionsBuilder<ITCompanyDbContext>();
            var options = optionBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (var db = new ITCompanyDbContext(options))
            {
                await db.SaveChangesAsync();
            }
        }
    }
}