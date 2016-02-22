namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Common;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class ManufacturerInputModel : IMapTo<Manufacturer>, IMapFrom<Manufacturer>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Name { get; set; }

        public int Id { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Manufacturer, ManufacturerInputModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}