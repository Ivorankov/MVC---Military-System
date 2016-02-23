namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class SendMessageViewModel
    {
        [Required]
        [MaxLength(Common.ModelsConstraints.MessageMaxLength)]
        public string Content { get; set; }

    }
}