namespace MilitarySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using MilitarySystem.Common;

    public class Mission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.MessageMaxLength)]
        public string Info { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Lat { get; set; }

        [Required]
        [Range(-180, 180)]
        public decimal Lgn { get; set; }

        public int? SquadId { get; set; }

        public virtual Squad Squad { get; set; }

        public bool IsActive { get; set; }

        //Type enum TODO maybe
    }
}
