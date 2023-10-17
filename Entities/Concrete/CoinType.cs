using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CoinType : IEntity
    {
        [Key]
        public int CoinTypeId { get; set; }
        public int CointTypeName { get; set; }
        public int GameId { get; set; }
    }
}
