namespace MilitarySystem.Web.Areas.Troops.ViewModels
{

    using AutoMapper;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;
    using System.Collections.Generic;

    public class MessageBoxViewModel : IMapFrom<Message>
    {
        public List<Message> Content { get; set; }
    }
}