using Microsoft.AspNet.Identity;
using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Areas.Troops.ViewModels;
using MilitarySystem.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    public class SquadController : BaseController
    {
        private IMissionsService missions;

        private ISquadsService squads;

        public SquadController(IMissionsService missions, ISquadsService squads, IUsersService users)
            :base(users)
        {
            this.squads = squads;
            this.missions = missions;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserDetails()
        {
            var userId = User.Identity.GetUserId();
            var user = this.Users.GetById(userId);
            var userModel = this.Mapper.Map<UserDetailsViewModel>(user);

            return PartialView("_UserDetails", userModel);
        }

        public ActionResult SquadDetails()
        {
            var userId = User.Identity.GetUserId();
            var user = this.Users.GetById(userId);
            var squad = this.squads.GetById(user.SquadId.GetValueOrDefault());
            var squadModel = this.Mapper.Map<SquadDetailsViewModel>(squad);

            return PartialView("_SquadDetails", squadModel);
        }

        public ActionResult Chat()
        {
            return PartialView("_Chat");
        }

        public ActionResult Message()
        {
            return PartialView("_SendMessage");
        }

        public ActionResult Mission()
        {
            var userId = User.Identity.GetUserId();
            var user = this.Users.GetById(userId);
            var mission = this.missions.GetById(user.SquadId.GetValueOrDefault());
            if (mission != null)
            {
                var missions = this.missions.GetById(mission.Id);
                var missionModel = this.Mapper.Map<MissionDetailsViewModel>(missions);

                return PartialView("_MissionDetails", missionModel);
            }

            return Json(null);
        }
    }
}