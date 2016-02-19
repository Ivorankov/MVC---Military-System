namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    public class ChatController : TroopsController
    {
        [HttpGet]
        public ActionResult Chat()
        {
            return PartialView("_Chat");
        }
    }
}