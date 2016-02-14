namespace MilitarySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Lat { get; set; }

        [Required]
        [Range(-180, 180)]
        public decimal Lgn { get; set; }
    }
}
