using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Game:IEntity
    {
        [Key]
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int CategoryId { get; set; }
        public int PlatformId { get; set; }
        public int TypeId { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        
    }
}
