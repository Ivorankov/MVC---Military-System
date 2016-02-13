namespace MilitarySystem.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using MilitarySystem.Services.Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        private ISquadsService squads;

        private IMissionsService missions;

        private IPlatoonsService platoons;

        public HomeController(IUsersService users, ISquadsService squads, IMissionsService missions, IPlatoonsService platoons)
            : base(users)
        {
            this.squads = squads;
            this.missions = missions;
            this.platoons = platoons;
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                var user = this.Users.GetById(userId);

                var squad = this.squads.GetById(1);
                var missions = this.missions.GetById(1);
                var platoon = this.platoons.GetById(1);

                var userModel = this.Mapper.Map<UserDetailsViewModel>(user);
                var squadModel = this.Mapper.Map<SquadDetailsViewModel>(squad);
                var missionModel = this.Mapper.Map<MissionDetailsViewModel>(missions);
                var platoonModel = this.Mapper.Map<PlatoonDetailsViewModel>(platoon);

                var indexViewModel = new IndexViewModel() { User = userModel, Squad = squadModel, Mission = missionModel, Message = new SendMessageViewModel(), Platoon = platoonModel };
                ViewBag.HeaderText = "Send Message To Platoon Leader";

                return View(indexViewModel);
            }

            return View();
        }
    }
}