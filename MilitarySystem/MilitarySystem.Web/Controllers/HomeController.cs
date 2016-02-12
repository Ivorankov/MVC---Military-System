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
        private ISquadsService squads;

        public HomeController(IUsersService users, ISquadsService squads)
            : base(users)
        {
            this.squads = squads;
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                var user = this.Users.GetById(userId);

                var squad = this.squads.GetById(user.SquadId.GetValueOrDefault());

                var userModel = this.Mapper.Map<UserDetailsViewModel>(user);
                var squadModel = this.Mapper.Map<SquadDetailsViewModel>(squad);

                var indexViewModel = new IndexViewModel() { User = userModel, Squad = squadModel };

                return View(indexViewModel);
            }
            return View();
        }
    }
}