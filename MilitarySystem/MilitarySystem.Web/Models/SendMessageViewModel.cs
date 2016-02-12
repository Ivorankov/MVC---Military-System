namespace MilitarySystem.Web.Models
{
    using System;

    using AutoMapper;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class SendMessageViewModel : IMapTo<Squad>
    {
        public string UserId { get; set; }

        public string Content { get; set; }

    }
}