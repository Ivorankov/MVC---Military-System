namespace MilitarySystem.Web.Models
{
    using System;
    using AutoMapper;
    using MilitarySystem.Web.Infrastructure.Mapping;
    using MilitarySystem.Models;

    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string FullName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int Rank { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserDetailsViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));
        }
    }
}