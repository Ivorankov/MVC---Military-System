namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using MilitarySystem.Web.Controllers;

    public class AdministrationController : BaseController
    {
        // GET: Administration/Administration
        public ActionResult Index()
        {
            return View();
        }
    }
}