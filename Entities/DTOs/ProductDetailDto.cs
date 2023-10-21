using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SkinName { get; set; }  
        public string GameKeyDetail { get; set; }
        public string InGameCoinName { get; set; } 
    }
}
