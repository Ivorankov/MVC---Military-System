namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Troops.ViewModels;
    using MilitarySystem.Web.Controllers;

    public class SquadController : TroopsController
    {
        private ISquadsService squads;

        private IUsersService users;

        public SquadController(ISquadsService squads, IUsersService users)
        {
            this.squads = squads;
            this.users = users;

        }

        [HttpGet]
        public ActionResult SquadDetails(string userId)
        {
            //var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);
            var squad = this.squads.GetById(user.SquadId.GetValueOrDefault());
            var squadModel = this.Mapper.Map<SquadDetailsViewModel>(squad);

            return PartialView("_SquadDetails", squadModel);
        }
    }
}