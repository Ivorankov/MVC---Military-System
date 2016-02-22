namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;

    using Infrastructure.Mapping;
    using MilitarySystem.Services.Contracts;
    using Models.ViewModels;
    using Web.Controllers;


    public class SquadAdministrationController : BaseController
    {
        private const string BaseUrl = "/Administration/SquadAdministration/SquadDetails/";

        private IUsersService users;

        private ISquadsService squads;

        private IVehiclesService vehicles;


        public SquadAdministrationController(IUsersService users, ISquadsService squads, IVehiclesService vehicles)
        {
            this.users = users;
            this.squads = squads;
            this.vehicles = vehicles;
        }

        // GET: Administration/SquadAdministration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SquadDetails(int id)
        {
            var squad = this.squads.GetById(id);
            var squadModel = this.Mapper.Map<SquadViewModel>(squad);

            ViewBag.Vehicles = this.vehicles
                .GetAll()
                .Where(x => x.SquadId == null)
                .ToList();

            ViewBag.UnassignedSoldiers = this.users
                .GetAll()
                .Where(x => x.SquadId == null)
                .To<UserViewModel>()
                .ToList();

            ViewBag.SoldiersInSquad = this.users
                .GetAll()
                .Where(x => x.SquadId == id && x.Id != squad.SquadLeaderId)
                .To<UserViewModel>()
                .ToList();

            return View(squadModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveSoldier(string soldierId, int? squadId)
        {
            var soldier = this.users.GetById(soldierId);
            soldier.SquadId = null;
            this.users.Update(soldier);

            return this.Redirect(BaseUrl + squadId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSoldier(string soldierId, int? squadId)
        {
            var soldier = this.users.GetById(soldierId);
            soldier.SquadId = squadId;
            this.users.Update(soldier);

            return this.Redirect(BaseUrl + squadId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignLeader(int? squadId, string soldierId)
        {
            var squad = this.squads.GetById(squadId);
            squad.SquadLeaderId = soldierId;
            this.squads.Update(squad);

            this.users.AddToRole(soldierId, ModelsConstraints.SquadLeaderRoleName);

            return this.Redirect(BaseUrl + squadId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveLeader(int? squadId, string squadLeaderId)
        {
            var squad = this.squads.GetById(squadId);
            squad.SquadLeaderId = null;
            this.squads.Update(squad);

            this.users.RemoveFromRole(squadLeaderId, ModelsConstraints.SquadLeaderRoleName);

            return this.Redirect(BaseUrl + squadId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveVehicle(int? squadId, int? id)
        {
            var vehicle = this.vehicles.GetById(id);


            vehicle.SquadId = null;
            this.vehicles.Update(vehicle);

            return this.Redirect(BaseUrl + squadId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVehicle(int? squadId, int? id)
        {
            var vehicle = this.vehicles.GetById(id);
            vehicle.SquadId = squadId;
            this.vehicles.Update(vehicle);

            return this.Redirect(BaseUrl + squadId);
        }
    }
}