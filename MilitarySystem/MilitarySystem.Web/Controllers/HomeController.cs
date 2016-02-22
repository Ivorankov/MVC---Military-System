namespace MilitarySystem.Web.Controllers
{
    using System.Web.Mvc;

    using MilitarySystem.Common;

    public class HomeController : Controller
    {

        public HomeController()
        {

        }
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var url = "/Troops/Troops";

                if (HttpContext.User.IsInRole(ModelsConstraints.AdminRoleName))
                {
                    url = "/Administration/Administration";
                }

                return this.Redirect(url);
            }

            return View();
        }
    }
}