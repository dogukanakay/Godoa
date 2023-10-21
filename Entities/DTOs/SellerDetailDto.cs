using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SellerDetailDto
    {
        public int  SellerId { get; set; }
        public string UserName {  get; set; }
        public string NationalityIdentity { get; set; }
        public string Adress { get; set; }
        public double SalesScore { get; set; }
    }
}
