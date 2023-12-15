using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VirtualCurrencyType : IEntity
    {
        [Key]
        public int VirtualCurrencyTypeId { get; set; }
        public string VirtualCurrencyTypeName { get; set; }
        public int GameId { get; set; }


    }
}
