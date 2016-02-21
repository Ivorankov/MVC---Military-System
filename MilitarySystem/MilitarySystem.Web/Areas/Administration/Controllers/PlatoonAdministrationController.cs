using MilitarySystem.Models;
using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Areas.Administration.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    public class PlatoonAdministrationController : GridAdministrationController<Platoon, PlatoonInputModel>
    {
        public PlatoonAdministrationController(IDataService<Platoon> platoon)
            : base(platoon)
        {


        }
        // GET: Administration/PlatoonAdministration
        public ActionResult Index()
        {
            return View();
        }
    }
}