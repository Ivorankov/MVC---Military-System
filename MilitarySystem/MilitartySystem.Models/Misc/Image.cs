namespace MilitarySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] ImgData { get; set; }

        [MaxLength(ModelsConstraints.ExtentionMaxLength)]
        public string Extention { get; set; }
    }
}
