namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using ViewModels;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Controllers;


    public class MissionController : BaseController
    {
        private IMissionsService missions;

        public MissionController(IMissionsService missions, IUsersService users)
            :base(users)
        {

            this.missions = missions;
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