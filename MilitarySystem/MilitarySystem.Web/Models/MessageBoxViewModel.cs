namespace MilitarySystem.Web.Models
{
    using System;

    using AutoMapper;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class MessageBoxViewModel : IMapFrom<Platoon>, IHaveCustomMappings
    {
        public string From { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Message, MessageBoxViewModel>()
            .ForMember(x => x.From, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName));
        }
    }
}