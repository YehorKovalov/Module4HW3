using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITCompany.Entities;
using ITCompany.Helpers;
using ITCompany.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ITCompany.Services
{
    public class Queries : BaseDataServices, IQueries
    {
        private readonly ITCompanyDbContext _db;

        public Queries(ITCompanyDbContext context) => _db = context;

        public async Task<List<EmployeeEntity>> GetEmployeesWithTitleAndOfficeOrNull()
        {
            return await _db.Employees.Include(e => e.Office)
                .Include(e => e.Title)
                .ToListAsync();
        }

        public async Task<List<string>> GetEmployeesWorkingExperiencesOrNull()
        {
            var employeesHiredDates = await _db.Employees.Select(e => e.HiredDate).ToListAsync();
            var experiences = employeesHiredDates.Select(e => (DateTime.UtcNow - e).ToString());
            return experiences.ToList();
        }

        public async Task<bool> ModifyEmployeesDemo(int id1, int id2)
        {
            var employee1 = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id1);
            var employee2 = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id2);

            if (employee1 == null || employee2 == null)
            {
                return false;
            }

            employee1.FirstName = "third modified employee";
            employee2.FirstName = "forth modified employee";

            var modifiedEmployees = new List<EmployeeEntity>();
            modifiedEmployees.Add(employee1);
            modifiedEmployees.Add(employee2);

            return await SafeExecute(() => _db.Employees.UpdateRange(modifiedEmployees), _db, true);
        }

        public async Task<bool> AddEmployeesWithTitlesAndProjects(EmployeeEntity employee)
        {
            if (employee == null || employee.Title == null || employee.EmployeeProject == null)
            {
                return false;
            }

            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeTest(int id)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee == null)
            {
                return false;
            }

            return await SafeExecute(() => _db.Employees.Remove(employee), _db, true);
        }

        public async Task<List<string>> GroupEmployeesAndGetTitlesThatDontIncludeLetter_a()
        {
            return await _db.Employees
                .GroupBy(e => e.Title.Name)
                .Select(e => e.Key)
                .Where(t => EF.Functions.Like(t, "%a%") == false)
                .ToListAsync();
        }
    }
}
