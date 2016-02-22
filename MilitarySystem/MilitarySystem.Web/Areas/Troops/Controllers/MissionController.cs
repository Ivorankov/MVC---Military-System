namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using ViewModels;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Models;

    public class MissionController : TroopsController
    {
        private IMissionsService missions;

        private IUsersService users;

        private ISquadsService squads;

        public MissionController(IMissionsService missions, IUsersService users, ISquadsService squads)
        {
            this.missions = missions;
            this.users = users;
            this.squads = squads;
        }

        [HttpGet]
        public ActionResult Mission()
        {
            var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);
            var squad = this.squads.GetById(user.SquadId);

            if (squad.ActiveMissionId != null)
            {
                var mission = this.missions.GetById(squad.ActiveMissionId.GetValueOrDefault());
                var missionModel = this.Mapper.Map<MissionDetailsViewModel>(mission);
                return PartialView("_MissionDetails", missionModel);
            }

            return PartialView("_MissionDetails", null);
        }

        [HttpGet]
        public ActionResult AssignMission(int squadId)
        {
            var viewModel = new AddMIssionInputModel() { SquadId = squadId };
            return PartialView("_AddMissionBox", viewModel);
        }

        [HttpPost]
        public ActionResult AssignMission(AddMIssionInputModel missionModel)
        {
            object response;
            if (!ModelState.IsValid)
            {
                response = "Invalid data!";
                return Json(response);
            }

            var squad = this.squads.GetById(missionModel.SquadId);
            var mission = this.Mapper.Map<Mission>(missionModel);

            if (squad != null)
            {
                squad.ActiveMission = mission;
            }

            this.squads.Update(squad);

            response = "Mission assigned!";
            return Json(response);

        }

        [HttpPost]
        public ActionResult CompleteMission()
        {
            var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);
            var squad = this.squads.GetById(user.SquadId);
            squad.ActiveMission = null;
            squad.ActiveMissionId = null;
            this.squads.Update(squad);

            object response = "Marked as completed!";
            return Json(response);
            

        }
    }
}