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
<<<<<<< HEAD
        public int ProductCategoryId { get; set; }
=======
        public string GameName { get; set; }
>>>>>>> db4722c4c4a36d55cae5aaa0371e864f4a1da301
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public bool Status { get; set; }
    }
}
