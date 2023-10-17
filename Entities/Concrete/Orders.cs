using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    internal class Orders : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public float TotalPrice { get; set; }
        public String? TradeUrl { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
