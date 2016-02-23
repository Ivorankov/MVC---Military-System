namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using MilitarySystem.Web.Controllers;
    using Common;

    [Authorize(Roles = ModelsConstraints.AdminRoleName)]
    public class AdministrationController : BaseController
    {
        // GET: Administration/Administration
        public ActionResult Index()
        {
            return View();
        }
    }
}