using System;
using System.Collections.Generic;
using System.IO;
using ITCompany.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ITCompany.Services
{
    public class ConfigurationServices : IConfigurationServices
    {
        private string _connectionString;

        public ConfigurationServices()
        {
            Init();
        }

        public string ConnectionString => _connectionString;

        private void Init()
        {
            const string configPath = "appsettings.json";
            const string connectionStringName = "DefaultConnection";
            var builder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            builder.SetBasePath(currentDirectory);
            builder.AddJsonFile(configPath);
            var config = builder.Build();
            _connectionString = config.GetConnectionString(connectionStringName);
        }
    }
}
