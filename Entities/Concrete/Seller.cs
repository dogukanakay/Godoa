using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Seller : IEntity
    {
        [Key]
        public int SellerId { get; set; }
        public int UserID { get; set; }
        public string NationalityIdentity { get; set; }
        public string Adress { get; set; }
        public double SalesScore { get; set; }


    }
}
