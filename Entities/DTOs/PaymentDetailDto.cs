using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PaymentDetailDto
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Status { get; set; }
    }
}
