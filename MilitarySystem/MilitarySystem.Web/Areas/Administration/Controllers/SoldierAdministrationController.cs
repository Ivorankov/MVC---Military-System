namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using MilitarySystem.Models;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;

    public class SoldierAdministrationController : GridAdministrationController<User, UserInputModel>
    {
        private IUsersService users;

        public SoldierAdministrationController(
            IDataService<User> user,
            IUsersService users)
            : base(user)
        {
            this.users = users;
        }

        // GET: Administration/SoldierAdministraton
        public ActionResult Index()
        {
            return View();
        }
    }
}