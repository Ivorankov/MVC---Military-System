namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MilitarySystem.Common;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Administration.Models;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;
    using MilitarySystem.Web.Areas.Administration.Models.ViewModels;
    using MilitarySystem.Web.Controllers;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class PlatoonAdministrationController : BaseController
    {
        private const string BaseUrl = "/Administration/PlatoonAdministration/PlatoonDetails/";
        private IPlatoonsService platoons;

        private ISquadsService squads;

        private IUsersService users;

        public PlatoonAdministrationController(
            IPlatoonsService platoons,
            ISquadsService squads,
            IUsersService users
            )
        {
            this.platoons = platoons;
            this.squads = squads;
            this.users = users;
        }

        // GET: Administration/PlatoonAdministration
        public ActionResult Index()
        {
            var platoonModel = new PlatoonIndexModel();

            platoonModel.Platoons = this.platoons
                .GetAll()
                .To<PlatoonViewModel>()
                .OrderBy(x => x.Name)
                .ToList();

            return View(platoonModel);
        }

        [HttpGet]
        public ActionResult PlatoonDetails(int id)
        {
            var platoon = this.platoons.GetById(id);
            var platoonModel = this.Mapper.Map<PlatoonViewModel>(platoon);

            if (platoon.PlatoonCommanderId == null)
            {
                ViewBag.Soldiers = this.users
                    .GetAll()
                    .Where(x => x.SquadId == null)
                    .To<UserViewModel>()
                    .ToList();
            }

            ViewBag.Squads = this.squads
                    .GetAll()
                    .Where(x => x.PlatoonId == null)
                    .To<SquadInputModel>()
                    .ToList();

            ViewBag.PlatoonId = id;

            return View(platoonModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveSquad(int? squadId, int? platoonId)
        {
            var squad = this.squads.GetById(squadId);
            squad.PlatoonId = null;
            this.squads.Update(squad);

            return this.Redirect(BaseUrl + platoonId);
        }

        [HttpPost]
        public ActionResult AddSquad(int? squadId, int? platoonId)
        {
            var squad = this.squads.GetById(squadId);
            squad.PlatoonId = platoonId;
            this.squads.Update(squad);

            return this.Redirect(BaseUrl + platoonId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCommander(int? platoonId, string userId)
        {
            var platoon = this.platoons.GetById(platoonId);
            platoon.PlatoonCommanderId = userId;
            this.platoons.Update(platoon);

            this.users.AddToRole(userId, ModelsConstraints.PlatoonLeaderRoleName);

            return this.Redirect(BaseUrl + platoonId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveCommander(string platoonCommanderId, int? platoonId)
        {
            var platoon = this.platoons.GetById(platoonId);
            platoon.PlatoonCommanderId = null;
            this.platoons.Update(platoon);

            this.users.RemoveFromRole(platoonCommanderId, ModelsConstraints.PlatoonLeaderRoleName);

            return this.Redirect(BaseUrl + platoonId);
        }
    }
}