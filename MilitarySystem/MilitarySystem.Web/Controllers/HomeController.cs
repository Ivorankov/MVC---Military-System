namespace MilitarySystem.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using MilitarySystem.Services.Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {

        public HomeController(IUsersService users)
            : base(users)
        {

        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var model = this.Users.GetById(userId);
            if (userId != null)
            {
                var result = this.Mapper.Map<UserDetailsViewModel>(model);

                return View(result);
            }
            return View();
        }
    }
}