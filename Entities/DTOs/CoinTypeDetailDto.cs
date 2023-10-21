using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
     public class CoinTypeDetailDto : IDto
    {
        public int CoinTypeId { get; set; }
        public string CoinTypeName { get; set; }
        public string GameName { get; set; }

    }
}
