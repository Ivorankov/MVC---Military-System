namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using MilitarySystem.Services.Contracts;
    using Web.Controllers;
    using ViewModels;

    public class PlatoonController : BaseController
    {
        private IPlatoonsService platoons;

        private ISquadsService squads;

        private IUsersService users;

        public PlatoonController(IPlatoonsService platoons, ISquadsService squads,  IUsersService users)
        {
            this.platoons = platoons;
            this.squads = squads;
            this.users = users;
        }

        [HttpGet]
        public ActionResult PlatoonDetails()
        {
            var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);

            var platoon = this.platoons
                .GetAll()
                .FirstOrDefault(x => x.PlatoonCommanderId == user.Id);

            if(platoon != null)
            {
                var platoonModel = this.Mapper.Map<PlatoonDetailsViewModel>(platoon);
                return this.PartialView("_PlatoonDetails", platoonModel);
            }

            return Json(null);
        }

        //[HttpPost]
        //public ActionResult AssignMission(int id)
        //{
        //    var squad = this.squads.GetById(id);

        //}
    }
}