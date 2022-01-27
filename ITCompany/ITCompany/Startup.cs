using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITCompany.SeedEntities;
using ITCompany.Services;
using ITCompany.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ITCompany
{
    public class Startup
    {
        public async Task Run()
        {
            var serviceProvider = ConfigureServices();
            var app = serviceProvider?.GetService<ConsoleTestingQueries>();
            await app?.Run();
        }

        public IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ISeeder, Seeder>();
            serviceCollection.AddSingleton<IConfigurationServices, ConfigurationServices>();
            serviceCollection.AddTransient<IQueries, Queries>();
            serviceCollection.AddTransient<ConsoleTestingQueries>();

            var connectionString = new ConfigurationServices().ConnectionString;
            serviceCollection.AddDbContext<ITCompanyDbContext>(o => o.UseSqlServer(connectionString));

            return serviceCollection.BuildServiceProvider();
        }
    }
}
