namespace MilitarySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.MessageMaxLength)]
        public string Content { get; set; }
    }
}
