using System.Collections.Generic;

namespace ITCompany.Entities
{
    public class OfficeEntity
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}
