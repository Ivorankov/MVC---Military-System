namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MilitarySystem.Common;
    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;
    public class SquadInputModel : IMapFrom<Squad>, IMapTo<Squad>
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Name { get; set; }

    }
}