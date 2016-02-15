namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    public class ChatController : Controller
    {
        public ActionResult Chat()
        {
            return PartialView("_Chat");
        }
    }
}