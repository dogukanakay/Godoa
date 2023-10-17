using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class InGameCoin:IEntity
    {
        [Key]
        public int InGameCoinId { get; set; }
        public int CoinTypeId { get; set; }
        public int Amount {  get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }


    }
}
