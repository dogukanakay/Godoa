using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; } 
        public int Amount { get; set; }
        public float TotalPrice { get; set; }
        public string TradeUrl { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
