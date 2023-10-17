using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Platform : IEntity
    {
        [Key]
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }

    }
}
