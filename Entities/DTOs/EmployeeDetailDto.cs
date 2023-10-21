using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EmployeeDetailDto
    {
        public int EmployeeId { get; set; }
        public string UserName { get; set; } 
        public string NationalityIdentity { get; set; } 
        public string Address { get; set; }
        public bool Status { get; set; }
        public DateTime HireDate { get; set; }
    }
}
