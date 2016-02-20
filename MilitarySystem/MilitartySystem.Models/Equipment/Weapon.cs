using System.ComponentModel.DataAnnotations;

namespace MilitarySystem.Models
{
    public class Weapon : BaseEquipment
    {
        [Required]
        public int Id { get; set; }
    }
}
