namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using Common;

    [Authorize]
    public class TroopsController : BaseController
    {
        public TroopsController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}