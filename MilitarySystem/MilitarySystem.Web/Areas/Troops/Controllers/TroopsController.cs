namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using Microsoft.AspNet.Identity;
    using MilitarySystem.Services.Contracts;
    using Web.Controllers;
    using System.Web.Mvc;
    using ViewModels;

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