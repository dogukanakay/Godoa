using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   
    public class GameKey:IEntity
    {
        [Key]
        public int GameKeyId { get; set; }
        public int GameId { get; set; }
        public int ProductId { get; set; } 
        public string KeyOfGame { get; set; }
        public bool IsUsed { get; set; }

    }
}
