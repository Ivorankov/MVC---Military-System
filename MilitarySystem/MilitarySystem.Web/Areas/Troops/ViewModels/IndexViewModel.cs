﻿namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    public class IndexViewModel
    {
        public SquadDetailsViewModel Squad { get; set; }

        public UserDetailsViewModel User { get; set; }

        public MissionDetailsViewModel Mission {get;set;}

        public SendMessageViewModel Message { get; set; }

        public PlatoonDetailsViewModel Platoon { get; set; }
    }
}