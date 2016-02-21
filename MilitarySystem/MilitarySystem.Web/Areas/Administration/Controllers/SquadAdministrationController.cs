namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using MilitarySystem.Models;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;

    public class SquadAdministrationController : GridAdministrationController<Squad, SquadInputModel>
    {
        public SquadAdministrationController(IDataService<Squad> squad) 
            : base(squad)
        {

        }
        // GET: Administration/SquadAdministration
        public ActionResult Index()
        {
            return View();
        }
    }
}