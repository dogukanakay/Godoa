using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee:IEntity
    {
        [Key]
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string NationalityIdentity { get; set; }
        public DateTime HireDate { get; set; }
        public bool Status { get; set; }
        
    }
}
