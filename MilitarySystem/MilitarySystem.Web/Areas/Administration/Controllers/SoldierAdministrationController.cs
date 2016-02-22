
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MilitarySystem.Data;
using MilitarySystem.Data.Contracts;
using MilitarySystem.Models;
using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Areas.Administration.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitarySystem.Common;

namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    public class SoldierAdministrationController : GridAdministrationController<User, UserInputModel>
    {
        private IUsersService users;

        public SoldierAdministrationController(
            IDataService<User> user,
            IUsersService users)
            : base(user)
        {
            this.users = users;
        }

        // GET: Administration/SoldierAdministraton
        public ActionResult Index()
        {
            return View();
        }
    }
}