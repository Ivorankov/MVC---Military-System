namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class ManufacturerInputModel : IMapTo<Manufacturer>
    {
        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Name { get; set; }
    }
}