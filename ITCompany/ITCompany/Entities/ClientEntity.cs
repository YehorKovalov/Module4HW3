using System;
using System.Collections.Generic;

namespace ITCompany.Entities
{
    public class ClientEntity
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset CooperationStartDate { get; set; }
        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
