using System;
using System.Collections.Generic;

namespace ITCompany.Entities
{
    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int? OfficeId { get; set; }
        public OfficeEntity Office { get; set; }

        public int? TitleId { get; set; }
        public TitleEntity Title { get; set; }

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
        public List<EmployeeProjectEntity> EmployeeProject { get; set; } = new List<EmployeeProjectEntity>();
    }
}
