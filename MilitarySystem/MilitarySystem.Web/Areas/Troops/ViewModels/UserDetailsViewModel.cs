namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    using System;
    using AutoMapper;
    using MilitarySystem.Web.Infrastructure.Mapping;
    using MilitarySystem.Models;

    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string FullName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string RankImgUrl { get; set; }

        public int MissionsCount { get; set; }

        public decimal Wage { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserDetailsViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.MissionsCount, opt => opt.MapFrom(x => x.Missions.Count))
                .ForMember(x => x.RankImgUrl, opt => opt.MapFrom(x => SelectBadge(x.Rank)));
        }

        private string SelectBadge(int rank)
        {
            switch (rank)
            {
                case 1: return "Content/CorporalBadge.png";
                case 2: return "Content/SergeantBadge.png";
                case 3: return "Content/LieutenantBadge.png";
                default: return "/";
            }
        }
    }
}
//wage
//weapons
//gear
//missions