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
        public string ProductCategoryName { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public bool Status { get; set; }
    }
}
