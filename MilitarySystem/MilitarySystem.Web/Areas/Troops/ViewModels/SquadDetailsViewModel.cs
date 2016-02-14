namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class SquadDetailsViewModel :IMapFrom<Squad>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public List<SoldierInListModel> Members { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        public string SquadLeaderName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Squad, SquadDetailsViewModel>()
                .ForMember(x => x.SquadLeaderName, opt => opt.MapFrom(x => x.SquadLeader.FirstName + " " + x.SquadLeader.LastName))
                .ForMember(x => x.Members, opt => opt.MapFrom(x => CastToSoldierListModel(x.Soldiers)));

        }

        private List<SoldierInListModel> CastToSoldierListModel(ICollection<User> Soldiers)
        {
            var result = new List<SoldierInListModel>();
            foreach (var item in Soldiers)
            {
                result.Add(new SoldierInListModel()
                {
                    Id = item.Id,
                    FullName = item.FirstName + " " + item.LastName
                });
            }

            return result;
        }
    }
}