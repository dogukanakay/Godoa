using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GameDetailDto : IDto
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string CategoryName { get; set; }
        public string PlatformName { get; set; }
        public string TypeName { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
