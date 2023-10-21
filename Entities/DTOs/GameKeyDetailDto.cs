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
        public float Price { get; set; }
        public int Status { get; set; }

    }
}