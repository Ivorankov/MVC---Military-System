using MilitarySystem.Common;
using System.ComponentModel.DataAnnotations;

namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    public class AddMIssionInputModel
    {
        [Required]
        public int SquadId { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.MessageMaxLength)]
        public string Info { get; set; }

        [Required]
        public int TargetLocationId { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Lat { get; set; }

        [Required]
        [Range(-180, 180)]
        public decimal Lgn { get; set; }
    }
}