using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Skin : IEntity
    {
        [Key]
        public int SkinId { get; set; }
        public string SkinName { get; set; }
        public int SellerId { get; set; }
        public int GameId { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
