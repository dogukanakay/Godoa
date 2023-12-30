using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ReturnOrderDto : IDto
    {
        public string ProductName { get; set; }
        public string Key { get; set; }
    }
}
