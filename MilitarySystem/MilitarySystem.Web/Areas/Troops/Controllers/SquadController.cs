namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Troops.ViewModels;
    using MilitarySystem.Web.Controllers;

    public class SquadController : BaseController
    {
        private ISquadsService squads;

        public SquadController(ISquadsService squads, IUsersService users)
            :base(users)
        {
            this.squads = squads;

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
    }
}