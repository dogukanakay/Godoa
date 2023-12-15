using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
     public class VirtualCurrencyTypeDetailDto : IDto
    {
        public int VirtualCurrencyTypeId { get; set; }
        public string VirtualCurrencyTypeName { get; set; }
        public string GameName { get; set; }

    }
}
