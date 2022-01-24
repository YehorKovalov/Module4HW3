using System.Collections.Generic;

namespace ITCompany.Entities
{
    public class TitleEntity
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}
