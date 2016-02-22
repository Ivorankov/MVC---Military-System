namespace MilitarySystem.Web.Areas.Administration.Models.ViewModels
{
    using System.Collections.Generic;
    using AutoMapper;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class SquadViewModel : IMapFrom<Squad>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string SquadLeaderId { get; set; }

        public string SquadLeaderName { get; set; }

        public int? PlatoonId { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual ICollection<User> Soldiers { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Squad, SquadViewModel>()
        .ForMember(x => x.SquadLeaderName, opt => opt.MapFrom(x => x.SquadLeader.FirstName + " " + x.SquadLeader.LastName));
        }
    }
}