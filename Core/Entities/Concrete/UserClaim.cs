using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserClaim:IEntity
    {
        [Key]
        public int UserClaimId { get; set; }
        public int UserId { get; set; }
        public int ClaimId { get; set; }
    }
}
