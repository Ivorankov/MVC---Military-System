using Microsoft.AspNet.Identity;
using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Areas.Troops.ViewModels;
using MilitarySystem.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUsersService users) : base(users)
        {

        }

        public ActionResult UserDetails()
        {
            var userId = User.Identity.GetUserId();
            var user = this.Users.GetById(userId);
            var userModel = this.Mapper.Map<UserDetailsViewModel>(user);

            return PartialView("_UserDetails", userModel);
        }
    }
}