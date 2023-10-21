using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class InGameCoinDetailDto : IDto
    {
        public int InGameCoinId { get; set; }
        public string CoinTypeName { get; set; } 
        public int Amount { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
    }
}
