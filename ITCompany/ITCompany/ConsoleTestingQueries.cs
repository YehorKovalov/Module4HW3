using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITCompany.Entities;
using ITCompany.SeedEntities;
using ITCompany.Services.Abstractions;

namespace ITCompany
{
    public class ConsoleTestingQueries
    {
        private readonly IQueries _queries;
        private readonly ISeeder _seeder;

        public ConsoleTestingQueries(
            IQueries queries,
            ISeeder seeder)
        {
            _queries = queries;
            _seeder = seeder;
        }

        public async Task Run()
        {
            /*            await _seeder.SeedAll();*/

            var employees = await _queries.GetEmployeesWithTitleAndOfficeOrNull();

            var experiences = await _queries.GetEmployeesWorkingExperiencesOrNull();

            var modifyingResult = await _queries.ModifyEmployeesDemo(3, 4);

            var addingResult = await _queries.AddEmployeesWithTitlesAndProjects(new EmployeeEntity
            {
                FirstName = "Name 10",
                LastName = "Surname 10",
                DateOfBirth = new DateTime(1993, 12, 1),
                HiredDate = new DateTime(2011, 11, 4),
                Title = new TitleEntity { Name = "Sybersecurity engineer" },
                EmployeeProject = new List<EmployeeProjectEntity>
                {
                    new EmployeeProjectEntity
                    {
                        StartedDate = new DateTime(2020, 12, 5),
                        Rate = 2,
                        Project = new ProjectEntity
                        {
                            Name = "Project forth task",
                            StartedDate = new DateTime(2020, 11, 9),
                            Budget = 23434
                        }
                    }
                }
            });

            var deletingResult = await _queries.DeleteEmployeeTest(6);

            var titles = await _queries.GroupEmployeesAndGetTitlesThatDontIncludeLetter_a();
        }
    }
}
