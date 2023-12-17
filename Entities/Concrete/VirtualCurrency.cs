using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VirtualCurrency:IEntity
    {
        [Key]
        public int CurrencyId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int ProductId {  get; set; }
        public string CurrencyKey { get; set; }
        public bool IsUsed { get; set; }


    }
}
