using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class VirtualCurrencyDetailDto :IDto
    {
        public int CurrencyId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int ProductId { get; set; }
        public string GameName { get; set; }
        public string CurrencyTypeName { get; set; }
        public string ProductName { get; set; }
        public string CurrencyKey { get; set; }
        public string IsUsed { get; set; }

    }
}
