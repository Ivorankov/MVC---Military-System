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

        public HomeController(IUsersService users, ISquadsService squads, IMissionsService missions)
            : base(users)
        {
            this.squads = squads;
            this.missions = missions;
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                var user = this.Users.GetById(userId);

                var squad = this.squads.GetById(user.SquadId.GetValueOrDefault());
                var missions = this.missions.GetById(squad.Missions.Where(x => x.IsActive == false).FirstOrDefault().Id);

                var userModel = this.Mapper.Map<UserDetailsViewModel>(user);
                var squadModel = this.Mapper.Map<SquadDetailsViewModel>(squad);
                var missionModel = this.Mapper.Map<MissionDetailsViewModel>(missions);

                var indexViewModel = new IndexViewModel() { User = userModel, Squad = squadModel, Mission = missionModel };

                return View(indexViewModel);
            }
            return View();
        }
    }
}