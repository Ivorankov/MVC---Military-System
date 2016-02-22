namespace MilitarySystem.Web.Areas.Administration.Models.ViewModels
{
    using System.Collections.Generic;

    using AutoMapper;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class PlatoonViewModel : IMapFrom<Platoon>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string PlatoonCommanderId { get; set; }

        public string PlatoonCommanderName { get; set; }

        public ICollection<Squad> Squads { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Platoon, PlatoonViewModel>()
                    .ForMember(x => x.PlatoonCommanderName, opt => opt.MapFrom(x => x.PlatoonCommander.FirstName + x.PlatoonCommander.LastName));
        }
    }
}