using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GameKeyDetailDto : IDto
    {
        public int GameKeyId { get; set; }
        public int GameId { get; set; }
        public int ProductId { get; set; }
        public string GameName { get; set; }
        public string ProductName { get; set; }
        public string KeyDetail { get; set; }
        public string IsUsed { get; set; }

    }
}
