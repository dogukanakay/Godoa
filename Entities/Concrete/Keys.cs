using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    
    public class Keys:IEntity
    {
        [Key]
        public int KeyId { get; set; }
        public int GameId { get; set; }
        public int KeyDetail { get; set; }
        public int EndDate { get; set; }
    }
}
