namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    using AutoMapper;

    using MilitarySystem.Models;
    using Infrastructure.Mapping;

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