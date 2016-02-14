using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitarySystem.Web.Areas.Tea.Controllers
{
    public class TeaController : Controller
    {
        // GET: Tea/Tea
        public ActionResult Index()
        {
            return View();
        }
    }
}