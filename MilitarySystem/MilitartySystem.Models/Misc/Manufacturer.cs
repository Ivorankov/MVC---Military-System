namespace MilitarySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Name { get; set; }
    }
}
