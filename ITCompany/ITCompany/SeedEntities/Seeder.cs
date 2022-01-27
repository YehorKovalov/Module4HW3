using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITCompany.Entities;

namespace ITCompany.SeedEntities
{
    public class Seeder : ISeeder
    {
        private readonly ITCompanyDbContext _db;

        public Seeder(ITCompanyDbContext db) => _db = db;

        public async Task SeedAll()
        {
            await SeedTitles();
            await SeedOffices();
            await SeedEmployees();
            await SeedEmployeeProject();
            await SeedClients();
        }

        private async Task SeedEmployees()
        {
            var employees = new List<EmployeeEntity>
            {
                new EmployeeEntity
                {
                    FirstName = "Yehor",
                    LastName = "Kovalov",
                    DateOfBirth = new DateTime(2001, 12, 5),
                    HiredDate = new DateTime(2017, 1, 12),
                    OfficeId = 1,
                    TitleId = 1
                },
                new EmployeeEntity
                {
                    FirstName = "Name2",
                    LastName = "LastName2",
                    DateOfBirth = new DateTime(2001, 12, 5),
                    HiredDate = new DateTime(2022, 1, 12),
                    OfficeId = 1,
                    TitleId = 1
                },
                new EmployeeEntity
                {
                    FirstName = "Name3",
                    LastName = "LastName3",
                    DateOfBirth = new DateTime(2001, 12, 5),
                    HiredDate = new DateTime(2021, 1, 12),
                    OfficeId = 1,
                    TitleId = 2
                },
                new EmployeeEntity
                {
                    FirstName = "Name4",
                    LastName = "LastNam4",
                    DateOfBirth = new DateTime(2001, 12, 5),
                    HiredDate = new DateTime(2020, 1, 12),
                    OfficeId = 1,
                    TitleId = 2
                },
                new EmployeeEntity
                {
                    FirstName = "Name5",
                    LastName = "LastName5",
                    DateOfBirth = new DateTime(2001, 12, 5),
                    HiredDate = new DateTime(2019, 1, 12),
                    OfficeId = 1,
                    TitleId = 2
                }
            };

            await _db.Employees.AddRangeAsync(employees);
            await _db.SaveChangesAsync();
        }

        private async Task SeedOffices()
        {
            await _db.Offices.AddAsync(new OfficeEntity { Location = "Kharkiv, Pobeda 20", Title = "Nix" });
            await _db.SaveChangesAsync();
        }

        private async Task SeedTitles()
        {
            await _db.Titles.AddAsync(new TitleEntity { Name = ".net dev" });
            await _db.Titles.AddAsync(new TitleEntity { Name = "QA" });
            await _db.SaveChangesAsync();
        }

        private async Task SeedEmployeeProject()
        {
            var employeesProjects = new List<EmployeeProjectEntity>
            {
                new EmployeeProjectEntity { EmployeeId = 3, ProjectId = -1, Rate = 5, StartedDate = new DateTime(2022, 1, 4) },
                new EmployeeProjectEntity { EmployeeId = 4, ProjectId = -1, Rate = 2, StartedDate = new DateTime(2022, 1, 4) },
                new EmployeeProjectEntity { EmployeeId = 5, ProjectId = -2, Rate = 5, StartedDate = new DateTime(2022, 12, 8) },
                new EmployeeProjectEntity { EmployeeId = 6, ProjectId = -1, Rate = 5, StartedDate = new DateTime(2022, 1, 4) },
                new EmployeeProjectEntity { EmployeeId = 7, ProjectId = -2, Rate = 5, StartedDate = new DateTime(2022, 12, 8) }
            };

            await _db.EmployeeProjects.AddRangeAsync(employeesProjects);
            await _db.SaveChangesAsync();
        }

        private async Task SeedClients()
        {
            var clients = new List<ClientEntity>
            {
                new ClientEntity { CooperationStartDate = new DateTime(2020, 12, 6), Email = "Email 6", Name = "Name6", PhoneNumber = "380505675294" },
                new ClientEntity { CooperationStartDate = new DateTime(2020, 12, 7), Email = "Email 7", Name = "Name7", PhoneNumber = "380505675292" },
                new ClientEntity { CooperationStartDate = new DateTime(2020, 12, 8), Email = "Email 8", Name = "Name8", PhoneNumber = "380505675293" },
                new ClientEntity { CooperationStartDate = new DateTime(2020, 12, 9), Email = "Email 9", Name = "Name9", PhoneNumber = "380505675291" },
                new ClientEntity { CooperationStartDate = new DateTime(2020, 12, 10), Email = "Email 10", Name = "Name10", PhoneNumber = "380505675296" },
            };

            await _db.Clients.AddRangeAsync(clients);
            await _db.SaveChangesAsync();
        }
    }
}
