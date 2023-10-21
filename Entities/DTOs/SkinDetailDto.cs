using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SkinDetailDto : IDto
    {
        public int SkinId { get; set; }
        public string SkinName { get; set; }
        public string SellerName { get; set; }
        public string GameName { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool Statu { get; set; }
    }
}
