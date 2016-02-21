namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    using AutoMapper;

    using MilitarySystem.Models;
    using Infrastructure.Mapping;

    public class MissionDetailsViewModel : IMapFrom<Mission>
    {
        public string Info { get; set; }

        public decimal Lat { get; set; }

        public decimal Lgn { get; set; }
    }
}