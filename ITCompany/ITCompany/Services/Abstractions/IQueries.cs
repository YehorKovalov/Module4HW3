using System.Collections.Generic;
using System.Threading.Tasks;
using ITCompany.Entities;

namespace ITCompany.Services.Abstractions
{
    public interface IQueries
    {
        Task<List<EmployeeEntity>> GetEmployeesWithTitleAndOfficeOrNull();
        Task<List<string>> GetEmployeesWorkingExperiencesOrNull();
        Task<bool> ModifyEmployeesDemo(int id1, int id2);
        Task<bool> AddEmployeesWithTitlesAndProjects(EmployeeEntity employee);
        Task<bool> DeleteEmployeeTest(int id);
        Task<List<string>> GroupEmployeesAndGetTitlesThatDontIncludeLetter_a();
    }
}