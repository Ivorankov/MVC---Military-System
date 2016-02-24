namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    using System.Collections.Generic;

    using AutoMapper;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class PlatoonDetailsViewModel : IMapFrom<Platoon>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string PlatoonCommanderId { get; set; }

        public string PlatoonCommanderName { get; set; }

        public ICollection<Squad> Squads { get; set; }

        public ICollection<Message> Messages { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Platoon, PlatoonDetailsViewModel>()
                        .ForMember(x => x.PlatoonCommanderName, opt => opt.MapFrom(x => x.PlatoonCommander.FirstName + " " + x.PlatoonCommander.LastName));
        }
    }
}