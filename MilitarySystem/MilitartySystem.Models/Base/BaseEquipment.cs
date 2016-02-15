namespace MilitarySystem.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEquipment
    {
        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
