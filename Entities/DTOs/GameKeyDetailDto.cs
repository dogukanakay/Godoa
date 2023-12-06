﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GameKeyDetailDto
    {
        public int GameKeyId { get; set; }  
        public string GameName { get; set; }
        public string KeyDetail { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }

    }
}
