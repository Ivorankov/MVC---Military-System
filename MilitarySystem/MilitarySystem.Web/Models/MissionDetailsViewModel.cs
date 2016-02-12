namespace MilitarySystem.Web.Models
{
    using MilitarySystem.Models;
    using Infrastructure.Mapping;
    using AutoMapper;

    public class MissionDetailsViewModel : IMapFrom<Mission>, IHaveCustomMappings
    {
        public string Info { get; set; }

        public decimal Lat { get; set; }

        public decimal Lgn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Mission, MissionDetailsViewModel>()
                .ForMember(x => x.Lat, opt => opt.MapFrom(x => x.TargetLocation.Lat))
            .ForMember(x => x.Lgn, opt => opt.MapFrom(x => x.TargetLocation.Lgn));

        }
    }
}