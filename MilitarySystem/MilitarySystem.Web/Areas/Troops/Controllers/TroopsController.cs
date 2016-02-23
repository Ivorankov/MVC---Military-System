namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;
    using Common;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class TroopsController : BaseController
    {
        public TroopsController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }
    }
}