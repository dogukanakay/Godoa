using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class KeyDetailDto
    {
        public int KeyId { get; set; }
        public string GameName { get; set; }
        public string KeyDetail { get; set; }
        public DateTime EndDate { get; set; }

    }
}
