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
        public int TargetLocationId { get; set; }

        public virtual Location TargetLocation { get; set; }

        public int? SquadId { get; set; }

        public virtual Squad Squad { get; set; }

        public bool IsActive { get; set; }

        //Type enum TODO maybe
    }
}
