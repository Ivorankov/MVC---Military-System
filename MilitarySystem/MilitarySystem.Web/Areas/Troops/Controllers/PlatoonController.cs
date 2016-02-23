namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using Common;
    using ViewModels;
    using MilitarySystem.Services.Contracts;

    [Authorize(Roles = ModelsConstraints.PlatoonLeaderRoleName)]
    public class PlatoonController : TroopsController
    {
        private IPlatoonsService platoons;

        private ISquadsService squads;

        private IUsersService users;

        public PlatoonController(IPlatoonsService platoons, ISquadsService squads, IUsersService users)
        {
            this.platoons = platoons;
            this.squads = squads;
            this.users = users;
        }

        [HttpGet]
        public ActionResult PlatoonDetails(string userId)
        {
            //var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);

            var platoon = this.platoons
                .GetAll()
                .FirstOrDefault(x => x.PlatoonCommanderId == user.Id);


            var platoonModel = this.Mapper.Map<PlatoonDetailsViewModel>(platoon);
            return this.PartialView("_PlatoonDetails", platoonModel);

        }
    }
}