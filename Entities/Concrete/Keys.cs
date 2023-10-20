using Core.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Keys:IEntity
    {
        [Key]
        public int KeyId { get; set; }
        public int GameId { get; set; }
        public string KeyDetail { get; set; }
        public DateTime EndDate { get; set; }
    }
}
