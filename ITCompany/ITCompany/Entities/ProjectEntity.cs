using System;
using System.Collections.Generic;

namespace ITCompany.Entities
{
    public class ProjectEntity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
        public List<EmployeeProjectEntity> EmployeeProject { get; set; } = new List<EmployeeProjectEntity>();
        public int ClientID { get; set; }
        public ClientEntity Client { get; set; }
    }
}
