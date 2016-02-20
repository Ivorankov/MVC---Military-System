namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Troops.ViewModels;
    using MilitarySystem.Web.Controllers;

    public class UserController : TroopsController
    {
        private IUsersService users;

        public UserController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult UserDetails()
        {
            var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);
            var userModel = this.Mapper.Map<UserDetailsViewModel>(user);

            return PartialView("_UserDetails", userModel);
        }
    }
}