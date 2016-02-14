namespace MilitarySystem.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Areas.Troops.ViewModels;
    using Services.Contracts;

    public class HomeController : Controller
    {

        public HomeController()
        {

        }
        public ActionResult Index()
        {

            return View();
        }
    }
}