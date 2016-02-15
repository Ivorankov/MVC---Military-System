using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Administration/Statistics
        public ActionResult Index()
        {
            return View();
        }
    }
}