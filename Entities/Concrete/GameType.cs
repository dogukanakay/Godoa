using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GameType:IEntity
    {
        [Key]
        public int GameTypeId { get; set; }
        public string GameTypeName { get; set; }
    }
}
