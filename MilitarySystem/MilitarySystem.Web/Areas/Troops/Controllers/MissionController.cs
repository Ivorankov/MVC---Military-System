namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using ViewModels;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Controllers;


    public class MissionController : TroopsController
    {
        private IMissionsService missions;

        private IUsersService users;

        public MissionController(IMissionsService missions, IUsersService users)
        {
            this.missions = missions;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Mission()
        {
            var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);
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