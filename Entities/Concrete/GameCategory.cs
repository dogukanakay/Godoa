using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GameCategory : IEntity
    {
        [Key]
        public int GameCategoryId { get; set; }
        public string GameCategoryName { get; set; }
    }
}
